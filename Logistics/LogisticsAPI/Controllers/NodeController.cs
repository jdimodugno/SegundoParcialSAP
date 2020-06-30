using System.Collections.Generic;
using LogisticsBusiness.Components;
using LogisticsDomain;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsAPI.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class NodeController : GenericController<Node, NodeComponent>
    {
        public NodeController() : base(new NodeComponent()) { }

        [HttpGet]
        public IEnumerable<Node> GetAll() => ((NodeComponent)_component).GetAll();
    }
}
