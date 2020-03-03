CREATE TABLE [dbo].[GoseWorkRestrictionLevels] (
    [GoseWorkRestrictionLevelId] INT           IDENTITY (1, 1) NOT NULL,
    [Description]                VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_GoseWorkRestrictionLevels] PRIMARY KEY CLUSTERED ([GoseWorkRestrictionLevelId] ASC)
);



