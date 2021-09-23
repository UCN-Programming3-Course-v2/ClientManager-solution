using ClientManager.DataAccessLayer;
using ClientManager.DataAccessLayer.Daos;
using System;
using System.Data;

namespace ClientManager
{
    public static class DaoFactory
    {
        public static TEntity Create<TEntity>(Func<IDbConnection> connectionFactory) where TEntity : class
        {
            // TODO: Create the appropriate DAO object and return it...
            switch (typeof(TEntity))
            {
                case var dao when dao == typeof(ICustomerDao):
                    return new CustomerDao(connectionFactory) as TEntity;                    
                default:
                    return null;
            }
        }
    }
}
