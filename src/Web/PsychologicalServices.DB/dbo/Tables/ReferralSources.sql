CREATE TABLE [dbo].[ReferralSources] (
    [ReferralSourceId]     INT             IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (100)  NOT NULL,
    [ReferralSourceTypeId] INT             NOT NULL,
    [IsActive]             BIT             CONSTRAINT [DF_ReferralSources_IsActive] DEFAULT ((1)) NOT NULL,
    [LargeFileSize]        INT             NOT NULL,
    [LargeFileFeeAmount]   INT             CONSTRAINT [DF_ReferralSources_LargeFileFeeAmount] DEFAULT ((0)) NOT NULL,
    [AddressId]            INT             NULL,
    [LateCancellationRate] DECIMAL (18, 4) NOT NULL,
    CONSTRAINT [PK_ReferralSources] PRIMARY KEY CLUSTERED ([ReferralSourceId] ASC),
    CONSTRAINT [FK_ReferralSources_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]),
    CONSTRAINT [FK_ReferralSources_ReferralSourceTypes] FOREIGN KEY ([ReferralSourceTypeId]) REFERENCES [dbo].[ReferralSourceTypes] ([ReferralSourceTypeId])
);







