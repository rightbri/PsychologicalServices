CREATE TABLE [dbo].[IssuesInDispute] (
    [IssueInDisputeId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50) NOT NULL,
    [IsActive]         BIT           CONSTRAINT [DF_IssuesInDispute_IsActive] DEFAULT ((1)) NOT NULL,
    [Instructions]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_IssuesInDispute] PRIMARY KEY CLUSTERED ([IssueInDisputeId] ASC)
);

