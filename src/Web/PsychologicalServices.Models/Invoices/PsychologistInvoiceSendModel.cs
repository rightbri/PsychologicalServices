using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class PsychologistInvoiceSendModel : IInvoiceSendModel
    {
        private readonly List<string> _errors = new List<string>();

        public PsychologistInvoiceSendModel(
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

            var hasPsychologistInvoice = null != invoice.InvoiceType && invoice.InvoiceType.InvoiceTypeId == InvoiceType.Psychologist;
            if (!hasPsychologistInvoice)
            {
                _errors.Add("The invoice is not a psychologist invoice");
                return;
            }

            var hasAppointment = null != invoice.LineGroups && invoice.LineGroups.Any(lineGroup => null != lineGroup.Appointment);
            if (!hasAppointment)
            {
                _errors.Add("The invoice has no appointment");
                return;
            }

            var appointment = hasAppointment ? invoice.LineGroups.First(lineGroup => null != lineGroup.Appointment).Appointment : null;

            var assessment = hasAppointment ? appointment.Assessment : null;

            var hasAssessment = null != assessment;

            var hasInvoiceContactEmail = hasAssessment && null != assessment.ReferralSource && !string.IsNullOrWhiteSpace(assessment.ReferralSource.InvoicesContactEmail);
            if (!hasInvoiceContactEmail)
            {
                _errors.Add("The referral source has no invoice contact email address");
                return;
            }

            Func<Claims.Claim, bool> claimWithClaimantPredicate = (claim) => null != claim.Claimant &&
                    !string.IsNullOrWhiteSpace(claim.Claimant.FirstName) &&
                    !string.IsNullOrWhiteSpace(claim.Claimant.LastName);

            var hasClaimant = hasAssessment &&
                null != assessment.Claims &&
                assessment.Claims.Any(claimWithClaimantPredicate);
            if (!hasClaimant)
            {
                _errors.Add("The related assessment has no claimant");
                return;
            }

            var claimant = assessment.Claims.First(claimWithClaimantPredicate).Claimant;

            var hasCompanyEmail = !string.IsNullOrWhiteSpace(assessment.Company.Email);
            if (!hasCompanyEmail)
            {
                _errors.Add("The related assessment has no company email");
                return;
            }

            var hasPsychologistEmail = hasAppointment && null != appointment.Psychologist && !string.IsNullOrWhiteSpace(appointment.Psychologist.Email);
            if (!hasPsychologistEmail)
            {
                _errors.Add("The psychologist has no email");
                return;
            }

            //set model properties
            SenderEmail = assessment.Company.Email;
            RecipientEmail = assessment.ReferralSource.InvoicesContactEmail;
            CourtesyCopyEmail = appointment.Psychologist.Email;
            ReplyToEmail = assessment.Company.ReplyToEmail;
            EmailSubject = $"Invoice {invoice.Identifier}";
            EmailBody = $"Please see the attached invoice regarding the services for {claimant.FirstName} {claimant.LastName}.";
        }
    }
}
