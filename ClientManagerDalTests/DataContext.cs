using System;
using System.Data;
using System.Data.SqlClient;

namespace ClientManagerDalTests
{
    class DataContext
    {
        //private static string connectionString = $"Server=(localdb)\\MSSqlLocalDb; Database=ClientManager_{Guid.NewGuid()}; Trusted_connection=true";
        private static string connectionString = $"Server=localhost\\sqlexpress; Database=ClientManager_1ca91cf1-00f4-4575-944d-5be5ab0a6aa0; Trusted_connection=true";
        public static IDbConnection GetConnection() => new SqlConnection(connectionString);

    }
}
