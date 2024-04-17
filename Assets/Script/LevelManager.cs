using Sirenix.OdinInspector;
using Sirenix.Serialization;
using SOGameEvents;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

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
        List<string> keys = LevelKeys.Keys.ToList();

        for (int i = 0; i < keys.Count; ++i)
        {
            Debug.Log(keys[i]);

            if (!ES3.KeyExists(keys[i])) continue;

            Debug.Log($"Load key: {keys[i]}");

            LevelKeys[keys[i]] = ES3.Load<bool>(keys[i]);
        }
    }
}
