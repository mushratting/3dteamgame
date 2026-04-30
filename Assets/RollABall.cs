using UnityEngine;
using UnityEngine.InputSystem; // Required to use Unity's new Input System


public class RollABall : MonoBehaviour
{
    public float acceleration = 10f;
    // Controls how strongly the ball accelerates when input is applied
    public float sprintSpeed = 15f;
    public Transform cameraTransform;
    // Reference to the active camera (usually the Main Camera with Cinemachine Brain)
    // Used to make movement relative to the camera's view direction

    Rigidbody rb;
    // Reference to the Rigidbody component (handles physics)

    InputAction moveAction;
    // Reference to the "Move" action from the Input System (WASD / stick)
    InputAction sprintAction;

    // Called once when the object is first created
    void Start()
    {
        // Cache the Rigidbody so we can apply physics forces to it
        rb = GetComponent<Rigidbody>();

        // Find the "Move" input action defined in the Input Actions asset
        moveAction = InputSystem.actions.FindAction("Move");

        sprintAction = InputSystem.actions.FindAction("Sprint");

        // Lock and hide the mouse cursor for mouse-look camera control
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Called once per frame
    void Update()
    {
        // Read player movement input (X = left/right, Y = forward/back)
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        // Get the camera's forward direction
        // We ignore the Y axis so movement stays on the ground plane
        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        // Get the camera's right direction (for strafing)
        // Again, ignore Y so the ball doesn't move up or down
        Vector3 camRight = cameraTransform.right;
        camRight.y = 0f;
        camRight.Normalize();

        // Combine input with camera directions
        // This makes "forward" always mean "forward relative to the camera"
        Vector3 moveDir = camRight * moveInput.x + camForward * moveInput.y;

        bool isSprinting = sprintAction.IsPressed();
        if (isSprinting)
        {
        rb.AddForce(moveDir * sprintSpeed, ForceMode.Acceleration);
        }
        else {
        rb.AddForce(moveDir * acceleration, ForceMode.Acceleration);
        }
    }
}