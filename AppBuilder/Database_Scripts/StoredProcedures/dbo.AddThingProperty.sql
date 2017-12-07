CREATE PROCEDURE [dbo].[AddThingProperty]
	@ownerId INT,
	@propertyId INT,
	@name NVARCHAR(50),
	@description NVARCHAR(MAX),
	@isList BIT
AS
	INSERT INTO ThingHasProperty(OwnerThingId, PropertyThingId, Name, Description, IsList)
	VALUES(@ownerId, @propertyId, @name, @description, @isList)
RETURN 0