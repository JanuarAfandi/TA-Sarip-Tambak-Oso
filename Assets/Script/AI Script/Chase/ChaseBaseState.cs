public class ChaseBaseState : BaseState
{
    public ChaseFSM FSM { get { return (ChaseFSM)_fsm; } }

    public ChaseBaseState(string name, FSMBase fsm) : base(name, fsm)
    {
    }
}
