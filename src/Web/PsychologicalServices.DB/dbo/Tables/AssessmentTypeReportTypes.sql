CREATE TABLE [dbo].[AssessmentTypeReportTypes] (
    [AssessmentTypeId] INT NOT NULL,
    [ReportTypeId]     INT NOT NULL,
    CONSTRAINT [PK_AssessmentTypeReportTypes] PRIMARY KEY CLUSTERED ([AssessmentTypeId] ASC, [ReportTypeId] ASC),
    CONSTRAINT [FK_AssessmentTypeReportTypes_AssessmentTypes] FOREIGN KEY ([AssessmentTypeId]) REFERENCES [dbo].[AssessmentTypes] ([AssessmentTypeId]),
    CONSTRAINT [FK_AssessmentTypeReportTypes_ReportTypes] FOREIGN KEY ([ReportTypeId]) REFERENCES [dbo].[ReportTypes] ([ReportTypeId])
);

