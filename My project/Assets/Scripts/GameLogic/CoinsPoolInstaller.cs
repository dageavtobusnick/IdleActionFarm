using UnityEngine;
using Zenject;

public class CoinsPoolInstaller : MonoInstaller
{
    [SerializeField]
    private CoinsPool _coinsPool;
    public override void InstallBindings()
    {
        Container.Bind<CoinsPool>().FromInstance(_coinsPool).AsSingle().NonLazy();
    }
}