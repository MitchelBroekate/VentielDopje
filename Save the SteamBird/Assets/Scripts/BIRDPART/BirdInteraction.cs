using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdInteraction : MonoBehaviour
{
    #region Vars
    public GameObject playerParent;
    public Transform birdPartCarryPos;
    public bool inObjective;

    public int birdPart;
    #endregion

    /// <summary>
    /// This function picks up the BirdPart so the player holds it with them
    /// </summary>
    public void BirdPartCarry()
    {
        if(inObjective) return;
        transform.parent = playerParent.transform;
        transform.position = birdPartCarryPos.position;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
