using UnityEngine;

public class PipePuzzleManager : MonoBehaviour
{
    #region Script
    public PuzzleManager puzzleManager;
    #endregion

    #region AirVents
    public Transform airVent1;
    public Transform airVent2;
    public Transform airVent3;
    public Transform airVent4;
    public Transform airVent5;
    #endregion

    #region AirVentInts
    public int currentAirvent;
    public int FixableAirvent;
    #endregion

    #region LastFixablePipe
    public int lastPipe;
    #endregion
    
    #region CompletionLock
    public bool completionLock;
    public AudioSource pipeAudio;
    #endregion


    /// <summary>
    /// Sets the first fixable pipe
    /// </summary>
    void Start()
    {
        RandomPipeSelector();
        pipeAudio.pitch = 1f;
    }

    /// <summary>
    /// Randomizes which pipe can be fixed
    /// </summary>
    public void RandomPipeSelector()
    {
        if(FixableAirvent > 4)
        {
            PuzzleCompleted();
            completionLock = true;
        }
        else
        {
            FixableAirvent++;
            currentAirvent = UnityEngine.Random.Range(1, 6);

            if(currentAirvent == lastPipe)
            {
                RandomPipeSelector();
                FixableAirvent--;
            }
            else
            {
                pipeAudio.pitch += 0.3f;

                airVent1.GetChild(0).gameObject.SetActive(false);
                airVent2.GetChild(0).gameObject.SetActive(false);
                airVent3.GetChild(0).gameObject.SetActive(false);
                airVent4.GetChild(0).gameObject.SetActive(false);
                airVent5.GetChild(0).gameObject.SetActive(false);

                switch(currentAirvent)
                {
                    case 1:
                    airVent1.GetChild(0).gameObject.SetActive(true);
                    break;

                    case 2:
                    airVent2.GetChild(0).gameObject.SetActive(true);
                    break;

                    case 3:
                    airVent3.GetChild(0).gameObject.SetActive(true);
                    break;

                    case 4:
                    airVent4.GetChild(0).gameObject.SetActive(true);
                    break;

                    case 5:
                    airVent5.GetChild(0).gameObject.SetActive(true);
                    break;
                }
            }

           
        }
    }

    /// <summary>
    /// Resets the puzzle when the wrong pipe is fixed
    /// </summary>
    public void PipePuzzleReset()
    {
        Debug.LogWarning("Puzzle Reset");

        FixableAirvent = 0;

        RandomPipeSelector();

        pipeAudio.pitch = 1f;
    }

    /// <summary>
    /// when the puzzle is completed it disables all possible open pipes and activates the pipe puzzle win script
    /// </summary>
     void PuzzleCompleted()
    {   
        airVent1.GetChild(0).gameObject.SetActive(false);
        airVent2.GetChild(0).gameObject.SetActive(false);
        airVent3.GetChild(0).gameObject.SetActive(false);
        airVent4.GetChild(0).gameObject.SetActive(false);
        airVent5.GetChild(0).gameObject.SetActive(false);

        puzzleManager.PipePuzzleComplete();
        pipeAudio.mute = true;
    }
}
