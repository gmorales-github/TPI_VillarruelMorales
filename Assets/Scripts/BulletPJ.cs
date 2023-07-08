using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPJ : MonoBehaviour
{
    public float lifetimer;

    public bool ownedByPlayer;

    [SerializeField] private int _damage;

    [SerializeField] public float _speed;

    private HealthComponent _ownerHealthComponent;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetimer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var healthComponent = collision.GetComponent<HealthComponent>();

        if (healthComponent && collision.gameObject.CompareTag("Enemy"))
        {
            if (healthComponent == _ownerHealthComponent)
            {
                
                return;
            }
            healthComponent.TakeDamageEnemy(_damage);
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * _speed * Time.deltaTime;
    }
}
