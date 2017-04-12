CREATE TABLE [dbo].[InvoiceDocuments] (
    [InvoiceId]   INT             NOT NULL,
    [Document]    VARBINARY (MAX) NOT NULL,
    [CreatedDate] DATETIME        CONSTRAINT [DF_InvoiceDocuments_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_InvoiceDocuments] PRIMARY KEY CLUSTERED ([InvoiceId] ASC),
    CONSTRAINT [FK_InvoiceDocuments_Invoices] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoices] ([InvoiceId])
);


GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[Tr_InvoiceDocuments_Update] 
   ON  [dbo].[InvoiceDocuments] 
   AFTER INSERT,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[InvoiceDocumentArchive] ([InvoiceId],[Document],[CreatedDate]) 
		SELECT [InvoiceId],[Document],[CreatedDate] FROM inserted

END