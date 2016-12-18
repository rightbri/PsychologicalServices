CREATE TABLE [dbo].[InvoiceAmounts] (
    [ReferralSourceId] INT             NOT NULL,
    [ReportTypeId]     INT             NOT NULL,
    [InvoiceAmount]    DECIMAL (19, 4) NOT NULL,
    CONSTRAINT [PK_InvoiceAmounts] PRIMARY KEY CLUSTERED ([ReferralSourceId] ASC, [ReportTypeId] ASC),
    CONSTRAINT [FK_InvoiceAmounts_ReferralSources] FOREIGN KEY ([ReferralSourceId]) REFERENCES [dbo].[ReferralSources] ([ReferralSourceId]),
    CONSTRAINT [FK_InvoiceAmounts_ReferralTypes] FOREIGN KEY ([ReportTypeId]) REFERENCES [dbo].[ReferralTypes] ([ReferralTypeId])
);

