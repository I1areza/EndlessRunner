using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _objectQty;

    private List<GameObject> _spawnedObjects = new List<GameObject>();


    protected void Initialize(GameObject gameObject)
    {
        for (int i = 0; i < _objectQty; i++)
        {
            var obj = Instantiate(gameObject, _container.transform);
            obj.SetActive(false);
            _spawnedObjects.Add(obj);
            
        }
    }
    
    protected void Initialize(GameObject[] gameObject)
    {
        for (int i = 0; i < _objectQty; i++)
        {
            int randIndex = Random.Range(0, gameObject.Length);
            var obj = Instantiate(gameObject[randIndex], _container.transform);
            obj.SetActive(false);
            _spawnedObjects.Add(obj);
            
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _spawnedObjects.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
    
}
