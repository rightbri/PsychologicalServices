using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class ArbitrationInvoiceSendModel : IInvoiceSendModel
    {
        private readonly List<string> _errors = new List<string>();

        public ArbitrationInvoiceSendModel(
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

            var hasArbitrationInvoice = null != invoice.InvoiceType && invoice.InvoiceType.InvoiceTypeId == InvoiceType.Arbitration;
            if (!hasArbitrationInvoice)
            {
                _errors.Add("The invoice is not an arbitration invoice");
                return;
            }

            var hasArbitration = invoice.LineGroups.Any(lineGroup => null != lineGroup.Arbitration);
            if (!hasArbitration)
            {
                _errors.Add("The invoice is not related to an arbitration");
                return;
            }

            var arbitration = hasArbitration ? invoice.LineGroups.First(lineGroup => null != lineGroup.Arbitration).Arbitration : null;

            var hasInvoiceContactEmail = hasArbitration && null != arbitration.BillToContact && !string.IsNullOrWhiteSpace(arbitration.BillToContact.Email);
            if (!hasInvoiceContactEmail)
            {
                _errors.Add("The bill-to contact has no email address");
                return;
            }

            Func<Claims.Claimant, bool> claimantPredicate = (c) =>
                    !string.IsNullOrWhiteSpace(c.FirstName) &&
                    !string.IsNullOrWhiteSpace(c.LastName);

            var hasClaimant = hasArbitration &&
                null != arbitration.Claimant &&
                claimantPredicate(arbitration.Claimant);
            if (!hasClaimant)
            {
                _errors.Add("The arbitration has no claimant");
                return;
            }

            var claimant = arbitration.Claimant;

            var hasPsychologistEmail = hasArbitration && null != arbitration.Psychologist && !string.IsNullOrWhiteSpace(arbitration.Psychologist.Email);
            if (!hasPsychologistEmail)
            {
                _errors.Add("The psychologist has no email");
                return;
            }

            var hasCompanyEmail = hasPsychologistEmail && null != arbitration.Psychologist.Company && !string.IsNullOrWhiteSpace(arbitration.Psychologist.Company.Email);
            if (!hasCompanyEmail)
            {
                _errors.Add("The related arbitration has no company email");
                return;
            }
            
            //set model properties
            SenderEmail = arbitration.Psychologist.Company.Email;
            RecipientEmail = arbitration.BillToContact.Email;
            CourtesyCopyEmail = arbitration.Psychologist.Email;
            ReplyToEmail = arbitration.Psychologist.Company.ReplyToEmail;
            EmailSubject = $"Invoice {invoice.Identifier}";
            EmailBody = $"Please see the attached invoice regarding the services for {claimant.FirstName} {claimant.LastName}.";
        }
    }
}
