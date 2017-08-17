CREATE TABLE [dbo].[Contacts] (
    [ContactId]     INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]     NVARCHAR (50)  NOT NULL,
    [LastName]      NVARCHAR (50)  NOT NULL,
    [Email]         NVARCHAR (100) NULL,
    [ContactTypeId] INT            NOT NULL,
    [AddressId]     INT            NULL,
    [EmployerId]    INT            NULL,
    [IsActive]      BIT            CONSTRAINT [DF_Contacts_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED ([ContactId] ASC),
    CONSTRAINT [FK_Contacts_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]),
    CONSTRAINT [FK_Contacts_ContactTypes] FOREIGN KEY ([ContactTypeId]) REFERENCES [dbo].[ContactTypes] ([ContactTypeId]),
    CONSTRAINT [FK_Contacts_Employers] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employers] ([EmployerId])
);

