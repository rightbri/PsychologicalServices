CREATE TABLE [dbo].[Cities] (
    [CityId]   INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Province] NVARCHAR (10) NOT NULL,
    [Country]  NVARCHAR (50) NOT NULL,
    [IsActive] BIT           CONSTRAINT [DF_Cities_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([CityId] ASC)
);

