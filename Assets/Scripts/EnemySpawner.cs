using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _maxSpawn;
    [SerializeField] private int _maxCount;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private Transform _enemyContainer;
    [SerializeField] private Transform _spawnPointsContainer;
    private float _currentTimeToSpawn;
    private Transform[] _spawnPoints;
    private int _spawnedCount;

    private void Awake()
    {
        _spawnPoints = new Transform[_spawnPointsContainer.childCount];
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = _spawnPointsContainer.GetChild(i);
        }
    }

    private void Update()
    {
        if (_currentTimeToSpawn > 0)
        {
            _currentTimeToSpawn -= Time.deltaTime;
        }
        else
        {
            _currentTimeToSpawn = _timeToSpawn;
            Spawn();
        }
    }

    public void Spawn()
    {
        if (_spawnedCount >= _maxSpawn)
        {
            return;
        }
        if (_enemyContainer.childCount < _maxCount)
        {
            var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            var enemy = Instantiate(
                _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)], 
                spawnPoint.position, 
                Quaternion.Euler(0, 0, Random.Range(0, 360)), 
                _enemyContainer);
            enemy.GetComponent<EnemyTargetComponent>().SetTarget(_player.transform);
            _spawnedCount++;
        }
    }

    public bool GetComplete()
    {
        return _spawnedCount >= _maxSpawn && _enemyContainer.childCount == 0;
    }
}
