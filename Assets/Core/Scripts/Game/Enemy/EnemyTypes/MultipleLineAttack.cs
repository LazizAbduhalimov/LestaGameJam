using PoolSystem.Alternative;
using System.Collections;
using UnityEngine;

[SelectionBase]
public class MultipleLineAttack : AttackBase
{
    [Header("Spread settings")]
    [Tooltip("Total spread angle in degrees (0..spread). Example: 45 yields lines at 0,22.5,45 when lines=3)")]
    [SerializeField] private float _spreadAngle = 45f;
    [Tooltip("Number of rays/lines to spawn inside the spread (>=1)")]
    [SerializeField] private int _lines = 3;

    [Header("Queue / timing")]
    [Tooltip("How many times the full set of lines will be fired in a row")]
    [SerializeField] private int _queues = 1;
    [Tooltip("Seconds between repeated queues")]
    [SerializeField] private float _timeBetweenQueues = 0.2f;

    [Header("Pool / spawn")]
    [SerializeField] private Transform _bulletCreateTransform;
    [SerializeField] private PoolContainer _bulletsPoolData;

    private bool _isAttacking;

    private void Update()
    {
        // Let base TryAttack() manage PassedAttackTime and firing timing.
        RefreshReloadBar();
        TryAttack();
    }

    protected override void Attack()
    {
        // Start firing the configured spread queues
        if (!_isAttacking)
            StartCoroutine(FireQueues());
    }

    private IEnumerator FireQueues()
    {
        _isAttacking = true;

        for (int q = 0; q < Mathf.Max(1, _queues); q++)
        {
            FireLines();
            if (q < _queues - 1)
                yield return new WaitForSeconds(_timeBetweenQueues);
        }

        _isAttacking = false;
        // Reset cooldown so AttackBase can manage next attack (optional behaviour)
        PassedAttackTime = 0f;
    }

    private void FireLines()
    {
        int linesCount = Mathf.Max(1, _lines);
        // Center the spread around forward: start = -spread/2, end = +spread/2
        float start = -_spreadAngle * 0.5f;
        float step = (linesCount > 1) ? _spreadAngle / (linesCount - 1) : 0f;

        for (int i = 0; i < linesCount; i++)
        {
            float angle = start + i * step; // -spread/2 .. +spread/2
            var rot = transform.rotation * Quaternion.Euler(0f, angle, 0f);
            CreateBullet(_bulletCreateTransform != null ? _bulletCreateTransform.position : transform.position, rot);
        }
    }

    private void CreateBullet(Vector3 position, Quaternion rotation)
    {
        if (_bulletsPoolData == null)
            return;

        var bullet = _bulletsPoolData.Pool.GetFreeElement(false);
        bullet.transform.SetPositionAndRotation(position, rotation);
        bullet.gameObject.SetActive(true);
    }
}