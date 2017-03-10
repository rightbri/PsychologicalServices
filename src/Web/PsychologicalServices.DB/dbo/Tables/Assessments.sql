CREATE TABLE [dbo].[Assessments] (
    [AssessmentId]               INT            IDENTITY (1, 1) NOT NULL,
    [ReferralTypeId]             INT            NOT NULL,
    [ReferralSourceId]           INT            NOT NULL,
    [AssessmentTypeId]           INT            NOT NULL,
    [Deleted]                    BIT            CONSTRAINT [DF_Assessments_Deleted] DEFAULT ((0)) NOT NULL,
    [CompanyId]                  INT            NOT NULL,
    [ReportStatusId]             INT            NOT NULL,
    [FileSize]                   INT            NULL,
    [ReferralSourceContactEmail] NVARCHAR (100) NULL,
    [DocListWriterId]            INT            NULL,
    [NotesWriterId]              INT            NULL,
    [MedicalFileReceivedDate]    DATETIME       NULL,
    [Psychiatrist]               BIT            CONSTRAINT [DF_Assessments_PsychiatristOnFile] DEFAULT ((0)) NOT NULL,
    [TypicalDay]                 BIT            CONSTRAINT [DF_Assessments_TypicalDay] DEFAULT ((0)) NOT NULL,
    [WorkHistory]                BIT            CONSTRAINT [DF_Assessments_WorkHistory] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Assessments] PRIMARY KEY CLUSTERED ([AssessmentId] ASC),
    CONSTRAINT [FK_Assessments_AssessmentTypes] FOREIGN KEY ([AssessmentTypeId]) REFERENCES [dbo].[AssessmentTypes] ([AssessmentTypeId]),
    CONSTRAINT [FK_Assessments_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId]),
    CONSTRAINT [FK_Assessments_DocListWriter] FOREIGN KEY ([DocListWriterId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Assessments_NotesWriter] FOREIGN KEY ([NotesWriterId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Assessments_ReferralSources] FOREIGN KEY ([ReferralSourceId]) REFERENCES [dbo].[ReferralSources] ([ReferralSourceId]),
    CONSTRAINT [FK_Assessments_ReferralTypes] FOREIGN KEY ([ReferralTypeId]) REFERENCES [dbo].[ReferralTypes] ([ReferralTypeId]),
    CONSTRAINT [FK_Assessments_ReportStatuses] FOREIGN KEY ([ReportStatusId]) REFERENCES [dbo].[ReportStatuses] ([ReportStatusId])
);



