using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Shoot Settings")]
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;
    [SerializeField] private Transform _target;

    [Header("Pool Settings")]
    [SerializeField] private PoolManager _poolManager;

    private GameObject _bullet;
    private float _timer;
    private BarController _barController;

    private void Start()
    {
        _barController = GetComponentInChildren<BarController>();
    }

    public void Update()
    {
        Shoot();
        _barController.FillAmount = _timer / _shootDelay;
    }

    private void Shoot()
    {
        if (_timer < _shootDelay)
        {
            _timer += Time.deltaTime;
            return;
        }

        _timer = 0;
        var direction = _target.transform.position - transform.position;
        direction.y = transform.position.y;

        var lookRotation = Quaternion.LookRotation(direction);

        _bullet = _poolManager.GetObject(_shootPoint.position, lookRotation);
    }

    private bool ShootCondition()
    {
        if (_target)
        {
            return !_bullet || _bullet.activeInHierarchy == false;
        }

        return false;
    }
}
