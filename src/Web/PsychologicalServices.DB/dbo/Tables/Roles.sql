CREATE TABLE [dbo].[Roles] (
    [RoleId]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (100) NULL,
    [IsActive]    BIT            CONSTRAINT [DF_Roles_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);

