CREATE TABLE [dbo].[Companies] (
    [CompanyId]                     INT            IDENTITY (1, 1) NOT NULL,
    [Name]                          NVARCHAR (100) NOT NULL,
    [IsActive]                      BIT            CONSTRAINT [DF_Companies_IsActive] DEFAULT ((1)) NOT NULL,
    [AddressId]                     INT            NULL,
    [Phone]                         NVARCHAR (50)  NULL,
    [Fax]                           NVARCHAR (50)  NULL,
    [Email]                         NVARCHAR (100) NULL,
    [TaxId]                         NVARCHAR (50)  NULL,
    [NewAppointmentTime]            BIGINT         NULL,
    [NewAppointmentLocationId]      INT            NULL,
    [NewAppointmentPsychologistId]  INT            NULL,
    [NewAppointmentPsychometristId] INT            NULL,
    [NewAppointmentStatusId]        INT            NULL,
    [NewAssessmentReportStatusId]   INT            NULL,
    [NewAssessmentSummaryNoteText]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ([CompanyId] ASC),
    CONSTRAINT [FK_Companies_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]),
    CONSTRAINT [FK_Companies_Addresses1] FOREIGN KEY ([NewAppointmentLocationId]) REFERENCES [dbo].[Addresses] ([AddressId]),
    CONSTRAINT [FK_Companies_AppointmentStatuses] FOREIGN KEY ([NewAppointmentStatusId]) REFERENCES [dbo].[AppointmentStatuses] ([AppointmentStatusId]),
    CONSTRAINT [FK_Companies_ReportStatuses] FOREIGN KEY ([NewAssessmentReportStatusId]) REFERENCES [dbo].[ReportStatuses] ([ReportStatusId]),
    CONSTRAINT [FK_Companies_Users] FOREIGN KEY ([NewAppointmentPsychologistId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Companies_Users1] FOREIGN KEY ([NewAppointmentPsychometristId]) REFERENCES [dbo].[Users] ([UserId])
);







