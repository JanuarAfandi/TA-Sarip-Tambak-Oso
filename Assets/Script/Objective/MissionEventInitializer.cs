using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionEventInitializer : SingletonDontDestroy<MissionEventInitializer>
{
    [BoxGroup("Mission List")]
    [SerializeField, ReadOnly]
    private List<Mission> _missions = new List<Mission>();

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnDestroy()
    {
        Dispose();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Dispose();
        Init();
    }

    private void Init()
    {
        _missions.Clear();

        Mission[] loadedMissions = Resources.LoadAll<Mission>("");

        _missions.AddRange(loadedMissions);

        foreach (var mission in loadedMissions)
        {
            mission.InitEvent();
        }
    }

    private void Dispose()
    {
        foreach (var mission in _missions)
        {
            mission.Dispose();
        }

        _missions.Clear();
    }
}
