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
        private readonly IInvoiceDocumentFileNameGenerator _invoiceDocumentFileNameGenerator = null;

        public InvoiceRepository(
            IDataAccessAdapterFactory adapterFactory,
            IDate date,
            IInvoiceHtmlGenerator invoiceHtmlGenerator,
            IHtmlToPdfService htmlToPdfService,
            ICompanyRepository companyRepository,
            IInvoiceDocumentFileNameGenerator invoiceDocumentFileNameGenerator
        ) : base(adapterFactory)
        {
            _date = date;
            _invoiceHtmlGenerator = invoiceHtmlGenerator;
            _htmlToPdfService = htmlToPdfService;
            _companyRepository = companyRepository;
            _invoiceDocumentFileNameGenerator = invoiceDocumentFileNameGenerator;
        }

        #region Prefetch Paths

        private Func<IPathEdgeRootParser<CompanyEntity>, IPathEdgeRootParser<CompanyEntity>> GetInvoiceCalculationDataPrefetchPath(
            int companyId,
            int referralSourceId,
            int assessmentTypeId,
            int appointmentStatusId,
            int appointmentSequenceId
        )
        {
            return (cPath => cPath
                .Prefetch<AppointmentStatusInvoiceRateEntity>(company => company.AppointmentStatusInvoiceRates)
                    .FilterOn(appointmentStatusInvoiceRate =>
                        appointmentStatusInvoiceRate.ReferralSourceId == referralSourceId &&
                        appointmentStatusInvoiceRate.AppointmentStatusId == appointmentStatusId &&
                        appointmentStatusInvoiceRate.AppointmentSequenceId == appointmentSequenceId
                    )
                .Prefetch<AssessmentTypeInvoiceAmountEntity>(company => company.AssessmentTypeInvoiceAmounts)
                    .FilterOn(assessmentTypeInvoiceAmount =>
                        assessmentTypeInvoiceAmount.ReferralSourceId == referralSourceId &&
                        assessmentTypeInvoiceAmount.AssessmentTypeId == assessmentTypeId
                    )
                .Prefetch<ReferralSourceInvoiceConfigurationEntity>(company => company.ReferralSourceInvoiceConfigurations)
                    .FilterOn(referralSourceInvoiceConfiguration =>
                        referralSourceInvoiceConfiguration.ReferralSourceId == referralSourceId
                    )
                .Prefetch<IssueInDisputeInvoiceAmountEntity>(company => company.IssueInDisputeInvoiceAmounts)
                    .SubPath(issueInDisputeInvoiceAmountPath => issueInDisputeInvoiceAmountPath
                        .Prefetch<IssueInDisputeEntity>(issueInDisputeInvoiceAmount => issueInDisputeInvoiceAmount.IssueInDispute)
                    )
            );
        }

        private static readonly Func<IPathEdgeRootParser<InvoiceEntity>, IPathEdgeRootParser<InvoiceEntity>>
            InvoiceSendPath =
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
                                            .Prefetch<CompanyEntity>(assessment => assessment.Company)
                                        )
                                    .Prefetch<UserEntity>(appointment => appointment.Psychologist)
                                )
                        )
                );

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
                                            .Prefetch<CompanyEntity>(assessment => assessment.Company)
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
                        //.SubPath(payableToPath => payableToPath
                        //    .Prefetch<CompanyEntity>(payableTo => payableTo.Company)
                        //)
                    .Prefetch<InvoiceStatusChangeEntity>(invoice => invoice.InvoiceStatusChanges)
                        .SubPath(invoiceStatusChangePath => invoiceStatusChangePath
                            .Prefetch<InvoiceStatusEntity>(invoiceStatusChange => invoiceStatusChange.InvoiceStatus)
                        )
                    .Prefetch<InvoiceDocumentEntity>(invoice => invoice.InvoiceDocuments)
                        .Exclude(invoiceDocument => invoiceDocument.Document)
                        .SubPath(invoiceDocumentPath => invoiceDocumentPath
                            .Prefetch<InvoiceDocumentSendLogEntity>(invoiceDocument => invoiceDocument.InvoiceDocumentSendLogs)
                        )
                    .Prefetch<InvoiceAppointmentEntity>(invoice => invoice.InvoiceAppointments)
                        .SubPath(invoiceAppointmentPath => invoiceAppointmentPath
                            .Prefetch<InvoiceLineEntity>(invoiceAppointment => invoiceAppointment.InvoiceLines)
                            .Prefetch<AppointmentEntity>(invoiceAppointment => invoiceAppointment.Appointment)
                                .SubPath(appointmentPath => appointmentPath
                                    .Prefetch<AppointmentStatusEntity>(appointment => appointment.AppointmentStatus)
                                        //.SubPath(appointmentStatusPath => appointmentStatusPath
                                        //    .Prefetch<ReferralSourceAppointmentStatusSettingEntity>(appointmentStatus => appointmentStatus.ReferralSourceAppointmentStatusSettings)
                                        //        .SubPath(referralSourceAppointmentStatusSettingPath => referralSourceAppointmentStatusSettingPath
                                        //            .Prefetch<InvoiceTypeEntity>(referralSourceAppointmentStatusSetting => referralSourceAppointmentStatusSetting.InvoiceType)
                                        //            .Prefetch<ReferralSourceEntity>(referralSourceAppointmentStatusSetting => referralSourceAppointmentStatusSetting.ReferralSource)
                                        //        )
                                        //)
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
                                            .Prefetch<AppointmentEntity>(assessment => assessment.Appointments)
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

        public PsychologistInvoiceCalculationData GetPsychologistInvoiceCalculationData(
            int companyId,
            int referralSourceId,
            int assessmentTypeId,
            int appointmentStatusId,
            int appointmentSequenceId
        )
        {
            var prefetchPath = GetInvoiceCalculationDataPrefetchPath(companyId, referralSourceId, assessmentTypeId, appointmentStatusId, appointmentSequenceId);
            
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var companyEntity = meta.Company
                    .WithPath(prefetchPath)
                    .Where(company => company.CompanyId == companyId)
                    .SingleOrDefault();
                
                var result = new PsychologistInvoiceCalculationData
                {
                    Company = companyEntity.ToCompany(),
                    IssueInDisputeInvoiceAmounts = companyEntity.IssueInDisputeInvoiceAmounts.Select(issueInDisputeInvoiceAmount => issueInDisputeInvoiceAmount.ToIssueInDisputeInvoiceAmount()),
                };

                if (companyEntity.AppointmentStatusInvoiceRates.Any())
                {
                    var appointmentStatusInvoiceRate = companyEntity.AppointmentStatusInvoiceRates.FirstOrDefault();

                    if (null != appointmentStatusInvoiceRate)
                    {
                        result.InvoiceRate = appointmentStatusInvoiceRate.InvoiceRate;
                        result.ApplyCompletionFee = appointmentStatusInvoiceRate.ApplyCompletionFee;
                        result.ApplyExtraReportFees = appointmentStatusInvoiceRate.ApplyExtraReportFees;
                        result.ApplyIssueInDisputeFees = appointmentStatusInvoiceRate.ApplyIssueInDisputeFees;
                        result.ApplyLargeFileFee = appointmentStatusInvoiceRate.ApplyLargeFileFee;
                        result.ApplyTravelFee = appointmentStatusInvoiceRate.ApplyTravelFee;
                    }
                    else
                    {
                        result.MissingAppointmentStatusInvoiceData = true;
                    }
                }

                if (companyEntity.AssessmentTypeInvoiceAmounts.Any())
                {
                    var assessmentTypeInvoiceAmount = companyEntity.AssessmentTypeInvoiceAmounts.First();

                    result.SingleReportInvoiceAmount = assessmentTypeInvoiceAmount.SingleReportInvoiceAmount;
                    result.ComboReportInvoiceAmount = assessmentTypeInvoiceAmount.ComboReportInvoiceAmount;
                }
                else
                {
                    result.MissingAssessmentTypeInvoiceData = true;
                }

                if (companyEntity.ReferralSourceInvoiceConfigurations.Any())
                {
                    var referralSourceInvoiceConfiguration = companyEntity.ReferralSourceInvoiceConfigurations.First();

                    result.CompletionFeeAmount = referralSourceInvoiceConfiguration.CompletionFeeAmount;
                    //result.FullFeeSequence = referralSourceInvoiceConfiguration.FullFeeSequence.ToAppointmentSequence();
                    result.ExtraReportFee = referralSourceInvoiceConfiguration.ExtraReportFee;
                    result.LargeFileFee = referralSourceInvoiceConfiguration.LargeFileFee;
                    result.LargeFileSize = referralSourceInvoiceConfiguration.LargeFileSize;
                }
                else
                {
                    result.MissingReferralSourceInvoiceData = true;
                }

                return result;
            }
        }

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
        
        public Invoice GetInvoiceForDocument(int invoiceDocumentId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Invoice
                    .WithPath(InvoiceSendPath)
                    .Where(invoice => invoice.InvoiceDocuments.Any(invoiceDocument => invoiceDocument.InvoiceDocumentId == invoiceDocumentId))
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
                var invoiceIds = RetrievalProcedures.InvoiceSearch(
                    criteria.CompanyId,
                    criteria.AppointmentId,
                    criteria.Identifier,
                    criteria.InvoiceDate,
                    criteria.InvoiceMonth,
                    criteria.InvoiceStatusId,
                    criteria.InvoiceTypeId,
                    criteria.PayableToId,
                    criteria.NeedsRefresh,
                    (DataAccessAdapter)adapter
                )
                .AsEnumerable()
                .Select(row => Convert.ToInt32(row["InvoiceId"]));
                
                if (!invoiceIds.Any())
                {
                    return Enumerable.Empty<Invoice>();
                }
                
                var meta = new LinqMetaData(adapter);

                var invoices = meta.Invoice
                    .WithPath(InvoiceListPath)
                    .Where(invoice => invoiceIds.Contains(invoice.InvoiceId));
                
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
        
        public IEnumerable<InvoiceDocumentSendLog> GetInvoiceDocumentSendLogs(int invoiceDocumentId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<InvoiceDocumentSendLogEntity>(
                    (ILLBLGenProQuery)
                        meta.InvoiceDocumentSendLog
                        .Where(invoiceDocumentSendLog => invoiceDocumentSendLog.InvoiceDocumentId == invoiceDocumentId)
                    )
                    .Select(invoiceDocumentSendLog => invoiceDocumentSendLog.ToInvoiceDocumentSendLog())
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
                    invoice.InvoiceStatus.SaveDocument &&
                    invoice.InvoiceStatus.InvoiceStatusId != invoiceEntity.InvoiceStatusId;
                
                invoiceEntity.Identifier = invoice.Identifier;
                invoiceEntity.InvoiceDate = invoice.InvoiceDate;
                invoiceEntity.InvoiceStatusId = invoice.InvoiceStatus.InvoiceStatusId;
                invoiceEntity.InvoiceTypeId = invoice.InvoiceType.InvoiceTypeId;
                invoiceEntity.PayableToId = invoice.PayableTo.UserId;
                invoiceEntity.InvoiceRate = invoice.InvoiceRate;
                invoiceEntity.TaxRate = invoice.TaxRate;
                invoiceEntity.Total = invoice.Total;
                invoiceEntity.UpdateDate = _date.UtcNow;

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
                                            line.Amount != invoiceLine.Amount ||
                                            line.Description != invoiceLine.Description ||
                                            line.ApplyInvoiceRate != invoiceLine.ApplyInvoiceRate ||
                                            line.IsCustom != invoiceLine.IsCustom
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
                                    ApplyInvoiceRate = line.ApplyInvoiceRate,
                                    OriginalAmount = line.IsCustom ? line.Amount : line.OriginalAmount,
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
                            ApplyInvoiceRate = line.ApplyInvoiceRate,
                            IsCustom = line.IsCustom,
                            OriginalAmount = line.IsCustom ? line.Amount : line.OriginalAmount,
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
                            FileName = string.Format("{0}.pdf", _invoiceDocumentFileNameGenerator.GetFileName(invoice)),
                            Document = pdf,
                        }
                    );
                }

                uow.AddForSave(invoiceEntity);

                uow.Commit(adapter);

                return invoiceEntity.InvoiceId;
            }
        }
        
        public int IncrementCompanyInvoiceCounter(int companyId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var entity = new CompanyEntity
                {
                    CompanyId = companyId,
                };

                if (adapter.FetchEntity(entity))
                {
                    var newValue = entity.InvoiceCounter + 1;

                    entity.InvoiceCounter = newValue;
                    
                    adapter.SaveEntity(entity);

                    return newValue;
                }

                throw new ArgumentOutOfRangeException("companyId", $"Company with id {companyId} not found");
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

        public int LogInvoiceDocumentSent(int invoiceDocumentId, string recipients)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var log = new InvoiceDocumentSendLogEntity
                {
                    InvoiceDocumentId = invoiceDocumentId,
                    IsNew = true,
                    Recipients = recipients,
                };

                adapter.SaveEntity(log);

                return log.InvoiceDocumentSendLogId;
            }
        }

    }
}
