using UnityEngine;

[CreateAssetMenu(fileName = "CarSwap", menuName = "BonusData/CarSwap")]
public class CarSwapBonus : Bonus
{
    public override string Title => SwapCar.Name;
    public CarData SwapCar;

    public override void Apply(Car car)
    {
        car.SetCarData(SwapCar);
    }
}