CREATE TABLE [dbo].[ClientSeparationProductDetail]
(
	[Id] INT IDENTITY(1,1)  NOT NULL PRIMARY KEY, 
    [ProductId] INT NOT NULL FOREIGN KEY REFERENCES Product(Id), 
    [ClientSeparationProductId] INT FOREIGN KEY REFERENCES ClientSeparationProduct(Id) NOT NULL, 
    [SeparatedQuantity] INT NOT NULL 
)
