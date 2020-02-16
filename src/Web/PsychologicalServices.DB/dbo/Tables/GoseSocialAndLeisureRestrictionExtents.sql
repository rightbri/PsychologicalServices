CREATE TABLE [dbo].[GoseSocialAndLeisureRestrictionExtents] (
    [GoseSocialAndLeisureRestrictionExtentId] INT           IDENTITY (1, 1) NOT NULL,
    [Description]                             VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_GoseSocialAndLeisureRestrictionExtents] PRIMARY KEY CLUSTERED ([GoseSocialAndLeisureRestrictionExtentId] ASC)
);

