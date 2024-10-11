using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPart : MonoBehaviour
{
    #region Scripts
    [Header("Scripts")]
    public Interaction interaction;
    public PuzzleManager puzzleManager;
    #endregion

    #region BirdParts
    [Header("BirdParts")]
    public GameObject bird1Object;
    public GameObject bird2Object;
    public GameObject bird3Object;
    #endregion

    #region BirdObjective
    [Header("BirdObjective")]
    public GameObject birdObjective1;
    public GameObject birdObjective2;
    public GameObject birdObjective3;

    bool part1InObjective;
    bool part2InObjective;
    bool part3InObjective;

    int birdPartsPlaced = 0;
    #endregion

    /// <summary>
    /// This function allows the player to insert a Birdpart into the bird and checks for when all the parts are inserted
    /// </summary>
    public void BirdPartInsertion()
    {
        if(interaction.invetoryFull)
        {
            if(interaction.birdPartInInventory == 1)
            {
                bird1Object.transform.parent = transform;
                bird1Object.transform.position = birdObjective1.transform.position;
                bird1Object.transform.rotation = birdObjective1.transform.rotation;
                bird1Object.GetComponent<BirdInteraction>().inObjective = true;

                EndGame();

                interaction.invetoryFull = false;
                interaction.birdPartInInventory = 0;
            }

            else if(interaction.birdPartInInventory == 2)
            {
                bird2Object.transform.parent = transform;
                bird2Object.transform.position = birdObjective2.transform.position;
                bird2Object.transform.rotation = birdObjective2.transform.rotation;
                bird2Object.GetComponent<BirdInteraction>().inObjective = true;
                
                EndGame();
                
                interaction.invetoryFull = false;
                interaction.birdPartInInventory = 0;
            }

            else if(interaction.birdPartInInventory == 3)
            {
                bird3Object.transform.parent = transform;
                bird3Object.transform.position = birdObjective3.transform.position;
                bird3Object.transform.rotation = birdObjective3.transform.rotation;
                bird3Object.GetComponent<BirdInteraction>().inObjective = true;

                EndGame();

                interaction.invetoryFull = false;
                interaction.birdPartInInventory = 0;
            }
        }
    }

    /// <summary>
    /// This function checks the win condition and activates the win screen
    /// </summary>
    void EndGame()
    {
        birdPartsPlaced++;

        if(birdPartsPlaced > 2)
        {
            puzzleManager.BirdPartsRestored();
        }

    }
}
