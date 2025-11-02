using UnityEngine;

public class AssBox : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _playerBody;


    [SerializeField] private float _rotationCoefficient = 5f;

    private void Update()
    {
        if (_playerTransform == null || _playerBody == null) return;

        Vector3 relativePosition = _playerTransform.InverseTransformPoint(transform.position);

        _playerBody.localEulerAngles = new Vector3(relativePosition.z, 0, -relativePosition.x) * _rotationCoefficient;
    }
}
