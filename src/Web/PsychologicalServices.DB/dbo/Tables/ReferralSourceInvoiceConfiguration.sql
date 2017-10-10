CREATE TABLE [dbo].[ReferralSourceInvoiceConfiguration] (
    [ReferralSourceId]    INT NOT NULL,
    [CompanyId]           INT NOT NULL,
    [LargeFileSize]       INT NOT NULL,
    [LargeFileFee]        INT NOT NULL,
    [ExtraReportFee]      INT NOT NULL,
    [CompletionFeeAmount] INT NOT NULL,
    CONSTRAINT [PK_ReferralSourceInvoiceConfiguration_1] PRIMARY KEY CLUSTERED ([ReferralSourceId] ASC, [CompanyId] ASC),
    CONSTRAINT [FK_ReferralSourceInvoiceConfiguration_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId]),
    CONSTRAINT [FK_ReferralSourceInvoiceConfiguration_ReferralSources] FOREIGN KEY ([ReferralSourceId]) REFERENCES [dbo].[ReferralSources] ([ReferralSourceId])
);





