CREATE TABLE [dbo].[Arbitrations] (
    [ArbitrationId]     INT                IDENTITY (1, 1) NOT NULL,
    [AssessmentId]      INT                NOT NULL,
    [StartDate]         DATETIMEOFFSET (7) NULL,
    [EndDate]           DATETIMEOFFSET (7) NULL,
    [AvailableDate]     DATETIMEOFFSET (7) NULL,
    [DefenseLawyerId]   INT                NULL,
    [DefenseFileNumber] NVARCHAR (50)      NULL,
    [Title]             NVARCHAR (250)     NOT NULL,
    [NoteId]            INT                NULL,
    CONSTRAINT [PK_Arbitrations] PRIMARY KEY CLUSTERED ([ArbitrationId] ASC),
    CONSTRAINT [FK_Arbitrations_Assessments] FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[Assessments] ([AssessmentId]),
    CONSTRAINT [FK_Arbitrations_Contacts] FOREIGN KEY ([DefenseLawyerId]) REFERENCES [dbo].[Contacts] ([ContactId]),
    CONSTRAINT [FK_Arbitrations_Notes] FOREIGN KEY ([NoteId]) REFERENCES [dbo].[Notes] ([NoteId])
);









