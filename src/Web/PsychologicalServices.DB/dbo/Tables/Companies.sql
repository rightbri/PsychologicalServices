CREATE TABLE [dbo].[Companies] (
    [CompanyId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [IsActive]  BIT            CONSTRAINT [DF_Companies_IsActive] DEFAULT ((1)) NOT NULL,
    [AddressId] INT            NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ([CompanyId] ASC),
    CONSTRAINT [FK_Companies_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId])
);



