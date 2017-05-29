CREATE TABLE [dbo].[InvoiceAppointments] (
    [InvoiceAppointmentId] INT IDENTITY (1, 1) NOT NULL,
    [InvoiceId]            INT NOT NULL,
    [AppointmentId]        INT NOT NULL,
    CONSTRAINT [PK_InvoiceAppointments] PRIMARY KEY CLUSTERED ([InvoiceAppointmentId] ASC),
    CONSTRAINT [FK_InvoiceAppointments_Appointments] FOREIGN KEY ([AppointmentId]) REFERENCES [dbo].[Appointments] ([AppointmentId]),
    CONSTRAINT [FK_InvoiceAppointments_Invoices] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoices] ([InvoiceId])
);

