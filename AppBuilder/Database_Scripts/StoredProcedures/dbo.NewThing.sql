CREATE PROCEDURE [dbo].[NewThing]
	@Name VARCHAR(50),
	@Description VARCHAR(MAX),
	@ThingTypeId INT
AS
	INSERT INTO dbo.Thing(Name, Description, ThingTypeId) VALUES (@Name, @Description, @ThingTypeId)
	SELECT CAST(SCOPE_IDENTITY() AS INT)
RETURN 0