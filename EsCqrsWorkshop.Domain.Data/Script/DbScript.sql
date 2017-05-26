USE [master]
GO
/****** Object:  Database [CqrsPizzeria]    Script Date: 26/05/2017 06:52:57 ******/
CREATE DATABASE [CqrsPizzeria]
GO
USE [CqrsPizzeria]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 26/05/2017 06:52:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerName] [nvarchar](250) NOT NULL,
	[PizzaTaste] [nvarchar](250) NOT NULL,
	[PizzeriaId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Completed] [bit]
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pizzerie]    Script Date: 26/05/2017 06:52:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pizzerie](
	[Id] [uniqueidentifier] NOT NULL,
	[Version] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Pizzerie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [CqrsPizzeria]
GO

/****** Object:  Table [dbo].[DomainEventCommits]    Script Date: 26/05/2017 07:04:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DomainEventCommits](
	[EventId] [uniqueidentifier] NOT NULL,
	[AggregateId] [uniqueidentifier] NOT NULL,
	[PublishedOn] [datetimeoffset](7) NOT NULL,
	[TransactionId] [uniqueidentifier] NOT NULL,
	[EventType] [nvarchar](max) NULL,
	[EventBlob] [nvarchar](max) NULL,
	[Version] [int] NOT NULL,
	[StreamGroup] [nvarchar](max) NULL,
	[IsDispatched] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.DomainEventCommits] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[DomainEventCommits] ADD  DEFAULT ((0)) FOR [IsDispatched]
GO

/****** Object:  View [dbo].[PizzerieView]    Script Date: 26/05/2017 06:52:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PizzerieView]
AS
SELECT        Id, Name
FROM            dbo.Pizzerie
GO

CREATE VIEW [dbo].[OrdersView]
AS
SELECT        dbo.Orders.Id, dbo.Orders.CustomerName, dbo.Orders.PizzaTaste, dbo.Orders.PizzeriaId, dbo.Orders.CreatedAt, dbo.Pizzerie.Name AS PizzeriaName
FROM            dbo.Orders INNER JOIN
                         dbo.Pizzerie ON dbo.Orders.PizzeriaId = dbo.Pizzerie.Id
WHERE dbo.Orders.Completed = 0

GO
USE [master]
GO
ALTER DATABASE [CqrsPizzeria] SET  READ_WRITE 
GO
