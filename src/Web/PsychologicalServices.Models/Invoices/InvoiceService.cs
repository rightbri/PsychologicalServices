﻿using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IAssessmentRepository _assessmentRepository = null;
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly IInvoiceValidator _invoiceValidator = null;
        private readonly IInvoiceGenerator _invoiceGenerator = null;
        private readonly IDate _date = null;

        public InvoiceService(
            IAssessmentRepository assessmentRepository,
            IInvoiceRepository invoiceRepository,
            IInvoiceValidator invoiceValidator,
            IInvoiceGenerator invoiceGenerator,
            IDate date
        )
        {
            _assessmentRepository = assessmentRepository;
            _invoiceRepository = invoiceRepository;
            _invoiceValidator = invoiceValidator;
            _invoiceGenerator = invoiceGenerator;
            _date = date;
        }
        
        public Invoice GetInvoice(int id)
        {
            var invoice = _invoiceRepository.GetInvoice(id);

            return invoice;
        }

        public Invoice NewInvoice(int assessmentId)
        {
            var assessment = _assessmentRepository.GetAssessment(assessmentId);

            var invoice = _invoiceGenerator.CreateInvoice(assessment);

            return invoice;
        }

        public IEnumerable<InvoiceStatus> GetInvoiceStatuses(bool? isActive = true)
        {
            var invoiceStatuses = _invoiceRepository.GetInvoiceStatuses(isActive);

            return invoiceStatuses;
        }

        public IEnumerable<Invoice> GetInvoices(InvoiceSearchCriteria criteria)
        {
            var invoices = _invoiceRepository.GetInvoices(criteria);

            return invoices;
        }

        public SaveResult<Invoice> SaveInvoice(Invoice invoice)
        {
            var result = new SaveResult<Invoice>();

            try
            {
                var validation = _invoiceValidator.Validate(invoice);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _invoiceRepository.SaveInvoice(invoice);

                    result.Item = _invoiceRepository.GetInvoice(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                //TODO: log error
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
