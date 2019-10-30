create table Waybills
(
	[Id] int primary key identity(1, 1),
	[ProductId] int not null,
	[StockerId] int not null,
	[Provider] nvarchar(MAX) null,
	[Receiver] nvarchar(MAX) null,
	[DeliveryDate] datetime null,
	[DepartureDate] datetime null,
	[IsExport] bit not null
)