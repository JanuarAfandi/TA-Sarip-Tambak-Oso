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
    public GameEventNoParam OnMissionIsDone = null;

    [BoxGroup("Events")]
    public GameEventNoParam OnMissionCanceled = null;

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

        OnMissionIsDone.Invoke();
    }

    public void Cancel()
    {
        Deinitialize();

        OnMissionCanceled.Invoke();
    }

    #endregion
}
