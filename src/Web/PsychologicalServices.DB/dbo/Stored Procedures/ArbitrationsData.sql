
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ArbitrationsData]
	@companyId INT,
	@months INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @companyId_local INT,
			@months_local INT

	SET @companyId_local = @companyId
	SET @months_local = @months

	SELECT
	 ass.AssessmentId
	,arb.ArbitrationId
	,ass.ReferralSourceId
	,rs.[Name] AS ReferralSource
	,id.IssueInDisputeId
	,id.[Name] AS IssueInDispute
	,law.ContactId AS LawyerId
	,ISNULL(law.FirstName + ' ' + law.LastName, 'Unknown') AS Lawyer
	FROM dbo.Arbitrations arb
	INNER JOIN dbo.Assessments ass ON arb.AssessmentId = ass.AssessmentId
	INNER JOIN dbo.ReferralSources rs ON ass.ReferralSourceId = rs.ReferralSourceId
	LEFT JOIN dbo.AssessmentReports ar ON ass.AssessmentId = ar.AssessmentId
	LEFT JOIN dbo.AssessmentReportIssuesInDispute arid ON ar.ReportId = arid.ReportId
	LEFT JOIN dbo.IssuesInDispute id ON arid.IssueInDisputeId = id.IssueInDisputeId
	LEFT JOIN dbo.Contacts law ON arb.DefenseLawyerId = law.ContactId

	WHERE
	ass.CompanyId = @companyId_local
	AND EXISTS (
		SELECT * FROM dbo.Appointments app
		WHERE
		app.AppointmentTime < DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0)
		AND (
			@months_local IS NULL
			OR app.AppointmentTime >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - @months_local, 0)
		)
		AND (
			@months_local IS NOT NULL
			OR app.AppointmentTime >= DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)
		)
	)

END