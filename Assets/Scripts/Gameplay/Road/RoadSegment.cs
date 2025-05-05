using System;
using System.Collections;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class RoadSegment : MonoBehaviour, IDisposable, IPoolInstance<RoadSegment>
{
    [SerializeField] private RoadMesh roadMesh;
    [SerializeField] private Transform contentParent;
    
    public float Lenght
    {
        get
        {
            float sum = 0;

            foreach (var content in contents)
            {
                sum += content.Lenght;
            }
            
            return sum;
        }
    }

    public float HalfLenght => Lenght / 2;

    public Vector3 EndPosition => transform.position + Vector3.forward * Lenght / 2;
    public Vector3 StartPosition => transform.position - Vector3.forward * Lenght / 2;

    private LinkedList<IRoadContent> contents = new LinkedList<IRoadContent>();
    private Pool<RoadSegment> pool;
    
    public void AddContent(IRoadContent content)
    {
        contents.AddLast(content);
        content.SetParent(contentParent);
        UpdateLenght();
        RepositionAllContent();
    }

    private void UpdateLenght()
    {
        roadMesh.SetLenght(Lenght);
    }

    private void RepositionAllContent()
    {
        if (contents.IsEmpty()) return;
        
        float totalLength = 0;
        foreach (var cont in contents)
        {
            totalLength += cont.Lenght;
        }

        float currentPositionZ = transform.position.z - totalLength / 2;

        foreach (var cont in contents)
        {
            Vector3 newPosition = new Vector3(transform.position.x, cont.Position.y, currentPositionZ + cont.Lenght / 2);
            cont.Position = newPosition;
            currentPositionZ += cont.Lenght;
        }
    }
    
    public void Dispose()
    {
        foreach (var content in contents)
        {
            content.Dispose();
        }
        
        contents.Clear();
        pool.Return(this);
    }
    
    public bool IsAheadOf(Vector3 position)
    {
        return position.z < StartPosition.z;
    }    
    
    public bool IsBehind(Vector3 position)
    {
        return position.z > EndPosition.z;
    }

    public float GetDistanceToEnd(Vector3 position)
    {
        return Mathf.Abs(EndPosition.z - position.z);
    }   
    
    public float GetDistanceToStart(Vector3 position)
    {
        return Mathf.Abs(StartPosition.z - position.z);
    }

    public bool IsAheadAtLessThan(Vector3 position, float distance)
    {
        return IsAheadOf(position) && GetDistanceToEnd(position) < distance;
    }

    public bool IsBehindAtMoreThan(Vector3 position, float distance)
    {
        return IsBehind(position) && GetDistanceToEnd(position) >= distance;
    }

    public void SetPool(Pool<RoadSegment> pool)
    { 
        this.pool = pool;
    }
}