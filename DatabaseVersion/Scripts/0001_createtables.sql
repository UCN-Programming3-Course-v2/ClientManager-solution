 CREATE TABLE Customers(
	Id int primary key identity(1,1) not null, 
	Firstname nvarchar(50) not null, 
	Lastname nvarchar(50) not null, 
	Address nvarchar(50) not null, 
	Zip char(6),
	City nvarchar(50), 
	Phone char(12),
	Email nvarchar(128)
 )