using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Tasks;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Appointments
{
    public class AppointmentRepository : RepositoryBase, IAppointmentRepository
    {
        private readonly INow _now = null;

        public AppointmentRepository(
            IDataAccessAdapterFactory adapterFactory,
            INow now
        ) : base(adapterFactory)
        {
            _now = now;
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<AppointmentEntity>, IPathEdgeRootParser<AppointmentEntity>>
            AppointmentPath =
                (appointmentPath => appointmentPath
                    .Prefetch<AddressEntity>(appointment => appointment.Location)
                        .SubPath(addressPath => addressPath
                            .Prefetch<AddressTypeEntity>(address => address.AddressType)
                        )
                    .Prefetch<UserEntity>(appointment => appointment.Psychologist)
                        .SubPath(userPath => userPath
                            .Prefetch<CompanyEntity>(user => user.Company)
                            .Prefetch<RoleEntity>(user => user.RoleCollectionViaUserRoles)
                                .SubPath(rolePath => rolePath
                                    .Prefetch<RightEntity>(role => role.RightCollectionViaRoleRights)
                                )
                        )
                    .Prefetch<UserEntity>(appointment => appointment.Psychometrist)
                        .SubPath(userPath => userPath
                            .Prefetch<CompanyEntity>(user => user.Company)
                            .Prefetch<RoleEntity>(user => user.RoleCollectionViaUserRoles)
                                .SubPath(rolePath => rolePath
                                    .Prefetch<RightEntity>(role => role.RightCollectionViaRoleRights)
                                )
                        )
                    .Prefetch<AppointmentStatusEntity>(appointment => appointment.AppointmentStatus)
                    .Prefetch<TaskEntity>(appointment => appointment.TaskCollectionViaAppointmentTasks)
                        .SubPath(taskPath => taskPath
                            .Prefetch<TaskStatusEntity>(task => task.TaskStatus)
                            .Prefetch<TaskTemplateEntity>(task => task.TaskTemplate)
                                .SubPath(taskTemplatePath => taskTemplatePath
                                    .Prefetch<CompanyEntity>(taskTemplate => taskTemplate.Company)
                                )
                        )
                    .Prefetch<AssessmentEntity>(appointment => appointment.Assessment)
                        .SubPath(assessmentPath => assessmentPath
                            .Prefetch<AssessmentTypeEntity>(assessment => assessment.AssessmentType)
                                .SubPath(assessmentTypePath => assessmentTypePath
                                    .Prefetch<ReportTypeEntity>(assessmentType => assessmentType.ReportTypeCollectionViaAssessmentTypeReportTypes)
                                )
                            .Prefetch<ReferralTypeEntity>(assessment => assessment.ReferralType)
                                .SubPath(referralTypePath => referralTypePath
                                    .Prefetch<IssueInDisputeEntity>(referralType => referralType.IssueInDisputeCollectionViaReferralTypeIssuesInDispute)
                                )
                            .Prefetch<ReferralSourceEntity>(assessment => assessment.ReferralSource)
                                .SubPath(referralSourcePath => referralSourcePath
                                    .Prefetch<ReferralSourceTypeEntity>(referralSource => referralSource.ReferralSourceType)
                                )
                            .Prefetch<ReportStatusEntity>(assessment => assessment.ReportStatus)
                            .Prefetch<UserEntity>(assessment => assessment.DocListWriter)
                                    //.SubPath(userPath => userPath
                                    //    .Prefetch<CompanyEntity>(user => user.Company)
                                    //    .Prefetch<RoleEntity>(user => user.RoleCollectionViaUserRoles)
                                    //        .SubPath(rolePath => rolePath
                                    //            .Prefetch<RightEntity>(role => role.RightCollectionViaRoleRights)
                                    //        )
                                    //)
                            .Prefetch<UserEntity>(assessment => assessment.NotesWriter)
                                    //.SubPath(userPath => userPath
                                    //    .Prefetch<CompanyEntity>(user => user.Company)
                                    //    .Prefetch<RoleEntity>(user => user.RoleCollectionViaUserRoles)
                                    //        .SubPath(rolePath => rolePath
                                    //            .Prefetch<RightEntity>(role => role.RightCollectionViaRoleRights)
                                    //        )
                                    //)
                            .Prefetch<CompanyEntity>(assessment => assessment.Company)
                            .Prefetch<ClaimEntity>(assessment => assessment.ClaimCollectionViaAssessmentClaims)
                                .SubPath(claimPath => claimPath
                                    .Prefetch<ClaimantEntity>(claim => claim.Claimant)
                                )
                            .Prefetch<IssueInDisputeEntity>(assessment => assessment.IssueInDisputeCollectionViaAssessmentIssuesInDispute)
                        )
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

        public Appointment NewAppointment(int assessmentId, int companyId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var assessmentEntity = meta.Assessment.Where(assessment => assessment.AssessmentId == assessmentId).SingleOrDefault();

                if (null == assessmentEntity)
                {
                    throw new ArgumentOutOfRangeException("assessmentId");
                }

                var companyEntity = meta.Company.Where(company => company.CompanyId == companyId).SingleOrDefault();

                if (null == companyEntity)
                {
                    throw new ArgumentOutOfRangeException("companyId");
                }

                var taskStatusEntity = meta.TaskStatus
                    .OrderBy(taskStatus => taskStatus.TaskStatusId)
                    .FirstOrDefault();

                var taskTemplates = meta.TaskTemplate
                    .Where(taskTemplate => taskTemplate.CompanyId == companyId)
                    .ToList();

                return new Appointment
                {
                    AppointmentTime = _now.DateTimeNow,
                    CompanyId = companyId,
                    AppointmentTasks = taskTemplates.Select(taskTemplate => new Task
                    {
                        TaskStatusId = null != taskStatusEntity ? taskStatusEntity.TaskStatusId : 0,
                        TaskStatus = taskStatusEntity.ToTaskStatus(),
                        TaskTemplateId = taskTemplate.TaskTemplateId,
                        TaskTemplate = taskTemplate.ToTaskTemplate(),
                    }),
                    Assessment = assessmentEntity.ToAssessment(),
                };
            }
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

                    if (criteria.AppointmentStatusId.HasValue)
                    {
                        appointments = appointments.Where(appointment => appointment.AppointmentStatusId == criteria.AppointmentStatusId.Value);
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
                        .WithPath(AppointmentPath)
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

                    prefetch.Add(AppointmentEntity.PrefetchPathAppointmentTasks)
                        .SubPath.Add(AppointmentTaskEntity.PrefetchPathTask);

                    adapter.FetchEntity(appointmentEntity, prefetch);
                }

                appointmentEntity.LocationId = appointment.Location.AddressId;
                appointmentEntity.PsychometristId = appointment.Psychometrist.UserId;
                appointmentEntity.PsychologistId = appointment.Psychologist.UserId;
                appointmentEntity.AppointmentStatusId = appointment.AppointmentStatus.AppointmentStatusId;
                appointmentEntity.AppointmentTime = appointment.AppointmentTime;
                appointmentEntity.AssessmentId = appointment.Assessment.AssessmentId;
                appointmentEntity.PsychometristConfirmed = appointment.PsychometristConfirmed;

                var tasksToAdd = appointment.AppointmentTasks
                    .Where(task =>
                        !appointmentEntity.AppointmentTasks.Any(appointmentTask =>
                            appointmentTask.Task.TaskTemplateId == task.TaskTemplate.TaskTemplateId
                        )
                    );

                appointmentEntity.AppointmentTasks.AddRange(
                    tasksToAdd.Select(task => new AppointmentTaskEntity
                    {
                        Task = new TaskEntity
                        {
                            TaskTemplateId = task.TaskTemplate.TaskTemplateId,
                            TaskStatusId = task.TaskStatus.TaskStatusId,
                        },
                    })
                );

                if (!isNew)
                {
                    var tasksToRemove = appointmentEntity.AppointmentTasks
                        .Where(appointmentTask =>
                            !appointment.AppointmentTasks.Any(task =>
                                task.TaskTemplate.TaskTemplateId == appointmentTask.Task.TaskTemplateId)
                        );

                    foreach (var task in tasksToRemove)
                    {
                        uow.AddForDelete(task);
                    }

                    var tasksToUpdate = appointmentEntity.AppointmentTasks
                        .Where(appointmentTask =>
                            appointment.AppointmentTasks.Any(task =>
                                appointmentTask.Task.TaskTemplateId == task.TaskTemplate.TaskTemplateId &&
                                appointmentTask.Task.TaskStatusId != task.TaskStatus.TaskStatusId
                            )
                        );

                    foreach (var appointmentTask in tasksToUpdate)
                    {
                        var task = appointment.AppointmentTasks.First(t => t.TaskId == appointmentTask.TaskId);

                        appointmentTask.Task.TaskStatusId = task.TaskStatus.TaskStatusId;
                    }
                }
                
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
                appointmentStatusEntity.IsActive = appointmentStatus.IsActive;
                
                adapter.SaveEntity(appointmentStatusEntity, false);

                return appointmentStatusEntity.AppointmentStatusId;
            }
        }
    }
}
