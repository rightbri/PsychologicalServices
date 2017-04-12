CREATE TABLE [dbo].[AssessmentReportIssuesInDispute] (
    [ReportId]         INT NOT NULL,
    [IssueInDisputeId] INT NOT NULL,
    CONSTRAINT [PK_AssessmentReportIssuesInDispute] PRIMARY KEY CLUSTERED ([ReportId] ASC, [IssueInDisputeId] ASC),
    CONSTRAINT [FK_AssessmentReportIssuesInDispute_AssessmentReports] FOREIGN KEY ([ReportId]) REFERENCES [dbo].[AssessmentReports] ([ReportId]),
    CONSTRAINT [FK_AssessmentReportIssuesInDispute_IssuesInDispute] FOREIGN KEY ([IssueInDisputeId]) REFERENCES [dbo].[IssuesInDispute] ([IssueInDisputeId])
);

