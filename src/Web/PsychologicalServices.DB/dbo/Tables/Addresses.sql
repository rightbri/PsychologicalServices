CREATE TABLE [dbo].[Addresses] (
    [AddressId]     INT            IDENTITY (1, 1) NOT NULL,
    [Address]       NVARCHAR (100) NOT NULL,
    [Suite]         NVARCHAR (100) NULL,
    [City]          NVARCHAR (100) NOT NULL,
    [Province]      NVARCHAR (10)  NOT NULL,
    [PostalCode]    NVARCHAR (10)  NOT NULL,
    [Country]       NVARCHAR (50)  NOT NULL,
    [IsActive]      BIT            CONSTRAINT [DF_Addresses_IsActive] DEFAULT ((1)) NOT NULL,
    [AddressTypeId] INT            NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([AddressId] ASC),
    CONSTRAINT [FK_Addresses_AddressTypes] FOREIGN KEY ([AddressTypeId]) REFERENCES [dbo].[AddressTypes] ([AddressTypeId])
);

