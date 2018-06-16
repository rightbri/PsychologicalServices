
namespace PsychologicalServices.Models.Invoices
{
    public enum InvoiceSendErrorType
    {
        InvoiceNotFound = 1,
        InvoiceTypeCannotBeSent,
        InvoiceDocumentNotFound,
        InvoiceSendModelNotImplemented,
        InvoiceSendModelValidationError,
        InvoiceSendMailError,
        Other
    }
}