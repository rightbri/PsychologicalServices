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

        private static readonly Func<IPathEdgeRootParser<PsychometristInvoiceAmountEntity>, IPathEdgeRootParser<PsychometristInvoiceAmountEntity>>
            PsychometristInvoiceAmountPath =
                (psychometristInvoiceAmountPath => psychometristInvoiceAmountPath
                    .Prefetch<AssessmentTypeEntity>(psychometristInvoiceAmount => psychometristInvoiceAmount.AssessmentType)
                    .Prefetch<AppointmentStatusEntity>(psychometristInvoiceAmount => psychometristInvoiceAmount.AppointmentStatus)
                    .Prefetch<AppointmentSequenceEntity>(psychometristInvoiceAmount => psychometristInvoiceAmount.AppointmentSequence)
                );

        private static readonly Func<IPathEdgeRootParser<CompanyEntity>, IPathEdgeRootParser<CompanyEntity>>
            InvoiceConfigurationPath =
                (companyPath => companyPath
                    .Prefetch<IssueInDisputeInvoiceAmountEntity>(company => company.IssueInDisputeInvoiceAmounts)
                        .SubPath(issueInDisputeInvoiceAmountPath => issueInDisputeInvoiceAmountPath
                            .Prefetch<IssueInDisputeEntity>(issueInDisputeInvoiceAmount => issueInDisputeInvoiceAmount.IssueInDispute)
                        )
                    .Prefetch<AssessmentTypeInvoiceAmountEntity>(company => company.AssessmentTypeInvoiceAmounts)
                        .SubPath(assessmentTypeInvoiceAmountPath => assessmentTypeInvoiceAmountPath
                            .Prefetch<ReferralSourceEntity>(assessmentTypeInvoiceAmount => assessmentTypeInvoiceAmount.ReferralSource)
                            .Prefetch<AssessmentTypeEntity>(assessmentTypeInvoiceAmount => assessmentTypeInvoiceAmount.AssessmentType)
                        )
                    .Prefetch<ReferralSourceInvoiceConfigurationEntity>(company => company.ReferralSourceInvoiceConfigurations)
                        .SubPath(referralSourceInvoiceConfigurationPath => referralSourceInvoiceConfigurationPath
                            .Prefetch<ReferralSourceEntity>(referralSourceInvoiceConfiguration => referralSourceInvoiceConfiguration.ReferralSource)
                        )
                    .Prefetch<AppointmentStatusInvoiceRateEntity>(company => company.AppointmentStatusInvoiceRates)
                        .SubPath(appointmentStatusInvoiceRatePath => appointmentStatusInvoiceRatePath
                            .Prefetch<ReferralSourceEntity>(appointmentStatusInvoiceRate => appointmentStatusInvoiceRate.ReferralSource)
                            .Prefetch<AppointmentStatusEntity>(appointmentStatusInvoiceRate => appointmentStatusInvoiceRate.AppointmentStatus)
                            .Prefetch<AppointmentSequenceEntity>(appointmentStatusInvoiceRate => appointmentStatusInvoiceRate.AppointmentSequence)
                        )
                    .Prefetch<PsychometristInvoiceAmountEntity>(company => company.PsychometristInvoiceAmounts)
                        .SubPath(psychometristInvoiceAmountPath => psychometristInvoiceAmountPath
                            .Prefetch<AssessmentTypeEntity>(psychometristInvoiceAmount => psychometristInvoiceAmount.AssessmentType)
                            .Prefetch<AppointmentStatusEntity>(psychometristInvoiceAmount => psychometristInvoiceAmount.AppointmentStatus)
                            .Prefetch<AppointmentSequenceEntity>(psychometristInvoiceAmount => psychometristInvoiceAmount.AppointmentSequence)
                        )
                );

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
                    .Prefetch<InvoiceLineGroupEntity>(invoice => invoice.InvoiceLineGroups)
                        .SubPath(invoiceLineGroupPath => invoiceLineGroupPath
                            .Prefetch<InvoiceLineGroupAppointmentEntity>(invoiceLineGroup => invoiceLineGroup.InvoiceLineGroupAppointment)
                                .SubPath(invoiceLineGroupAppointmentPath => invoiceLineGroupAppointmentPath
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
                        )
                );

        private static readonly Func<IPathEdgeRootParser<InvoiceEntity>, IPathEdgeRootParser<InvoiceEntity>>
            InvoiceListPath =
                (invoicePath => invoicePath
                    .Prefetch<InvoiceStatusEntity>(invoice => invoice.InvoiceStatus)
                    .Prefetch<InvoiceTypeEntity>(invoice => invoice.InvoiceType)
                    .Prefetch<UserEntity>(invoice => invoice.PayableTo)
                    .Prefetch<InvoiceLineGroupEntity>(invoice => invoice.InvoiceLineGroups)
                        .SubPath(invoiceLineGroupPath => invoiceLineGroupPath
                            .Prefetch<InvoiceLineGroupAppointmentEntity>(invoiceLineGroup => invoiceLineGroup.InvoiceLineGroupAppointment)
                                .SubPath(invoiceLineGroupAppointmentPath => invoiceLineGroupAppointmentPath
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
                    .Prefetch<InvoiceLineGroupEntity>(invoice => invoice.InvoiceLineGroups)
                        .SubPath(invoiceLineGroupPath => invoiceLineGroupPath
                            .Prefetch<InvoiceLineEntity>(invoiceLineGroup => invoiceLineGroup.InvoiceLines)
                            .Prefetch<InvoiceLineGroupAppointmentEntity>(invoiceLineGroup => invoiceLineGroup.InvoiceLineGroupAppointment)
                                .SubPath(invoiceLineGroupAppointmentPath => invoiceLineGroupAppointmentPath
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
                    criteria.ClaimantId,
                    criteria.NeedsRefresh,
                    criteria.NeedsToBeSentToReferralSource,
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

                    var invoiceLineGroupPath = prefetch.Add(InvoiceEntity.PrefetchPathInvoiceLineGroups);

                    invoiceLineGroupPath
                        .SubPath.Add(InvoiceLineGroupEntity.PrefetchPathInvoiceLines);

                    invoiceLineGroupPath
                        .SubPath.Add(InvoiceLineGroupEntity.PrefetchPathInvoiceLineGroupAppointment);
                    
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
                invoiceEntity.TaxRate = invoice.TaxRate;
                invoiceEntity.Total = invoice.Total;
                invoiceEntity.UpdateDate = _date.UtcNow;

                #region invoice line groups

                var invoiceLineGroupsToAdd = invoice.LineGroups
                    .Where(lg => 
                        !invoiceEntity.InvoiceLineGroups.Any(lineGroup => 
                            lineGroup.InvoiceLineGroupId == lg.InvoiceLineGroupId
                        )
                    )
                    .ToList();

                if (!isNew)
                {
                    var lineGroupsToRemove = invoiceEntity.InvoiceLineGroups
                        .Where(invoiceLineGroup =>
                            !invoice.LineGroups.Any(lg =>
                                lg.InvoiceLineGroupId == invoiceLineGroup.InvoiceLineGroupId
                            )
                        )
                        .ToList();

                    foreach (var lineGroup in lineGroupsToRemove)
                    {
                        uow.AddCollectionForDelete(lineGroup.InvoiceLines);

                        if (null != lineGroup.InvoiceLineGroupAppointment)
                        {
                            uow.AddForDelete(lineGroup.InvoiceLineGroupAppointment);
                        }
                        
                        uow.AddForDelete(lineGroup);
                    }

                    var lineGroupsToUpdate = invoice.LineGroups
                        .Where(lg => invoiceEntity.InvoiceLineGroups.Any(lineGroup =>
                                lineGroup.InvoiceLineGroupId == lg.InvoiceLineGroupId &&
                                (
                                    lg.Description != lineGroup.Description ||
                                    lg.Sort != lineGroup.Sort ||
                                    (null != lg.Appointment && null != lineGroup.InvoiceLineGroupAppointment && lg.Appointment.AppointmentId != lineGroup.InvoiceLineGroupAppointment.AppointmentId) ||
                                    (null != lg.Appointment && null == lineGroup.InvoiceLineGroupAppointment) ||
                                    (null == lg.Appointment && null != lineGroup.InvoiceLineGroupAppointment) ||
                                    //new lines
                                    lg.Lines.Any(line => !lineGroup.InvoiceLines.Any(invoiceLine => invoiceLine.InvoiceLineId == line.InvoiceLineId)) ||
                                    lineGroup.InvoiceLines.Any(invoiceLine =>
                                        //deleted lines
                                        !lg.Lines.Any(line => line.InvoiceLineId == invoiceLine.InvoiceLineId) ||
                                        //updated lines
                                        lg.Lines.Any(line => line.InvoiceLineId == invoiceLine.InvoiceLineId &&
                                            (
                                            line.Amount != invoiceLine.Amount ||
                                            line.Description != invoiceLine.Description ||
                                            line.IsCustom != invoiceLine.IsCustom
                                            )
                                        )
                                    )
                                )
                            )
                        )
                        .ToList();

                    foreach (var lg in lineGroupsToUpdate)
                    {
                        var lineGroupEntity = invoiceEntity.InvoiceLineGroups.SingleOrDefault(lineGroup => lineGroup.InvoiceLineGroupId == lg.InvoiceLineGroupId);
                        if (null != lineGroupEntity)
                        {
                            lineGroupEntity.Description = lg.Description;
                            lineGroupEntity.Sort = lg.Sort;

                            if (null != lg.Appointment && null != lineGroupEntity.InvoiceLineGroupAppointment && lg.Appointment.AppointmentId != lineGroupEntity.InvoiceLineGroupAppointment.AppointmentId)
                            {
                                lineGroupEntity.InvoiceLineGroupAppointment.AppointmentId = lg.Appointment.AppointmentId;
                            }

                            if (null != lg.Appointment && null == lineGroupEntity.InvoiceLineGroupAppointment)
                            {
                                lineGroupEntity.InvoiceLineGroupAppointment = new InvoiceLineGroupAppointmentEntity
                                {
                                    AppointmentId = lg.Appointment.AppointmentId,
                                };
                            }

                            if (null == lg.Appointment && null != lineGroupEntity.InvoiceLineGroupAppointment)
                            {
                                uow.AddForDelete(lineGroupEntity.InvoiceLineGroupAppointment);
                            }

                            #region invoice lines

                            var linesToAdd = lg.Lines
                                .Where(line =>
                                    !lineGroupEntity.InvoiceLines.Any(invoiceLine =>
                                        invoiceLine.InvoiceLineId == line.InvoiceLineId
                                    )
                                )
                                .ToList();

                            if (!isNew)
                            {
                                var linesToRemove = lineGroupEntity.InvoiceLines
                                    .Where(invoiceLine =>
                                        !lg.Lines.Any(line => line.InvoiceLineId == invoiceLine.InvoiceLineId)
                                    );

                                foreach (var line in linesToRemove)
                                {
                                    uow.AddForDelete(line);
                                }

                                var linesToUpdate = lg.Lines
                                    .Where(line =>
                                        lineGroupEntity.InvoiceLines.Any(invoiceLine =>
                                            invoiceLine.InvoiceLineId == line.InvoiceLineId &&
                                            (
                                                invoiceLine.Amount != line.Amount ||
                                                invoiceLine.Description != line.Description
                                            )
                                        )
                                    );

                                foreach (var line in linesToUpdate)
                                {
                                    var lineEntity = lineGroupEntity.InvoiceLines.SingleOrDefault(invoiceLine => invoiceLine.InvoiceLineId == line.InvoiceLineId);
                                    if (null != lineEntity)
                                    {
                                        lineEntity.Amount = line.Amount;
                                        lineEntity.Description = line.Description;
                                    }
                                }
                            }

                            lineGroupEntity.InvoiceLines.AddRange(
                                linesToAdd.Select(line => new InvoiceLineEntity
                                {
                                    Amount = line.Amount,
                                    Description = line.Description,
                                    IsCustom = line.IsCustom,
                                    OriginalAmount = line.IsCustom ? line.Amount : line.OriginalAmount,
                                })
                            );

                            #endregion
                        }
                    }
                }

                //new invoice line groups
                foreach (var lg in invoiceLineGroupsToAdd)
                {
                    var lineGroup = new InvoiceLineGroupEntity
                    {
                        Description = lg.Description,
                        Sort = lg.Sort,
                        InvoiceLineGroupAppointment = new InvoiceLineGroupAppointmentEntity { AppointmentId = lg.Appointment.AppointmentId },
                    };
                    
                    lineGroup.InvoiceLines.AddRange(
                        lg.Lines.Select(line => new InvoiceLineEntity
                        {
                            Amount = line.Amount,
                            Description = line.Description,
                            IsCustom = line.IsCustom,
                            OriginalAmount = line.IsCustom ? line.Amount : line.OriginalAmount,
                        })
                    );

                    invoiceEntity.InvoiceLineGroups.Add(lineGroup);
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

        public int SaveInvoiceConfiguration(InvoiceConfiguration invoiceConfiguration)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var companyEntity = new CompanyEntity(invoiceConfiguration.CompanyId);

                var prefetch = new PrefetchPath2(EntityType.CompanyEntity);

                prefetch.Add(CompanyEntity.PrefetchPathIssueInDisputeInvoiceAmounts);

                prefetch.Add(CompanyEntity.PrefetchPathAssessmentTypeInvoiceAmounts);

                prefetch.Add(CompanyEntity.PrefetchPathReferralSourceInvoiceConfigurations);

                prefetch.Add(CompanyEntity.PrefetchPathAppointmentStatusInvoiceRates);

                prefetch.Add(CompanyEntity.PrefetchPathPsychometristInvoiceAmounts);

                adapter.FetchEntity(companyEntity, prefetch);

                #region assessment type invoice amounts

                var assessmentTypeInvoiceAmountsToAdd = invoiceConfiguration.AssessmentTypeInvoiceAmounts
                    .Where(atia => !companyEntity.AssessmentTypeInvoiceAmounts.Any(atiae => atiae.ReferralSourceId == atia.ReferralSource.ReferralSourceId && atiae.AssessmentTypeId == atia.AssessmentType.AssessmentTypeId))
                    .ToList();

                var assessmentTypeInvoiceAmountsToDelete = companyEntity.AssessmentTypeInvoiceAmounts
                    .Where(atiae => !invoiceConfiguration.AssessmentTypeInvoiceAmounts.Any(atia => atia.ReferralSource.ReferralSourceId == atiae.ReferralSourceId && atia.AssessmentType.AssessmentTypeId == atiae.AssessmentTypeId))
                    .ToList();

                var assessmentTypeInvoiceAmountsToUpdate = invoiceConfiguration.AssessmentTypeInvoiceAmounts
                    .Where(atia =>
                        companyEntity.AssessmentTypeInvoiceAmounts.Any(atiae =>
                            atiae.ReferralSourceId == atia.ReferralSource.ReferralSourceId &&
                            atiae.AssessmentTypeId == atia.AssessmentType.AssessmentTypeId &&
                            (
                                atiae.SingleReportInvoiceAmount != atia.SingleReportInvoiceAmount ||
                                atiae.ComboReportInvoiceAmount != atia.ComboReportInvoiceAmount
                            )
                        )
                    )
                    .ToList();

                foreach (var assessmentTypeInvoiceAmount in assessmentTypeInvoiceAmountsToDelete)
                {
                    uow.AddForDelete(assessmentTypeInvoiceAmount);
                }

                foreach (var assessmentTypeInvoiceAmount in assessmentTypeInvoiceAmountsToUpdate)
                {
                    var entity = companyEntity.AssessmentTypeInvoiceAmounts.Where(atiae => atiae.ReferralSourceId == assessmentTypeInvoiceAmount.ReferralSource.ReferralSourceId && atiae.AssessmentTypeId == assessmentTypeInvoiceAmount.AssessmentType.AssessmentTypeId).SingleOrDefault();

                    if (null != entity)
                    {
                        entity.SingleReportInvoiceAmount = assessmentTypeInvoiceAmount.SingleReportInvoiceAmount;
                        entity.ComboReportInvoiceAmount = assessmentTypeInvoiceAmount.ComboReportInvoiceAmount;

                        uow.AddForSave(entity);
                    }
                }

                foreach (var assessmentTypeInvoiceAmount in assessmentTypeInvoiceAmountsToAdd)
                {
                    uow.AddForSave(
                        new AssessmentTypeInvoiceAmountEntity
                        {
                            CompanyId = invoiceConfiguration.CompanyId,
                            ReferralSourceId = assessmentTypeInvoiceAmount.ReferralSource.ReferralSourceId,
                            AssessmentTypeId = assessmentTypeInvoiceAmount.AssessmentType.AssessmentTypeId,
                            SingleReportInvoiceAmount = assessmentTypeInvoiceAmount.SingleReportInvoiceAmount,
                            ComboReportInvoiceAmount = assessmentTypeInvoiceAmount.ComboReportInvoiceAmount,
                            IsNew = true,
                        }
                    );
                }

                #endregion

                #region issue in dispute invoice amounts

                var issueInDisputeInvoiceAmountsToAdd = invoiceConfiguration.IssueInDisputeInvoiceAmounts
                    .Where(idia => !companyEntity.IssueInDisputeInvoiceAmounts.Any(idiae => idiae.IssueInDisputeId == idia.IssueInDispute.IssueInDisputeId))
                    .ToList();

                var issueInDisputeInvoiceAmountsToDelete = companyEntity.IssueInDisputeInvoiceAmounts
                    .Where(idiae => !invoiceConfiguration.IssueInDisputeInvoiceAmounts.Any(idia => idia.IssueInDispute.IssueInDisputeId == idiae.IssueInDisputeId))
                    .ToList();

                var issueInDisputeInvoiceAmountsToUpdate = invoiceConfiguration.IssueInDisputeInvoiceAmounts
                    .Where(idia =>
                        companyEntity.IssueInDisputeInvoiceAmounts.Any(idiae =>
                            idiae.IssueInDisputeId == idia.IssueInDispute.IssueInDisputeId &&
                            idiae.InvoiceAmount != idia.InvoiceAmount
                        )
                    )
                    .ToList();

                foreach (var entity in issueInDisputeInvoiceAmountsToDelete)
                {
                    uow.AddForDelete(entity);
                }

                foreach (var issueInDisputeInvoiceAmount in issueInDisputeInvoiceAmountsToUpdate)
                {
                    var entity = companyEntity.IssueInDisputeInvoiceAmounts.Where(idiae => idiae.IssueInDisputeId == issueInDisputeInvoiceAmount.IssueInDispute.IssueInDisputeId).SingleOrDefault();

                    if (null != entity)
                    {
                        entity.InvoiceAmount = issueInDisputeInvoiceAmount.InvoiceAmount;

                        uow.AddForSave(entity);
                    }
                }

                foreach (var issueInDisputeInvoiceAmount in issueInDisputeInvoiceAmountsToAdd)
                {
                    uow.AddForSave(
                        new IssueInDisputeInvoiceAmountEntity
                        {
                            CompanyId = invoiceConfiguration.CompanyId,
                            IssueInDisputeId = issueInDisputeInvoiceAmount.IssueInDispute.IssueInDisputeId,
                            InvoiceAmount = issueInDisputeInvoiceAmount.InvoiceAmount,
                            IsNew = true,
                        }
                    );
                }

                #endregion

                #region referral source invoice configurations

                var referralSourceInvoiceConfigurationsToAdd = invoiceConfiguration.ReferralSourceInvoiceConfigurations
                    .Where(rsic => !companyEntity.ReferralSourceInvoiceConfigurations.Any(rsice => rsice.ReferralSourceId == rsic.ReferralSource.ReferralSourceId))
                    .ToList();

                var referralSourceInvoiceConfigurationsToDelete = companyEntity.ReferralSourceInvoiceConfigurations
                    .Where(rsice => !invoiceConfiguration.ReferralSourceInvoiceConfigurations.Any(rsic => rsic.ReferralSource.ReferralSourceId == rsice.ReferralSourceId))
                    .ToList();

                var referralSourceInvoiceConfigurationsToUpdate = invoiceConfiguration.ReferralSourceInvoiceConfigurations
                    .Where(rsic => companyEntity.ReferralSourceInvoiceConfigurations.Any(rsice =>
                            rsice.ReferralSourceId == rsic.ReferralSource.ReferralSourceId &&
                            (
                                rsice.CompletionFeeAmount != rsic.CompletionFee ||
                                rsice.ExtraReportFee != rsic.ExtraReportFee ||
                                rsice.LargeFileFee != rsic.LargeFileFee ||
                                rsice.LargeFileSize != rsic.LargeFileSize
                            )
                        )
                    )
                    .ToList();

                foreach (var entity in referralSourceInvoiceConfigurationsToDelete)
                {
                    uow.AddForDelete(entity);
                }

                foreach (var referralSourceInvoiceConfiguration in referralSourceInvoiceConfigurationsToUpdate)
                {
                    var entity = companyEntity.ReferralSourceInvoiceConfigurations.Where(rsice => rsice.ReferralSourceId == referralSourceInvoiceConfiguration.ReferralSource.ReferralSourceId).SingleOrDefault();

                    if (null != entity)
                    {
                        entity.CompletionFeeAmount = referralSourceInvoiceConfiguration.CompletionFee;
                        entity.ExtraReportFee = referralSourceInvoiceConfiguration.ExtraReportFee;
                        entity.LargeFileFee = referralSourceInvoiceConfiguration.LargeFileFee;
                        entity.LargeFileSize = referralSourceInvoiceConfiguration.LargeFileSize;
                    }
                }

                foreach (var referralSourceInvoiceConfiguration in referralSourceInvoiceConfigurationsToAdd)
                {
                    uow.AddForSave(
                        new ReferralSourceInvoiceConfigurationEntity
                        {
                            CompanyId = invoiceConfiguration.CompanyId,
                            ReferralSourceId = referralSourceInvoiceConfiguration.ReferralSource.ReferralSourceId,
                            CompletionFeeAmount = referralSourceInvoiceConfiguration.CompletionFee,
                            ExtraReportFee = referralSourceInvoiceConfiguration.ExtraReportFee,
                            LargeFileFee = referralSourceInvoiceConfiguration.LargeFileFee,
                            LargeFileSize = referralSourceInvoiceConfiguration.LargeFileSize,
                            IsNew = true,
                        }
                    );
                }

                #endregion

                #region appointment status invoice rates

                var appointmentStatusInvoiceRatesToAdd = invoiceConfiguration.AppointmentStatusInvoiceRates
                    .Where(asir => !companyEntity.AppointmentStatusInvoiceRates.Any(asire =>
                        asir.ReferralSource.ReferralSourceId == asire.ReferralSourceId &&
                        asir.AppointmentStatus.AppointmentStatusId == asire.AppointmentStatusId &&
                        asir.AppointmentSequence.AppointmentSequenceId == asire.AppointmentSequenceId
                        )
                    )
                    .ToList();

                var appointmentStatusInvoiceRatesToDelete = companyEntity.AppointmentStatusInvoiceRates
                    .Where(asire => !invoiceConfiguration.AppointmentStatusInvoiceRates.Any(asir =>
                        asir.ReferralSource.ReferralSourceId == asire.ReferralSourceId &&
                        asir.AppointmentStatus.AppointmentStatusId == asire.AppointmentStatusId &&
                        asir.AppointmentSequence.AppointmentSequenceId == asire.AppointmentSequenceId
                        )
                    )
                    .ToList();

                var appointmentStatusInvoiceRatesToUpdate = invoiceConfiguration.AppointmentStatusInvoiceRates
                    .Where(asir => companyEntity.AppointmentStatusInvoiceRates.Any(asire =>
                        asir.ReferralSource.ReferralSourceId == asire.ReferralSourceId &&
                        asir.AppointmentStatus.AppointmentStatusId == asire.AppointmentStatusId &&
                        asir.AppointmentSequence.AppointmentSequenceId == asire.AppointmentSequenceId &&
                        (
                            asir.ApplyCompletionFee != asire.ApplyCompletionFee ||
                            asir.ApplyExtraReportFees != asire.ApplyExtraReportFees ||
                            asir.ApplyIssueInDisputeFees != asire.ApplyIssueInDisputeFees ||
                            asir.ApplyLargeFileFee != asire.ApplyLargeFileFee ||
                            asir.ApplyTravelFee != asire.ApplyTravelFee ||
                            asir.InvoiceRate != asire.InvoiceRate
                        ))
                    )
                    .ToList();


                foreach (var entity in appointmentStatusInvoiceRatesToDelete)
                {
                    uow.AddForDelete(entity);
                }

                foreach (var appointmentStatusInvoiceRate in appointmentStatusInvoiceRatesToUpdate)
                {
                    var entity = companyEntity.AppointmentStatusInvoiceRates.Where(asire =>
                        asire.ReferralSourceId == appointmentStatusInvoiceRate.ReferralSource.ReferralSourceId &&
                        asire.AppointmentStatusId == appointmentStatusInvoiceRate.AppointmentStatus.AppointmentStatusId &&
                        asire.AppointmentSequenceId == appointmentStatusInvoiceRate.AppointmentSequence.AppointmentSequenceId
                    ).SingleOrDefault();

                    if (null != entity)
                    {
                        entity.ApplyCompletionFee = appointmentStatusInvoiceRate.ApplyCompletionFee;
                        entity.ApplyExtraReportFees = appointmentStatusInvoiceRate.ApplyExtraReportFees;
                        entity.ApplyIssueInDisputeFees = appointmentStatusInvoiceRate.ApplyIssueInDisputeFees;
                        entity.ApplyLargeFileFee = appointmentStatusInvoiceRate.ApplyLargeFileFee;
                        entity.ApplyTravelFee = appointmentStatusInvoiceRate.ApplyTravelFee;
                        entity.InvoiceRate = appointmentStatusInvoiceRate.InvoiceRate;

                        uow.AddForSave(entity);
                    }
                }

                foreach (var appointmentStatusInvoiceRate in appointmentStatusInvoiceRatesToAdd)
                {
                    uow.AddForSave(
                        new AppointmentStatusInvoiceRateEntity
                        {
                            CompanyId = invoiceConfiguration.CompanyId,
                            ReferralSourceId = appointmentStatusInvoiceRate.ReferralSource.ReferralSourceId,
                            AppointmentStatusId = appointmentStatusInvoiceRate.AppointmentStatus.AppointmentStatusId,
                            AppointmentSequenceId = appointmentStatusInvoiceRate.AppointmentSequence.AppointmentSequenceId,
                            ApplyCompletionFee = appointmentStatusInvoiceRate.ApplyCompletionFee,
                            ApplyExtraReportFees = appointmentStatusInvoiceRate.ApplyExtraReportFees,
                            ApplyIssueInDisputeFees = appointmentStatusInvoiceRate.ApplyIssueInDisputeFees,
                            ApplyLargeFileFee = appointmentStatusInvoiceRate.ApplyLargeFileFee,
                            ApplyTravelFee = appointmentStatusInvoiceRate.ApplyTravelFee,
                            InvoiceRate = appointmentStatusInvoiceRate.InvoiceRate,
                        }
                    );
                }

                #endregion

                #region psychometrist invoice amounts

                var psychometristInvoiceAmountsToAdd = invoiceConfiguration.PsychometristInvoiceAmounts
                    .Where(pia => !companyEntity.PsychometristInvoiceAmounts.Any(piae =>
                        pia.AssessmentType.AssessmentTypeId == piae.AssessmentTypeId &&
                        pia.AppointmentStatus.AppointmentStatusId == piae.AppointmentStatusId &&
                        pia.AppointmentSequence.AppointmentSequenceId == piae.AppointmentSequenceId
                        )
                    )
                    .ToList();

                var psychometristInvoiceAmountsToDelete = companyEntity.PsychometristInvoiceAmounts
                    .Where(piae => !invoiceConfiguration.PsychometristInvoiceAmounts.Any(pia =>
                        pia.AssessmentType.AssessmentTypeId == piae.AssessmentTypeId &&
                        pia.AppointmentStatus.AppointmentStatusId == piae.AppointmentStatusId &&
                        pia.AppointmentSequence.AppointmentSequenceId == piae.AppointmentSequenceId
                        )
                    )
                    .ToList();

                var psychometristInvoiceAmountsToUpdate = invoiceConfiguration.PsychometristInvoiceAmounts
                    .Where(pia => companyEntity.PsychometristInvoiceAmounts.Any(piae =>
                        pia.AssessmentType.AssessmentTypeId == piae.AssessmentTypeId &&
                        pia.AppointmentStatus.AppointmentStatusId == piae.AppointmentStatusId &&
                        pia.AppointmentSequence.AppointmentSequenceId == piae.AppointmentSequenceId &&
                        (
                            pia.InvoiceAmount != piae.InvoiceAmount
                        ))
                    )
                    .ToList();

                foreach (var entity in psychometristInvoiceAmountsToDelete)
                {
                    uow.AddForDelete(entity);
                }

                foreach (var psychometristInvoiceAmount in psychometristInvoiceAmountsToUpdate)
                {
                    var entity = companyEntity.PsychometristInvoiceAmounts.Where(piae =>
                        psychometristInvoiceAmount.AssessmentType.AssessmentTypeId == piae.AssessmentTypeId &&
                        psychometristInvoiceAmount.AppointmentStatus.AppointmentStatusId == piae.AppointmentStatusId &&
                        psychometristInvoiceAmount.AppointmentSequence.AppointmentSequenceId == piae.AppointmentSequenceId
                    ).SingleOrDefault();
                    
                    if (null != entity)
                    {
                        entity.InvoiceAmount = psychometristInvoiceAmount.InvoiceAmount;

                        uow.AddForSave(entity);
                    }
                }

                foreach (var psychometristInvoiceAmount in psychometristInvoiceAmountsToAdd)
                {
                    uow.AddForSave(
                        new PsychometristInvoiceAmountEntity
                        {
                            CompanyId = invoiceConfiguration.CompanyId,
                            AssessmentTypeId = psychometristInvoiceAmount.AssessmentType.AssessmentTypeId,
                            AppointmentStatusId = psychometristInvoiceAmount.AppointmentStatus.AppointmentStatusId,
                            AppointmentSequenceId = psychometristInvoiceAmount.AppointmentSequence.AppointmentSequenceId,
                            InvoiceAmount = psychometristInvoiceAmount.InvoiceAmount,
                        }
                    );
                }

                #endregion

                uow.Commit(adapter);
            }

            return invoiceConfiguration.CompanyId;
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
                    .WithPath(PsychometristInvoiceAmountPath)
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

        public InvoiceConfiguration GetInvoiceConfiguration(int companyId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Company
                    .WithPath(InvoiceConfigurationPath)
                    .Where(company => company.CompanyId == companyId)
                    .SingleOrDefault()
                    .ToInvoiceConfiguration();
            }
        }
    }
}
