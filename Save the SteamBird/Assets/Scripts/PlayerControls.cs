using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    #region WalkMovement Variables
    Vector2 moveDirection;
    [SerializeField] float moveSpeed;
    Rigidbody rb;
    #endregion

    #region CamMovement Variables
    [SerializeField] Transform cam;
    [SerializeField] Transform camCrouch;
    [SerializeField] Transform camUncrouch;

    [SerializeField]
    float mouseSens;
    float xRotation = 0f;

    bool crouchPressedB;
    #endregion

    /// <summary>
    /// The Start function gets the ridgedbody component
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// The Update function updates the Walk, CrouchPressed and CameraMovement functions
    /// </summary>
    private void Update()
    {
        Walk();
        CameraMovement();
        CrouchPressed();
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

    /// <summary>
    /// This function activates the crouch ability
    /// </summary>
    void CrouchPressed()
    {
        if(crouchPressedB)
        {
            cam.position = Vector3.Lerp(cam.position, camCrouch.position, 5 * Time.deltaTime);
        }

        if(!crouchPressedB)
        {
            cam.position = Vector3.Lerp(cam.position, camUncrouch.position, 5 * Time.deltaTime);
        }
    }

/// <summary>
/// This Function toggles the camera position when the crouch button is pressed
/// </summary>
/// <param name="value"></param>
    void OnCrouch(InputValue value)
    {
        if(cam.position != camCrouch.position)
        {
            if(value.isPressed)
            {
                crouchPressedB = true;
            }
        }

        if(cam.position != camUncrouch.position)
        {
            if(!value.isPressed)
            {
                crouchPressedB = false;
            }   
        }

    }
}
