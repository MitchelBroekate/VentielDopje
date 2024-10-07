using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogRotate : MonoBehaviour
{
    public bool canRotate;
    public bool rotateDir;
  

    void FixedUpdate()
    {

        if(canRotate)
        {
            if (rotateDir)
            {
                transform.Rotate(new Vector3(0, 3, 0));
                
                
            }
            else
            {
                transform.Rotate(new Vector3(0, -3, 0));
               
                
            }
        }
    }
}
