using PsychologicalServices.Data;
using PsychologicalServices.Data.DatabaseSpecific;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Invoices;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace PsychologicalServices.Infrastructure.Invoices
{
    public class InvoiceRepository : RepositoryBase, IInvoiceRepository
    {
        private readonly IDate _date = null;
        private readonly IInvoiceHtmlGenerator _invoiceHtmlGenerator = null;
        private readonly IHtmlToPdfService _htmlToPdfService = null;
        private readonly ICompanyRepository _companyRepository = null;

        public InvoiceRepository(
            IDataAccessAdapterFactory adapterFactory,
            IDate date,
            IInvoiceHtmlGenerator invoiceHtmlGenerator,
            IHtmlToPdfService htmlToPdfService,
            ICompanyRepository companyRepository
        ) : base(adapterFactory)
        {
            _date = date;
            _invoiceHtmlGenerator = invoiceHtmlGenerator;
            _htmlToPdfService = htmlToPdfService;
            _companyRepository = companyRepository;
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<InvoiceEntity>, IPathEdgeRootParser<InvoiceEntity>>
            InvoiceListPath =
                (invoicePath => invoicePath
                    .Prefetch<InvoiceStatusEntity>(invoice => invoice.InvoiceStatus)
                    .Prefetch<InvoiceTypeEntity>(invoice => invoice.InvoiceType)
                    .Prefetch<UserEntity>(invoice => invoice.PayableTo)
                    .Prefetch<InvoiceAppointmentEntity>(invoice => invoice.InvoiceAppointments)
                        .SubPath(invoiceAppointmentPath => invoiceAppointmentPath
                            .Prefetch<AppointmentEntity>(invoiceAppointment => invoiceAppointment.Appointment)
                                .SubPath(appointmentPath => appointmentPath
                                    .Prefetch<AssessmentEntity>(appointment => appointment.Assessment)
                                        .SubPath(assessmentPath => assessmentPath
                                            .Prefetch<ReferralSourceEntity>(assessment => assessment.ReferralSource)
                                            .Prefetch<AssessmentClaimEntity>(assessment => assessment.AssessmentClaims)
                                                .SubPath(assessmentClaimPath => assessmentClaimPath
                                                    .Prefetch<ClaimEntity>(assessmentClaim => assessmentClaim.Claim)
                                                        .SubPath(claimPath => claimPath
                                                            .Prefetch<ClaimantEntity>(claim => claim.Claimant)
                                                        )
                                                )
                                        )
                                )
                        )
                );

        private static readonly Func<IPathEdgeRootParser<InvoiceEntity>, IPathEdgeRootParser<InvoiceEntity>>
            InvoiceEditPath =
                (invoicePath => invoicePath
                    .Prefetch<InvoiceStatusEntity>(invoice => invoice.InvoiceStatus)
                        .SubPath(invoiceStatusPath => invoiceStatusPath
                            .Prefetch<InvoiceStatusPathsEntity>(invoiceStatus => invoiceStatus.InvoiceStatusPaths)
                                .SubPath(invoiceStatusPathsPath => invoiceStatusPathsPath
                                    .Prefetch<InvoiceStatusEntity>(invoiceStatusPaths => invoiceStatusPaths.NextInvoiceStatus)
                                )
                        )
                    .Prefetch<InvoiceTypeEntity>(invoice => invoice.InvoiceType)
                    .Prefetch<UserEntity>(invoice => invoice.PayableTo)
                    .Prefetch<InvoiceStatusChangeEntity>(invoice => invoice.InvoiceStatusChanges)
                        .SubPath(invoiceStatusChangePath => invoiceStatusChangePath
                            .Prefetch<InvoiceStatusEntity>(invoiceStatusChange => invoiceStatusChange.InvoiceStatus)
                        )
                    .Prefetch<InvoiceDocumentEntity>(invoice => invoice.InvoiceDocuments)
                        .Exclude(invoiceDocument => invoiceDocument.Document)
                    .Prefetch<InvoiceAppointmentEntity>(invoice => invoice.InvoiceAppointments)
                        .SubPath(invoiceAppointmentPath => invoiceAppointmentPath
                            .Prefetch<InvoiceLineEntity>(invoiceAppointment => invoiceAppointment.InvoiceLines)
                            .Prefetch<AppointmentEntity>(invoiceAppointment => invoiceAppointment.Appointment)
                                .SubPath(appointmentPath => appointmentPath
                                    .Prefetch<AppointmentStatusEntity>(appointment => appointment.AppointmentStatus)
                                        .SubPath(appointmentStatusPath => appointmentStatusPath
                                            .Prefetch<ReferralSourceAppointmentStatusSettingEntity>(appointmentStatus => appointmentStatus.ReferralSourceAppointmentStatusSettings)
                                                .SubPath(referralSourceAppointmentStatusSettingPath => referralSourceAppointmentStatusSettingPath
                                                    .Prefetch<InvoiceTypeEntity>(referralSourceAppointmentStatusSetting => referralSourceAppointmentStatusSetting.InvoiceType)
                                                    .Prefetch<ReferralSourceEntity>(referralSourceAppointmentStatusSetting => referralSourceAppointmentStatusSetting.ReferralSource)
                                                )
                                        )
                                    .Prefetch<UserEntity>(appointment => appointment.Psychologist)
                                        .SubPath(psychologistPath => psychologistPath
                                            .Prefetch<UserTravelFeeEntity>(psychologist => psychologist.UserTravelFees)
                                                .SubPath(userTravelFeePath => userTravelFeePath
                                                    .Prefetch<CityEntity>(userTravelFee => userTravelFee.City)
                                                )
                                        )
                                    .Prefetch<UserEntity>(appointment => appointment.Psychometrist)
                                        .SubPath(psychometristPath => psychometristPath
                                            .Prefetch<UserTravelFeeEntity>(psychometrist => psychometrist.UserTravelFees)
                                                .SubPath(userTravelFeePath => userTravelFeePath
                                                    .Prefetch<CityEntity>(userTravelFee => userTravelFee.City)
                                                )
                                        )
                                    .Prefetch<AddressEntity>(appointment => appointment.Location)
                                        .SubPath(locationPath => locationPath
                                            .Prefetch<CityEntity>(location => location.City)
                                        )
                                    .Prefetch<AssessmentEntity>(appointment => appointment.Assessment)
                                        .SubPath(assessmentPath => assessmentPath
                                            .Prefetch<AssessmentTypeEntity>(assessment => assessment.AssessmentType)
                                            .Prefetch<AssessmentReportEntity>(assessment => assessment.AssessmentReports)
                                                .SubPath(assessmentReportPath => assessmentReportPath
                                                    .Prefetch<ReportTypeEntity>(assessmentReport => assessmentReport.ReportType)
                                                    .Prefetch<AssessmentReportIssueInDisputeEntity>(assessmentReport => assessmentReport.AssessmentReportIssuesInDispute)
                                                        .SubPath(assessmentReportIssueInDisputePath => assessmentReportIssueInDisputePath
                                                            .Prefetch<IssueInDisputeEntity>(assessmentReportIssueInDispute => assessmentReportIssueInDispute.IssueInDispute)
                                                        )
                                                )
                                            .Prefetch<ReferralSourceEntity>(assessment => assessment.ReferralSource)
                                                .SubPath(referralSourcePath => referralSourcePath
                                                    .Prefetch<AddressEntity>(referralSource => referralSource.Address)
                                                        .SubPath(addressPath => addressPath
                                                            .Prefetch<CityEntity>(address => address.City)
                                                        )
                                                )
                                            .Prefetch<CompanyEntity>(assessment => assessment.Company)
                                                .SubPath(companyPath => companyPath
                                                    .Prefetch<AddressEntity>(company => company.Address)
                                                        .SubPath(addressPath => addressPath
                                                            .Prefetch<CityEntity>(address => address.City)
                                                        )
                                                )
                                            .Prefetch<AssessmentClaimEntity>(assessment => assessment.AssessmentClaims)
                                                .SubPath(assessmentClaimPath => assessmentClaimPath
                                                    .Prefetch<ClaimEntity>(assessmentClaim => assessmentClaim.Claim)
                                                        .SubPath(claimPath => claimPath
                                                            .Prefetch<ClaimantEntity>(claim => claim.Claimant)
                                                        )
                                                )
                                        )
                                )
                        )
                );

        #endregion

        public Invoice GetInvoice(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Invoice
                    .WithPath(InvoiceEditPath)
                    .Where(invoice => invoice.InvoiceId == id)
                    .SingleOrDefault()
                    .ToInvoice();
            }
        }

        public InvoiceStatus GetInvoiceStatus(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.InvoiceStatus
                    .Where(invoiceStatus => invoiceStatus.InvoiceStatusId == id)
                    .SingleOrDefault()
                    .ToInvoiceStatus();
            }
        }

        public InvoiceStatus GetInitialInvoiceStatus()
        {
            //TODO: don't hard-code value
            return GetInvoiceStatus(1);
        }

        public IEnumerable<InvoiceStatus> GetInvoiceStatuses(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<InvoiceStatusEntity>(
                    (ILLBLGenProQuery)
                        meta.InvoiceStatus
                        .Where(invoiceStatus => isActive == null || invoiceStatus.IsActive == isActive)
                    )
                    .Select(invoiceStatus => invoiceStatus.ToInvoiceStatus())
                    .ToList();
            }
        }

        public IEnumerable<Invoice> GetInvoices(InvoiceSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var invoices = meta.Invoice
                    .WithPath(InvoiceListPath);
                    
                if (null != criteria)
                {
                    invoices = invoices.Where(invoice => invoice.PayableTo.CompanyId == criteria.CompanyId);

                    if (criteria.AppointmentId.HasValue)
                    {
                        invoices = invoices
                            .Where(invoice => invoice.InvoiceAppointments
                                .Any(invoiceAppointment => invoiceAppointment.AppointmentId == criteria.AppointmentId.Value)
                            );
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.Identifier))
                    {
                        invoices = invoices.Where(invoice => invoice.Identifier.Contains(criteria.Identifier));
                    }

                    if (criteria.InvoiceDate.HasValue)
                    {
                        invoices = invoices.Where(invoice => invoice.InvoiceDate >= criteria.InvoiceDate.Value.Date && invoice.InvoiceDate < criteria.InvoiceDate.Value.Date.AddDays(1));
                    }

                    if (criteria.InvoiceMonth.HasValue)
                    {
                        var company = _companyRepository.GetCompany(criteria.CompanyId);
                        
                        if (null != company)
                        {
                            var monthStart = criteria.InvoiceMonth.Value.StartOfMonth(company.Timezone);

                            var monthEnd = monthStart.AddMonths(1);

                            invoices = invoices.Where(invoice => invoice.InvoiceDate >= monthStart && invoice.InvoiceDate < monthEnd);
                        }
                    }

                    if (criteria.InvoiceStatusId.HasValue)
                    {
                        invoices = invoices.Where(invoice => invoice.InvoiceStatusId == criteria.InvoiceStatusId);
                    }

                    if (criteria.InvoiceTypeId.HasValue)
                    {
                        invoices = invoices.Where(invoice => invoice.InvoiceTypeId == criteria.InvoiceTypeId);
                    }

                    if (criteria.PayableToId.HasValue)
                    {
                        invoices = invoices.Where(invoice => invoice.PayableToId == criteria.PayableToId);
                    }
                }

                return Execute<InvoiceEntity>(
                        (ILLBLGenProQuery)
                        invoices
                    )
                    .Select(invoice => invoice.ToInvoice())
                    .ToList();
            }
        }

        public IEnumerable<InvoiceDocument> GetInvoiceDocuments(int invoiceId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<InvoiceDocumentEntity>(
                    (ILLBLGenProQuery)
                        meta.InvoiceDocument
                        .ExcludeFields(invoiceDocument => invoiceDocument.Document)
                        .Where(invoiceDocument => invoiceDocument.InvoiceId == invoiceId)
                    )
                    .Select(invoiceDocument => invoiceDocument.ToInvoiceDocument())
                    .ToList();
            }
        }

        public int SaveInvoice(Invoice invoice)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var isNew = invoice.IsNew();

                var invoiceEntity = new InvoiceEntity
                {
                    IsNew = isNew,
                    InvoiceId = invoice.InvoiceId,
                };

                if (!isNew)
                {
                    var prefetch = new PrefetchPath2(EntityType.InvoiceEntity);

                    prefetch.Add(InvoiceEntity.PrefetchPathInvoiceStatus);

                    var payableToPath = prefetch.Add(InvoiceEntity.PrefetchPathPayableTo);

                    payableToPath
                        .SubPath.Add(UserEntity.PrefetchPathAddress)
                        .SubPath.Add(AddressEntity.PrefetchPathCity);

                    var invoiceAppointmentPath = prefetch.Add(InvoiceEntity.PrefetchPathInvoiceAppointments);

                    invoiceAppointmentPath
                        .SubPath.Add(InvoiceAppointmentEntity.PrefetchPathAppointment);

                    invoiceAppointmentPath
                        .SubPath.Add(InvoiceAppointmentEntity.PrefetchPathInvoiceLines);

                    adapter.FetchEntity(invoiceEntity, prefetch);
                }
                else
                {
                    invoiceEntity.InvoiceStatus = invoice.InvoiceStatus.ToInvoiceStatusEntity();
                }

                //determine whether we're changing to a status that requires an invoice document to be saved
                var saveDocument = 
                    !invoiceEntity.InvoiceStatus.SaveDocument &&
                    invoice.InvoiceStatus.SaveDocument;
                
                invoiceEntity.Identifier = invoice.Identifier;
                invoiceEntity.InvoiceDate = invoice.InvoiceDate;
                invoiceEntity.InvoiceStatusId = invoice.InvoiceStatus.InvoiceStatusId;
                invoiceEntity.InvoiceTypeId = invoice.InvoiceType.InvoiceTypeId;
                invoiceEntity.PayableToId = invoice.PayableTo.UserId;
                invoiceEntity.UpdateDate = _date.UtcNow;
                invoiceEntity.TaxRate = invoice.TaxRate;
                invoiceEntity.Total = invoice.Total;

                #region appointments

                var appointmentsToAdd = invoice.Appointments
                    .Where(ia => 
                        !invoiceEntity.InvoiceAppointments.Any(invoiceAppointment => 
                            invoiceAppointment.AppointmentId == ia.Appointment.AppointmentId
                        )
                    )
                    .ToList();

                if (!isNew)
                {
                    var appointmentsToRemove = invoiceEntity.InvoiceAppointments
                        .Where(invoiceAppointment =>
                            !invoice.Appointments.Any(ia =>
                                ia.Appointment.AppointmentId == invoiceAppointment.AppointmentId
                            )
                        )
                        .ToList();

                    foreach (var appointment in appointmentsToRemove)
                    {
                        uow.AddCollectionForDelete(appointment.InvoiceLines);

                        uow.AddForDelete(appointment);
                    }

                    var appointmentsToUpdate = invoice.Appointments
                        .Where(ia => invoiceEntity.InvoiceAppointments.Any(invoiceAppointment =>
                                invoiceAppointment.AppointmentId == ia.Appointment.AppointmentId &&
                                (
                                    //new lines
                                    ia.Lines.Any(line => !invoiceAppointment.InvoiceLines.Any(invoiceLine => invoiceLine.InvoiceLineId == line.InvoiceLineId)) ||
                                    invoiceAppointment.InvoiceLines.Any(invoiceLine =>
                                        //deleted lines
                                        !ia.Lines.Any(line => line.InvoiceLineId == invoiceLine.InvoiceLineId) ||
                                        //updated lines
                                        ia.Lines.Any(line => line.InvoiceLineId == invoiceLine.InvoiceLineId &&
                                            (
                                            line.Description != invoiceLine.Description ||
                                            line.Amount != invoiceLine.Amount
                                            )
                                        )
                                    )
                                )
                            )
                        )
                        .ToList();

                    foreach (var ia in appointmentsToUpdate)
                    {
                        var invoiceAppointmentEntity = invoiceEntity.InvoiceAppointments.SingleOrDefault(invoiceAppointment => invoiceAppointment.InvoiceAppointmentId == ia.InvoiceAppointmentId);
                        if (null != invoiceAppointmentEntity)
                        {
                            #region invoice lines

                            var linesToAdd = ia.Lines
                                .Where(line =>
                                    !invoiceAppointmentEntity.InvoiceLines.Any(invoiceLine =>
                                        invoiceLine.InvoiceLineId == line.InvoiceLineId
                                    )
                                )
                                .ToList();

                            if (!isNew)
                            {
                                var linesToRemove = invoiceAppointmentEntity.InvoiceLines
                                    .Where(invoiceLine =>
                                        !ia.Lines.Any(line => line.InvoiceLineId == invoiceLine.InvoiceLineId)
                                    );

                                foreach (var line in linesToRemove)
                                {
                                    uow.AddForDelete(line);
                                }

                                var linesToUpdate = ia.Lines
                                    .Where(line =>
                                        invoiceAppointmentEntity.InvoiceLines.Any(invoiceLine =>
                                            invoiceLine.InvoiceLineId == line.InvoiceLineId &&
                                            (
                                                invoiceLine.Amount != line.Amount ||
                                                invoiceLine.Description != line.Description
                                            )
                                        )
                                    );

                                foreach (var line in linesToUpdate)
                                {
                                    var lineEntity = invoiceAppointmentEntity.InvoiceLines.SingleOrDefault(invoiceLine => invoiceLine.InvoiceLineId == line.InvoiceLineId);
                                    if (null != lineEntity)
                                    {
                                        lineEntity.Amount = line.Amount;
                                        lineEntity.Description = line.Description;
                                    }
                                }
                            }

                            invoiceAppointmentEntity.InvoiceLines.AddRange(
                                linesToAdd.Select(line => new InvoiceLineEntity
                                {
                                    Amount = line.Amount,
                                    Description = line.Description,
                                    IsCustom = line.IsCustom,
                                })
                            );

                            #endregion
                        }
                    }
                }

                //new invoice appointments
                foreach (var ia in appointmentsToAdd)
                {
                    var invoiceAppointment = new InvoiceAppointmentEntity
                    {
                        AppointmentId = ia.Appointment.AppointmentId,
                    };

                    invoiceAppointment.InvoiceLines.AddRange(
                        ia.Lines.Select(line => new InvoiceLineEntity
                        {
                            Amount = line.Amount,
                            Description = line.Description,
                            IsCustom = line.IsCustom,
                        })
                    );

                    invoiceEntity.InvoiceAppointments.Add(invoiceAppointment);
                }
                
                #endregion

                if (saveDocument)
                {
                    //generate and store pdf
                    var html = _invoiceHtmlGenerator.GetInvoiceHtml(invoice);

                    var pdf = _htmlToPdfService.GetPdf(html);

                    invoiceEntity.InvoiceDocuments.Add(
                        new InvoiceDocumentEntity
                        {
                            FileName = string.Format("{0}_{1:yyyyMMddhhmmss}.pdf", invoice.Identifier, _date.UtcNow),
                            Document = pdf,
                        }
                    );
                }

                uow.AddForSave(invoiceEntity);

                uow.Commit(adapter);

                return invoiceEntity.InvoiceId;
            }
        }

        public int GetInvoiceCount(int year, int month)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var startDate = new DateTime(year, month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                return meta.Invoice
                    .Where(invoice => invoice.InvoiceDate >= startDate && invoice.InvoiceDate <= endDate)
                    .Count();
            }
        }

        public int GetInvoiceCount(int userId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Invoice
                    .Where(invoice => invoice.PayableToId == userId)
                    .Count();
            }
        }

        public decimal GetTaxRate()
        {
            return 0.13m;   //TODO: retrieve from DB
        }

        public int GetAdditionalReportAmount(int referralSourceId, int reportTypeId)
        {
            return 50000;
        }

        public InvoiceDocument GetInvoiceDocument(int invoiceDocumentId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.InvoiceDocument
                    .Where(invoiceDocument => invoiceDocument.InvoiceDocumentId == invoiceDocumentId)
                    .SingleOrDefault()
                    .ToInvoiceDocument();
            }
        }

        public InvoiceType GetInvoiceType(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.InvoiceType
                    .Where(invoiceType => invoiceType.InvoiceTypeId == id)
                    .SingleOrDefault()
                    .ToInvoiceType();
            }
        }

        public IEnumerable<InvoiceType> GetInvoiceTypes(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<InvoiceTypeEntity>(
                    (ILLBLGenProQuery)
                    meta.InvoiceType
                    .Where(invoiceType => isActive == null || invoiceType.IsActive == isActive)
                )
                .Select(invoiceType => invoiceType.ToInvoiceType())
                .ToList();
            }
        }

        public PsychometristInvoiceAmount GetPsychometristInvoiceAmount(int assessmentTypeId, int appointmentStatusId, int appointmentSequenceId, int companyId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.PsychometristInvoiceAmount
                    .Where(psychometristInvoiceAmount =>
                        psychometristInvoiceAmount.AssessmentTypeId == assessmentTypeId &&
                        psychometristInvoiceAmount.AppointmentStatusId == appointmentStatusId &&
                        psychometristInvoiceAmount.AppointmentSequenceId == appointmentSequenceId &&
                        psychometristInvoiceAmount.CompanyId == companyId
                    )
                    .SingleOrDefault()
                    .ToPsychometristInvoiceAmount();
            }
        }

        public IEnumerable<InvoiceableAppointmentData> GetInvoiceableAppointmentData(InvoiceableAppointmentDataSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var table = RetrievalProcedures.InvoiceableAppointmentData(criteria.CompanyId, criteria.InvoiceTypeId, criteria.StartSearch, (DataAccessAdapter)adapter);

                return table
                    .AsEnumerable()
                    .Select(row =>
                        new InvoiceableAppointmentData
                        {
                            Year = Convert.ToInt32(row["Year"]),
                            Month = Convert.ToInt32(row["Month"]),
                            AssessmentId = Convert.ToInt32(row["AssessmentId"]),
                            AppointmentId = Convert.ToInt32(row["AppointmentId"]),
                            AppointmentTime = (DateTimeOffset)row["AppointmentTime"],
                            AppointmentStatus = Convert.ToString(row["AppointmentStatus"]),
                            PayableTo = Convert.ToString(row["PayableTo"]),
                            PayableToId = Convert.ToInt32(row["PayableToId"]),
                            InvoiceTypeId = Convert.ToInt32(row["InvoiceTypeId"]),
                            AssessmentType = Convert.ToString(row["AssessmentType"]),
                            ReferralSource = Convert.ToString(row["ReferralSource"]),
                            Claimant = Convert.ToString(row["Claimant"]),
                        })
                    .ToList();
            }
        }
    }
}
