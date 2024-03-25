using UnityEngine;

public class PatrolIdleState : PatrolBaseState
{
    private float _currentTimeToMove = 0f;

    public PatrolIdleState(string name, FSMBase fsm) : base(name, fsm)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _currentTimeToMove = 0f;
    }

    public override void Update()
    {
        base.Update();

        CountIdleTime();
        CheckTarget();
    }

    private void CountIdleTime()
    {
        _currentTimeToMove += Time.deltaTime;

        if (_currentTimeToMove >= FSM.DelayBetweenMoving)
        {
            FSM.ChangeState(FSM.moveState);

            return;
        }
    }

    private void CheckTarget()
    {
        if (!FSM.CheckTarget()) return;

        FSM.ChangeState(FSM.shootState);
    }
}
