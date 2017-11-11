using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public string Identifier { get; set; }

        public DateTimeOffset InvoiceDate { get; set; }

        public InvoiceStatus InvoiceStatus { get; set; }

        public InvoiceType InvoiceType { get; set; }

        public User PayableTo { get; set; }

        public DateTimeOffset UpdateDate { get; set; }

        public decimal InvoiceRate { get; set; }

        public decimal TaxRate { get; set; }

        public int Total { get; set; }

        public IEnumerable<InvoiceAppointment> Appointments { get; set; }

        public IEnumerable<InvoiceStatusChange> StatusChanges { get; set; }

        public IEnumerable<InvoiceDocument> Documents { get; set; }

        public bool IsNew()
        {
            return InvoiceId == 0;
        }

        public int Subtotal
        {
            get
            {
                return null != Appointments
                    ? Appointments
                        .SelectMany(invoiceAppointment => invoiceAppointment.Lines)
                        .Select(line => line.Amount)
                        .Sum()
                    : 0;
            }
        }
    }
}
