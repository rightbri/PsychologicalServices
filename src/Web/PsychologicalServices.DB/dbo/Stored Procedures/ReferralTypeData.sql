

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReferralTypeData]
	@companyId INT,
	@startDateSearch DATETIMEOFFSET,
	@endDateSearch DATETIMEOFFSET
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @referralTypeIdAbDefense INT = 1,
		@referralTypeIdAbPlaintiff INT = 9,
		@referralTypeIdMedLegalDefense INT = 4,
		@referralTypeIdMedLegalPlaintiff INT = 5,
		@referralTypeIdLtd INT = 2,
		@localCompanyId INT = @companyId,
		@localStartDateSearch DATETIMEOFFSET = @startDateSearch,
		@localEndDateSearch DATETIMEOFFSET = @endDateSearch
		;

	SELECT 
	 ass.AssessmentId 
	,app.AppointmentTime 
	,DATEPART(YEAR, app.AppointmentTime) AS [Year]
	,DATEPART(MONTH, app.AppointmentTime) AS [Month]
	,CASE 
		WHEN ass.ReferralTypeId IN(@referralTypeIdAbPlaintiff, @referralTypeIdMedLegalPlaintiff) THEN 1 
		ELSE 0 
	END AS IsPlaintiff 
	,CASE
		WHEN ass.ReferralTypeId IN(@referralTypeIdAbDefense, @referralTypeIdMedLegalDefense) THEN 1 
		ELSE 0
	END AS IsDefense
	,CASE
		WHEN ass.ReferralTypeId IN(@referralTypeIdAbDefense, @referralTypeIdAbPlaintiff) THEN 'AB'
		WHEN ass.ReferralTypeId IN(@referralTypeIdLtd) THEN 'LTD'
		WHEN ass.ReferralTypeId IN(@referralTypeIdMedLegalDefense, @referralTypeIdMedLegalPlaintiff) THEN 'Med Legal'
		ELSE 'Other'
	END AS ReferralType
	FROM dbo.Assessments ass 
	INNER JOIN (
		SELECT * FROM (	
			SELECT 
			 iapp.AppointmentId 
			,iapp.AssessmentId 
			,iapp.AppointmentTime
			,iapp.AppointmentStatusId 
			,iapps.[Name] AppointmentStatus 
			,ROW_NUMBER() OVER (PARTITION BY AssessmentId ORDER BY AppointmentTime) AS RowNum 
			FROM dbo.Appointments iapp 
			INNER JOIN dbo.AppointmentStatuses iapps ON iapp.AppointmentStatusId = iapps.AppointmentStatusId 
			WHERE iapps.ClaimantSeen = 1 
		) x WHERE x.RowNum = 1
	) app ON ass.AssessmentId = app.AssessmentId 
	--INNER JOIN dbo.ReferralTypes rt ON ass.ReferralTypeId = rt.ReferralTypeId 
	WHERE 1=1 
	AND ass.CompanyId = @localCompanyId 
	AND ass.ReferralTypeId IN(
		@referralTypeIdAbDefense,
		@referralTypeIdAbPlaintiff,
		@referralTypeIdMedLegalDefense,
		@referralTypeIdMedLegalPlaintiff,
		@referralTypeIdLtd
	) 
	AND (@localStartDateSearch IS NULL OR app.AppointmentTime >= @localStartDateSearch) 
	AND (@localEndDateSearch IS NULL OR app.AppointmentTime < @localEndDateSearch) 
	
END