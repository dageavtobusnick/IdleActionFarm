using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    private T _poolObject;
    private Transform _transform;
    private HashSet<GameObject> _freeObjects;

    private void Awake()
    {
        _transform = transform;
        _freeObjects = new HashSet<GameObject>();
        _poolObject.gameObject.SetActive(false);
    }

    private void Start()
    {
        foreach (var e in GetComponentsInChildren<T>())
        {
            _freeObjects.Add(e.gameObject);
            e.gameObject.SetActive(false);
        }
    }
    public GameObject Take()
    {
        if (_freeObjects.Count == 0)
            Spawn();
        var takedObject = _freeObjects.First();
        _freeObjects.Remove(takedObject);
        return takedObject;
    }

    private void Spawn()
    {
        var spawnedObject = Instantiate(_poolObject, _transform);
        spawnedObject.gameObject.SetActive(false);
        _freeObjects.Add(spawnedObject.gameObject);
    }

    public void Return(GameObject gameObject)
    {
        gameObject.gameObject.SetActive(false);
        _freeObjects.Add(gameObject);
    }
}
