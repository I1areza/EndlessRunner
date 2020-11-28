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
            _spawnedObjects.Add(obj);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _spawnedObjects.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
    
}
