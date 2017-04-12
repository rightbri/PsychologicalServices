CREATE TABLE [dbo].[ReportTypeInvoiceAmounts] (
    [ReferralSourceId] INT NOT NULL,
    [ReportTypeId]     INT NOT NULL,
    [InvoiceAmount]    INT CONSTRAINT [DF_ReportTypeInvoiceAmounts_InvoiceAmount] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ReportTypeInvoiceAmounts] PRIMARY KEY CLUSTERED ([ReferralSourceId] ASC, [ReportTypeId] ASC),
    CONSTRAINT [FK_ReportTypeInvoiceAmounts_ReferralSources] FOREIGN KEY ([ReferralSourceId]) REFERENCES [dbo].[ReferralSources] ([ReferralSourceId]),
    CONSTRAINT [FK_ReportTypeInvoiceAmounts_ReportTypes] FOREIGN KEY ([ReportTypeId]) REFERENCES [dbo].[ReportTypes] ([ReportTypeId])
);

