using System;
using UnityEngine;
using UnityEngine.Serialization;


[Serializable]
[CreateAssetMenu(fileName = "CarData", menuName = "ScriptableObjects/CarData", order = 1)]
public class CarData : ScriptableObject
{
    public string Name;
    public CarStats Stats;
    public CarView View;
    public CarType CarType;
}