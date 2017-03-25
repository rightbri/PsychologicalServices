CREATE TABLE [dbo].[UserTravelFees] (
    [UserId] INT NOT NULL,
    [CityId] INT NOT NULL,
    [Amount] INT CONSTRAINT [DF_UserTravelFees_Amount] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UserTravelFees] PRIMARY KEY CLUSTERED ([UserId] ASC, [CityId] ASC),
    CONSTRAINT [FK_UserTravelFees_Cities] FOREIGN KEY ([CityId]) REFERENCES [dbo].[Cities] ([CityId]),
    CONSTRAINT [FK_UserTravelFees_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);



