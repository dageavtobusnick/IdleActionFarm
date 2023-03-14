using UnityEngine;
using Zenject;

public class GrassObjectInstallerInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _grassCollectablePrefab;
    public override void InstallBindings()
    {

        Container.Bind<GrassCollectable>().FromComponentsInNewPrefab(_grassCollectablePrefab).AsSingle().NonLazy();
    }
}