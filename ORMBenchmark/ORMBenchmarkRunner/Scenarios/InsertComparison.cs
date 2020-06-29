using BenchmarkDotNet.Attributes;
using ORMBenchmark.Data.Dapper;
using ORMBenchmark.Data.EntityFramework;

namespace ORMBenchmarkRunner.Scenarios
{
    public class InsertComparison
    {
        EFCoreRepository efCoreRepository = new EFCoreRepository();
        DapperRepository dapperRepository = new DapperRepository();


        [Benchmark]
        public void BulkInsertBooksThroughDapper() => dapperRepository.BulkInsert();

        [Benchmark]
        public void BulkInsertBooksThroughEFCore() => efCoreRepository.BulkInsert();
    }
}
