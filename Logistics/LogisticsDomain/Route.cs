using System;
using System.Collections.Generic;

namespace LogisticsDomain
{
    public class Route
    {
        public string Detail { get; set; }
        public int Distance { get; set; }
        public List<Guid> NodeIds { get; set; }
        public List<Node> Nodes { get; set; }
    }
}
