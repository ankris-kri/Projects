USE [master]
GO
/****** Object:  Database [Physician]    Script Date: 3/22/2016 6:20:36 PM ******/
CREATE DATABASE [Physician]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Physician', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Physician.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Physician_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Physician_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Physician] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Physician].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Physician] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Physician] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Physician] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Physician] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Physician] SET ARITHABORT OFF 
GO
ALTER DATABASE [Physician] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Physician] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Physician] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Physician] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Physician] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Physician] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Physician] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Physician] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Physician] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Physician] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Physician] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Physician] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Physician] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Physician] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Physician] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Physician] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Physician] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Physician] SET RECOVERY FULL 
GO
ALTER DATABASE [Physician] SET  MULTI_USER 
GO
ALTER DATABASE [Physician] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Physician] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Physician] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Physician] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Physician] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Physician', N'ON'
GO
USE [Physician]
GO
/****** Object:  Table [dbo].[Hospital]    Script Date: 3/22/2016 6:20:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hospital](
	[HospitalID] [int] IDENTITY(1,1) NOT NULL,
	[HospitalName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Hospital] PRIMARY KEY CLUSTERED 
(
	[HospitalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Physician]    Script Date: 3/22/2016 6:20:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Physician](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[NPI] [varchar](50) NOT NULL,
	[HospitalID] [int] NOT NULL,
	[SpecialtyID] [int] NOT NULL,
	[ConsultationCharge] [numeric](10, 2) NOT NULL,
 CONSTRAINT [PK_Physician] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Specialty]    Script Date: 3/22/2016 6:20:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Specialty](
	[SpecialtyID] [int] IDENTITY(1,1) NOT NULL,
	[SpecialtyName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Specialty] PRIMARY KEY CLUSTERED 
(
	[SpecialtyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [Physician] SET  READ_WRITE 
GO
