using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    public GameObject pause;
    public GameObject pauseSetting;
    public GameObject playerCanvas;
    public GameObject vaultCanvas;
    public GameObject mainPlayer;
    public GameObject winScreen;
    public GameObject loseScreen;

    public Interaction interaction;
   
    
        
    public void ShowPause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (mainPlayer.activeInHierarchy == true)
        {
            playerCanvas.SetActive(false);
        }
        else
        {
            vaultCanvas.SetActive(false);
        }

        interaction.IntroCheck = false;

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

       if(mainPlayer.activeInHierarchy == true)
        {
            playerCanvas.SetActive(true);
        }
        else
        {
            vaultCanvas.SetActive(true);
        }

        interaction.IntroCheck = true;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach ( AudioSource a in audios)
        {
            a.UnPause();
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(pause.activeInHierarchy == false && pauseSetting.activeInHierarchy == false && winScreen.activeInHierarchy == false && loseScreen.activeInHierarchy == false)
            {
                ShowPause();
            }
        }
    }
}
