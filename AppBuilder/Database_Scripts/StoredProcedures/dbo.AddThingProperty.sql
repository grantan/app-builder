CREATE PROCEDURE [dbo].[AddThingProperty]
	@ownerId INT,
	@propertyId INT,
	@name NVARCHAR(50),
	@description NVARCHAR(MAX),
	@isList BIT,
	@sequenceOrder INT
AS
	INSERT INTO ThingHasProperty(OwnerThingId, PropertyThingId, Name, Description, IsList, SequenceOrder)
	VALUES(@ownerId, @propertyId, @name, @description, @isList, @sequenceOrder)
	SELECT CAST(SCOPE_IDENTITY() AS INT)
RETURN 0