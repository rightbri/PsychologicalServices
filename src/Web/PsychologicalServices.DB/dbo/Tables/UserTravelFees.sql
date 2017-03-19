CREATE TABLE [dbo].[UserTravelFees] (
    [UserId]     INT NOT NULL,
    [LocationId] INT NOT NULL,
    [Amount]     INT CONSTRAINT [DF_UserTravelFees_Amount] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UserTravelFees] PRIMARY KEY CLUSTERED ([UserId] ASC, [LocationId] ASC),
    CONSTRAINT [FK_UserTravelFees_Addresses] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Addresses] ([AddressId]),
    CONSTRAINT [FK_UserTravelFees_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

