using System;
using System.Linq;
using LogisticsDomain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsCore.Data
{
    public class BaseRepository<T> where T : class
    {
        protected DbSet<T> _entity;
        protected DbContext context;

        public BaseRepository()
        {
            this.context = new AppDBContext();
            _entity = context.Set<T>();
        }
    }
}
