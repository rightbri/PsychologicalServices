

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InvoiceableRawTestDataData]
	@companyId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @rawTestDataInvoiceTypeId INT = 4,
			@localCompanyId INT = @companyId
	
    --raw test datas that need invoices
	SELECT
	 rtd.RawTestDataId
	,psychologists.FirstName + ' ' + psychologists.LastName AS PayableTo
	,psychologists.UserId AS PayableToId
	,@rawTestDataInvoiceTypeId AS InvoiceTypeId
	,clm.FirstName + ' ' + clm.LastName AS Claimant
	,rs.[Name] AS ReferralSource
	,rtd.RequestReceivedDate
	FROM dbo.RawTestDatas rtd
	INNER JOIN dbo.Users psychologists ON rtd.PsychologistId = psychologists.UserId
	INNER JOIN dbo.Claimants clm ON rtd.ClaimantId = clm.ClaimantId
	INNER JOIN dbo.ReferralSources rs ON rtd.BillToReferralSourceId = rs.ReferralSourceId
	WHERE 
	NOT EXISTS (
		SELECT
		*
		FROM dbo.InvoiceLineGroupRawTestData ilgr
		INNER JOIN dbo.InvoiceLineGroups ilg ON ilgr.InvoiceLineGroupId = ilg.InvoiceLineGroupId
		INNER JOIN dbo.Invoices i ON ilg.InvoiceId = i.InvoiceId
		WHERE
		ilgr.RawTestDataId = rtd.RawTestDataId
		AND i.PayableToId = psychologists.UserId
	)
	AND rtd.CompanyId = @localCompanyId

END