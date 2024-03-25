using Sirenix.OdinInspector;
using SOGameEvents;
using TMPro;
using UnityEngine;

public class MissionUI : MonoBehaviour
{
    [BoxGroup("References")]
    [SerializeField] private TMP_Text _labelText = null;

    [BoxGroup("Events")]
    [SerializeField] private GameEventNoParam _onMissionChanged = null;

    private void Awake()
    {
        _onMissionChanged.AddListener(OnStartNewMission);
    }

    private void Start()
    {
        OnStartNewMission();
    }

    private void OnDestroy()
    {
        _onMissionChanged?.RemoveListener(OnStartNewMission);
    }

    private void OnStartNewMission()
    {
        MissionManager missionManager = MissionManager.Instance;

        if (missionManager == null)
        {
            ChangeText(string.Empty);
            return;
        }

        if (missionManager.CurrentMission == null)
        {
            ChangeText(string.Empty);
            return;
        }

        ChangeText(missionManager.CurrentMission.Title);
    }

    private void ChangeText(string text)
    {
        if (text == string.Empty)
        {
            _labelText.text = "-";
            return;
        }

        _labelText.text = text;
    }
}