using UnityEngine;

public class CarView : MonoBehaviour
{
    [SerializeField] private CarType carType;
    
    public CarType CarType => carType;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}