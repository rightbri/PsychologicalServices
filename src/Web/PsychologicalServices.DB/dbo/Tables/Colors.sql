CREATE TABLE [dbo].[Colors] (
    [ColorId]  INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [HexCode]  VARCHAR (10) NOT NULL,
    [IsActive] BIT          CONSTRAINT [DF_Colors_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED ([ColorId] ASC)
);

