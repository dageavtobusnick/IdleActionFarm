using UnityEngine;
using Zenject;

[RequireComponent(typeof(IGrassStorage))]
public class SellTimer : MonoBehaviour, ISellTimer, ITickable
{
    [Inject]
    private GameConfigs _gameConfigs;
    [Inject]
    private GrassCollectablePool _grassCollectablePool;
    [Inject]
    private Timer _timer;

    private IGrassStorage _grassStorage;
    private bool _isSelling;
    private float _time;
    private Transform _transform;
    private void Awake()
    {
        _grassStorage=GetComponent<IGrassStorage>();
        _transform = GetComponent<Transform>();
    }
    private void OnEnable()
    {
        _timer.Add(this);
    }
    private void OnDisable()
    {
        _timer.Remove(this);
    }
    public void StartTrySelling()
    {
        _isSelling=true;
        _time = 0;
    }

    public void StopTrySelling()
    {
        _isSelling = false;
    }

    public void Tick()
    {
        if(_isSelling)
        {
            _time += Time.deltaTime;
            if (_time >= _gameConfigs.TimeBetweenSelling)
            {
                _time = 0;
                if(_grassStorage.IsEmpty)
                {
                    _isSelling = false;
                    return;
                }
                _grassStorage.SellGrass();
                var sellObject=_grassCollectablePool.Take();
                sellObject.SetActive(true);
                sellObject.transform.position=_transform.position;
                if(sellObject.TryGetComponent<ISellable>(out var sellable))
                {
                    sellable.MoveToSell();
                }
            }
        }
    }
}
