

CREATE PROCEDURE [dbo].[DeleteInvoice]
	@InvoiceId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @invoiceIds TABLE ( InvoiceId INT )

	INSERT INTO @invoiceIds ([InvoiceId])
		SELECT @InvoiceId

	DELETE idsl FROM dbo.InvoiceDocumentSendLogs idsl
	INNER JOIN dbo.InvoiceDocuments id ON idsl.InvoiceDocumentId = id.InvoiceDocumentId
	WHERE id.InvoiceId IN (
		SELECT InvoiceId FROM @invoiceIds
	)

	DELETE FROM dbo.InvoiceDocuments WHERE InvoiceId IN (
		SELECT InvoiceId FROM @invoiceIds
	)

	DELETE FROM dbo.InvoiceStatusChanges WHERE InvoiceId IN (
		SELECT InvoiceId FROM @invoiceIds
	)

	DELETE il FROM dbo.InvoiceLines il
	INNER JOIN dbo.InvoiceLineGroups ilg ON il.InvoiceLineGroupId = ilg.InvoiceLineGroupId
	WHERE ilg.InvoiceId IN (
		SELECT InvoiceId FROM @invoiceIds
	)

	DELETE ilga FROM dbo.InvoiceLineGroupAppointments ilga
	INNER JOIN dbo.InvoiceLineGroups ilg ON ilga.InvoiceLineGroupId = ilg.InvoiceLineGroupId
	WHERE ilg.InvoiceId IN (
		SELECT InvoiceId FROM @invoiceIds
	)

	DELETE ilga FROM dbo.InvoiceLineGroupArbitrations ilga
	INNER JOIN dbo.InvoiceLineGroups ilg ON ilga.InvoiceLineGroupId = ilg.InvoiceLineGroupId 
	WHERE ilg.InvoiceId IN (
		SELECT InvoiceId FROM @invoiceIds
	)

	DELETE ilgr FROM dbo.InvoiceLineGroupRawTestData ilgr
	INNER JOIN dbo.InvoiceLineGroups ilg ON ilgr.InvoiceLineGroupId = ilg.InvoiceLineGroupId 
	WHERE ilg.InvoiceId IN (
		SELECT InvoiceId FROM @invoiceIds
	)

	DELETE ilgc FROM dbo.InvoiceLineGroupConsultingAgreements ilgc
	INNER JOIN dbo.InvoiceLineGroups ilg ON ilgc.InvoiceLineGroupId = ilg.InvoiceLineGroupId 
	WHERE ilg.InvoiceId IN (
		SELECT InvoiceId FROM @invoiceIds
	)

	DELETE FROM dbo.InvoiceLineGroups 
	WHERE InvoiceId IN (
		SELECT InvoiceId FROM @invoiceIds
	)

	DELETE FROM dbo.Invoices WHERE InvoiceId IN (
		SELECT * FROM @invoiceIds
	)

END