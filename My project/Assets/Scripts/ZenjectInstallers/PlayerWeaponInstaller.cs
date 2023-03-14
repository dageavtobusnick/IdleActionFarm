using UnityEngine;
using Zenject;

public class PlayerWeaponInstaller : MonoInstaller
{
    [SerializeField]
    private PlayerWeapon _playerWeapon;
    public override void InstallBindings()
    {
        Container.Bind<PlayerWeapon>().FromInstance(_playerWeapon).AsSingle().NonLazy();
    }
}