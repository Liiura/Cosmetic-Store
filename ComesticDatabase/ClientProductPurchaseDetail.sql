CREATE TABLE [dbo].[ClientProductPurchaseDetail]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [QuantityPurchase] INT NOT NULL, 
    [CurrentProductPrice] MONEY NOT NULL, 
    [ProductId] INT NOT NULL FOREIGN KEY REFERENCES Product(Id), 
    [ClientProductPurchaseId] INT NOT NULL FOREIGN KEY REFERENCES ClientProductPurchase(Id)
)
