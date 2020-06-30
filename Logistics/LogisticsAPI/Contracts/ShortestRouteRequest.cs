using System;
namespace LogisticsAPI.Contracts
{
    public class ShortestRouteRequest
    {
        public Guid OriginNodeId { get; set; }
        public Guid[] DestinationNodeIds { get; set; }
    }
}
