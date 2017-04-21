CREATE TABLE [dbo].[ReferralSourceAppointmentStatusSettings] (
    [ReferralSourceId]    INT             NOT NULL,
    [AppointmentStatusId] INT             NOT NULL,
    [InvoiceRate]         DECIMAL (18, 4) NOT NULL,
    CONSTRAINT [PK_ReferralSourceAppointmentStatusSettings] PRIMARY KEY CLUSTERED ([ReferralSourceId] ASC, [AppointmentStatusId] ASC),
    CONSTRAINT [FK_ReferralSourceAppointmentStatusSettings_AppointmentStatuses] FOREIGN KEY ([AppointmentStatusId]) REFERENCES [dbo].[AppointmentStatuses] ([AppointmentStatusId]),
    CONSTRAINT [FK_ReferralSourceAppointmentStatusSettings_ReferralSources] FOREIGN KEY ([ReferralSourceId]) REFERENCES [dbo].[ReferralSources] ([ReferralSourceId])
);

