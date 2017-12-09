CREATE PROCEDURE [dbo].[GetOwnerByPropertyThingId]
	@PropertyThingId int
AS
	SELECT T.Id, T.Name, T.Description, ThingTypeId FROM dbo.Thing T 
	JOIN ThingHasProperty THP ON THP.OwnerThingId = T.Id
	WHERE THP.Id = @PropertyThingId
RETURN 0
