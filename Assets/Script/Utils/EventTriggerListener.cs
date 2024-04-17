using Sirenix.OdinInspector;
using SOGameEvents;
using UnityEngine;
using UnityEngine.Events;

public class EventTriggerListener : MonoBehaviour
{
    #region Variables

    [BoxGroup("Event Added")]
    [SerializeField] private UnityEvent _eventToListen = new UnityEvent(); 

    [BoxGroup("Event")]
    [SerializeField] private GameEventNoParam _listener = null;

    #endregion

    #region Mono

    private void OnEnable()
    {
        if (_listener == null) return;

        _listener.AddListener(OnListen);
    }

    private void OnDisable()
    {
        if (_listener == null) return;

        _listener.RemoveListener(OnListen);
    }

    #endregion

    #region Methods

    private void OnListen()
    {
        _eventToListen.Invoke();
    }

    #endregion
}
