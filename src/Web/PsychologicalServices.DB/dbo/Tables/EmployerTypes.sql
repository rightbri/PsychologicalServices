CREATE TABLE [dbo].[EmployerTypes] (
    [EmployerTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50) NOT NULL,
    [IsActive]       BIT           CONSTRAINT [DF_EmployerTypes_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_EmployerTypes] PRIMARY KEY CLUSTERED ([EmployerTypeId] ASC)
);

