using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraCrouch : MonoBehaviour
{
    #region  Variables
    public Transform camCrouch;
    public Transform camUncrouch;
    #endregion

    /// <summary>
    /// This Function Makes the camera move to a crouched position and reverses it when the corresponding button is pressed and let go
    /// </summary>
    /// <param name="context"></param>
    public void Crouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //transform.position -= new Vector3(0, 0.4f, 0);
            transform.position = Vector3.Lerp(transform.position, camCrouch.position, 4);
        }

        if (context.canceled)
        {
            //transform.position = camUncrouch.position;
            transform.position = Vector3.Lerp(transform.position, camUncrouch.position, 4);
        }
    }
}
