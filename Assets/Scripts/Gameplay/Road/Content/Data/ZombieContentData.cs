using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieContentData", menuName = "ContentData/ZombieContentData")]
public class ZombieContentData : RoadContentData
{
    public int MinZombiesAmount, MaxZombiesAmount;
    public int MinLenght, MaxLenght;
    public int Amount => Random.Range(MinZombiesAmount, MaxZombiesAmount);
    public float Lenght => Random.Range(MinLenght, MaxLenght);
}
