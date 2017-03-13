CREATE TABLE [dbo].[CompanyAttributes] (
    [CompanyId]   INT NOT NULL,
    [AttributeId] INT NOT NULL,
    CONSTRAINT [PK_CompanyAttributes] PRIMARY KEY CLUSTERED ([CompanyId] ASC, [AttributeId] ASC),
    CONSTRAINT [FK_CompanyAttributes_Attributes] FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[Attributes] ([AttributeId]),
    CONSTRAINT [FK_CompanyAttributes_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId])
);

