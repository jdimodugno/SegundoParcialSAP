using System;
using System.Collections.Generic;

namespace ORMBenchmark.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        T GetFirst();
        IEnumerable<T> GetAll();
        T InsertOne(T entity);
        IEnumerable<T> BulkInsert(List<T> entities);
    }
}
