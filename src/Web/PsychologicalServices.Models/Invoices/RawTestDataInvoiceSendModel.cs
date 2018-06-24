using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class RawTestDataInvoiceSendModel : IInvoiceSendModel
    {
        private readonly List<string> _errors = new List<string>();

        public RawTestDataInvoiceSendModel(
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

            var hasArbitrationInvoice = null != invoice.InvoiceType && invoice.InvoiceType.InvoiceTypeId == InvoiceType.RawTestData;
            if (!hasArbitrationInvoice)
            {
                _errors.Add("The invoice is not a raw test data invoice");
                return;
            }

            var hasRawTestData = invoice.LineGroups.Any(lineGroup => null != lineGroup.RawTestData);
            if (!hasRawTestData)
            {
                _errors.Add("The invoice is not related to raw test data");
                return;
            }

            var rawTestData = hasRawTestData ? invoice.LineGroups.First(lineGroup => null != lineGroup.RawTestData).RawTestData : null;

            var hasInvoiceContactEmail = hasRawTestData && null != rawTestData.BillToReferralSource && !string.IsNullOrWhiteSpace(rawTestData.BillToReferralSource.InvoicesContactEmail);
            if (!hasInvoiceContactEmail)
            {
                _errors.Add("The bill-to referral source has no invoice contact email address");
                return;
            }

            Func<Claims.Claimant, bool> claimantPredicate = (c) =>
                    !string.IsNullOrWhiteSpace(c.FirstName) &&
                    !string.IsNullOrWhiteSpace(c.LastName);

            var hasClaimant = hasRawTestData &&
                null != rawTestData.Claimant &&
                claimantPredicate(rawTestData.Claimant);
            if (!hasClaimant)
            {
                _errors.Add("The raw test data has no claimant");
                return;
            }

            var claimant = rawTestData.Claimant;

            var hasPsychologistEmail = hasRawTestData && null != rawTestData.Psychologist && !string.IsNullOrWhiteSpace(rawTestData.Psychologist.Email);
            if (!hasPsychologistEmail)
            {
                _errors.Add("The psychologist has no email");
                return;
            }

            var hasCompanyEmail = hasPsychologistEmail && null != rawTestData.Company && !string.IsNullOrWhiteSpace(rawTestData.Company.Email);
            if (!hasCompanyEmail)
            {
                _errors.Add("The related raw test data has no company email");
                return;
            }
            
            //set model properties
            SenderEmail = rawTestData.Company.Email;
            RecipientEmail = rawTestData.BillToReferralSource.InvoicesContactEmail;
            CourtesyCopyEmail = rawTestData.Psychologist.Email;
            EmailSubject = "Invoice";
            EmailBody = $"Please see the attached invoice regarding the services for {claimant.FirstName} {claimant.LastName}.";
        }
    }
}
