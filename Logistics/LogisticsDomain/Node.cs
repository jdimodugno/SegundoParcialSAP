using System;
using System.Collections.Generic;

namespace LogisticsDomain
{
    public class Node
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IdentifierName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<Path> PathAsOrigin { get; set; }
        public ICollection<Path> PathAsDestination { get; set; }

    }
}
