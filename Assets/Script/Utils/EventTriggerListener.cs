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
        _listener.AddListener(OnListen);
    }

    private void OnDisable()
    {
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
