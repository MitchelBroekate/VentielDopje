using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    RaycastHit hit;

    public bool invetoryFull;

    [SerializeField] LayerMask interactableLayer;

    void Update()
    {
        DoInteract();
    }
    void DoInteract()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("button pressed");
            if(!Physics.Raycast(transform.position, transform.forward, out hit, 200, interactableLayer)) return;
            
            if(!hit.transform.TryGetComponent(out Interactable interactable)) return;

            
            if(hit.collider.gameObject.tag != "COG")
            {
                interactable.Interact();
            }
            else
            {
                if(invetoryFull) return;

                interactable.Interact();

                invetoryFull = true;
            }

            




            Debug.Log("Interact");
        }
    }
}
