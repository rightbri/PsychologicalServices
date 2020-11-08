
CREATE PROCEDURE [dbo].[AppointmentProtocolResponseData]
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
	 PsychometristId
	,PsychometristFirstName
	,PsychometristLastName
	,AppointmentId
	,AssessmentId
	,AppointmentTime
	,ClaimantId
	,ClaimantFirstName
	,ClaimantLastName
	,Question
	,Response
FROM   
	(
	SELECT 
	 app.PsychometristId
	,up.FirstName AS PsychometristFirstName
	,up.LastName AS PsychometristLastName
	,app.AppointmentId
	,app.AssessmentId
	,app.AppointmentTime
	,cl.ClaimantId
	,cl.FirstName AS ClaimantFirstName
	,cl.LastName AS ClaimantLastName
	,apr.OnTimeArrivalAndNotificationId
	,apr.ClaimantArrivalNotificationId
	,apr.CovidFormsCompletedBeforeEnteringRoomId
	,apr.TestedClaimantsEnglishReadingLevelId
	,apr.TommSimsScoreNotificationId
	,apr.AskedWhichTestsShouldBeRemovedId
	,apr.AdvisedOfUnexpectedDelaysId
	,apr.AfterAssessmentNotificationId
	,apr.AllPapersHaveClaimantInitialsAndDateId
	,apr.ScoringDoubleCheckedId
	,apr.RelevantObservationsDocumentedId
	,apr.ErrorCheckedObservationsId
	,apr.AllFormsCompletedId
	,apr.TimeAssessmentLabelCompletedId
	,apr.ScansUploadedNotificationId
	,apr.UploadedScanLegibilityVerifiedId
	,apr.SpareSetReplenishmentRequestSentId
	,apr.RespondedToQuestionsWithinRequiredTimeframeId
	,apr.StapledItemsTogetherId
	,apr.WillPersonallyDropOffPackageId
	FROM dbo.AppointmentProtocolResponses apr 
	INNER JOIN dbo.Appointments app ON apr.AppointmentId = app.AppointmentId 
	INNER JOIN dbo.Users up ON app.PsychometristId = up.UserId 
	INNER JOIN dbo.Assessments ass ON app.AssessmentId = ass.AssessmentId 
	INNER JOIN dbo.Claimants cl ON ass.ClaimantId = cl.ClaimantId 
	WHERE 1=1 
	AND ass.CompanyId = @companyId_local
	AND app.AppointmentTime < DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0)
	AND (
		@months_local IS NULL
		OR app.AppointmentTime >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - @months_local, 0)
	)
	AND (
		@months_local IS NOT NULL
		OR app.AppointmentTime >= DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)
	)
) p  
UNPIVOT  
   (Response FOR Question IN   
    (
		 OnTimeArrivalAndNotificationId
		,ClaimantArrivalNotificationId
		,CovidFormsCompletedBeforeEnteringRoomId
		,TestedClaimantsEnglishReadingLevelId
		,TommSimsScoreNotificationId
		,AskedWhichTestsShouldBeRemovedId
		,AdvisedOfUnexpectedDelaysId
		,AfterAssessmentNotificationId
		,AllPapersHaveClaimantInitialsAndDateId
		,ScoringDoubleCheckedId
		,RelevantObservationsDocumentedId
		,ErrorCheckedObservationsId
		,AllFormsCompletedId
		,TimeAssessmentLabelCompletedId
		,ScansUploadedNotificationId
		,UploadedScanLegibilityVerifiedId
		,SpareSetReplenishmentRequestSentId
		,RespondedToQuestionsWithinRequiredTimeframeId
		,StapledItemsTogetherId
		,WillPersonallyDropOffPackageId
	)  
)AS unpvt 

WHERE 1=1 

ORDER BY 
PsychometristId
,Question
,AppointmentId



END