using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class RoadSegmentsPool : Pool<RoadSegment>
{
    [Serializable]
    public class Settings
    {
        public RoadSegment Prefab;
    }
    
    private Settings settings;
    private PoolGlobalParent globalParent;
    
    public RoadSegmentsPool(Settings settings, PoolGlobalParent globalParent)
    {
        this.settings = settings;
        this.globalParent = globalParent;
    }

    protected override RoadSegment Instantiate()
    {
        return Object.Instantiate(settings.Prefab);
    }

    public override void Return(RoadSegment obj)
    {
        base.Return(obj);
        obj.transform.SetParent(globalParent.transform);
    }
}
