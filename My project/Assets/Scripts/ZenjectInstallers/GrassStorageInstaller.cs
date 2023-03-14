using UnityEngine;
using Zenject;

public class GrassStorageInstaller : MonoInstaller
{
    [SerializeField]
    private GrassStorage _grassStorage;
    public override void InstallBindings()
    {
        Container.Bind<IGrassStorage>().To<GrassStorage>().FromInstance(_grassStorage).AsSingle().NonLazy();
    }
}