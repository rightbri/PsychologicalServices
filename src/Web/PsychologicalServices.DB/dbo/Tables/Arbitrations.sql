﻿CREATE TABLE [dbo].[Arbitrations] (
    [ArbitrationId]     INT                IDENTITY (1, 1) NOT NULL,
    [AssessmentId]      INT                NOT NULL,
    [StartDate]         DATETIMEOFFSET (7) NOT NULL,
    [EndDate]           DATETIMEOFFSET (7) NOT NULL,
    [AvailableDate]     DATETIMEOFFSET (7) NOT NULL,
    [DefenseLawyerId]   INT                NULL,
    [DefenseFileNumber] NVARCHAR (50)      NULL,
    [Title]             NVARCHAR (50)      NOT NULL,
    CONSTRAINT [PK_Arbitrations] PRIMARY KEY CLUSTERED ([ArbitrationId] ASC),
    CONSTRAINT [FK_Arbitrations_Assessments] FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[Assessments] ([AssessmentId]),
    CONSTRAINT [FK_Arbitrations_Contacts] FOREIGN KEY ([DefenseLawyerId]) REFERENCES [dbo].[Contacts] ([ContactId])
);


