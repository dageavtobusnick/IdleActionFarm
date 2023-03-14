using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerConfigsInstaller", menuName = "Installers/PlayerConfigsInstaller")]
public class PlayerConfigsInstaller : ScriptableObjectInstaller<PlayerConfigsInstaller>
{
    [SerializeField]
    private PlayerConfigs _playerConfigs;
    public override void InstallBindings()
    {
        Container.Bind<PlayerConfigs>().FromScriptableObject(_playerConfigs).AsSingle().NonLazy();
    }
}