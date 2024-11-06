using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [SerializeField] Transform looseCogs;
    #endregion

    #region VaultTimeCode
    [Header("TimeCode")]
    public string timeCode;

    [Header("Chicago")]
    public TMP_Text chicagoTime1;
    public TMP_Text chicagoTime2;
    public TMP_Text chicagoTime3;
    public TMP_Text chicagoTime4;
    [Header("Texas")]
    public TMP_Text texasTime1;
    public TMP_Text texasTime2;
    public TMP_Text texasTime3;
    public TMP_Text texasTime4;
    [Header("NewYork")]
    public TMP_Text newYorkTime1;
    public TMP_Text newYorkTime2;
    public TMP_Text newYorkTime3;
    public TMP_Text newYorkTime4;
    [Header("Arizona")]
    public TMP_Text arizonaTime1;
    public TMP_Text arizonaTime2;
    public TMP_Text arizonaTime3;
    public TMP_Text arizonaTime4;
    #endregion

    #region BirdParts Vars
    [Header("BirdPartVars")]
    [SerializeField] Transform bird1, bird2, bird3, bird4;
    [SerializeField] Transform birdspawn1, birdspawn2, birdspawn3, birdspawn4;
    #endregion

    #region CogWorkbench
    [Header("CogWorkbench")]
    [SerializeField] Transform workbench;
    [SerializeField] Transform moveLocation;
    bool allowWorkbenchMove;

    [SerializeField] AudioSource workbenchAudio;
    #endregion

    #region PipeRotate
    [Header("PipeRotate")]
    [SerializeField] ParticleSystem rotatePipeSteam1;
    [SerializeField] ParticleSystem rotatePipeSteam2;
    [SerializeField] ParticleSystem rotatePipeSteam3;
    [SerializeField] AudioSource steamAudio;
    #endregion

    #region SteamPipe
    [Header("SteamPipe")]
    [SerializeField] ParticleSystem steamPipePiece1;
    [SerializeField] ParticleSystem steamPipePiece2;
    [SerializeField] ParticleSystem steamPipePiece3;
    [SerializeField] AudioSource steamPipeAudio;
    #endregion

    #region Win
    [Header("Win")]
    public bool gameWon;
    #endregion

    #region SFX
    [Header("SFX")]
    [SerializeField] AudioSource audioSource;
    #endregion

    #region Objective
    [Header("Objective")]
    [SerializeField] Timer timer;
    #endregion
    
    /// <summary>
    /// This function activates the CogRandomSpawn and SetVaultCodeTime at the start of the game
    /// </summary>
    void Start()
    {
        CogRandomSpawn();
        SetVaultCodeTime();
    }
    void Update()
    {
        if(allowWorkbenchMove)
        {
            workbench.position = Vector3.Lerp(workbench.position, moveLocation.position, 3f * Time.deltaTime);
        }
    }

    /// <summary>
    /// This function gives you a bird part and shows you completed the Cog puzzle
    /// </summary>
    public void CogComplete()
    {
        if(cog1.GetComponent<CogInteract>().inObjective && cog2.GetComponent<CogInteract>().inObjective)
        {
            Debug.Log($"<color=#ff0015>Completed the Cog puzzle!</color>");

            for(int i = 0; i < looseCogs.childCount; i++)
            {
                looseCogs.GetChild(i).GetComponent<CogRotate>().canRotate = true;
                cog1.GetComponent<CogRotate>().canRotate = true;
                cog2.GetComponent<CogRotate>().canRotate = true;
                cog3.GetComponent<CogRotate>().canRotate = true;
                cog4.GetComponent<CogRotate>().canRotate = true;
            }

            bird1.transform.position = birdspawn1.position;

            allowWorkbenchMove = true;

            workbenchAudio.Play();

            audioSource.Play();

            timer.puzzlesRemaining++;
            timer.SetCurrentObjective();
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
    /// Sets the time for the displaybord code
    /// </summary>
    void SetVaultCodeTime()
    {
        float c1;
        float a2;
        float t3;
        float n4;

        #region CodePiece1
        c1 = Random.Range(minInclusive: 0, maxExclusive: 3);
        chicagoTime1.text = c1.ToString();
        if(c1 == 2)
        {
            float c2 = Random.Range(minInclusive: 0, maxExclusive: 4);
            chicagoTime2.text = c2.ToString();
        }
        else
        {
            float c2 = Random.Range(minInclusive: 0, maxExclusive: 9);
            chicagoTime2.text = c2.ToString();
        }
        float c3 = Random.Range(minInclusive: 0, maxExclusive: 6);
        chicagoTime3.text = c3.ToString();

        float c4 = Random.Range(minInclusive: 0, maxExclusive: 10);
        chicagoTime4.text = c4.ToString();
        #endregion
        
        #region CodePiece2
        float a1 = Random.Range(minInclusive: 0, maxExclusive: 3);
        arizonaTime1.text = a1.ToString();
        if(a1 == 2)
        {
            a2 = Random.Range(minInclusive: 0, maxExclusive: 4);
            arizonaTime2.text = a2.ToString();
        }
        else
        {
            a2 = Random.Range(minInclusive: 0, maxExclusive: 9);
            arizonaTime2.text = a2.ToString();
        }
        float a3 = Random.Range(minInclusive: 0, maxExclusive: 5);
        arizonaTime3.text = a3.ToString();

        float a4 = Random.Range(minInclusive: 0, maxExclusive: 9);
        arizonaTime4.text = a4.ToString();
        #endregion

        #region CodePiece3
        float t1 = Random.Range(minInclusive: 0, maxExclusive: 3);
        texasTime1.text = t1.ToString();
        if(t1 == 2)
        {
            float t2 = Random.Range(minInclusive: 0, maxExclusive: 4);
            texasTime2.text = t2.ToString();
        }
        else
        {
            float t2 = Random.Range(minInclusive: 0, maxExclusive: 9);
            texasTime2.text = t2.ToString();
        }
        t3 = Random.Range(minInclusive: 0, maxExclusive: 5);
        texasTime3.text = t3.ToString();

        float t4 = Random.Range(minInclusive: 0, maxExclusive: 9);
        texasTime4.text = t4.ToString();
        #endregion

        #region CodePiece4
        float n1 = Random.Range(minInclusive: 0, maxExclusive: 3);
        newYorkTime1.text = n1.ToString();
        if(n1 == 2)
        {
            float n2 = Random.Range(minInclusive: 0, maxExclusive: 4);
            arizonaTime3.text = n2.ToString();
        }
        else
        {
            float n2 = Random.Range(minInclusive: 0, maxExclusive: 9);
            newYorkTime3.text = n2.ToString();

        }
        float n3 = Random.Range(minInclusive: 0, maxExclusive: 5);
        newYorkTime4.text = n3.ToString();

        n4 = Random.Range(minInclusive: 0, maxExclusive: 9);
        newYorkTime4.text = n4.ToString();
        #endregion

        timeCode = string.Format("{0}{1}{2}{3}", c1, a2, t3, n4);
    }

    /// <summary>
    /// This function gives you a bird part and shows you completed the Vault puzzle
    /// </summary>
    public void VaultPuzzleComplete()
    {
        Debug.Log($"<color=#0092ff>Completed the Vault puzzle!</color>");

        bird2.transform.position = birdspawn2.position;

        audioSource.Play();

        timer.puzzlesRemaining++;
        timer.SetCurrentObjective();
    }

    /// <summary>
    /// This function gives you a bird part and shows you completed the Pipe puzzle
    /// </summary>
    public void PipePuzzleComplete()
    {
        Debug.Log($"<color=#0cff00>Completed the Pipe puzzle!</color>");

        bird3.transform.position = birdspawn3.position;

        audioSource.Play();

        StartCoroutine(PipeSteamWait());

        timer.puzzlesRemaining++;
        timer.SetCurrentObjective();
    }
    
    /// <summary>
    /// This function activates the win condition and stops the timer
    /// </summary>
    public void PipeRotateCompletion()
    {
        StartCoroutine(PipeRotateWait());

        audioSource.Play();

        timer.puzzlesRemaining++;
        timer.SetCurrentObjective();
    }

    /// <summary>
    /// This function sets the gamestate to win and gives your final objective
    /// </summary>
    public void BirdPartsRestored()
    {
        Debug.Log($"<color=#8d28ed>You Beat The Game!!!</color>");
        gameWon = true;

        audioSource.Play();
    }

    /// <summary>
    /// This coroutine enables when you complete the PipeRotate puzzle and spawns the birdpart
    /// </summary>
    /// <returns></returns>
    IEnumerator PipeRotateWait()
    {
        yield return new WaitForSeconds(4);

        rotatePipeSteam1.Play();
        rotatePipeSteam2.Play();
        rotatePipeSteam3.Play();
        steamAudio.Play();

        bird4.position = birdspawn4.position;
        Debug.Log($"<color=#2d43ed>Pipe Rotate Complete!!!</color>");

        yield return new WaitForSeconds(5);

        steamAudio.Stop();
    }

    /// <summary>
    /// This coroutine plays a particle and a sound when the Steampipe puzzle is completed
    /// </summary>
    /// <returns></returns>
    IEnumerator PipeSteamWait()
    {
        steamPipePiece1.Play();
        steamPipePiece2.Play();
        steamPipePiece3.Play();
        steamPipeAudio.Play();

        yield return new WaitForSeconds(5);

        steamAudio.Stop();

    }
}