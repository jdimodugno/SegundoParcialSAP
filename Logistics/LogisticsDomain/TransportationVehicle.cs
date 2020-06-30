using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using LogisticsDomain.Enums;

namespace LogisticsDomain
{
    public class TransportationVehicle
    {
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public ICollection<Shipping> Shippings { get; set; }

        [NotMapped]
        public bool Available { get; set; }
    }
}
