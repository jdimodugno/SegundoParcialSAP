using System;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using Microsoft.Data.SqlClient;
using ORMBenchmarkRunner.Scenarios;

namespace ORMBenchmarkRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("STARTING BENCHMARKING");

            ResetBookTable();

            var config = new ManualConfig()
                            .WithOptions(ConfigOptions.JoinSummary)
                            .WithOptions(ConfigOptions.DisableLogFile)
                            .WithOptions(ConfigOptions.DisableOptimizationsValidator)
                            .AddValidator(JitOptimizationsValidator.DontFailOnError)
                            .AddLogger(ConsoleLogger.Default)
                            .AddColumnProvider(DefaultColumnProviders.Instance);

            BenchmarkRunner.Run<InsertComparison>(config);
            BenchmarkRunner.Run<SelectComparison>(config);

            Console.WriteLine("FINISHING BENCHMARKING");
        }

        static void ResetBookTable()
        {
            SqlConnection conn = new SqlConnection("Server=localhost,1433;Database=SegundoParcial;User=sa;Password=cdd4646!;MultipleActiveResultSets=true;");
            string SqlCommand = "DELETE Book; DBCC CHECKIDENT ('Book', RESEED, 0);";
            SqlCommand cmd = new SqlCommand(SqlCommand, conn);

            try
            {
                conn.Open();
                cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
