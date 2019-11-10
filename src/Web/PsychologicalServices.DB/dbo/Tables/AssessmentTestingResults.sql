CREATE TABLE [dbo].[AssessmentTestingResults] (
    [AssessmentId] INT            NOT NULL,
    [Name]         VARCHAR (50)   NOT NULL,
    [Responses]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AssessmentTestingResults] PRIMARY KEY CLUSTERED ([AssessmentId] ASC, [Name] ASC),
    CONSTRAINT [FK_AssessmentTestingResults_Assessments] FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[Assessments] ([AssessmentId])
);

