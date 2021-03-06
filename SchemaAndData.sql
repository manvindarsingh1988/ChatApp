USE [master]
GO
/****** Object:  Database [Chat]    Script Date: 15-10-2021 14:40:32 ******/
CREATE DATABASE [Chat]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Chat', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Chat.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Chat_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Chat_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Chat] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Chat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Chat] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Chat] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Chat] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Chat] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Chat] SET ARITHABORT OFF 
GO
ALTER DATABASE [Chat] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Chat] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Chat] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Chat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Chat] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Chat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Chat] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Chat] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Chat] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Chat] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Chat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Chat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Chat] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Chat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Chat] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Chat] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Chat] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Chat] SET RECOVERY FULL 
GO
ALTER DATABASE [Chat] SET  MULTI_USER 
GO
ALTER DATABASE [Chat] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Chat] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Chat] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Chat] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Chat] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Chat] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Chat', N'ON'
GO
ALTER DATABASE [Chat] SET QUERY_STORE = OFF
GO
USE [Chat]
GO
/****** Object:  Table [dbo].[ChatGroupInfo]    Script Date: 15-10-2021 14:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatGroupInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_ChatGroupInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatRoomInfo]    Script Date: 15-10-2021 14:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatRoomInfo](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[IsGroup] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageInfoDetail]    Script Date: 15-10-2021 14:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageInfoDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](200) NULL,
	[UserId] [int] NULL,
	[ToUserId] [int] NULL,
	[MessageSentOn] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageLikeDetails]    Script Date: 15-10-2021 14:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageLikeDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MessageId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_MessageLikeDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChatGroupInfo] ON 

INSERT [dbo].[ChatGroupInfo] ([ID], [GroupId], [UserId]) VALUES (1, 1, 2)
INSERT [dbo].[ChatGroupInfo] ([ID], [GroupId], [UserId]) VALUES (2, 3, 1)
INSERT [dbo].[ChatGroupInfo] ([ID], [GroupId], [UserId]) VALUES (3, 3, 2)
SET IDENTITY_INSERT [dbo].[ChatGroupInfo] OFF
GO
INSERT [dbo].[ChatRoomInfo] ([ID], [Name], [IsGroup]) VALUES (1, N'User1', 0)
INSERT [dbo].[ChatRoomInfo] ([ID], [Name], [IsGroup]) VALUES (2, N'User2', 0)
INSERT [dbo].[ChatRoomInfo] ([ID], [Name], [IsGroup]) VALUES (3, N'Group1', 1)
GO

ALTER TABLE [dbo].[ChatGroupInfo]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[ChatRoomInfo] ([ID])
GO
ALTER TABLE [dbo].[ChatGroupInfo]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[ChatRoomInfo] ([ID])
GO
ALTER TABLE [dbo].[MessageLikeDetails]  WITH CHECK ADD FOREIGN KEY([MessageId])
REFERENCES [dbo].[MessageInfoDetail] ([ID])
GO
ALTER TABLE [dbo].[MessageLikeDetails]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[ChatRoomInfo] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[usp_GetMessageDetails]    Script Date: 15-10-2021 14:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetMessageDetails] 
@Id int,
@ToId int
AS
BEGIN
	declare @isGroup bit
	Select @isGroup = IsGroup from [dbo].[ChatRoomInfo] where Id = @ToId
	if(@isGroup = 1)
	begin 
	  Select MID.ID, MID.Message, MID.UserId, MID.ToUserId, MID.MessageSentOn, CRI.Name UserName, CRI1.Name ToUserName from [dbo].[MessageInfoDetail] MID 
	  inner join [dbo].[ChatRoomInfo] CRI on MID.UserId = CRI.ID
	  inner join [dbo].[ChatRoomInfo] CRI1 on MID.ToUserId = CRI1.ID
	  where ToUserId = @ToId
	end
	else
	begin
	    Select MID.ID, MID.Message, MID.UserId, MID.ToUserId, MID.MessageSentOn, CRI.Name UserName, CRI1.Name ToUserName from [dbo].[MessageInfoDetail] MID 
	  inner join [dbo].[ChatRoomInfo] CRI on MID.UserId = CRI.ID
	  inner join [dbo].[ChatRoomInfo] CRI1 on MID.ToUserId = CRI1.ID
	   where MID.ToUserId = @ToId and MID.UserId = @Id
	   union
	   Select MID.ID, MID.Message, MID.UserId, MID.ToUserId, MID.MessageSentOn, CRI.Name UserName, CRI1.Name ToUserName from [dbo].[MessageInfoDetail] MID 
	  inner join [dbo].[ChatRoomInfo] CRI on MID.UserId = CRI.ID
	  inner join [dbo].[ChatRoomInfo] CRI1 on MID.ToUserId = CRI1.ID
	   where MID.ToUserId = @Id and MID.UserId = @ToId 
	
	end
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUsersAndGroups]    Script Date: 15-10-2021 14:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetUsersAndGroups] 
	@Id int
AS
BEGIN
    if(@Id = -1)
	begin
	  Select cri.ID, cri.Name, cri.IsGroup from ChatRoomInfo cri where IsGroup = 0
	end
	else
	begin
		Select cri.ID, cri.Name, cri.IsGroup from ChatGroupInfo cgi inner join  ChatRoomInfo cri on cgi.UserId = cri.Id where GroupId = @Id and IsGroup = 0
		union
		Select cri.ID, cri.Name, cri.IsGroup from ChatGroupInfo cgi inner join  ChatRoomInfo cri on cgi.GroupId = cri.Id where UserId = @Id and IsGroup = 0
		union
		Select cri.ID, cri.Name, cri.IsGroup from ChatGroupInfo cgi inner join  ChatRoomInfo cri on cgi.GroupId = cri.Id where UserId = @Id and IsGroup = 1
	end
END

GO
USE [master]
GO
ALTER DATABASE [Chat] SET  READ_WRITE 
GO
