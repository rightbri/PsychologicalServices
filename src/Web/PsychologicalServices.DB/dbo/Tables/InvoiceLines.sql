CREATE TABLE [dbo].[InvoiceLines] (
    [InvoiceLineId]      INT            IDENTITY (1, 1) NOT NULL,
    [Description]        NVARCHAR (100) NOT NULL,
    [Amount]             INT            NOT NULL,
    [IsCustom]           BIT            CONSTRAINT [DF_InvoiceLines_IsCustom] DEFAULT ((0)) NOT NULL,
    [OriginalAmount]     INT            NOT NULL,
    [InvoiceLineGroupId] INT            NOT NULL,
    CONSTRAINT [PK_InvoiceLines] PRIMARY KEY CLUSTERED ([InvoiceLineId] ASC),
    CONSTRAINT [FK_InvoiceLines_InvoiceLineGroups] FOREIGN KEY ([InvoiceLineGroupId]) REFERENCES [dbo].[InvoiceLineGroups] ([InvoiceLineGroupId])
);













