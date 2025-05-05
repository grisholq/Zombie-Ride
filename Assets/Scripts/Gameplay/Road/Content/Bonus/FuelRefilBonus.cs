using UnityEngine;

[CreateAssetMenu(fileName = "FuilRefil", menuName = "BonusData/FuelRefil")]
public class FuelRefilBonus : Bonus
{
    public override string Title => $"Fuel: {RefilAmount}";
    public float RefilAmount;
 
    public override void Apply(Car car)
    {
        car.AddFuel(RefilAmount);
    }
}