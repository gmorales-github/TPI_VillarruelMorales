using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float _speed;
    [SerializeField]private float _timeBetweenShot;
    [SerializeField]private float _detectionRange;
    [SerializeField]private float _attackRange;
    private float _currentTimeBetweenShot;
    [SerializeField]private Weapon _weapon;
    private Player _player;
    private Rigidbody2D _rb;
    private Vector2 _dirToPlayer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (_player == null)
        {
            return;
        }
        _dirToPlayer = _player.transform.position - transform.position;
        //Chase();

        if (_dirToPlayer.magnitude < _attackRange)
        {
            Attack();
        }
        else if (_dirToPlayer.magnitude < _detectionRange)
        {
            Chase();
        }
        else
        {
            Idle();
        }
    }

    public void SetTarget(Player player)
    {
        _player = player;
    }
    private void Idle()
    {
        _rb.velocity = Vector2.zero;
    }

    private void Chase()
    {
        _rb.velocity = _dirToPlayer.normalized * _speed;
        transform.up = _dirToPlayer;
    }

    private void Attack()
    {
        _rb.velocity = Vector2.zero;
        transform.up = _dirToPlayer;
        if (_currentTimeBetweenShot < _timeBetweenShot)
        {
            _currentTimeBetweenShot += Time.deltaTime;
        }
        else
        {
            _weapon.Shoot();
            _currentTimeBetweenShot = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _detectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}