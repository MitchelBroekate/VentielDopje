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
        if(context.performed)
        {
            rotateAngle.Rotate(0, 0, 36);

            

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
        if(context.performed)
        {
            rotateAngle.Rotate(0, 0, -36);

            

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
        if(vaultCam.activeInHierarchy == true)
        {
            if(Input.GetMouseButtonDown(1))
            {

                Debug.Log(currentCodePiece);

                if(code4 == null && code3 != null)
                {
                    code4 = currentCodePiece.ToString();

                    ClockTime();
                }

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
                }
            }
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
        if(Input.GetMouseButtonDown(0))
        {
            if(vaultCam.activeInHierarchy == true)
            {
                vaultCam.SetActive(false);
                player.SetActive(true);

                vaultKeys.SetActive(false);

                allowCamSwitch = true;
                playerControls.crouchPressedB = false;
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
        }
        else
        {
            fullCode = null;
            code1 = null;
            code2 = null;
            code3 = null;
            code4 = null;
        }
    }
}
