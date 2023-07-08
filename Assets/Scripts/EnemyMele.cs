using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMele : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _detectionRange;
    [SerializeField] private EnemyTargetComponent _targetComponent;
    private Vector2 _dirToPlayer;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_targetComponent.GetTarget() == null)
        {
            Stop();
            return;
        }
        _dirToPlayer = _targetComponent.GetTarget().position - transform.position;
        if (_dirToPlayer.magnitude < _detectionRange)
        {
            Chase();
        }
        else
        {
            Stop();
        }
    }
    private void Stop()
    {
        _rb.velocity = Vector2.zero;
    }
    private void Chase()
    {
        _rb.velocity = _dirToPlayer.normalized * _speed;
        transform.up = _dirToPlayer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.GetComponent<HealthComponent>().TakeDamagePJ(_damage);
            player.rb.AddForce(_dirToPlayer.normalized * 1200, ForceMode2D.Force);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _detectionRange);
    }
}
