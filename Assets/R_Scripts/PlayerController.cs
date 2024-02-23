using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the movement speed
    public Animator animator; // Reference to the Animator component
    public Transform playerModel; // Reference to the player model (to rotate)

    // Animation trigger names
    private const string IdleTrigger = "Idle";
    private const string ShootTrigger = "Shoot";
    private const string DefendTrigger = "Defend";

    private bool isShooting = false; // Flag to track if shooting animation is playing
    private bool isDefending = false; // Flag to track if defending animation is playing
    private bool isRunning = false; // Flag to track if the player is running

    void Update()
    {
        // Input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Rotate the player model to face the movement direction
        if (moveDirection != Vector3.zero)
        {
            playerModel.rotation = Quaternion.LookRotation(moveDirection);
        }

        // Move the player in the correct direction if not shooting or defending
        if (!isShooting && !isDefending)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

            // Update running state
            isRunning = moveDirection != Vector3.zero;
            // Set animation parameters
            animator.SetBool("IsRunning", isRunning);
        }
        else
        {
            // Set back to idle animation if shooting or defending
            animator.SetTrigger(IdleTrigger);
        }

        // Handle shoot animation
        if (Input.GetMouseButtonDown(0) && !isShooting) // Left click
        {
            animator.SetTrigger(ShootTrigger);
            isShooting = true;
            isDefending = false; // Reset defending flag
        }
        else if (Input.GetMouseButtonUp(0)) // Release left click
        {
            animator.ResetTrigger(ShootTrigger);
            isShooting = false;
        }

        // Handle defend animation
        if (Input.GetMouseButtonDown(1) && !isDefending) // Right click
        {
            animator.SetTrigger(DefendTrigger);
            isDefending = true;
            isShooting = false; // Reset shooting flag
        }
        else if (Input.GetMouseButtonUp(1)) // Release right click
        {
            animator.ResetTrigger(DefendTrigger);
            isDefending = false;
        }

        // Set back to idle animation when not clicking left or right click
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !isRunning)
        {
            animator.SetTrigger(IdleTrigger);
        }
    }
}
