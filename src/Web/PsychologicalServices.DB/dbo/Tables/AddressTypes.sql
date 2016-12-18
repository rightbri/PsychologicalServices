CREATE TABLE [dbo].[AddressTypes] (
    [AddressTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [IsActive]      BIT           CONSTRAINT [DF_AddressTypes_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_AddressTypes] PRIMARY KEY CLUSTERED ([AddressTypeId] ASC)
);

