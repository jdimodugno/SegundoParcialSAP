using System;
using System.Collections.Generic;

namespace LogisticsDomain
{
    public class TransportationVehicle
    {
        public string LicencePlate { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public ICollection<Shipping> Shippings { get; set; }
    }
}
