using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using ORMBenchmark.Generator;
using ORMBenchmark.Models;

namespace ORMBenchmark.Data.EntityFramework
{
    public class EFCoreRepository
    {
        protected DbSet<Book> _entity;
        protected DbContext context;

        public EFCoreRepository()
        {
            context = new ApplicationDBContext();
            _entity = context.Set<Book>();
        }

        public void BulkInsert()
        {
            _entity.AddRange(MockHelper.GetBookList());
            context.SaveChanges();
        }

        [Benchmark]
        public void GetAll()
        {
            try
            {
                _entity.ToList();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
