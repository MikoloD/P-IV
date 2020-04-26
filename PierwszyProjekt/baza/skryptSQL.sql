USE [master]
GO
/****** Object:  Database [DaneMeteo]    Script Date: 26.04.2020 20:59:51 ******/
CREATE DATABASE [DaneMeteo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DaneMeteo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DaneMeteo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DaneMeteo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DaneMeteo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DaneMeteo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DaneMeteo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DaneMeteo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DaneMeteo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DaneMeteo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DaneMeteo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DaneMeteo] SET ARITHABORT OFF 
GO
ALTER DATABASE [DaneMeteo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DaneMeteo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DaneMeteo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DaneMeteo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DaneMeteo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DaneMeteo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DaneMeteo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DaneMeteo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DaneMeteo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DaneMeteo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DaneMeteo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DaneMeteo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DaneMeteo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DaneMeteo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DaneMeteo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DaneMeteo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DaneMeteo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DaneMeteo] SET RECOVERY FULL 
GO
ALTER DATABASE [DaneMeteo] SET  MULTI_USER 
GO
ALTER DATABASE [DaneMeteo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DaneMeteo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DaneMeteo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DaneMeteo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DaneMeteo] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DaneMeteo', N'ON'
GO
ALTER DATABASE [DaneMeteo] SET QUERY_STORE = OFF
GO
USE [DaneMeteo]
GO
/****** Object:  Table [dbo].[Pomiar]    Script Date: 26.04.2020 20:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pomiar](
	[IdPomiaru] [nvarchar](255) NOT NULL,
	[NazwaPomiaru] [nvarchar](255) NULL,
	[Data] [date] NULL,
	[Godzina] [time](0) NULL,
	[Wynik] [float] NULL,
	[Jednostka] [nvarchar](25) NULL,
	[NazwaStacji] [nvarchar](5) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stacja]    Script Date: 26.04.2020 20:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stacja](
	[NazwaStacji] [nvarchar](5)NOT NULL,
	[Miasto] [nvarchar](255) NULL,
	[Ulica] [nchar](255) NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [DaneMeteo] SET  READ_WRITE 
GO
