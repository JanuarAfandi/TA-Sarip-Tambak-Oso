public class BaseState
{
    #region Variables

    protected string _name = string.Empty;
    protected FSMBase _fsm = null;

    #endregion

    #region Properties

    public string Name { get { return _name; } }

    #endregion

    #region Methods

    public BaseState(string name, FSMBase fsm)
    {
        _name = name;
        _fsm = fsm;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }

    #endregion

    #region Mono

    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void LateUpdate() { }

    #endregion
}