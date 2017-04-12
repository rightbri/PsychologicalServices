CREATE TABLE [dbo].[InvoiceStatuses] (
    [InvoiceStatusId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50) NOT NULL,
    [IsActive]        BIT           CONSTRAINT [DF_InvoiceStatuses_IsActive] DEFAULT ((1)) NOT NULL,
    [CanEdit]         BIT           CONSTRAINT [DF_InvoiceStatuses_CanEdit] DEFAULT ((0)) NOT NULL,
    [CanOpen]         BIT           CONSTRAINT [DF_InvoiceStatuses_CanOpen] DEFAULT ((0)) NOT NULL,
    [CanSubmit]       BIT           CONSTRAINT [DF_InvoiceStatuses_CanSubmit] DEFAULT ((0)) NOT NULL,
    [CanMarkPaid]     BIT           CONSTRAINT [DF_InvoiceStatuses_CanMarkPaid] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_InvoiceStatuses] PRIMARY KEY CLUSTERED ([InvoiceStatusId] ASC)
);



