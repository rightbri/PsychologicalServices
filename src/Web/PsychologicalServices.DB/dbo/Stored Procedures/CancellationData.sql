﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CancellationData]
	-- Add the parameters for the stored procedure here
	@companyId INT,
	@months INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @canceledStatusId INT = 3,
			@showedStatusId INT = 4,
			@noShowStatusId INT = 5,
			@incompleteStatusId INT = 6,
			@completeStatusId INT = 7,
			@lateCancellationStatusId INT = 8,
			@localCompanyId INT = @companyId,
			@localMonths INT = @months

	SELECT
	 ass.AssessmentId
	,ass.ReferralSourceId
	,rs.[Name] AS ReferralSource
	,DATEPART(YEAR, app.AppointmentTime) AS [Year]
	,DATEPART(MONTH, app.AppointmentTime) AS [Month]
	,1 AS AppointmentCount
	,CASE
		WHEN AppointmentStatusId IN ( @showedStatusId , @noShowStatusId , @incompleteStatusId , @completeStatusId , @lateCancellationStatusId) THEN 1
		ELSE 0
	END AS BillableCount
	,CASE
		WHEN AppointmentStatusId = @canceledStatusId THEN 1
		ELSE 0
	END AS CanceledCount
	,CASE
		WHEN AppointmentStatusId = @lateCancellationStatusId THEN 1
		ELSE 0
	END AS LateCanceledCount
	FROM dbo.Assessments ass
	INNER JOIN dbo.ReferralSources rs ON ass.ReferralSourceId = rs.ReferralSourceId
	INNER JOIN dbo.AssessmentTypes t ON ass.AssessmentTypeId = t.AssessmentTypeId
	INNER JOIN dbo.Appointments app ON ass.AssessmentId = app.AssessmentId
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

END