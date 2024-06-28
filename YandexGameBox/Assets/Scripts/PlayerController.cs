using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject playerCamera;
    public int jumpForce;

    private PlayerControls _playerControls;
    private Rigidbody _rb;
    private Vector2 _moveVector2;
    private Vector3 _spawnDirection;
    private float _speed;
    private bool _isGrounded;
    private bool _notObstacle;
    private int _deadPosY;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _rb = GetComponent<Rigidbody>();
        _notObstacle = true;
        _deadPosY = 250;
        _spawnDirection = transform.position;
        
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
        if (_notObstacle)
            _rb.MovePosition(transform.position + (transform.forward * _speed + transform.right * _moveVector2.x * 6) * Time.deltaTime);
        if (transform.position.y < _deadPosY)
            transform.position = _spawnDirection;
        Control();
        Jump();
    }

    private void LateUpdate()
    {
        playerCamera.transform.position = transform.position;
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
            StartCoroutine(Respawn(1f));
        }                
    }
    public void OnEnable()
    {
        _playerControls.Enable();
    }

    public void OnDisable()
    {
        _playerControls.Disable();
    }

    private void Jump()
    {
        if (_isGrounded & _playerControls.Player.Jump.IsPressed())
        {
            _isGrounded = false;
            _rb.AddForce(transform.up * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
        }            
    }

    private void Control()
    {

    }

    private IEnumerator Respawn(float time)
    {
        _notObstacle = false;
        OnDisable();
        yield return new WaitForSeconds(time);
        OnEnable();
        transform.position = _spawnDirection;
        _notObstacle = true;
    }

    public void ChangeSpawnDirection(Vector3 spawn)
    {
        _spawnDirection = spawn;
    }

    public void ChangeDeadPosY(int i)
    {
        _deadPosY = i;
    }

}
