CREATE TABLE [dbo].[Employers] (
    [EmployerId]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50) NOT NULL,
    [EmployerTypeId] INT           NOT NULL,
    [IsActive]       BIT           CONSTRAINT [DF_Employers_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Employers] PRIMARY KEY CLUSTERED ([EmployerId] ASC),
    CONSTRAINT [FK_Employers_EmployerTypes] FOREIGN KEY ([EmployerTypeId]) REFERENCES [dbo].[EmployerTypes] ([EmployerTypeId])
);

