CREATE TABLE [dbo].[ThingHasProperty] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [OwnerThingId]    INT            NOT NULL,
    [PropertyThingId] INT            NOT NULL,
    [Name]            NVARCHAR (50)  NOT NULL,
    [Description]     NVARCHAR (MAX) NOT NULL,
    [IsList]          BIT            DEFAULT ((0)) NOT NULL,
    [SequenceOrder] INT NOT NULL DEFAULT (0), 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

