CREATE PROCEDURE [dbo].[DeleteThingProperty]
	@thingPropertyId INT
AS
	DELETE FROM ThingHasProperty WHERE Id = @thingPropertyId
RETURN 0
