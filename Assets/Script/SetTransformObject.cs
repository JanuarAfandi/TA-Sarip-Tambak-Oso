using Sirenix.OdinInspector;
using UnityEngine;

public class SetTransformObject : MonoBehaviour
{
    public Transform reference;

    [Header("Properties")]
    public Vector3 position = Vector3.zero;
    public Vector3 rotation = Vector3.zero;
    public Vector3 scale = Vector3.one;

    [Button]
    public void Trigger()
    {
        if (reference == null) return;

        reference.localPosition = position;
        reference.localEulerAngles = rotation;
        reference.localScale = scale;
    }
}
