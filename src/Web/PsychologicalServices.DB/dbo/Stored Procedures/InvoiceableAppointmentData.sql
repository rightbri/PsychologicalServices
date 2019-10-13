-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InvoiceableAppointmentData]
	@companyId INT,
	@invoiceTypeId INT = NULL,
	@startDateSearch DATETIMEOFFSET = NULL,
	@endDateSearch DATETIMEOFFSET = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @startDateSearch IS NULL
		BEGIN
			SET @startDateSearch = DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), 0)
		END

	IF @endDateSearch IS NULL
		BEGIN
			SET @endDateSearch = DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()) + 1, 0)
		END

	DECLARE @psychologistInvoiceTypeId INT = 1,
			@psychometristInvoiceTypeId INT = 2,
			@localCompanyId INT = @companyId,
			@localInvoiceTypeId INT = @invoiceTypeId,
			@localStartDateSearch DATETIMEOFFSET = @startDateSearch,
			@localEndDateSearch DATETIMEOFFSET = @endDateSearch

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
		FROM dbo.InvoiceLineGroupAppointments ilga
		INNER JOIN dbo.InvoiceLineGroups ilg ON ilga.InvoiceLineGroupId = ilg.InvoiceLineGroupId
		INNER JOIN dbo.Invoices i ON ilg.InvoiceId = i.InvoiceId
		WHERE 
		InvoiceTypeId = @psychometristInvoiceTypeId 
		AND ilga.AppointmentId = app.AppointmentId
		AND i.PayableToId = app.PsychometristId 
	)
	AND ass.CompanyId = @localCompanyId
	AND app.AppointmentTime >= @localStartDateSearch
	AND app.AppointmentTime < @localEndDateSearch
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
	AND app.AppointmentTime >= @localStartDateSearch
	AND app.AppointmentTime < @localEndDateSearch
	AND (@localInvoiceTypeId IS NULL OR @localInvoiceTypeId = @psychologistInvoiceTypeId)

END