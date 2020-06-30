using System;
using System.Collections.Generic;
using System.Linq;
using LogisticsDomain;
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
    }
}
