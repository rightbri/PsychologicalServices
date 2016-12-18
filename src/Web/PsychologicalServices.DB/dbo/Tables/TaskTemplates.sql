CREATE TABLE [dbo].[TaskTemplates] (
    [TaskTemplateId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50) NOT NULL,
    [IsActive]       BIT           CONSTRAINT [DF_AppointmentTaskTemplates_IsActive] DEFAULT ((1)) NOT NULL,
    [CompanyId]      INT           NOT NULL,
    CONSTRAINT [PK_AppointmentTaskTemplates] PRIMARY KEY CLUSTERED ([TaskTemplateId] ASC),
    CONSTRAINT [FK_AppointmentTaskTemplates_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId])
);

