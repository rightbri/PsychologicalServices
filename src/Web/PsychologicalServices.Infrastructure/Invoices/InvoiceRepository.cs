﻿using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.HelperClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Invoices;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Invoices
{
    public class InvoiceRepository : RepositoryBase, IInvoiceRepository
    {
        public InvoiceRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<InvoiceEntity>, IPathEdgeRootParser<InvoiceEntity>>
            InvoiceListPath =
                (invoicePath => invoicePath
                    .Prefetch<InvoiceStatusEntity>(invoice => invoice.InvoiceStatus)
                    .Prefetch<AppointmentEntity>(invoice => invoice.Appointment)
                        .SubPath(appointmentPath => appointmentPath
                            .Prefetch<AddressEntity>(appointment => appointment.Location)
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
                );

        private static readonly Func<IPathEdgeRootParser<InvoiceEntity>, IPathEdgeRootParser<InvoiceEntity>>
            InvoiceEditPath =
                (invoicePath => invoicePath
                    .Prefetch<InvoiceLineEntity>(invoice => invoice.InvoiceLines)
                    .Prefetch<InvoiceStatusEntity>(invoice => invoice.InvoiceStatus)
                    .Prefetch<InvoiceStatusChangeEntity>(invoice => invoice.InvoiceStatusChanges)
                        .SubPath(invoiceStatusChangePath => invoiceStatusChangePath
                            .Prefetch<InvoiceStatusEntity>(invoiceStatusChange => invoiceStatusChange.InvoiceStatus)
                        )
                    .Prefetch<AppointmentEntity>(invoice => invoice.Appointment)
                        .SubPath(appointmentPath => appointmentPath
                            .Prefetch<AppointmentStatusEntity>(appointment => appointment.AppointmentStatus)
                            .Prefetch<UserEntity>(appointment => appointment.Psychologist)
                                .SubPath(psychologistPath => psychologistPath
                                    .Prefetch<UserTravelFeeEntity>(psychologist => psychologist.UserTravelFees)
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
                    if (criteria.AppointmentId.HasValue)
                    {
                        invoices = invoices.Where(invoice => invoice.AppointmentId == criteria.AppointmentId.Value);
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.Identifier))
                    {
                        invoices = invoices.Where(invoice => invoice.Identifier.Contains(criteria.Identifier));
                    }

                    if (criteria.InvoiceDate.HasValue)
                    {
                        invoices = invoices.Where(invoice => invoice.InvoiceDate >= criteria.InvoiceDate.Value.Date && invoice.InvoiceDate < criteria.InvoiceDate.Value.Date.AddDays(1));
                    }

                    if (criteria.InvoiceStatusId.HasValue)
                    {
                        invoices = invoices.Where(invoice => invoice.InvoiceStatusId == criteria.InvoiceStatusId);
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

                    prefetch.Add(InvoiceEntity.PrefetchPathAppointment);

                    prefetch.Add(InvoiceEntity.PrefetchPathInvoiceLines);

                    adapter.FetchEntity(invoiceEntity, prefetch);
                }

                invoiceEntity.Identifier = invoice.Identifier;
                invoiceEntity.InvoiceDate = invoice.InvoiceDate;
                invoiceEntity.AppointmentId = invoice.Appointment.AppointmentId;
                invoiceEntity.InvoiceStatusId = invoice.InvoiceStatus.InvoiceStatusId;
                invoiceEntity.UpdateDate = invoice.UpdateDate;
                invoiceEntity.TaxRate = invoice.TaxRate;
                invoiceEntity.Total = invoice.Total;
                invoiceEntity.ModifiedTotal = invoice.ModifiedTotal;
                
                if (!isNew)
                {
                    var linesToRemove = invoiceEntity.InvoiceLines
                        .Where(invoiceLine =>
                            !invoice.Lines.Any(line => line.InvoiceLineId == invoiceLine.InvoiceLineId)
                        );

                    foreach (var line in linesToRemove)
                    {
                        uow.AddForDelete(line);
                    }

                    var linesToUpdate = invoice.Lines
                        .Where(line =>
                            invoiceEntity.InvoiceLines.Any(invoiceLine =>
                                invoiceLine.InvoiceLineId == line.InvoiceLineId &&
                                (
                                    invoiceLine.Amount != line.Amount ||
                                    invoiceLine.Description != line.Description
                                )
                            )
                        );

                    foreach (var line in linesToUpdate)
                    {
                        var lineEntity = invoiceEntity.InvoiceLines.SingleOrDefault(invoiceLine => invoiceLine.InvoiceLineId == line.InvoiceLineId);

                        if (null != lineEntity)
                        {
                            lineEntity.Amount = line.Amount;
                            lineEntity.Description = line.Description;
                        }
                    }
                }

                var linesToAdd = invoice.Lines
                    .Where(line =>
                        !invoiceEntity.InvoiceLines.Any(invoiceLine =>
                            invoiceLine.InvoiceLineId == line.InvoiceLineId
                        )
                    );

                invoiceEntity.InvoiceLines.AddRange(
                    linesToAdd.Select(line => new InvoiceLineEntity
                    {
                        Amount = line.Amount,
                        Description = line.Description,
                        IsCustom = line.IsCustom,
                    })
                );

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

        public IEnumerable<InvoiceAmount> GetInvoiceAmounts(int companyId, int referralSourceId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<InvoiceAmountEntity>(
                        (ILLBLGenProQuery)
                        meta.InvoiceAmount
                        .Where(invoiceAmount => invoiceAmount.ReferralSourceId == referralSourceId)
                    )
                    .Select(invoiceAmount => invoiceAmount.ToInvoiceAmount())
                    .ToList();
            }
        }

        public decimal GetTaxRate()
        {
            return 13.0m;   //TODO: retrieve from DB
            throw new NotImplementedException();
        }
    }
}
