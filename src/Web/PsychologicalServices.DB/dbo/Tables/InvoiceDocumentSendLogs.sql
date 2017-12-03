CREATE TABLE [dbo].[InvoiceDocumentSendLogs] (
    [InvoiceDocumentSendLogId] INT                IDENTITY (1, 1) NOT NULL,
    [InvoiceDocumentId]        INT                NOT NULL,
    [Recipients]               NVARCHAR (4000)    NOT NULL,
    [SentDate]                 DATETIMEOFFSET (7) CONSTRAINT [DF_Table_1_SendDate] DEFAULT (sysdatetimeoffset()) NOT NULL,
    CONSTRAINT [PK_InvoiceDocumentSendLogs] PRIMARY KEY CLUSTERED ([InvoiceDocumentSendLogId] ASC),
    CONSTRAINT [FK_InvoiceDocumentSendLogs_InvoiceDocuments] FOREIGN KEY ([InvoiceDocumentId]) REFERENCES [dbo].[InvoiceDocuments] ([InvoiceDocumentId])
);

