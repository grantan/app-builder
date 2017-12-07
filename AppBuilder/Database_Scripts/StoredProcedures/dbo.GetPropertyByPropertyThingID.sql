CREATE PROCEDURE [dbo].[GetPropertyByPropertyThingID]
	@Id int
AS
	SELECT T.Id, T.Name, T.Description FROM dbo.Thing T
	JOIN ThingHasProperty THP ON THP.PropertyThingId = T.Id
	WHERE THP.Id = @Id
RETURN 0