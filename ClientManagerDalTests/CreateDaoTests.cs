using ClientManager;
using ClientManager.DataAccessLayer;
using DatabaseVersion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClientManagerDalTests
{
    [TestClass]
    public class CreateDaoTests
    {
        private readonly DataContext _dbContext = new DataContext($@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ClientManager_TEST_{Guid.NewGuid()};Integrated Security=True");


        public void Initialize()
        {
            Database.Upgrade(_dbContext.ConnectionString);
        }

        public void Cleanup()
        {
            Database.Drop(_dbContext.ConnectionString);
        }

        [TestMethod]
        public void CreateCustomerDao()
        {
            ICustomerDao dao = DaoFactory.Create<ICustomerDao>(_dbContext.GetConnection);
            Assert.IsInstanceOfType(dao, typeof(ICustomerDao));
        }
    }
}
