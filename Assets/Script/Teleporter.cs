using Sirenix.OdinInspector;
using SOGameEvents;
using UnityEngine;

public class Teleporter : Interactable
{
    public Transform targetPosition = null;

    [BoxGroup("Events", Order = 1)]
    public GameEventBool setActiveInteractButton = null;

    [BoxGroup("Events", Order = 1)]
    public GameEventVector2 movePositionPlayerEvent = null;

    public override void Detected()
    {
        base.Detected();

        setActiveInteractButton.Invoke(true);
    }

    public override void Undetected()
    {
        base.Undetected();

        setActiveInteractButton.Invoke(false);
    }

    public override void Interact()
    {
        base.Interact();

        Debug.Log("Interact");

        movePositionPlayerEvent.Invoke(targetPosition.position);
    }
}
