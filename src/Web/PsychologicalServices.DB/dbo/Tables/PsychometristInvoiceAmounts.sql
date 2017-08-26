CREATE TABLE [dbo].[PsychometristInvoiceAmounts] (
    [AssessmentTypeId]      INT NOT NULL,
    [AppointmentStatusId]   INT NOT NULL,
    [CompanyId]             INT NOT NULL,
    [AppointmentSequenceId] INT NOT NULL,
    [InvoiceAmount]         INT CONSTRAINT [DF_PsychometristInvoiceAmounts_InvoiceAmount] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PsychometristInvoiceAmounts] PRIMARY KEY CLUSTERED ([AssessmentTypeId] ASC, [AppointmentStatusId] ASC, [CompanyId] ASC, [AppointmentSequenceId] ASC),
    CONSTRAINT [FK_PsychometristInvoiceAmounts_AppointmentSequences] FOREIGN KEY ([AppointmentSequenceId]) REFERENCES [dbo].[AppointmentSequences] ([AppointmentSequenceId]),
    CONSTRAINT [FK_PsychometristInvoiceAmounts_AppointmentStatuses] FOREIGN KEY ([AppointmentStatusId]) REFERENCES [dbo].[AppointmentStatuses] ([AppointmentStatusId]),
    CONSTRAINT [FK_PsychometristInvoiceAmounts_AssessmentTypes] FOREIGN KEY ([AssessmentTypeId]) REFERENCES [dbo].[AssessmentTypes] ([AssessmentTypeId]),
    CONSTRAINT [FK_PsychometristInvoiceAmounts_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId])
);

