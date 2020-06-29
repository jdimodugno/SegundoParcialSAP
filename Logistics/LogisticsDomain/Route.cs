using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsDomain
{
    public class Route
    {
        public Guid Id { get; set; }
        public string Detail { get; set; }
        public int Distance { get; set; }

        public List<RouteNode>? RouteNodes { get; set; }

        [NotMapped]
        public List<Guid> NodeIds { get; set; }

        [NotMapped]
        public List<Path> Segments { get; set; }

        public ICollection<Shipping> Shippings { get; set; }
    }
}
