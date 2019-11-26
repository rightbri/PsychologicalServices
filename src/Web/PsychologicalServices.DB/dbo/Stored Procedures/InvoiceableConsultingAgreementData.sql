


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InvoiceableConsultingAgreementData]
	@companyId INT,
	@year INT,
	@month INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @consultingAgreementInvoiceTypeId INT = 5,
			@localCompanyId INT = @companyId,
			@localYear INT = @year,
			@localMonth INT = @month,
			@now DATETIME = GETDATE()

	DECLARE @currentYear INT = YEAR(@now),
			@currentMonth INT = MONTH(@now)
	
    --consulting agreements that need invoices
	SELECT
	 ca.ConsultingAgreementId
	,psychologists.FirstName + ' ' + psychologists.LastName AS PayableTo
	,psychologists.UserId AS PayableToId
	,@consultingAgreementInvoiceTypeId AS InvoiceTypeId
	,rs.[Name] AS ReferralSource
	,@localYear AS [Year]
	,@localMonth AS [Month]
	,i.InvoiceId AS InvoiceId
	,CAST(CASE WHEN i.InvoiceId IS NULL THEN 1 ELSE 0 END AS BIT) AS CanCreateInvoice
	FROM dbo.ConsultingAgreements ca
	INNER JOIN dbo.Users psychologists ON ca.PsychologistId = psychologists.UserId
	INNER JOIN dbo.ReferralSources rs ON ca.BillToReferralSourceId = rs.ReferralSourceId 
	LEFT JOIN (
		SELECT
		 ilgc.ConsultingAgreementId
		,i.InvoiceId
		FROM dbo.InvoiceLineGroupConsultingAgreements ilgc
		INNER JOIN dbo.InvoiceLineGroups ilg ON ilgc.InvoiceLineGroupId = ilg.InvoiceLineGroupId
		INNER JOIN dbo.Invoices i ON ilg.InvoiceId = i.InvoiceId
		WHERE 1=1
		AND YEAR(i.InvoicePeriodBegin) = @localYear
		AND MONTH(i.InvoicePeriodBegin) = @localMonth
	) i ON ca.ConsultingAgreementId = i.ConsultingAgreementId
	WHERE 1=1
	AND ca.CompanyId = @localCompanyId 
	AND @localMonth >= 1
	AND @localMonth <= 12
	AND @localYear <= @currentYear
	AND @localYear >= @currentYear - 1
	AND (@localYear < @currentYear OR (@localYear = @currentYear AND @localMonth <= @currentMonth))

END