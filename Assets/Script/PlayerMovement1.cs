using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public new Animator animation;
    private PlayerController _playerController;
    private Rigidbody2D _rigidbody2D;

    private bool isGround;

    [SerializeField] private LayerMask _layerMask;

    private float speed = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        _playerController = new PlayerController();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _playerController.Land.Jump.performed += _ => Jump();
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() {
        var movementInput = _playerController.Land.Move.ReadValue<float>();
        Flip(movementInput);
        _rigidbody2D.velocity = new Vector2(movementInput * speed, 0f);
        
        animation.SetBool("Run", movementInput != 0);
    }

    private void Flip(float flip)
    {
        Vector3 scaleBefore = transform.localScale;
        if (flip < 0) transform.localScale = new Vector3(-Mathf.Abs(scaleBefore.x), scaleBefore.y, scaleBefore.z);
        else if (flip > 0) transform.localScale = new Vector3(Mathf.Abs(scaleBefore.x), scaleBefore.y, scaleBefore.z);
    }

    private void Jump()
    {
        if (isGround)
        {
            _rigidbody2D.AddForce(new Vector2(0f, 3000f));
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

    private void OnEnable()
    {
        _playerController.Enable();
    }

    private void OnDisable()
    {
        _playerController.Disable();
    }
}