using UnityEngine;
using Zenject;

[RequireComponent (typeof(IStoragable))]
public class GrassCollectable : MonoBehaviour
{
    [Inject]
    private GrassCollectablePool _pool;

    private IStoragable _storagable;

    private void Awake()
    {
        _storagable=GetComponent<IStoragable>();
    }

    private void OnTriggerEnter(Collider other)
    {
       if(_storagable.IsStoragable&&other.TryGetComponent<IGrassStorage>(out var storage)&&!storage.IsFull)
        {
            storage.CollectGrass();
            _pool.Return(gameObject);
        }
    }
}
