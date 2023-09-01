USE [C:\USERS\SNISHI\SOURCE\REPOS\WEBAPI2\DATABASE\WEBAPI2.MDF]
GO

/****** Objeto: Table [dbo].[Tasks] Fecha del script: 1/09/2023 10:30:53 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


DROP TABLE [dbo].[Tasks];
DROP TABLE [dbo].[Users];

GO
CREATE TABLE [dbo].[Tasks] (
    [TaskId]    INT         IDENTITY (1, 1) NOT NULL,
    [Title]     NCHAR (100) NOT NULL,
    [CreatedAt] DATETIME    NOT NULL,
    [UserId]    INT         NULL,
    [IsActive]  BIT         NOT NULL
);


GO
CREATE TABLE [dbo].[Users] (
    [UserId] INT         NOT NULL,
    [Name]   NCHAR (100) NOT NULL
);


