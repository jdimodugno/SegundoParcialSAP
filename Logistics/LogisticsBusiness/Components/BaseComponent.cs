using System;
using LogisticsCore.Data;

namespace LogisticsBusiness.Components
{
    public abstract class BaseComponent<T> where T : class
    {
        protected readonly BaseRepository<T> _repository;
        public BaseComponent(BaseRepository<T> repository)
        {
            _repository = repository;
        }
    }
}
