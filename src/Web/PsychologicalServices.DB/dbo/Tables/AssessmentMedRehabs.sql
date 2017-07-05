CREATE TABLE [dbo].[AssessmentMedRehabs] (
    [MedRehabId]   INT            IDENTITY (1, 1) NOT NULL,
    [AssessmentId] INT            NOT NULL,
    [Date]         DATETIME       NOT NULL,
    [Amount]       INT            NOT NULL,
    [Description]  NVARCHAR (100) NOT NULL,
    [Deleted]      BIT            CONSTRAINT [DF_AssessmentMedRehabs_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AssessmentMedRehabs] PRIMARY KEY CLUSTERED ([MedRehabId] ASC),
    CONSTRAINT [FK_AssessmentMedRehabs_Assessments] FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[Assessments] ([AssessmentId])
);



