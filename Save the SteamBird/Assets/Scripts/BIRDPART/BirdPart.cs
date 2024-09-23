using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPart : MonoBehaviour
{
    [Header("Scripts")]
    public Interaction interaction;
    public PuzzleManager puzzleManager;

    [Header("BirdParts")]
    public GameObject bird1Object;
    public GameObject bird2Object;
    public GameObject bird3Object;

    [Header("BirdObjectiveLocation")]
    public GameObject birdObjective1;
    public GameObject birdObjective2;
    public GameObject birdObjective3;

    bool part1InObjective;
    bool part2InObjective;
    bool part3InObjective;

    int birdPartsPlaced = 0;


    public void BirdPartInsertion()
    {
        if(interaction.invetoryFull)
        {
            if(interaction.birdPartInInventory == 1)
            {
                bird1Object.transform.parent = null;
                bird1Object.transform.position = birdObjective1.transform.position;
                bird1Object.transform.rotation = birdObjective1.transform.rotation;
                bird1Object.GetComponent<BirdInteraction>().inObjective = true;

                EndGame();

                interaction.invetoryFull = false;
                interaction.birdPartInInventory = 0;
            }

            else if(interaction.birdPartInInventory == 2)
            {
                bird2Object.transform.parent = null;
                bird2Object.transform.position = birdObjective2.transform.position;
                bird2Object.transform.rotation = birdObjective2.transform.rotation;
                bird2Object.GetComponent<BirdInteraction>().inObjective = true;
                
                EndGame();
                
                interaction.invetoryFull = false;
                interaction.birdPartInInventory = 0;
            }

            else if(interaction.birdPartInInventory == 3)
            {
                bird3Object.transform.parent = null;
                bird3Object.transform.position = birdObjective3.transform.position;
                bird3Object.transform.rotation = birdObjective3.transform.rotation;
                bird3Object.GetComponent<BirdInteraction>().inObjective = true;

                EndGame();

                interaction.invetoryFull = false;
                interaction.birdPartInInventory = 0;
            }
            
        }

        if(bird1Object.GetComponent<BirdInteraction>().inObjective)
        {
            
        }

    }

    void EndGame()
    {
        birdPartsPlaced++;

        if(birdPartsPlaced > 2)
        {
            puzzleManager.BirdPartsRestored();
        }

    }
}
