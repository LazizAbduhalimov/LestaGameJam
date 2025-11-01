using UnityEngine;

[RequireComponent(typeof(IControllable))]
public class InputController: MonoBehaviour
{
    private IControllable _controllable;
    private Camera _mainCamera;

    private void Start()
    {
        _controllable = GetComponent<IControllable>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var cameraForward = _mainCamera.transform.forward.normalized;
        var cameraRight = _mainCamera.transform.right.normalized;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        var direction = (cameraForward * vertical + cameraRight * horizontal).normalized;
        _controllable.Move(direction);
    }
}
