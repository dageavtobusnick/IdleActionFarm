using UnityEngine;
using Zenject;

public class VisualEffectLifetime : MonoBehaviour, ITickable
{
    [SerializeField]
    private float _lifetime;

    [Inject]
    private Timer _timer;
    [Inject]
    private GrassVisualEffectPool _grassVisualEffectPool;

    private float _time;
    private bool _isTicking;

    private void OnEnable()
    {
        _timer.Add(this);
        _isTicking = true;
    }

    private void OnDisable()
    {
        _timer.Remove(this);
        _isTicking = false;
    }

    public void Tick()
    {
        if (_isTicking)
        {
            _time += Time.deltaTime;
            if(_time >= _lifetime)
            {
                _isTicking = false;
                _time = 0;
                _grassVisualEffectPool.Return(gameObject);
            }
        }
    }
}
