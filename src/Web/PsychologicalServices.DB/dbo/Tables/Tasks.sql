CREATE TABLE [dbo].[Tasks] (
    [TaskId]         INT IDENTITY (1, 1) NOT NULL,
    [TaskTemplateId] INT NOT NULL,
    [TaskStatusId]   INT NOT NULL,
    CONSTRAINT [PK_AppointmentTasks] PRIMARY KEY CLUSTERED ([TaskId] ASC),
    CONSTRAINT [FK_Tasks_TaskStatuses] FOREIGN KEY ([TaskStatusId]) REFERENCES [dbo].[TaskStatuses] ([TaskStatusId]),
    CONSTRAINT [FK_Tasks_TaskTemplates] FOREIGN KEY ([TaskTemplateId]) REFERENCES [dbo].[TaskTemplates] ([TaskTemplateId])
);

