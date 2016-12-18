CREATE TABLE [dbo].[TaskStatuses] (
    [TaskStatusId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [IsActive]     BIT           CONSTRAINT [DF_AppointmentTaskStatuses_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_AppointmentTaskStatuses] PRIMARY KEY CLUSTERED ([TaskStatusId] ASC)
);

