using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTest : MonoBehaviour
{
    public InputAction myJump, myDuck;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        myJump = InputSystem.actions.FindAction("Jump");
        myDuck = InputSystem.actions.FindAction("Crouch");
    }

    // Update is called once per frame
    void Update()
    {
        if (myJump.triggered)
        {
            animator.Play("Jump");
        }
        if (myDuck.triggered)
        {
            animator.Play("Duck");
        }
    }
}
