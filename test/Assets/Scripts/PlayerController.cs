using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public Transform cameraTransform;
    public float stepHeight = 0.5f; 
    private Rigidbody rb;
    private Vector3 movement;
    private float cameraVerticalAngle = 0.0f;

    private CapsuleCollider playerCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        if (cameraTransform == null)
        {
            Debug.LogError("Remember to set the Camera Transform in the inspector!");
        }
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

    // Handle player movement based on input
    void HandleMovementInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        movement = new Vector3(moveX, 0, moveZ).normalized * speed;
    }

    // Move the player based on the movement vector
    void MovePlayer()
    {
        Vector3 moveOffset = transform.TransformDirection(movement) * Time.fixedDeltaTime;
        RaycastHit hit;
        // Cast downwards from the base of the capsule collider (thus slightly above the player's feet)
        if (Physics.Raycast(transform.position + Vector3.up * playerCollider.radius, Vector3.down, out hit, stepHeight + playerCollider.radius))
        {
            if (hit.distance < playerCollider.radius)  // Meaning we are on top of something
            {
                moveOffset.y -= stepHeight - hit.distance;  // Adjust height based on difference
            }
        }
        rb.MovePosition(rb.position + moveOffset);
    }

    // Handle player camera rotation based on mouse input
    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        cameraVerticalAngle -= mouseY;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -90.0f, 90.0f);

        cameraTransform.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);
    }

    // If player enters trigger, load the next scene
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
