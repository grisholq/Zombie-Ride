using UnityEngine;

[CreateAssetMenu(fileName = "BonusContentData", menuName = "ContentData/BonusContentData")]
public class BonusContentData : RoadContentData
{
    public Bonus[] PossibleBonuses;

    public Bonus RandomBonus => PossibleBonuses[Random.Range(0, PossibleBonuses.Length)];
}