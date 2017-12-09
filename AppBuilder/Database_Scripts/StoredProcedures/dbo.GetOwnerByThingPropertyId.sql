CREATE PROCEDURE [dbo].[GetOwnerByThingPropertyId]
	@ThingPropertyId int
AS
	SELECT T.Id, T.Name, T.Description, ThingTypeId FROM dbo.Thing T 
	JOIN ThingHasProperty THP ON THP.OwnerThingId = T.Id
	WHERE THP.Id = @ThingPropertyId
RETURN 0
