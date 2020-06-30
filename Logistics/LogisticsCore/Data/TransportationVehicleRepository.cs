using System;
using System.Collections.Generic;
using System.Linq;
using LogisticsDomain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsCore.Data
{
    public class TransportationVehicleRepository : BaseRepository<TransportationVehicle>
    {
        public List<TransportationVehicle> GetAll() => _entity.ToList();

        public TransportationVehicle GetByLicensePlate(string LicensePlate) => _entity
            .Where(v => v.LicensePlate == LicensePlate)
            .Include(v => v.Shippings)
            .First();
    }
}
