using UnityEngine;

public class PipeInteractable : MonoBehaviour
{
    [SerializeField] PipePuzzleManager pipePuzzleManager;
    [SerializeField] int valveInt;

    public void PipeInteract()
    {
        if(pipePuzzleManager.FixableAirvent > 5) return;

        if(valveInt == pipePuzzleManager.currentAirvent)
        {
            pipePuzzleManager.lastPipe = valveInt;
            pipePuzzleManager.RandomPipeSelector();
        }
        else
        {
            pipePuzzleManager.PipePuzzleReset();
        }
    }
}
