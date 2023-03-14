using UnityEngine;
using Zenject;

public class SellFinalPointInstaller : MonoInstaller
{
    [SerializeField]
    private SellFinalPoint _finalPoint;
    public override void InstallBindings()
    {
        Container.Bind<ISellPoint>().To<SellFinalPoint>().FromInstance(_finalPoint).AsSingle().NonLazy();
    }
}