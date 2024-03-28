using UnityEngine;

public class ChaseBackState : ChaseBaseState
{
    public ChaseBackState(string name, FSMBase fsm) : base(name, fsm)
    {
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        Move();
    }

    public override void Update()
    {
        base.Update();

        CheckTarget();
    }

    private void Move()
    {
        Vector2 direction = FSM.OriginPos - (Vector2)FSM.transform.position;

        FSM.Movement.Move(direction.x < 0 ? -1 : 1);

        float distanceFromTargetPoint = Vector2.Distance(FSM.transform.position, FSM.OriginPos);
        if (distanceFromTargetPoint <= FSM.MinDistanceToTarget)
        {
            FSM.Movement.Move(0);
            FSM.ChangeState(FSM.idleState);
        }
    }

    private void CheckTarget()
    {
        if (FSM.Target == null) return;

        FSM.ChangeState(FSM.chasingState);
    }
}
