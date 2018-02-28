using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceValidator : IInvoiceValidator
    {
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly IAppointmentRepository _appointmentRepository = null;

        public InvoiceValidator(
            IInvoiceRepository invoiceRepository,
            IAppointmentRepository appointmentRepository
        )
        {
            _invoiceRepository = invoiceRepository;
            _appointmentRepository = appointmentRepository;
        }

        public IValidationResult Validate(Invoice item)
        {
            var result = new ValidationResult();

            if (item.Total < 0)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Total", Message = "Total must be greater than or equal to zero." }
                );
            }

            if (string.IsNullOrWhiteSpace(item.Identifier))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Identifier", Message = "Identifier must be specified" }
                );
            }

            if (item.TaxRate < 0)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "TaxRate", Message = "Tax Rate must be specified" }
                );
            }

            if (item.InvoiceType.InvoiceTypeId == InvoiceType.Psychologist && item.InvoiceStatus.InvoiceStatusId == InvoiceStatus.Submitted)
            {
                var lineGroup = item.LineGroups.Where(lg => null != lg.Appointment).FirstOrDefault();

                if (null != lineGroup)
                {
                    var appointment = _appointmentRepository.GetAppointmentForPsychologistInvoice(lineGroup.Appointment.AppointmentId);

                    if (appointment.PsychologistInvoiceLock)
                    {
                        result.ValidationErrors.Add(
                            new ValidationError { PropertyName = "", Message = "The invoice is locked and cannot be submitted." }
                        );
                    }
                }
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
