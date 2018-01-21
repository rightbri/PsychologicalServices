CREATE TABLE [dbo].[InvoiceLineGroups] (
    [InvoiceLineGroupId] INT            IDENTITY (1, 1) NOT NULL,
    [InvoiceId]          INT            NOT NULL,
    [Description]        NVARCHAR (100) NULL,
    CONSTRAINT [PK_InvoiceLineGroups] PRIMARY KEY CLUSTERED ([InvoiceLineGroupId] ASC),
    CONSTRAINT [FK_InvoiceLineGroups_Invoices] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoices] ([InvoiceId])
);

