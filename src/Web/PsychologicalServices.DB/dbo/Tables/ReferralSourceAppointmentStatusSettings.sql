CREATE TABLE [dbo].[ReferralSourceAppointmentStatusSettings] (
    [ReferralSourceId]      INT             NOT NULL,
    [AppointmentStatusId]   INT             NOT NULL,
    [InvoiceTypeId]         INT             NOT NULL,
    [InvoiceRate]           DECIMAL (18, 4) NOT NULL,
    [AppointmentSequenceId] INT             CONSTRAINT [DF_ReferralSourceAppointmentStatusSettings_AppointmentSequenceId] DEFAULT ((1)) NOT NULL,
    [InvoiceFee]            INT             CONSTRAINT [DF_ReferralSourceAppointmentStatusSettings_InvoiceFee] DEFAULT ((0)) NOT NULL,
    [ApplyTravelFee]        BIT             CONSTRAINT [DF_ReferralSourceAppointmentStatusSettings_ApplyTravelFee] DEFAULT ((1)) NOT NULL,
    [ApplyLargeFileFee]     BIT             CONSTRAINT [DF_ReferralSourceAppointmentStatusSettings_ApplyLargeFileFee] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ReferralSourceAppointmentStatusSettings_1] PRIMARY KEY CLUSTERED ([ReferralSourceId] ASC, [AppointmentStatusId] ASC, [InvoiceTypeId] ASC, [AppointmentSequenceId] ASC),
    CONSTRAINT [FK_ReferralSourceAppointmentStatusSettings_AppointmentSequences] FOREIGN KEY ([AppointmentSequenceId]) REFERENCES [dbo].[AppointmentSequences] ([AppointmentSequenceId]),
    CONSTRAINT [FK_ReferralSourceAppointmentStatusSettings_AppointmentStatuses] FOREIGN KEY ([AppointmentStatusId]) REFERENCES [dbo].[AppointmentStatuses] ([AppointmentStatusId]),
    CONSTRAINT [FK_ReferralSourceAppointmentStatusSettings_InvoiceTypes] FOREIGN KEY ([InvoiceTypeId]) REFERENCES [dbo].[InvoiceTypes] ([InvoiceTypeId]),
    CONSTRAINT [FK_ReferralSourceAppointmentStatusSettings_ReferralSources] FOREIGN KEY ([ReferralSourceId]) REFERENCES [dbo].[ReferralSources] ([ReferralSourceId])
);





