using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] bool holdingItem;
    [SerializeField] GameObject item;

    [SerializeField] Transform itemHoldLocation;
    [SerializeField] RaycastHit hit;

    void OnInteract(InputValue value)
    {
        if(value.isPressed)
        {
            if(Physics.Raycast(transform.position, transform.forward, out hit, 20))
            {
                if(hit.collider.gameObject.tag == "INTERACTABLE")
                {
                    
                }

                if(!holdingItem)
                {
                    if(hit.collider.gameObject.tag == "ITEM")
                    {
                        item = hit.collider.gameObject;
                        item.transform.parent = transform;
                        holdingItem = true;
                    }
                }
            }
        }
    }
}
