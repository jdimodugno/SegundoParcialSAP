using System.Collections.Generic;
using LogisticsBusiness.Components;
using LogisticsDomain;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsAPI.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class TransportationVehicleController : GenericController<TransportationVehicle, TransportationVehicleComponent>
    {
        public TransportationVehicleController() : base(new TransportationVehicleComponent()) { }

        [HttpGet]
        public IEnumerable<TransportationVehicle> GetAll() => ((TransportationVehicleComponent)_component).GetAll();

        [HttpGet("{LicensePlate}")]
        public TransportationVehicle GetByLicensePlate(string LicensePlate) => ((TransportationVehicleComponent)_component).GetByLicensePlate(LicensePlate);
    }
}
