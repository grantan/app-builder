CREATE PROCEDURE [dbo].[GetThingProperty]
	@Id INT
AS
	SELECT @Id AS PropertyThingId, p.Name AS PropertyName, p.Description AS PropertyDescription, p.IsList AS IsList, 
			t2.Id AS OwnedThingId, t2.Name AS OwnedThingName, t2.Description AS OwnedThingDescription
	FROM ThingHasProperty p
	INNER JOIN Thing t2 ON p.PropertyThingId = t2.Id
	WHERE p.Id = @Id
RETURN 0