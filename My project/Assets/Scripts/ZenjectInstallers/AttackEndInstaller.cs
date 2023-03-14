using UnityEngine;
using Zenject;

public class AttackEndInstaller : MonoInstaller
{
    [SerializeField]
    private AttackEnd _attackEnd;
    public override void InstallBindings()
    {
        Container.Bind<IAttackEnd>().To<AttackEnd>()
            .FromInstance(_attackEnd).AsSingle().NonLazy();
    }
}