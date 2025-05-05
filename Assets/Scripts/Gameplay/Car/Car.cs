using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class Car : MonoBehaviour, IInitializable, IDisposable
{
    public float FuelPercent => carFuel.FuelPercent;
    
    private CarViewHolder carViewHolder;
    private CarStatsHolder carStatsHolder;
    private CarLogicLoop carLogicLoop;
    private CarFuel carFuel;
    private IActivatable[] activatables;

    public event Action OutOfFuel;
    
    [Inject]
    private void Construct(CarStatsHolder carStatsHolder, CarViewHolder carViewHolder, CarLogicLoop carLogicLoop, IActivatable[] activatables, CarFuel fuel)
    {
        this.carStatsHolder = carStatsHolder;
        this.carViewHolder = carViewHolder;
        this.carLogicLoop = carLogicLoop;
        this.activatables = activatables;
        this.carFuel = fuel;
    }

    public void SetCarData(CarData carData)
    {
        carStatsHolder.Current = carData.Stats;
        carViewHolder.SetCarView(carData.View);
    }

    public void AddFuel(float amount)
    {
        carFuel.AddFuel(amount);
    }

    public void Activate()
    {
        foreach (var activatable in activatables)
        {
            activatable.Activate();
        }
    }
    
    public void Deactivate()
    {
        foreach (var activatable in activatables)
        {
            activatable.Deactivate();
        }
    }

    public void Initialize()
    {
        carFuel.OutOfFuel += OnOutOfFuel;
    }

    private void OnOutOfFuel()
    {
        OutOfFuel?.Invoke();
    }

    public void Dispose()
    {
        carFuel.OutOfFuel -= OnOutOfFuel;
    }
}