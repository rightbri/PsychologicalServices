CREATE TABLE [dbo].[Arbitrations] (
    [ArbitrationId]                 INT                IDENTITY (1, 1) NOT NULL,
    [AssessmentId]                  INT                NULL,
    [StartDate]                     DATETIMEOFFSET (7) NULL,
    [EndDate]                       DATETIMEOFFSET (7) NULL,
    [AvailableDate]                 DATETIMEOFFSET (7) NULL,
    [DefenseLawyerId]               INT                NULL,
    [DefenseFileNumber]             NVARCHAR (50)      NULL,
    [Title]                         NVARCHAR (250)     NOT NULL,
    [NoteId]                        INT                NULL,
    [NotifiedDate]                  DATETIMEOFFSET (7) NULL,
    [LetterOfUnderstandingSentDate] DATETIMEOFFSET (7) NULL,
    [PlaintiffLawyerId]             INT                NULL,
    [BillToContactId]               INT                NULL,
    [ClaimantId]                    INT                NOT NULL,
    [PsychologistId]                INT                NOT NULL,
    CONSTRAINT [PK_Arbitrations] PRIMARY KEY CLUSTERED ([ArbitrationId] ASC),
    CONSTRAINT [FK_Arbitrations_Assessments] FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[Assessments] ([AssessmentId]),
    CONSTRAINT [FK_Arbitrations_BillToContact] FOREIGN KEY ([BillToContactId]) REFERENCES [dbo].[Contacts] ([ContactId]),
    CONSTRAINT [FK_Arbitrations_Claimants] FOREIGN KEY ([ClaimantId]) REFERENCES [dbo].[Claimants] ([ClaimantId]),
    CONSTRAINT [FK_Arbitrations_DefenseLawyer] FOREIGN KEY ([DefenseLawyerId]) REFERENCES [dbo].[Contacts] ([ContactId]),
    CONSTRAINT [FK_Arbitrations_Notes] FOREIGN KEY ([NoteId]) REFERENCES [dbo].[Notes] ([NoteId]),
    CONSTRAINT [FK_Arbitrations_PlaintiffLawyer] FOREIGN KEY ([PlaintiffLawyerId]) REFERENCES [dbo].[Contacts] ([ContactId]),
    CONSTRAINT [FK_Arbitrations_Psychologist] FOREIGN KEY ([PsychologistId]) REFERENCES [dbo].[Users] ([UserId])
);











