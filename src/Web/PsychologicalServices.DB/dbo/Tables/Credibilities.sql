CREATE TABLE [dbo].[Credibilities] (
    [CredibilityId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [IsActive]      BIT           CONSTRAINT [DF_Credibilities_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Credibilities] PRIMARY KEY CLUSTERED ([CredibilityId] ASC)
);

