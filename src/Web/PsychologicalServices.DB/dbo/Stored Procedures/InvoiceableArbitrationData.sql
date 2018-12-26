
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InvoiceableArbitrationData]
	@companyId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @arbitrationInvoiceTypeId INT = 3,
			@localCompanyId INT = @companyId
			
    --arbitrations that need invoices
	SELECT
	 arb.ArbitrationId
	,arb.Title
	,psychologists.FirstName + ' ' + psychologists.LastName AS PayableTo
	,psychologists.UserId AS PayableToId
	,@arbitrationInvoiceTypeId AS InvoiceTypeId
	,c.Claimant
	,arb.StartDate
	,arb.AvailableDate
	FROM dbo.Arbitrations arb
	INNER JOIN dbo.Users psychologists ON arb.PsychologistId = psychologists.UserId
	LEFT JOIN (
		SELECT
		ArbitrationId
		,ROW_NUMBER() OVER (PARTITION BY ac.ArbitrationId ORDER BY ac.ClaimId) AS RowNum
		,cl.FirstName + ' ' + cl.LastName AS Claimant
		FROM dbo.ArbitrationClaims ac
		INNER JOIN dbo.Claims c ON ac.ClaimId = c.ClaimId
		INNER JOIN dbo.Claimants cl ON c.ClaimantId = cl.ClaimantId
	) c ON arb.ArbitrationId = c.ArbitrationId
	WHERE 
	NOT EXISTS (
		SELECT
		*
		FROM dbo.InvoiceLineGroupArbitrations ilga
		INNER JOIN dbo.InvoiceLineGroups ilg ON ilga.InvoiceLineGroupId = ilg.InvoiceLineGroupId
		INNER JOIN dbo.Invoices i ON ilg.InvoiceId = i.InvoiceId
		WHERE
		ilga.ArbitrationId = arb.ArbitrationId
		AND i.PayableToId = psychologists.UserId
	)
	AND (c.RowNum IS NULL OR c.RowNum = 1)
	AND psychologists.CompanyId = @localCompanyId

END