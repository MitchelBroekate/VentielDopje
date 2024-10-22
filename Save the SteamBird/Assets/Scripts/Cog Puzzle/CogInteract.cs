using UnityEngine;

public class CogInteract : MonoBehaviour
{
    #region Vars
    public GameObject playerParent;
    public Transform cogCarryPos;
    public bool inObjective;
    public GameObject currentCog;
    public bool inInventory;
    public GameObject particle;
    public int cog;
    #endregion

    /// <summary>
    /// This function picks up the cog so the player holds it with them
    /// </summary>
    public void CogCarry()
    {
        if(inObjective) return;
        inInventory = true;
        transform.parent = playerParent.transform;
        transform.position = cogCarryPos.position;
        transform.rotation = cogCarryPos.rotation;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;
        particle.SetActive(false);
    }
}
