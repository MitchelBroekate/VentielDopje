using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRotateIneractable : MonoBehaviour
{
    public int rotateValue = 0;
    public Transform rotateObject;
    public int rotateStart;

    void Start()
    {
        rotateObject.rotation = Quaternion.Euler(rotateStart, 0, -90);
    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateObject.rotation, 1 * Time.deltaTime);    
    }
    public void RotatePipe()
    {
        rotateObject.Rotate(0,90,0);

        if(rotateValue < 3)
        {
            rotateValue++;
        }
        else
        {
            rotateValue = 0;
        }
    }
}
