USE [TrainingDB]
GO

/****** Object: Table [dbo].[Training] Script Date: 26-05-2020 00:31:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Training] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [TrainingName] NVARCHAR (50) NOT NULL,
    [StartDate]    DATETIME      NOT NULL,
    [EndDate]      DATETIME      NOT NULL
);


