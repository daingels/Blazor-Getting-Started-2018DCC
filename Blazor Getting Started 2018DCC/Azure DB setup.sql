USE [master]
GO

CREATE LOGIN [ScoreboardWebAPI] WITH PASSWORD=N'DCC2018!'
GO

ALTER LOGIN [ScoreboardWebAPI] ENABLE
GO

USE [Scoreboard]
GO

CREATE USER [ScoreboardWebAPI] FROM LOGIN [ScoreboardWebAPI]
GO

ALTER ROLE [db_datareader] ADD MEMBER [ScoreboardWebAPI]
GO

ALTER ROLE [db_datawriter] ADD MEMBER [ScoreboardWebAPI]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GameResults](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sport] [nvarchar](50) NOT NULL,
	[HomeTeamName] [nvarchar](50) NOT NULL,
	[HomeTeamScore] [int] NOT NULL,
	[VisitorTeamName] [nvarchar](50) NOT NULL,
	[VisitorTeamScore] [int] NOT NULL,
	[Period] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GameResults] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
