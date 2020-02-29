CREATE TABLE [dbo].[GoseRespondentTypes] (
    [GoseRespondentTypeId] INT          IDENTITY (1, 1) NOT NULL,
    [Description]          VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_GoseRespondentTypes] PRIMARY KEY CLUSTERED ([GoseRespondentTypeId] ASC)
);

