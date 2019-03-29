
CREATE PROCEDURE [dbo].[NonABCompletionData]
	-- Add the parameters for the stored procedure here
	@companyId INT,
	@months INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
	DECLARE @appointmentStatusComplete INT = 7,
			@localCompanyId INT = @companyId,
			@localMonths INT = @months

	SELECT 
	ass.AssessmentId
	,asst.[Name] AS AssessmentType
	,rt.[Name] AS ReferralType
	,app.AppointmentTime
	,DATEPART(YEAR, app.AppointmentTime) AS AppointmentYear
	,DATEPART(MONTH, app.AppointmentTime) AS AppointmentMonth
	,apps.[Name] AS AppointmentStatus
	,cl.FirstName
	,cl.LastName
	FROM dbo.Assessments ass
	INNER JOIN dbo.AssessmentTypes asst ON ass.AssessmentTypeId = asst.AssessmentTypeId
	INNER JOIN dbo.ReferralTypes rt ON ass.ReferralTypeId = rt.ReferralTypeId
	INNER JOIN dbo.Appointments app ON ass.AssessmentId = app.AssessmentId 
	INNER JOIN dbo.AppointmentStatuses apps ON app.AppointmentStatusId = apps.AppointmentStatusId
	INNER JOIN dbo.Claimants cl ON ass.ClaimantId = cl.ClaimantId

	WHERE 
	ass.CompanyId = @localCompanyId
	AND app.AppointmentTime < DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0)
	AND (
		@localMonths IS NULL
		OR app.AppointmentTime >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - @localMonths, 0)
	)
	AND (
		@localMonths IS NOT NULL
		OR app.AppointmentTime >= DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)
	)
	AND rt.[Name] <> 'AB'
	AND app.AppointmentStatusId = @appointmentStatusComplete

	ORDER BY
	AppointmentYear
	,AppointmentMonth
	,LastName
	,FirstName


END