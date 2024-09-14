using UnityEngine;

public class Interaction : MonoBehaviour
{
    #region  Vars
    public PlayerControls playerControls;
    RaycastHit hit;
    public bool invetoryFull;
    GameObject Cog;

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
            if(!Physics.Raycast(transform.position, transform.forward, out hit, 200, interactableLayer)) return;
            
            if(!hit.transform.TryGetComponent(out Interactable interactable)) return;

            
            if(hit.collider.gameObject.tag != "COG")
            {
                interactable.Interact();

                Debug.Log("Interact");
            }
            else
            {
                if(invetoryFull) return;

                interactable.Interact();

                invetoryFull = true;
                playerControls.invetoryFull = true;

                Debug.Log("Carrying Cog");
            }
        }
    }
}
