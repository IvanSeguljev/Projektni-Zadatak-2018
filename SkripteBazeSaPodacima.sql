USE [ProjektniZadatak]
GO
ALTER TABLE [dbo].[TelefonKontakt] DROP CONSTRAINT [FK_TelefonKontakt_KontaktOsoba1]
GO
ALTER TABLE [dbo].[MailKontakt] DROP CONSTRAINT [FK_MailKontakt_KontaktOsoba]
GO
ALTER TABLE [dbo].[KontaktOsoba] DROP CONSTRAINT [FK_KontaktOsoba_Preduzece1]
GO
/****** Object:  Table [dbo].[TelefonKontakt]    Script Date: 3/16/2018 8:57:45 PM ******/
DROP TABLE [dbo].[TelefonKontakt]
GO
/****** Object:  Table [dbo].[Preduzece]    Script Date: 3/16/2018 8:57:45 PM ******/
DROP TABLE [dbo].[Preduzece]
GO
/****** Object:  Table [dbo].[MailKontakt]    Script Date: 3/16/2018 8:57:45 PM ******/
DROP TABLE [dbo].[MailKontakt]
GO
/****** Object:  Table [dbo].[LoginUsers]    Script Date: 3/16/2018 8:57:45 PM ******/
DROP TABLE [dbo].[LoginUsers]
GO
/****** Object:  Table [dbo].[KontaktOsoba]    Script Date: 3/16/2018 8:57:45 PM ******/
DROP TABLE [dbo].[KontaktOsoba]
GO
USE [master]
GO
/****** Object:  Database [ProjektniZadatak]    Script Date: 3/16/2018 8:57:45 PM ******/
DROP DATABASE [ProjektniZadatak]
GO
/****** Object:  Database [ProjektniZadatak]    Script Date: 3/16/2018 8:57:45 PM ******/
CREATE DATABASE [ProjektniZadatak]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjektniZadatak', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ProjektniZadatak.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjektniZadatak_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ProjektniZadatak_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjektniZadatak] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjektniZadatak].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjektniZadatak] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjektniZadatak] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjektniZadatak] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjektniZadatak] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjektniZadatak] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjektniZadatak] SET  MULTI_USER 
GO
ALTER DATABASE [ProjektniZadatak] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjektniZadatak] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjektniZadatak] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ProjektniZadatak] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ProjektniZadatak]
GO
/****** Object:  Table [dbo].[KontaktOsoba]    Script Date: 3/16/2018 8:57:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KontaktOsoba](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDpreduzeca] [int] NOT NULL,
	[Ime] [nvarchar](30) NOT NULL,
	[Prezime] [nvarchar](30) NOT NULL,
	[RadnoMesto] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_KontaktOsoba] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoginUsers]    Script Date: 3/16/2018 8:57:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginUsers](
	[Username] [nvarchar](35) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[PravoPristupa] [int] NULL,
 CONSTRAINT [PK_LoginUsers] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MailKontakt]    Script Date: 3/16/2018 8:57:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MailKontakt](
	[IDKontakt] [int] NOT NULL,
	[OznakaTip] [nvarchar](15) NOT NULL,
	[Adresa] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MailKontakt] PRIMARY KEY CLUSTERED 
(
	[Adresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Preduzece]    Script Date: 3/16/2018 8:57:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preduzece](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NazivPreduzeca] [nvarchar](50) NOT NULL,
	[Adresa] [nvarchar](50) NOT NULL,
	[Opstina] [nvarchar](30) NOT NULL,
	[PostanskiBR] [nvarchar](5) NOT NULL,
	[MatBR] [nvarchar](8) NOT NULL,
	[PIB] [nvarchar](9) NOT NULL,
	[BrojRacuna] [nvarchar](20) NOT NULL,
	[WebStranica] [nvarchar](100) NULL,
	[FotografijaPecata] [nvarchar](max) NULL,
	[Beleska] [nvarchar](255) NULL,
 CONSTRAINT [PK_Preduzece_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TelefonKontakt]    Script Date: 3/16/2018 8:57:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TelefonKontakt](
	[IDKontakt] [int] NOT NULL,
	[OznakaTip] [nvarchar](15) NOT NULL,
	[BrojTelefona] [nvarchar](20) NOT NULL,
	[Lokal] [int] NOT NULL,
 CONSTRAINT [PK_TelefonKontakt] PRIMARY KEY CLUSTERED 
(
	[BrojTelefona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[KontaktOsoba] ON 

INSERT [dbo].[KontaktOsoba] ([ID], [IDpreduzeca], [Ime], [Prezime], [RadnoMesto]) VALUES (1, 1, N'Pera', N'Peric', N'Maloprodaja')
INSERT [dbo].[KontaktOsoba] ([ID], [IDpreduzeca], [Ime], [Prezime], [RadnoMesto]) VALUES (23, 30, N'Nikola ', N'Nikolic', N'Sef racunovodstva')
SET IDENTITY_INSERT [dbo].[KontaktOsoba] OFF
INSERT [dbo].[LoginUsers] ([Username], [Password], [PravoPristupa]) VALUES (N'A', N'A', 3)
INSERT [dbo].[LoginUsers] ([Username], [Password], [PravoPristupa]) VALUES (N'Admin', N'Admin', 3)
INSERT [dbo].[LoginUsers] ([Username], [Password], [PravoPristupa]) VALUES (N'B', N'B', 2)
INSERT [dbo].[LoginUsers] ([Username], [Password], [PravoPristupa]) VALUES (N'C', N'C', 1)
INSERT [dbo].[LoginUsers] ([Username], [Password], [PravoPristupa]) VALUES (N'aaa', N'bbb', NULL)
INSERT [dbo].[MailKontakt] ([IDKontakt], [OznakaTip], [Adresa]) VALUES (1, N'Privatni', N'PeraPeric123@yahoo.com')
INSERT [dbo].[MailKontakt] ([IDKontakt], [OznakaTip], [Adresa]) VALUES (23, N'Privatna', N'nikola@yahoo.com')
INSERT [dbo].[MailKontakt] ([IDKontakt], [OznakaTip], [Adresa]) VALUES (1, N'privatni', N'pera@rocketmail')
SET IDENTITY_INSERT [dbo].[Preduzece] ON 

INSERT [dbo].[Preduzece] ([ID], [NazivPreduzeca], [Adresa], [Opstina], [PostanskiBR], [MatBR], [PIB], [BrojRacuna], [WebStranica], [FotografijaPecata], [Beleska]) VALUES (1, N'FCO', N'Bulevar M. Pupina 115b', N'Novi Beograd', N'11070', N'12345678', N'987654321', N'1111222233334444', N'http://www.fashioncompany.rs', NULL, N'Fashion company')
INSERT [dbo].[Preduzece] ([ID], [NazivPreduzeca], [Adresa], [Opstina], [PostanskiBR], [MatBR], [PIB], [BrojRacuna], [WebStranica], [FotografijaPecata], [Beleska]) VALUES (30, N'Grmec', N'Adresa', N'Novi Beograd', N'11000', N'12312212', N'12312312', N'123123123', N'http://www.Grmec.com', NULL, N'Izmisljena firma')
INSERT [dbo].[Preduzece] ([ID], [NazivPreduzeca], [Adresa], [Opstina], [PostanskiBR], [MatBR], [PIB], [BrojRacuna], [WebStranica], [FotografijaPecata], [Beleska]) VALUES (39, N'test', N'Test', N'Opstina', N'11000', N'16452378', N'008684563', N'11-54623423-21', N'http://www.preduzece.com', N'~/Images/images182201798.jpg', N'Test preduzece')
SET IDENTITY_INSERT [dbo].[Preduzece] OFF
INSERT [dbo].[TelefonKontakt] ([IDKontakt], [OznakaTip], [BrojTelefona], [Lokal]) VALUES (1, N'privatni', N'0631112222', 1)
INSERT [dbo].[TelefonKontakt] ([IDKontakt], [OznakaTip], [BrojTelefona], [Lokal]) VALUES (23, N'sluzbeni', N'064-888-885-1', 3)
INSERT [dbo].[TelefonKontakt] ([IDKontakt], [OznakaTip], [BrojTelefona], [Lokal]) VALUES (1, N'Sluzbeni', N'0641234567', 23)
ALTER TABLE [dbo].[KontaktOsoba]  WITH CHECK ADD  CONSTRAINT [FK_KontaktOsoba_Preduzece1] FOREIGN KEY([IDpreduzeca])
REFERENCES [dbo].[Preduzece] ([ID])
GO
ALTER TABLE [dbo].[KontaktOsoba] CHECK CONSTRAINT [FK_KontaktOsoba_Preduzece1]
GO
ALTER TABLE [dbo].[MailKontakt]  WITH CHECK ADD  CONSTRAINT [FK_MailKontakt_KontaktOsoba] FOREIGN KEY([IDKontakt])
REFERENCES [dbo].[KontaktOsoba] ([ID])
GO
ALTER TABLE [dbo].[MailKontakt] CHECK CONSTRAINT [FK_MailKontakt_KontaktOsoba]
GO
ALTER TABLE [dbo].[TelefonKontakt]  WITH NOCHECK ADD  CONSTRAINT [FK_TelefonKontakt_KontaktOsoba1] FOREIGN KEY([IDKontakt])
REFERENCES [dbo].[KontaktOsoba] ([ID])
GO
ALTER TABLE [dbo].[TelefonKontakt] NOCHECK CONSTRAINT [FK_TelefonKontakt_KontaktOsoba1]
GO
USE [master]
GO
ALTER DATABASE [ProjektniZadatak] SET  READ_WRITE 
GO
