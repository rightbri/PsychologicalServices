CREATE TABLE [dbo].[InvoiceStatuses] (
    [InvoiceStatusId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50) NOT NULL,
    [IsActive]        BIT           CONSTRAINT [DF_InvoiceStatuses_IsActive] DEFAULT ((1)) NOT NULL,
    [CanEdit]         BIT           CONSTRAINT [DF_InvoiceStatuses_CanEdit] DEFAULT ((0)) NOT NULL,
    [SaveDocument]    BIT           CONSTRAINT [DF_InvoiceStatuses_CanOpen] DEFAULT ((0)) NOT NULL,
    [ActionName]      NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_InvoiceStatuses] PRIMARY KEY CLUSTERED ([InvoiceStatusId] ASC)
);





