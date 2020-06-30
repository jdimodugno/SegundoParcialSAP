using System;
using System.Collections.Generic;
using LogisticsCore.Data;
using LogisticsDomain;

namespace LogisticsBusiness.Components
{
    public class ShippingComponent : BaseComponent<Shipping>
    {
        public ShippingComponent() : base(new ShippingRepository()) { }

        public List<Shipping> GetAll() => ((ShippingRepository)_repository).GetAll();

        public Shipping GetById(Guid Id) => ((ShippingRepository)_repository).GetById(Id);

        public List<Shipping> GetInProgressShippings() => ((ShippingRepository)_repository).GetInProgressShippings();
    }
}
