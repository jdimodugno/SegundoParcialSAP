using System;
namespace LogisticsDomain
{
    public class Path
    {
        public int Weight { get; set; }

        public Guid OriginId { get; set; }
        public Node Origin { get; set; }

        public Guid DestinationId { get; set; }
        public Node Destination { get; set; }

        public string SegmentIdentifierName { get; set; }
        public string GetSegmentDetail() => $"{Origin.Name} - {Destination.Name}";
    }
}
