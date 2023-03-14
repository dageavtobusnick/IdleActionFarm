using System;
using UnityEngine;
using UnityEngine.VFX;
using Zenject;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(IGrassGrow))]
public class Grass : MonoBehaviour,IGrass
{
    [SerializeField]
    private GameObject _fullModel;
    [SerializeField]
    private GameObject _upperModel;
    [SerializeField]
    private GameObject _lowerModel;
    [SerializeField]
    private Vector3 _upperGrassOfset;

    [Inject]
    private GrassVisualEffectPool _effectPool;

    private Collider _collider;
    private IGrassGrow _grown;
    private Transform _transform;

    public event Action GrassBevelled;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _grown = GetComponent<IGrassGrow>();
        _transform = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerWeapon>(out var _))
        {
            GrassBevelled?.Invoke();
            _fullModel?.SetActive(false);
            _upperModel?.SetActive(true);
            _upperModel.transform.localPosition = _upperGrassOfset;
            var effect = _effectPool.Take();
            effect.SetActive(true);
            effect.transform.position=_transform.position;
            if(effect.TryGetComponent<GrassVisualEffect>(out var visualEffect))
            {
                visualEffect.RestartEffect();
            }
            _lowerModel?.SetActive(true);
            _collider.enabled = false;
        }
    }

    private void OnEnable()
    {
        _grown.GrassGrowned += OnGrassGrown;
        GrassBevelled += _grown.OnGrassBevelled;
    }

    private void OnDisable()
    {
        _grown.GrassGrowned -= OnGrassGrown;
        GrassBevelled -= _grown.OnGrassBevelled;
    }
    private void OnGrassGrown()
    {
        _fullModel?.SetActive(true);
        _lowerModel?.SetActive(false);
        _collider.enabled = true;
    }
}
