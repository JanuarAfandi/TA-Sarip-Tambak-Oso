using Sirenix.OdinInspector;
using SOGameEvents;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    #region Variables

    [BoxGroup("Data")]
    [SerializeField] private Mission _currentMission = null;

    [BoxGroup("Events")]
    [SerializeField] private GameEventObject _startMissionCallback = null;

    #endregion

    #region Mono

    private void OnEnable()
    {
        _startMissionCallback.AddListener(StartMission);
    }

    private void OnDisable()
    {
        _startMissionCallback.RemoveListener(StartMission);
    }

    #endregion

    #region Methods

    private void StartMission(object missionObj)
    {
        if (missionObj is not Mission) return;

        if (_currentMission != null)
        {
            _currentMission.Cancel();
        }

        _currentMission = (Mission)missionObj;

        Debug.Log($"Start new mission {_currentMission.Title}");

        _currentMission.Initialize();

        foreach(MissionItem todo in _currentMission.Todos)
        {
            todo.Callback.AddListener(CheckIsDone);
        }

        _currentMission.OnMissionCanceled.AddListener(OnCancel);
    }

    private void OnCancel()
    {
        foreach (MissionItem todo in _currentMission.Todos)
        {
            todo.Callback.RemoveListener(CheckIsDone);
        }

        _currentMission.OnMissionCanceled.RemoveListener(OnCancel);
        _currentMission = null;
    }

    private void Done()
    {
        foreach (MissionItem todo in _currentMission.Todos)
        {
            todo.Callback.RemoveListener(CheckIsDone);
        }

        Mission completedMission = _currentMission;

        _currentMission = null;

        completedMission.Done();
    }

    private void CheckIsDone()
    {
        if (_currentMission.IsDone)
        {
            Done();
        }
    }

    #endregion
}
