using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [Inject]
    private GameConfigs _gameConfigs;
    [Inject]
    private CoinsPool _coinsPool;
    [Inject]
    private IWallet _wallet;

    private int _coinsPackCount;
    private bool _animate;
    private RectTransform _transform;

    private void Awake()
    {
        _transform=GetComponent<RectTransform>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<FlyingCoin>(out var coin))
        {
            _coinsPackCount++;
            _coinsPool.Return(coin.gameObject);
            if (!_animate)
            {
                StartCoroutine(Animate());
            }
        }
    }
    IEnumerator Animate()
    {
        _animate = true;
        while (_coinsPackCount > 0)
        {
            var time = _gameConfigs.MoneyCollectedShakeTime / _gameConfigs.GrassCost;
            _transform.DOShakePosition(_gameConfigs.MoneyCollectedShakeTime,_gameConfigs.ShakeStrength);
            for(var i=0; i < _gameConfigs.GrassCost; i++)
            {
                _wallet.AddMoney(1);
                _text.text = _wallet.Money.ToString();
                yield return new WaitForSeconds(time);
            }
            _coinsPackCount--;
        }
        _animate = false;
        StopCoroutine(Animate());
    }
}
