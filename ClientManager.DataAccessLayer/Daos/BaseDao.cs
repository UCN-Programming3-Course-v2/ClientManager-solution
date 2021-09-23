using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManager.DataAccessLayer.Daos
{
    internal abstract class BaseDao
    {
        private readonly Func<IDbConnection> _connectionFactory;

        public BaseDao(Func<IDbConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        protected IDbConnection GetConnection()
        {
            return _connectionFactory();
        }
    }
}
