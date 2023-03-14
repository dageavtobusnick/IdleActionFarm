using UnityEngine;
using Zenject;

public class CoinsCounterInstaller : MonoInstaller
{
    [SerializeField]
    private CoinsCounter _coinsCounter;
    public override void InstallBindings()
    {
        Container.Bind<CoinsCounter>().FromInstance(_coinsCounter).AsSingle().NonLazy();
    }
}