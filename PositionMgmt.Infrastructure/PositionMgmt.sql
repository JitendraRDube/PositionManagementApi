USE [PositionManagementDB]
GO
/****** Object:  Table [dbo].[ActionMaster]    Script Date: 14-06-2025 04:36:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionMaster](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ActionType] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecurityMaster]    Script Date: 14-06-2025 04:36:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SecurityCode] [varchar](20) NULL,
	[SecurityName] [varchar](200) NULL,
 CONSTRAINT [PK_SecurityMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecurityPrice]    Script Date: 14-06-2025 04:36:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityPrice](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SecurityId] [bigint] NOT NULL,
	[Price] [decimal](18, 6) NULL,
	[CreationDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_SecurityPriceId] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 14-06-2025 04:36:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionId] [bigint] IDENTITY(1,1) NOT NULL,
	[TradeId] [bigint] NOT NULL,
	[Version] [bigint] NOT NULL,
	[SecurityId] [int] NULL,
	[Quantity] [int] NULL,
	[TransactionTypeId] [int] NULL,
	[ActionTypeId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_TradeHistory] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionTypeMaster]    Script Date: 14-06-2025 04:36:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionTypeMaster](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionType] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SecurityPrice]  WITH CHECK ADD  CONSTRAINT [FK_SecurityPrice_SecurityMaster] FOREIGN KEY([SecurityId])
REFERENCES [dbo].[SecurityMaster] ([Id])
GO
ALTER TABLE [dbo].[SecurityPrice] CHECK CONSTRAINT [FK_SecurityPrice_SecurityMaster]
GO

USE [PositionManagementDB]
GO

INSERT INTO [dbo].[ActionMaster] ([ActionType]) VALUES ('Buy')
INSERT INTO [dbo].[ActionMaster] ([ActionType]) VALUES ('Sell')


INSERT INTO [dbo].[TransactionTypeMaster] ([TransactionType]) VALUES ('INSERT')
INSERT INTO [dbo].[TransactionTypeMaster] ([TransactionType]) VALUES ('UPDATE')
INSERT INTO [dbo].[TransactionTypeMaster] ([TransactionType]) VALUES ('CANCEL')
GO


