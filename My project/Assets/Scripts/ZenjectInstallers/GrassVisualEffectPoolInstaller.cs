using UnityEngine;
using Zenject;

public class GrassVisualEffectPoolInstaller : MonoInstaller
{
    [SerializeField]
    private GrassVisualEffectPool _visualEffectPool;
    public override void InstallBindings()
    {
        Container.Bind<GrassVisualEffectPool>().FromInstance(_visualEffectPool).AsSingle().NonLazy();
    }
}