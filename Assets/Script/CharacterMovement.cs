using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Properties")]
    public float MoveSpeed = 10f;
    public float JumpForce = 10f;
    public LayerMask GroundLayer;

    [Header("References")]
    //[SerializeField] private Transform _graphics = null;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private Rigidbody2D _rigidbody = null;

    public virtual void Move(float direction)
    {
        if (_animator != null)
            _animator.SetBool("Run", direction != 0);

        if (direction == 0)
        {
            _rigidbody.velocity = new Vector2(0f, _rigidbody.velocity.y);

            return;
        }

        // Flip character graphics based on direction
        Vector3 euler = transform.eulerAngles;
        if (direction == 1)
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z));
        else if (direction == -1)
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z));

        // Walk by rigidbody
        _rigidbody.velocity = new Vector2(direction * MoveSpeed, _rigidbody.velocity.y);
    }

    public virtual void Jump()
    {
        if (!GroundCheck()) return;

        _rigidbody.AddForce(new Vector2(0f, JumpForce * 200f));
    }

    public bool GroundCheck()
    {
        float distance = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, Vector2.one, 0f, Vector2.down, distance, GroundLayer);

        return raycastHit.collider != null;
    }
}
