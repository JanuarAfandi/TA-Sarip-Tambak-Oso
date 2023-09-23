using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Properties")]
    public float MoveSpeed = 10f;
    public float JumpForce = 10f;
    public LayerMask GroundLayer;

    [Header("References")]
    //[SerializeField] private Transform _graphics = null;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private Rigidbody2D _rigidbody = null;

    private PlayerController _playerController = null;
    private float _moveDirection = 0f;

    private void Awake()
    {
        _playerController = new PlayerController();
    }

    private void OnEnable()
    {
        _playerController.Land.Enable();
        _playerController.Land.Move.performed += Move_peformed;
        _playerController.Land.Move.canceled += Move_canceled;
        _playerController.Land.Jump.started += Jump_started;
    }

    private void OnDisable()
    {
        _playerController.Land.Move.performed -= Move_peformed;
        _playerController.Land.Move.canceled -= Move_canceled;
        _playerController.Land.Jump.started -= Jump_started;
        _playerController.Land.Disable();
    }

    private void FixedUpdate()
    {
        Move(_moveDirection);
    }

    private void Move_peformed(InputAction.CallbackContext ctx)
    {
        _moveDirection = ctx.ReadValue<float>();
    }

    private void Move_canceled(InputAction.CallbackContext ctx)
    {
        _moveDirection = 0f;
    }

    private void Jump_started(InputAction.CallbackContext ctx)
    {
        Jump();
    }

    public virtual void Move(float direction)
    {
        _animator.SetBool("Run", direction != 0);

        if (direction == 0)
        {
            _rigidbody.velocity = new Vector2(0f, _rigidbody.velocity.y);

            return;
        }

        // Flip character graphics based on direction
        if (direction == 1)
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z));
        else if (direction == -1)
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z));

        // Walk by rigidbody
        _rigidbody.velocity = new Vector2(direction * MoveSpeed, _rigidbody.velocity.y);
    }

    public virtual void Jump()
    {
        Debug.Log("Jump 1");

        if (!GroundCheck()) return;

        Debug.Log("Jump 2");

        _rigidbody.AddForce(new Vector2(0f, JumpForce * 200f));
    }

    public bool GroundCheck()
    {
        float distance = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, Vector2.one, 0f, Vector2.down, distance, GroundLayer);

        return raycastHit.collider != null;
    }
}