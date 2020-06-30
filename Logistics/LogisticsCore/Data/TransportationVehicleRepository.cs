using System;
using System.Collections.Generic;
using System.Linq;
using LogisticsDomain;
using LogisticsDomain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LogisticsCore.Data
{
    public class TransportationVehicleRepository : BaseRepository<TransportationVehicle>
    {
        public List<TransportationVehicle> GetAll()
        {
            List<TransportationVehicle> vehicles = _entity.Include(v => v.Shippings).ToList();
            vehicles.ForEach(v => v.Available = v.Shippings.All(s => s.Status == (int)ShippingStatus.Completed));
            return vehicles;
        }

        public TransportationVehicle GetByLicensePlate(string LicensePlate) => _entity
            .Where(v => v.LicensePlate == LicensePlate)
            .Include(v => v.Shippings)
            .ThenInclude(s => s.CurrentSegment)
            .First();

        public TransportationVehicle GetAvailableVehicles() => _entity
            .Where(v => v.Shippings.All(s => s.Status == (int)ShippingStatus.Completed))
            .Include(v => v.Shippings)
            .First();
    }
}
