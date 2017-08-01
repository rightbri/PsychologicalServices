CREATE TABLE [dbo].[AppointmentStatuses] (
    [AppointmentStatusId]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (50)  NOT NULL,
    [Description]          NVARCHAR (100) NULL,
    [IsActive]             BIT            CONSTRAINT [DF_AppointmentStatuses_IsActive] DEFAULT ((0)) NOT NULL,
    [NotifyReferralSource] BIT            CONSTRAINT [DF_AppointmentStatuses_NotifyImeCompany] DEFAULT ((0)) NOT NULL,
    [CanInvoice]           BIT            CONSTRAINT [DF_AppointmentStatuses_CanInvoice] DEFAULT ((0)) NOT NULL,
    [Sort]                 INT            NOT NULL,
    [ShowOnSchedule]       BIT            CONSTRAINT [DF_AppointmentStatuses_ShowOnSchedule] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AppointmentStatuses] PRIMARY KEY CLUSTERED ([AppointmentStatusId] ASC)
);







