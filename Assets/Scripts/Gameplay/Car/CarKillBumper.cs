using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarKillBumper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var zombie = other.GetComponentInParent<Zombie>();
        
        if(zombie == null) return;
        KillZombie(zombie);
    }

    public void KillZombie(Zombie zombie)
    {
        zombie.DieIn(1.5f);
    }
}