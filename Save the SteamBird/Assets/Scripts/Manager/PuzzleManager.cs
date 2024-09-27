using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    #region Cog Vars
    [Header("CogVars")]
    [SerializeField] Transform cog1;
    [SerializeField] Transform cog2;
    [SerializeField] Transform cog3;
    [SerializeField] Transform cog4;
    [SerializeField] Transform cogSpawnParent;

    [SerializeField] List<Transform> cogSpawnpoint = new List<Transform>();
    #endregion

    #region BirdParts Vars
    [Header("BirdPartVars")]
    [SerializeField] Timer timer;
    [SerializeField] Transform bird1, bird2, bird3;
    [SerializeField] Transform birdspawn1, birdspawn2, birdspawn3;
    #endregion

    #region Player
    [Header("PlayerVars")]
    [SerializeField] PlayerControls playerControls;
    [SerializeField] Transform player;
    [SerializeField] GameObject playerCanvas;
    #endregion

    [Header("WinCanvas")]
    [SerializeField] GameObject winCanvas;

    /// <summary>
    /// This function activates the CogRandomSpawn at the start of the game
    /// </summary>
    void Start()
    {
        CogRandomSpawn();
    }

    /// <summary>
    /// This function gives you a bird part and shows you completed the Cog puzzle
    /// </summary>
    public void CogComplete()
    {
        if(cog1.GetComponent<CogInteract>().inObjective && cog2.GetComponent<CogInteract>().inObjective)
        {
            Debug.Log($"<color=#ff0015>Completed the Cog puzzle!</color>");

            bird1.transform.position = birdspawn1.position;
        }
    }

    /// <summary>
    /// This function gets spawn positions for the cogs and teleports the cogs to them
    /// </summary>
    void CogRandomSpawn()
    {

        for (int i = 0; i < cogSpawnParent.childCount; i++)
        {
            if(!cogSpawnpoint.Contains(cogSpawnParent.GetChild(i)))
            {
                cogSpawnpoint.Add(cogSpawnParent.GetChild(i).transform);
            }

        }

        int cog1Spawn = Random.Range(0, cogSpawnpoint.Count - 1);
        cog1.transform.position = cogSpawnpoint[cog1Spawn].position;
        Transform currentCog1Spawn = cogSpawnpoint[cog1Spawn];
        cogSpawnpoint.RemoveAt(cog1Spawn);
        
        int cog2Spawn = Random.Range(0, cogSpawnpoint.Count - 1);
        cog2.transform.position = cogSpawnpoint[cog2Spawn].position;
        Transform currentCog2Spawn = cogSpawnpoint[cog2Spawn];
        cogSpawnpoint.RemoveAt(cog2Spawn);

        int cog3Spawn = Random.Range(0, cogSpawnpoint.Count - 1);
        cog3.transform.position = cogSpawnpoint[cog3Spawn].position;
        Transform currentCog3Spawn = cogSpawnpoint[cog3Spawn];
        cogSpawnpoint.RemoveAt(cog3Spawn);

        int cog4Spawn = Random.Range(0, cogSpawnpoint.Count - 1);
        cog4.transform.position = cogSpawnpoint[cog4Spawn].position;
        cogSpawnpoint.Add(currentCog1Spawn);
        cogSpawnpoint.Add(currentCog2Spawn);
        cogSpawnpoint.Add(currentCog3Spawn);
    }

    /// <summary>
    /// This function gives you a bird part and shows you completed the Vault puzzle
    /// </summary>
    public void VaultPuzzleComplete()
    {
        Debug.Log($"<color=#0092ff>Completed the Vault puzzle!</color>");

        bird2.transform.position = birdspawn2.position;
    }

    /// <summary>
    /// This function gives you a bird part and shows you completed the Pipe puzzle
    /// </summary>
    public void PipePuzzleComplete()
    {
        Debug.Log($"<color=#0cff00>Completed the Pipe puzzle!</color>");

        bird3.transform.position = birdspawn3.position;
    }
    
    /// <summary>
    /// This function activates the win condition and stops the timer
    /// </summary>
    public void BirdPartsRestored()
    {
        Debug.Log($"<color=#8d28ed>You Beat The Game!!!</color>");

        timer.timeIsRunning = false;
        Cursor.lockState = CursorLockMode.None;
        playerControls.winMovement = true;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerCanvas.SetActive(false);
        winCanvas.SetActive(true);
    }
}