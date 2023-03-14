using UnityEngine;
using Zenject;

public class UpperGrassTransformation : MonoBehaviour,ITickable
{
    [SerializeField]
    private Vector3 _spawnedGrassOfset;
    [Inject]
    private GrassCollectablePool _grassPool;
    [Inject]
    private Timer _timer;
    [Inject]
    private GameConfigs _gameConfigs;
    [Inject]
    private IGrassStorage _grassStorage;

    private bool _isTicsking;
    private Transform _transform;
    private float _time;

    private void Awake()
    {
        _transform = transform;
    }

    public void Tick()
    {
        if (_isTicsking)
        {
            _time += Time.deltaTime;
            if(_time>=_gameConfigs.GrassDeatroyTime) 
            { 
                _isTicsking = false;
                var hay = _grassPool.Take();
                hay.transform.position=_transform.position+_spawnedGrassOfset;
                hay.SetActive(true);
                if(hay.TryGetComponent<IStoragable>(out var storagable)&&!_grassStorage.IsFull)
                {
                    storagable.MoveToStorage();
                }
                gameObject.SetActive(false);
            }
        }
    
    }

    private void OnEnable()
    {
        _timer.Add(this);
        _isTicsking = true;
        _time = 0f;
    }

    private void OnDisable()
    {
        _timer.Remove(this);
        _isTicsking = false;
    }
}
