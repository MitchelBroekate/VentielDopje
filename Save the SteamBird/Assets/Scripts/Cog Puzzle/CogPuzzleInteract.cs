using UnityEngine;

public class CogPuzzleInteract : MonoBehaviour
{
    #region CogVars
    [Header("CogVars")]
    public int cogPlacement;
    public Interaction interaction;
    public GameObject cogInInventory;

    public bool correctSpace; 
    #endregion

    /// <summary>
    /// This function allows the player to insert a Cog into the CogPuzzle and checks for the correct position
    /// </summary>
    public void CogInsertion()
    {

        if(interaction.invetoryFull)
        {
            //cogInInventory
            cogInInventory.transform.parent = null;
            cogInInventory.transform.position = transform.position;
            cogInInventory.transform.rotation = transform.rotation;

            interaction.invetoryFull = false;
            interaction.cogInInventory = 0;

            if(interaction.cogInInventory == cogPlacement)
            {
                correctSpace = true;
            }
        }




    }


}
