using System;
using UnityEngine;

public class ZombiePersuitTarget : MonoBehaviour
{
    public Transform Target { get; set; }
    
    public event Action TargetAcquired;
    public event Action TargetLost;
}