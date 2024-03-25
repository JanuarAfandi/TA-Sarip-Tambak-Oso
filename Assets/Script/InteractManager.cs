using Sirenix.OdinInspector;
using SOGameEvents;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    private Interactable _detected = null;

    [BoxGroup("Events")]
    [SerializeField]
    private GameEventNoParam _interactEvent = null;

    private void OnEnable()
    {
        _interactEvent.AddListener(Interact);
    }

    private void OnDisable()
    {
        _interactEvent.RemoveListener(Interact);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out Interactable interactable)) return;
        if (!interactable.CanInteracted()) return;

        _detected = interactable;
        _detected.Detected();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out Interactable interactable)) return;
        if (interactable != _detected) return;

        _detected.Undetected();
        _detected = null;
    }

    private void Interact()
    {
        if (_detected == null) return;

        _detected.Interact();
    }
}
