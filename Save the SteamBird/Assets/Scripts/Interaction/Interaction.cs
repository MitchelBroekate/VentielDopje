using Unity.VisualScripting;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    #region  Vars
    public PlayerControls playerControls;
    RaycastHit hit;
    public bool invetoryFull;

    public int cogInInventory;
    public int birdPartInInventory;

    [SerializeField] LayerMask interactableLayer;
    #endregion

    /// <summary>
    /// Updates the Innteract function
    /// </summary>
    void Update()
    {
        DoInteract();
    }

    /// <summary>
    /// This function checks for a interactable or an item that can be picked up and sets states for those interactables/items
    /// </summary>
    void DoInteract()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(!Physics.Raycast(transform.position, transform.forward, out hit, 2, interactableLayer)) return;
            
            if(!hit.transform.TryGetComponent(out Interactable interactable)) return;
            Transform currentHit = hit.transform;
            
            if(hit.collider.gameObject.tag == "COG")
            {

                if(invetoryFull) return;

                interactable.Interact();

                if(currentHit.GetComponent<CogInteract>().cog1)
                {
                    cogInInventory = 1;
                }
                else
                {
                    cogInInventory = 2;
                }

                invetoryFull = true;
                playerControls.invetoryFull = true;
            }
            
            else if(hit.collider.gameObject.tag == "BIRDPART")
            {
                if(invetoryFull) return;

                interactable.Interact();

                if(currentHit.GetComponent<BirdInteraction>().birdPart == 1)
                {
                    birdPartInInventory = 1;
                }
                else if(currentHit.GetComponent<BirdInteraction>().birdPart == 2)
                {
                    birdPartInInventory = 2;
                }
                else if(currentHit.GetComponent<BirdInteraction>().birdPart == 3)
                {
                    birdPartInInventory = 3;
                }

                invetoryFull = true;
                playerControls.invetoryFull = true;
            }

            else
            {
                interactable.Interact();
            }
        }
    }
}
