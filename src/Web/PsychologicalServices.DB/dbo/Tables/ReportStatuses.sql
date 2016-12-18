CREATE TABLE [dbo].[ReportStatuses] (
    [ReportStatusId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50) NOT NULL,
    [IsActive]       BIT           CONSTRAINT [DF_ReportStatuses_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_ReportStatuses] PRIMARY KEY CLUSTERED ([ReportStatusId] ASC)
);

