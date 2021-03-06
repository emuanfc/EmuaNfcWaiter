USE [dbEmuaNfc]
GO
/****** Object:  Table [dbo].[NfcCompany]    Script Date: 14.10.2018 18:43:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NfcCompany](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LogoUrl] [nvarchar](max) NULL,
	[WebSiteUrl] [nvarchar](max) NULL,
	[Adress] [nvarchar](max) NULL,
	[Mail] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.NfcCompany] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NfcCompanyDeskAlarm]    Script Date: 14.10.2018 18:43:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NfcCompanyDeskAlarm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AlarmTypeName] [nvarchar](150) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[DeskId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.NfcCompanyDeskAlarm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NfcDesk]    Script Date: 14.10.2018 18:43:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NfcDesk](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[DeskCategoryId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.NfcDesk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NfcDeskCategory]    Script Date: 14.10.2018 18:43:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NfcDeskCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[OrderNumber] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.NfcDeskCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NfcMenu]    Script Date: 14.10.2018 18:43:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NfcMenu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[OrderNumber] [int] NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[IsAdmin] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.NfcMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NfcTag]    Script Date: 14.10.2018 18:43:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NfcTag](
	[DeskId] [int] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Code] [nvarchar](150) NULL,
	[CreatedDate] [datetime] NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_NfcTag] PRIMARY KEY CLUSTERED 
(
	[DeskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[NfcCompanyDeskAlarm]  WITH CHECK ADD  CONSTRAINT [FK_NfcCompanyDeskAlarm_NfcCompany] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[NfcCompany] ([Id])
GO
ALTER TABLE [dbo].[NfcCompanyDeskAlarm] CHECK CONSTRAINT [FK_NfcCompanyDeskAlarm_NfcCompany]
GO
ALTER TABLE [dbo].[NfcCompanyDeskAlarm]  WITH CHECK ADD  CONSTRAINT [FK_NfcCompanyDeskAlarm_NfcDesk] FOREIGN KEY([DeskId])
REFERENCES [dbo].[NfcDesk] ([Id])
GO
ALTER TABLE [dbo].[NfcCompanyDeskAlarm] CHECK CONSTRAINT [FK_NfcCompanyDeskAlarm_NfcDesk]
GO
ALTER TABLE [dbo].[NfcDesk]  WITH CHECK ADD  CONSTRAINT [FK_NfcDesk_NfcCompany] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[NfcCompany] ([Id])
GO
ALTER TABLE [dbo].[NfcDesk] CHECK CONSTRAINT [FK_NfcDesk_NfcCompany]
GO
ALTER TABLE [dbo].[NfcDesk]  WITH CHECK ADD  CONSTRAINT [FK_NfcDesk_NfcDeskCategory] FOREIGN KEY([DeskCategoryId])
REFERENCES [dbo].[NfcDeskCategory] ([Id])
GO
ALTER TABLE [dbo].[NfcDesk] CHECK CONSTRAINT [FK_NfcDesk_NfcDeskCategory]
GO
ALTER TABLE [dbo].[NfcDesk]  WITH CHECK ADD  CONSTRAINT [FK_NfcDesk_NfcTag] FOREIGN KEY([Id])
REFERENCES [dbo].[NfcTag] ([DeskId])
GO
ALTER TABLE [dbo].[NfcDesk] CHECK CONSTRAINT [FK_NfcDesk_NfcTag]
GO
ALTER TABLE [dbo].[NfcDeskCategory]  WITH CHECK ADD  CONSTRAINT [FK_NfcDeskCategory_NfcCompany] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[NfcCompany] ([Id])
GO
ALTER TABLE [dbo].[NfcDeskCategory] CHECK CONSTRAINT [FK_NfcDeskCategory_NfcCompany]
GO
ALTER TABLE [dbo].[NfcMenu]  WITH CHECK ADD  CONSTRAINT [FK_NfcMenu_NfcCompany] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[NfcCompany] ([Id])
GO
ALTER TABLE [dbo].[NfcMenu] CHECK CONSTRAINT [FK_NfcMenu_NfcCompany]
GO
ALTER TABLE [dbo].[NfcTag]  WITH CHECK ADD  CONSTRAINT [FK_NfcTag_NfcCompany] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[NfcCompany] ([Id])
GO
ALTER TABLE [dbo].[NfcTag] CHECK CONSTRAINT [FK_NfcTag_NfcCompany]
GO
