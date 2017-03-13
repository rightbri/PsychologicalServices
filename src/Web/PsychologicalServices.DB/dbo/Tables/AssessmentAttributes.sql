CREATE TABLE [dbo].[AssessmentAttributes] (
    [AssessmentId] INT NOT NULL,
    [AttributeId]  INT NOT NULL,
    CONSTRAINT [PK_AssessmentAttributes] PRIMARY KEY CLUSTERED ([AssessmentId] ASC, [AttributeId] ASC),
    CONSTRAINT [FK_AssessmentAttributes_Assessments] FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[Assessments] ([AssessmentId]),
    CONSTRAINT [FK_AssessmentAttributes_Attributes] FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[Attributes] ([AttributeId])
);

