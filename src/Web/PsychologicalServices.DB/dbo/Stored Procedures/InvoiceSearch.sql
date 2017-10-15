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
	,@NeedsRefresh BIT = NULL
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
			@needsRefresh_local BIT

	SET @companyId_local = @CompanyId
	SET @appointmentId_local = @AppointmentId
	SET @identifier_local = @Identifier
	SET @invoiceDate_local = @InvoiceDate
	SET @invoiceMonth_local = @InvoiceMonth
	SET @invoiceStatusId_local = @InvoiceStatusId
	SET @invoiceTypeId_local = @InvoiceTypeId
	SET @payableToId_local = @PayableToId
	SET @needsRefresh_local = @NeedsRefresh

	
	SELECT
	i.InvoiceId
	FROM dbo.Invoices i
	INNER JOIN dbo.Users u ON i.PayableToId = u.UserId
	LEFT JOIN dbo.InvoiceAppointments ia ON i.InvoiceId = ia.InvoiceId
	WHERE
	u.CompanyId = @companyId_local
	AND (@appointmentId_local IS NULL OR ia.AppointmentId = @appointmentId_local)
	AND (@identifier_local IS NULL OR LEN(@identifier_local) = 0 OR i.Identifier LIKE '%' + @identifier_local + '%')
	AND (@invoiceDate_local IS NULL OR (i.InvoiceDate >= CAST(@invoiceDate_local AS DATE) AND i.InvoiceDate < DATEADD(DAY,1,CAST(@invoiceDate_local AS DATE))))
	AND (@invoiceMonth_local IS NULL OR (YEAR(i.InvoiceDate) = YEAR(@invoiceMonth_local) AND MONTH(i.InvoiceDate) = MONTH(@invoiceMonth_local)))
	AND (@invoiceStatusId_local IS NULL OR i.InvoiceStatusId = @invoiceStatusId_local)
	AND (@invoiceTypeId_local IS NULL OR i.InvoiceTypeId = @invoiceTypeId_local)
	AND (@payableToId_local IS NULL OR i.PayableToId = @payableToId_local)
	AND (@needsRefresh_local IS NULL OR 
		(@needsRefresh_local = 1 AND EXISTS (
			SELECT
			*
			FROM dbo.Appointments eapp
			INNER JOIN dbo.AppointmentStatuses eas ON eapp.AppointmentStatusId = eas.AppointmentStatusId
			LEFT JOIN dbo.InvoiceAppointments eia ON eapp.AppointmentId = eia.AppointmentId
			WHERE
			eapp.PsychometristId = i.PayableToId
			AND YEAR(eapp.AppointmentTime) = YEAR(i.InvoiceDate)
			AND MONTH(eapp.AppointmentTime) = MONTH(i.InvoiceDate)
			AND eas.CanInvoice = 1
			AND eia.InvoiceId IS NULL
		)) OR
		(@needsRefresh_local = 0 AND NOT EXISTS (
			SELECT
			*
			FROM dbo.Appointments eapp
			INNER JOIN dbo.AppointmentStatuses eas ON eapp.AppointmentStatusId = eas.AppointmentStatusId
			LEFT JOIN dbo.InvoiceAppointments eia ON eapp.AppointmentId = eia.AppointmentId
			WHERE
			eapp.PsychometristId = i.PayableToId
			AND YEAR(eapp.AppointmentTime) = YEAR(i.InvoiceDate)
			AND MONTH(eapp.AppointmentTime) = MONTH(i.InvoiceDate)
			AND eas.CanInvoice = 1
			AND eia.InvoiceId IS NULL
		))
	)
	GROUP BY
	i.InvoiceId


END