CREATE TABLE [dbo].[Attributes] (
    [AttributeId]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50) NOT NULL,
    [AttributeTypeId] INT           NOT NULL,
    [IsActive]        BIT           CONSTRAINT [DF_Attributes_IsActive] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Attributes] PRIMARY KEY CLUSTERED ([AttributeId] ASC),
    CONSTRAINT [FK_Attributes_AttributeTypes] FOREIGN KEY ([AttributeTypeId]) REFERENCES [dbo].[AttributeTypes] ([AttributeTypeId])
);

