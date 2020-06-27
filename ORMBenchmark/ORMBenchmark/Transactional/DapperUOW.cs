using System;
using ORMBenchmark.Data.Dapper;
using ORMBenchmark.Interfaces;

namespace ORMBenchmark.Transactional
{
    public class DapperUOW : IUnityOfWork<DapperAuthorRepository, DapperBookRepository>
    {

        public DapperAuthorRepository AuthorRepository { get; }
        public DapperBookRepository BookRepository { get; }

        public DapperUOW()
        {
            AuthorRepository = new DapperAuthorRepository();
            BookRepository = new DapperBookRepository();
        }
    }
}
