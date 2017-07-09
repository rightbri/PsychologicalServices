CREATE TABLE [dbo].[AddressAddressTypes] (
    [AddressId]     INT NOT NULL,
    [AddressTypeId] INT NOT NULL,
    CONSTRAINT [PK_AddressAddressTypes] PRIMARY KEY CLUSTERED ([AddressId] ASC, [AddressTypeId] ASC),
    CONSTRAINT [FK_AddressAddressTypes_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]),
    CONSTRAINT [FK_AddressAddressTypes_AddressTypes] FOREIGN KEY ([AddressTypeId]) REFERENCES [dbo].[AddressTypes] ([AddressTypeId])
);

