using System;
using LogisticsAPI.Helpers;
using LogisticsBusiness.Components;
using LogisticsDomain;
using LogisticsDomain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsAPI.Controllers
{
    [Route("api/shippings")]
    [ApiController]
    public class ShippingController : GenericController<Shipping, ShippingComponent>
    {
        public ShippingController() : base(new ShippingComponent()) { }

        [HttpGet]
        [Route("statuses")]
        public JsonResult GetShippingStatuses() => new JsonResult(EnumHelper<ShippingStatus>.ToJson());

        [HttpGet("{Id}")]
        public Shipping GetByLicensePlate(Guid Id) => ((ShippingComponent)_component).GetById(Id);
    }
}
