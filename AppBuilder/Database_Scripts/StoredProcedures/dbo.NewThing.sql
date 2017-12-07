CREATE PROCEDURE [dbo].[NewThing]
	@Name VARCHAR(50),
	@Description VARCHAR(MAX)
AS
	INSERT INTO dbo.Thing(Name, Description) VALUES (@Name, @Description)
	SELECT CAST(SCOPE_IDENTITY() AS INT)
RETURN 0