using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public float maxDistance = 10f;
    public LayerMask target = 0;

    [SerializeField]
    private Rigidbody2D _rigidbody = null;
    [SerializeField]
    private UnityEvent _onTargetShooted = new UnityEvent();

    private Vector2 _initialPosition = Vector2.zero;

    public UnityEvent OnTargetShooted { get { return  _onTargetShooted; } }

    private void Update()
    {
        CheckMaxDistance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((target.value & (1 << collision.gameObject.layer)) <= 0) return;

        _onTargetShooted.Invoke();

        Destroy(gameObject);
    }

    public void Shoot(float speed)
    {
        if (_rigidbody == null) return;

        _initialPosition = transform.position;
        _rigidbody.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    private void CheckMaxDistance()
    {
        if (Vector2.Distance(transform.position, _initialPosition) < maxDistance) return;

        Destroy(gameObject);
    }
}
