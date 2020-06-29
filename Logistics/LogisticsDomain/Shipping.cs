using System;
using System.Runtime.Serialization;

namespace LogisticsDomain
{
    public class Shipping
    {
        public Guid Id { get; set; }

        public int Status { get; set; }
        public DateTime DateScheduled { get; set; }
        public DateTime? DateCompleted { get; set; }

        public string? CurrentSegment { get; set; }

        public Guid RouteId { get; set; }
        public virtual Route Route { get; set; }

        public string TransportationVehicleLicensePlate { get; set; }
        public virtual TransportationVehicle TransportationVehicle { get; set; }
    }
}
