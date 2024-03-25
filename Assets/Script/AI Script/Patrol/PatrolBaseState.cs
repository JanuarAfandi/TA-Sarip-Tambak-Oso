public class PatrolBaseState : BaseState
{
    public PatrolFSM FSM { get { return (PatrolFSM)_fsm; } }

    public PatrolBaseState(string name, FSMBase fsm) : base(name, fsm)
    {
    }
}
