CREATE TABLE [dbo].[Promotion]
(
	[Id] INT IDENTITY(1,1)  NOT NULL PRIMARY KEY, 
    [PromotionName] NVARCHAR(MAX) NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [PromotionPercentage] DECIMAL(18,3) NOT NULL, 
    [MaximalAmount] MONEY NOT NULL, 
    [MinimalAmount] MONEY NOT NULL
)
