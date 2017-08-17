CREATE TABLE [dbo].[UserUnavailabilities] (
    [Id]        INT                IDENTITY (1, 1) NOT NULL,
    [UserId]    INT                NOT NULL,
    [StartDate] DATETIMEOFFSET (7) NOT NULL,
    [EndDate]   DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_UserUnavailability] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserUnavailability_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);



