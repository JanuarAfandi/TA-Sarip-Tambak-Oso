using Sirenix.OdinInspector;
using SOGameEvents;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "New Mission Data",
    menuName = "Mission/New Mission Data"
    )]
public class Mission : ScriptableObject
{
    #region Variables

    [BoxGroup("Data")]
    public string Title = "Mission Title";

    [BoxGroup("Data")]
    [ListDrawerSettings(Expanded = true)]
    public List<MissionItem> Todos = new List<MissionItem>();

    [BoxGroup("Events")]
    public GameEventObject StartMissionCallback = null;

    [BoxGroup("Events")]
    public GameEventNoParam StartThisMissionCallback = null;

    [BoxGroup("Events")]
    public List<GameEventNoParam> OnMissionIsDone = new List<GameEventNoParam>();

    [BoxGroup("Events")]
    public List<GameEventNoParam> OnMissionCanceled = new List<GameEventNoParam>();

    #endregion

    #region Properties

    public bool IsDone
    {
        get
        {
            foreach (MissionItem todo in Todos)
            {
                if (!todo.IsDone) return false;
            }

            return true;
        }
    }

    #endregion

    #region Methods

    public void InitEvent()
    {
        if (StartThisMissionCallback != null)
            StartThisMissionCallback.AddListener(StartMission);
    }

    public void Dispose()
    {
        if (StartThisMissionCallback != null)
            StartThisMissionCallback.RemoveListener(StartMission);
    }

    private void StartMission()
    {
        if (StartMissionCallback == null) return;

        StartMissionCallback.Invoke(this);
    }

    public void Initialize()
    {
        foreach (MissionItem todo in Todos)
        {
            todo.Initialize();
        }
    }

    public void Deinitialize()
    {
        foreach (MissionItem todo in Todos)
        {
            todo.Deinitialize();
        }
    }

    public void Done()
    {
        Debug.Log($"Misssion {Title} is done.");
        
        Deinitialize();

        foreach (var gameEvent in OnMissionIsDone)
        {
            Debug.Log($"Game event invoke: {gameEvent.ToString()}");
            gameEvent.Invoke();
        }
    }

    public void Cancel()
    {
        Deinitialize();

        foreach (var gameEvent in OnMissionCanceled)
        {
            gameEvent.Invoke();
        }
    }

    #endregion
}
