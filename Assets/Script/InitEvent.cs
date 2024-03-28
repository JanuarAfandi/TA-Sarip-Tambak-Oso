using UnityEngine;
using UnityEngine.Events;

public class InitEvent : MonoBehaviour
{
    public enum Type { Start, Awake, Enabled }

    public Type type = Type.Awake;
    public UnityEvent initEvent = new UnityEvent();

    private void Awake()
    {
        if (type != Type.Awake) return;

        initEvent.Invoke();
    }

    private void Start()
    {
        if (type != Type.Start) return;

        initEvent.Invoke();
    }

    private void OnEnable()
    {
        if (type != Type.Enabled) return;

        initEvent.Invoke();
    }
}
