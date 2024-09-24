using UnityEngine;

public class CogPuzzleInteract : MonoBehaviour
{
    #region CogVars
    [Header("CogVars")]
    public bool cog1;
    public Interaction interaction;
    public GameObject cog1Object;
    public GameObject cog2Object;
    #endregion

    /// <summary>
    /// This function allows the player to insert a Cog into the CogPuzzle
    /// </summary>
    public void CogInsertion()
    {
        if(cog1)
        {
            if(interaction.invetoryFull)
            {
                if(interaction.cogInInventory == 1)
                {
                    cog1Object.transform.parent = null;
                    cog1Object.transform.position = transform.position;
                    cog1Object.transform.rotation = transform.rotation;
                    cog1Object.GetComponent<CogInteract>().inObjective = true;

                    interaction.invetoryFull = false;
                    interaction.cogInInventory = 0;

                    gameObject.SetActive(false);
                }
            }
            
        }
        else
        {
            if(interaction.invetoryFull)
            {
                if(interaction.cogInInventory == 2)
                {
                    cog2Object.transform.parent = null;
                    cog2Object.transform.position = transform.position;
                    cog2Object.transform.rotation = transform.rotation;
                    cog2Object.GetComponent<CogInteract>().inObjective = true;

                    interaction.invetoryFull = false;
                    interaction.cogInInventory = 0;

                    gameObject.SetActive(false);
                }
            }
        }
    }

}
