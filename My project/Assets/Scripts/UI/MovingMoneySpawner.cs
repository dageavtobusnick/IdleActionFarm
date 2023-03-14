using UnityEngine;
using Zenject;

[RequireComponent (typeof(Canvas))]
public class MovingMoneySpawner : MonoBehaviour,IMovingMoneySpawner
{
    [Inject]
    private MainCamera _mainCamera;
    [Inject]
    private CoinsPool _coinsPool;

    private Canvas _canvas;
    private Camera _camera;

    private void Awake()
    {
        _camera=_mainCamera.GetComponent<Camera>();
        _canvas = GetComponent<Canvas>();
    }

    public void SpawnMoney(Vector3 position)
    {
        var positionOnCanvas=_canvas.WorldToCanvasPosition(_camera, position);
        var coin = _coinsPool.Take();
        coin.SetActive(true);
        coin.GetComponent<RectTransform>().anchoredPosition = positionOnCanvas;
    }

}
