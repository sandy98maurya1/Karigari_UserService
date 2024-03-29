USE [master]
GO 
/****** Object:  Database [KarigariUserManagement]    Script Date: 25-01-2022 14:06:47 ******/
CREATE DATABASE [KarigariUserManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KarigariUserManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\KarigariUserManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KarigariUserManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\KarigariUserManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [KarigariUserManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KarigariUserManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KarigariUserManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KarigariUserManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KarigariUserManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KarigariUserManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KarigariUserManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KarigariUserManagement] SET  MULTI_USER 
GO
ALTER DATABASE [KarigariUserManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KarigariUserManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KarigariUserManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KarigariUserManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KarigariUserManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KarigariUserManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [KarigariUserManagement] SET QUERY_STORE = OFF
GO
USE [KarigariUserManagement]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 25-01-2022 14:06:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Village] [nvarchar](max) NULL,
	[Taluka] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Zip] [nvarchar](max) NULL,
	[UserId] [bigint] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 25-01-2022 14:06:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[CompanyType] [nvarchar](max) NULL,
	[CompanyOwner] [nvarchar](max) NULL,
	[ContactPerson] [nvarchar](max) NULL,
	[ContactNo] [nvarchar](max) NULL,
	[CompanyEmail] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[BusinessContactNo] [nvarchar](max) NULL,
	[AddressId] [int] NULL,
	[Role] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[Disabled] [bit] NULL,
 CONSTRAINT [PK_Employer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company_Address]    Script Date: 25-01-2022 14:06:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company_Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Village] [nvarchar](max) NULL,
	[Taluka] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Zip] [nvarchar](max) NULL,
	[CompanyId] [bigint] NOT NULL,
 CONSTRAINT [PK_C_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobType]    Script Date: 25-01-2022 14:06:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobName] [nvarchar](max) NULL,
 CONSTRAINT [PK_JobType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location_City]    Script Date: 25-01-2022 14:06:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location_City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[StateID] [int] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location_State]    Script Date: 25-01-2022 14:06:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location_State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25-01-2022 14:06:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Contact] [nvarchar](max) NULL,
	[AlternetContact] [nvarchar](max) NULL,
	[MaritalStatus] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[Address] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
	[WorkerType] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[IsMobileVerified] [bit] NOT NULL,
	[DeviceID] [int] NULL,
	[Enabled] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Worker_Job_Profile]    Script Date: 25-01-2022 14:06:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worker_Job_Profile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Duration] [int] NULL,
	[AvailableDate] [nvarchar](max) NULL,
	[JobTypeID] [int] NULL,
	[LocationID] [int] NULL,
	[UserID] [bigint] NULL,
 CONSTRAINT [PK_Worker_Job_Profile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Employer_AddressId]    Script Date: 25-01-2022 14:06:48 ******/
CREATE NONCLUSTERED INDEX [IX_Employer_AddressId] ON [dbo].[Company]
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Address] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Address]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_C_Address_Address] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_C_Address_Address]
GO
ALTER TABLE [dbo].[Company_Address]  WITH CHECK ADD  CONSTRAINT [FK_Company_Address] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Company_Address] CHECK CONSTRAINT [FK_Company_Address]
GO
ALTER TABLE [dbo].[Location_City]  WITH CHECK ADD  CONSTRAINT [FK_Location_City_State] FOREIGN KEY([Id])
REFERENCES [dbo].[Location_State] ([Id])
GO
ALTER TABLE [dbo].[Location_City] CHECK CONSTRAINT [FK_Location_City_State]
GO
ALTER TABLE [dbo].[Worker_Job_Profile]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Job_ID] FOREIGN KEY([JobTypeID])
REFERENCES [dbo].[JobType] ([Id])
GO
ALTER TABLE [dbo].[Worker_Job_Profile] CHECK CONSTRAINT [FK_Worker_Job_ID]
GO
ALTER TABLE [dbo].[Worker_Job_Profile]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Job_User_ID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Worker_Job_Profile] CHECK CONSTRAINT [FK_Worker_Job_User_ID]
GO
ALTER TABLE [dbo].[Worker_Job_Profile]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Location_ID] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Location_State] ([Id])
GO
ALTER TABLE [dbo].[Worker_Job_Profile] CHECK CONSTRAINT [FK_Worker_Location_ID]
GO
USE [master]
GO
ALTER DATABASE [KarigariUserManagement] SET  READ_WRITE 
GO
