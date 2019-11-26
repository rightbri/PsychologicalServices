CREATE TABLE [dbo].[InvoiceLineGroupConsultingAgreements] (
    [InvoiceLineGroupId]    INT NOT NULL,
    [ConsultingAgreementId] INT NOT NULL,
    CONSTRAINT [PK_InvoiceLineGroupConsultingAgreements] PRIMARY KEY CLUSTERED ([InvoiceLineGroupId] ASC),
    CONSTRAINT [FK_InvoiceLineGroupConsultingAgreements_ConsultingAgreements] FOREIGN KEY ([ConsultingAgreementId]) REFERENCES [dbo].[ConsultingAgreements] ([ConsultingAgreementId]),
    CONSTRAINT [FK_InvoiceLineGroupConsultingAgreements_InvoiceLineGroups] FOREIGN KEY ([InvoiceLineGroupId]) REFERENCES [dbo].[InvoiceLineGroups] ([InvoiceLineGroupId])
);

