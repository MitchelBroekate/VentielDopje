using UnityEngine;

public class CogPuzzleInteract : MonoBehaviour
{
    #region CogVars
    [Header("CogVars")]
    public int cogPlacement;
    public bool correctSpace; 
    public Interaction interaction;
    public Transform cogInInventory;
    public Transform interactionParent;
    int interactionComplete;
    #endregion

    /// <summary>
    /// This function allows the player to insert a Cog into the CogPuzzle and checks for the correct position
    /// </summary>
    public void CogInsertion()
    {

        if(interaction.invetoryFull)
        {
            cogInInventory = interaction.cogInInventory;
            cogInInventory.GetComponent<BoxCollider>().enabled = true;
            cogInInventory.parent = null;
            cogInInventory.position = transform.position;
            cogInInventory.rotation = transform.rotation;

            if(interaction.cogInt == cogPlacement)
            {
                correctSpace = true;
            }

            interaction.invetoryFull = false;
            interaction.cogInt = 0;
            interaction.cogInInventory = null;

            for(int i = 0; i < interactionParent.childCount; i++)
            {
                if(interactionParent.GetChild(i).GetComponent<CogPuzzleInteract>().correctSpace)
                {
                    interactionComplete++;
                }
            }

            if(interactionComplete == 4)
            {
                for(int i = 0; i < interactionParent.childCount; i++)
                {
                    Transform currentCogInInventory = interactionParent.GetChild(i).GetComponent<CogPuzzleInteract>().cogInInventory;
                    currentCogInInventory.GetComponent<CogInteract>().inObjective = true;
                    currentCogInInventory.GetComponent<BoxCollider>().enabled = false;
                }
            }
            
        }
    }
}
