create database QuanLyKho
go
use QuanLyKho
go

--use master 
--drop database QuanLyKho
create table Unit
(
	Id int identity(1, 1) primary key,
	DisplayName nvarchar(1000),
)
go

create table Suplier 
(
	Id int identity(1, 1) primary key,
	DisplayName nvarchar(500),
	Address nvarchar(1000),
	Phone nvarchar(20),
	Email nvarchar(200),
	MoreInfo nvarchar(500),
	ContractDate Datetime,
)
go

create table Customer
(
	Id int identity(1, 1) primary key,
	DisplayName nvarchar(500),
	Address nvarchar(1000),
	Phone nvarchar(20),
	Email nvarchar(200),
	MoreInfo nvarchar(500),
	ContractDate Datetime,
)
go

create table Object
(
	Id nvarchar(128) primary key,
	DisplayName nvarchar(500),
	IdUnit int not null,
	IdSuplier int not null, 
	QRCode nvarchar(500),
	BarCode nvarchar(500),

	foreign key(IdUnit) references Unit(Id),
	foreign key (IdSuplier) references Suplier(Id),
)
go

create table UserRole
(
	Id int identity(1, 1) primary key,
	DisplayName nvarchar(500),
)
insert into UserRole values(N'Admin')
insert into UserRole values(N'Nhân viên')
select * from UserRole

create table Users
(
	Id int identity(1, 1) primary key,
	DisplayName nvarchar(500),
	UserName nvarchar(100),
	Password nvarchar(max),
	IdRole int not null,

	foreign key (IdRole) references UserRole(Id),
)
go

insert into Users(DisplayName, UserName, Password, IdRole) values(N'He who remain', N'admin', N'db69fc039dcbd2962cb4d28f5891aae1', 1)
insert into Users(DisplayName, UserName, Password, IdRole) values(N'Stupid', N'staff', N'978aae9bb6bee8fb75de3e4830a1be46', 2)
--delete Users where Id = 3
--truncate table Users -- Xoa sach bang
--update Users set IdRole = 2 where Id = 4
--DBCC CHECKIDENT ('Users', RESEED, 0); ---Dat lai Id tu dau
select * from Users


create table Input
(
	Id nvarchar(128) primary key,
	DateInput Datetime,
)
go

create table InputInfo
(
	Id nvarchar(128) primary key,
	IdObject nvarchar(128) not null,
	IdInput nvarchar(128) not null,
	Count int,
	InputPirce float default 0,
	OutputPrice float default 0,

	foreign key (IdObject) references Object(Id),
	foreign key (IdInput) references Input(Id),
)
go

create table Output
(
	Id nvarchar(128) primary key,
	DateOutput Datetime,
)
go

create table OutputInfo 
(
	Id nvarchar(128) primary key,
	IdObject nvarchar(128) not null,
	IdOutInfo nvarchar(128) not null,
	IdCustomer int not null,
	Count int,
	Status nvarchar(100),

	foreign key (IdObject) references Object(Id),
	foreign key (IdOutInfo) references Output(Id),
	foreign key (IdCustomer) references Customer(Id)
)
go