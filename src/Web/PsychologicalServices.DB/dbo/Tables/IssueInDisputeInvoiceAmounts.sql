CREATE TABLE [dbo].[IssueInDisputeInvoiceAmounts] (
    [CompanyId]        INT NOT NULL,
    [IssueInDisputeId] INT NOT NULL,
    [InvoiceAmount]    INT CONSTRAINT [DF_IssueInDisputeInvoiceAmounts_InvoiceAmount] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_IssueInDisputeInvoiceAmounts] PRIMARY KEY CLUSTERED ([CompanyId] ASC, [IssueInDisputeId] ASC),
    CONSTRAINT [FK_IssueInDisputeInvoiceAmounts_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId]),
    CONSTRAINT [FK_IssueInDisputeInvoiceAmounts_IssuesInDispute] FOREIGN KEY ([IssueInDisputeId]) REFERENCES [dbo].[IssuesInDispute] ([IssueInDisputeId])
);

