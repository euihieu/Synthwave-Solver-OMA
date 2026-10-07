using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    public bool isDead;
    private bool playerUnlocked;

    public InputSystem_Actions input;

    [Header("Knockback Info")]
    [SerializeField] private Vector2 knockbackDir;
    private bool isKnocked;
    private bool canBeKnocked = true;

    [Header("Move Info")]
    [SerializeField] public float moveSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speedMultiplier;
    private float defaultSpeed;
    [Space]
    [SerializeField] private float milestoneIncreaser;
    private float defaultMilestoneIncrease;
    private float speedMileStone;

    [Header("Jump Info")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float doubleJumpForce;
    private bool canDoubleJump;

    [Header("Slide Info")]
    [SerializeField] private float slideSpeed;
    [SerializeField] private float slideTime;
    [SerializeField] private float slideCoolDown;
    private float slideCoolDownCounter;
    private float slideTimerCounter;
    private bool isSliding;

    [Header("Collision Info")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float ceilingCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Vector2 wallCheckSize;
    private bool isGrounded;
    private bool wallDetected;
    private bool ceilingDetected;
    [HideInInspector] public bool ledgeDetected;

    [Header("Ledge Info")]
    [SerializeField] private Vector2 offset1; //offset for position before climb
    [SerializeField] private Vector2 offset2; //offset for position after climb

    private Vector2 climbBegunPosition;
    private Vector2 climbOverPosition;

    private bool canGrabLedge = true;
    private bool canClimb;



    private void Awake()
    {
        input = new InputSystem_Actions();
    }

    private void OnEnable()

    {
        input.Enable();

        input.Player.Jump.performed += OnJump;
        input.Player.Slide.performed += OnSlide;
        input.Player.Start.performed += OnStart;
    }

    private void OnJump(InputAction.CallbackContext context)
        {
            if (isDead || isKnocked) return;
            JumpButton();
        SoundManager.instance.PlaySound("jump");
        }

    private void OnSlide(InputAction.CallbackContext context)
        {
            if (isDead || isKnocked) return;
            SlideButton();
        }

    private void OnStart(InputAction.CallbackContext context)
        {
            playerUnlocked = true;
        }

    public void OnDisable()
    {
        input.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        speedMileStone = milestoneIncreaser;
        defaultSpeed = moveSpeed;
        defaultMilestoneIncrease = milestoneIncreaser;

        StartCoroutine(Invincibility());
    }

    void Update()
    {
        CheckCollision();
        AnimatorControllers();

        slideTimerCounter -= Time.deltaTime;
        slideCoolDownCounter -= Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.K))
            Knockback();

        if (Input.GetKeyDown(KeyCode.O) && !isDead)
            StartCoroutine(Die());

        if (isDead)
            return;

        if (isKnocked)
            return;

        if (playerUnlocked)
            SetupMovement();

        if (isGrounded)
            canDoubleJump = true;

        SpeedController();

        CheckForLedge();
        CheckForSlideCancel();
    }

    public void Damage()
    {
        if (moveSpeed >= maxSpeed)
            Knockback();
        else
            StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        isDead = true;
        canBeKnocked = false;
        rb.linearVelocity = knockbackDir;
        anim.SetBool("isDead", true);

        yield return new WaitForSeconds(.5f);
        rb.linearVelocity = new Vector2(0, 0);
    }

    #region Knockback

    private IEnumerator Invincibility()
    {
        Color originalColor = sr.color;
        Color darkenColor = new Color(sr.color.r, sr.color.g, sr.color.b, .5f);

        canBeKnocked = false;

        sr.color = darkenColor;
        yield return new WaitForSeconds(.1f);

        sr.color = originalColor;
        yield return new WaitForSeconds(.1f);

        sr.color = darkenColor;
        yield return new WaitForSeconds(.15f);

        sr.color = originalColor;
        yield return new WaitForSeconds(.15f);

        sr.color = darkenColor;
        yield return new WaitForSeconds(.25f);

        sr.color = originalColor;
        yield return new WaitForSeconds(.25f);

        sr.color = darkenColor;
        yield return new WaitForSeconds(.3f);

        sr.color = originalColor;
        canBeKnocked = true;
    }


    private void Knockback()
    {
        if (!canBeKnocked)
            return;

        StartCoroutine(Invincibility());
        isKnocked = true;
        rb.linearVelocity = knockbackDir;
    }

    private void CancelKnockback() => isKnocked = false;

    #endregion

    #region SpeedControl

    private void SpeedReset()
    {
        moveSpeed = defaultSpeed;
        milestoneIncreaser = defaultMilestoneIncrease;
    }

    private void SpeedController()
    {
        if (moveSpeed == maxSpeed)
            return;

        if (transform.position.x > speedMileStone)
        {
            speedMileStone = speedMileStone + milestoneIncreaser;

            moveSpeed = moveSpeed * speedMultiplier;
            milestoneIncreaser = milestoneIncreaser * speedMultiplier;

            if (moveSpeed > maxSpeed)
                moveSpeed = maxSpeed;
        }
    }

    #endregion

    #region Ledge Climb Region

    private void CheckForLedge()
    {
        if (ledgeDetected && canGrabLedge)
        {
            canGrabLedge = false;
            rb.gravityScale = 0;

            Vector2 ledgePosition = GetComponentInChildren<LedgeDetection>().transform.position;

            climbBegunPosition = ledgePosition + offset1;
            climbOverPosition = ledgePosition + offset2;

            canClimb = true;
        }

        if (canClimb)
            transform.position = climbBegunPosition;

    }

    private void LedgeClimbOver()
    {
        canClimb = false;
        rb.gravityScale = 5;
        transform.position = climbOverPosition;
        Invoke("AllowLedgeGrab", .1f);
    }

    private void AllowLedgeGrab() => canGrabLedge = true;

    #endregion

    private void CheckForSlideCancel()
    {
        if (slideTimerCounter < 0 && !ceilingDetected)
            isSliding = false;
    }

    private void SetupMovement()
    {
        if (wallDetected)
        {
            SpeedReset();
            return;
        }

        if (isSliding)
            rb.linearVelocity = new Vector2(slideSpeed, rb.linearVelocity.y);
        else
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    #region Inputs

    private void SlideButton()
    {
        if (rb.linearVelocity.x != 0 && slideCoolDownCounter < 0)
        {
            isSliding = true;
            slideTimerCounter = slideTime;
            slideCoolDownCounter = slideCoolDown;
        }
    }

    private void JumpButton()
    {
        if (isSliding)
            return;

        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        else if (canDoubleJump)
        {
            canDoubleJump = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, doubleJumpForce);
        }
    }



    #endregion

    #region Animations

    private void AnimatorControllers()
    {
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
        anim.SetFloat("yVelocity", rb.linearVelocity.y);

        anim.SetBool("canDoubleJump", canDoubleJump);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isSliding", isSliding);
        anim.SetBool("canClimb", canClimb);
        anim.SetBool("isKnocked", isKnocked);

        if (rb.linearVelocity.y < 20)
            anim.SetBool("canRoll", true);
    }

    private void RollAnimFinished() => anim.SetBool("canRoll", false);

    #endregion

    private void CheckCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
        ceilingDetected = Physics2D.Raycast(transform.position, Vector2.up, ceilingCheckDistance, whatIsGround);
        wallDetected = Physics2D.BoxCast(wallCheck.position, wallCheckSize, 0, Vector2.zero, 0, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y + ceilingCheckDistance));
        Gizmos.DrawWireCube(wallCheck.position, wallCheckSize);
    }
}
