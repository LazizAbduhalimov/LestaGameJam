using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private RigidbodyMovement _moveController;
    private Animator _animator;

    private void Awake() 
    {
        _moveController = GetComponent<RigidbodyMovement>();   
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update() 
    {
        _animator.SetFloat("Speed", _moveController.DirectionSqrMagnitude);
    }
}