using System;
namespace LogisticsDomain
{
    public class RouteNode
    {
        public Guid RouteId { get; set; }
        public virtual Route Route { get; set; }

        public int Order { get; set; }

        public Guid NodeId { get; set; }
        public virtual Node Node { get; set; }
    }
}
