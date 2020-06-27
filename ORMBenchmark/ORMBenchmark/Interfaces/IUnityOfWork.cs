using System;
namespace ORMBenchmark.Interfaces
{
    public interface IUnityOfWork<AuthorRepositoryType, BookRepositoryType>
    {
        AuthorRepositoryType AuthorRepository { get; }
        BookRepositoryType BookRepository { get; }
    }
}
