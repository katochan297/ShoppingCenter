USE [master]
GO
/****** Object:  Database [ShoppingCenter]    Script Date: 10/4/2016 8:56:06 PM ******/
CREATE DATABASE [ShoppingCenter]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShoppingCenter', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ShoppingCenter.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ShoppingCenter_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ShoppingCenter_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ShoppingCenter] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShoppingCenter].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShoppingCenter] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShoppingCenter] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShoppingCenter] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShoppingCenter] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShoppingCenter] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShoppingCenter] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShoppingCenter] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShoppingCenter] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShoppingCenter] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShoppingCenter] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShoppingCenter] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShoppingCenter] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShoppingCenter] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShoppingCenter] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShoppingCenter] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShoppingCenter] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShoppingCenter] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShoppingCenter] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShoppingCenter] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShoppingCenter] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShoppingCenter] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShoppingCenter] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShoppingCenter] SET RECOVERY FULL 
GO
ALTER DATABASE [ShoppingCenter] SET  MULTI_USER 
GO
ALTER DATABASE [ShoppingCenter] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShoppingCenter] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShoppingCenter] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShoppingCenter] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ShoppingCenter] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShoppingCenter', N'ON'
GO
USE [ShoppingCenter]
GO
/****** Object:  Table [dbo].[Banner]    Script Date: 10/4/2016 8:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Banner](
	[BannerID] [int] IDENTITY(1,1) NOT NULL,
	[BannerTitle] [nvarchar](50) NOT NULL,
	[Description] [ntext] NOT NULL,
	[PictureUrl] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Banner] PRIMARY KEY CLUSTERED 
(
	[BannerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/4/2016 8:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryTypeID] [int] NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[Description] [ntext] NULL,
	[PictureUrl] [varchar](100) NULL,
	[Status] [smallint] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategoryType]    Script Date: 10/4/2016 8:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryType](
	[CategoryTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CategoryType] PRIMARY KEY CLUSTERED 
(
	[CategoryTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaskProduct]    Script Date: 10/4/2016 8:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaskProduct](
	[ProductID] [int] NOT NULL,
	[MaskContent] [nvarchar](100) NULL,
	[SkinType] [nvarchar](100) NULL,
 CONSTRAINT [PK_MaskProduct] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 10/4/2016 8:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
	[Path] [nvarchar](50) NOT NULL,
	[Icon] [nvarchar](50) NULL,
	[ParentID] [int] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/4/2016 8:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductSKU] [varchar](50) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[CategoryID] [int] NULL,
	[Description] [ntext] NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[UnitOnOrder] [smallint] NOT NULL,
	[OrderLevel] [smallint] NULL,
	[PictureUrl] [varchar](100) NULL,
	[Status] [smallint] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 10/4/2016 8:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductImage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[ImageUrl] [varchar](100) NULL,
 CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Banner] ON 

GO
INSERT [dbo].[Banner] ([BannerID], [BannerTitle], [Description], [PictureUrl]) VALUES (1, N'Edited from user2', N'htnkt', N'trkh')
GO
INSERT [dbo].[Banner] ([BannerID], [BannerTitle], [Description], [PictureUrl]) VALUES (3, N'Title2', N'qaaa', N'111')
GO
INSERT [dbo].[Banner] ([BannerID], [BannerTitle], [Description], [PictureUrl]) VALUES (4, N'title kato', N'aa', N'111')
GO
INSERT [dbo].[Banner] ([BannerID], [BannerTitle], [Description], [PictureUrl]) VALUES (5, N'title kato', N'aa', N'111')
GO
SET IDENTITY_INSERT [dbo].[Banner] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTypeID], [CategoryName], [Description], [PictureUrl], [Status]) VALUES (1, 2, N'Sheet Mask', N'', NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[CategoryType] ON 

GO
INSERT [dbo].[CategoryType] ([CategoryTypeID], [TypeName]) VALUES (2, N'Mask')
GO
SET IDENTITY_INSERT [dbo].[CategoryType] OFF
GO
INSERT [dbo].[MaskProduct] ([ProductID], [MaskContent], [SkinType]) VALUES (1, N'mask content1', N'skin1')
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

GO
INSERT [dbo].[Menu] ([MenuID], [Title], [Path], [Icon], [ParentID], [Status]) VALUES (1, N'Home', N'http://localhost:1668/Presentation/Home', NULL, NULL, 1)
GO
INSERT [dbo].[Menu] ([MenuID], [Title], [Path], [Icon], [ParentID], [Status]) VALUES (4, N'Mask', N'http://localhost:1668/Presentation/Mask', NULL, NULL, 1)
GO
INSERT [dbo].[Menu] ([MenuID], [Title], [Path], [Icon], [ParentID], [Status]) VALUES (5, N'SheetMask', N'#', NULL, 4, 1)
GO
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

GO
INSERT [dbo].[Product] ([ProductID], [ProductSKU], [ProductName], [CategoryID], [Description], [Quantity], [Price], [UnitOnOrder], [OrderLevel], [PictureUrl], [Status]) VALUES (1, N'sku1', N'name1', 1, N'des1', 1, CAST(300000 AS Decimal(18, 0)), 1, 1, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_CategoryType] FOREIGN KEY([CategoryTypeID])
REFERENCES [dbo].[CategoryType] ([CategoryTypeID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_CategoryType]
GO
ALTER TABLE [dbo].[MaskProduct]  WITH CHECK ADD  CONSTRAINT [FK_MaskProduct_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MaskProduct] CHECK CONSTRAINT [FK_MaskProduct_Product]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Menu] FOREIGN KEY([ParentID])
REFERENCES [dbo].[Menu] ([MenuID])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Menu]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Product]
GO
USE [master]
GO
ALTER DATABASE [ShoppingCenter] SET  READ_WRITE 
GO
