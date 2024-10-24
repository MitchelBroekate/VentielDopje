using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdInteraction : MonoBehaviour
{
    #region Vars
    public GameObject playerParent;
    public Transform birdPartCarryPos;
    public bool inObjective;
    public GameObject particle;
    public int birdPart;
    public AudioSource audioSource;
    #endregion

    /// <summary>
    /// This function picks up the BirdPart so the player holds it with them
    /// </summary>
    public void BirdPartCarry()
    {
        if(inObjective) return;
        transform.parent = playerParent.transform;
        transform.position = birdPartCarryPos.position;
        transform.rotation = birdPartCarryPos.rotation;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;
        particle.SetActive(false);

    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "GROUND")
        {
            if(audioSource.enabled == true)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.enabled = true;
            }
        }
    }
}
