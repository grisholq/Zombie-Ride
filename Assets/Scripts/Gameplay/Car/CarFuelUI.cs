using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CarFuelUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    [Inject]
    private Car car;

    private void Update()
    {
        slider.value = car.FuelPercent;
    }
}