CREATE TABLE [dbo].[RoleRights] (
    [RoleId]  INT NOT NULL,
    [RightId] INT NOT NULL,
    CONSTRAINT [PK_RoleRights] PRIMARY KEY CLUSTERED ([RoleId] ASC, [RightId] ASC),
    CONSTRAINT [FK_RoleRights_Rights] FOREIGN KEY ([RightId]) REFERENCES [dbo].[Rights] ([RightId]),
    CONSTRAINT [FK_RoleRights_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId])
);

