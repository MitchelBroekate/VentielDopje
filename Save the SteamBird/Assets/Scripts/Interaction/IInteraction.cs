using UnityEngine.Events;

/// <summary>
///  Base Event Function
/// </summary>
public interface IInteraction
{
   public UnityEvent onInteract {get; protected set;}
    public void Interact();
}