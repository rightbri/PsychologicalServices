CREATE TABLE [dbo].[InvoiceLineGroups] (
    [InvoiceLineGroupId] INT            IDENTITY (1, 1) NOT NULL,
    [InvoiceId]          INT            NOT NULL,
    [Description]        NVARCHAR (200) NOT NULL,
    [Sort]               INT            CONSTRAINT [DF_InvoiceLineGroups_Sort] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_InvoiceLineGroups] PRIMARY KEY CLUSTERED ([InvoiceLineGroupId] ASC),
    CONSTRAINT [FK_InvoiceLineGroups_Invoices] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoices] ([InvoiceId])
);






GO
CREATE NONCLUSTERED INDEX [IX_InvoiceLineGroups_InvoiceId]
    ON [dbo].[InvoiceLineGroups]([InvoiceId] ASC);

