CREATE TABLE [dbo].[Assessments] (
    [AssessmentId]                       INT                IDENTITY (1, 1) NOT NULL,
    [ReferralTypeId]                     INT                NOT NULL,
    [ReferralSourceId]                   INT                NOT NULL,
    [AssessmentTypeId]                   INT                NOT NULL,
    [CompanyId]                          INT                NOT NULL,
    [ReportStatusId]                     INT                NOT NULL,
    [FileSize]                           INT                NULL,
    [ReferralSourceContactEmail]         NVARCHAR (4000)    NULL,
    [DocListWriterId]                    INT                NULL,
    [NotesWriterId]                      INT                NULL,
    [MedicalFileReceivedDate]            DATETIMEOFFSET (7) NULL,
    [IsLargeFile]                        BIT                CONSTRAINT [DF_Assessments_IsLargeFile] DEFAULT ((0)) NOT NULL,
    [ReferralSourceFileNumber]           NVARCHAR (50)      NULL,
    [CreateDate]                         DATETIMEOFFSET (7) CONSTRAINT [DF_Assessments_CreateDate] DEFAULT (getdate()) NOT NULL,
    [CreateUserId]                       INT                NOT NULL,
    [UpdateDate]                         DATETIMEOFFSET (7) CONSTRAINT [DF_Assessments_UpdateDate] DEFAULT (getdate()) NOT NULL,
    [UpdateUserId]                       INT                NOT NULL,
    [SummaryNoteId]                      INT                NULL,
    [PsychologistFoundInFavorOfClaimant] BIT                NULL,
    [NeurocognitiveCredibilityId]        INT                NULL,
    [PsychologicalCredibilityId]         INT                NULL,
    [DiagnosisFoundReponseId]            INT                NULL,
    [IsReassessment]                     BIT                CONSTRAINT [DF_Assessments_IsReassessment] DEFAULT ((0)) NOT NULL,
    [PreviouslySeenDate]                 DATETIMEOFFSET (7) NULL,
    [ClaimantId]                         INT                NULL,
    CONSTRAINT [PK_Assessments] PRIMARY KEY CLUSTERED ([AssessmentId] ASC),
    CONSTRAINT [FK_Assessments_AssessmentTypes] FOREIGN KEY ([AssessmentTypeId]) REFERENCES [dbo].[AssessmentTypes] ([AssessmentTypeId]),
    CONSTRAINT [FK_Assessments_Claimants] FOREIGN KEY ([ClaimantId]) REFERENCES [dbo].[Claimants] ([ClaimantId]),
    CONSTRAINT [FK_Assessments_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId]),
    CONSTRAINT [FK_Assessments_Credibilities] FOREIGN KEY ([NeurocognitiveCredibilityId]) REFERENCES [dbo].[Credibilities] ([CredibilityId]),
    CONSTRAINT [FK_Assessments_Credibilities1] FOREIGN KEY ([PsychologicalCredibilityId]) REFERENCES [dbo].[Credibilities] ([CredibilityId]),
    CONSTRAINT [FK_Assessments_DiagnosisFoundResponses] FOREIGN KEY ([DiagnosisFoundReponseId]) REFERENCES [dbo].[DiagnosisFoundResponses] ([DiagnosisFoundResponseId]),
    CONSTRAINT [FK_Assessments_DocListWriter] FOREIGN KEY ([DocListWriterId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Assessments_Notes] FOREIGN KEY ([SummaryNoteId]) REFERENCES [dbo].[Notes] ([NoteId]),
    CONSTRAINT [FK_Assessments_NotesWriter] FOREIGN KEY ([NotesWriterId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Assessments_ReferralSources] FOREIGN KEY ([ReferralSourceId]) REFERENCES [dbo].[ReferralSources] ([ReferralSourceId]),
    CONSTRAINT [FK_Assessments_ReferralTypes] FOREIGN KEY ([ReferralTypeId]) REFERENCES [dbo].[ReferralTypes] ([ReferralTypeId]),
    CONSTRAINT [FK_Assessments_ReportStatuses] FOREIGN KEY ([ReportStatusId]) REFERENCES [dbo].[ReportStatuses] ([ReportStatusId]),
    CONSTRAINT [FK_Assessments_Users] FOREIGN KEY ([CreateUserId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Assessments_Users1] FOREIGN KEY ([UpdateUserId]) REFERENCES [dbo].[Users] ([UserId])
);























