using System;
using LogisticsBusiness.Components;
using LogisticsDomain;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : GenericController<Route, RouteComponent>
    {
        public RouteController() : base(new RouteComponent()) { }

        [HttpGet]
        public Route GetShortestRoute()
        {
            Guid CABA = Guid.Parse("98f457c9-aa02-4d6b-8013-ecb3f4fb1785");
            Guid Formosa = Guid.Parse("10de5c0a-0fb9-462d-83ba-6b5ac7c48095");
            Guid Cordoba = Guid.Parse("2272753e-7939-4c53-92b8-40182d578338");
            Guid LaRioja = Guid.Parse("7eb35662-4380-4a6a-a978-446b342cd39f");
            Guid Neuquen = Guid.Parse("9adc8373-3399-406d-ac49-e894229e6d05");

            return ((RouteComponent)_component).GetShortestRoute(LaRioja, new Guid[] { Formosa, CABA, Cordoba, Neuquen });
        }
    }
}
