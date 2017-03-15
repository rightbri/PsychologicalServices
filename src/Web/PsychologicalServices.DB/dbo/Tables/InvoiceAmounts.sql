CREATE TABLE [dbo].[InvoiceAmounts] (
    [ReferralSourceId]       INT NOT NULL,
    [ReportTypeId]           INT NOT NULL,
    [FirstReportAmount]      INT CONSTRAINT [DF_InvoiceAmounts_InvoiceAmount] DEFAULT ((0)) NOT NULL,
    [AdditionalReportAmount] INT CONSTRAINT [DF_InvoiceAmounts_AdditionalReportAmount] DEFAULT ((50000)) NOT NULL,
    CONSTRAINT [PK_InvoiceAmounts] PRIMARY KEY CLUSTERED ([ReferralSourceId] ASC, [ReportTypeId] ASC),
    CONSTRAINT [FK_InvoiceAmounts_ReferralSources] FOREIGN KEY ([ReferralSourceId]) REFERENCES [dbo].[ReferralSources] ([ReferralSourceId]),
    CONSTRAINT [FK_InvoiceAmounts_ReportTypes] FOREIGN KEY ([ReportTypeId]) REFERENCES [dbo].[ReportTypes] ([ReportTypeId])
);







