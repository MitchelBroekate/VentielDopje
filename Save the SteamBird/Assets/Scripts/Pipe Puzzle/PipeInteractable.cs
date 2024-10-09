using UnityEngine;

public class PipeInteractable : MonoBehaviour
{
    #region Vars
    [SerializeField] PipePuzzleManager pipePuzzleManager;
    [SerializeField] int valveInt;
    #endregion

    /// <summary>
    /// This function checks if the right pipe is selected when interacted with
    /// </summary>
    public void PipeInteract()
    {
        if(pipePuzzleManager.FixableAirvent > 4) return;

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
