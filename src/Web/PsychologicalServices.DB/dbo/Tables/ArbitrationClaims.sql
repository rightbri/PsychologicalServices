CREATE TABLE [dbo].[ArbitrationClaims] (
    [ArbitrationId] INT NOT NULL,
    [ClaimId]       INT NOT NULL,
    CONSTRAINT [PK_ArbitrationClaims] PRIMARY KEY CLUSTERED ([ArbitrationId] ASC, [ClaimId] ASC),
    CONSTRAINT [FK_ArbitrationClaims_Arbitrations] FOREIGN KEY ([ArbitrationId]) REFERENCES [dbo].[Arbitrations] ([ArbitrationId]),
    CONSTRAINT [FK_ArbitrationClaims_Claims] FOREIGN KEY ([ClaimId]) REFERENCES [dbo].[Claims] ([ClaimId])
);

