using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        collision.transform.position += new Vector3(0, 0.30f, 0);
    }
}
