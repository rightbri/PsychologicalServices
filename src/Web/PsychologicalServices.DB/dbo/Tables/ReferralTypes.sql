CREATE TABLE [dbo].[ReferralTypes] (
    [ReferralTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50) NOT NULL,
    [IsActive]       BIT           CONSTRAINT [DF_ReferralTypes_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_ReferralTypes] PRIMARY KEY CLUSTERED ([ReferralTypeId] ASC)
);

