using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteraction
{
    [Header("UnityEvent")]
    [SerializeField] UnityEvent onInteract;

    [Header("IntroCheck")]
    [SerializeField] bool IntroCheck;

    //Getter and Setter for the onInteract function
    UnityEvent IInteraction.onInteract
    {
        get => onInteract;
        set => onInteract = value;
    }

    /// <summary>
    /// Invokes the onInteract
    /// </summary>
    public void Interact() => onInteract.Invoke();
}