using UnityEngine;

public class PatrolShootState : PatrolBaseState
{
    private float _currentDelayShootTime = 0f;

    public PatrolShootState(string name, FSMBase fsm) : base(name, fsm)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _currentDelayShootTime = 0f;
    }

    public override void Update()
    {
        base.Update();

        CountDelayShoot();
        CheckTarget();
    }

    private void CountDelayShoot()
    {
        _currentDelayShootTime += Time.deltaTime;
        if (_currentDelayShootTime >= FSM.ShootDelay)
        {
            Debug.Log("Shoot");
        }
    }

    private void CheckTarget()
    {
        if (FSM.CheckTarget()) return;

        FSM.RedoState();
    }
}
