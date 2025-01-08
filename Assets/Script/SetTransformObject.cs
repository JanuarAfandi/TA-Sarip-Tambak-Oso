using Sirenix.OdinInspector;
using UnityEngine;

public class SetTransformObject : MonoBehaviour
{
    public Transform reference;

    [Header("Properties")]
    public bool changePosition = true;
    [ShowIf("changePosition")]
    public Vector3 position = Vector3.zero;

    public bool changeRotation = true;
    [ShowIf("changeRotation")]
    public Vector3 rotation = Vector3.zero;

    public bool changeScale = true;
    [ShowIf("changeScale")]
    public Vector3 scale = Vector3.one;

    [Button]
    public void Trigger()
    {
        if (reference == null) return;

        if (changePosition) reference.localPosition = position;
        if (changeRotation) reference.localEulerAngles = rotation;
        if (changeScale) reference.localScale = scale;
    }

    [Button("Get Current Transform Properties")]
    public void GetCurrentTransform()
    {
        position = reference.localPosition;
        rotation = reference.localEulerAngles;
        scale = reference.localScale;
    }
}
