CREATE TABLE [dbo].[InvoiceLines] (
    [InvoiceLineId]        INT            IDENTITY (1, 1) NOT NULL,
    [InvoiceAppointmentId] INT            NOT NULL,
    [Description]          NVARCHAR (100) NOT NULL,
    [Amount]               INT            NOT NULL,
    [IsCustom]             BIT            CONSTRAINT [DF_InvoiceLines_IsCustom] DEFAULT ((0)) NOT NULL,
    [ApplyInvoiceRate]     BIT            CONSTRAINT [DF_InvoiceLines_ApplyInvoiceRate] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_InvoiceLines] PRIMARY KEY CLUSTERED ([InvoiceLineId] ASC),
    CONSTRAINT [FK_InvoiceLines_InvoiceAppointments] FOREIGN KEY ([InvoiceAppointmentId]) REFERENCES [dbo].[InvoiceAppointments] ([InvoiceAppointmentId])
);







