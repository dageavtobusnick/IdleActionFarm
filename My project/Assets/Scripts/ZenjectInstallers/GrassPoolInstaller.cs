using UnityEngine;
using Zenject;

public class GrassPoolInstaller : MonoInstaller
{
    [SerializeField]
    private GrassCollectablePool _pool;
    public override void InstallBindings()
    {
        Container.Bind<GrassCollectablePool>().FromInstance(_pool).AsSingle().NonLazy();
    }
}