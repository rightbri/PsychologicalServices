CREATE TABLE [dbo].[InvoiceLines] (
    [InvoiceLineId] INT             IDENTITY (1, 1) NOT NULL,
    [InvoiceId]     INT             NOT NULL,
    [Description]   NVARCHAR (100)  NOT NULL,
    [Amount]        DECIMAL (18, 4) NOT NULL,
    [IsCustom]      BIT             CONSTRAINT [DF_InvoiceLines_IsCustom] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_InvoiceLines] PRIMARY KEY CLUSTERED ([InvoiceLineId] ASC),
    CONSTRAINT [FK_InvoiceLines_Invoices] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoices] ([InvoiceId])
);

