using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;  // Player movement speed
    public float mouseSensitivity = 2.0f;  // Mouse look sensitivity
    public Transform cameraTransform;  // Reference to the player's camera

    private Rigidbody rb;
    private Vector3 movement;
    private float cameraVerticalAngle = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (cameraTransform == null)
        {
            Debug.LogError("Remember to set the Camera Transform in the inspector!");
        }

        Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor to the center of the screen
        Cursor.visible = false;  // Hide the cursor
    }

    private void Update()
    {
        HandleMovementInput();
        HandleMouseLook();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void HandleMovementInput()
    {
        float moveX = Input.GetAxis("Horizontal");  // A, D keys
        float moveZ = Input.GetAxis("Vertical");    // W, S keys

        movement = new Vector3(moveX, 0, moveZ).normalized * speed;
    }

    void MovePlayer()
    {
        Vector3 moveOffset = transform.TransformDirection(movement) * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveOffset);
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        cameraVerticalAngle -= mouseY;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -90.0f, 90.0f);
        
        cameraTransform.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);
    }
}
