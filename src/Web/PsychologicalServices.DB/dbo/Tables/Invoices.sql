﻿CREATE TABLE [dbo].[Invoices] (
    [InvoiceId]       INT             IDENTITY (1, 1) NOT NULL,
    [Identifier]      NVARCHAR (20)   NOT NULL,
    [InvoiceDate]     DATETIME        NOT NULL,
    [AppointmentId]   INT             NOT NULL,
    [InvoiceStatusId] INT             NOT NULL,
    [UpdateDate]      DATETIME        CONSTRAINT [DF_Invoices_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    [TaxRate]         DECIMAL (18, 4) NOT NULL,
    [Total]           DECIMAL (18, 4) NOT NULL,
    CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED ([InvoiceId] ASC),
    CONSTRAINT [FK_Invoices_Appointments] FOREIGN KEY ([AppointmentId]) REFERENCES [dbo].[Appointments] ([AppointmentId]),
    CONSTRAINT [FK_Invoices_InvoiceStatuses] FOREIGN KEY ([InvoiceStatusId]) REFERENCES [dbo].[InvoiceStatuses] ([InvoiceStatusId])
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