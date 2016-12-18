CREATE TABLE [dbo].[ReportTypes] (
    [ReportTypeId]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50) NOT NULL,
    [IsActive]        BIT           CONSTRAINT [DF_ReportTypes_IsActive] DEFAULT ((1)) NOT NULL,
    [NumberOfReports] INT           NOT NULL,
    CONSTRAINT [PK_ReportTypes] PRIMARY KEY CLUSTERED ([ReportTypeId] ASC)
);

