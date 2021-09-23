# Client Manager Application (Exercise 1)

In this exercise you worked on a Visual Studio solution where a big part of it already was implemented. 

You were given the task to implement the database operations in the application layer and now you should have implemented the CRUD methods in the Data Access Layer (DAL). 

It is implemented using the abstract factory pattern and you must comply with that.

**HINT!** The methods that you must implement are marked with a TODO comment

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
