CREATE TABLE [dbo].[ArbitrationStatuses] (
    [ArbitrationStatusId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (50) NOT NULL,
    [IsActive]            BIT           CONSTRAINT [DF_ArbitrationStatuses_IsActive] DEFAULT ((1)) NOT NULL,
    [ShowOnCalendar]      BIT           CONSTRAINT [DF_ArbitrationStatuses_ShowOnCalendar] DEFAULT ((0)) NOT NULL,
    [ShowOnSchedule]      BIT           CONSTRAINT [DF_ArbitrationStatuses_ShowOnSchedule] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ArbitrationStatuses] PRIMARY KEY CLUSTERED ([ArbitrationStatusId] ASC)
);



