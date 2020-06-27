using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ORMBenchmark.Data.Dapper
{
    public abstract class DapperBaseRepository
    {
        protected readonly IDbConnection db;

        public DapperBaseRepository()
        {
            string connectionString = Startup.GlobalConfiguration.GetConnectionString("DefaultConnection");
            db = new SqlConnection(connectionString);
        }
    }
}
