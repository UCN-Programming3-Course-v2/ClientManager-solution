using ClientManager.Model;
using System.Collections.Generic;

namespace ClientManager.DataAccessLayer
{
    public interface ICustomerDao
    {
        bool Delete(Customer entity);
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        int Insert(Customer entity);
        bool Update(Customer entity);
    }
}