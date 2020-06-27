using System;
using System.Collections.Generic;
using ORMBenchmark.Interfaces;
using ORMBenchmark.Models;

namespace ORMBenchmark.Data.Dapper
{
    public class DapperBookRepository : DapperBaseRepository, IRepository<Book>
    {
        public DapperBookRepository() : base() { }

        public IEnumerable<Book> BulkInsert(List<Book> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public Book GetFirst()
        {
            throw new NotImplementedException();
        }

        public Book InsertOne(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
