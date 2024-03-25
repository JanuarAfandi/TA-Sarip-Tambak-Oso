using Sirenix.OdinInspector;
using SOGameEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideManager : MonoBehaviour
{
    [BoxGroup("References")]
    [SerializeField]
    private Rigidbody2D _rigidbody = null;

    [BoxGroup("References")]
    [SerializeField]
    private Collider2D _collider = null;

    [BoxGroup("References")]
    [SerializeField]
    private GameObject _graphics = null;

    [BoxGroup("Events")]
    [SerializeField]
    private GameEventNoParam _hideEvent = null;

    [BoxGroup("Events")]
    [SerializeField]
    private GameEventBool _setActiveControllerButtonEvent = null;

    [BoxGroup("Events")]
    [SerializeField]
    private GameEventBool _setActiveInteractButtonEvent = null;

    [BoxGroup("Events")]
    [SerializeField]
    private GameEventNoParam _interactEvent = null;

    [BoxGroup("Debug")]
    [SerializeField, ReadOnly]
    private bool _isHidden = false;

    private void OnEnable()
    {
        _hideEvent.AddListener(Hide);
    }

    private void OnDisable()
    {
        _hideEvent.RemoveListener(Hide);
    }

    private void Hide()
    {
        _isHidden = true;

        _interactEvent.AddListener(Unhide);

        _rigidbody.isKinematic = true;
        _collider.isTrigger = true;
        _graphics.SetActive(false);

        _setActiveInteractButtonEvent.Invoke(true);
        _setActiveControllerButtonEvent.Invoke(false);
    }

    private void Unhide()
    {
        _isHidden = false;

        _interactEvent.RemoveListener(Unhide);

        _rigidbody.isKinematic = false;
        _collider.isTrigger = false;
        _graphics.SetActive(true);

        _setActiveInteractButtonEvent.Invoke(false);
        _setActiveControllerButtonEvent.Invoke(true);
    }
}
