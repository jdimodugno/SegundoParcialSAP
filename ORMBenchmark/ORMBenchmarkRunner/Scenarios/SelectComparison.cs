using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using ORMBenchmark.Data.Dapper;
using ORMBenchmark.Data.EntityFramework;
using ORMBenchmark.Models;

namespace ORMBenchmarkRunner.Scenarios
{
    public class SelectComparison
    {
        EFCoreRepository efCoreRepository = new EFCoreRepository();
        DapperRepository dapperRepository = new DapperRepository();

        [Benchmark]
        public void GetBooksFromDapper() => dapperRepository.GetAll();

        [Benchmark]
        public void GetBooksFromEFCore() => efCoreRepository.GetAll();
    }
}
