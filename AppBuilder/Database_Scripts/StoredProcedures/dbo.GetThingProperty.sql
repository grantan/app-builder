CREATE PROCEDURE [dbo].[GetThingProperty]
	@Id INT
AS
	SELECT @Id AS PropertyThingId, p.Name AS PropertyName, p.Description AS PropertyDescription, p.IsList AS IsList, p.SequenceOrder,
			t2.Id AS OwnedThingId
	FROM ThingHasProperty p
	INNER JOIN Thing t2 ON p.PropertyThingId = t2.Id
	WHERE p.Id = @Id
RETURN 0