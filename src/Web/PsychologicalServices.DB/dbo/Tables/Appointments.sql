CREATE TABLE [dbo].[Appointments] (
    [AppointmentId]       INT                IDENTITY (1, 1) NOT NULL,
    [LocationId]          INT                NOT NULL,
    [AppointmentTime]     DATETIMEOFFSET (7) NOT NULL,
    [PsychometristId]     INT                NOT NULL,
    [PsychologistId]      INT                NOT NULL,
    [AppointmentStatusId] INT                NOT NULL,
    [AssessmentId]        INT                NOT NULL,
    [CreateDate]          DATETIMEOFFSET (7) CONSTRAINT [DF_Appointments_CreateDate] DEFAULT (getdate()) NOT NULL,
    [CreateUserId]        INT                NOT NULL,
    [UpdateDate]          DATETIMEOFFSET (7) CONSTRAINT [DF_Appointments_UpdateDate] DEFAULT (getdate()) NOT NULL,
    [UpdateUserId]        INT                NOT NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([AppointmentId] ASC),
    CONSTRAINT [FK_Appointments_Addresses] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Addresses] ([AddressId]),
    CONSTRAINT [FK_Appointments_AppointmentStatuses] FOREIGN KEY ([AppointmentStatusId]) REFERENCES [dbo].[AppointmentStatuses] ([AppointmentStatusId]),
    CONSTRAINT [FK_Appointments_Assessments] FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[Assessments] ([AssessmentId]),
    CONSTRAINT [FK_Appointments_Psychologist] FOREIGN KEY ([PsychologistId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Appointments_Psychometrist] FOREIGN KEY ([PsychometristId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Appointments_Users] FOREIGN KEY ([CreateUserId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Appointments_Users1] FOREIGN KEY ([UpdateUserId]) REFERENCES [dbo].[Users] ([UserId])
);











