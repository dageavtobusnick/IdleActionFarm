using System;
using UnityEngine;
using Zenject;

public class GrassGrow : MonoBehaviour, IGrassGrow, ITickable
{
    [Inject]
    private GameConfigs _gameConfig;
    [Inject]
    private Timer _timer;

    private bool _isGrassGrowing;
    private float _growTime;

    public event Action GrassGrowned;


    private void OnEnable()
    {
        _timer.Add(this);
    }

    private void OnDisable()
    {
        _timer.Remove(this);
    }

    public void OnGrassBevelled()
    {
        _isGrassGrowing = true;
    }

    public void Tick()
    {
        if (_isGrassGrowing)
        {
            _growTime += Time.deltaTime;
            if(_growTime>=_gameConfig.GrassGrownTime)
            {
                _isGrassGrowing = false;
                GrassGrowned?.Invoke();
                _growTime = 0;
            }
        }
    }
}
