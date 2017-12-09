CREATE TABLE [dbo].[Thing] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [ThingTypeId] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

