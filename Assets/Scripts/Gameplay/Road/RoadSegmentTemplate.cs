using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RoadSegmentTemplate", menuName = "RoadSegmentTemplate")]
public class RoadSegmentTemplate : ScriptableObject
{
    public List<RoadContentData> ContentStructure;
}