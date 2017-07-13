using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Appointments;
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
        private readonly ITimezoneService _timezoneService = null;

        public AppointmentRepository(
            IDataAccessAdapterFactory adapterFactory,
            IDate date,
            ICompanyRepository companyRepository,
            ITimezoneService timezoneService
        ) : base(adapterFactory)
        {
            _date = date;
            _companyRepository = companyRepository;
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
                        .SubPath(appointmentStatusPath => appointmentStatusPath
                            .Prefetch<ReferralSourceAppointmentStatusSettingEntity>(appointmentStatus => appointmentStatus.ReferralSourceAppointmentStatusSettings)
                                .SubPath(referralSourceAppointmentStatusSettingPath => referralSourceAppointmentStatusSettingPath
                                    .Prefetch<ReferralSourceEntity>(referralSourceAppointmentStatusSetting => referralSourceAppointmentStatusSetting.ReferralSource)
                                    .Prefetch<InvoiceTypeEntity>(referralSourceAppointmentStatusSetting => referralSourceAppointmentStatusSetting.InvoiceType)
                                )
                        )
                    .Prefetch<AppointmentAttributeEntity>(appointment => appointment.AppointmentAttributes)
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
                            .Prefetch<ReferralSourceEntity>(assessment => assessment.ReferralSource)
                                .SubPath(referralSourcePath => referralSourcePath
                                    .Prefetch<ReferralSourceTypeEntity>(referralSource => referralSource.ReferralSourceType)
                                )
                            .Prefetch<ReportStatusEntity>(assessment => assessment.ReportStatus)
                            .Prefetch<UserEntity>(assessment => assessment.DocListWriter)
                            .Prefetch<UserEntity>(assessment => assessment.NotesWriter)
                            .Prefetch<AssessmentClaimEntity>(assessment => assessment.AssessmentClaims)
                                .SubPath(assessmentClaimPath => assessmentClaimPath
                                    .Prefetch<ClaimEntity>(assessmentClaim => assessmentClaim.Claim)
                                        .SubPath(claimPath => claimPath
                                            .Prefetch<ClaimantEntity>(claim => claim.Claimant)
                                        )
                                )
                            .Prefetch<AssessmentAttributeEntity>(assessment => assessment.AssessmentAttributes)
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
                        )
                    .Prefetch<UserEntity>(appointment => appointment.CreateUser)
                    .Prefetch<UserEntity>(appointment => appointment.UpdateUser)
                );

        #endregion

        public Appointment GetAppointment(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Appointment
                    .WithPath(AppointmentPath)
                    .Where(appointment => appointment.AppointmentId == id)
                    .SingleOrDefault()
                    .ToAppointment();
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
                Attributes = Enumerable.Empty<Models.Attributes.Attribute>(),
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

        public IEnumerable<Appointment> GetAppointments(AppointmentSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var appointments = meta.Appointment
                    .WithPath(AppointmentPath);

                if (null != criteria)
                {
                    if (criteria.AppointmentId.HasValue)
                    {
                        appointments = appointments.Where(appointment => appointment.AppointmentId == criteria.AppointmentId.Value);
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
                }

                return Execute<AppointmentEntity>(
                        (ILLBLGenProQuery)
                        appointments
                    )
                    .Select(appointment => appointment.ToAppointment())
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

                appointmentEntity.LocationId = appointment.Location.AddressId;
                appointmentEntity.PsychometristId = appointment.Psychometrist.UserId;
                appointmentEntity.PsychologistId = appointment.Psychologist.UserId;
                appointmentEntity.AppointmentStatusId = appointment.AppointmentStatus.AppointmentStatusId;
                appointmentEntity.AppointmentTime = appointment.AppointmentTime;
                appointmentEntity.AssessmentId = appointment.Assessment.AssessmentId;

                if (!isNew)
                {
                    var attributesToRemove = appointmentEntity.AppointmentAttributes
                        .Where(appointmentAttribute =>
                            !appointment.Attributes.Any(attribute => attribute.AttributeId == appointmentAttribute.AttributeId
                        )
                    );

                    foreach (var attribute in attributesToRemove)
                    {
                        uow.AddForDelete(attribute);
                    }
                }

                var attributesToAdd = appointment.Attributes
                    .Where(attribute =>
                        !appointmentEntity.AppointmentAttributes.Any(appointmentAttribute =>
                            appointmentAttribute.AttributeId == attribute.AttributeId
                        )
                    );

                appointmentEntity.AppointmentAttributes.AddRange(
                    attributesToAdd.Select(attribute => new AppointmentAttributeEntity
                    {
                        AttributeId = attribute.AttributeId,
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
                appointmentStatusEntity.Sort = appointmentStatus.Sort;
                appointmentStatusEntity.IsActive = appointmentStatus.IsActive;
                
                adapter.SaveEntity(appointmentStatusEntity, false);

                return appointmentStatusEntity.AppointmentStatusId;
            }
        }

        public int GetLateCancellationStatusId()
        {
            //TODO: retrieve from DB or config
            return 8;
        }

    }
}
