using UnityEngine;

public class BonusChoiceRoadContent : MonoBehaviour, IRoadContent
{
    [SerializeField] private float lenght = 10;
    [SerializeField] private BonusChoice leftBonus, rightBonus;
    
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

    private CarData leftUpgrade, rightUpgrade;
        
    public void Initialize(Bonus leftBonus, Bonus rightBonus)
    {
        this.leftBonus.Init(leftBonus);
        this.rightBonus.Init(rightBonus);

        this.leftBonus.Choosen += ApplyBonus;
        this.rightBonus.Choosen += ApplyBonus;
    }

    public void ApplyBonus(Car car, Bonus bonus)
    {
        bonus.Apply(car);
        Deactivate();
    }

    private void Deactivate()
    {
        leftBonus.Deactivate();
        rightBonus.Deactivate();
    }
    
    public void Dispose()
    {
        Destroy(gameObject);
        
        leftBonus.Choosen += ApplyBonus;
        rightBonus.Choosen += ApplyBonus;
    }
}
