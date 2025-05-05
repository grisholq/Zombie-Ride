using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieZone : MonoBehaviour, IRoadContent
{
    [SerializeField] private float spawnWidth = 10;
    
    public float Lenght => lenght;

    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
    }

    private float halfSpawnWidth => spawnWidth * 0.5f;
    private float halfLenght => lenght * 0.5f;
    
    private List<Zombie> zombies = new List<Zombie>();
    private float lenght;
    
    public void Initialize(float lenght, IEnumerable<Zombie> zombies)
    {
        this.lenght = lenght;
        this.zombies.AddRange(zombies);
        ParentAllZombies();
        PositionZombiesRandomly();
    }

    private void ParentAllZombies()
    {
        foreach (var zombie in zombies)
        {
            zombie.transform.SetParent(transform);
        }
    }
    
    private void PositionZombiesRandomly()
    {
        foreach (var zombie in zombies)
        {
            var x = Random.Range(-halfSpawnWidth, halfSpawnWidth);
            var z = Random.Range(-halfLenght, halfLenght);
            zombie.transform.position = new Vector3(x, 0, z);
        }
    }
    
    public void Dispose()
    {
        foreach (var zombie in zombies)
        {
            zombie.Dispose();
        }
        
        zombies.Clear();
        
        Destroy(gameObject);
    }
}