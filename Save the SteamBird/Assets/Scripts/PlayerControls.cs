using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    #region WalkMovement
    Vector2 moveDirection;
    [SerializeField] float moveSpeed;
    Rigidbody rb;
    #endregion

    #region CamMovement
    [SerializeField]
    Transform cam;

    [SerializeField]
    float mouseSens;
    float xRotation = 0f;
    #endregion

    /// <summary>
    /// The Start function gets the ridgedbody component
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// The Update function updates the Walk and CameraMovement functions
    /// </summary>
    private void Update()
    {
        Walk();
        CameraMovement();
    }  

    /// <summary>
    /// This method sets the velocity for any walking direction.
    /// </summary>
    void Walk()
    {
        Vector3 playerV = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.y * moveSpeed);
        rb.velocity = transform.TransformDirection(playerV);
    } 

    /// <summary>
    /// This function sets the movement vector2 in a vector2 variable.
    /// </summary>
    /// <param name="value"></param>
    void OnMovement(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    /// <summary>
    /// Sets the movement for the camera and sets the clamp for the camera movement
    /// </summary>
    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

    }
}
