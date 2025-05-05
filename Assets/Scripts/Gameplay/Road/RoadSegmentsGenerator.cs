public class RoadSegmentsGenerator
{
    private RoadSegmentsPool roadSegmentsPool;
    private RoadContentFactory roadContentFactory;
    
    public RoadSegmentsGenerator(RoadSegmentsPool pool, RoadContentFactory factory)
    {
        roadSegmentsPool = pool;
        roadContentFactory = factory;
    }

    public RoadSegment Generate(RoadSegmentTemplate template)
    {
        var segment = roadSegmentsPool.Get();

        foreach (var content in template.ContentStructure)
        {
            switch (content.Type)
            {
                case RoadContentType.Empty:
                    var emptyData = (EmptyRoadContentData)content;
                    segment.AddContent(new EmptyRoadContent(emptyData.Lenght));
                    break;
                
                case RoadContentType.Zombie:
                    var zombieData = (ZombieContentData)content;
                    var zombieZone = roadContentFactory.GenerateZombieZone(zombieData);
                    segment.AddContent(zombieZone);
                    break;
                
                case RoadContentType.Bonus:
                    var bonusData = (BonusContentData)content;
                    var bonusChoice = roadContentFactory.GenerateBonusChoice(bonusData);
                    segment.AddContent(bonusChoice);
                    break;
            }
        }
        
        return segment;
    }
}