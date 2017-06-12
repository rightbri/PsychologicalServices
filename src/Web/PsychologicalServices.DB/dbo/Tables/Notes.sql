CREATE TABLE [dbo].[Notes] (
    [NoteId]       INT            IDENTITY (1, 1) NOT NULL,
    [Note]         NVARCHAR (MAX) NOT NULL,
    [UpdateUserId] INT            NOT NULL,
    [UpdateDate]   DATETIME       CONSTRAINT [DF_Notes_UpdateDate] DEFAULT (getdate()) NOT NULL,
    [CreateUserId] INT            NOT NULL,
    [CreateDate]   DATETIME       CONSTRAINT [DF_Notes_CreateDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED ([NoteId] ASC),
    CONSTRAINT [FK_Notes_CreateUser] FOREIGN KEY ([CreateUserId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Notes_UpdateUser] FOREIGN KEY ([UpdateUserId]) REFERENCES [dbo].[Users] ([UserId])
);









