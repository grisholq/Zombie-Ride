using System;
using System.Collections;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public class ZombiePool : Pool<Zombie>
{   
    [Serializable]
    public class Settings
    {
        public Zombie Prefab;
    }
    
    private Settings settings;
    private PoolGlobalParent globalParent;

    public ZombiePool(Settings settings, PoolGlobalParent globalParent)
    {
        this.settings = settings;
        this.globalParent = globalParent;
    }

    public IEnumerable<Zombie> GetZombies(int amount)
    {
        var zombies = new List<Zombie>();

        for (int i = 0; i < amount; i++)
        {
            zombies.Add(Get());
        }
        
        return zombies;
    }
    
    protected override Zombie Instantiate()
    {
        return Object.Instantiate(settings.Prefab);
    }

    public override void Return(Zombie obj)
    {
        base.Return(obj);
        obj.transform.SetParent(globalParent.transform);
    }
}
