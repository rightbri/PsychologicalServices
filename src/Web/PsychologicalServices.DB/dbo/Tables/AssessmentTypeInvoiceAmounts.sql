CREATE TABLE [dbo].[AssessmentTypeInvoiceAmounts] (
    [CompanyId]                 INT NOT NULL,
    [ReferralSourceId]          INT NOT NULL,
    [AssessmentTypeId]          INT NOT NULL,
    [SingleReportInvoiceAmount] INT NOT NULL,
    [ComboReportInvoiceAmount]  INT NOT NULL,
    CONSTRAINT [PK_AssessmentTypeInvoiceAmounts] PRIMARY KEY CLUSTERED ([CompanyId] ASC, [ReferralSourceId] ASC, [AssessmentTypeId] ASC),
    CONSTRAINT [FK_AssessmentTypeInvoiceAmounts_AssessmentTypes] FOREIGN KEY ([AssessmentTypeId]) REFERENCES [dbo].[AssessmentTypes] ([AssessmentTypeId]),
    CONSTRAINT [FK_AssessmentTypeInvoiceAmounts_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId]),
    CONSTRAINT [FK_AssessmentTypeInvoiceAmounts_ReferralSources] FOREIGN KEY ([ReferralSourceId]) REFERENCES [dbo].[ReferralSources] ([ReferralSourceId])
);

