CREATE TABLE [dbo].[IssuesInDispute] (
    [IssueInDisputeId] INT             IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50)   NOT NULL,
    [IsActive]         BIT             CONSTRAINT [DF_IssuesInDispute_IsActive] DEFAULT ((1)) NOT NULL,
    [AdditionalFee]    DECIMAL (18, 4) CONSTRAINT [DF_IssuesInDispute_AdditionalFee] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_IssuesInDispute] PRIMARY KEY CLUSTERED ([IssueInDisputeId] ASC)
);



