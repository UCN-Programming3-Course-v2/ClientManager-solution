# Client Manager Application (Exercise 1)

In this exercise you worked on a Visual Studio solution where a big part of it already was implemented. 

You were given the task to implement the database operations in the application layer and now you should have implemented the CRUD methods in the Data Access Layer (DAL). 

This sample solution uses a variant of the factory method pattern when creating the DAO's. It is implemented in the DaoFactory class in the ClientManager.DataAccessLayer project. There is a single method with a generic parameter indicating which DAO interface you get back.

The CRUD methods is pretty straight forward using ADO.NET to execute SQL commands on the SQL Server.

## Database

The task can be solved with a single table in the database that should look something like this:

```SQL
CREATE TABLE Customers (  
  Id int primary key identity(1,1) not null,   
  Firstname nvarchar(50) not null,   
  Lastname nvarchar(50) not null,   
  Address nvarchar(50) not null,   
  Zip char(6),  
  City nvarchar(50),   
  Phone char(12),  
  Email nvarchar(128)  
)
```

The database is created very simply with the DbUp DeployChanges class that executes the SQL script above. Test data is also inserted. The SQL scripts are executed before each test and the database is dropped after. That way we can be sure that the test is consistent.
