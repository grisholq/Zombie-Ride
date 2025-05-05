using System;
using UnityEngine;

public interface IRoadContent : IDisposable
{   
    public float Lenght { get; }
    public Vector3 Position { get; set; }
    public void SetParent(Transform parent);
}