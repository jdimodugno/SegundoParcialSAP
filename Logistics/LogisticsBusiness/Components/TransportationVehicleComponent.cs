using System;
using System.Collections.Generic;
using LogisticsCore.Data;
using LogisticsDomain;

namespace LogisticsBusiness.Components
{
    public class TransportationVehicleComponent : BaseComponent<TransportationVehicle>
    {
        public TransportationVehicleComponent() : base(new TransportationVehicleRepository()) { }

        public List<TransportationVehicle> GetAll() => ((TransportationVehicleRepository)_repository).GetAll();

        public TransportationVehicle GetByLicensePlate(string LicensePlate) => ((TransportationVehicleRepository)_repository).GetByLicensePlate(LicensePlate);
    }
}
