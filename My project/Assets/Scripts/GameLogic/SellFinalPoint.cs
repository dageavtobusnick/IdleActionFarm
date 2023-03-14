using UnityEngine;
using Zenject;

public class SellFinalPoint : MonoBehaviour,ISellPoint
{
    [Inject]
    private GrassCollectablePool _pool;
    [Inject]
    private IMovingMoneySpawner _spawner;

    private Transform _transform;
    public Transform Transform => _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<GrassCollectable>(out var collectable))
        {
            _pool.Return(collectable.gameObject);
            _spawner.SpawnMoney(_transform.position);
        }
    }

}
