CREATE TABLE [dbo].[InvoiceStatusPaths] (
    [InvoiceStatusPathId] INT IDENTITY (1, 1) NOT NULL,
    [InvoiceStatusId]     INT NOT NULL,
    [NextInvoiceStatusId] INT NULL,
    CONSTRAINT [PK_InvoiceStatusPaths_1] PRIMARY KEY CLUSTERED ([InvoiceStatusPathId] ASC),
    CONSTRAINT [FK_InvoiceStatusPaths_InvoiceStatuses] FOREIGN KEY ([InvoiceStatusId]) REFERENCES [dbo].[InvoiceStatuses] ([InvoiceStatusId]),
    CONSTRAINT [FK_InvoiceStatusPaths_InvoiceStatuses1] FOREIGN KEY ([NextInvoiceStatusId]) REFERENCES [dbo].[InvoiceStatuses] ([InvoiceStatusId])
);

