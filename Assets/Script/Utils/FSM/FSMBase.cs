using Sirenix.OdinInspector;
using UnityEngine;

public class FSMBase : MonoBehaviour
{
    #region Variables

    [BoxGroup("Debug", Order = 999)]
    [SerializeField]
    private bool _showGUI = false;

    protected BaseState _prevState = null;
    protected BaseState _currentState = null;

    #endregion

    #region Mono

    protected virtual void Awake()
    {
        InitializeStates();
        _currentState = GetInitialState();
    }

    protected virtual void Start()
    {
        if (_currentState == null)
            return;

        _currentState.Enter();
    }

    protected virtual void Update()
    {
        if (_currentState == null) return;

        _currentState.Update();
    }

    protected virtual void FixedUpdate()
    {
        if (_currentState == null) return;

        _currentState.FixedUpdate();
    }

    protected virtual void LateUpdate()
    {
        if (_currentState == null) return;

        _currentState.LateUpdate();
    }

    #endregion

    #region Methods

    protected virtual void InitializeStates() { }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    public void ChangeState(BaseState state)
    {
        if (state == _currentState) return;

        _currentState.Exit();

        _prevState = _currentState;

        _currentState = state;

        state.Enter();
    }

    public void RedoState()
    {
        if (_prevState == null) return;

        ChangeState(_prevState);
    }

    #endregion

    #region GUI

#if UNITY_EDITOR
    private void OnGUI()
    {
        if (!_showGUI) return;

        GUILayout.BeginArea(new Rect(10f, 10f, 200f, 100f));
        string content = _currentState != null ? _currentState.Name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        GUILayout.EndArea();
    }
#endif

    #endregion
}