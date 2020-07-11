CREATE TABLE [dbo].[PhoneLogs] (
    [PhoneLogId]        INT                IDENTITY (1, 1) NOT NULL,
    [CallTime]          DATETIMEOFFSET (7) NOT NULL,
    [CompanyName]       NVARCHAR (100)     NULL,
    [CallerName]        NVARCHAR (100)     NULL,
    [ClaimantFirstName] NVARCHAR (50)      NULL,
    [ClaimantLastName]  NVARCHAR (50)      NULL,
    [NoteId]            INT                NOT NULL,
    [CreateDate]        DATETIMEOFFSET (7) CONSTRAINT [DF_PhoneLogs_CreateDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [CreateUserId]      INT                NOT NULL,
    [UpdateDate]        DATETIMEOFFSET (7) CONSTRAINT [DF_PhoneLogs_UpdateDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [UpdateUserId]      INT                NOT NULL,
    CONSTRAINT [PK_PhoneLogs] PRIMARY KEY CLUSTERED ([PhoneLogId] ASC),
    CONSTRAINT [FK_PhoneLogs_CreateUser] FOREIGN KEY ([CreateUserId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_PhoneLogs_Notes] FOREIGN KEY ([NoteId]) REFERENCES [dbo].[Notes] ([NoteId]),
    CONSTRAINT [FK_PhoneLogs_UpdateUser] FOREIGN KEY ([UpdateUserId]) REFERENCES [dbo].[Users] ([UserId])
);

