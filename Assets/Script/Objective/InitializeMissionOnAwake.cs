using Sirenix.OdinInspector;
using SOGameEvents;
using UnityEngine;

public class InitializeMissionOnAwake : MonoBehaviour
{
    #region Variables

    [BoxGroup("Data")]
    [SerializeField] private Mission _missionToInitialize = null;

    [BoxGroup("Events")]
    [SerializeField] private GameEventObject _startMissionCallback = null;

    #endregion

    #region Mono

    private void Start()
    {
        if (_missionToInitialize == null) return;

        _startMissionCallback.Invoke(_missionToInitialize);
    }

    #endregion
}
