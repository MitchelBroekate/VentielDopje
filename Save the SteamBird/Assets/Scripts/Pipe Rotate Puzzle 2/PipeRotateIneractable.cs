using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRotateIneractable : MonoBehaviour
{
    public int rotateValue = 0;
    public void RotatePipe()
    {
        transform.Rotate(0,90,0);

        if(rotateValue < 4)
        {
            rotateValue++;
        }
        else
        {
            rotateValue = 0;
        }
    }
}
