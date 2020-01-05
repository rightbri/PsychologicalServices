CREATE TABLE [dbo].[ConsultingAgreements] (
    [ConsultingAgreementId]  INT          IDENTITY (1, 1) NOT NULL,
    [CompanyId]              INT          NOT NULL,
    [PsychologistId]         INT          NOT NULL,
    [BillToReferralSourceId] INT          NOT NULL,
    [IsActive]               BIT          CONSTRAINT [DF_ConsultingAgreements_IsActive] DEFAULT ((0)) NOT NULL,
    [BillReferenceNumber]    VARCHAR (50) NULL,
    CONSTRAINT [PK_ConsultingAgreements] PRIMARY KEY CLUSTERED ([ConsultingAgreementId] ASC),
    CONSTRAINT [FK_ConsultingAgreements_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId]),
    CONSTRAINT [FK_ConsultingAgreements_ReferralSources] FOREIGN KEY ([BillToReferralSourceId]) REFERENCES [dbo].[ReferralSources] ([ReferralSourceId]),
    CONSTRAINT [FK_ConsultingAgreements_Users] FOREIGN KEY ([PsychologistId]) REFERENCES [dbo].[Users] ([UserId])
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [UK_ConsultingAgreements_CompanyId_PsychologistId_ReferralSourceId]
    ON [dbo].[ConsultingAgreements]([CompanyId] ASC, [PsychologistId] ASC, [BillToReferralSourceId] ASC);

