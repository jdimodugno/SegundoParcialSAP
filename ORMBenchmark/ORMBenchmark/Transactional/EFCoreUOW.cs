using System;
using ORMBenchmark.Data.Dapper;
using ORMBenchmark.Data.EntityFramework;
using ORMBenchmark.Interfaces;

namespace ORMBenchmark.Transactional
{
    public class EFCoreUOW : IUnityOfWork<EFCoreAuthorRepository, EFCoreBookRepository>
    {
        public EFCoreAuthorRepository AuthorRepository { get; }
        public EFCoreBookRepository BookRepository { get; }

        public EFCoreUOW()
        {
            AuthorRepository = new EFCoreAuthorRepository();
            BookRepository = new EFCoreBookRepository();
        }
    }
}
