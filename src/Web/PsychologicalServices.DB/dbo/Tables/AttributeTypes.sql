CREATE TABLE [dbo].[AttributeTypes] (
    [AttributeTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50) NOT NULL,
    [IsActive]        BIT           CONSTRAINT [DF_AttributeTypes_IsActive] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AttributeTypes] PRIMARY KEY CLUSTERED ([AttributeTypeId] ASC)
);

