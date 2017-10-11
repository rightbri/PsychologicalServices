CREATE TABLE [dbo].[AppointmentStatusInvoiceRates] (
    [CompanyId]               INT            NOT NULL,
    [ReferralSourceId]        INT            NOT NULL,
    [AppointmentStatusId]     INT            NOT NULL,
    [AppointmentSequenceId]   INT            NOT NULL,
    [InvoiceRate]             DECIMAL (3, 2) NOT NULL,
    [ApplyCompletionFee]      BIT            CONSTRAINT [DF_AppointmentStatusInvoiceRates_ApplyCompletionFee] DEFAULT ((0)) NOT NULL,
    [ApplyLargeFileFee]       BIT            CONSTRAINT [DF_AppointmentStatusInvoiceRates_ApplyLargeFileFee] DEFAULT ((0)) NOT NULL,
    [ApplyTravelFee]          BIT            CONSTRAINT [DF_AppointmentStatusInvoiceRates_ApplyTravelFee] DEFAULT ((0)) NOT NULL,
    [ApplyIssueInDisputeFees] BIT            CONSTRAINT [DF_AppointmentStatusInvoiceRates_ApplyIssueInDisputeFees] DEFAULT ((0)) NOT NULL,
    [ApplyExtraReportFees]    BIT            CONSTRAINT [DF_AppointmentStatusInvoiceRates_ApplyExtraReportFees] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AppointmentStatusInvoiceRates] PRIMARY KEY CLUSTERED ([CompanyId] ASC, [ReferralSourceId] ASC, [AppointmentStatusId] ASC, [AppointmentSequenceId] ASC),
    CONSTRAINT [FK_AppointmentStatusInvoiceRates_AppointmentSequences] FOREIGN KEY ([AppointmentSequenceId]) REFERENCES [dbo].[AppointmentSequences] ([AppointmentSequenceId]),
    CONSTRAINT [FK_AppointmentStatusInvoiceRates_AppointmentStatuses] FOREIGN KEY ([AppointmentStatusId]) REFERENCES [dbo].[AppointmentStatuses] ([AppointmentStatusId]),
    CONSTRAINT [FK_AppointmentStatusInvoiceRates_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId]),
    CONSTRAINT [FK_AppointmentStatusInvoiceRates_ReferralSources] FOREIGN KEY ([ReferralSourceId]) REFERENCES [dbo].[ReferralSources] ([ReferralSourceId])
);



