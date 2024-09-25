using UnityEngine;

public class CogPuzzleInteract : MonoBehaviour
{
    #region CogVars
    [Header("CogVars")]
    public int cogPlacement;
    public Interaction interaction;
    public GameObject cog1Object;
    public GameObject cog2Object;
    public GameObject cog3Object;
    public GameObject cog4Object;
    #endregion

    /// <summary>
    /// This function allows the player to insert a Cog into the CogPuzzle
    /// </summary>
    public void CogInsertion()
    {

        switch (cogPlacement)
        {
            case 1:
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
                    else
                    {
                        cog1Object.transform.parent = null;
                        cog1Object.transform.position = transform.position;
                        cog1Object.transform.rotation = transform.rotation;
                        
                        interaction.invetoryFull = false;
                        interaction.cogInInventory = 0;

                        gameObject.SetActive(false);
                    }
                }
            break;

            case 2:
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
                    else
                    {
                        cog1Object.transform.parent = null;
                        cog1Object.transform.position = transform.position;
                        cog1Object.transform.rotation = transform.rotation;
                        
                        interaction.invetoryFull = false;
                        interaction.cogInInventory = 0;

                        gameObject.SetActive(false);
                    }
                }
            break;

            case 3:
                if(interaction.invetoryFull)
                {
                    if(interaction.cogInInventory == 3)
                    {
                        cog3Object.transform.parent = null;
                        cog3Object.transform.position = transform.position;
                        cog3Object.transform.rotation = transform.rotation;
                        cog3Object.GetComponent<CogInteract>().inObjective = true;

                        interaction.invetoryFull = false;
                        interaction.cogInInventory = 0;

                        gameObject.SetActive(false);
                    }
                    else
                    {
                        cog1Object.transform.parent = null;
                        cog1Object.transform.position = transform.position;
                        cog1Object.transform.rotation = transform.rotation;
                        
                        interaction.invetoryFull = false;
                        interaction.cogInInventory = 0;

                        gameObject.SetActive(false);
                    }
                }
            break;

            case 4:
                if(interaction.invetoryFull)
                {
                    if(interaction.cogInInventory == 4)
                    {
                        cog4Object.transform.parent = null;
                        cog4Object.transform.position = transform.position;
                        cog4Object.transform.rotation = transform.rotation;
                        cog4Object.GetComponent<CogInteract>().inObjective = true;

                        interaction.invetoryFull = false;
                        interaction.cogInInventory = 0;

                        gameObject.SetActive(false);
                    }
                    else
                    {
                        cog1Object.transform.parent = null;
                        cog1Object.transform.position = transform.position;
                        cog1Object.transform.rotation = transform.rotation;
                        
                        interaction.invetoryFull = false;
                        interaction.cogInInventory = 0;

                        gameObject.SetActive(false);
                    }
                }
            break;
        }

    }

}
