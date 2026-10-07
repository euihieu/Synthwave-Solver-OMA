using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Adding jump and crouch with new unity input action
    //
    private float jumpForce = 20f;
    private Rigidbody2D rb;
    private bool isGrounded;

    private InputAction jumpAction;
    private InputAction crouchAction;

    public InputActionAsset inputActionAsset;

    private Vector2 originalScale;
    private float scaleCrouch = 0.5f;


    ////////////////////////////////////////////////////////////////////////
    private void OnEnable()
    {
        inputActionAsset.FindActionMap("Player").Enable();
        inputActionAsset.FindActionMap("UI").Enable();
    }

    private void OnDisable()
    {
        inputActionAsset.FindActionMap("Player").Disable();
        inputActionAsset.FindActionMap("UI").Disable();
    }
    ////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////
    void Awake()
    {
        jumpAction = inputActionAsset.FindActionMap("Player").FindAction("Jump");
        crouchAction = inputActionAsset.FindActionMap("Player").FindAction("Crouch");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
        originalScale = transform.localScale;
    }

    void Update()
    {
        jump();
        crouch();
    }
    ////////////////////////////////////////////////////////////////////////


    void jump()
    {
        if (jumpAction.WasPressedThisFrame() && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void crouch()
    {
        if (crouchAction.WasPressedThisFrame() && isGrounded)
        {
            transform.localScale = new Vector2(originalScale.x, scaleCrouch);
        }
        else if (crouchAction.WasReleasedThisFrame())
        {
            transform.localScale = originalScale;
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            // inputActionAsset.FindActionMap("Player").Disable();
        }
    }
}
