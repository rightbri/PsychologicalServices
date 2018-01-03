CREATE TABLE [dbo].[DiagnosisFoundResponses] (
    [DiagnosisFoundResponseId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]                     NVARCHAR (50) NOT NULL,
    [IsActive]                 BIT           CONSTRAINT [DF_DiagnosisFoundResponses_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_DiagnosisFoundResponses] PRIMARY KEY CLUSTERED ([DiagnosisFoundResponseId] ASC)
);

