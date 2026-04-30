using UnityEngine;
using UnityEngine.InputSystem;

public class BallJump : MonoBehaviour
{
    Rigidbody rb;
    InputAction jumpAction;

    public float jumpForce = 10f;
    public float groundDistanceCheck = 1.2f;
    public LayerMask groundMask;
    private bool canJump = true;
    
    [HideInInspector]
    public bool isJumping = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpAction = InputSystem.actions.FindAction("Jump");
        jumpAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        canJump = Physics.Raycast(transform.position, Vector3.down, groundDistanceCheck, groundMask);
        isJumping = !canJump;

        bool jumpPressed = jumpAction.WasPressedThisFrame();

        if (jumpPressed && canJump)
        {
             Vector3 velocity = rb.linearVelocity;
            velocity.y = 0f;
            rb.linearVelocity = velocity;
            
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }

    }
}
