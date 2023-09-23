using Cinemachine;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfinerSwitcher : MonoBehaviour
{
    #region Variables

    [BoxGroup("References")]
    [SerializeField] private CinemachineConfiner2D _confiner = null;

    [BoxGroup("References")]
    [ListDrawerSettings(Expanded = true)]
    [SerializeField] private List<PolygonCollider2D> _colliders = new List<PolygonCollider2D>();

    #endregion

    #region Mono

    public void Change(int index)
    {
        if (index > _colliders.Count - 1) return;

        _confiner.m_BoundingShape2D = _colliders[index];
        _confiner.InvalidateCache();
    }

    #endregion
}
