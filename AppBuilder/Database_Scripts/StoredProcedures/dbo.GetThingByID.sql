CREATE PROCEDURE [dbo].[GetThingByID]
	@Id int
AS
	SELECT * FROM dbo.Thing WHERE Id = @Id
RETURN 0