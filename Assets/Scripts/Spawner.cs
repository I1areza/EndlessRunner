using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnTimeRange;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _prefab;

    private float elapsedTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= _spawnTimeRange)
        {
            elapsedTime = 0;
            var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Instantiate(_prefab, spawnPoint.transform);
        }
    }
}
