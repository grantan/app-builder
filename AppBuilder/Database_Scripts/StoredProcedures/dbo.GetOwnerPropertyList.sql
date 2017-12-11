CREATE PROCEDURE [dbo].[GetOwnerPropertyList]
	@ownerId INT
AS
	SELECT p.Id AS Id, p.Name AS PropertyName, p.Description AS PropertyDescription, p.IsList, p.SequenceOrder,
			t.Id AS OwnedThingId			
	FROM ThingHasProperty p
	INNER JOIN Thing t ON p.PropertyThingId = t.Id	
	WHERE p.OwnerThingId = @ownerId
	ORDER BY p.SequenceOrder
RETURN 0