
CREATE PROCEDURE [dbo].[DeleteAssessment]
	@AssessmentId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE aa
	FROM dbo.AppointmentAttributes aa
	WHERE
	EXISTS(
		SELECT * FROM dbo.Appointments WHERE aa.AppointmentId = AppointmentId AND AssessmentId = @AssessmentId
	)

	DELETE aa
	FROM dbo.AssessmentAttributes aa
	WHERE
	aa.AssessmentId = @AssessmentId

	DECLARE @claimIds TABLE ( ClaimId INT )

	INSERT INTO @claimIds ([ClaimId])
		SELECT ClaimId FROM dbo.AssessmentClaims WHERE AssessmentId = @AssessmentId

	DELETE FROM dbo.AssessmentClaims WHERE AssessmentId = @AssessmentId

	DELETE c
	FROM dbo.Claims c
	WHERE
	ClaimId IN (
		SELECT ClaimId FROM @claimIds
	)

	DELETE FROM dbo.AssessmentColors WHERE AssessmentId = @AssessmentId

	DELETE FROM dbo.AssessmentMedRehabs WHERE AssessmentId = @AssessmentId

	DECLARE @noteIds TABLE ( NoteId INT )

	INSERT INTO @noteIds ([NoteId])
		SELECT NoteId FROM dbo.AssessmentNotes WHERE AssessmentId = @AssessmentId

	DELETE FROM dbo.AssessmentNotes WHERE AssessmentId = @AssessmentId

	DELETE n
	FROM dbo.Notes n
	WHERE
	EXISTS (
		SELECT * FROM dbo.AssessmentNotes WHERE NoteId = n.NoteId AND AssessmentId = @AssessmentId
	)

	DECLARE @reportIds TABLE ( ReportId INT )

	INSERT INTO @reportIds ([ReportId])
		SELECT ReportId FROM dbo.AssessmentReports WHERE AssessmentId = @AssessmentId

	DELETE FROM dbo.AssessmentReportIssuesInDispute WHERE ReportId IN (
		SELECT ReportId FROM @reportIds
	)

	DELETE FROM dbo.AssessmentReports WHERE AssessmentId = @AssessmentId

	DECLARE @invoiceIds TABLE ( InvoiceId INT )

	INSERT INTO @invoiceIds ([InvoiceId])
		SELECT DISTINCT
		InvoiceId 
		FROM dbo.InvoiceLineGroupAppointments ilga
		INNER JOIN dbo.InvoiceLineGroups ilg ON ilga.InvoiceLineGroupId = ilg.InvoiceLineGroupId
		INNER JOIN dbo.Appointments a ON ilga.AppointmentId = a.AppointmentId
		WHERE
		a.AssessmentId = @AssessmentId

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

	DELETE FROM dbo.InvoiceLineGroups 
	WHERE InvoiceId IN (
		SELECT InvoiceId FROM @invoiceIds
	)

	DELETE FROM dbo.Invoices WHERE InvoiceId IN (
		SELECT * FROM @invoiceIds
	)

	DELETE FROM dbo.Arbitrations WHERE AssessmentId = @AssessmentId

	DELETE FROM dbo.Appointments WHERE AssessmentId = @AssessmentId

	DELETE FROM dbo.Assessments WHERE AssessmentId = @AssessmentId

END