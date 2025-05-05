using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMesh : MonoBehaviour
{
    [SerializeField] private Renderer roadRenderer;
    [SerializeField] private float meshScale = 0.1f;
    
    public void SetLenght(float lenght)
    {
        var adjustedLenght = lenght * meshScale;
        SetRoadMaterialLenght(adjustedLenght);
        SetMeshScale(adjustedLenght);
    }
    
    private void SetRoadMaterialLenght(float lenght)
    {
        var material = roadRenderer.material;
        material.mainTextureScale = new Vector2(material.mainTextureScale.x,  lenght);
    }

    private void SetMeshScale(float lenght)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, lenght);
    }
}
