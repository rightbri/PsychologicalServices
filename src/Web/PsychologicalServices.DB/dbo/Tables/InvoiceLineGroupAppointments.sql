﻿CREATE TABLE [dbo].[InvoiceLineGroupAppointments] (
    [InvoiceLineGroupId] INT NOT NULL,
    [AppointmentId]      INT NOT NULL,
    CONSTRAINT [PK_InvoiceLineGroupAppointments_1] PRIMARY KEY CLUSTERED ([InvoiceLineGroupId] ASC),
    CONSTRAINT [FK_InvoiceLineGroupAppointments_Appointments] FOREIGN KEY ([AppointmentId]) REFERENCES [dbo].[Appointments] ([AppointmentId]),
    CONSTRAINT [FK_InvoiceLineGroupAppointments_InvoiceLineGroups] FOREIGN KEY ([InvoiceLineGroupId]) REFERENCES [dbo].[InvoiceLineGroups] ([InvoiceLineGroupId])
);



