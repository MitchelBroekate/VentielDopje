using UnityEngine;

public class PipePuzzleManager : MonoBehaviour
{

    public PuzzleManager puzzleManager;
    public Transform airVent1, airVent2, airVent3, airVent4, airVent5;

    public int currentAirvent;
    public int FixableAirvent;

    void Start()
    {
        RandomPipeSelector();
    }

    public void RandomPipeSelector()
    {
        if(FixableAirvent > 4)
        {
            PuzzleCompleted();
        }
        else
        {
            FixableAirvent++;
            currentAirvent = UnityEngine.Random.Range(0, 4);

            airVent1.GetChild(0).gameObject.SetActive(false);
            airVent2.GetChild(0).gameObject.SetActive(false);
            airVent3.GetChild(0).gameObject.SetActive(false);
            airVent4.GetChild(0).gameObject.SetActive(false);
            airVent5.GetChild(0).gameObject.SetActive(false);

            switch(currentAirvent)
            {
                case 0:
                airVent1.GetChild(0).gameObject.SetActive(true);
                break;

                case 1:
                airVent2.GetChild(0).gameObject.SetActive(true);
                break;

                case 2:
                airVent3.GetChild(0).gameObject.SetActive(true);
                break;

                case 3:
                airVent4.GetChild(0).gameObject.SetActive(true);
                break;

                case 4:
                airVent5.GetChild(0).gameObject.SetActive(true);
                break;
            }
        }
    }

    public void PipePuzzleReset()
    {
        Debug.LogWarning("Puzzle Reset");

        FixableAirvent = 0;

        RandomPipeSelector();
    }

     void PuzzleCompleted()
    {   
        airVent1.GetChild(0).gameObject.SetActive(false);
        airVent2.GetChild(0).gameObject.SetActive(false);
        airVent3.GetChild(0).gameObject.SetActive(false);
        airVent4.GetChild(0).gameObject.SetActive(false);
        airVent5.GetChild(0).gameObject.SetActive(false);

        puzzleManager.PipePuzzleComplete();
    }
}
