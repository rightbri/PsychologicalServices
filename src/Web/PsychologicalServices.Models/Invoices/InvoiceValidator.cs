using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Arbitrations;
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
        private readonly IArbitrationRepository _arbitrationRepository = null;

        public InvoiceValidator(
            IInvoiceRepository invoiceRepository,
            IAppointmentRepository appointmentRepository,
            IArbitrationRepository arbitrationRepository
        )
        {
            _invoiceRepository = invoiceRepository;
            _appointmentRepository = appointmentRepository;
            _arbitrationRepository = arbitrationRepository;
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
            else if (item.InvoiceType.InvoiceTypeId == InvoiceType.Arbitration && item.InvoiceStatus.InvoiceStatusId == InvoiceStatus.Submitted)
            {
                var lineGroup = item.LineGroups.Where(lg => null != lg.Arbitration).FirstOrDefault();

                if (null != lineGroup)
                {
                    var arbitration = _arbitrationRepository.GetArbitration(lineGroup.Arbitration.ArbitrationId);

                    if (null == arbitration.BillToContact)
                    {
                        result.ValidationErrors.Add(
                            new ValidationError { PropertyName = "", Message = "The arbitration has no 'Bill To' contact and cannot be submitted." }
                        );
                    }
                }
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
