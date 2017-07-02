CREATE TABLE [dbo].[Claims] (
    [ClaimId]     INT           IDENTITY (1, 1) NOT NULL,
    [ClaimantId]  INT           NOT NULL,
    [DateOfLoss]  DATETIME      NULL,
    [ClaimNumber] NVARCHAR (50) NULL,
    [Lawyer]      NVARCHAR (50) NULL,
    CONSTRAINT [PK_Claims] PRIMARY KEY CLUSTERED ([ClaimId] ASC),
    CONSTRAINT [FK_Claims_Claimants] FOREIGN KEY ([ClaimantId]) REFERENCES [dbo].[Claimants] ([ClaimantId])
);





