USE [CustomersDb]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/1/2020 1:35:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[TS] [smalldatetime] NOT NULL,
	[Active] [bit] NOT NULL,
	[Blocked] [bit] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/1/2020 1:35:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Total] [decimal](19, 4) NOT NULL,
	[Currency] [char](3) NOT NULL,
	[TS] [smalldatetime] NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([Id], [Username], [Password], [FirstName], [LastName], [Email], [TS], [Active], [Blocked]) VALUES (1, N'coding', N'211fa152a7cd822484e866907dbfff0bfc39ea5188cc2a4942f60d36966bae6c', N'Coding', N'Sonata', N'coding@codingsonata.com', CAST(N'2020-10-30T00:00:00' AS SmallDateTime), 1, 1)
GO
INSERT [dbo].[Customer] ([Id], [Username], [Password], [FirstName], [LastName], [Email], [TS], [Active], [Blocked]) VALUES (2, N'test', N'b822f1cd2dcfc685b47e83e3980289fd5d8e3ff3a82def24d7d1d68bb272eb32', N'Test', N'Testing', N'testing@codingsonata.com', CAST(N'2020-10-30T00:00:00' AS SmallDateTime), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 
GO
INSERT [dbo].[Order] ([Id], [Status], [Quantity], [Total], [Currency], [TS], [CustomerId]) VALUES (1, N'Processed', 5, CAST(120.0000 AS Decimal(19, 4)), N'USD', CAST(N'2020-10-25T00:00:00' AS SmallDateTime), 1)
GO
INSERT [dbo].[Order] ([Id], [Status], [Quantity], [Total], [Currency], [TS], [CustomerId]) VALUES (2, N'Completed', 2, CAST(750.0000 AS Decimal(19, 4)), N'USD', CAST(N'2020-10-25T00:00:00' AS SmallDateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO