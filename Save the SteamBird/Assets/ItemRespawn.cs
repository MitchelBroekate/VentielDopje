using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    public bool respawnType;
    void OnCollisionEnter(Collision collision)
    {
        if(respawnType)
        {
            collision.transform.position += new Vector3(0, 0.3f, 0);
        }
        else
        {
            collision.transform.position += transform.forward + new Vector3(0, 0.3f, 0);
        }
    }
}
