using Trader;
using Zenject;
using Entities.Vegetable;

public class Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .BindInterfacesTo<VegetableRepository>()
            .AsSingle();
        
        Container
            .BindInterfacesTo<UpgradeRepository>()
            .AsSingle();
    }
}