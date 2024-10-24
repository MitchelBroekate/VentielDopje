using UnityEngine;

public class PipeInteractable : MonoBehaviour
{
    #region Vars
    [SerializeField] PipePuzzleManager pipePuzzleManager;
    [SerializeField] int valveInt;
    [SerializeField] Transform rotateObject;

    [SerializeField] AudioSource audioSource;
    #endregion

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateObject.rotation, 1 * Time.deltaTime);
    }

    /// <summary>
    /// This function checks if the right pipe is selected when interacted with
    /// </summary>
    public void PipeInteract()
    {
        if(pipePuzzleManager.completionLock) return;

        audioSource.Play();

        if(valveInt == pipePuzzleManager.currentAirvent)
        {
            pipePuzzleManager.lastPipe = valveInt;
            pipePuzzleManager.RandomPipeSelector();

            rotateObject.transform.Rotate(0, 180, 0);
        }
        else
        {
            pipePuzzleManager.PipePuzzleReset();
            
            rotateObject.transform.Rotate(0, 180, 0);
        }
    }
}
