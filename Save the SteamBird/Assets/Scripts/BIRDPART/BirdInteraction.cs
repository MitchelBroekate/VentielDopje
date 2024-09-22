using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdInteraction : MonoBehaviour
{
    #region Vars
    public GameObject cameraParent;
    public Transform birdPartCarryPos;
    public bool inObjective;

    public bool cog1;
    #endregion

    /// <summary>
    /// This function picks up the BirdPart so the player holds it with them
    /// </summary>
    public void BirdPartCarry()
    {
        if(inObjective) return;
        transform.parent = cameraParent.transform;
        transform.position = birdPartCarryPos.position;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;
    }
}
