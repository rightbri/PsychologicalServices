CREATE TABLE [dbo].[ReferralSourceTypes] (
    [ReferralSourceTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (50) NOT NULL,
    [IsActive]             BIT           CONSTRAINT [DF_ReferralSourceTypes_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_ReferralSourceTypes] PRIMARY KEY CLUSTERED ([ReferralSourceTypeId] ASC)
);

