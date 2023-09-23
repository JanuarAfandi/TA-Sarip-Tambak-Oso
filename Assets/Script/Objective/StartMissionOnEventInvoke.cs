using Sirenix.OdinInspector;
using SOGameEvents;
using UnityEngine;

public class StartMissionOnEventInvoke : MonoBehaviour
{
    #region Variables

    [BoxGroup("Data")]
    [SerializeField] private Mission _mission = null;

    [BoxGroup("Events")]
    [SerializeField] private GameEventObject _startMissionCallback = null;

    [BoxGroup("Events")]
    [SerializeField] private GameEventNoParam _eventCallback = null;

    #endregion

    #region Mono

    private void OnEnable()
    {
        _eventCallback.AddListener(StartMission);
    }

    private void OnDisable()
    {
        _eventCallback.RemoveListener(StartMission);
    }

    #endregion

    #region Methods

    private void StartMission()
    {
        Debug.Log($"Start Mission Trigger");
        _startMissionCallback.Invoke(_mission);
    }

    #endregion
}
