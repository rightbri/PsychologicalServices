CREATE TABLE [dbo].[Users] (
    [UserId]          INT                IDENTITY (1, 1) NOT NULL,
    [FirstName]       NVARCHAR (100)     NOT NULL,
    [LastName]        NVARCHAR (100)     NOT NULL,
    [Email]           NVARCHAR (100)     NOT NULL,
    [IsActive]        BIT                CONSTRAINT [DF_Users_IsActive] DEFAULT ((1)) NOT NULL,
    [CompanyId]       INT                NOT NULL,
    [AddressId]       INT                NOT NULL,
    [DateInactivated] DATETIMEOFFSET (7) NULL,
    [SpinnerId]       INT                NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_Spinner_Users] FOREIGN KEY ([SpinnerId]) REFERENCES [dbo].[Documents] ([DocumentId]),
    CONSTRAINT [FK_Users_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]),
    CONSTRAINT [FK_Users_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId])
);







