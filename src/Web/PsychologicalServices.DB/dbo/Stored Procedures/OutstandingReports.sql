-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[OutstandingReports]
	@companyId INT,
	@daysOutstanding INT = 60,
	@searchStart DATETIMEOFFSET = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @finalCopyReceivedAttributeId INT = 14,
			@completedAppointmentStatusId INT = 7,
			@localCompanyId INT = @companyId,
			@localDaysOutstanding INT = @daysOutstanding,
			@localSearchStart DATETIMEOFFSET = @searchStart
			
	IF @localSearchStart IS NULL
		BEGIN
			SET @localSearchStart = DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)
		END

	SELECT 
	ass.AssessmentId
	,app.AppointmentTime
	,clm.FirstName + ' ' + clm.LastName AS Claimant
	,rs.[Name] AS ReferralSource
	FROM dbo.Assessments ass
	INNER JOIN dbo.AssessmentAttributes assattr ON ass.AssessmentId = assattr.AssessmentId
	INNER JOIN dbo.Attributes attr ON assattr.AttributeId = attr.AttributeId
	INNER JOIN dbo.Appointments app ON ass.AssessmentId = app.AssessmentId
	INNER JOIN dbo.AssessmentClaims ac ON ass.AssessmentId = ac.AssessmentId
	INNER JOIN dbo.Claims cl ON ac.ClaimId = cl.ClaimId
	INNER JOIN dbo.Claimants clm ON cl.ClaimantId = clm.ClaimantId
	INNER JOIN dbo.ReferralSources rs ON ass.ReferralSourceId = rs.ReferralSourceId
	WHERE 
	ass.CompanyId = @localCompanyId
	AND attr.AttributeId = @finalCopyReceivedAttributeId
	AND (assattr.[Value] IS NULL OR assattr.[Value] = 0)
	AND app.AppointmentStatusId = @completedAppointmentStatusId
	AND DATEDIFF(DAY, app.AppointmentTime, DATEADD(DAY, 0, DATEDIFF(DAY, 0, GETDATE()))) >= @localDaysOutstanding
	AND app.AppointmentTime >= @localSearchStart
	ORDER BY
	app.AppointmentTime

END