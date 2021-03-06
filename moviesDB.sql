USE [master]
GO
/****** Object:  Database [MoviesWebApp]    Script Date: 4/09/2020 11:01:43 am ******/
CREATE DATABASE [MoviesWebApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MoviesWebApp', FILENAME = N'C:\Users\User\Desktop\MSSQL15.SQLEXPRESS\MSSQL\DATA\MoviesWebApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MoviesWebApp_log', FILENAME = N'C:\Users\User\Desktop\MSSQL15.SQLEXPRESS\MSSQL\DATA\MoviesWebApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MoviesWebApp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MoviesWebApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MoviesWebApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MoviesWebApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MoviesWebApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MoviesWebApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MoviesWebApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [MoviesWebApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MoviesWebApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MoviesWebApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MoviesWebApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MoviesWebApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MoviesWebApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MoviesWebApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MoviesWebApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MoviesWebApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MoviesWebApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MoviesWebApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MoviesWebApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MoviesWebApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MoviesWebApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MoviesWebApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MoviesWebApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MoviesWebApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MoviesWebApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MoviesWebApp] SET  MULTI_USER 
GO
ALTER DATABASE [MoviesWebApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MoviesWebApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MoviesWebApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MoviesWebApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MoviesWebApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MoviesWebApp] SET QUERY_STORE = OFF
GO
USE [MoviesWebApp]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/09/2020 11:01:44 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressModel]    Script Date: 4/09/2020 11:01:44 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressModel](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[PinCode] [int] NOT NULL,
 CONSTRAINT [PK_AddressModel] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoviesModel]    Script Date: 4/09/2020 11:01:44 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoviesModel](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[MovieName] [nvarchar](max) NULL,
	[Released] [datetime2](7) NOT NULL,
	[Genre] [nvarchar](max) NULL,
	[Rating] [int] NOT NULL,
	[IsBlockBuster] [bit] NOT NULL,
 CONSTRAINT [PK_MoviesModel] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalsModel]    Script Date: 4/09/2020 11:01:44 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalsModel](
	[RentalsId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
	[BookingDate] [datetime2](7) NOT NULL,
	[IsDeliveryAddress] [bit] NOT NULL,
 CONSTRAINT [PK_RentalsModel] PRIMARY KEY CLUSTERED 
(
	[RentalsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersModel]    Script Date: 4/09/2020 11:01:44 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersModel](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_UsersModel] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200901102404_InitialCreate', N'3.1.7')
GO
SET IDENTITY_INSERT [dbo].[AddressModel] ON 

INSERT [dbo].[AddressModel] ([AddressId], [Address], [PinCode]) VALUES (1, N'Hamilton', 3210)
SET IDENTITY_INSERT [dbo].[AddressModel] OFF
GO
SET IDENTITY_INSERT [dbo].[MoviesModel] ON 

INSERT [dbo].[MoviesModel] ([MovieId], [MovieName], [Released], [Genre], [Rating], [IsBlockBuster]) VALUES (1, N'pbx1', CAST(N'2020-09-01T10:54:00.0000000' AS DateTime2), N'fight', 10, 1)
INSERT [dbo].[MoviesModel] ([MovieId], [MovieName], [Released], [Genre], [Rating], [IsBlockBuster]) VALUES (2, N'pb26', CAST(N'2020-08-10T00:00:00.0000000' AS DateTime2), N'action', 99, 1)
SET IDENTITY_INSERT [dbo].[MoviesModel] OFF
GO
SET IDENTITY_INSERT [dbo].[UsersModel] ON 

INSERT [dbo].[UsersModel] ([UserId], [FirstName], [LastName], [Email], [AddressId]) VALUES (1, N'Jot', N'Singh', N'jot@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[UsersModel] OFF
GO
/****** Object:  Index [IX_RentalsModel_MovieId]    Script Date: 4/09/2020 11:01:44 am ******/
CREATE NONCLUSTERED INDEX [IX_RentalsModel_MovieId] ON [dbo].[RentalsModel]
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RentalsModel_UserId]    Script Date: 4/09/2020 11:01:44 am ******/
CREATE NONCLUSTERED INDEX [IX_RentalsModel_UserId] ON [dbo].[RentalsModel]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsersModel_AddressId]    Script Date: 4/09/2020 11:01:44 am ******/
CREATE NONCLUSTERED INDEX [IX_UsersModel_AddressId] ON [dbo].[UsersModel]
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RentalsModel]  WITH CHECK ADD  CONSTRAINT [FK_RentalsModel_MoviesModel_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[MoviesModel] ([MovieId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RentalsModel] CHECK CONSTRAINT [FK_RentalsModel_MoviesModel_MovieId]
GO
ALTER TABLE [dbo].[RentalsModel]  WITH CHECK ADD  CONSTRAINT [FK_RentalsModel_UsersModel_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UsersModel] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RentalsModel] CHECK CONSTRAINT [FK_RentalsModel_UsersModel_UserId]
GO
ALTER TABLE [dbo].[UsersModel]  WITH CHECK ADD  CONSTRAINT [FK_UsersModel_AddressModel_AddressId] FOREIGN KEY([AddressId])
REFERENCES [dbo].[AddressModel] ([AddressId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersModel] CHECK CONSTRAINT [FK_UsersModel_AddressModel_AddressId]
GO
USE [master]
GO
ALTER DATABASE [MoviesWebApp] SET  READ_WRITE 
GO
