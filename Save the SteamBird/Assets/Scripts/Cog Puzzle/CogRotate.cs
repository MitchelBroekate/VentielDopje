using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogRotate : MonoBehaviour
{
    public bool canRotate;

    void FixedUpdate()
    {
        if(canRotate)
        {
            transform.Rotate(new Vector3(0, 3, 0));
        }
    }
}
