using PsychologicalServices.Models.Consulting;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IConsultingInvoiceGenerator
    {
        Invoice CreateInvoice(ConsultingAgreement consultingAgreement, int year, int month);

        IEnumerable<InvoiceLineGroup> GetInvoiceLineGroups(Invoice invoice);

        int GetInvoiceTotal(Invoice invoice);
    }
}
