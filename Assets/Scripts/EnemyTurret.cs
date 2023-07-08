using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private EnemyTargetComponent _targetComponent;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _timeBetweenShot;
    private float _currentTimeBetweenShot;
    private Vector2 _dirToPlayer;

    private void Awake()
    {
        _weapon.SetOwner(GetComponent<HealthComponent>());
    }

    private void Update()
    {
        if (_targetComponent.GetTarget() == null) return;
        _dirToPlayer = _targetComponent.GetTarget().position - transform.position;

        if (_dirToPlayer.magnitude < _attackRange)
        {
            Attack();
        }
    }

    private void Attack()
    {
        transform.up = _dirToPlayer;
        if (_currentTimeBetweenShot < 0)
        {
            _weapon.Shoot();
            _currentTimeBetweenShot = _timeBetweenShot;
        }
        else
        {
            _currentTimeBetweenShot -= Time.deltaTime;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}