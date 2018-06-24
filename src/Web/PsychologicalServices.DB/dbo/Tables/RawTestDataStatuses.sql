CREATE TABLE [dbo].[RawTestDataStatuses] (
    [RawTestDataStatusId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (50) NOT NULL,
    [IsActive]            BIT           CONSTRAINT [DF_RawTestDataStatuses_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_RawTestDataStatuses] PRIMARY KEY CLUSTERED ([RawTestDataStatusId] ASC)
);

