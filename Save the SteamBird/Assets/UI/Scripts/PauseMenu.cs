using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    public GameObject pause;
   
    
        
    public void ShowPause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }

    }

    public void HidePause()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach ( AudioSource a in audios)
        {
            a.Play();
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
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
