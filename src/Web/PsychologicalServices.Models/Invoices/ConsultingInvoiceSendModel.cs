using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class ConsultingInvoiceSendModel : IInvoiceSendModel
    {
        private readonly List<string> _errors = new List<string>();

        public ConsultingInvoiceSendModel(
            InvoiceDocument invoiceDocument,
            Invoice invoice
        )
        {
            Validate(invoiceDocument, invoice);
        }

        public bool IsValid
        {
            get { return !Errors.Any(); }
        }

        public IEnumerable<string> Errors
        {
            get { return _errors; }
        }

        public string SenderEmail { get; private set; }

        public string RecipientEmail { get; private set; }

        public string CourtesyCopyEmail { get; private set; }

        public string ReplyToEmail { get; private set; }

        public string EmailBody { get; private set; }

        public string EmailSubject { get; private set; }

        public InvoiceDocument InvoiceDocument { get; private set; }

        private void Validate(
            InvoiceDocument invoiceDocument,
            Invoice invoice
        )
        {
            InvoiceDocument = invoiceDocument ?? throw new ArgumentNullException("invoiceDocument");

            if (null == invoice)
            {
                throw new ArgumentNullException("invoice");
            }

            var hasConsultingInvoice = null != invoice.InvoiceType && invoice.InvoiceType.InvoiceTypeId == InvoiceType.Consulting;
            if (!hasConsultingInvoice)
            {
                _errors.Add("The invoice is not a consulting invoice");
                return;
            }

            var hasConsultingAgreement = invoice.LineGroups.Any(lineGroup => null != lineGroup.ConsultingAgreement);
            if (!hasConsultingAgreement)
            {
                _errors.Add("The invoice is not related to a consulting agreement");
                return;
            }

            var consultingAgreement = hasConsultingAgreement ? invoice.LineGroups.First(lineGroup => null != lineGroup.ConsultingAgreement).ConsultingAgreement : null;

            var hasInvoiceContactEmail = hasConsultingAgreement && null != consultingAgreement.BillToReferralSource && !string.IsNullOrWhiteSpace(consultingAgreement.BillToReferralSource.InvoicesContactEmail);
            if (!hasInvoiceContactEmail)
            {
                _errors.Add("The bill-to referral source has no invoice contact email address");
                return;
            }

            var hasPsychologistEmail = hasConsultingAgreement && null != consultingAgreement.Psychologist && !string.IsNullOrWhiteSpace(consultingAgreement.Psychologist.Email);
            if (!hasPsychologistEmail)
            {
                _errors.Add("The psychologist has no email");
                return;
            }

            var hasCompanyEmail = hasPsychologistEmail && null != consultingAgreement.Company && !string.IsNullOrWhiteSpace(consultingAgreement.Company.Email);
            if (!hasCompanyEmail)
            {
                _errors.Add("The related raw test data has no company email");
                return;
            }
            
            //set model properties
            SenderEmail = consultingAgreement.Company.Email;
            RecipientEmail = consultingAgreement.BillToReferralSource.InvoicesContactEmail;
            CourtesyCopyEmail = consultingAgreement.Psychologist.Email;
            ReplyToEmail = consultingAgreement.Company.ReplyToEmail;
            EmailSubject = $"Invoice {invoice.Identifier}";
            EmailBody = $"Please see the attached invoice regarding consulting services for {consultingAgreement.BillToReferralSource.Name}.";
        }
    }
}
