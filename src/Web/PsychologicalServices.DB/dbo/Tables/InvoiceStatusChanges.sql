CREATE TABLE [dbo].[InvoiceStatusChanges] (
    [InvoiceStatusChangeId] INT                IDENTITY (1, 1) NOT NULL,
    [InvoiceId]             INT                NOT NULL,
    [InvoiceStatusId]       INT                NOT NULL,
    [UpdateDate]            DATETIMEOFFSET (7) CONSTRAINT [DF_InvoiceStatusChanges_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_InvoiceStatusChanges] PRIMARY KEY CLUSTERED ([InvoiceStatusChangeId] ASC),
    CONSTRAINT [FK_InvoiceStatusChanges_Invoices] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoices] ([InvoiceId]),
    CONSTRAINT [FK_InvoiceStatusChanges_InvoiceStatuses] FOREIGN KEY ([InvoiceStatusId]) REFERENCES [dbo].[InvoiceStatuses] ([InvoiceStatusId])
);



