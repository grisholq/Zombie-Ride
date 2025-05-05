using UnityEngine;

public class EmptyRoadContent : IRoadContent
{
    public float Lenght { get; private set; }
    public Vector3 Position { get; set; }
    public void SetParent(Transform parent)
    {
        
    }

    public void Dispose() { }

    public EmptyRoadContent(float lenght)
    {
        Lenght = lenght;
    }
}