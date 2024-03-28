using UnityEngine;

public class ChaseIdleState : ChaseBaseState
{
    #region Variables

    private float _currentTurnedTime = 0f;

    #endregion

    #region Base State

    public ChaseIdleState(string name, FSMBase fsm) : base(name, fsm)
    {
    }

    public override void Update()
    {
        base.Update();

        Turning();
        CheckTarget();
    }

    #endregion

    #region Methods

    private void Turning()
    {
        if (!FSM.IsTurned) return;

        _currentTurnedTime += Time.deltaTime;
        if (_currentTurnedTime >= FSM.TurnedTime)
        {
            Vector3 euler = FSM.transform.eulerAngles;

            if (euler.y == 0f)
                FSM.Movement.Move(-1);

            if (euler.y > 0f)
                FSM.Movement.Move(1);

            FSM.Movement.Move(0);

            _currentTurnedTime = 0f;
        }
    }

    private void CheckTarget()
    {
        if (FSM.Target == null) return;

        FSM.ChangeState(FSM.chasingState);
    }

    #endregion
}
