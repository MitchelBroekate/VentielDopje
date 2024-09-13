using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteraction
{
    [SerializeField]private UnityEvent onInteract;

    UnityEvent IInteraction.onInteract
    {
        get => onInteract;
        set => onInteract = value;
    }

    public void Interact() => onInteract.Invoke();

}