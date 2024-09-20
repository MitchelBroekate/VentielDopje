using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PuzzleManager : MonoBehaviour
{
    [SerializeField] Transform cog1, cog2;
    [SerializeField] Transform cogSpawnParent;

    [SerializeField] List<Transform> cogSpawnpoint = new List<Transform>();

    void Start()
    {
        CogRandomSpawn();
    }

    public void CogComplete()
    {
        if(cog1.GetComponent<CogInteract>().inObjective && cog2.GetComponent<CogInteract>().inObjective)
        {
            Debug.Log($"<color=#ff0015>Completed the Cog puzzle!</color>");
        }
    }

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
        cogSpawnpoint.Add(currentCog1Spawn);
    }

    public void VaultPuzzleComplete()
    {
        Debug.Log($"<color=#0092ff>Completed the Vault puzzle!</color>");
    }

    public void PipePuzzleComplete()
    {
        Debug.Log($"<color=#0cff00>Completed the Pipe puzzle!</color>");
    }
}