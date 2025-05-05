using System;
using UnityEngine;

[Serializable]
public abstract class Bonus : ScriptableObject
{
    public abstract string Title { get; }
    public abstract void Apply(Car car);
}