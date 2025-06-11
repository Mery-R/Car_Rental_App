create database Users
go
use Users
go
create table [User]
(
	Id UNIQUEIDENTIFIER primary Key default NEWID(),
	Username nvarchar (50) unique not null,
	[Password] nvarchar (100) not null,
	[Name] nvarchar (50) not null,
	LastName nvarchar (50) not null,
	Email  nvarchar (100) unique not null,
	Access bit not null default 0
)
go
insert into [User] values (NEWID(), 'admin', 'admin','Mi³osz','Stec', 'smilosz11@gmail.com', 1)
insert into [User] values (NEWID(), 'user', 'user','Adam','Puc', 'apuc@student.agh.edu.pl', 0)
go

select *from [User]