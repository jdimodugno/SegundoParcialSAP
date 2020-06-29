using System;
using System.Collections.Generic;
using LogisticsCore.Data;
using LogisticsDomain;

namespace LogisticsBusiness.Components
{
    public class NodeComponent : BaseComponent<Node>
    {
        public NodeComponent() : base(new NodeRepository()) { }

        public List<Node> GetAll() => ((NodeRepository)_repository).GetAll();
    }
}
