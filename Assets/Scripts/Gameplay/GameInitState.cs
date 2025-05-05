public class GameInitState : IState
{
    private IStateMachine stateMachine;
    private Road road;
    private Car car;
    private GameConfig config;
    private RoadSegmentsGenerator roadGenerator;
    
    public GameInitState(Road road, Car car, RoadSegmentsGenerator roadGenerator,  GameConfig config)
    {
        this.road = road;
        this.car = car;
        this.config = config;
        this.roadGenerator = roadGenerator;
    }
    
    public void SetStateMachine(IStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        GenerateStartRoad();
        SetupCar();
        
        stateMachine.SwitchState<GameRunState>();
    }

    private void GenerateStartRoad()
    {
        foreach (var start in config.StartTemplates)
        {
            var startSegment = roadGenerator.Generate(start);
            road.AddSegmentToEnd(startSegment);
        }
    }

    private void SetupCar()
    {
        car.SetCarData(config.DefaultCarData);
        car.Activate();
    }

    public void Update()
    {
        
    }

    public void FixedUpdate()
    {
        
    }

    public void Exit()
    {
        
    }
}