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
USE [master]
GO
ALTER DATABASE [CqrsPizzeria] SET  READ_WRITE 
GO
