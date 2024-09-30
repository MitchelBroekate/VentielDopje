using UnityEngine;

public class CogInteract : MonoBehaviour
{
    #region Vars
    public GameObject cameraParent;
    public Transform cogCarryPos;
    public bool inObjective;
    public GameObject currentCog;

    public int cog;
    #endregion

    /// <summary>
    /// This function picks up the cog so the player holds it with them
    /// </summary>
    public void CogCarry()
    {
        if(inObjective) return;
        transform.parent = cameraParent.transform;
        transform.position = cogCarryPos.position;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;
    }
}
