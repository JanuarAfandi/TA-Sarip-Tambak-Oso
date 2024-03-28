using Sirenix.OdinInspector;
using SOGameEvents;
using UnityEngine;

public class ChaseFSM : FSMBase
{
    [BoxGroup("Properties")]
    [SerializeField]
    private float _detectRange = 1f;

    [BoxGroup("Properties")]
    [SerializeField]
    private float _chaseRange = 10f;

    [BoxGroup("Properties")]
    [SerializeField]
    private float _unchaseTime = 1f;

    [BoxGroup("Properties")]
    [SerializeField]
    private float _catchDistance = 1f;

    [BoxGroup("Properties")]
    [SerializeField]
    private float _catchTime = 1f;

    [BoxGroup("Properties")]
    [SerializeField]
    private float _minDistanceToTarget = 1f;

    [BoxGroup("Properties")]
    [SerializeField]
    private bool _isTurned = false;

    [BoxGroup("Properties")]
    [SerializeField]
    private float _turnedTime = 3f;

    [BoxGroup("Properties")]
    [SerializeField]
    private LayerMask _targetLayer = 0;

    [BoxGroup("References")]
    [SerializeField]
    private CharacterMovement _movement = null;

    [BoxGroup("Events")]
    [SerializeField]
    private GameEventNoParam _onCatchEvent = null;

    [BoxGroup("Debug")]
    [SerializeField, ReadOnly]
    private Transform _target = null;

    [BoxGroup("Debug")]
    [SerializeField, ReadOnly]
    private bool _isInitOrigin = false;

    [BoxGroup("Debug")]
    [SerializeField, ReadOnly]
    private Vector2 _originPos = Vector2.zero;

    #region States

    public ChaseIdleState idleState = null;
    public ChaseChasingState chasingState = null;
    public ChaseBackState backState = null;
    public ChaseCatchState catchState = null;

    #endregion

    #region Properties

    public bool IsTurned { get { return _isTurned; } }
    public float TurnedTime { get { return _turnedTime; } }
    public float UnchaseTime { get { return _unchaseTime; } }
    public float CatchDistance { get { return _catchDistance; } }
    public float CatchTime { get { return _catchTime; } }
    public float ChaseRange { get { return _chaseRange; } }
    public float MinDistanceToTarget { get { return _minDistanceToTarget; } }
    public CharacterMovement Movement { get { return _movement; } }
    public Transform Target { get { return _target; } set { _target = value; } }
    public Vector2 OriginPos { get { return _originPos; } }
    public GameEventNoParam OnCatchEvent { get { return _onCatchEvent; } }

    #endregion

    #region FSM Base

    protected override void InitializeStates()
    {
        base.InitializeStates();

        idleState = new ChaseIdleState("Idle", this);
        chasingState = new ChaseChasingState("Chasing", this);
        backState = new ChaseBackState("Back", this);
        catchState = new ChaseCatchState("Catch", this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    #endregion

    #region Mono

    protected override void Update()
    {
        base.Update();

        CheckTarget();

        if (!_isInitOrigin)
        {
            if (!Movement.GroundCheck()) return;

            _isInitOrigin = true;
            _originPos = transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Target != null ? Color.green : Color.red;

        Vector2 forward = _detectRange * transform.right;
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y + 3f, 0f), new Vector3(transform.position.x + forward.x, transform.position.y + 3f, 0f));

        Vector3 pos = _isInitOrigin ? _originPos : transform.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(pos.x - _chaseRange, pos.y + 1f, pos.z), new Vector3(pos.x + _chaseRange, pos.y + 1f, pos.z));
    }

    #endregion

    #region Methods

    public void CheckTarget()
    {
        RaycastHit2D[] hits = new RaycastHit2D[10];

        int count = Physics2D.RaycastNonAlloc(transform.position + new Vector3(0, 1f, 0), transform.right, hits, _detectRange, _targetLayer);

        Target = count > 0 ? hits[0].transform : null;
    }

    #endregion
}
