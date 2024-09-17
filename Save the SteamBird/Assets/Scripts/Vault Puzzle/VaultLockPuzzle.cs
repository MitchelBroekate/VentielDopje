using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class VaultLockPuzzle : MonoBehaviour
{

    public GameObject player;
    public GameObject vaultCam;

    public SetClockTime setClockTime;

    int currentCodePiece = 0;

    string timeCode;

    string fullCode ;
    string code1 = null;
    string code2 = null;
    string code3 = null;
    string code4 = null;

    public PuzzleManager puzzleManager;

    bool camSwitch;
    bool allowCamSwitch = true;

    void Update()
    {
        SwitchCamsVault();
        VaultLockSelect();

        if(camSwitch && allowCamSwitch)
        {
            vaultCam.SetActive(true);
            player.SetActive(false);

            allowCamSwitch = false;
            camSwitch = false;
        }
    }

    public void VaultLockBack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            transform.Rotate(0, 0, 36);

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

    public void VaultLockForward(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            transform.Rotate(0, 0, -36);

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

    void VaultLockSelect()
    {
        if(Input.GetMouseButtonDown(1))
        {

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

    public void SwtichCamsInteraction()
    {
        camSwitch = true;
    }

    void SwitchCamsVault()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(vaultCam.activeInHierarchy == true)
            {
                vaultCam.SetActive(false);
                player.SetActive(true);

                allowCamSwitch = true;
            }
        }
    }

    void ClockTime()
    {
        timeCode = setClockTime.timeCode;

        fullCode = code1 + code2 + ":" + code3 + code4;

        Debug.Log(fullCode);

        if(String.Compare(timeCode, fullCode) == 0)
        {
            puzzleManager.VaultPuzzleComplete();
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
