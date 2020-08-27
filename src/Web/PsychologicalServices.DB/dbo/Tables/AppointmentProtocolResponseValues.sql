CREATE TABLE [dbo].[AppointmentProtocolResponseValues] (
    [AppointmentProtocolResponseValueId] INT          IDENTITY (1, 1) NOT NULL,
    [Value]                              VARCHAR (50) NOT NULL,
    [IsActive]                           BIT          CONSTRAINT [DF_AppointmentProtocolResponseValues_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_AppointmentProtocolResponseValues] PRIMARY KEY CLUSTERED ([AppointmentProtocolResponseValueId] ASC)
);

