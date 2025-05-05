using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CarLogicLoop : ITickable, IFixedTickable, IActivatable, IInitializable, IDisposable
{
    private CarInput carInput;
    private CarStatsHolder carStatsHolder;
    private CarFuel carFuel;
    private Transform carViewTransform;
    private Rigidbody rigidbody;

    private CarStats carStats => carStatsHolder.Current;

    private bool active = false;
    
    [Inject]
    private void Construct(CarInput carInput, CarStatsHolder carStatsHolder, CarMonos carMonos, CarFuel fuel)
    {
        this.carInput = carInput;
        this.carStatsHolder = carStatsHolder;
        rigidbody = carMonos.Rigidbody;
        carViewTransform = carMonos.viewHolderTransform;
        carFuel = fuel;
    }
    
    public void Initialize()
    {
        carFuel.OutOfFuel += OnOutOfFuel;
    }
    
    public void FixedTick()
    {
        if(active == false) return;
        
        HandleMovement();
    }
    
    public void Tick()
    {  
        if(active == false) return;

        HandleCarRotation();
        carFuel.TryConsumeFuel(carStats.FuelSpendPerSecond * Time.deltaTime);
    }
    
    private void HandleMovement()
    {
        var velocityZ = carStats.Speed;
        var velocityX =  (carInput.Turn * carStats.SideSpeed);
        rigidbody.velocity = new Vector3(velocityX, rigidbody.velocity.y, velocityZ);
    }
    
    private void HandleCarRotation()
    {
        float targetRotationAngle = carInput.Turn * carStats.MaxRotationAngle;
        var eulers = carViewTransform.eulerAngles;
        eulers.y = Mathf.LerpAngle(eulers.y, targetRotationAngle, carStats.ViewRotationSpeed * Time.deltaTime);
        carViewTransform.eulerAngles = eulers;
    }

    public void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;   
    }

    public void Dispose()
    {
        carFuel.OutOfFuel -= OnOutOfFuel;
    }

    private void OnOutOfFuel()
    {
        
    }
}