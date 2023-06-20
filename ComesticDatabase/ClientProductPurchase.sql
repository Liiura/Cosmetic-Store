CREATE TABLE [dbo].[ClientProductPurchase]
(
	[Id] INT IDENTITY(1,1)  NOT NULL PRIMARY KEY, 
    [PurchaseDate] DATETIME NULL, 
    [ClientId] INT FOREIGN KEY REFERENCES Client(Id) NOT NULL
)
