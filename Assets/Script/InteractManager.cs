using UnityEngine;

public class InteractManager : MonoBehaviour
{
    private Interactable _detected = null;

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
}
