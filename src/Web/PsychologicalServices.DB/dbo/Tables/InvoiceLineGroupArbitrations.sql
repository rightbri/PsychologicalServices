CREATE TABLE [dbo].[InvoiceLineGroupArbitrations] (
    [InvoiceLineGroupId] INT NOT NULL,
    [ArbitrationId]      INT NOT NULL,
    CONSTRAINT [PK_InvoiceLineGroupArbitrations] PRIMARY KEY CLUSTERED ([InvoiceLineGroupId] ASC),
    CONSTRAINT [FK_InvoiceLineGroupArbitrations_Arbitrations] FOREIGN KEY ([ArbitrationId]) REFERENCES [dbo].[Arbitrations] ([ArbitrationId]),
    CONSTRAINT [FK_InvoiceLineGroupArbitrations_InvoiceLineGroups] FOREIGN KEY ([InvoiceLineGroupId]) REFERENCES [dbo].[InvoiceLineGroups] ([InvoiceLineGroupId])
);

