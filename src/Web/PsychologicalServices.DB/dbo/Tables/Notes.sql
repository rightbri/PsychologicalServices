CREATE TABLE [dbo].[Notes] (
    [NoteId]       INT            IDENTITY (1, 1) NOT NULL,
    [Note]         VARCHAR (1000) NOT NULL,
    [UpdateUserId] INT            NOT NULL,
    [UpdateDate]   DATETIME       CONSTRAINT [DF_Notes_UpdateDate] DEFAULT (getdate()) NOT NULL,
    [CreateUserId] INT            NOT NULL,
    [CreateDate]   DATETIME       CONSTRAINT [DF_Notes_CreateDate] DEFAULT (getdate()) NOT NULL,
    [Deleted]      BIT            CONSTRAINT [DF_Notes_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED ([NoteId] ASC),
    CONSTRAINT [FK_Notes_Users] FOREIGN KEY ([CreateUserId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Notes_Users1] FOREIGN KEY ([UpdateUserId]) REFERENCES [dbo].[Users] ([UserId])
);

