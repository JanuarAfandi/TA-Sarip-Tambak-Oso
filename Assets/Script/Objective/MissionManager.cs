using Sirenix.OdinInspector;
using SOGameEvents;
using UnityEngine;

public class MissionManager : SingletonDontDestroy<MissionManager>
{
    #region Variables

    [BoxGroup("Data")]
    [SerializeField] private Mission _currentMission = null;

    [BoxGroup("Events")]
    [SerializeField] private GameEventObject _startMissionCallback = null;

    [BoxGroup("Events")]
    [SerializeField] private GameEventNoParam _cancelMissionCallback = null;

    [BoxGroup("Events")]
    [SerializeField] private GameEventNoParam _onMissionChanged = null;

    #endregion

    #region Props

    public Mission CurrentMission { get { return _currentMission; } }

    #endregion

    #region Mono

    protected override void Awake()
    {
        base.Awake();

        _startMissionCallback.AddListener(StartMission);
        _cancelMissionCallback.AddListener(CancelMission);
    }

    private void Start()
    {
        if (_currentMission != null)
            StartMission(_currentMission);
    }

    private void OnDestroy()
    {
        _startMissionCallback.RemoveListener(StartMission);
        _cancelMissionCallback?.RemoveListener(CancelMission);
    }

    #endregion

    #region Methods

    private void StartMission(object missionObj)
    {
        Debug.Log("Test");

        if (missionObj is not Mission) return;

        if (_currentMission != null)
        {
            CancelMission();
        }

        _currentMission = (Mission)missionObj;

        Debug.Log($"Start new mission {_currentMission.Title}");

        _currentMission.Initialize();

        foreach(MissionItem todo in _currentMission.Todos)
        {
            todo.Callback.AddListener(CheckIsDone);
        }

        _onMissionChanged.Invoke();
    }

    private void CancelMission()
    {
        if (_currentMission == null) return;

        _currentMission.Cancel();

        foreach (MissionItem todo in _currentMission.Todos)
        {
            todo.Callback.RemoveListener(CheckIsDone);
        }

        _currentMission = null;

        _onMissionChanged.Invoke();
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

        _onMissionChanged.Invoke();
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
