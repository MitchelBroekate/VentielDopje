using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VaultLockPuzzle : MonoBehaviour
{

    public GameObject player;
    public GameObject vaultCam;

    int currentCodePiece = 0;
    

    void Update()
    {
        SwitchCamsVault();
    }

    public void VaultLockBack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            transform.Rotate(0, 0, 36);

            if(currentCodePiece < 10)
            {
                currentCodePiece++;
            }
            else
            {
                currentCodePiece = 0;
            }
        }
    }

    public void VaultLockForward(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            transform.Rotate(0, 0, -36);

            if(currentCodePiece >0)
            {
                currentCodePiece--;
            }
            else
            {
                currentCodePiece = 10;
            }
        }
    }

    public void VaultLockSelect(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            
        }
    }

    public void SwtichCamsInteraction()
    {
            vaultCam.SetActive(true);
            player.SetActive(false);
    }

    void SwitchCamsVault()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(vaultCam.activeInHierarchy == true)
            {
                vaultCam.SetActive(false);
                player.SetActive(true);
            }
        }
    }
}
