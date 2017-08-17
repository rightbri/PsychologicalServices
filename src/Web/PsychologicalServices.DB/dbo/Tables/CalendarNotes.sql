CREATE TABLE [dbo].[CalendarNotes] (
    [CalendarNoteId] INT                IDENTITY (1, 1) NOT NULL,
    [FromDate]       DATETIMEOFFSET (7) NOT NULL,
    [ToDate]         DATETIMEOFFSET (7) NOT NULL,
    [NoteId]         INT                NOT NULL,
    [CompanyId]      INT                NOT NULL,
    CONSTRAINT [PK_CalendarNotes] PRIMARY KEY CLUSTERED ([CalendarNoteId] ASC),
    CONSTRAINT [FK_CalendarNotes_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId]),
    CONSTRAINT [FK_CalendarNotes_Notes] FOREIGN KEY ([NoteId]) REFERENCES [dbo].[Notes] ([NoteId])
);



