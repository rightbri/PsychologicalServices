CREATE TABLE [dbo].[Events] (
    [EventId]     INT                IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (300)     NOT NULL,
    [Location]    NVARCHAR (300)     NULL,
    [Time]        NVARCHAR (100)     NULL,
    [Url]         NVARCHAR (1000)    NULL,
    [Expires]     DATETIMEOFFSET (7) NOT NULL,
    [IsActive]    BIT                CONSTRAINT [DF_Events_IsActive] DEFAULT ((1)) NOT NULL,
    [CompanyId]   INT                NOT NULL,
    CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED ([EventId] ASC),
    CONSTRAINT [FK_Events_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId])
);





