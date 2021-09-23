using System;
using System.Data;
using System.Data.SqlClient;

namespace ClientManagerDalTests
{
    class DataContext
    {
        public string ConnectionString { get; }

        public DataContext(string connectionString)
        {
            if (connectionString is null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            ConnectionString = connectionString;
        }

        public IDbConnection GetConnection() => new SqlConnection(ConnectionString);

    }
}
