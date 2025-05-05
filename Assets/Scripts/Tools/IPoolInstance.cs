using UnityEngine;

public interface IPoolInstance<T> where T : MonoBehaviour, IPoolInstance<T>
{
    public void SetPool(Pool<T> pool);
}
