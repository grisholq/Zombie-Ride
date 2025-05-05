using System;
using TMPro;
using UnityEngine;

public class BonusChoice : MonoBehaviour
{
    [SerializeField] private TextMeshPro bonusName;

    public event Action<Car, Bonus> Choosen;
    
    private Bonus bonus;
    private bool active = true;
    
    public void Init(Bonus bonus)
    {
        this.bonus = bonus;
        bonusName.text = bonus.Title;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!active) return;
        
        var car = other.GetComponentInParent<Car>();

        if (car != null)
        {
            active = false;
            Choosen?.Invoke(car, bonus);
        }
    }

    public void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }
}