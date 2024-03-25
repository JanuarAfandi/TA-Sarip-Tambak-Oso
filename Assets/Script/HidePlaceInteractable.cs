using Sirenix.OdinInspector;
using SOGameEvents;
using UnityEngine;

public class HidePlaceInteractable : Interactable
{
    [BoxGroup("Events")]
    [SerializeField]
    private GameEventNoParam _hidePlayerEvent = null;

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

        _hidePlayerEvent.Invoke();
    }
}
