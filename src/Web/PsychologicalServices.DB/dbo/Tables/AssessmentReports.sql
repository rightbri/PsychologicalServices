CREATE TABLE [dbo].[AssessmentReports] (
    [ReportId]     INT IDENTITY (1, 1) NOT NULL,
    [AssessmentId] INT NOT NULL,
    [ReportTypeId] INT NOT NULL,
    CONSTRAINT [PK_AssessmentReports] PRIMARY KEY CLUSTERED ([ReportId] ASC),
    CONSTRAINT [FK_AssessmentReports_Assessments] FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[Assessments] ([AssessmentId]),
    CONSTRAINT [FK_AssessmentReports_ReportTypes] FOREIGN KEY ([ReportTypeId]) REFERENCES [dbo].[ReportTypes] ([ReportTypeId])
);

