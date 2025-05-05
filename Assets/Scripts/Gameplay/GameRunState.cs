using System;
using UniRx;
using UnityEngine;

public class GameRunState : IState
{
    private Car car;
    private Road road;
    private GameConfig config;
    private RoadSegmentsGenerator roadSegmentsGenerator;
    private IStateMachine stateMachine;

    private IDisposable roadUpdater;
    
    public GameRunState(Road road, Car car, GameConfig config, RoadSegmentsGenerator roadSegmentsGenerator)
    {
        this.road = road;
        this.car = car;
        this.config = config;
        this.roadSegmentsGenerator = roadSegmentsGenerator;
    }
    
    public void SetStateMachine(IStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    
    public void Enter()
    {
        roadUpdater = Observable.Interval(TimeSpan.FromSeconds(0.5f))
            .Subscribe(_ => HandleRoadUpdate());
    }

    private void HandleRoadUpdate()
    {
        if (IsCarCloseToRoadEnd())
        {
            GenerateRoad();
        }

        if (RoadHasSegmentsBehindCar())
        {
            road.RemoveFirstSegment();
        }
    }

    private bool IsCarCloseToRoadEnd()
    {
        return road.LastSegment.IsAheadAtLessThan(car.transform.position, config.RoadGenerationDistance);
    }

    private void GenerateRoad()
    {
        var segment = roadSegmentsGenerator.Generate(config.DefaultSegmentTemplate);
        road.AddSegmentToEnd(segment);
    }

    private bool RoadHasSegmentsBehindCar()
    {
        return road.FirstSegment.IsBehindAtMoreThan(car.transform.position, config.RoadSegmentBehindDestroyDistance);
    }
    
    public void Update()
    {
        
    }
    
    public void FixedUpdate()
    {
    }

    public void Exit()
    {
        roadUpdater?.Dispose();
    }
}