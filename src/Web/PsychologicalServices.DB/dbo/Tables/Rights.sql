CREATE TABLE [dbo].[Rights] (
    [RightId]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (100) NULL,
    [IsActive]    BIT            CONSTRAINT [DF_Right_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Rights] PRIMARY KEY CLUSTERED ([RightId] ASC)
);

