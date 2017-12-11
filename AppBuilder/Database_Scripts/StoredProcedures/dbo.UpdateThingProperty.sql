CREATE PROCEDURE [dbo].[UpdateThingProperty]
	@thingPropertyId INT,
	@propertyId INT,
	@name NVARCHAR(50),
	@description NVARCHAR(MAX),
	@isList BIT,
	@sequenceOrder INT
AS
	UPDATE ThingHasProperty
	SET PropertyThingId = @propertyId, Name = @name, Description = @description, IsList = @isList, SequenceOrder = @sequenceOrder
	WHERE Id = @thingPropertyId
RETURN 0