CREATE TABLE [dbo].[Log] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [Date]      DATETIME      NOT NULL,
    [Level]     VARCHAR (20)  NOT NULL,
    [Logger]    VARCHAR (255) NOT NULL,
    [Message]   VARCHAR (MAX) NOT NULL,
    [Username]  VARCHAR (255) NOT NULL,
    [Exception] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([ID] ASC)
);

