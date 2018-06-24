CREATE TABLE [dbo].[RawTestDatas] (
    [RawTestDataId]                   INT                IDENTITY (1, 1) NOT NULL,
    [ClaimantId]                      INT                NULL,
    [BillToReferralSourceId]          INT                NULL,
    [RequestReceivedDate]             DATETIMEOFFSET (7) NULL,
    [SignedAuthorizationReceivedDate] DATETIMEOFFSET (7) NULL,
    [DataSentDate]                    DATETIMEOFFSET (7) NULL,
    [RawTestDataStatusId]             INT                NULL,
    [NoteId]                          INT                NULL,
    [CompanyId]                       INT                NOT NULL,
    [PsychologistId]                  INT                NULL,
    CONSTRAINT [PK_RawTestDatas] PRIMARY KEY CLUSTERED ([RawTestDataId] ASC),
    CONSTRAINT [FK_RawTestDatas_Claimants] FOREIGN KEY ([ClaimantId]) REFERENCES [dbo].[Claimants] ([ClaimantId]),
    CONSTRAINT [FK_RawTestDatas_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId]),
    CONSTRAINT [FK_RawTestDatas_Notes] FOREIGN KEY ([NoteId]) REFERENCES [dbo].[Notes] ([NoteId]),
    CONSTRAINT [FK_RawTestDatas_RawTestDataStatuses] FOREIGN KEY ([RawTestDataStatusId]) REFERENCES [dbo].[RawTestDataStatuses] ([RawTestDataStatusId]),
    CONSTRAINT [FK_RawTestDatas_ReferralSources] FOREIGN KEY ([BillToReferralSourceId]) REFERENCES [dbo].[ReferralSources] ([ReferralSourceId]),
    CONSTRAINT [FK_RawTestDatas_Users] FOREIGN KEY ([PsychologistId]) REFERENCES [dbo].[Users] ([UserId])
);

