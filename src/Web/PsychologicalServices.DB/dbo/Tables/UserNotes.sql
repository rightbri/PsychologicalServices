CREATE TABLE [dbo].[UserNotes] (
    [NoteId] INT NOT NULL,
    [UserId] INT NOT NULL,
    CONSTRAINT [PK_UserNotes] PRIMARY KEY CLUSTERED ([NoteId] ASC, [UserId] ASC),
    CONSTRAINT [FK_UserNotes_Notes] FOREIGN KEY ([NoteId]) REFERENCES [dbo].[Notes] ([NoteId]),
    CONSTRAINT [FK_UserNotes_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

