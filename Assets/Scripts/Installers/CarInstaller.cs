using UnityEngine;
using Zenject;

public class CarInstaller : MonoInstaller
{
    [SerializeField] private Car car;
    [SerializeField] private CarMonos carMonos;
    [SerializeField] private CarFuel.Settings carFuelSettings;
    
    public override void InstallBindings()
    {
        Container.Bind<Car>().FromInstance(car).AsCached();
        Container.Bind<CarMonos>().FromInstance(carMonos).AsCached();
        Container.Bind<CarFuel.Settings>().FromInstance(carFuelSettings).AsCached();
        
        Container.BindInterfacesAndSelfTo<CarLogicLoop>().FromNew().AsCached();
        Container.Bind<CarInput>().FromNew().AsCached();
        Container.Bind<CarStatsHolder>().FromNew().AsCached();
        Container.Bind<CarViewHolder>().FromNew().AsCached();
        Container.Bind<CarFuel>().FromNew().AsCached();
    }
}