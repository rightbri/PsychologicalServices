using PsychologicalServices.Models.Common.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceSender : IInvoiceSender
    {
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly IMailService _mailService = null;

        public InvoiceSender(
            IInvoiceRepository invoiceRepository,
            IMailService mailService
        )
        {
            _invoiceRepository = invoiceRepository;
            _mailService = mailService;
        }

        public InvoiceSendResult SendInvoiceDocument(IInvoiceSendModel model)
        {
            var success = false;
            var errors = new List<InvoiceSendError>();
            IEnumerable<InvoiceDocumentSendLog> sendLogs = null;

            if (model.IsValid)
            {
                var message = new MailMessage(
                    model.SenderEmail,
                    model.RecipientEmail,
                    model.EmailSubject,
                    model.EmailBody
                );

                if (!string.IsNullOrWhiteSpace(model.CourtesyCopyEmail))
                {
                    message.CC.Add(model.CourtesyCopyEmail);
                }

                if (!string.IsNullOrWhiteSpace(model.ReplyToEmail))
                {
                    message.ReplyToList.Add(model.ReplyToEmail);
                }

                message.Attachments.Add(
                    new Attachment(new MemoryStream(model.InvoiceDocument.Content), model.InvoiceDocument.FileName)
                );

                var mailResult = _mailService.Send(message);

                if (!string.IsNullOrWhiteSpace(mailResult.ErrorDetails))
                {
                    errors.Add(
                        new InvoiceSendError(mailResult.ErrorDetails, InvoiceSendErrorType.InvoiceSendMailError)
                    );
                }

                success = mailResult.MailSent && !mailResult.IsError;

                if (success)
                {
                    var logId = _invoiceRepository.LogInvoiceDocumentSent(model.InvoiceDocument.InvoiceDocumentId, model.RecipientEmail);

                    sendLogs = _invoiceRepository.GetInvoiceDocumentSendLogs(model.InvoiceDocument.InvoiceDocumentId);
                }
            }
            else
            {
                errors.AddRange(
                    model.Errors.Select(error =>
                        new InvoiceSendError(error, InvoiceSendErrorType.InvoiceSendModelValidationError)
                    )
                );
            }

            return new InvoiceSendResult(success, errors, sendLogs);
        }
    }
}
