using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    private float elapsedTime;
    
    [SerializeField] private float _spawnTimeRange;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _prefab;
    
    void Start()
    {
        Initialize(_prefab);
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= _spawnTimeRange)
        {
            if (TryGetObject(out GameObject enemy))
            {
                elapsedTime = 0;
                var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
                SetEnemy(enemy, spawnPoint.position);
            }
        }
    }
    private void SetEnemy(GameObject enemy, Vector3 position)
    {
        enemy.SetActive(true);
        enemy.transform.position = position;
    }
}
