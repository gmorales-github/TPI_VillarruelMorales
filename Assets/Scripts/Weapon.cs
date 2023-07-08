using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    private HealthComponent _owner;




    public void SetOwner(HealthComponent owner)
    {
        _owner = owner;
    }

    public void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = _bulletSpawnPoint.position;
        bullet.transform.rotation = _bulletSpawnPoint.rotation;
        bullet.GetComponent<Bullet>().SetOwner(_owner);        

    }
}
