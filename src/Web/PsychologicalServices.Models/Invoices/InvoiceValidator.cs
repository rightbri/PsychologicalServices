using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceValidator : IInvoiceValidator
    {
        private readonly IInvoiceRepository _invoiceRepository = null;

        public InvoiceValidator(
            IInvoiceRepository invoiceRepository
        )
        {
            _invoiceRepository = invoiceRepository;
        }

        public IValidationResult Validate(Invoice item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (item.ModifiedTotal.HasValue)
            {
                if (item.ModifiedTotal.Value < 0)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "ModifiedTotal", Message = "Modified Total must be greater than or equal to zero." }
                    );
                }
            }

            if (item.Total.HasValue)
            {
                if (item.Total.Value < 0)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "Total", Message = "Total must be greater than or equal to zero." }
                    );
                }
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

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
