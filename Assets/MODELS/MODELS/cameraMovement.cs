using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the camera
    public float rotationSpeed = 3f; // Rotation speed of the camera
    public float verticalMoveSpeed = 3f; // Vertical movement speed of the camera

    private Vector3 lastMousePosition; // Last recorded mouse position

    void Update()
    {
        // Check for mouse button down to start dragging
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        // Check for mouse button being held down
        if (Input.GetMouseButton(0))
        {
            // Calculate the mouse movement since the last frame
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;

            // Invert the mouse drag direction for rotation
            float rotationX = -mouseDelta.y * rotationSpeed;
            float rotationY = mouseDelta.x * rotationSpeed;

            transform.Rotate(Vector3.up, rotationY, Space.World);
            transform.Rotate(Vector3.right, rotationX, Space.World);

            // Update the last mouse position for the next frame
            lastMousePosition = Input.mousePosition;
        }

        // Move the camera based on arrow keys and WASD keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Move the camera up and down based on 'W' and 'E' keys
        float upDownInput = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            upDownInput = 1f;
        }
        else if (Input.GetKey(KeyCode.S)) // Use 'S' for downward movement
        {
            upDownInput = -1f;
        }

        Vector3 verticalMovement = Vector3.up * upDownInput * verticalMoveSpeed * Time.deltaTime;
        transform.Translate(verticalMovement);
    }
}
