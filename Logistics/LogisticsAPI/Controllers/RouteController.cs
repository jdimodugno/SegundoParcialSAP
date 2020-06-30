using System;
using LogisticsAPI.Contracts;
using LogisticsBusiness.Components;
using LogisticsDomain;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsAPI.Controllers
{
    [Route("api/routes")]
    [ApiController]
    public class RouteController : GenericController<Route, RouteComponent>
    {
        public RouteController() : base(new RouteComponent()) { }

        [HttpGet("{Id}")]
        public Route GetRouteById(Guid Id) => ((RouteComponent)_component).GetById(Id);

        [Route("calculate")]
        [HttpPost]
        public Route GetShortestRoute([FromBody] ShortestRouteRequest shortestRouteRequest) => ((RouteComponent)_component)
                .GetShortestRoute(shortestRouteRequest.OriginNodeId, shortestRouteRequest.DestinationNodeIds);
    }
}
