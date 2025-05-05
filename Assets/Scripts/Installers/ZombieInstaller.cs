using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class ZombieInstaller : MonoInstaller
{
    [SerializeField] private Animator animator; 
     [SerializeField] private ZombiePersuitTarget persuitTarget;
    
    public override void InstallBindings()
    {
        
    }
}