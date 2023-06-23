CREATE TABLE [dbo].[SeparatePlan]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [SeparatePlanName] NVARCHAR(50) NOT NULL, 
    [SeparateValue] MONEY NOT NULL, 
    [SeparatePlanPercentage] DECIMAL(18, 3) NOT NULL
)
