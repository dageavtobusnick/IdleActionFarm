using System;
using UnityEngine;
using Zenject;

public class GrassStorage : MonoBehaviour, IGrassStorage
{
    [Inject]
    private PlayerConfigs _playerConfigs;

    private Transform _transform;
    private int _totalStorage;

    public Transform Transform { get => _transform; }
    public int TotalStorage { get => _totalStorage; }

    public bool IsEmpty => _totalStorage<=0;

    public bool IsFull => _totalStorage>=_playerConfigs.MaxStorage;

    public event Action<float> GrassCountChanged;

    public void CollectGrass()
    {
        if (_totalStorage <= _playerConfigs.MaxStorage)
        {
            _totalStorage++;
            GrassCountChanged?.Invoke(_totalStorage);
        }
    }

    public void SellGrass()
    {
        if(_totalStorage>0)
        {
            _totalStorage--;
            GrassCountChanged?.Invoke(_totalStorage);
        }
    }

    private void Awake()
    {
        _transform = transform;
    }
}
