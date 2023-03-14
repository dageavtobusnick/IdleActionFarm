using UnityEngine;
using Zenject;

public class WalletInstaller : MonoInstaller
{
    [SerializeField]
    private Wallet _wallet;
    public override void InstallBindings()
    {
        Container.Bind<IWallet>().To<Wallet>().FromInstance(_wallet).AsSingle().NonLazy();
    }
}