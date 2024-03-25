using Sirenix.OdinInspector;
using SOGameEvents;
using UnityEngine;
using UnityEngine.Events;

public class InteractableCustomEvent : Interactable
{
    public UnityEvent onInteracted = null;

    [BoxGroup("Events")]
    [SerializeField]
    private GameEventBool _setActiveInteractButton = null;

    public override void Detected()
    {
        base.Detected();

        _setActiveInteractButton.Invoke(true);
    }

    public override void Undetected()
    {
        base.Undetected();

        _setActiveInteractButton.Invoke(false);
    }

    public override void Interact()
    {
        base.Interact();

        onInteracted.Invoke();
    }
}
