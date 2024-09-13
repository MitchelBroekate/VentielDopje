using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    RaycastHit hit;

    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, 20))
        {
            if(hit.collider.gameObject != null)
            {
                
            }
        }
    }

    void OnInteract(InputValue value)
    {
        if(value.isPressed)
        {

        }
    }
}
