using DG.Tweening;
using UnityEngine;
using Zenject;

public class FlyingCoin : MonoBehaviour
{
    [Inject]
    private GameConfigs _gameConfigs;
    [Inject]
    private CoinsCounter _coinsCounter;

    private RectTransform _rectTransform;
    private RectTransform _counterTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _counterTransform=_coinsCounter.GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        _rectTransform.DOMove(_counterTransform.position, _gameConfigs.MoneyMovingTime);
    }


}
