
CREATE PROCEDURE [dbo].[ClaimantSearch]
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50),
	@name NVARCHAR(50),
	@dateOfBirth DATETIMEOFFSET,
	@resultCount INT = 50
AS
BEGIN
	SET NOCOUNT ON;

    DECLARE @firstName_local NVARCHAR(50) = @firstName,
			@lastName_local NVARCHAR(50) = @lastName,
			@name_local NVARCHAR(50) = @name,
			@dateOfBirth_local DATETIMEOFFSET = @dateOfBirth,
			@resultCount_local INT = @resultCount

	CREATE TABLE #claimants (
		[ClaimantId] INT NOT NULL,
		[FirstName] NVARCHAR(50) NOT NULL,
		[LastName] NVARCHAR(50) NOT NULL,
		[IsActive] BIT NOT NULL,
		[Gender] NCHAR(1) NOT NULL,
		[DateOfBirth] DATETIMEOFFSET NOT NULL,
		[Order] INT
		PRIMARY KEY CLUSTERED ([ClaimantId])
	)

	INSERT INTO #claimants ([ClaimantId],[FirstName],[LastName],[IsActive],[Gender],[DateOfBirth],[Order]) 
		SELECT TOP(@resultCount_local) 
		 [ClaimantId]
		,[FirstName]
		,[LastName]
		,[IsActive]
		,[Gender]
		,[DateOfBirth]
		,CASE
			WHEN [FirstName] LIKE ISNULL(@name_local, ISNULL(@firstName_local, '')) THEN LEN([FirstName]) 
			WHEN [LastName] LIKE ISNULL(@name_local, ISNULL(@lastName_local, '')) THEN LEN([LastName]) 
			ELSE 50
		END AS [Order]
		FROM [dbo].[Claimants] 
		WHERE 1=1 
		AND (@firstName_local IS NULL OR [FirstName] LIKE @firstName_local)
		AND (@lastName_local IS NULL OR [LastName] LIKE @lastName_local)
		AND (@name_local IS NULL OR ([LastName] LIKE @name_local OR [FirstName] LIKE @name_local))
		AND (@dateOfBirth_local IS NULL OR [DateOfBirth] = @dateOfBirth_local)
		ORDER BY 
		[Order]

	SELECT * FROM #claimants ORDER BY [Order]
	
	SELECT 
	 cl.[ClaimId]
	,cl.[ClaimantId]
	,cl.[DateOfLoss]
	,cl.[ClaimNumber]
	,cl.[Lawyer]
	,cl.[InsuranceCompany]
	FROM [dbo].[Claims] cl
	INNER JOIN #claimants c ON cl.ClaimantId = c.ClaimantId 

END