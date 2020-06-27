using System;
using System.Collections.Generic;
using ORMBenchmark.Interfaces;
using ORMBenchmark.Models;

namespace ORMBenchmark.Data.Dapper
{
    public class DapperAuthorRepository : DapperBaseRepository, IRepository<Author>
    {
        public DapperAuthorRepository() : base() { }

        public IEnumerable<Author> BulkInsert(List<Author> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public Author GetFirst()
        {
            throw new NotImplementedException();
        }

        public Author InsertOne(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
