using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    public GameObject pause;
    public AudioSource steam;
    public AudioSource bird;
    
        
    public void ShowPause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        steam.Pause();

    }

    public void HidePause()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        steam.UnPause();
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("joe");
            if (pause.activeInHierarchy == true)
            {
                HidePause();
            }
            else
            {
                ShowPause();
            }
        }
    }
}
