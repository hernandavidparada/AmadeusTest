USE [prueba]
GO

/****** Object:  Table [dbo].[Tabla1]    Script Date: 16/07/2024 9:27:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
	[EntryDate] [nvarchar](50) NOT NULL,
	[Cost] [int] NOT NULL,
	[Units] [int] NOT NULL,
	[StoreNumber] [int] NOT NULL,
	[Dispatcher] [nvarchar](50) NOT NULL
	

) ON [PRIMARY]
GO


