using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private Car car;
    [SerializeField] private Road road;
    [SerializeField] private GameConfig config;
    [SerializeField] private RoadSegmentsPool.Settings roadPoolSettings;
    [SerializeField] private RoadContentFactory.Prefabs roadContentPrefabs;
    [SerializeField] private ZombiePool.Settings zombiePoolSettings;
    
    public override void InstallBindings()
    {
        Container.Bind<PoolGlobalParent>().FromNewComponentOnNewGameObject().AsCached();
        Container.Bind<GameConfig>().FromInstance(config).AsCached();
        Container.Bind<RoadSegmentsPool.Settings>().FromInstance(roadPoolSettings).AsCached();
        
        Container.Bind<Road>().FromInstance(road).AsCached();
        Container.Bind<RoadSegmentsPool>().FromNew().AsCached();
        Container.Bind<RoadSegmentsGenerator>().FromNew().AsCached();
        Container.Bind<RoadContentFactory>().FromNew().AsCached();
        Container.Bind<RoadContentFactory.Prefabs>().FromInstance(roadContentPrefabs).AsCached();
        
        Container.Bind<Car>().FromInstance(car).AsCached();
        
        Container.Bind<ZombiePool>().FromNew().AsCached();
        Container.Bind<ZombiePool.Settings>().FromInstance(zombiePoolSettings).AsCached();
        
        Container.BindInterfacesAndSelfTo<GameStateMachine>().FromNew().AsCached();
        Container.BindInterfacesAndSelfTo<GameInitState>().FromNew().AsCached();
        Container.BindInterfacesAndSelfTo<GameRunState>().FromNew().AsCached();
    }
}