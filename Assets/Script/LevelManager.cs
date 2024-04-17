using Sirenix.OdinInspector;
using Sirenix.Serialization;
using SOGameEvents;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SerializedMonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField]
    private Dictionary<string, bool> _levelKeys = new Dictionary<string, bool>();

    public GameEventString _unlockLevelCallbackEvent = null;

    public Dictionary<string, bool> LevelKeys { get { return _levelKeys; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Load();
            return;
        }

        Destroy(gameObject);
    }

    private void OnEnable()
    {
        _unlockLevelCallbackEvent.AddListener(UnlockLevel);
    }

    private void OnDisable()
    {
        _unlockLevelCallbackEvent?.RemoveListener(UnlockLevel);
    }

    private void UnlockLevel(string key)
    {
        if (!_levelKeys.ContainsKey(key)) return;

        _levelKeys[key] = true;

        ES3.Save(key, true);
    }

    private void Load()
    {
        foreach (var key in LevelKeys.Keys)
        {
            if (!ES3.KeyExists(key)) return;

            LevelKeys[key] = ES3.Load<bool>(key);
        }
    }
}
