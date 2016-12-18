CREATE TABLE [dbo].[AppointmentTasks] (
    [AppointmentId] INT NOT NULL,
    [TaskId]        INT NOT NULL,
    CONSTRAINT [PK_AppointmentTasks_1] PRIMARY KEY CLUSTERED ([AppointmentId] ASC, [TaskId] ASC),
    CONSTRAINT [FK_AppointmentTasks_Appointments] FOREIGN KEY ([AppointmentId]) REFERENCES [dbo].[Appointments] ([AppointmentId]),
    CONSTRAINT [FK_AppointmentTasks_Tasks] FOREIGN KEY ([TaskId]) REFERENCES [dbo].[Tasks] ([TaskId])
);

