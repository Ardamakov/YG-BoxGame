using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int jumpForce;

    private PlayerControls _playerControls;
    private Rigidbody _rb;
    private Animator _playerAnimator;
    private Vector2 _moveVector2;
    private float _speed;
    private bool _isGrounded;
    private bool _isControl;
    private bool _notObstacle;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _rb = GetComponent<Rigidbody>();
        _notObstacle = true;
        _playerAnimator = GetComponent<Animator>();
        OnEnable();
    }

    private void Update()
    {
        _moveVector2 = _playerControls.Player.Move.ReadValue<Vector2>();
        
        if (_moveVector2.y > 0)
            _speed = 8f;
        else if (_moveVector2.y < 0)
            _speed = 4f;
        else
            _speed = 6f;
    }

    private void FixedUpdate()
    {  
        Control();
        Jump();
        if (_notObstacle)
            _rb.MovePosition(transform.position + (transform.forward * _speed + transform.right * _moveVector2.x * 6) * Time.deltaTime);
    }

    private void Jump()
    {
        if (_isGrounded & _playerControls.Player.Jump.IsPressed())
        {
            _isGrounded = false;
            _rb.AddForce(transform.up * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);

            if (_playerAnimator.GetBool("isJump") == false)
                _playerAnimator.SetBool("isJump", true);
        }
        else
            _playerAnimator.SetBool("isJump", false);
    }

    private void Control()
    {
        if (_playerControls.Player.Control.IsPressed())
            _playerAnimator.SetBool("isControl", true);
        else
            _playerAnimator.SetBool("isControl", false);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            _isGrounded = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _notObstacle = false;
            OnDisable();
        }            
            
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
