CREATE TABLE [dbo].[Product]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Price] MONEY NOT NULL, 
    [SellDepartmentId] INT NOT NULL
)
