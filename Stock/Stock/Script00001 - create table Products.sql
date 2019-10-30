create table Products 
(
	[Id] int primary key identity(1,1),
	[Waybill] int not null,
	[Name] nvarchar(MAX) not null,
	[Count] int not null
)