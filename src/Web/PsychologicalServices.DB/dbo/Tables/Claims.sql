﻿CREATE TABLE [dbo].[Claims] (
    [ClaimId]          INT                IDENTITY (1, 1) NOT NULL,
    [ClaimantId]       INT                NOT NULL,
    [DateOfLoss]       DATETIMEOFFSET (7) NULL,
    [ClaimNumber]      NVARCHAR (50)      NULL,
    [Lawyer]           NVARCHAR (50)      NULL,
    [InsuranceCompany] NVARCHAR (50)      NULL,
    CONSTRAINT [PK_Claims] PRIMARY KEY CLUSTERED ([ClaimId] ASC),
    CONSTRAINT [FK_Claims_Claimants] FOREIGN KEY ([ClaimantId]) REFERENCES [dbo].[Claimants] ([ClaimantId])
);












GO
CREATE NONCLUSTERED INDEX [IX_Claims_ClaimantId]
    ON [dbo].[Claims]([ClaimantId] ASC);

