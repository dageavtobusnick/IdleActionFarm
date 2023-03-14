using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(IGrassStorage))]
public class GrassStorageVisualize : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _hays;

    [Inject]
    private PlayerConfigs _playerConfigs;

    private IGrassStorage _grassStorage;

    private void Awake()
    {
        _grassStorage = GetComponent<GrassStorage>();
    }

    private void OnEnable()
    {
        _grassStorage.GrassCountChanged += OnGrassCountChanged;
    }

    private void OnDisable()
    {
        _grassStorage.GrassCountChanged -= OnGrassCountChanged;
    }

    private void OnGrassCountChanged(float count)
    {
        var haysCount = Mathf.CeilToInt(count / _playerConfigs.MaxStorage * _hays.Count);
        for(int i = 0; i < _hays.Count; i++)
        {
            _hays[i].SetActive(i<haysCount);
        }
    }
}
