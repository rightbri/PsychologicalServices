using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class PsychometristInvoiceSendModel : IInvoiceSendModel
    {
        private readonly List<string> _errors = new List<string>();

        public PsychometristInvoiceSendModel(
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

            var hasPsychometristInvoice = null != invoice.InvoiceType && invoice.InvoiceType.InvoiceTypeId == InvoiceType.Psychometrist;
            if (!hasPsychometristInvoice)
            {
                _errors.Add("The invoice is not a psychometrist invoice");
                return;
            }

            var psychometrist = invoice.PayableTo;

            if (string.IsNullOrWhiteSpace(psychometrist.Email))
            {
                _errors.Add("The psychometrist has no email");
                return;
            }

            var hasCompanyEmail = !string.IsNullOrWhiteSpace(psychometrist.Company.Email);
            if (!hasCompanyEmail)
            {
                _errors.Add("The company has no email");
                return;
            }

            //set model properties
            SenderEmail = psychometrist.Company.Email;
            RecipientEmail = psychometrist.Email;
            CourtesyCopyEmail = psychometrist.Company.AccountingEmail;
            ReplyToEmail = psychometrist.Company.ReplyToEmail;
            EmailSubject = $"Timesheet for period {invoice.InvoicePeriodBegin:dd-MM-yyyy} to {invoice.InvoicePeriodEnd:dd-MM-yyyy}";
            EmailBody = $"Please find the attached timesheet generated based on assessments from {invoice.InvoicePeriodBegin:dd-MM-yyyy} to {invoice.InvoicePeriodEnd:dd-MM-yyyy}. If there are any errors please advise within 24 hours.";
        }
    }
}
