USE [master]
GO
/****** Object:  Database [DataBase]    Script Date: 11/08/2021 00:09:34 ******/
CREATE DATABASE [DataBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataBase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DataBase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DataBase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DataBase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DataBase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DataBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DataBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DataBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DataBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [DataBase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DataBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DataBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DataBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DataBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DataBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DataBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DataBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DataBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DataBase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DataBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DataBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DataBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DataBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DataBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DataBase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DataBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DataBase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DataBase] SET  MULTI_USER 
GO
ALTER DATABASE [DataBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DataBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DataBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DataBase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DataBase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DataBase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DataBase] SET QUERY_STORE = OFF
GO
USE [DataBase]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 11/08/2021 00:09:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[Token] [int] NOT NULL,
	[UserID] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Boot] [nvarchar](50) NOT NULL,
	[Result] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/08/2021 00:09:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
/****** Object:  StoredProcedure [dbo].[RegisterGame]    Script Date: 11/08/2021 00:09:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
CREATE PROCEDURE [dbo].[RegisterGame] 
	-- Add the parameters for the stored procedure here
	@gameToken int,
	@userID nvarchar(50),
	@username nvarchar(50),
	@bot nvarchar(50),
	@result nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Games  values(@gameToken, @userID, @username, @bot,@result)
END
GO
/****** Object:  StoredProcedure [dbo].[UserEnter]    Script Date: 11/08/2021 00:09:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserEnter]
	-- Add the parameters for the stored procedure here
	@UserId nvarchar(50),
	@UserName nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	(SELECT  COUNT(*)	from Users where @UserId=UserId AND @UserName=UserName)
END
GO
/****** Object:  StoredProcedure [dbo].[UserExistsCheck]    Script Date: 11/08/2021 00:09:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserExistsCheck]
	-- Add the parameters for the stored procedure here
	@UserID nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Users where UserID = @UserID
END
GO
USE [master]
GO
ALTER DATABASE [DataBase] SET  READ_WRITE 
GO
