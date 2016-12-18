CREATE TABLE [dbo].[AssessmentClaims] (
    [AssessmentId] INT NOT NULL,
    [ClaimId]      INT NOT NULL,
    CONSTRAINT [PK_AssessmentClaims] PRIMARY KEY CLUSTERED ([AssessmentId] ASC, [ClaimId] ASC),
    CONSTRAINT [FK_AssessmentClaims_Assessments] FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[Assessments] ([AssessmentId]),
    CONSTRAINT [FK_AssessmentClaims_Claims] FOREIGN KEY ([ClaimId]) REFERENCES [dbo].[Claims] ([ClaimId])
);

