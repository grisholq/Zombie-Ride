using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine.Serialization;
using Zenject;

public class Road : MonoBehaviour
{
    [SerializeField] private Transform segmentsStart;
    [SerializeField] private Transform segmentsParent;

    public RoadSegment FirstSegment => roadSegments.FirstOrDefault();
    public RoadSegment LastSegment => roadSegments.LastOrDefault();
    
    private LinkedList<RoadSegment> roadSegments = new LinkedList<RoadSegment>();
    
    public void AddSegmentToEnd(RoadSegment segment)
    {       
        PositionSegment(segment);
        segment.transform.SetParent(segmentsParent);
        roadSegments.AddLast(segment);
    }

    public void RemoveFirstSegment()
    {
        var firstSegment = roadSegments.First.Value;
        firstSegment.Dispose();
        roadSegments.RemoveFirst();
    }

    private void PositionSegment(RoadSegment segment)
    {
        if (roadSegments.IsEmpty())
        {
            segment.transform.position = segmentsStart.position;
            return;
        }
        
        var lastSegment = roadSegments.Last.Value;
        segment.transform.position = lastSegment.transform.position + Vector3.forward * (segment.HalfLenght + lastSegment.HalfLenght);
    }
}