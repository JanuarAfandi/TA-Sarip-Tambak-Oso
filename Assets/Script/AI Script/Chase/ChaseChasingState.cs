using UnityEngine;

public class ChaseChasingState : ChaseBaseState
{
    #region Variables

    private bool _isMoving = true;
    private float _timeToBack = 0f;

    #endregion

    #region Base State

    public ChaseChasingState(string name, FSMBase fsm) : base(name, fsm)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _isMoving = true;
        _timeToBack = 0f;
    }

    public override void Update()
    {
        base.Update();

        CheckTarget();
        CheckDistanceToTarget();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        Move();
    }

    public override void Exit()
    {
        base.Exit();

        FSM.Movement.Move(0);
    }

    #endregion

    #region Methods

    private void Move()
    {
        if (!_isMoving)
        {
            FSM.Movement.Move(0);
            return;
        }  

        Vector2 direction = (Vector2)FSM.Target.position - (Vector2)FSM.transform.position;

        FSM.Movement.Move(direction.x < 0 ? -1 : 1);
    }

    private void CheckDistanceToTarget()
    {
        if (FSM.Target == null) return;

        float distanceToTarget = Vector2.Distance(FSM.transform.position, FSM.Target.position);

        if (distanceToTarget > FSM.CatchDistance) return;

        FSM.ChangeState(FSM.catchState);
    }

    private void CheckTarget()
    {
        bool isOnBoundary = FSM.OriginPos.x - FSM.ChaseRange <= FSM.transform.position.x && FSM.transform.position.x <= FSM.OriginPos.x + FSM.ChaseRange;
        if (FSM.Target != null && isOnBoundary)
        {
            _isMoving = true;
            _timeToBack = 0f;
            return;
        }

        _isMoving = false;
        _timeToBack += Time.deltaTime;

        if (_timeToBack >= FSM.UnchaseTime)
        {
            FSM.ChangeState(FSM.backState);
        }
    }

    #endregion
}
