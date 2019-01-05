-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InvoiceableAppointmentData]
	@companyId INT,
	@invoiceTypeId INT = NULL,
	@startSearch DATETIMEOFFSET = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @startSearch IS NULL
		BEGIN
			SET @startSearch = DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)
		END

	DECLARE @psychologistInvoiceTypeId INT = 1,
			@psychometristInvoiceTypeId INT = 2,
			@localCompanyId INT = @companyId,
			@localInvoiceTypeId INT = @invoiceTypeId,
			@localStartSearch DATETIMEOFFSET = @startSearch

    --psychometrist months that need invoices
	SELECT
	 DATEPART(YEAR, app.AppointmentTime) AS [Year]
	,DATEPART(MONTH, app.AppointmentTime) AS [Month]
	,ass.AssessmentId
	,app.AppointmentId
	,app.AppointmentTime
	,apps.[Name] AS AppointmentStatus
	,psychometrists.FirstName + ' ' + psychometrists.LastName AS PayableTo
	,psychometrists.UserId AS PayableToId
	,@psychometristInvoiceTypeId AS InvoiceTypeId
	,t.[Name] AS AssessmentType
	,rs.[Name] AS ReferralSource
	,c.FirstName + ' ' + c.LastName AS Claimant
	FROM dbo.Appointments app
	INNER JOIN dbo.AppointmentStatuses apps ON app.AppointmentStatusId = apps.AppointmentStatusId
	INNER JOIN dbo.Users psychometrists ON app.PsychometristId = psychometrists.UserId
	INNER JOIN dbo.Assessments ass ON app.AssessmentId = ass.AssessmentId
	INNER JOIN dbo.AssessmentTypes t ON ass.AssessmentTypeId = t.AssessmentTypeId
	INNER JOIN dbo.ReferralSources rs ON ass.ReferralSourceId = rs.ReferralSourceId
	LEFT JOIN dbo.Claimants c ON ass.ClaimantId = c.ClaimantId
	WHERE 
	apps.CanInvoice = 1
	AND t.PsychometristCanInvoice = 1
	--prevent new invoices being created when new invoiceable appointments are added during a month that is already covered by an invoice
	AND NOT EXISTS (
		SELECT
		*
		FROM dbo.Invoices
		WHERE
		InvoiceTypeId = @psychometristInvoiceTypeId 
		AND PayableToId = app.PsychometristId
		AND YEAR(InvoiceDate) = YEAR(app.AppointmentTime) 
		AND MONTH(InvoiceDate) = MONTH(app.AppointmentTime)
	)
	AND ass.CompanyId = @localCompanyId
	AND app.AppointmentTime >= @localStartSearch
	AND (@localInvoiceTypeId IS NULL OR @localInvoiceTypeId = @psychometristInvoiceTypeId)


	UNION ALL


	--psychologist appointments that need invoices
	SELECT
	 DATEPART(YEAR, app.AppointmentTime) AS [Year]
	,DATEPART(MONTH, app.AppointmentTime) AS [Month]
	,ass.AssessmentId
	,app.AppointmentId
	,app.AppointmentTime
	,apps.[Name] AS AppointmentStatus
	,psychologists.FirstName + ' ' + psychologists.LastName AS PayableTo
	,psychologists.UserId AS PayableToId
	,@psychologistInvoiceTypeId AS InvoiceTypeId
	,t.[Name] AS AssessmentType
	,rs.[Name] AS ReferralSource
	,c.FirstName + ' ' + c.LastName AS Claimant
	FROM dbo.Appointments app
	INNER JOIN dbo.AppointmentStatuses apps ON app.AppointmentStatusId = apps.AppointmentStatusId
	INNER JOIN dbo.Users psychologists ON app.PsychologistId = psychologists.UserId
	INNER JOIN dbo.Assessments ass ON app.AssessmentId = ass.AssessmentId
	INNER JOIN dbo.AssessmentTypes t ON ass.AssessmentTypeId = t.AssessmentTypeId
	INNER JOIN dbo.ReferralSources rs ON ass.ReferralSourceId = rs.ReferralSourceId
	INNER JOIN dbo.AssessmentTypeInvoiceAmounts atia ON t.AssessmentTypeId = atia.AssessmentTypeId AND rs.ReferralSourceId = atia.ReferralSourceId AND ass.CompanyId = atia.CompanyId
	LEFT JOIN dbo.Claimants c ON ass.ClaimantId = c.ClaimantId
	WHERE 
	apps.CanInvoice = 1
	AND NOT EXISTS (
		SELECT
		*
		FROM dbo.InvoiceLineGroupAppointments ilga
		INNER JOIN dbo.InvoiceLineGroups ilg ON ilga.InvoiceLineGroupId = ilg.InvoiceLineGroupId
		INNER JOIN dbo.Invoices i ON ilg.InvoiceId = i.InvoiceId
		WHERE
		ilga.AppointmentId = app.AppointmentId
		AND i.PayableToId = psychologists.UserId
	)
	AND ass.CompanyId = @localCompanyId
	AND app.AppointmentTime >= @localStartSearch
	AND (@localInvoiceTypeId IS NULL OR @localInvoiceTypeId = @psychologistInvoiceTypeId)

END