CREATE TABLE [dbo].[Addresses] (
    [AddressId]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [Street]     NVARCHAR (100) NOT NULL,
    [Suite]      NVARCHAR (100) NULL,
    [CityId]     INT            NOT NULL,
    [PostalCode] NVARCHAR (10)  NOT NULL,
    [IsActive]   BIT            CONSTRAINT [DF_Addresses_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([AddressId] ASC),
    CONSTRAINT [FK_Addresses_Cities] FOREIGN KEY ([CityId]) REFERENCES [dbo].[Cities] ([CityId])
);







