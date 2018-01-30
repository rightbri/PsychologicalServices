

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CredibilityData]
	@companyId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @companyId_local INT

	SET @companyId_local = @companyId

	SELECT 
	 ass.AssessmentTypeId
	,asst.[Name] AS AssessmentTypeName
	,CASE WHEN asst.[Name] IN ('NC','NC/P','NP') AND ass.NeurocognitiveCredibilityId IS NOT NULL THEN 1 ELSE 0 END AS CountNeurocognitiveCredibility
	,CASE WHEN asst.[Name] IN ('P', 'PVOC', 'NP', 'NC/P') AND ass.PsychologicalCredibilityId IS NOT NULL THEN 1 ELSE 0 END AS CountPsychologicalCredibility
	,CASE WHEN asst.[Name] IN ('NC','NC/P','NP') AND ass.NeurocognitiveCredibilityId = 1 THEN 1 ELSE 0 END AS NeurocognitiveCredibilityCredible
	,CASE WHEN asst.[Name] IN ('NC','NC/P','NP') AND ass.NeurocognitiveCredibilityId = 2 THEN 1 ELSE 0 END AS NeurocognitiveCredibilityNotCredible
	,CASE WHEN asst.[Name] IN ('NC','NC/P','NP') AND ass.NeurocognitiveCredibilityId = 3 THEN 1 ELSE 0 END AS NeurocognitiveCredibilityQuestionable
	,CASE WHEN asst.[Name] IN ('P', 'PVOC', 'NP', 'NC/P') AND ass.PsychologicalCredibilityId = 1 THEN 1 ELSE 0 END AS PsychologicalCredibilityCredible
	,CASE WHEN asst.[Name] IN ('P', 'PVOC', 'NP', 'NC/P') AND ass.PsychologicalCredibilityId = 2 THEN 1 ELSE 0 END AS PsychologicalCredibilityNotCredible
	,CASE WHEN asst.[Name] IN ('P', 'PVOC', 'NP', 'NC/P') AND ass.PsychologicalCredibilityId = 3 THEN 1 ELSE 0 END AS PsychologicalCredibilityQuestionable
	,CASE WHEN ass.DiagnosisFoundReponseId = 1 THEN 1 ELSE 0 END AS DiagnosisFoundYes
	,CASE WHEN ass.DiagnosisFoundReponseId = 2 THEN 1 ELSE 0 END AS DiagnosisFoundNo
	,CASE WHEN ass.DiagnosisFoundReponseId = 3 THEN 1 ELSE 0 END AS DiagnosisFoundRuleOut
	,CASE WHEN ass.PsychologistFoundInFavorOfClaimant = 1 THEN 1 ELSE 0 END AS PsychologistFoundInFavorOfClaimantYes
	,CASE WHEN ass.PsychologistFoundInFavorOfClaimant = 0 THEN 1 ELSE 0 END AS PsychologistFoundInFavorOfClaimantNo
	,CASE WHEN ass.PsychologistFoundInFavorOfClaimant IS NULL THEN 1 ELSE 0 END AS PsychologistFoundInFavorOfClaimantUnknown

	--,ass.NeurocognitiveCredibilityId
	--,ass.PsychologicalCredibilityId
	--,ass.DiagnosisFoundReponseId
	--,ass.PsychologistFoundInFavorOfClaimant
	FROM dbo.Assessments ass
	INNER JOIN dbo.AssessmentTypes asst ON ass.AssessmentTypeId = asst.AssessmentTypeId
	INNER JOIN dbo.AssessmentAttributes assAttr ON ass.AssessmentId = assAttr.AssessmentId
	INNER JOIN dbo.Attributes attr ON assAttr.AttributeId = attr.AttributeId
	WHERE
	ass.CompanyId = @companyId_local 
	AND attr.[Name] = 'Final copy received'
	AND assAttr.[Value] = 1
	AND 
	(
		(asst.[Name] IN ('NC','NC/P','NP') AND ass.NeurocognitiveCredibilityId IS NOT NULL)
		OR (asst.[Name] IN ('P', 'PVOC', 'NP', 'NC/P') AND ass.PsychologicalCredibilityId IS NOT NULL)
	)
	--AND DiagnosisFoundReponseId IS NOT NULL

END