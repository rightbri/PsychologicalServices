CREATE TABLE [dbo].[InvoiceDocuments] (
    [InvoiceDocumentId] INT                IDENTITY (1, 1) NOT NULL,
    [InvoiceId]         INT                NOT NULL,
    [Document]          VARBINARY (MAX)    NOT NULL,
    [CreateDate]        DATETIMEOFFSET (7) CONSTRAINT [DF_InvoiceDocuments_CreateDate] DEFAULT (getutcdate()) NOT NULL,
    [FileName]          VARCHAR (50)       NOT NULL,
    CONSTRAINT [PK_InvoiceDocuments] PRIMARY KEY CLUSTERED ([InvoiceDocumentId] ASC),
    CONSTRAINT [FK_InvoiceDocuments_Invoices] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoices] ([InvoiceId])
);






GO
