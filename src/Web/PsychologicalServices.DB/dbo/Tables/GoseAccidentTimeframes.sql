CREATE TABLE [dbo].[GoseAccidentTimeframes] (
    [GoseAccidentTimeframeId] INT          IDENTITY (1, 1) NOT NULL,
    [Months]                  INT          NOT NULL,
    [Description]             VARCHAR (50) NOT NULL,
    [Basic]                   BIT          NOT NULL,
    [Intermediate]            BIT          NOT NULL,
    [Advanced]                BIT          NOT NULL,
    CONSTRAINT [PK_GoseAccidentTimeframes] PRIMARY KEY CLUSTERED ([GoseAccidentTimeframeId] ASC),
    CONSTRAINT [FK_GoseAccidentTimeframes_GoseAccidentTimeframes] FOREIGN KEY ([GoseAccidentTimeframeId]) REFERENCES [dbo].[GoseAccidentTimeframes] ([GoseAccidentTimeframeId])
);

