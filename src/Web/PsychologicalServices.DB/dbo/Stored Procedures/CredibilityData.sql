

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
	FROM dbo.Assessments ass
	INNER JOIN dbo.AssessmentTypes asst ON ass.AssessmentTypeId = asst.AssessmentTypeId
	WHERE
	ass.CompanyId = @companyId_local 
	AND 
	(
		(asst.[Name] IN ('NC','NC/P','NP') AND ass.NeurocognitiveCredibilityId IS NOT NULL)
		OR (asst.[Name] IN ('P', 'PVOC', 'NP', 'NC/P') AND ass.PsychologicalCredibilityId IS NOT NULL)
	)
	

	DECLARE @data TABLE (
		[Year] INT,
		[Count] INT,
		[PsychCredibilityAnswered] DECIMAL(16, 2),
		[NeuroCredibilityAnswered] DECIMAL(16, 2),
		[PsychCredible] DECIMAL(16, 2),
		[PsychNotCredible] DECIMAL(16, 2),
		[PsychQuestionable] DECIMAL(16, 2),
		[NeuroCredible] DECIMAL(16, 2),
		[NeuroNotCredible] DECIMAL(16, 2),
		[NeuroQuestionable] DECIMAL(16, 2),
		[Psychometrist] VARCHAR(200),
		[Reader] DECIMAL(16, 2),
		[Translator] DECIMAL(16, 2)
	)

	INSERT INTO @data (
		[Year],
		[Count],
		[PsychCredibilityAnswered],
		[NeuroCredibilityAnswered],
		[PsychCredible],
		[PsychNotCredible],
		[PsychQuestionable],
		[NeuroCredible],
		[NeuroNotCredible],
		[NeuroQuestionable],
		[Psychometrist],
		[Reader],
		[Translator]
	) 
		SELECT 
		 YEAR(app.AppointmentTime) AS [Year]
		,app.[Row]
		,CASE WHEN PsychologicalCredibilityId IS NOT NULL THEN 1 ELSE 0 END AS PsychCredibilityAnswered
		,CASE WHEN NeurocognitiveCredibilityId IS NOT NULL THEN 1 ELSE 0 END AS NeuroCredibilityAnswered
		,CASE WHEN PsychologicalCredibilityId = 1 THEN 1 ELSE 0 END AS PsychCredible
		,CASE WHEN PsychologicalCredibilityId = 2 THEN 1 ELSE 0 END AS PsychNotCredible
		,CASE WHEN PsychologicalCredibilityId = 3 THEN 1 ELSE 0 END AS PsychQuestionable
		,CASE WHEN NeurocognitiveCredibilityId = 1 THEN 1 ELSE 0 END AS NeuroCredible
		,CASE WHEN NeurocognitiveCredibilityId = 2 THEN 1 ELSE 0 END AS NeuroNotCredible
		,CASE WHEN NeurocognitiveCredibilityId = 3 THEN 1 ELSE 0 END AS NeuroQuestionable
		,app.Psychometrist
		,app.Reader
		,app.Translator

		FROM dbo.Assessments ass
		INNER JOIN (
			SELECT * FROM (
				SELECT 
				 AssessmentId 
				,appt.AppointmentId
				,AppointmentTime
				,psychometrists.FirstName AS Psychometrist
				,CASE WHEN Reader IS NULL THEN 0 ELSE Reader END AS Reader
				,CASE WHEN Translator IS NULL THEN 0 ELSE Translator END AS Translator
				,ROW_NUMBER() OVER (PARTITION BY appt.AssessmentId ORDER BY AppointmentTime) AS [Row]
				FROM dbo.Appointments appt 
				LEFT JOIN (
					SELECT 
					appAttr.[AppointmentId]
					,MAX(CASE WHEN AttributeId = 1 THEN 1 ELSE 0 END) AS Reader
					,MAX(CASE WHEN AttributeId = 2 THEN 1 ELSE 0 END) AS Translator
					FROM dbo.AppointmentAttributes appAttr
					WHERE 
					AttributeId IN (1, 2)
					AND [Value] = 1
					GROUP BY
					AppointmentId
				) attr ON appt.AppointmentId = attr.AppointmentId
				LEFT JOIN dbo.Users psychometrists ON appt.PsychometristId = psychometrists.UserId
				WHERE 
				AppointmentStatusId IN (6, 7) 
			) x
			WHERE 
			[Row] = 1
		) app ON ass.AssessmentId = app.AssessmentId
		INNER JOIN dbo.AssessmentTypes asst ON ass.AssessmentTypeId = asst.AssessmentTypeId
		WHERE 
		(
			ass.NeurocognitiveCredibilityId IS NOT NULL
			OR
			ass.PsychologicalCredibilityId IS NOT NULL
		)
		AND ass.CompanyId = @companyId_local


	SELECT
	[Type]
	,[Year]
	,[CredibilityTotal]
	,[Credible]
	,[NotCredible]
	,[Questionable]
	,CASE WHEN [CredibilityTotal] = 0 THEN 0 ELSE [Credible] / [CredibilityTotal] END AS CredibleRate
	,CASE WHEN [CredibilityTotal] = 0 THEN 0 ELSE [NotCredible] / [CredibilityTotal] END AS NotCredibleRate
	,CASE WHEN [CredibilityTotal] = 0 THEN 0 ELSE [Questionable] / [CredibilityTotal] END AS QuestionableRate

	FROM (

		SELECT 
		 'Neurocognitive' AS [Type]
		,[Year]
		,SUM(NeuroCredibilityAnswered) AS CredibilityTotal
		,SUM(NeuroCredible) AS Credible
		,SUM(NeuroNotCredible) AS NotCredible
		,SUM(NeuroQuestionable) AS Questionable
		FROM @data
		GROUP BY 
		[Year]

		UNION ALL

		SELECT 
		 'Psychological' AS [Type]
		,[Year]
		,SUM(PsychCredibilityAnswered) AS CredibilityTotal
		,SUM(PsychCredible) AS Credible
		,SUM(PsychNotCredible) AS NotCredible
		,SUM(PsychQuestionable) AS Questionable
		FROM @data
		GROUP BY 
		[Year]

	) x
	ORDER BY 
	[Type]
	,[Year]


	--Not Credibles - % with/without reader/translator
	SELECT 
	[Type]
	,[Year]
	,SUM([Count]) AS [Count]
	,SUM([WithReader]) AS WithReader
	,SUM([WithoutReader]) AS WithoutReader
	,SUM([WithTranslator]) AS WithTranslator
	,SUM([WithoutTranslator]) AS WithoutTranslator

	,SUM([WithReader]) / SUM([Count]) AS WithReaderRate
	,SUM([WithoutReader]) / SUM([Count]) AS WithoutReaderRate
	,SUM([WithTranslator]) / SUM([Count]) AS WithTranslatorRate
	,SUM([WithoutTranslator]) / SUM([Count]) AS WithoutTranslatorRate

	FROM (
		SELECT 
		'Neurocognitive' AS [Type]
		,[Year]
		,[Count]
		,CAST(CASE WHEN [NeuroNotCredible] = 1 AND [Reader] = 1 THEN 1 ELSE 0 END AS DECIMAL(16, 2)) AS WithReader
		,CAST(CASE WHEN [NeuroNotCredible] = 1 AND [Reader] = 0 THEN 1 ELSE 0 END AS DECIMAL(16, 2)) AS WithoutReader
		,CAST(CASE WHEN [NeuroNotCredible] = 1 AND [Translator] = 1 THEN 1 ELSE 0 END AS DECIMAL(16, 2)) AS WithTranslator
		,CAST(CASE WHEN [NeuroNotCredible] = 1 AND [Translator] = 0 THEN 1 ELSE 0 END AS DECIMAL(16, 2)) AS WithoutTranslator

		FROM @data 
		WHERE 
		[NeuroNotCredible] = 1

		UNION ALL 

		SELECT 
		'Psychological' AS [Type]
		,[Year]
		,[Count]
		,CASE WHEN [PsychNotCredible] = 1 AND [Reader] = 1 THEN 1 ELSE 0 END AS WithReader
		,CASE WHEN [PsychNotCredible] = 1 AND [Reader] = 0 THEN 1 ELSE 0 END AS WithoutReader
		,CASE WHEN [PsychNotCredible] = 1 AND [Translator] = 1 THEN 1 ELSE 0 END AS WithTranslator
		,CASE WHEN [PsychNotCredible] = 1 AND [Translator] = 0 THEN 1 ELSE 0 END AS WithoutTranslator

		FROM @data 
		WHERE 
		[PsychNotCredible] = 1
	) x
	GROUP BY 
	 [Type]
	,[Year]
	ORDER BY 
	 [Type]
	,[Year]


	--credibility by psychometrist
	SELECT 
	 [Type]
	,[Year]
	,[Psychometrist]
	,SUM([Credible]) AS [Credible]
	,SUM([NotCredible]) AS [NotCredible]
	,SUM([Questionable]) AS [Questionable]
	,SUM([Credible]) / SUM([Count]) AS CredibleRate
	,SUM([NotCredible]) / SUM([Count]) AS NotCredibleRate
	,SUM([Questionable]) / SUM([Count]) AS QuestionableRate

	FROM (
		SELECT 
		 [Year]
		,'Neurocognitive' AS [Type]
		,[Psychometrist]
		,1 AS [Count]
		,[NeuroCredible] AS [Credible]
		,[NeuroNotCredible] AS [NotCredible]
		,[NeuroQuestionable] AS [Questionable]
		FROM @data 
		WHERE 
		[NeuroCredibilityAnswered] = 1

		UNION ALL

		SELECT 
		 [Year]
		,'Psychological' AS [Type]
		,[Psychometrist]
		,1 AS [Count]
		,[PsychCredible] AS [Credible]
		,[PsychNotCredible] AS [NotCredible]
		,[PsychQuestionable] AS [Questionable]
		FROM @data 
		WHERE 
		[PsychCredibilityAnswered] = 1
	) x
	GROUP BY 
	[Type]
	,[Year]
	,[Psychometrist]
	ORDER BY 
	 [Type]
	,[Year]
	,[Psychometrist]

END