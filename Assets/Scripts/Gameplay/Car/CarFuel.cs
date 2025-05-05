using UnityEngine;
using System;

public class CarFuel
{
    [Serializable]
    public class Settings
    {
        public float MaxFuel = 50f;
    }

    public float FuelPercent => current / settings.MaxFuel;
    
    public float Current
    {
        get => current;
        set
        {
            float previousFuel = current;
            current = Mathf.Clamp(value, 0, settings.MaxFuel);

            if (previousFuel > 0 && current <= 0)
            {
                OutOfFuel?.Invoke();
            }
        }
    }

    private float current;
    private Settings settings;

    public event Action OutOfFuel;

    public CarFuel(Settings settings)
    {
        this.settings = settings;
        this.current = settings.MaxFuel;
    }

    public bool TryConsumeFuel(float amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        if (Current >= amount)
        {
            Current -= amount;
            return true;
        }

        return false;
    }

    public void AddFuel(float amount)
    {
        Current += amount;
    }
}