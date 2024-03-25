using UnityEngine;

public class PatrolMoveState : PatrolBaseState
{
    public PatrolMoveState(string name, FSMBase fsm) : base(name, fsm)
    {
    }

    public override void Update()
    {
        base.Update();

        CheckTarget();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        float distanceFromTargetPoint = Vector2.Distance(FSM.transform.position, FSM.PatrolPoints[FSM.CurrentPointIndex]);
        if (distanceFromTargetPoint <= FSM.MinDistanceFromPoint)
        {
            FSM.CurrentPointIndex++;
            if (FSM.CurrentPointIndex == FSM.PatrolPoints.Count)
            {
                FSM.CurrentPointIndex = 0;
            }

            FSM.ChangeState(FSM.idleState);

            return;
        }

        Vector2 direction = FSM.PatrolPoints[FSM.CurrentPointIndex] - (Vector2)FSM.transform.position;

        FSM.Movement.Move(direction.x < 0 ? -1 : 1);
    }

    public override void Exit()
    {
        base.Exit();

        FSM.Movement.Move(0);
    }

    private void CheckTarget()
    {
        if (!FSM.CheckTarget()) return;

        FSM.ChangeState(FSM.shootState);
    }
}
