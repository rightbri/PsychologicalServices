﻿CREATE TABLE [dbo].[GoseFamilyAndFriendshipsDisruptionLevels] (
    [GoseFamilyAndFriendshipsDisruptionLevelId] INT          IDENTITY (1, 1) NOT NULL,
    [Description]                               VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_GoseFamilyAndFriendshipsDisruptionLevels] PRIMARY KEY CLUSTERED ([GoseFamilyAndFriendshipsDisruptionLevelId] ASC)
);

