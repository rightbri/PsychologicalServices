CREATE TABLE [dbo].[Notes] (
    [NoteId]       INT                IDENTITY (1, 1) NOT NULL,
    [Note]         NVARCHAR (MAX)     NOT NULL,
    [UpdateUserId] INT                NOT NULL,
    [UpdateDate]   DATETIMEOFFSET (7) CONSTRAINT [DF_Notes_UpdateDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [CreateUserId] INT                NOT NULL,
    [CreateDate]   DATETIMEOFFSET (7) CONSTRAINT [DF_Notes_CreateDate] DEFAULT (sysutcdatetime()) NOT NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED ([NoteId] ASC),
    CONSTRAINT [FK_Notes_CreateUser] FOREIGN KEY ([CreateUserId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Notes_UpdateUser] FOREIGN KEY ([UpdateUserId]) REFERENCES [dbo].[Users] ([UserId])
);













