CREATE TABLE [dbo].[ContactTypes] (
    [ContactTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [IsActive]      BIT           CONSTRAINT [DF_ContactTypes_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_ContactTypes] PRIMARY KEY CLUSTERED ([ContactTypeId] ASC)
);

