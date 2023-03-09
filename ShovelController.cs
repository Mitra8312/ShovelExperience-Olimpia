using UnityEngine;

public class ShovelController : MonoBehaviour
{
    private Rigidbody rigidbody;

    private GameManager gameManager;

    private float pitch;

    private float yaw;

    public float movementSpeed = 2.0f;

    public float rotationSmoothing = 20f;

    public GameObject shovel;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space)) Jump();

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            gameManager.SetActiveMenu();
        }

        rigidbody.MovePosition(CalculateMovement());

        SetRotation();
    }

    public void SetRotation()
    {
        yaw += Input.GetAxis("Mouse X");
        pitch -= Input.GetAxis("Mouse Y");

        pitch = Mathf.Clamp(pitch, -60, 90);

        Quaternion SmoothRotation = Quaternion.Euler(pitch, yaw, 0);

        shovel.transform.rotation = Quaternion.Slerp(shovel.transform.rotation, SmoothRotation, rotationSmoothing * Time.fixedDeltaTime);

        SmoothRotation = Quaternion.Euler(0, yaw, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, SmoothRotation, rotationSmoothing * Time.fixedDeltaTime);
    }

    private Vector3 CalculateMovement()
    {
        float HorizontalDirection = Input.GetAxis("Horizontal");
        float VerticalDirection = Input.GetAxis("Vertical");

        Vector3 Move = transform.right * HorizontalDirection + transform.forward * VerticalDirection;

        return rigidbody.transform.position + Move * Time.fixedDeltaTime * movementSpeed;
    }

    private void Jump()
    {
        rigidbody.AddForce(Vector3.up * 15f, ForceMode.Impulse);
    }
}
