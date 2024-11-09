using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class VaultLockPuzzle : MonoBehaviour
{
    #region PlayerCams
    [Header("PlayerCams")]
    public GameObject player;
    public GameObject vaultCam;
    #endregion

    #region ClockCode
    [Header("ClockCode")]
    bool canInputCode = true;
    int currentCodePiece = 0;
    string timeCode;
    string fullCode ;
    string code1 = null;
    string code2 = null;
    string code3 = null;
    string code4 = null;
    #endregion

    #region CamSwitch
    [Header("CamSwitch")]
    bool camSwitch;
    bool allowCamSwitch = true;
    #endregion

    #region Scripts
    [Header("Scripts")]
    public PuzzleManager puzzleManager;
    public PlayerControls playerControls;
    public PauseMenu pauseMenu;
    #endregion

    #region VaultKeybind
    [Header("VaultKeybind")]
    public GameObject vaultKeys;
    #endregion

    #region VaultDial
    [Header("VaultDial")]
    public GameObject vaultDial;
    #endregion

    #region Animator
    [Header("Animator")]
    public Animator animator;
    #endregion

    #region RotateAngle
    public Transform rotateAngle;
    #endregion

    #region SFX
    [Header("SFX")]
    public AudioSource audioSource;
    public AudioClip vaultRotate;
    public AudioClip vaultOpen;
    public AudioClip vaultSelect;
    public AudioClip vaultReset;
    #endregion

    #region Interactables
    [Header("Interactables")]
    public GameObject interactable1;
    public GameObject interactable2;
    #endregion

    /// <summary>
    /// This function updates the cam switcher, check if you can switch cams and updates the vault code selector
    /// </summary>
    void Update()
    {
        SwitchCamsVault();
        VaultLockSelect();

        if(camSwitch && allowCamSwitch)
        {
            vaultCam.SetActive(true);
            player.SetActive(false);

            vaultKeys.SetActive(true);

            allowCamSwitch = false;
            camSwitch = false;
        }

        vaultDial.transform.rotation = Quaternion.Lerp(vaultDial.transform.rotation, rotateAngle.rotation, 2f * Time.deltaTime);
    }

    /// <summary>
    /// This function rotates the vault knob back and enters it's code
    /// </summary>
    /// <param name="context"></param>
    public void VaultLockBack(InputAction.CallbackContext context)
    {
        if(pauseMenu.isPaused) return;

        if(context.performed)
        {
            rotateAngle.Rotate(0, 0, 36);

            audioSource.clip = vaultRotate;
            audioSource.Play();

            if(currentCodePiece >0)
            {
                currentCodePiece--;
            }
            else
            {
                currentCodePiece = 9;
            }
        }
    }

    /// <summary>
    /// This function rotates the vault knob forward and enters it's code
    /// </summary>
    /// <param name="context"></param>
    public void VaultLockForward(InputAction.CallbackContext context)
    {
        if(pauseMenu.isPaused) return;

        if(context.performed)
        {
            rotateAngle.Rotate(0, 0, -36);

            audioSource.clip = vaultRotate;
            audioSource.Play();

            if(currentCodePiece < 9)
            {
                currentCodePiece++;
            }
            else
            {
                currentCodePiece = 0;
            }
        }
    }

    /// <summary>
    /// This function locks in the current selected codepiece
    /// </summary>
    void VaultLockSelect()
    {
        if(pauseMenu.isPaused) return;

        if(!vaultCam.activeInHierarchy) return;

            if(Input.GetMouseButtonDown(0))
            {
                audioSource.clip = vaultSelect;
                audioSource.Play();

                if(!canInputCode) canInputCode = true;

                if(code4 == null && code3 != null)
                {
                    code4 = currentCodePiece.ToString();

                    ClockTime();
                    canInputCode = false;
                }
                if(!canInputCode) return;

                if(code3 == null && code2 != null) 
                {
                    code3 = currentCodePiece.ToString();
                }

                if(code2 == null && code1 != null)
                {
                    code2 = currentCodePiece.ToString();
                }

                if(code1 == null)
                {
                    code1 = currentCodePiece.ToString();
                    Debug.Log(code1);
                }

                Debug.Log("(" + currentCodePiece + ")" + " is the current code piece");
            }
    }

    /// <summary>
    /// This function allows the player to switch back into the vault when exited
    /// </summary>
    public void SwtichCamsInteraction()
    {
        camSwitch = true;
    }

    /// <summary>
    /// This function allows the player to switch cameras out of the vault
    /// </summary>
    void SwitchCamsVault()
    {
        if(Input.GetMouseButtonDown(1))
        {


            if(vaultCam.activeInHierarchy == true)
            {
                vaultCam.SetActive(false);
                player.SetActive(true);

                vaultKeys.SetActive(false);

                allowCamSwitch = true;
            }
        }
    }

    /// <summary>
    /// This function checks the code with the time code and resets it if its wrong
    /// </summary>
    void ClockTime()
    { 
        timeCode = puzzleManager.timeCode;

        fullCode = code1 + code2 +  code3 + code4;

        Debug.Log(fullCode);

        if(String.Compare(timeCode, fullCode) == 0)
        {
            puzzleManager.VaultPuzzleComplete();
            animator.SetBool("DoorOpen", true);

            audioSource.clip = vaultOpen;
            audioSource.Play();

            vaultCam.SetActive(false);
            player.SetActive(true);
            vaultKeys.SetActive(false);

            interactable1.layer = 0;
            interactable2.layer = 0;
        }
        else
        {
            audioSource.clip = vaultReset;
            audioSource.Play();
        }
        fullCode = null;
        code1 = null;
        code2 = null;
        code3 = null;
        code4 = null;

    }
}
