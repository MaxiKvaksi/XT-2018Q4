USE [master]
GO
/****** Object:  Database [epam_task_db]    Script Date: 12.02.2019 13:16:30 ******/
CREATE DATABASE [epam_task_db]
 CONTAINMENT = NONE
ALTER DATABASE [epam_task_db] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [epam_task_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [epam_task_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [epam_task_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [epam_task_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [epam_task_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [epam_task_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [epam_task_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [epam_task_db] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [epam_task_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [epam_task_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [epam_task_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [epam_task_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [epam_task_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [epam_task_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [epam_task_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [epam_task_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [epam_task_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [epam_task_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [epam_task_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [epam_task_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [epam_task_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [epam_task_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [epam_task_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [epam_task_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [epam_task_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [epam_task_db] SET  MULTI_USER 
GO
ALTER DATABASE [epam_task_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [epam_task_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [epam_task_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [epam_task_db] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [epam_task_db]
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAward]
	@title NVARCHAR(50),
	@id_image INT
	
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO awards(title, idImage)
	VALUES (@title, @id_image)
END

GO
/****** Object:  StoredProcedure [dbo].[AddAwardedUser]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAwardedUser]
	@id_user INT,
	@id_award INT
	
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO awarded_users(idUser, idAward)
	VALUES (@id_user, @id_award)
END

GO
/****** Object:  StoredProcedure [dbo].[AddImage]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddImage]
	@image_value NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO images(image_value)
	VALUES (@image_value)
END

GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
	@name NVARCHAR(50),
	@date_of_birth DATE,
	@id_image INT

AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO users(name, date_of_birth, id_image)
	VALUES (@name, @date_of_birth, @id_image)
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteAward]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAward]
	@id INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM awarded_users
	WHERE idAward = @id
	DELETE FROM awards
	WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteAwardedUser]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAwardedUser]
	@idAward INT,
	@idUser INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM awarded_users
	WHERE idAward = @idAward AND idUser = @idUser
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteAwardedUserByIdAward]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAwardedUserByIdAward]
	@idAward INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM awarded_users
	WHERE idAward = @idAward
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteImage]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteImage]
	@id INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM images
	WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUser]
	@id INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM users
	WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllAwardedUsers]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllAwardedUsers]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT awarded_users.idUser, awarded_users.idAward FROM awarded_users;
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllAwards]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllAwards]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT awards.id, awards.title, awards.idImage FROM awards;
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllImages]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllImages]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT images.id, images.image_value FROM images;
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT users.id, users.name, users.date_of_birth, users.id_image FROM users;
END

GO
/****** Object:  StoredProcedure [dbo].[GetImageId]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetImageId]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT MAX(images.id) as id FROM images;
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAward]
	@id INT,
	@title NVARCHAR(50),
	@id_image INT
AS
BEGIN
	UPDATE awards
	SET idImage = @id_image, title = @title
	WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser]
	@id INT,
	@name NVARCHAR(50),
	@date_of_birth DATE,
	@id_image INT
AS
BEGIN
	UPDATE users
	SET id_image = @id_image, name = @name, date_of_birth = @date_of_birth
	WHERE id = @id
END

GO
/****** Object:  Table [dbo].[awarded_users]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[awarded_users](
	[idUser] [int] NOT NULL,
	[idAward] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[awards]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[awards](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[idImage] [int] NOT NULL,
 CONSTRAINT [PK_awards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[images]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[images](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[image_value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_images] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 12.02.2019 13:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[date_of_birth] [datetime] NOT NULL,
	[id_image] [int] NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[awards] ADD  CONSTRAINT [DF_awards_idImage]  DEFAULT ((2)) FOR [idImage]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_id_image]  DEFAULT ((1)) FOR [id_image]
GO
ALTER TABLE [dbo].[awarded_users]  WITH CHECK ADD  CONSTRAINT [FK_awarded_users_awards] FOREIGN KEY([idAward])
REFERENCES [dbo].[awards] ([id])
GO
ALTER TABLE [dbo].[awarded_users] CHECK CONSTRAINT [FK_awarded_users_awards]
GO
ALTER TABLE [dbo].[awarded_users]  WITH CHECK ADD  CONSTRAINT [FK_awarded_users_users] FOREIGN KEY([idUser])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[awarded_users] CHECK CONSTRAINT [FK_awarded_users_users]
GO
ALTER TABLE [dbo].[awards]  WITH CHECK ADD  CONSTRAINT [FK_awards_images] FOREIGN KEY([idImage])
REFERENCES [dbo].[images] ([id])
GO
ALTER TABLE [dbo].[awards] CHECK CONSTRAINT [FK_awards_images]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_images] FOREIGN KEY([id_image])
REFERENCES [dbo].[images] ([id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_images]
GO
USE [master]
GO
ALTER DATABASE [epam_task_db] SET  READ_WRITE 
GO
