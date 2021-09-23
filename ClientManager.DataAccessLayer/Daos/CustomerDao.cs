using ClientManager.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace ClientManager.DataAccessLayer.Daos
{
    // TODO: Solve the compile error
    class CustomerDao : BaseDao, ICustomerDao
    {
        public CustomerDao(Func<IDbConnection> connectionFactory) : base(connectionFactory)
        {

        }

        public IEnumerable<Customer> GetAll()
        {
            // TODO: Implement call to database for returning all rows from the Customers table (Exercise 1)

            // 1. Create and open a connection to the database
            IDbConnection conn = GetConnection();
            conn.Open();

            // 2. Create a sql command that will be executed on the database
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Customers";

            // 3. Create a datareader object to retrieve data
            IDataReader reader = cmd.ExecuteReader();

            // 4. Pass the data from the reader into a collection of Customer objects
            while (reader.Read())
            {
                yield return new Customer
                {
                    CustomerId = reader.GetInt32(0),
                    Firstname = reader.GetString(1),
                    Lastname = reader.GetString(2),
                    Address = reader.GetString(3),
                    Zip = reader.GetString(5),
                    City = reader.GetString(4),
                    Phone = reader.GetString(6),
                    Email = reader.GetString(7)
                };
            }

            // 5. Clean up
            conn.Close();
        }

        public Customer GetById(int id)
        {
            // TODO: Implement call to database for returning a specific row from the Customers table with the given id (Exercise 1)
            IDbConnection conn = GetConnection();
            conn.Open();

            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Customers WHERE Id = @id";

            IDataParameter idParameter = cmd.CreateParameter();
            idParameter.Value = id;
            idParameter.DbType = DbType.Int32;
            idParameter.ParameterName = "@id";
            cmd.Parameters.Add(idParameter);

            IDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Customer
                {
                    CustomerId = reader.GetInt32(0),
                    Firstname = reader.GetString(1),
                    Lastname = reader.GetString(2),
                    Address = reader.GetString(3),
                    Zip = reader.GetString(5),
                    City = reader.GetString(4),
                    Phone = reader.GetString(6),
                    Email = reader.GetString(7)
                };
            }
            else
            {
                return null;
            }
        }


        public int Insert(Customer entity)
        {
            // TODO: Implement call to database that inserts the entity into the customers table (Exercise 1)
            IDbConnection conn = GetConnection();
            conn.Open();

            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Customers VALUES (@firstname, @lastname, @address, @zip, @city, @email, @phone)";

            IDataParameter firstnameParameter = cmd.CreateParameter();
            firstnameParameter.ParameterName = "@firstname";
            firstnameParameter.Value = entity.Firstname;
            firstnameParameter.DbType = DbType.String;
            cmd.Parameters.Add(firstnameParameter);

            IDataParameter lastnameParameter = cmd.CreateParameter();
            lastnameParameter.ParameterName = "@lastname";
            lastnameParameter.Value = entity.Lastname;
            lastnameParameter.DbType = DbType.String;
            cmd.Parameters.Add(lastnameParameter);

            IDataParameter addressParameter = cmd.CreateParameter();
            addressParameter.ParameterName = "@address";
            addressParameter.Value = entity.Address;
            addressParameter.DbType = DbType.String;
            cmd.Parameters.Add(addressParameter);

            IDataParameter zipParameter = cmd.CreateParameter();
            zipParameter.ParameterName = "@zip";
            zipParameter.Value = entity.Zip;
            zipParameter.DbType = DbType.String;
            cmd.Parameters.Add(zipParameter);

            IDataParameter cityParameter = cmd.CreateParameter();
            cityParameter.ParameterName = "@city";
            cityParameter.Value = entity.City;
            cityParameter.DbType = DbType.String;
            cmd.Parameters.Add(cityParameter);

            IDataParameter emailParameter = cmd.CreateParameter();
            emailParameter.ParameterName = "@email";
            emailParameter.Value = entity.Email;
            emailParameter.DbType = DbType.String;
            cmd.Parameters.Add(emailParameter);

            IDataParameter phoneParameter = cmd.CreateParameter();
            phoneParameter.ParameterName = "@phone";
            phoneParameter.Value = entity.Phone;
            phoneParameter.DbType = DbType.String;
            cmd.Parameters.Add(phoneParameter);

            return cmd.ExecuteNonQuery();
        }

        public bool Update(Customer entity)
        {
            // TODO: Implement call to database that updates the entity in the customers table (Exercise 1)
            IDbConnection conn = GetConnection();
            conn.Open();

            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Customers SET " +
                "Firstname = @firstname, " +
                "Lastname = @lastname, " +
                "Address = @address, " +
                "Zip = @zip, " +
                "City = @city, " +
                "Email = @email, " +
                "Phone = @phone " +
                "WHERE Id = @id";

            IDataParameter firstnameParameter = cmd.CreateParameter();
            firstnameParameter.ParameterName = "@firstname";
            firstnameParameter.Value = entity.Firstname;
            firstnameParameter.DbType = DbType.String;
            cmd.Parameters.Add(firstnameParameter);

            IDataParameter lastnameParameter = cmd.CreateParameter();
            lastnameParameter.ParameterName = "@lastname";
            lastnameParameter.Value = entity.Lastname;
            lastnameParameter.DbType = DbType.String;
            cmd.Parameters.Add(lastnameParameter);

            IDataParameter addressParameter = cmd.CreateParameter();
            addressParameter.ParameterName = "@address";
            addressParameter.Value = entity.Address;
            addressParameter.DbType = DbType.String;
            cmd.Parameters.Add(addressParameter);

            IDataParameter zipParameter = cmd.CreateParameter();
            zipParameter.ParameterName = "@zip";
            zipParameter.Value = entity.Zip;
            zipParameter.DbType = DbType.String;
            cmd.Parameters.Add(zipParameter);

            IDataParameter cityParameter = cmd.CreateParameter();
            cityParameter.ParameterName = "@city";
            cityParameter.Value = entity.City;
            cityParameter.DbType = DbType.String;
            cmd.Parameters.Add(cityParameter);

            IDataParameter emailParameter = cmd.CreateParameter();
            emailParameter.ParameterName = "@email";
            emailParameter.Value = entity.Email;
            emailParameter.DbType = DbType.String;
            cmd.Parameters.Add(emailParameter);

            IDataParameter phoneParameter = cmd.CreateParameter();
            phoneParameter.ParameterName = "@phone";
            phoneParameter.Value = entity.Phone;
            phoneParameter.DbType = DbType.String;
            cmd.Parameters.Add(phoneParameter);

            IDataParameter idParameter = cmd.CreateParameter();
            idParameter.ParameterName = "@id";
            idParameter.Value = entity.CustomerId;
            idParameter.DbType = DbType.Int32;
            cmd.Parameters.Add(idParameter);

            return cmd.ExecuteNonQuery() == 1;
        }

        public bool Delete(Customer entity)
        {
            // TODO: Implement call to database that deletes the entity from the customers table (Exercise 1)
            IDbConnection conn = GetConnection();
            conn.Open();

            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Customers WHERE Id = @id";

            IDataParameter idParameter = cmd.CreateParameter();
            idParameter.Value = entity.CustomerId;
            idParameter.DbType = DbType.Int32;
            idParameter.ParameterName = "@id";
            cmd.Parameters.Add(idParameter);

            return cmd.ExecuteNonQuery() == 1;
        }
    }
}
