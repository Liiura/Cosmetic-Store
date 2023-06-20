/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO Color VALUES('Red',GETDATE()),('Blue',GETDATE()),('Yellow',GETDATE()),('Gray',GETDATE()),('Green',GETDATE())
INSERT INTO Promotion VALUES('Promotion 1', GETDATE(),5, 100000,150000),('Promotion 2', GETDATE(),7, 150000,170000),('Promotion 3', GETDATE(),10, 150000,200000)
INSERT INTO SellDepartment VALUES('Department 1',GETDATE()),('Department 2',GETDATE()),('Department 3',GETDATE())