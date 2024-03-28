using Sirenix.OdinInspector;
using SOGameEvents;
using System.Collections.Generic;
using UnityEngine;

public class PatrolFSM : FSMBase
{
    [BoxGroup("Properties")]
    [SerializeField]
    private float _delayBetweenMoving = 3f;

    [BoxGroup("Properties")]
    [SerializeField]
    private List<Vector2> _patrolPoints = new List<Vector2>();

    [BoxGroup("Properties")]
    [SerializeField]
    private float _minDistanceFromPoint = 1f;

    [BoxGroup("Properties")]
    [SerializeField]
    private float _shootDelay = 1f;

    [BoxGroup("Properties")]
    [SerializeField]
    private float _detectRange = 1f;

    [BoxGroup("Properties")]
    [SerializeField]
    private LayerMask _targetLayer = 0;

    [BoxGroup("References")]
    [SerializeField]
    private CharacterMovement _movement = null;

    [BoxGroup("Events")]
    [SerializeField]
    private GameEventNoParam _onShootEvent = null;

    [BoxGroup("Debug")]
    [SerializeField, ReadOnly]
    private int _currentPointIndex = 0;

    #region States

    public PatrolIdleState idleState = null;
    public PatrolMoveState moveState = null;
    public PatrolShootState shootState = null;

    #endregion

    #region Properties

    public float DelayBetweenMoving { get { return _delayBetweenMoving; } }
    public List<Vector2> PatrolPoints { get { return _patrolPoints; } }
    public float MinDistanceFromPoint { get { return _minDistanceFromPoint; } }
    public float ShootDelay { get { return _shootDelay; } }
    public float DetectRange { get { return _detectRange;} }
    public CharacterMovement Movement { get { return _movement; } }
    public int CurrentPointIndex { get { return _currentPointIndex; } set { _currentPointIndex = value; } }
    public GameEventNoParam OnShootEvent { get { return _onShootEvent; } }

    #endregion

    #region FSM Base

    protected override void InitializeStates()
    {
        base.InitializeStates();

        idleState = new PatrolIdleState("Idle", this);
        moveState = new PatrolMoveState("Move", this);
        shootState = new PatrolShootState("Shoot", this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    #endregion

    #region Mono

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        foreach (var point in PatrolPoints)
        {
            Gizmos.DrawSphere(point, 0.2f);
        }

        Gizmos.color = CheckTarget() ? Color.green : Color.red;

        Vector2 forward = DetectRange * transform.right;
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y + 1f, 0f), new Vector3(transform.position.x + forward.x, transform.position.y + 1f, 0f));
    }

    #endregion

    #region Methods

    public bool CheckTarget()
    {
        RaycastHit2D[] hits = new RaycastHit2D[10];
        int count = Physics2D.RaycastNonAlloc(transform.position + new Vector3(0, 1f, 0), transform.right, hits, DetectRange, _targetLayer);
        if (count > 0)
            Debug.Log(hits[0].transform.gameObject.name);
        return count > 0;
    }

    #endregion
}
