using UnityEngine;
using Zenject;

public class MainCameraInstaller : MonoInstaller
{
    [SerializeField]
    private MainCamera _mainCamera;
    public override void InstallBindings()
    {
        Container.Bind<MainCamera>().FromInstance(_mainCamera)
            .AsSingle().NonLazy();
    }
}