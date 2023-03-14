using UnityEngine;
using Zenject;

public class PlayerAnimatorStateInstaller : MonoInstaller
{
    [SerializeField]
    private PlayerAnimatorState _playerAnimatorState;
    public override void InstallBindings()
    {
        Container.Bind<IPlayerAnimatorState>().To<PlayerAnimatorState>()
                 .FromInstance(_playerAnimatorState).AsSingle().NonLazy();
    }
}