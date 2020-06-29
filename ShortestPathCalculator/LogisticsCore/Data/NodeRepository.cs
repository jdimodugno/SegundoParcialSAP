using System;
using System.Collections.Generic;
using System.Linq;
using LogisticsDomain;

namespace LogisticsCore.Data
{
    public class NodeRepository : BaseRepository<Node>
    {
        public List<Node> GetAll() => _entity.ToList();
    }
}
