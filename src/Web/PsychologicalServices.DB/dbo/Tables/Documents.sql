CREATE TABLE [dbo].[Documents] (
    [DocumentId] INT             IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (200)  NOT NULL,
    [Size]       INT             NOT NULL,
    [Data]       VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED ([DocumentId] ASC)
);

