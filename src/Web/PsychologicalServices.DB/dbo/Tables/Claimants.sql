CREATE TABLE [dbo].[Claimants] (
    [ClaimantId]  INT                IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (50)      NOT NULL,
    [LastName]    NVARCHAR (50)      NOT NULL,
    [IsActive]    BIT                CONSTRAINT [DF_Claimants_IsActive] DEFAULT ((1)) NOT NULL,
    [Gender]      NCHAR (1)          NOT NULL,
    [DateOfBirth] DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_Claimants] PRIMARY KEY CLUSTERED ([ClaimantId] ASC)
);










GO
CREATE NONCLUSTERED INDEX [IX_Claimants_LastName]
    ON [dbo].[Claimants]([LastName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Claimants_FirstName]
    ON [dbo].[Claimants]([FirstName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Claimants_DateOfBirth]
    ON [dbo].[Claimants]([DateOfBirth] DESC);

