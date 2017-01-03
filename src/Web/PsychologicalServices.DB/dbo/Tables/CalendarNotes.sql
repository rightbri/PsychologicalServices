CREATE TABLE [dbo].[CalendarNotes] (
    [CalendarNoteId] INT      IDENTITY (1, 1) NOT NULL,
    [FromDate]       DATETIME NULL,
    [ToDate]         DATETIME NULL,
    [NoteId]         INT      NOT NULL,
    CONSTRAINT [PK_CalendarNotes] PRIMARY KEY CLUSTERED ([CalendarNoteId] ASC),
    CONSTRAINT [FK_CalendarNotes_Notes] FOREIGN KEY ([NoteId]) REFERENCES [dbo].[Notes] ([NoteId])
);

