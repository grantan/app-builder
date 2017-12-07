CREATE PROCEDURE [dbo].[UpdateThing]
	@Id int,
	@Name NVARCHAR(50),
	@Description NVARCHAR(50)

	AS

	UPDATE dbo.Thing SET Name = @Name, Description = @Description WHERE Id = @Id
	
RETURN 0