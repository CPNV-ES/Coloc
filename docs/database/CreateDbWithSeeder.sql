USE [master]
GO
/****** Object:  Database [Coloc]    Script Date: 19.03.2019 14:47:30 ******/
CREATE DATABASE [Coloc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Coloc', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Coloc.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Coloc_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Coloc_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Coloc] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Coloc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Coloc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Coloc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Coloc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Coloc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Coloc] SET ARITHABORT OFF 
GO
ALTER DATABASE [Coloc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Coloc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Coloc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Coloc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Coloc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Coloc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Coloc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Coloc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Coloc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Coloc] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Coloc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Coloc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Coloc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Coloc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Coloc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Coloc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Coloc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Coloc] SET RECOVERY FULL 
GO
ALTER DATABASE [Coloc] SET  MULTI_USER 
GO
ALTER DATABASE [Coloc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Coloc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Coloc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Coloc] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Coloc] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Coloc', N'ON'
GO
ALTER DATABASE [Coloc] SET QUERY_STORE = OFF
GO
USE [Coloc]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Coloc]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 19.03.2019 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 19.03.2019 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 19.03.2019 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 19.03.2019 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 19.03.2019 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 19.03.2019 14:47:31 ******/
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
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 19.03.2019 14:47:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 19.03.2019 14:47:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[Description] [text] NOT NULL,
	[TodoId] [int] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Todos]    Script Date: 19.03.2019 14:47:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Todos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[Description] [text] NOT NULL,
 CONSTRAINT [PK_Todos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTasks]    Script Date: 19.03.2019 14:47:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[BeginTask] [datetime] NOT NULL,
	[EndTask] [datetime] NOT NULL,
	[State] [tinyint] NOT NULL,
 CONSTRAINT [PK_UserTasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'DD0AB3E1-1673-47F9-8AA3-D213B49B7B88', N'Admin', N'Admin', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'E9CD19B2-635B-4170-A797-846A2B49956D', N'User', N'User', N'User')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0bc161dd-b114-4643-b598-dda9f0b1a50d', N'E9CD19B2-635B-4170-A797-846A2B49956D')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0d019839-2b1c-47c4-99d6-ce24a0bb39f3', N'E9CD19B2-635B-4170-A797-846A2B49956D')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'36b3f9c6-ecce-4e22-807e-e05c18eaca5b', N'E9CD19B2-635B-4170-A797-846A2B49956D')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'792c9b09-8d6e-47f7-98be-fa27f8faa4d3', N'E9CD19B2-635B-4170-A797-846A2B49956D')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a014da9b-42ac-46c0-849f-cdbc421a917b', N'E9CD19B2-635B-4170-A797-846A2B49956D')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b96d623c-3188-49c0-8ec6-da7ae511033f', N'E9CD19B2-635B-4170-A797-846A2B49956D')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd158b29e-c8c9-4d18-a0af-d3b843441d3a', N'DD0AB3E1-1673-47F9-8AA3-D213B49B7B88')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0bc161dd-b114-4643-b598-dda9f0b1a50d', N'benjamin@cpnv.ch', N'BENJAMIN@CPNV.CH', N'benjamin@cpnv.ch', N'BENJAMIN@CPNV.CH', 0, N'AQAAAAEAACcQAAAAEMAPV7BVGUVGYVQ85OM04PCuezjs7jTd/hvZW0bCLuwECE3C9nNeJRimmrIimx9BjQ==', N'XWQBKKFH7H37IU4AIXOPF355XKIZAZP6', N'd3276cfb-5576-472f-a8e9-06a440c4a880', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0d019839-2b1c-47c4-99d6-ce24a0bb39f3', N'kevin@cpnv.ch', N'KEVIN@CPNV.CH', N'kevin@cpnv.ch', N'KEVIN@CPNV.CH', 0, N'AQAAAAEAACcQAAAAEI4+zp81tZL571fBKNwd4xiCjVirIiN1mtc6mCGoVVvRGJZ3ZT7V1ENcEiajQm66kw==', N'44QQ4PA5C34XYWMYF44DGZPR7HU2C4BM', N'dd1380d3-63ea-49cd-a115-725c6004329c', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'36b3f9c6-ecce-4e22-807e-e05c18eaca5b', N'steven@cpnv.ch', N'STEVEN@CPNV.CH', N'steven@cpnv.ch', N'STEVEN@CPNV.CH', 0, N'AQAAAAEAACcQAAAAEDTUJuFnsDst+wxKEg4yhjzWPlU5/H+DdXUfBuRz0pxIM/M97tH15085uOtgIBNigw==', N'JPES75M3CXDGFG3S2ZO5Y7W4ZCJ4SCOT', N'85607df9-6941-4faa-8b2e-323d610ea371', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'792c9b09-8d6e-47f7-98be-fa27f8faa4d3', N'davide@cpnv.ch', N'DAVIDE@CPNV.CH', N'davide@cpnv.ch', N'DAVIDE@CPNV.CH', 0, N'AQAAAAEAACcQAAAAENoz1iZieoQZdQgJK27OqA7mGaLkYIFkWTzYKt0uYTgGEJ5+Jf3npLXBNlD9CjszAw==', N'WET55QU2VJDFPTFUEG3BOMT2F4LAHAMW', N'8c0a051e-f74b-4bd5-8939-fb6adde53efb', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a014da9b-42ac-46c0-849f-cdbc421a917b', N'antonio@cpnv.ch', N'ANTONIO@CPNV.CH', N'antonio@cpnv.ch', N'ANTONIO@CPNV.CH', 0, N'AQAAAAEAACcQAAAAEPf3tl+BEB7rVBMEq3c7GvgQPhjacfXG5NqtYay9w3KDRvn/r2c/Mt94XJd5S8ZyLw==', N'UNEBTOONVWNHGS5SHFDXQUVQ5U4OQ322', N'3a9a73bc-3f83-4be8-b32f-5fab229e53d0', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b96d623c-3188-49c0-8ec6-da7ae511033f', N'bastien@cpnv.ch', N'BASTIEN@CPNV.CH', N'bastien@cpnv.ch', N'BASTIEN@CPNV.CH', 0, N'AQAAAAEAACcQAAAAEHMwjv/3XXQn6QL7idnq4CkGg3lpEIEeDupwEbz749rzHPGer/uMK06ZOfgW4lXZDg==', N'WUGQB22Y6VUTYQQBP4CX5OG674QVLKE5', N'320186ed-575a-4bb7-96be-9b544773faa2', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd158b29e-c8c9-4d18-a0af-d3b843441d3a', N'julien@cpnv.ch', N'JULIEN@CPNV.CH', N'julien@cpnv.ch', N'JULIEN@CPNV.CH', 0, N'AQAAAAEAACcQAAAAEArQBT3rCNUz1U7C58MlQdubtOB9cY4+6g2EtFfX3/i8EON7MiTpxnFkEl+6DNkmFg==', N'B44NKEUJBJ5OHGWVTML52O5IF3XFWDG6', N'2f9605bf-9551-4ecc-a651-e5d4f1c07742', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Tasks] ON 

INSERT [dbo].[Tasks] ([Id], [Title], [Description], [TodoId]) VALUES (2, N'Toilettes', N'Nettoyer les toilettes', 1)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [TodoId]) VALUES (3, N'Salon', N'Nettoyer le salon', 1)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [TodoId]) VALUES (4, N'Cuisine', N'Ranger la cuisine', 1)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [TodoId]) VALUES (5, N'Gazon', N'Tondre ou arroser le gazon', 2)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [TodoId]) VALUES (6, N'Nettoyer', N'Ramasser feuilles mortes et branches', 2)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [TodoId]) VALUES (7, N'Couper plantes', N'Couper les branches ou les fleurs', 2)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [TodoId]) VALUES (8, N'Plantage et récolte', N'Planter ou récolter les légumes et fruits', 2)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [TodoId]) VALUES (9, N'Vélo', N'Regonfler pneu et huiler chaine', 3)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [TodoId]) VALUES (10, N'Lampes', N'Remplacer les lumières cassées', 3)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [TodoId]) VALUES (11, N'Machine à café', N'Remplacer filtre machine à café', 4)
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [TodoId]) VALUES (12, N'Four à vapeur', N'Remplacer filtre four à vapeur', 4)
SET IDENTITY_INSERT [dbo].[Tasks] OFF
SET IDENTITY_INSERT [dbo].[Todos] ON 

INSERT [dbo].[Todos] ([Id], [Title], [Description]) VALUES (1, N'Maison', N'Nettoyer les différentes pièces de la maison')
INSERT [dbo].[Todos] ([Id], [Title], [Description]) VALUES (2, N'Jardin', N'Entretenir les différents éléments du jardin')
INSERT [dbo].[Todos] ([Id], [Title], [Description]) VALUES (3, N'Réparation', N'Réparer ces différents éléments')
INSERT [dbo].[Todos] ([Id], [Title], [Description]) VALUES (4, N'Entretien', N'Entretien des machines suivantes')
SET IDENTITY_INSERT [dbo].[Todos] OFF
SET IDENTITY_INSERT [dbo].[UserTasks] ON 

INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (6, 2, N'0bc161dd-b114-4643-b598-dda9f0b1a50d', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2020-03-19T14:27:50.000' AS DateTime), 0)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (10, 6, N'0bc161dd-b114-4643-b598-dda9f0b1a50d', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 0)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (11, 12, N'0bc161dd-b114-4643-b598-dda9f0b1a50d', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-03-30T14:27:50.000' AS DateTime), 1)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (12, 2, N'0d019839-2b1c-47c4-99d6-ce24a0bb39f3', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 0)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (13, 3, N'0d019839-2b1c-47c4-99d6-ce24a0bb39f3', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 0)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (14, 4, N'0d019839-2b1c-47c4-99d6-ce24a0bb39f3', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 1)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (15, 5, N'0d019839-2b1c-47c4-99d6-ce24a0bb39f3', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 2)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (16, 6, N'0d019839-2b1c-47c4-99d6-ce24a0bb39f3', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 1)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (17, 7, N'0d019839-2b1c-47c4-99d6-ce24a0bb39f3', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 2)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (18, 8, N'0d019839-2b1c-47c4-99d6-ce24a0bb39f3', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 1)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (19, 9, N'0d019839-2b1c-47c4-99d6-ce24a0bb39f3', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 0)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (20, 10, N'0d019839-2b1c-47c4-99d6-ce24a0bb39f3', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 0)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (21, 11, N'0d019839-2b1c-47c4-99d6-ce24a0bb39f3', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 2)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (22, 12, N'0d019839-2b1c-47c4-99d6-ce24a0bb39f3', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 1)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (23, 4, N'36b3f9c6-ecce-4e22-807e-e05c18eaca5b', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 0)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (24, 9, N'36b3f9c6-ecce-4e22-807e-e05c18eaca5b', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 2)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (25, 10, N'36b3f9c6-ecce-4e22-807e-e05c18eaca5b', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 1)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (26, 8, N'792c9b09-8d6e-47f7-98be-fa27f8faa4d3', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 0)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (27, 12, N'792c9b09-8d6e-47f7-98be-fa27f8faa4d3', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 1)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (28, 3, N'd158b29e-c8c9-4d18-a0af-d3b843441d3a', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-04-19T14:27:50.000' AS DateTime), 0)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (29, 5, N'd158b29e-c8c9-4d18-a0af-d3b843441d3a', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 1)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (30, 8, N'd158b29e-c8c9-4d18-a0af-d3b843441d3a', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-06-19T14:27:50.000' AS DateTime), 0)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (31, 9, N'd158b29e-c8c9-4d18-a0af-d3b843441d3a', CAST(N'2019-04-19T14:27:50.000' AS DateTime), CAST(N'2019-07-19T14:27:50.000' AS DateTime), 0)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (32, 11, N'd158b29e-c8c9-4d18-a0af-d3b843441d3a', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 2)
INSERT [dbo].[UserTasks] ([Id], [TaskId], [UserId], [BeginTask], [EndTask], [State]) VALUES (33, 12, N'd158b29e-c8c9-4d18-a0af-d3b843441d3a', CAST(N'2019-03-19T14:27:50.000' AS DateTime), CAST(N'2019-05-19T14:27:50.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[UserTasks] OFF
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO


/* TRIGGER
Add default role 'User' when a new user is created 
*/
CREATE TRIGGER DefaultRole ON AspNetUsers
FOR INSERT 
AS
declare @userId nvarchar(450)
declare @roleId nvarchar(450)
SELECT @userId = Id from inserted
SELECT @roleId = Id FROM AspNetRoles WHERE Name = 'User' 
INSERT INTO AspNetUserRoles(UserId, RoleId) 
VALUES(@userId, @roleId)

GO

ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Todos_TodoId] FOREIGN KEY([TodoId])
REFERENCES [dbo].[Todos] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Todos_TodoId]
GO
ALTER TABLE [dbo].[UserTasks]  WITH CHECK ADD  CONSTRAINT [FK_UserTasks_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserTasks] CHECK CONSTRAINT [FK_UserTasks_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserTasks]  WITH CHECK ADD  CONSTRAINT [FK_UserTasks_Tasks_TaskId] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([Id])
GO
ALTER TABLE [dbo].[UserTasks] CHECK CONSTRAINT [FK_UserTasks_Tasks_TaskId]
GO
USE [master]
GO
ALTER DATABASE [Coloc] SET  READ_WRITE 
GO