CREATE PROCEDURE [dbo].[UpdateThing]
	@Id int,
	@Name NVARCHAR(50),
	@Description NVARCHAR(50),
	@ThingTypeId INT

	AS

	UPDATE dbo.Thing SET Name = @Name, Description = @Description, ThingTypeId = @ThingTypeId WHERE Id = @Id
	
RETURN 0