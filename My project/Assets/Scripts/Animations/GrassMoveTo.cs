using DG.Tweening;
using UnityEngine;
using Zenject;

public class GrassMoveTo : MonoBehaviour,IStoragable,ISellable
{
    [Inject]
    private IGrassStorage _grassStorage;
    [Inject]
    private GameConfigs _gameConfigs;
    [Inject]
    private ISellPoint _sellPoint;

    private Transform _transform;
    private Transform _storagePos;
    private bool _isStoragable;

    public bool IsStoragable => _isStoragable;

    public void Awake()
    {
        _transform = transform;
        _storagePos = _grassStorage.Transform;
    }

    public void MoveToSell()
    {
        _transform.DOMove(_sellPoint.Transform.position,_gameConfigs.GrassMoveToTargetTime);
        _isStoragable = false;
    }

    public void MoveToStorage()
    {
        _transform.DOMove(_storagePos.position, _gameConfigs.GrassMoveToTargetTime);
        _isStoragable = true;
    }

}
