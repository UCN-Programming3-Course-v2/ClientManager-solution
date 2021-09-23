using ClientManager;
using ClientManager.DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClientManagerDalTests
{
    [TestClass]
    public class CreateDaoTests
    {
        [TestMethod]
        public void CreateCustomerDao()
        {
            ICustomerDao dao = DaoFactory.Create<ICustomerDao>(DataContext.GetConnection);
            Assert.IsInstanceOfType(dao, typeof(ICustomerDao));
        }
    }
}
