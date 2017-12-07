CREATE PROCEDURE [dbo].[UpdateThingProperty]
	@thingPropertyId INT,
	@propertyId INT,
	@name NVARCHAR(50),
	@description NVARCHAR(MAX),
	@isList BIT
AS
	UPDATE ThingHasProperty
	SET PropertyThingId = @propertyId, Name = @name, Description = @description, IsList = @isList
	WHERE Id = @thingPropertyId
RETURN 0