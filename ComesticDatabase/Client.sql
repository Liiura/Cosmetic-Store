﻿CREATE TABLE [dbo].[Client]
(
	[Id] INT IDENTITY(1,1)  NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [CreatedDate] DATETIME NULL
)
