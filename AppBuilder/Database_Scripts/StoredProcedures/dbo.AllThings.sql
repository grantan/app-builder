CREATE PROCEDURE [dbo].[AllThings]
	
AS
	SELECT Id, Name, Description, ThingTypeId FROM dbo.Thing

RETURN 0