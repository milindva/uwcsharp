USE [Inventory]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 4/1/2017 5:58:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[PricePerItem] [money] NOT NULL,
	[QtyOnHand] [int] NOT NULL,
	[OurCostPerItem] [money] NOT NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_ITEM] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


-- Insert sample data


  INSERT INTO dbo.Products
  
  select 'Wireless Keyboard', 55.50, 50, 38.50, GETDATE()
  UNION
  select 'Wireless Mouse', 35.50, 150, 22.50, GETDATE()
  UNION
  select 'Mouse pad', 8.50, 200, 4.50, GETDATE()
  UNION
  select 'Portable hard drive', 105.50, 45, 85.50, GETDATE()
  UNION
  select 'USB cable', 10.50, 55, 6.50, GETDATE()

  GO