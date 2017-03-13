CREATE TABLE [dbo].[AppointmentAttributes] (
    [AppointmentId] INT NOT NULL,
    [AttributeId]   INT NOT NULL,
    CONSTRAINT [PK_AppointmentAttributes] PRIMARY KEY CLUSTERED ([AppointmentId] ASC, [AttributeId] ASC),
    CONSTRAINT [FK_AppointmentAttributes_Appointments] FOREIGN KEY ([AppointmentId]) REFERENCES [dbo].[Appointments] ([AppointmentId]),
    CONSTRAINT [FK_AppointmentAttributes_Attributes] FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[Attributes] ([AttributeId])
);

