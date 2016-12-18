CREATE TABLE [dbo].[Claims] (
    [ClaimId]     INT           IDENTITY (1, 1) NOT NULL,
    [ClaimantId]  INT           NOT NULL,
    [DateOfLoss]  DATETIME      NOT NULL,
    [ClaimNumber] NVARCHAR (50) NOT NULL,
    [Deleted]     BIT           CONSTRAINT [DF_Claims_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Claims] PRIMARY KEY CLUSTERED ([ClaimId] ASC),
    CONSTRAINT [FK_Claims_Claimants] FOREIGN KEY ([ClaimantId]) REFERENCES [dbo].[Claimants] ([ClaimantId])
);

