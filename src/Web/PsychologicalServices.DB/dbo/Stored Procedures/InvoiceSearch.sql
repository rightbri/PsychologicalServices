-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InvoiceSearch]
	-- Add the parameters for the stored procedure here
	@CompanyId INT
	,@AppointmentId INT = NULL
	,@Identifier NVARCHAR(20) = NULL
	,@InvoiceDate DATETIMEOFFSET = NULL
	,@InvoiceMonth DATETIMEOFFSET = NULL
	,@InvoiceStatusId INT = NULL
	,@InvoiceTypeId INT = NULL
	,@PayableToId INT = NULL
	,@ClaimantId INT = NULL
	,@NeedsRefresh BIT = NULL
	,@NeedsToBeSentToReferralSource BIT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @companyId_local INT,
			@appointmentId_local INT,
			@identifier_local NVARCHAR(20),
			@invoiceDate_local DATETIMEOFFSET,
			@invoiceMonth_local DATETIMEOFFSET,
			@invoiceStatusId_local INT,
			@invoiceTypeId_local INT,
			@payableToId_local INT,
			@claimantId_local INT,
			@needsRefresh_local BIT,
			@needsToBeSentToReferralSource_local BIT

	SET @companyId_local = @CompanyId
	SET @appointmentId_local = @AppointmentId
	SET @identifier_local = @Identifier
	SET @invoiceDate_local = @InvoiceDate
	SET @invoiceMonth_local = @InvoiceMonth
	SET @invoiceStatusId_local = @InvoiceStatusId
	SET @invoiceTypeId_local = @InvoiceTypeId
	SET @payableToId_local = @PayableToId
	SET @claimantId_local = @ClaimantId
	SET @needsRefresh_local = @NeedsRefresh
	SET @needsToBeSentToReferralSource_local = @NeedsToBeSentToReferralSource
	
	DECLARE @invoiceDateSentTrackingBeginDate DATETIME = '20171203'
	DECLARE @invoiceStatusIdPaid INT = 3

	SELECT
	i.InvoiceId
	FROM dbo.Invoices i
	INNER JOIN dbo.Users u ON i.PayableToId = u.UserId
	LEFT JOIN dbo.InvoiceLineGroups ilg ON i.InvoiceId = ilg.InvoiceId
	LEFT JOIN dbo.InvoiceLineGroupAppointments ilga ON ilg.InvoiceLineGroupId = ilga.InvoiceLineGroupId
	LEFT JOIN dbo.Appointments app ON ilga.AppointmentId = app.AppointmentId
	LEFT JOIN dbo.Assessments ass ON app.AssessmentId = ass.AssessmentId
	LEFT JOIN dbo.AssessmentClaims ac ON ass.AssessmentId = ac.AssessmentId
	LEFT JOIN dbo.Claims cl ON ac.ClaimId = cl.ClaimId
	LEFT JOIN (
		SELECT
		 InvoiceId
		,InvoiceDocumentId
		,SentDate
		FROM (
			SELECT
			 id.InvoiceId
			,id.InvoiceDocumentId
			,idsl.SentDate
			,ROW_NUMBER() OVER (PARTITION BY id.InvoiceId ORDER BY id.InvoiceDocumentId DESC) AS RowNum
			FROM dbo.InvoiceDocuments id
			LEFT JOIN dbo.InvoiceDocumentSendLogs idsl ON id.InvoiceDocumentId = idsl.InvoiceDocumentId
		) x
		WHERE 
		x.RowNum = 1
	) id ON i.InvoiceId = id.InvoiceId
	WHERE
	u.CompanyId = @companyId_local
	AND (@appointmentId_local IS NULL OR ilga.AppointmentId = @appointmentId_local)
	AND (@identifier_local IS NULL OR LEN(@identifier_local) = 0 OR i.Identifier LIKE '%' + @identifier_local + '%')
	AND (@invoiceDate_local IS NULL OR (i.InvoiceDate >= CAST(@invoiceDate_local AS DATE) AND i.InvoiceDate < DATEADD(DAY,1,CAST(@invoiceDate_local AS DATE))))
	AND (@invoiceMonth_local IS NULL OR (YEAR(i.InvoiceDate) = YEAR(@invoiceMonth_local) AND MONTH(i.InvoiceDate) = MONTH(@invoiceMonth_local)))
	AND (@invoiceStatusId_local IS NULL OR i.InvoiceStatusId = @invoiceStatusId_local)
	AND (@invoiceTypeId_local IS NULL OR i.InvoiceTypeId = @invoiceTypeId_local)
	AND (@payableToId_local IS NULL OR i.PayableToId = @payableToId_local)
	AND (@claimantId_local IS NULL OR cl.ClaimantId = @claimantId_local)
	AND (@needsRefresh_local IS NULL OR 
		(@needsRefresh_local = 1 AND EXISTS (
			SELECT
			*
			FROM dbo.Appointments eapp
			INNER JOIN dbo.AppointmentStatuses eas ON eapp.AppointmentStatusId = eas.AppointmentStatusId
			LEFT JOIN dbo.InvoiceLineGroupAppointments eilga ON eapp.AppointmentId = eilga.AppointmentId
			LEFT JOIN dbo.InvoiceLineGroups eilg ON eilga.InvoiceLineGroupId = eilg.InvoiceLineGroupId
			WHERE
			eapp.PsychometristId = i.PayableToId
			AND YEAR(eapp.AppointmentTime) = YEAR(i.InvoiceDate)
			AND MONTH(eapp.AppointmentTime) = MONTH(i.InvoiceDate)
			AND eas.CanInvoice = 1
			AND eilg.InvoiceId IS NULL
		)) OR
		(@needsRefresh_local = 0 AND NOT EXISTS (
			SELECT
			*
			FROM dbo.Appointments eapp
			INNER JOIN dbo.AppointmentStatuses eas ON eapp.AppointmentStatusId = eas.AppointmentStatusId
			LEFT JOIN dbo.InvoiceLineGroupAppointments eilga ON eapp.AppointmentId = eilga.AppointmentId
			LEFT JOIN dbo.InvoiceLineGroups eilg ON eilga.InvoiceLineGroupId = eilg.InvoiceLineGroupId
			WHERE
			eapp.PsychometristId = i.PayableToId
			AND YEAR(eapp.AppointmentTime) = YEAR(i.InvoiceDate)
			AND MONTH(eapp.AppointmentTime) = MONTH(i.InvoiceDate)
			AND eas.CanInvoice = 1
			AND eilg.InvoiceId IS NULL
		))
	)
	AND (@needsToBeSentToReferralSource_local IS NULL
		OR (@needsToBeSentToReferralSource_local = 1
			 AND i.InvoiceTypeId = 1
			 AND i.UpdateDate >= @invoiceDateSentTrackingBeginDate
			 AND id.SentDate IS NULL
			 AND i.InvoiceStatusId <> @invoiceStatusIdPaid
			)
		OR (@needsToBeSentToReferralSource_local = 0
			AND (
				i.InvoiceTypeId <> 1
				OR (i.InvoiceTypeId = 1 
					AND i.UpdateDate < @invoiceDateSentTrackingBeginDate
					AND id.SentDate IS NOT NULL
					)
				)
		   )
	)
	GROUP BY
	i.InvoiceId


END