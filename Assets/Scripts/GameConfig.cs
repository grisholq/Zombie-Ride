using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    public float RoadGenerationDistance = 100;
    public float RoadSegmentBehindDestroyDistance = 5;
    public RoadSegmentTemplate[] StartTemplates;
    public RoadSegmentTemplate DefaultSegmentTemplate;
    public CarData DefaultCarData;
}