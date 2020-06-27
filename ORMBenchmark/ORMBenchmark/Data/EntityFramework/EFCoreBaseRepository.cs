using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ORMBenchmark.Interfaces;

namespace ORMBenchmark.Data.EntityFramework
{
    public abstract class EFCoreBaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbSet<T> _entity;
        protected DbContext context;

        public EFCoreBaseRepository()
        {
            this.context = new ApplicationDBContext();
            _entity = context.Set<T>();
        }

        public IEnumerable<T> BulkInsert(List<T> entities)
        {
            _entity.BulkInsert<T>(entities);
            return _entity.ToList<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetFirst()
        {
            return _entity.FirstOrDefault();
        }

        public T InsertOne(T entity)
        {
            _entity.Add(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
