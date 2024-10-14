using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRotateIneractable : MonoBehaviour
{
    int rotateValue;
    public void RotatePipe()
    {
        transform.Rotate(0,90,0);
        rotateValue++;
    }
}
