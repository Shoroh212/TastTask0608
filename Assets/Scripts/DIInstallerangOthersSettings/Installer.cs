using UnityEngine;
using Zenject;

public class Installer :MonoInstaller
{
    public override void InstallBindings()  // инсталлер для внедрения зависимостей 
    {

        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<CardSelectedSignal>();

        Container.Bind<ICardReceiver>()
            .To<InfoPanel>()
            .FromComponentInHierarchy()
            .AsSingle();

      

    }
}
