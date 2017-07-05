CREATE TABLE [dbo].[AppointmentSequences] (
    [AppointmentSequenceId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]                  NVARCHAR (50) NOT NULL,
    [IsActive]              BIT           CONSTRAINT [DF_AppointmentSequences_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_AppointmentSequences] PRIMARY KEY CLUSTERED ([AppointmentSequenceId] ASC)
);

