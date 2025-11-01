using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMovement : MonoBehaviour, IControllable
{
    [SerializeField] private float _speed;
    private Rigidbody _rb;
    private Vector3 _direction;
    
    public float DirectionSqrMagnitude => _direction.sqrMagnitude;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        RotateAlongMoveDirection();
    }

    private void FixedUpdate() 
    {
        MoveInternal();
    }

    public void Move(Vector3 direction)
    {
        _direction = direction;
    }

    private void MoveInternal()
    {
        var velocity = _direction * _speed;
        velocity.y = _rb.linearVelocity.y;
        _rb.linearVelocity = velocity;
    }

    private void RotateAlongMoveDirection()
    {
        if (_direction.sqrMagnitude != 0f)
            transform.LookAt(transform.position + _direction);
    }
}
