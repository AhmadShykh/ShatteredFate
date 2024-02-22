using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the movement speed

    // Update is called once per frame
    void Update()
    {
        // Input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction in isometric space
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0f; // Ensure the player doesn't move up or down

        // Move the player
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
