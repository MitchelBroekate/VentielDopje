using Unity.VisualScripting;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    #region  Vars
    public PlayerControls playerControls;
    RaycastHit hit;
    public bool invetoryFull;

    public int cogInt;
    public int birdPartInInventory;
    public Transform cogInInventory;

    public GameObject interactTXT;
    public GameObject dropTXT;

    [SerializeField] LayerMask interactableLayer;
    #endregion

    /// <summary>
    /// Updates the Innteract function
    /// </summary>
    void Update()
    {
        if(!playerControls.winMovement)
        {
            DoInteract();
        }
        
    }

    /// <summary>
    /// This function checks for a interactable or an item that can be picked up and sets states for those interactables/items
    /// </summary>
    void DoInteract()
    {
        //sets the drop text when the player carries an item
        if(invetoryFull)
        {
            dropTXT.SetActive(true);
        }
        else
        {
            dropTXT.SetActive(false);
        }

        if(Physics.Raycast(transform.position, transform.forward, out hit, 1.5f, interactableLayer))
        {
            Debug.Log(hit.transform.tag);
            if(hit.transform.tag != "COGPUZZLE")
            {
                interactTXT.SetActive(true);
            }
            else if(hit.transform.gameObject.tag == "COGPUZZLE" && invetoryFull)
            {
                interactTXT.SetActive(true);
            }

            if(!hit.transform.TryGetComponent(out Interactable interactable)) return;

            if (Input.GetMouseButtonDown(0))
            {
                
                Transform currentHit = hit.transform;
                
                if(hit.collider.tag == "COG")
                {

                    if(invetoryFull) return;

                    interactable.Interact();

                    cogInt = currentHit.GetComponent<CogInteract>().cog;
                    cogInInventory = currentHit.transform;

                    invetoryFull = true;
                    playerControls.invetoryFull = true;
                }
                
                else if(hit.collider.tag == "BIRDPART")
                {
                    if(invetoryFull) return;

                    interactable.Interact();

                    birdPartInInventory = currentHit.GetComponent<BirdInteraction>().birdPart;

                    invetoryFull = true;
                    playerControls.invetoryFull = true;
                }

                else
                {
                    interactable.Interact();
                }
            }
        }
        else
        {
            interactTXT.SetActive(false);
            return;
        }
    }
}
