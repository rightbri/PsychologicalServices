CREATE TABLE [dbo].[Invoices] (
    [InvoiceId]          INT                IDENTITY (1, 1) NOT NULL,
    [Identifier]         NVARCHAR (20)      NOT NULL,
    [InvoiceDate]        DATETIMEOFFSET (7) NOT NULL,
    [InvoiceStatusId]    INT                NOT NULL,
    [UpdateDate]         DATETIMEOFFSET (7) CONSTRAINT [DF_Invoices_UpdateDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [TaxRate]            DECIMAL (18, 4)    NOT NULL,
    [Total]              INT                NOT NULL,
    [InvoiceTypeId]      INT                NOT NULL,
    [PayableToId]        INT                NOT NULL,
    [InvoicePeriodBegin] DATETIMEOFFSET (7) NOT NULL,
    [InvoicePeriodEnd]   DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED ([InvoiceId] ASC),
    CONSTRAINT [FK_Invoices_InvoiceStatuses] FOREIGN KEY ([InvoiceStatusId]) REFERENCES [dbo].[InvoiceStatuses] ([InvoiceStatusId]),
    CONSTRAINT [FK_Invoices_InvoiceTypes] FOREIGN KEY ([InvoiceTypeId]) REFERENCES [dbo].[InvoiceTypes] ([InvoiceTypeId]),
    CONSTRAINT [FK_Invoices_Users] FOREIGN KEY ([PayableToId]) REFERENCES [dbo].[Users] ([UserId])
);




















GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[Tr_Invoices_Update] 
   ON  dbo.Invoices 
   AFTER INSERT,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE	@isChange BIT = 0
	
    -- Insert statements for trigger here
	IF EXISTS (SELECT * FROM DELETED)
		BEGIN
			DECLARE @beforeStatusId INT,
					@afterStatusId INT

			SELECT @beforeStatusId = [InvoiceStatusId] FROM deleted
			
			SELECT @afterStatusId = [InvoiceStatusId] FROM inserted
			
			IF @beforeStatusId <> @afterStatusId
				SET @isChange = 1

		END
	ELSE
		SET @isChange = 1

	IF @isChange = 1
		INSERT INTO [dbo].[InvoiceStatusChanges] ([InvoiceId],[InvoiceStatusId],[UpdateDate]) 
			SELECT [InvoiceId],[InvoiceStatusId],[UpdateDate] FROM inserted

END