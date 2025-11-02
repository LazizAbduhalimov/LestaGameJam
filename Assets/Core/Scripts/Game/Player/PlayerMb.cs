using PrimeTween;
using UnityEngine;

public class PlayerMb : MonoBehaviour
{
    [SerializeField] private float _stunDuration;
    private InputController _inputController;

    private void Start()
    {
        _inputController = GetComponent<InputController>();
    } 

    public void Stun()
    {
        // _inputController.IsStunned = true;
        // Tween.Delay(_stunDuration, () => {_inputController.IsStunned = false;});
    }
}