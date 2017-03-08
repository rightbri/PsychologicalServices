CREATE TABLE [dbo].[AssessmentColors] (
    [AssessmentId] INT NOT NULL,
    [ColorId]      INT NOT NULL,
    CONSTRAINT [PK_AssessmentColors] PRIMARY KEY CLUSTERED ([AssessmentId] ASC, [ColorId] ASC),
    CONSTRAINT [FK_AssessmentColors_Assessments] FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[Assessments] ([AssessmentId]),
    CONSTRAINT [FK_AssessmentColors_Colors] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId])
);

