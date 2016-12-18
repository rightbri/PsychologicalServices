CREATE TABLE [dbo].[AssessmentIssuesInDispute] (
    [AssessmentId]     INT NOT NULL,
    [IssueIsDisputeId] INT NOT NULL,
    CONSTRAINT [PK_AssessmentIssuesInDispute] PRIMARY KEY CLUSTERED ([AssessmentId] ASC, [IssueIsDisputeId] ASC),
    CONSTRAINT [FK_AssessmentIssuesInDispute_Assessments] FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[Assessments] ([AssessmentId]),
    CONSTRAINT [FK_AssessmentIssuesInDispute_IssuesInDispute] FOREIGN KEY ([IssueIsDisputeId]) REFERENCES [dbo].[IssuesInDispute] ([IssueInDisputeId])
);

