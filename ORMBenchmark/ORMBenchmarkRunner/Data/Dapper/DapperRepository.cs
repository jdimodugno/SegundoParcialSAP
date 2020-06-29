using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ORMBenchmark.Models;
using Dapper;
using BenchmarkDotNet.Attributes;
using System.Linq;
using ORMBenchmark.Generator;

namespace ORMBenchmark.Data.Dapper
{
    public class DapperRepository
    {
        readonly IDbConnection conn;

        public DapperRepository()
        {
            conn = new SqlConnection("Server=localhost,1433;Database=SegundoParcial;User=sa;Password=cdd4646!;MultipleActiveResultSets=true;");
        }

        public void BulkInsert()
        {
            string sqlCommand = "insert into Book(Title, Year, Price, Genre, AuthorName) values(@Title, @Year, @Price, @Genre, @AuthorName)";

            try
            {
                conn.Execute(sqlCommand, MockHelper.GetBookArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        [Benchmark]
        public void GetAll()
        {
            try
            {
                conn.Query<Book>("select * from Book;").ToList();
            }
            catch (System.Exception ex)
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
