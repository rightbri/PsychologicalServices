CREATE TABLE [dbo].[InvoiceDocumentArchive] (
    [InvoiceDocumentArchiveId] INT             IDENTITY (1, 1) NOT NULL,
    [InvoiceId]                INT             NOT NULL,
    [Document]                 VARBINARY (MAX) NOT NULL,
    [CreatedDate]              DATETIME        NOT NULL,
    CONSTRAINT [PK_InvoiceDocumentArchive] PRIMARY KEY CLUSTERED ([InvoiceDocumentArchiveId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_InvoiceDocumentArchive]
    ON [dbo].[InvoiceDocumentArchive]([InvoiceId] ASC);

