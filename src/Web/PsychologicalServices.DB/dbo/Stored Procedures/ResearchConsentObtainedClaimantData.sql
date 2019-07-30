


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ResearchConsentObtainedClaimantData]
	@companyId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @companyId_local INT,
			@researchConsentObtainedAttributeId INT

	SET @companyId_local = @companyId
	SET @researchConsentObtainedAttributeId = 21

	SELECT 
	 cl.ClaimantId
	,cl.FirstName
	,cl.LastName
	,cl.Gender
	,cl.DateOfBirth
	,rs.[Name] AS ReferralSource
	,app.AppointmentTime 
	FROM dbo.Assessments ass 
	INNER JOIN dbo.AssessmentAttributes assAttr ON ass.AssessmentId = assAttr.AssessmentId 
	INNER JOIN dbo.Claimants cl ON ass.ClaimantId = cl.ClaimantId 
	INNER JOIN dbo.ReferralSources rs ON ass.ReferralSourceId = rs.ReferralSourceId 
	INNER JOIN (
		SELECT * FROM (
			SELECT 
			 app.AssessmentId
			,app.AppointmentId
			,app.AppointmentTime
			,ROW_NUMBER() OVER (PARTITION BY AssessmentId ORDER BY AppointmentTime) AS RowNum
			FROM dbo.Appointments app 
			INNER JOIN dbo.AppointmentStatuses appS ON app.AppointmentStatusId = appS.AppointmentStatusId 
			WHERE appS.ClaimantSeen = 1
		) x
		WHERE 
		RowNum = 1
	) app ON ass.AssessmentId = app.AssessmentId 
	WHERE 
	assAttr.[AttributeId] = @researchConsentObtainedAttributeId
	AND assAttr.[Value] = 1
	AND cl.[IsActive] = 1

	ORDER BY 
	cl.LastName
	,cl.FirstName

END