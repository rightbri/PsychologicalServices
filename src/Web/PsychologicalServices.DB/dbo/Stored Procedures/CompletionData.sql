-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CompletionData]
	-- Add the parameters for the stored procedure here
	@companyId INT,
	@months INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @readerAttributeId INT = 1,
			@translatorAttributeId INT = 2,
			@psychiatristAttributeId INT = 3,
			@attributeYesValue BIT = 1,
			@incompleteStatusId INT = 6,
			@completeStatusId INT = 7,
			@femaleValue NCHAR(1) = 'F',
			@localCompanyId INT = @companyId,
			@localMonths INT = @months

    SELECT 
	AssessmentId
	,AppointmentTime
	,DATEPART(YEAR, AppointmentTime) AS [Year]
	,DATEPART(MONTH, AppointmentTime) AS [Month]
	,Psychometrist
	,IncompleteCount
	,CompleteCount
	,HasTranslator
	,HasReader
	,HasPsychiatrist
	,IsFemaleClaimant
	FROM (
		SELECT 
		ass.AssessmentId
		,ROW_NUMBER() OVER (PARTITION BY ass.AssessmentId ORDER BY app.AppointmentTime ASC) AS RowNum
		,app.AppointmentTime
		,CASE
			WHEN app.AppointmentStatusId = @incompleteStatusId THEN 1
			ELSE 0
		END AS IncompleteCount
		,CASE
			WHEN app.AppointmentStatusId = @completeStatusId THEN 1
			ELSE 0
		END AS CompleteCount
		,psy.FirstName + ' ' + psy.LastName AS Psychometrist
		,CASE
			WHEN attrTranslator.[Value] = @attributeYesValue THEN 1
			ELSE 0
		END AS HasTranslator
		,CASE
			WHEN attrReader.[Value] = @attributeYesValue THEN 1
			ELSE 0
		END AS HasReader
		,CASE
			WHEN attrPsychiatrist.[Value] = @attributeYesValue THEN 1
			ELSE 0
		END AS HasPsychiatrist
		,CASE
			WHEN c.Gender = @femaleValue THEN 1
			ELSE 0
		END AS IsFemaleClaimant
		FROM dbo.Appointments app
		INNER JOIN dbo.Assessments ass ON app.AssessmentId = ass.AssessmentId
		INNER JOIN dbo.AssessmentTypes t ON ass.AssessmentTypeId = t.AssessmentTypeId
		INNER JOIN dbo.Users psy ON app.PsychometristId = psy.UserId
		LEFT JOIN dbo.AppointmentAttributes attrTranslator ON app.AppointmentId = attrTranslator.AppointmentId AND attrTranslator.AttributeId = @translatorAttributeId
		LEFT JOIN dbo.AppointmentAttributes attrReader ON app.AppointmentId = attrReader.AppointmentId AND attrReader.AttributeId = @readerAttributeId
		LEFT JOIN dbo.AssessmentAttributes attrPsychiatrist ON ass.AssessmentId = attrPsychiatrist.AssessmentId AND attrPsychiatrist.AttributeId = @psychiatristAttributeId
		LEFT JOIN (
			SELECT
			AssessmentId
			,Gender
			,ROW_NUMBER() OVER (PARTITION BY cl.Gender ORDER BY cl.ClaimantId ASC) AS RowNum
			FROM dbo.AssessmentClaims ac
			INNER JOIN dbo.Claims c ON ac.ClaimId = c.ClaimId
			INNER JOIN dbo.Claimants cl ON c.ClaimantId = cl.ClaimantId
		) c ON ass.AssessmentId = c.AssessmentId
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
		AND app.AppointmentStatusId IN( @incompleteStatusId , @completeStatusId )
	) a
	WHERE
	RowNum = 1

	ORDER BY
	Psychometrist

END