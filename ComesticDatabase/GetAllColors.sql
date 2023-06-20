CREATE PROCEDURE [dbo].[GetAllColors]
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT Id, Color.Name, CreatedDate
    FROM Color;
    return 
END