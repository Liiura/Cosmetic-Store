CREATE TABLE [dbo].[ClientSeparationProduct]
(
	[Id] INT IDENTITY(1,1)  NOT NULL PRIMARY KEY, 
    [ClientId] INT NOT NULL FOREIGN KEY REFERENCES Client(Id), 
    [PromotionId] INT NULL FOREIGN KEY REFERENCES Promotion(Id), 
    [CreatedDate] DATETIME NOT NULL
)
