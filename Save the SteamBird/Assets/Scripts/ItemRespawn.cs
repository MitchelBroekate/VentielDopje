using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    [SerializeField] GameObject partRespawnLocation;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BIRDPART" || collision.gameObject.tag == "COG")
        {
            collision.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.transform.position = partRespawnLocation.transform.position;
        }
    }
}
