using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public abstract class Pool<T> where T : MonoBehaviour, IPoolInstance<T>
{
    private readonly Stack<T> pool = new Stack<T>();
    
    public T Get(Transform parent = null)
    {
        T obj = null;
            
        if (pool.Count > 0)
        {
            obj = pool.Pop();
            obj.gameObject.SetActive(true); 
        }
        else
        {
            obj = CreateObject(true);
        }
        
        if(parent != null) obj.transform.SetParent(parent);
        
        obj.SetPool(this);
        return obj;
    }
    
    public virtual void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Push(obj);
    }
    
    private T CreateObject(bool active = false)
    {
        T newObj = Instantiate();
        newObj.gameObject.SetActive(active);
        return newObj;
    }

    protected abstract T Instantiate();
}