USE [master]
GO
/****** Object:  Database [Koala]    Script Date: 11-03-20 15:20:20 ******/
CREATE DATABASE [Koala]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Koala', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLHACKATHON\MSSQL\DATA\Koala.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Koala_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLHACKATHON\MSSQL\DATA\Koala_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Koala] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Koala].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Koala] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Koala] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Koala] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Koala] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Koala] SET ARITHABORT OFF 
GO
ALTER DATABASE [Koala] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Koala] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Koala] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Koala] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Koala] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Koala] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Koala] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Koala] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Koala] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Koala] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Koala] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Koala] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Koala] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Koala] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Koala] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Koala] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Koala] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Koala] SET RECOVERY FULL 
GO
ALTER DATABASE [Koala] SET  MULTI_USER 
GO
ALTER DATABASE [Koala] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Koala] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Koala] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Koala] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Koala] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Koala', N'ON'
GO
ALTER DATABASE [Koala] SET QUERY_STORE = OFF
GO
USE [Koala]
GO
/****** Object:  User [KoalaUser]    Script Date: 11-03-20 15:20:21 ******/
CREATE USER [KoalaUser] FOR LOGIN [KoalaUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [KoalaUser]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11-03-20 15:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Activities]    Script Date: 11-03-20 15:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IndicatorId] [int] NULL,
 CONSTRAINT [PK_Activities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivitySites]    Script Date: 11-03-20 15:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivitySites](
	[ActivityId] [int] NOT NULL,
	[SiteId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11-03-20 15:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11-03-20 15:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11-03-20 15:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11-03-20 15:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11-03-20 15:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11-03-20 15:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11-03-20 15:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 11-03-20 15:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nme] [nvarchar](max) NULL,
	[Zip] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Financials]    Script Date: 11-03-20 15:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Financials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Objective] [decimal](18, 2) NOT NULL,
	[ActualSale] [decimal](18, 2) NOT NULL,
	[ReportDate] [datetime2](7) NOT NULL,
	[ActivityId] [int] NULL,
 CONSTRAINT [PK_Financials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Indicators]    Script Date: 11-03-20 15:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Indicators](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Indicators] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sites]    Script Date: 11-03-20 15:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sites](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[CityId] [int] NULL,
 CONSTRAINT [PK_Sites] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200309180201_v1', N'3.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200309180201_v1', N'3.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200309180201_v1', N'3.1.2')
SET IDENTITY_INSERT [dbo].[Activities] ON 

INSERT [dbo].[Activities] ([Id], [Name], [IndicatorId]) VALUES (1, N'Eat', 1)
INSERT [dbo].[Activities] ([Id], [Name], [IndicatorId]) VALUES (2, N'Grow', 2)
INSERT [dbo].[Activities] ([Id], [Name], [IndicatorId]) VALUES (3, N'Learn', 3)
SET IDENTITY_INSERT [dbo].[Activities] OFF
SET IDENTITY_INSERT [dbo].[Financials] ON 

INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (1, N'Eat_January', CAST(22000.00 AS Decimal(18, 2)), CAST(36450.00 AS Decimal(18, 2)), CAST(N'2019-01-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (2, N'Eat_February', CAST(22000.00 AS Decimal(18, 2)), CAST(28846.00 AS Decimal(18, 2)), CAST(N'2019-01-02T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (3, N'Eat_March', CAST(22000.00 AS Decimal(18, 2)), CAST(37297.00 AS Decimal(18, 2)), CAST(N'2019-03-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (4, N'Eat_April', CAST(22000.00 AS Decimal(18, 2)), CAST(40650.00 AS Decimal(18, 2)), CAST(N'2019-04-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (5, N'Eat_May', CAST(22000.00 AS Decimal(18, 2)), CAST(38856.00 AS Decimal(18, 2)), CAST(N'2019-05-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (6, N'Eat_June', CAST(22000.00 AS Decimal(18, 2)), CAST(17729.00 AS Decimal(18, 2)), CAST(N'2019-06-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (7, N'Grow_January', CAST(4000.00 AS Decimal(18, 2)), CAST(5841.00 AS Decimal(18, 2)), CAST(N'2019-01-01T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (8, N'Grow_February', CAST(4000.00 AS Decimal(18, 2)), CAST(3865.00 AS Decimal(18, 2)), CAST(N'2019-02-01T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (9, N'Grow_March', CAST(4000.00 AS Decimal(18, 2)), CAST(6201.00 AS Decimal(18, 2)), CAST(N'2019-03-01T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (10, N'Grow_April', CAST(4000.00 AS Decimal(18, 2)), CAST(2067.00 AS Decimal(18, 2)), CAST(N'2019-04-01T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (11, N'Grow_May', CAST(4000.00 AS Decimal(18, 2)), CAST(2984.00 AS Decimal(18, 2)), CAST(N'2019-05-01T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (12, N'Grow_June', CAST(4000.00 AS Decimal(18, 2)), CAST(3052.00 AS Decimal(18, 2)), CAST(N'2019-06-01T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (13, N'Learn_January', CAST(4000.00 AS Decimal(18, 2)), CAST(3454.00 AS Decimal(18, 2)), CAST(N'2019-01-01T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (14, N'Learn_February', CAST(4000.00 AS Decimal(18, 2)), CAST(2706.00 AS Decimal(18, 2)), CAST(N'2019-02-01T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (15, N'Learn_March', CAST(4000.00 AS Decimal(18, 2)), CAST(987.00 AS Decimal(18, 2)), CAST(N'2019-03-01T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (16, N'Learn_April', CAST(4000.00 AS Decimal(18, 2)), CAST(1462.00 AS Decimal(18, 2)), CAST(N'2019-04-01T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (17, N'Learn_May', CAST(4000.00 AS Decimal(18, 2)), CAST(2045.00 AS Decimal(18, 2)), CAST(N'2019-05-01T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (18, N'Learn_June', CAST(4000.00 AS Decimal(18, 2)), CAST(2862.00 AS Decimal(18, 2)), CAST(N'2019-06-01T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (19, N'Eat_July', CAST(22000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2019-07-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (20, N'Eat_August', CAST(22000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2019-08-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (21, N'Eat_September', CAST(22000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2019-09-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (22, N'Eat_October', CAST(22000.00 AS Decimal(18, 2)), CAST(29180.00 AS Decimal(18, 2)), CAST(N'2019-10-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (23, N'Eat_November', CAST(22000.00 AS Decimal(18, 2)), CAST(24109.00 AS Decimal(18, 2)), CAST(N'2019-11-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (24, N'Eat_December', CAST(22000.00 AS Decimal(18, 2)), CAST(29234.00 AS Decimal(18, 2)), CAST(N'2019-12-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (25, N'Grow_July', CAST(4000.00 AS Decimal(18, 2)), CAST(1493.00 AS Decimal(18, 2)), CAST(N'2019-07-01T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (26, N'Grow_August', CAST(4000.00 AS Decimal(18, 2)), CAST(10516.00 AS Decimal(18, 2)), CAST(N'2019-08-01T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (27, N'Grow_September', CAST(4000.00 AS Decimal(18, 2)), CAST(4448.00 AS Decimal(18, 2)), CAST(N'2019-09-01T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (28, N'Grow_October', CAST(4000.00 AS Decimal(18, 2)), CAST(2524.00 AS Decimal(18, 2)), CAST(N'2019-10-01T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (29, N'Grow_November', CAST(7500.00 AS Decimal(18, 2)), CAST(9699.00 AS Decimal(18, 2)), CAST(N'2019-11-01T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (30, N'Grow_December', CAST(7500.00 AS Decimal(18, 2)), CAST(8122.00 AS Decimal(18, 2)), CAST(N'2019-12-01T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (31, N'Learn_July', CAST(4000.00 AS Decimal(18, 2)), CAST(1449.00 AS Decimal(18, 2)), CAST(N'2019-07-01T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (32, N'Learn_August', CAST(4000.00 AS Decimal(18, 2)), CAST(1472.00 AS Decimal(18, 2)), CAST(N'2019-08-01T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (33, N'Learn_September', CAST(4000.00 AS Decimal(18, 2)), CAST(1960.00 AS Decimal(18, 2)), CAST(N'2019-09-01T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (34, N'Learn_October', CAST(4000.00 AS Decimal(18, 2)), CAST(3045.00 AS Decimal(18, 2)), CAST(N'2019-10-01T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (35, N'Learn_November', CAST(4000.00 AS Decimal(18, 2)), CAST(3695.00 AS Decimal(18, 2)), CAST(N'2019-11-01T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Financials] ([Id], [Name], [Objective], [ActualSale], [ReportDate], [ActivityId]) VALUES (36, N'Learn_December', CAST(4000.00 AS Decimal(18, 2)), CAST(1705.00 AS Decimal(18, 2)), CAST(N'2019-12-01T00:00:00.0000000' AS DateTime2), 3)
SET IDENTITY_INSERT [dbo].[Financials] OFF
SET IDENTITY_INSERT [dbo].[Indicators] ON 

INSERT [dbo].[Indicators] ([Id], [Name]) VALUES (1, N'economic')
INSERT [dbo].[Indicators] ([Id], [Name]) VALUES (2, N'environmental')
INSERT [dbo].[Indicators] ([Id], [Name]) VALUES (3, N'social')
SET IDENTITY_INSERT [dbo].[Indicators] OFF
ALTER TABLE [dbo].[Activities]  WITH CHECK ADD  CONSTRAINT [FK_Activities_Indicators] FOREIGN KEY([IndicatorId])
REFERENCES [dbo].[Indicators] ([Id])
GO
ALTER TABLE [dbo].[Activities] CHECK CONSTRAINT [FK_Activities_Indicators]
GO
ALTER TABLE [dbo].[ActivitySites]  WITH CHECK ADD  CONSTRAINT [FK_ActivitySites_Activities] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[Activities] ([Id])
GO
ALTER TABLE [dbo].[ActivitySites] CHECK CONSTRAINT [FK_ActivitySites_Activities]
GO
ALTER TABLE [dbo].[ActivitySites]  WITH CHECK ADD  CONSTRAINT [FK_ActivitySites_Sites] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Sites] ([Id])
GO
ALTER TABLE [dbo].[ActivitySites] CHECK CONSTRAINT [FK_ActivitySites_Sites]
GO
ALTER TABLE [dbo].[Financials]  WITH CHECK ADD  CONSTRAINT [FK_Financials_Activities] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[Activities] ([Id])
GO
ALTER TABLE [dbo].[Financials] CHECK CONSTRAINT [FK_Financials_Activities]
GO
ALTER TABLE [dbo].[Sites]  WITH CHECK ADD  CONSTRAINT [FK_Sites_Cities] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Sites] CHECK CONSTRAINT [FK_Sites_Cities]
GO
USE [master]
GO
ALTER DATABASE [Koala] SET  READ_WRITE 
GO
