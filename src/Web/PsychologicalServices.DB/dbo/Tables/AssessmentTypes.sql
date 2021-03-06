﻿CREATE TABLE [dbo].[AssessmentTypes] (
    [AssessmentTypeId]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]                    NVARCHAR (50)  NOT NULL,
    [Description]             NVARCHAR (100) NULL,
    [IsActive]                BIT            CONSTRAINT [DF_AssessmentTypes_IsActive] DEFAULT ((1)) NOT NULL,
    [ShowOnSchedule]          BIT            CONSTRAINT [DF_AssessmentTypes_ShowOnSchedule] DEFAULT ((1)) NOT NULL,
    [PsychometristCanInvoice] BIT            CONSTRAINT [DF_AssessmentTypes_PsychometristCanInvoice] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_AssessmentTypes] PRIMARY KEY CLUSTERED ([AssessmentTypeId] ASC)
);









