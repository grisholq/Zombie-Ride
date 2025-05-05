using System;
using System.Collections;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public class RoadContentFactory
{
    [Serializable]
    public class Prefabs
    {
        public ZombieZone ZombieZonePrefab;
        public BonusChoiceRoadContent BonusChoicePrefab;
    }
    
    private ZombiePool zombiePool;
    private Prefabs prefabs;
    
    public RoadContentFactory(Prefabs prefabs, ZombiePool zombiePool)
    {
        this.prefabs = prefabs;
        this.zombiePool = zombiePool;
    }
    
    public ZombieZone GenerateZombieZone(ZombieContentData data)
    {
        var instance = Object.Instantiate(prefabs.ZombieZonePrefab);
        var zombies = zombiePool.GetZombies(data.Amount);
        instance.Initialize(data.Lenght, zombies);
        return instance;
    }

    public BonusChoiceRoadContent GenerateBonusChoice(BonusContentData data)
    {
        var instance = Object.Instantiate(prefabs.BonusChoicePrefab);
        instance.Initialize(data.RandomBonus, data.RandomBonus);
        return instance;
    }
}