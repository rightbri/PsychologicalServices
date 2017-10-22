CREATE TABLE [dbo].[InvoiceTypes] (
    [InvoiceTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [IsActive]      BIT           CONSTRAINT [DF_InvoiceTypes_IsActive] DEFAULT ((1)) NOT NULL,
    [CanSend]       BIT           CONSTRAINT [DF_InvoiceTypes_CanSend] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_InvoiceTypes] PRIMARY KEY CLUSTERED ([InvoiceTypeId] ASC)
);



