-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BookingData]
	@companyId INT,
	@months INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @psychologicalAssessmentTypeName NVARCHAR(50) = 'P',
			@localCompanyId INT = @companyId,
			@localMonths INT = @months

	SELECT * FROM (
		SELECT
		 ass.AssessmentId
		,ass.ReferralSourceId
		,rs.[Name] AS ReferralSource
		,DATEPART(YEAR, app.AppointmentTime) AS [Year]
		,DATEPART(MONTH, app.AppointmentTime) AS [Month]
		,ROW_NUMBER() OVER (PARTITION BY app.AssessmentId ORDER BY app.AppointmentTime ASC) AS RowNum
		,CASE
			WHEN t.[Name] = @psychologicalAssessmentTypeName THEN 1
			ELSE 0
		END AS IsPsychological
		,CASE
			WHEN ass.IsLargeFile = 1 THEN 1
			WHEN ass.FileSize >= rsic.LargeFileSize THEN 1
			ELSE 0
		END AS IsLargeFile
		FROM dbo.Assessments ass
		INNER JOIN dbo.ReferralSources rs ON ass.ReferralSourceId = rs.ReferralSourceId
		INNER JOIN dbo.AssessmentTypes t ON ass.AssessmentTypeId = t.AssessmentTypeId
		INNER JOIN dbo.Appointments app ON ass.AssessmentId = app.AssessmentId
		LEFT JOIN dbo.ReferralSourceInvoiceConfiguration rsic ON ass.CompanyId = rsic.CompanyId AND ass.ReferralSourceId = rsic.ReferralSourceId
		WHERE
		app.AppointmentTime < DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0)
		AND (
			@localMonths IS NULL
			OR app.AppointmentTime >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - @localMonths, 0)
		)
		AND (
			@localMonths IS NOT NULL
			OR app.AppointmentTime >= DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)
		)
		AND ass.CompanyId = @localCompanyId
		AND t.ShowOnSchedule = 1
	) a
	WHERE 
	RowNum = 1

END