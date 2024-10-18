using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DoorInteraction : MonoBehaviour
{
    public Transform doorRotate;
    bool coroutineActive;
    void Update()
    {
        if (coroutineActive) 
        transform.rotation = Quaternion.Slerp(transform.rotation, doorRotate.rotation, 0.2f * Time.deltaTime);
    }

    public void DoorInteract()
    {
        if(doorRotate != null)//game not finished
        {
            if(!coroutineActive)
            {
                StartCoroutine(DoorWiggle());
            }
        }

    }

    IEnumerator DoorWiggle()
    {
        coroutineActive = true;
        doorRotate.Rotate(0, 0, 20);
        yield return new WaitForSeconds(1f);
        doorRotate.Rotate(0, 0, -40);
        yield return new WaitForSeconds(1f);
        doorRotate.Rotate(0, 0, 20);
        yield return new WaitForSeconds(1f);
        doorRotate.Rotate(0, 0, -40);
        yield return new WaitForSeconds(1f);
        doorRotate.Rotate(0, 0, 0);
        yield return new WaitForSeconds(3);
        coroutineActive = false;
    }
}
