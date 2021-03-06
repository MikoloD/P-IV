USE [master]
GO
/****** Object:  Database [DaneMeteo]    Script Date: 01.05.2020 21:42:09 ******/
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
/****** Object:  Table [dbo].[Pomiar]    Script Date: 01.05.2020 21:42:10 ******/
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
	[NazwaStacji] [nvarchar](5)NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stacja]    Script Date: 01.05.2020 21:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stacja](
	[NazwaStacji] [nvarchar](5) NOT NULL,
	[Miasto] [nvarchar](255) NULL,
	[Ulica] [nchar](255) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw1', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), 1.1, N'm/s', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw2', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 2.1, N'm/s', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw3', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 2.2, N'm/s', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw4', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), 2.1, N'm/s', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw5', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), 2.1, N'm/s', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw6', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 2.3, N'm/s', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw7', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 3, N'm/s', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw8', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), 3.3, N'm/s', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw9', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), 1.9, N'm/s', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw10', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 3.3, N'm/s', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw11', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 1.9, N'm/s', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw12', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), 1.9, N'm/s', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw13', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), 4.1, N'm/s', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw14', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 4.4, N'm/s', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw15', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 4.5, N'm/s', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'pw16', N'Prędkość Wiatru', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), 3.9, N'm/s', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op1', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), 0.2, N'l/m2', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op2', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 0.6, N'l/m2', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op3', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 1.9, N'l/m2', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op4', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), 1.7, N'l/m2', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op5', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), 0, N'l/m2', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op6', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 0.5, N'l/m2', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op7', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 0.2, N'l/m2', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op8', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), 1.4, N'l/m2', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op9', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), 0, N'l/m2', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op10', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 0, N'l/m2', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op11', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 0, N'l/m2', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op12', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), 0, N'l/m2', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op13', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), 0, N'l/m2', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op14', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 0, N'l/m2', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op15', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 0, N'l/m2', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'op16', N'Opad', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), 0, N'l/m2', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci1', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), 1027.5, N'hPa', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci2', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 1024.6, N'hPa', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci3', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 1026.8, N'hPa', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci4', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), 1025.3, N'hPa', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci5', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), 1001.8, N'hPa', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci6', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 1001.6, N'hPa', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci7', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 1011.8, N'hPa', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci8', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), 1025.7, N'hPa', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci9', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), 976.9, N'hPa', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci10', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 1005.4, N'hPa', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci11', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 989.3, N'hPa', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci12', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), 1001.7, N'hPa', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci13', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), 1024.3, N'hPa', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci14', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 1019.3, N'hPa', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci15', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 1025.1, N'hPa', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'ci16', N'Ciśnienie', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), 985.9, N'hPa', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te1', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), -8.8, N'C', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te2', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 6.9, N'C', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te3', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 4.6, N'C', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te4', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), -1, N'C', N'WROC1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te5', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), -5.1, N'C', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te6', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 4.1, N'C', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te7', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 3.3, N'C', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te8', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), -0.5, N'C', N'WROC2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te9', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), -7.6, N'C', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te10', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 4.4, N'C', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te11', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 3.2, N'C', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te12', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), -0.8, N'C', N'BIEL1')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te13', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'06:00:00' AS Time), -5.3, N'C', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te14', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'12:00:00' AS Time), 3.3, N'C', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te15', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'18:00:00' AS Time), 1.5, N'C', N'BIEL2')
INSERT [dbo].[Pomiar] ([IdPomiaru], [NazwaPomiaru], [Data], [Godzina], [Wynik], [Jednostka], [NazwaStacji]) VALUES (N'te16', N'Temperatura', CAST(N'2020-03-31' AS Date), CAST(N'00:00:00' AS Time), -1.7, N'C', N'BIEL2')
INSERT [dbo].[Stacja] ([NazwaStacji], [Miasto], [Ulica]) VALUES (N'WROC1', N'Wrocław', N'Piłsudzkiego                                                                                                                                                                                                                                                   ')
INSERT [dbo].[Stacja] ([NazwaStacji], [Miasto], [Ulica]) VALUES (N'WROC2', N'Wrocław', N'Paderewskiego                                                                                                                                                                                                                                                  ')
INSERT [dbo].[Stacja] ([NazwaStacji], [Miasto], [Ulica]) VALUES (N'BIEL1', N'Bielsko-Biała', N'11 Listopada                                                                                                                                                                                                                                                   ')
INSERT [dbo].[Stacja] ([NazwaStacji], [Miasto], [Ulica]) VALUES (N'BIEL2', N'Bielsko-Biała', N'Partyzantów                                                                                                                                                                                                                                                    ')
USE [master]
GO
ALTER DATABASE [DaneMeteo] SET  READ_WRITE 
GO
