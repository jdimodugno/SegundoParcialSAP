using System;
using System.Collections.Generic;
using System.Linq;
using LogisticsDomain;
using LogisticsDomain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LogisticsCore.Data
{
    public class ShippingRepository : BaseRepository<Shipping>
    {
        public List<Shipping> GetAll() => _entity.ToList();

        public Shipping GetById(Guid Id) => _entity
            .Where(s => s.Id == Id)
            .Include(s => s.Route)
            .First();

        public List<Shipping> GetInProgressShippings() => _entity
            .Where(s => s.Status == (int)ShippingStatus.InProgress)
            .Include(s => s.TransportationVehicle)
            .Include(s => s.CurrentSegment)
            .Include(s => s.Route)
                .ThenInclude(r => r.RouteNodes)
            .ToList();
    }
}
