CREATE TABLE [dbo].[Articoli](
	[Id] [int] NOT NULL,
	[CodArticolo] [nvarchar](50) NOT NULL,
	[Prezzo] [decimal](15, 5) NOT NULL,
 CONSTRAINT [PK_Articoli] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Sales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Region] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[ItemType] [nvarchar](50) NULL,
	[SalesChannel] [nvarchar](50) NULL,
	[OrderPriority] [nvarchar](50) NULL,
	[OrderDate] [datetime] NULL,
	[OrderID] [nvarchar](50) NULL,
	[ShipDate] [datetime] NULL,
	[UnitsSold] [decimal](15, 7) NULL,
	[UnitPrice] [decimal](15, 7) NULL,
	[UnitCost] [decimal](15, 7) NULL,
	[TotalRevenue] [decimal](15, 7) NULL,
	[TotalProfit] [decimal](15, 7) NULL,
	[TotalCost] [decimal](15, 7) NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO