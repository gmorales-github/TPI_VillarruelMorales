using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] public float _speed;
    private HealthComponent _ownerHealthComponent;

    private void OnEnable()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.position += transform.up * (Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var healthComponent = collision.GetComponent<HealthComponent>();

        if (healthComponent)
        {
            if (healthComponent == _ownerHealthComponent)
            {
                return;
                
            }
            healthComponent.TakeDamagePJ(_damage);
        }
        Destroy(gameObject);
    }

    public void SetOwner(HealthComponent ownerHealthComponent)
    {
        _ownerHealthComponent = ownerHealthComponent;
    }
}