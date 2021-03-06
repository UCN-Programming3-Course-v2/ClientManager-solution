using ClientManager;
using ClientManager.DataAccessLayer;
using ClientManager.Model;
using DatabaseVersion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientManagerDalTests
{
    [TestClass]
    public class CustomerTests
    {      
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Database.Upgrade(DataContext.ConnectionString);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
            {
                Database.Drop(DataContext.ConnectionString);
            }
        }

        [TestMethod]
        public void GetAllTest()
        {
            // TODO: Implement database integration test
            ICustomerDao dao = DaoFactory.Create<ICustomerDao>(DataContext.OpenConnection);

            var list = dao.GetAll();

            Assert.IsNotNull(list);
            Assert.IsInstanceOfType(list, typeof(IEnumerable<Customer>));
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            // TODO: Implement database integration test
            ICustomerDao dao = DaoFactory.Create<ICustomerDao>(DataContext.OpenConnection);

            var customer = dao.GetById(1);

            Assert.IsNotNull(customer);
            Assert.IsInstanceOfType(customer, typeof(Customer));
            Assert.AreEqual("Gyro", customer.Firstname);
            Assert.AreEqual("Duckburg", customer.City);
        }

        [TestMethod]
        public void CreateCustomerTest()
        {
            ICustomerDao dao = DaoFactory.Create<ICustomerDao>(DataContext.OpenConnection);

            Customer customer = new()
            {
                Firstname = "Donald",
                Lastname = "Duck",
                Address = "1313 Webfoot Street",
                City = "Duckburg",
                Zip = "LZ6548",
                Email = "daisylover01@barksuniverse.com",
                Phone = "877-764-2539"
            };

            int result = dao.Insert(customer);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateCustomerTest()
        {
            // TODO: Implement database integration test
            ICustomerDao dao = DaoFactory.Create<ICustomerDao>(DataContext.OpenConnection);

            var customer = dao.GetById(2);

            customer.Firstname = "Test";
            customer.Lastname = "Testesson";

            var result = dao.Update(customer);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteCustomerTest()
        {
            // TODO: Implement database integration test
            ICustomerDao dao = DaoFactory.Create<ICustomerDao>(DataContext.OpenConnection);

            var customer = dao.GetById(3);

            var result = dao.Delete(customer);

            Assert.IsTrue(result);

            customer = dao.GetById(3);

            Assert.IsNull(customer);
        }
    }
}
