using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f; // Adjust this to control the movement speed
    public Animator animator; // Reference to the Animator component
    public Transform playerModel; // Reference to the player model (to rotate)
    public Shooter shooter; // Reference to the Shooter component

    // Animation trigger names
    private const string IdleTrigger = "Idle";
    private const string ShootTrigger = "Shoot";
    private const string DefendTrigger = "Defend";

    private bool isShooting = false; // Flag to track if shooting animation is playing
    private bool isDefending = false; // Flag to track if defending animation is playing
    private bool isRunning = false; // Flag to track if the player is running
    private bool canMove = true; // Flag to track if the player can move
    private float animationCooldown = 0.2f; // Cooldown time for animations
    private float cooldownTimer = 0f; // Timer to track the cooldown

    private Rigidbody rb; // Reference to the Rigidbody component

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Input for movement
        float horizontalInput = canMove ? Input.GetAxis("Horizontal") : 0f;
        float verticalInput = canMove ? Input.GetAxis("Vertical") : 0f;

        // Calculate the movement direction
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Rotate the player model to face the movement direction
        if (moveDirection != Vector3.zero)
        {
            playerModel.rotation = Quaternion.LookRotation(moveDirection);
        }

        // Move the player using Rigidbody's MovePosition method
        if (canMove && !isShooting && !isDefending)
        {
            
            Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
            rb.MovePosition(newPosition);

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

        // Handle cooldown timer
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Handle shoot animation
        if (Input.GetMouseButtonDown(0) && !isShooting && cooldownTimer <= 0) // Left click
        {
            shooter.Shoot();
            
            // Set shooting flag and cooldown timer
            animator.SetTrigger(ShootTrigger);
            isShooting = true;
            canMove = false; // Disable movement
            cooldownTimer = animationCooldown; // Start cooldown timer
        }
        else if (Input.GetMouseButtonUp(0)) // Release left click
        {
            animator.ResetTrigger(ShootTrigger);
            isShooting = false;
            canMove = true; // Enable movement
        }

        // Handle defend animation
        if (Input.GetMouseButtonDown(1) && !isDefending && cooldownTimer <= 0) // Right click
        {
            animator.SetTrigger(DefendTrigger);
            isDefending = true;
            isShooting = false; // Reset shooting flag
            canMove = false; // Disable movement
            cooldownTimer = animationCooldown; // Start cooldown timer
        }
        else if (Input.GetMouseButtonUp(1)) // Release right click
        {
            animator.ResetTrigger(DefendTrigger);
            isDefending = false;
            canMove = true; // Enable movement
        }

        // Set back to idle animation when not clicking left or right click
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !isRunning)
        {
            animator.SetTrigger(IdleTrigger);
        }
    }
}
