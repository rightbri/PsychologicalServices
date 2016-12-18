CREATE TABLE [dbo].[ReferralTypeIssuesInDispute] (
    [ReferralTypeId]   INT NOT NULL,
    [IssueInDisputeId] INT NOT NULL,
    CONSTRAINT [PK_ReferralTypeIssuesInDispute] PRIMARY KEY CLUSTERED ([ReferralTypeId] ASC, [IssueInDisputeId] ASC),
    CONSTRAINT [FK_ReferralTypeIssuesInDispute_IssuesInDispute] FOREIGN KEY ([IssueInDisputeId]) REFERENCES [dbo].[IssuesInDispute] ([IssueInDisputeId]),
    CONSTRAINT [FK_ReferralTypeIssuesInDispute_ReferralTypes] FOREIGN KEY ([ReferralTypeId]) REFERENCES [dbo].[ReferralTypes] ([ReferralTypeId])
);

