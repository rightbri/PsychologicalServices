CREATE TABLE [dbo].[InvoiceLineGroupRawTestData] (
    [InvoiceLineGroupId] INT NOT NULL,
    [RawTestDataId]      INT NOT NULL,
    CONSTRAINT [PK_InvoiceLineGroupRawTestData] PRIMARY KEY CLUSTERED ([InvoiceLineGroupId] ASC),
    CONSTRAINT [FK_InvoiceLineGroupRawTestData_InvoiceLineGroups] FOREIGN KEY ([InvoiceLineGroupId]) REFERENCES [dbo].[InvoiceLineGroups] ([InvoiceLineGroupId]),
    CONSTRAINT [FK_InvoiceLineGroupRawTestData_RawTestDatas] FOREIGN KEY ([RawTestDataId]) REFERENCES [dbo].[RawTestDatas] ([RawTestDataId])
);

