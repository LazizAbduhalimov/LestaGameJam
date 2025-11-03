using PoolSystem.Alternative;
using UnityEngine;

[SelectionBase]
public class TurretAttack : AttackBase
{
    [SerializeField] private int _bulletNumber = 1;
    [SerializeField] private float _timeBtwAttack = 0.2f;
    [SerializeField] private float _bulletSpeed = 8;
    [SerializeField] private Transform _bulletCreateTransform;
    [SerializeField] private PoolContainer _bulletsPoolData;
    
    private BarController _barController;
    
    private bool _isAttacking;
    private float _passedTimeBtwAttack;
    private int _bulletsCreatedWhileAttacking;

    private void Start()
    {
        _passedTimeBtwAttack = _timeBtwAttack;
    }

    private void Update()
    {
        if (!_isAttacking)
            PassedAttackTime += Time.deltaTime;
        
        RefreshReloadBar();
        TryAttack();
    }

    protected override void Attack()
    {
        CreateBullet(_bulletCreateTransform.position, transform.rotation);
    }

    private bool TryAttack()
    {
        if (PassedAttackTime < AttackRate && !_isAttacking)
            return false;

        _isAttacking = true;

        _passedTimeBtwAttack += Time.deltaTime;
        if (_passedTimeBtwAttack >= _timeBtwAttack)
        {
            Attack();
            _bulletsCreatedWhileAttacking++;
            _passedTimeBtwAttack -= _timeBtwAttack;
            PassedAttackTime -= AttackRate / _bulletNumber;

            if (_bulletsCreatedWhileAttacking >= _bulletNumber)
            {
                _passedTimeBtwAttack = _timeBtwAttack;
                _bulletsCreatedWhileAttacking = 0;
                _isAttacking = false;
            }
        }
        return true;
    }

    private void CreateBullet(Vector3 position, Quaternion rotation)
    {
        var bullet = _bulletsPoolData.Pool.GetFreeElement(false);
        var bulletComp = bullet.GetComponent<EnemyBullet>();
        bulletComp.Initialize(_bulletSpeed, 15, 3);
        bullet.transform.SetPositionAndRotation(position, rotation);
        bullet.gameObject.SetActive(true);
    }
}