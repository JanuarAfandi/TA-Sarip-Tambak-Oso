using UnityEngine;

public class ChaseCatchState : ChaseBaseState
{
    #region Variables

    private float _timeToCatch = 0f;
    private bool _alreadyCatch = false;

    #endregion

    #region BaseState

    public ChaseCatchState(string name, FSMBase fsm) : base(name, fsm)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _timeToCatch = 0f;
    }

    public override void Update()
    {
        base.Update();

        CheckTarget();
    }

    #endregion

    #region Methods

    private void CheckTarget()
    {
        if (_alreadyCatch) return;

        if (FSM.Target == null)
        {
            FSM.RedoState();
            return;
        }

        float distanceToTarget = Vector2.Distance(FSM.transform.position, FSM.Target.position);
        if (distanceToTarget > FSM.CatchDistance)
        {
            FSM.RedoState();
            return;
        }

        _timeToCatch += Time.deltaTime;

        if (_timeToCatch < FSM.CatchTime) return;

        if (FSM.OnCatchEvent != null)
            FSM.OnCatchEvent.Invoke();

        _alreadyCatch = true;
    }

    #endregion
}
