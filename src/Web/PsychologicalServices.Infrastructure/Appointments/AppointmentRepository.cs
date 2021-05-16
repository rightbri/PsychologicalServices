using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Attributes;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Companies;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Appointments
{
    public class AppointmentRepository : RepositoryBase, IAppointmentRepository
    {
        private readonly IDate _date = null;
        private readonly ICompanyRepository _companyRepository = null;
        private readonly IAttributeRepository _attributeRepository = null;
        private readonly ITimezoneService _timezoneService = null;

        public AppointmentRepository(
            IDataAccessAdapterFactory adapterFactory,
            IDate date,
            ICompanyRepository companyRepository,
            IAttributeRepository attributeRepository,
            ITimezoneService timezoneService
        ) : base(adapterFactory)
        {
            _date = date;
            _companyRepository = companyRepository;
            _attributeRepository = attributeRepository;
            _timezoneService = timezoneService;
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<AppointmentEntity>, IPathEdgeRootParser<AppointmentEntity>>
            AppointmentPath =
                (appointmentPath => appointmentPath
                    .Prefetch<AddressEntity>(appointment => appointment.Location)
                        .SubPath(addressPath => addressPath
                            .Prefetch<AddressAddressTypeEntity>(address => address.AddressAddressTypes)
                                .SubPath(addressAddressTypePath => addressAddressTypePath
                                    .Prefetch<AddressTypeEntity>(addressAddressType => addressAddressType.AddressType)
                                )
                            .Prefetch<CityEntity>(address => address.City)
                        )
                    .Prefetch<UserEntity>(appointment => appointment.Psychologist)
                    .Prefetch<UserEntity>(appointment => appointment.Psychometrist)
                    .Prefetch<AppointmentStatusEntity>(appointment => appointment.AppointmentStatus)
                        //.SubPath(appointmentStatusPath => appointmentStatusPath
                        //    .Prefetch<ReferralSourceAppointmentStatusSettingEntity>(appointmentStatus => appointmentStatus.ReferralSourceAppointmentStatusSettings)
                        //        .SubPath(referralSourceAppointmentStatusSettingPath => referralSourceAppointmentStatusSettingPath
                        //            .Prefetch<ReferralSourceEntity>(referralSourceAppointmentStatusSetting => referralSourceAppointmentStatusSetting.ReferralSource)
                        //            .Prefetch<InvoiceTypeEntity>(referralSourceAppointmentStatusSetting => referralSourceAppointmentStatusSetting.InvoiceType)
                        //        )
                        //)
                    .Prefetch<AppointmentAttributeEntity>(appointment => appointment.AppointmentAttributes)
                        .FilterOn(appointmentAttribute => appointmentAttribute.Attribute.IsActive)
                        .SubPath(appointmentAttributePath => appointmentAttributePath
                            .Prefetch<AttributeEntity>(appointmentAttribute => appointmentAttribute.Attribute)
                                .SubPath(attributePath => attributePath
                                    .Prefetch<AttributeTypeEntity>(attribute => attribute.AttributeType)
                                )
                        )
                    .Prefetch<AssessmentEntity>(appointment => appointment.Assessment)
                        .SubPath(assessmentPath => assessmentPath
                            .Prefetch<AppointmentEntity>(assessment => assessment.Appointments)
                                .SubPath(assessmentAppointmentPath => assessmentAppointmentPath
                                    .Prefetch<AppointmentStatusEntity>(assessmentAppointment => assessmentAppointment.AppointmentStatus)
                                )
                            .Prefetch<AssessmentTypeEntity>(assessment => assessment.AssessmentType)
                                .SubPath(assessmentTypePath => assessmentTypePath
                                    .Prefetch<AssessmentTypeReportTypeEntity>(assessmentType => assessmentType.AssessmentTypeReportTypes)
                                        .SubPath(assessmentTypeReportTypePath => assessmentTypeReportTypePath
                                            .Prefetch<ReportTypeEntity>(assessmentTypeReportType => assessmentTypeReportType.ReportType)
                                        )
                                )
                            .Prefetch<ReferralTypeEntity>(assessment => assessment.ReferralType)
                            .Prefetch<ReferralSourceEntity>(assessment => assessment.ReferralSource)
                                .SubPath(referralSourcePath => referralSourcePath
                                    .Prefetch<ReferralSourceTypeEntity>(referralSource => referralSource.ReferralSourceType)
                                )
                            .Prefetch<ReportStatusEntity>(assessment => assessment.ReportStatus)
                            .Prefetch<UserEntity>(assessment => assessment.DocListWriter)
                            .Prefetch<UserEntity>(assessment => assessment.NotesWriter)
                            .Prefetch<ClaimantEntity>(assessment => assessment.Claimant)
                            .Prefetch<AssessmentClaimEntity>(assessment => assessment.AssessmentClaims)
                                .SubPath(assessmentClaimPath => assessmentClaimPath
                                    .Prefetch<ClaimEntity>(assessmentClaim => assessmentClaim.Claim)
                                )
                            .Prefetch<AssessmentAttributeEntity>(assessment => assessment.AssessmentAttributes)
                                .FilterOn(assessmentAttribute => assessmentAttribute.Attribute.IsActive)
                                .SubPath(assessmentAttributePath => assessmentAttributePath
                                    .Prefetch<AttributeEntity>(assessmentAttribute => assessmentAttribute.Attribute)
                                        .SubPath(attributePath => attributePath
                                            .Prefetch<AttributeTypeEntity>(attribute => attribute.AttributeType)
                                        )
                                )
                            .Prefetch<AssessmentReportEntity>(assessment => assessment.AssessmentReports)
                                .SubPath(assessmentReportPath => assessmentReportPath
                                    .Prefetch<ReportTypeEntity>(assessmentReport => assessmentReport.ReportType)
                                    .Prefetch<AssessmentReportIssueInDisputeEntity>(assessmentReport => assessmentReport.AssessmentReportIssuesInDispute)
                                        .SubPath(assessmentReportIssueInDisputePath => assessmentReportIssueInDisputePath
                                            .Prefetch<IssueInDisputeEntity>(assessmentReportIssueInDispute => assessmentReportIssueInDispute.IssueInDispute)
                                        )
                                )
                            .Prefetch<AssessmentMedRehabEntity>(assessment => assessment.AssessmentMedRehabs)
                            .Prefetch<AssessmentNoteEntity>(assessment => assessment.AssessmentNotes)
                                //only pull notes that should show on the calendar
                                .FilterOn(assessmentNote => assessmentNote.ShowOnCalendar)
                                .SubPath(assessmentNotePath => assessmentNotePath
                                    .Prefetch<NoteEntity>(assessmentNote => assessmentNote.Note)
                                )
                            .Prefetch<AssessmentColorEntity>(assessment => assessment.AssessmentColors)
                                .SubPath(assessmentColorPath => assessmentColorPath
                                    .Prefetch<ColorEntity>(assessmentColor => assessmentColor.Color)
                                )
                            .Prefetch<NoteEntity>(assessment => assessment.Summary)
                            .Prefetch<CompanyEntity>(assessment => assessment.Company)
                        )
                    .Prefetch<UserEntity>(appointment => appointment.CreateUser)
                    .Prefetch<UserEntity>(appointment => appointment.UpdateUser)
                );

        private static readonly Func<IPathEdgeRootParser<AppointmentEntity>, IPathEdgeRootParser<AppointmentEntity>>
            PsychometristInvoiceAppointmentPath =
                (appointmentPath => appointmentPath
                    .Prefetch<AddressEntity>(appointment => appointment.Location)
                        .SubPath(addressPath => addressPath
                            .Prefetch<CityEntity>(address => address.City)
                        )
                    .Prefetch<UserEntity>(appointment => appointment.Psychometrist)
                        .SubPath(psychometristPath => psychometristPath
                            .Prefetch<UserTravelFeeEntity>(psychometrist => psychometrist.UserTravelFees)
                                .SubPath(userTravelFeePath => userTravelFeePath
                                    .Prefetch<CityEntity>(userTravelFee => userTravelFee.City)
                                )
                        )
                    .Prefetch<AppointmentStatusEntity>(appointment => appointment.AppointmentStatus)
                    .Prefetch<AssessmentEntity>(appointment => appointment.Assessment)
                        .SubPath(assessmentPath => assessmentPath
                            .Prefetch<AppointmentEntity>(assessment => assessment.Appointments)
                            .Prefetch<AssessmentTypeEntity>(assessment => assessment.AssessmentType)
                            .Prefetch<ReferralSourceEntity>(assessment => assessment.ReferralSource)
                            .Prefetch<ClaimantEntity>(assessment => assessment.Claimant)
                            .Prefetch<AssessmentClaimEntity>(assessment => assessment.AssessmentClaims)
                                .SubPath(assessmentClaimPath => assessmentClaimPath
                                    .Prefetch<ClaimEntity>(assessmentClaim => assessmentClaim.Claim)
                                )
                            .Prefetch<CompanyEntity>(assessment => assessment.Company)
                        )
                );

        private static readonly Func<IPathEdgeRootParser<AppointmentEntity>, IPathEdgeRootParser<AppointmentEntity>>
            PsychologistInvoiceAppointmentPath =
                (appointmentPath => appointmentPath
                    .Prefetch<AddressEntity>(appointment => appointment.Location)
                        .SubPath(addressPath => addressPath
                            .Prefetch<CityEntity>(address => address.City)
                        )
                    .Prefetch<UserEntity>(appointment => appointment.Psychologist)
                        .SubPath(psychologistPath => psychologistPath
                            .Prefetch<UserTravelFeeEntity>(psychologist => psychologist.UserTravelFees)
                                .SubPath(userTravelFeePath => userTravelFeePath
                                    .Prefetch<CityEntity>(userTravelFee => userTravelFee.City)
                                )
                        )
                    .Prefetch<AppointmentStatusEntity>(appointment => appointment.AppointmentStatus)
                    .Prefetch<AssessmentEntity>(appointment => appointment.Assessment)
                        .SubPath(assessmentPath => assessmentPath
                            .Prefetch<AppointmentEntity>(assessment => assessment.Appointments)
                                .SubPath(assessmentAppointmentPath => assessmentAppointmentPath
                                    .Prefetch<AppointmentStatusEntity>(assessmentAppointment => assessmentAppointment.AppointmentStatus)
                                )
                            .Prefetch<AssessmentTypeEntity>(assessment => assessment.AssessmentType)
                            .Prefetch<ReferralSourceEntity>(assessment => assessment.ReferralSource)
                            .Prefetch<ClaimantEntity>(assessment => assessment.Claimant)
                            .Prefetch<AssessmentClaimEntity>(assessment => assessment.AssessmentClaims)
                                .SubPath(assessmentClaimPath => assessmentClaimPath
                                    .Prefetch<ClaimEntity>(assessmentClaim => assessmentClaim.Claim)
                                )
                            .Prefetch<AssessmentReportEntity>(assessment => assessment.AssessmentReports)
                                .SubPath(assessmentReportPath => assessmentReportPath
                                    .Prefetch<AssessmentReportIssueInDisputeEntity>(assessmentReport => assessmentReport.AssessmentReportIssuesInDispute)
                                        .SubPath(assessmentReportIssueInDisputePath => assessmentReportIssueInDisputePath
                                            .Prefetch(assessmentReportIssueInDispute => assessmentReportIssueInDispute.IssueInDispute)
                                        )
                                )
                            .Prefetch<CompanyEntity>(assessment => assessment.Company)
                        )
                );

        private static readonly Func<IPathEdgeRootParser<AppointmentEntity>, IPathEdgeRootParser<AppointmentEntity>>
            AppointmentSiblingsSequencePath =
                (appointmentPath => appointmentPath
                    .Prefetch<AppointmentStatusEntity>(appointment => appointment.AppointmentStatus)
                    .Prefetch<AssessmentEntity>(appointment => appointment.Assessment)
                );

        private static readonly Func<IPathEdgeRootParser<AppointmentProtocolResponseEntity>, IPathEdgeRootParser<AppointmentProtocolResponseEntity>>
            AppointmentProtocolResponsePath =
                (appointmentProtocolResponsePath => appointmentProtocolResponsePath
                    .Prefetch<UserEntity>(appointmentProtocolResponse => appointmentProtocolResponse.CreateUser)
                    .Prefetch<UserEntity>(appointmentProtocolResponse => appointmentProtocolResponse.UpdateUser)
                    .Prefetch<AppointmentEntity>(appointmentProtocolResponse => appointmentProtocolResponse.Appointment)
                        .SubPath(appointmentPath => appointmentPath
                            .Prefetch<UserEntity>(appointment => appointment.Psychometrist)
                            .Prefetch<AppointmentStatusEntity>(appointment => appointment.AppointmentStatus)
                            .Prefetch<AssessmentEntity>(appointment => appointment.Assessment)
                                .SubPath(assessmentPath => assessmentPath
                                    .Prefetch<ClaimantEntity>(assessment => assessment.Claimant)
                                )
                        )
                );

        #endregion

        private Appointment GetAppointment(int id, Func<IPathEdgeRootParser<AppointmentEntity>, IPathEdgeRootParser<AppointmentEntity>> prefetchPath = null)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var appointment = meta.Appointment.AsQueryable();

                if (null != prefetchPath)
                {
                    appointment = appointment.WithPath(prefetchPath);
                }
                
                return appointment
                    .Where(appt => appt.AppointmentId == id)
                    .SingleOrDefault()
                    .ToAppointment();
            }
        }

        public Appointment GetAppointment(int id)
        {
            return GetAppointment(id, AppointmentPath);
        }

        public Appointment GetAppointmentForPsychologistInvoice(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var appointment = meta.Appointment
                    .WithPath(PsychologistInvoiceAppointmentPath)
                    .Where(appt => appt.AppointmentId == id)
                    .SingleOrDefault()
                    .ToPsychologistInvoiceAppointment();

                return appointment;
            }
        }

        public Appointment NewAppointment(int companyId)
        {
            return NewAppointment(companyId, DateTime.Today);
        }
        
        public Appointment NewAppointment(int companyId, DateTime appointmentDate)
        {
            var company = _companyRepository.GetCompany(companyId);

            if (null == company)
            {
                throw new ArgumentOutOfRangeException("companyId");
            }

            var day = appointmentDate.Date;
            
            var timezone = _timezoneService.GetTimeZoneInfo(company.Timezone);

            var appointmentTime = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0, DateTimeKind.Unspecified)
                .Add(company.NewAppointmentTime);

            var appointmentTimeOffset = _timezoneService.GetDateTimeOffset(appointmentTime, timezone);
            
            return new Appointment
            {
                AppointmentTime = appointmentTimeOffset.UtcDateTime,
                Location = company.NewAppointmentLocation,
                AppointmentStatus = company.NewAppointmentStatus,
                Psychologist = company.NewAppointmentPsychologist,
                Psychometrist = company.NewAppointmentPsychometrist,
                Attributes = Enumerable.Empty<AttributeValue>(),
            };
        }

        public AppointmentStatus GetAppointmentStatus(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.AppointmentStatus
                    .Where(appointmentStatus => appointmentStatus.AppointmentStatusId == id)
                    .SingleOrDefault()
                    .ToAppointmentStatus();
            }
        }

        public IEnumerable<Appointment> GetAppointmentSequenceSiblings(int appointmentId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var appointments = meta.Appointment
                    .WithPath(AppointmentSiblingsSequencePath)
                    .Where(appointment =>
                        appointment.Assessment.Appointments.Any(assessmentAppointment => assessmentAppointment.AppointmentId == appointmentId) &&
                        appointment.AppointmentId != appointmentId
                    );
                
                return Execute<AppointmentEntity>(
                        (ILLBLGenProQuery)
                        appointments
                    )
                    .Select(appointment => appointment.ToAppointment())
                    .ToList();
            }
        }

        private IEnumerable<Appointment> GetAppointments(AppointmentSearchCriteria criteria, Func<IPathEdgeRootParser<AppointmentEntity>, IPathEdgeRootParser<AppointmentEntity>> prefetchPath = null)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var appointments = meta.Appointment.AsQueryable();

                if (null != prefetchPath)
                {
                    appointments = appointments.WithPath(prefetchPath);
                }

                if (null != criteria)
                {
                    if (criteria.AppointmentId.HasValue)
                    {
                        appointments = appointments.Where(appointment => appointment.AppointmentId == criteria.AppointmentId.Value);
                    }

                    if (criteria.AssessmentId.HasValue)
                    {
                        appointments = appointments.Where(appointment => appointment.AssessmentId == criteria.AssessmentId.Value);
                    }

                    if (criteria.CompanyId.HasValue)
                    {
                        appointments = appointments.Where(appointment => appointment.Assessment.CompanyId == criteria.CompanyId.Value);
                    }

                    if (null != criteria.AppointmentStatusIds && criteria.AppointmentStatusIds.Any())
                    {
                        appointments = appointments.Where(appointment =>
                            criteria.AppointmentStatusIds.Contains(appointment.AppointmentStatusId)
                        );
                    }

                    if (criteria.AppointmentTimeEnd.HasValue)
                    {
                        appointments = appointments.Where(appointment => appointment.AppointmentTime <= criteria.AppointmentTimeEnd.Value);
                    }

                    if (criteria.AppointmentTimeStart.HasValue)
                    {
                        appointments = appointments.Where(appointment => appointment.AppointmentTime >= criteria.AppointmentTimeStart.Value);
                    }

                    if (criteria.LocationId.HasValue)
                    {
                        appointments = appointments.Where(appointment => appointment.LocationId == criteria.LocationId.Value);
                    }

                    if (criteria.PsychologistId.HasValue)
                    {
                        appointments = appointments.Where(appointment => appointment.PsychologistId == criteria.PsychologistId.Value);
                    }

                    if (criteria.PsychometristId.HasValue)
                    {
                        appointments = appointments.Where(appointment => appointment.PsychometristId == criteria.PsychometristId.Value);
                    }

                    if (criteria.ExcludePsychometristInvoicedAppointments)
                    {
                        if (criteria.ExcludePsychometristInvoiceAppointmentsIgnoreInvoiceId.HasValue)
                        {
                            var invoiceId = criteria.ExcludePsychometristInvoiceAppointmentsIgnoreInvoiceId.Value;

                            appointments = appointments.Where(appointment =>
                                !appointment.InvoiceLineGroupAppointments.Any(ilga =>
                                    ilga.InvoiceLineGroup.Invoice.PayableToId == criteria.PsychometristId &&
                                    ilga.InvoiceLineGroup.Invoice.InvoiceId != invoiceId
                                )
                            );
                        }
                        else
                        {
                            appointments = appointments.Where(appointment =>
                                !appointment.InvoiceLineGroupAppointments.Any(ilga =>
                                    ilga.InvoiceLineGroup.Invoice.PayableToId == criteria.PsychometristId
                                )
                            );
                        }
                    }
                }

                return Execute<AppointmentEntity>(
                        (ILLBLGenProQuery)
                        appointments
                    )
                    .Select(appointment => appointment.ToAppointment())
                    .ToList();
            }
        }

        public IEnumerable<Appointment> GetAppointments(AppointmentSearchCriteria criteria)
        {
            return GetAppointments(criteria, AppointmentPath);
        }

        public IEnumerable<Appointment> GetAppointmentsForPsychometristInvoice(AppointmentSearchCriteria criteria)
        {
            return GetAppointments(criteria, PsychometristInvoiceAppointmentPath);
        }

        public IEnumerable<AppointmentSequence> GetAppointmentSequences(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return
                    Execute<AppointmentSequenceEntity>(
                        (ILLBLGenProQuery)
                        meta.AppointmentSequence
                        .Where(appointmentSequence => isActive == null || appointmentSequence.IsActive == isActive.Value)
                    )
                    .Select(appointmentSequence => appointmentSequence.ToAppointmentSequence())
                    .ToList();
            }
        }

        public IEnumerable<AppointmentStatus> GetAppointmentStatuses(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return
                    Execute<AppointmentStatusEntity>(
                        (ILLBLGenProQuery)
                        meta.AppointmentStatus
                        .Where(appointmentStatus => isActive == null || appointmentStatus.IsActive == isActive.Value)
                    )
                    .Select(appointmentStatus => appointmentStatus.ToAppointmentStatus())
                    .ToList();
            }
        }

        public AppointmentProtocolResponse GetAppointmentProtocolResponse(int appointmentId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var appointmentEntity = new AppointmentEntity
                {
                    AppointmentId = appointmentId,
                };

                var prefetch = new PrefetchPath2(EntityType.AppointmentEntity);

                prefetch.Add(AppointmentEntity.PrefetchPathAppointmentProtocolResponse);

                var appointmentExists = adapter.FetchEntity(appointmentEntity, prefetch);

                if (!appointmentExists)
                {
                    throw new ArgumentOutOfRangeException(nameof(appointmentId));
                }

                var entity = appointmentEntity.AppointmentProtocolResponse
                    ?? new AppointmentProtocolResponseEntity
                    {
                        AppointmentId = appointmentId,
                    };

                return entity.ToAppointmentProtocolResponse();
            }
        }

        public IEnumerable<AppointmentProtocolResponseValue> GetAppointmentProtocolResponseValues(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return
                    Execute<AppointmentProtocolResponseValueEntity>(
                        (ILLBLGenProQuery)
                        meta.AppointmentProtocolResponseValue
                        .Where(appointmentProtocolResponseValue => isActive == null || appointmentProtocolResponseValue.IsActive == isActive.Value)
                    )
                    .Select(appointmentProtocolResponseValue => appointmentProtocolResponseValue.ToAppointmentProtocolResponseValue())
                    .ToList();
            }
        }

        public int SaveAppointment(Appointment appointment)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var isNew = appointment.IsNew();

                var appointmentEntity = new AppointmentEntity
                {
                    IsNew = isNew,
                    AppointmentId = appointment.AppointmentId,
                };

                if (!isNew)
                {
                    var prefetch = new PrefetchPath2(EntityType.AppointmentEntity);

                    prefetch.Add(AppointmentEntity.PrefetchPathAppointmentAttributes);

                    adapter.FetchEntity(appointmentEntity, prefetch);
                }
                else
                {
                    appointmentEntity.CreateDate = _date.UtcNow;
                    appointmentEntity.CreateUserId = appointment.CreateUser.UserId;
                }

                appointmentEntity.LocationId = appointment.Location.AddressId;
                appointmentEntity.PsychometristId = appointment.Psychometrist.UserId;
                appointmentEntity.PsychologistId = appointment.Psychologist.UserId;
                appointmentEntity.AppointmentStatusId = appointment.AppointmentStatus.AppointmentStatusId;
                appointmentEntity.AppointmentTime = appointment.AppointmentTime;
                appointmentEntity.AssessmentId = appointment.Assessment.AssessmentId;
                appointmentEntity.PsychologistInvoiceLock = appointment.PsychologistInvoiceLock;

                if (null == appointment.RoomRentalBillableAmount)
                {
                    appointmentEntity.SetNewFieldValue((int)AppointmentFieldIndex.RoomRentalBillableAmount, null);
                }
                else
                {
                    appointmentEntity.RoomRentalBillableAmount = appointment.RoomRentalBillableAmount;
                }

                if (null == appointment.CancellationDate)
                {
                    appointmentEntity.SetNewFieldValue((int)AppointmentFieldIndex.CancellationDate, null);
                }
                else
                {
                    appointmentEntity.CancellationDate = appointment.CancellationDate;
                }

                if (string.IsNullOrWhiteSpace(appointment.CancellationReason))
                {
                    appointmentEntity.SetNewFieldValue((int)AppointmentFieldIndex.CancellationReason, null);
                }
                else
                {
                    appointmentEntity.CancellationReason = appointment.CancellationReason;
                }

                if (!isNew)
                {
                    var attributesToRemove = appointmentEntity.AppointmentAttributes
                        .Where(appointmentAttribute =>
                            !appointment.Attributes.Any(attribute => attribute.Attribute.AttributeId == appointmentAttribute.AttributeId
                        )
                    )
                    .ToList();

                    foreach (var attribute in attributesToRemove)
                    {
                        uow.AddForDelete(attribute);
                    }

                    var attributesToUpdate = appointment.Attributes
                        .Where(attribute =>
                            appointmentEntity.AppointmentAttributes.Any(appointmentAttribute =>
                                appointmentAttribute.AttributeId == attribute.Attribute.AttributeId &&
                                appointmentAttribute.Value != attribute.Value
                        )
                    )
                    .ToList();

                    foreach (var attribute in attributesToUpdate)
                    {
                        var appointmentAttribute = appointmentEntity.AppointmentAttributes.SingleOrDefault(aa => aa.AttributeId == attribute.Attribute.AttributeId);
                        if (null != appointmentAttribute)
                        {
                            if (null == attribute.Value)
                            {
                                appointmentAttribute.SetNewFieldValue((int)AppointmentAttributeFieldIndex.Value, null);
                            }
                            else
                            {
                                appointmentAttribute.Value = attribute.Value;
                            }
                        }
                    }
                }

                var attributesToAdd = appointment.Attributes
                    .Where(attribute =>
                        !appointmentEntity.AppointmentAttributes.Any(appointmentAttribute =>
                            appointmentAttribute.AttributeId == attribute.Attribute.AttributeId
                        )
                    )
                    .ToList();

                appointmentEntity.AppointmentAttributes.AddRange(
                    attributesToAdd.Select(attribute => new AppointmentAttributeEntity
                    {
                        AttributeId = attribute.Attribute.AttributeId,
                        Value = attribute.Value,
                    })
                );

                uow.AddForSave(appointmentEntity);

                uow.Commit(adapter);

                return appointmentEntity.AppointmentId;
            }
        }

        public int SaveAppointmentStatus(AppointmentStatus appointmentStatus)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = appointmentStatus.IsNew();

                var appointmentStatusEntity = new AppointmentStatusEntity
                {
                    IsNew = isNew,
                    AppointmentStatusId = appointmentStatus.AppointmentStatusId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(appointmentStatusEntity);
                }

                appointmentStatusEntity.Name = appointmentStatus.Name;
                appointmentStatusEntity.Description = appointmentStatus.Description;
                appointmentStatusEntity.NotifyReferralSource = appointmentStatus.NotifyReferralSource;
                appointmentStatusEntity.CanInvoice = appointmentStatus.CanInvoice;
                appointmentStatusEntity.ShowOnSchedule = appointmentStatus.ShowOnSchedule;
                appointmentStatusEntity.ClaimantSeen = appointmentStatus.ClaimantSeen;
                appointmentStatusEntity.Sort = appointmentStatus.Sort;
                appointmentStatusEntity.IsActive = appointmentStatus.IsActive;
                
                adapter.SaveEntity(appointmentStatusEntity, false);

                return appointmentStatusEntity.AppointmentStatusId;
            }
        }

        public int SaveAppointmentProtocolResponse(AppointmentProtocolResponse appointmentProtocolResponse)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var appointmentEntity = new AppointmentEntity
                {
                    AppointmentId = appointmentProtocolResponse.AppointmentId,
                };

                var prefetch = new PrefetchPath2(EntityType.AppointmentEntity);

                prefetch.Add(AppointmentEntity.PrefetchPathAppointmentProtocolResponse);

                var appointmentExists = adapter.FetchEntity(appointmentEntity, prefetch);
                
                if (!appointmentExists)
                {
                    throw new ArgumentOutOfRangeException(nameof(appointmentProtocolResponse), $"Appointment {appointmentProtocolResponse.AppointmentId} does not exist.");
                }

                var entity = appointmentEntity.AppointmentProtocolResponse
                    ?? new AppointmentProtocolResponseEntity
                    {
                        AppointmentId = appointmentProtocolResponse.AppointmentId,
                        CreateDate = _date.UtcNow,
                        CreateUserId = appointmentProtocolResponse.CreateUser.UserId,
                    };

                if (null == appointmentProtocolResponse.OnTimeArrivalAndNotificationId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.OnTimeArrivalAndNotificationId, null);
                }
                else
                {
                    entity.OnTimeArrivalAndNotificationId = appointmentProtocolResponse.OnTimeArrivalAndNotificationId;
                }

                if (null == appointmentProtocolResponse.ClaimantArrivalNotificationId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.ClaimantArrivalNotificationId, null);
                }
                else
                {
                    entity.ClaimantArrivalNotificationId = appointmentProtocolResponse.ClaimantArrivalNotificationId;
                }

                if (null == appointmentProtocolResponse.CovidFormsCompletedBeforeEnteringRoomId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.CovidFormsCompletedBeforeEnteringRoomId, null);
                }
                else
                {
                    entity.CovidFormsCompletedBeforeEnteringRoomId = appointmentProtocolResponse.CovidFormsCompletedBeforeEnteringRoomId;
                }

                if (null == appointmentProtocolResponse.TestedClaimantsEnglishReadingLevelId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.TestedClaimantsEnglishReadingLevelId, null);
                }
                else
                {
                    entity.TestedClaimantsEnglishReadingLevelId = appointmentProtocolResponse.TestedClaimantsEnglishReadingLevelId;
                }

                if (null == appointmentProtocolResponse.TommSimsScoreNotificationId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.TommSimsScoreNotificationId, null);
                }
                else
                {
                    entity.TommSimsScoreNotificationId = appointmentProtocolResponse.TommSimsScoreNotificationId;
                }

                if (null == appointmentProtocolResponse.AskedWhichTestsShouldBeRemovedId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.AskedWhichTestsShouldBeRemovedId, null);
                }
                else
                {
                    entity.AskedWhichTestsShouldBeRemovedId = appointmentProtocolResponse.AskedWhichTestsShouldBeRemovedId;
                }

                if (null == appointmentProtocolResponse.AdvisedOfUnexpectedDelaysId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.AdvisedOfUnexpectedDelaysId, null);
                }
                else
                {
                    entity.AdvisedOfUnexpectedDelaysId = appointmentProtocolResponse.AdvisedOfUnexpectedDelaysId;
                }

                if (null == appointmentProtocolResponse.AfterAssessmentNotificationId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.AfterAssessmentNotificationId, null);
                }
                else
                {
                    entity.AfterAssessmentNotificationId = appointmentProtocolResponse.AfterAssessmentNotificationId;
                }

                if (null == appointmentProtocolResponse.AllPapersHaveClaimantInitialsAndDateId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.AllPapersHaveClaimantInitialsAndDateId, null);
                }
                else
                {
                    entity.AllPapersHaveClaimantInitialsAndDateId = appointmentProtocolResponse.AllPapersHaveClaimantInitialsAndDateId;
                }

                if (null == appointmentProtocolResponse.ScoringDoubleCheckedId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.ScoringDoubleCheckedId, null);
                }
                else
                {
                    entity.ScoringDoubleCheckedId = appointmentProtocolResponse.ScoringDoubleCheckedId;
                }

                if (null == appointmentProtocolResponse.RelevantObservationsDocumentedId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.RelevantObservationsDocumentedId, null);
                }
                else
                {
                    entity.RelevantObservationsDocumentedId = appointmentProtocolResponse.RelevantObservationsDocumentedId;
                }

                if (null == appointmentProtocolResponse.ErrorCheckedObservationsId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.ErrorCheckedObservationsId, null);
                }
                else
                {
                    entity.ErrorCheckedObservationsId = appointmentProtocolResponse.ErrorCheckedObservationsId;
                }

                if (null == appointmentProtocolResponse.AllFormsCompletedId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.AllFormsCompletedId, null);
                }
                else
                {
                    entity.AllFormsCompletedId = appointmentProtocolResponse.AllFormsCompletedId;
                }

                if (null == appointmentProtocolResponse.TimeAssessmentLabelCompletedId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.TimeAssessmentLabelCompletedId, null);
                }
                else
                {
                    entity.TimeAssessmentLabelCompletedId = appointmentProtocolResponse.TimeAssessmentLabelCompletedId;
                }

                if (null == appointmentProtocolResponse.ScansUploadedNotificationId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.ScansUploadedNotificationId, null);
                }
                else
                {
                    entity.ScansUploadedNotificationId = appointmentProtocolResponse.ScansUploadedNotificationId;
                }

                if (null == appointmentProtocolResponse.UploadedScanLegibilityVerifiedId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.UploadedScanLegibilityVerifiedId, null);
                }
                else
                {
                    entity.UploadedScanLegibilityVerifiedId = appointmentProtocolResponse.UploadedScanLegibilityVerifiedId;
                }

                if (null == appointmentProtocolResponse.SpareSetReplenishmentRequestSentId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.SpareSetReplenishmentRequestSentId, null);
                }
                else
                {
                    entity.SpareSetReplenishmentRequestSentId = appointmentProtocolResponse.SpareSetReplenishmentRequestSentId;
                }

                if (null == appointmentProtocolResponse.RespondedToQuestionsWithinRequiredTimeframeId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.RespondedToQuestionsWithinRequiredTimeframeId, null);
                }
                else
                {
                    entity.RespondedToQuestionsWithinRequiredTimeframeId = appointmentProtocolResponse.RespondedToQuestionsWithinRequiredTimeframeId;
                }

                if (null == appointmentProtocolResponse.StapledItemsTogetherId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.StapledItemsTogetherId, null);
                }
                else
                {
                    entity.StapledItemsTogetherId = appointmentProtocolResponse.StapledItemsTogetherId;
                }

                if (null == appointmentProtocolResponse.WillPersonallyDropOffPackageId)
                {
                    entity.SetNewFieldValue((int)AppointmentProtocolResponseFieldIndex.WillPersonallyDropOffPackageId, null);
                }
                else
                {
                    entity.WillPersonallyDropOffPackageId = appointmentProtocolResponse.WillPersonallyDropOffPackageId;
                }

                entity.Comments = appointmentProtocolResponse.Comments;

                entity.UpdateDate = _date.UtcNow;
                
                entity.UpdateUserId = appointmentProtocolResponse.UpdateUser.UserId;

                uow.AddForSave(entity);

                uow.Commit(adapter);

                return entity.AppointmentId;
            }
        }
    }
}
