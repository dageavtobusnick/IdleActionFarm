using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Material))]
public class GrassCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private string _materialParametrName;

    [Inject]
    private IGrassStorage _storage;
    [Inject]
    private PlayerConfigs _playerConfigs;

    private Material _material;

    private void Awake()
    {
        _storage.GrassCountChanged += OnGrassCountChanged;
        _material=GetComponent<RawImage>().material;
        _material.SetFloat(_materialParametrName, 0);
    }


    private void OnGrassCountChanged(float _totalCount)
    {
        _text.text = $"{(int)_totalCount}\r\n—\r\n{_playerConfigs.MaxStorage}";
        _material.SetFloat(_materialParametrName, _totalCount/_playerConfigs.MaxStorage);
    }


}
