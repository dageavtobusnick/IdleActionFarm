using UnityEngine;
using Zenject;

public class FlyinMoneySpawnerInstaller : MonoInstaller
{
    [SerializeField]
    private MovingMoneySpawner _movingMoneySpawner;
    public override void InstallBindings()
    {
        Container.Bind<IMovingMoneySpawner>().To<MovingMoneySpawner>().FromInstance(_movingMoneySpawner).AsSingle().NonLazy();
    }
}