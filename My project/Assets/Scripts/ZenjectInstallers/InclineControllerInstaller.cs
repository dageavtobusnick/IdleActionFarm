using UnityEngine;
using Zenject;

public class InclineControllerInstaller : MonoInstaller
{
    [SerializeField]
    private InclineController _inclineController;
    public override void InstallBindings()
    {
        Container.Bind<IInclineController>().To<InclineController>()
            .FromInstance(_inclineController).AsSingle().NonLazy();
    }
}