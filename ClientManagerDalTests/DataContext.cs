using System;
using System.Data;
using System.Data.SqlClient;

namespace ClientManagerDalTests
{
    public static class DataContext
    {
        public static string ConnectionString { get; }

        static DataContext()
        {
            ConnectionString = $@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ClientManager_TEST_{Guid.NewGuid()};Integrated Security=True";
        }

        public static IDbConnection OpenConnection()
        {
            SqlConnection conn = new(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
