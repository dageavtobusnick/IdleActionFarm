using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameConfigsInstaller", menuName = "Installers/GameConfigsInstaller")]
public class GameConfigsInstaller : ScriptableObjectInstaller<GameConfigsInstaller>
{
    [SerializeField]
    private GameConfigs _gameConfigs;
    public override void InstallBindings()
    {
        Container.Bind<GameConfigs>().FromScriptableObject(_gameConfigs).AsSingle().NonLazy();
    }
}