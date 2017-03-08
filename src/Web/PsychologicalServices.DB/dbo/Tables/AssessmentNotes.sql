CREATE TABLE [dbo].[AssessmentNotes] (
    [AssessmentId] INT NOT NULL,
    [NoteId]       INT NOT NULL,
    CONSTRAINT [PK_AssessmentNotes] PRIMARY KEY CLUSTERED ([AssessmentId] ASC, [NoteId] ASC),
    CONSTRAINT [FK_AssessmentNotes_Assessments] FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[Assessments] ([AssessmentId]),
    CONSTRAINT [FK_AssessmentNotes_Notes] FOREIGN KEY ([NoteId]) REFERENCES [dbo].[Notes] ([NoteId])
);

