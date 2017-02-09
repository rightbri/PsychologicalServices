using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Assessments;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Assessments
{
    public class AssessmentRepository : RepositoryBase, IAssessmentRepository
    {
        public AssessmentRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<AssessmentEntity>, IPathEdgeRootParser<AssessmentEntity>>
            AssessmentPath =
                (assessmentPath => assessmentPath
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
                    .Prefetch<AppointmentEntity>(assessment => assessment.Appointments)
                        .SubPath(appointmentPath => appointmentPath
                            .Prefetch<AddressEntity>(appointment => appointment.Location)
                                .SubPath(addressPath => addressPath
                                    .Prefetch<AddressTypeEntity>(address => address.AddressType)
                                )
                            .Prefetch<UserEntity>(appointment => appointment.Psychologist)
                                //.SubPath(userPath => userPath
                                //    .Prefetch<CompanyEntity>(user => user.Company)
                                //    .Prefetch<RoleEntity>(user => user.RoleCollectionViaUserRoles)
                                //        .SubPath(rolePath => rolePath
                                //            .Prefetch<RightEntity>(role => role.RightCollectionViaRoleRights)
                                //        )
                                //)
                            .Prefetch<UserEntity>(appointment => appointment.Psychometrist)
                                //.SubPath(userPath => userPath
                                //    .Prefetch<CompanyEntity>(user => user.Company)
                                //    .Prefetch<RoleEntity>(user => user.RoleCollectionViaUserRoles)
                                //        .SubPath(rolePath => rolePath
                                //            .Prefetch<RightEntity>(role => role.RightCollectionViaRoleRights)
                                //        )
                                //)
                            .Prefetch<AppointmentStatusEntity>(appointment => appointment.AppointmentStatus)
                            .Prefetch<TaskEntity>(appointment => appointment.TaskCollectionViaAppointmentTasks)
                                .SubPath(taskPath => taskPath
                                    .Prefetch<TaskStatusEntity>(task => task.TaskStatus)
                                    .Prefetch<TaskTemplateEntity>(task => task.TaskTemplate)
                                        .SubPath(taskTemplatePath => taskTemplatePath
                                            .Prefetch<CompanyEntity>(taskTemplate => taskTemplate.Company)
                                        )
                                )
                        )
                    .Prefetch<IssueInDisputeEntity>(assessment => assessment.IssueInDisputeCollectionViaAssessmentIssuesInDispute)
                );

        #endregion

        public Assessment GetAssessment(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Assessment
                    .WithPath(AssessmentPath)
                    .Where(assessment => assessment.AssessmentId == id)
                    .SingleOrDefault()
                    .ToAssessment();
            }
        }

        public AssessmentType GetAssessmentType(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.AssessmentType
                    .Where(assessmentType => assessmentType.AssessmentTypeId == id)
                    .SingleOrDefault()
                    .ToAssessmentType();
            }
        }

        public IEnumerable<Assessment> GetAssessments(AssessmentSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var assessments = meta.Assessment
                    .WithPath(AssessmentPath);

                if (null != criteria)
                {
                    if (criteria.AssessmentId.HasValue)
                    {
                        assessments = assessments.Where(assessment => assessment.AssessmentId == criteria.AssessmentId.Value);
                    }

                    if (criteria.AssesmentTypeId.HasValue)
                    {
                        assessments = assessments.Where(assessment => assessment.AssessmentTypeId == criteria.AssesmentTypeId.Value);
                    }

                    if (criteria.ReferralTypeId.HasValue)
                    {
                        assessments = assessments.Where(assessment => assessment.ReferralTypeId == criteria.ReferralTypeId.Value);
                    }

                    if (criteria.ReferralSourceId.HasValue)
                    {
                        assessments = assessments.Where(assessment => assessment.ReferralSourceId == criteria.ReferralSourceId.Value);
                    }

                    if (criteria.ReportStatusId.HasValue)
                    {
                        assessments = assessments.Where(assessment => assessment.ReportStatusId == criteria.ReportStatusId.Value);
                    }

                    if (criteria.DocListWriterId.HasValue)
                    {
                        assessments = assessments.Where(assessment => assessment.DocListWriterId == criteria.DocListWriterId.Value);
                    }

                    if (criteria.NotesWriterId.HasValue)
                    {
                        assessments = assessments.Where(assessment => assessment.NotesWriterId == criteria.NotesWriterId.Value);
                    }

                    if (criteria.MedicalFileReceivedDateStart.HasValue)
                    {
                        assessments = assessments.Where(assessment => assessment.MedicalFileReceivedDate >= criteria.MedicalFileReceivedDateStart.Value);
                    }

                    if (criteria.MedicalFileReceivedDateEnd.HasValue)
                    {
                        assessments = assessments.Where(assessment => assessment.MedicalFileReceivedDate <= criteria.MedicalFileReceivedDateEnd.Value);
                    }

                    if (criteria.FileSizeMin.HasValue)
                    {
                        assessments = assessments.Where(assessment => assessment.FileSize >= criteria.FileSizeMin.Value);
                    }

                    if (criteria.FileSizeMax.HasValue)
                    {
                        assessments = assessments.Where(assessment => assessment.FileSize <= criteria.FileSizeMax.Value);
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.ReferralSourceContactEmail))
                    {
                        assessments = assessments.Where(assessment => assessment.ReferralSourceContactEmail.Contains(criteria.ReferralSourceContactEmail));
                    }

                    if (criteria.CompanyId.HasValue)
                    {
                        assessments = assessments.Where(assessment => assessment.CompanyId == criteria.CompanyId.Value);
                    }

                    if (criteria.Deleted.HasValue)
                    {
                        assessments = assessments.Where(assessment => assessment.Deleted == criteria.Deleted.Value);
                    }
                }

                return Execute<AssessmentEntity>(
                        (ILLBLGenProQuery)
                        assessments
                    )
                    .Select(assessment => assessment.ToAssessment())
                    .ToList();
            }
        }

        public IEnumerable<AssessmentType> GetAssessmentTypes(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<AssessmentTypeEntity>(
                    (ILLBLGenProQuery)
                    meta.AssessmentType
                        .Where(assessmentType => isActive == null || assessmentType.IsActive == isActive.Value)
                    )
                    .Select(assessmentType => assessmentType.ToAssessmentType())
                    .ToList();
            }
        }

        public int SaveAssessment(Assessment assessment)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var isNew = assessment.IsNew();

                var assessmentEntity = new AssessmentEntity
                {
                    IsNew = isNew,
                    AssessmentId = assessment.AssessmentId,
                };

                if (!isNew)
                {
                    var prefetch = new PrefetchPath2(EntityType.AssessmentEntity);

                    //prefetch.Add(AssessmentEntity.PrefetchPathClaimCollectionViaAssessmentClaims);

                    //prefetch.Add(AssessmentEntity.PrefetchPathAppointments);

                    prefetch.Add(AssessmentEntity.PrefetchPathAssessmentIssuesInDispute);
                    
                    adapter.FetchEntity(assessmentEntity, prefetch);
                }

                assessmentEntity.AssessmentTypeId = assessment.AssessmentTypeId;
                assessmentEntity.ReferralTypeId = assessment.ReferralTypeId;
                assessmentEntity.ReferralSourceId = assessment.ReferralSourceId;
                assessmentEntity.ReportStatusId = assessment.ReportStatusId;
                assessmentEntity.DocListWriterId = assessment.DocListWriterId;
                assessmentEntity.NotesWriterId = assessment.NotesWriterId;
                assessmentEntity.MedicalFileReceivedDate = assessment.MedicalFileReceivedDate;
                assessmentEntity.FileSize = assessment.FileSize;
                assessmentEntity.ReferralSourceContactEmail = assessment.ReferralSourceContactEmail;
                assessmentEntity.CompanyId = assessment.CompanyId;
                assessmentEntity.Deleted = assessment.Deleted;

                var issuesInDisputeToAdd = assessment.IssuesInDispute
                    .Where(issueInDispute => 
                        !assessmentEntity.AssessmentIssuesInDispute.Any(assessmentIssueInDispute => assessmentIssueInDispute.IssueIsDisputeId == issueInDispute.IssueInDisputeId)
                    );

                var issuesInDisputeToRemove = assessmentEntity.AssessmentIssuesInDispute
                    .Where(assessmentIssueInDispute => 
                        !assessment.IssuesInDispute.Any(issueInDispute => issueInDispute.IssueInDisputeId == assessmentIssueInDispute.IssueIsDisputeId)
                    );

                assessmentEntity.AssessmentIssuesInDispute.AddRange(
                    issuesInDisputeToAdd.Select(issueInDispute => new AssessmentIssueInDisputeEntity
                    {
                        AssessmentId = assessment.AssessmentId,
                        IssueIsDisputeId = issueInDispute.IssueInDisputeId,
                    })
                );

                foreach (var issueInDispute in issuesInDisputeToRemove)
                {
                    uow.AddForDelete(issueInDispute);
                }

                uow.AddForSave(assessmentEntity);


                //var claimsToAdd = assessment.Claims.Where(claim => !assessmentEntity.ClaimCollectionViaAssessmentClaims.Any(assessmentClaim => assessmentClaim.ClaimId == claim.ClaimId));

                //var claimsToRemove = assessmentEntity.ClaimCollectionViaAssessmentClaims.Where(assessmentClaim => !assessment.Claims.Any(claim => claim.ClaimId == assessmentClaim.ClaimId));

                //foreach (var claim in claimsToRemove)
                //{
                //    assessmentEntity.ClaimCollectionViaAssessmentClaims.Remove(claim);
                //}

                
                //var appointmentsToRemove = assessmentEntity.Appointments.Where(assessmentAppointment => !assessment.Appointments.Any(appointment => appointment.AppointmentId == assessmentAppointment.AppointmentId));

                //foreach (var appointment in appointmentsToRemove)
                //{
                //    assessmentEntity.Appointments.Remove(appointment);
                //}
                /*
        public IEnumerable<Claim> Claims { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
                */

                

                //adapter.SaveEntity(assessmentEntity, false);

                uow.Commit(adapter);

                return assessmentEntity.AssessmentId;
            }
        }

        public int SaveAssessmentType(AssessmentType assessmentType)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = assessmentType.IsNew();

                var assessmentTypeEntity = new AssessmentTypeEntity
                {
                    IsNew = isNew,
                    AssessmentTypeId = assessmentType.AssessmentTypeId,
                };

                if (!isNew)
                {
                    var prefetch = new PrefetchPath2(EntityType.AssessmentTypeEntity);

                    prefetch.Add(AssessmentTypeEntity.PrefetchPathAssessmentTypeReportTypes);

                    adapter.FetchEntity(assessmentTypeEntity, prefetch);
                }

                assessmentTypeEntity.Name = assessmentType.Name;
                assessmentTypeEntity.Description = assessmentType.Description;
                assessmentTypeEntity.Duration = assessmentType.Duration;
                assessmentTypeEntity.IsActive = assessmentType.IsActive;

                var reportTypesToAdd = assessmentType.ReportTypes.Where(reportType => !assessmentTypeEntity.AssessmentTypeReportTypes.Any(assessmentTypeReportType => assessmentTypeReportType.ReportTypeId == reportType.ReportTypeId));

                assessmentTypeEntity.AssessmentTypeReportTypes.AddRange(
                    reportTypesToAdd.Select(reportType => new AssessmentTypeReportTypeEntity
                    {
                        AssessmentTypeId = assessmentTypeEntity.AssessmentTypeId,
                        ReportTypeId = reportType.ReportTypeId
                    })
                );

                var reportTypesToDelete = assessmentTypeEntity.AssessmentTypeReportTypes.Where(assessmentTypeReportType => !assessmentType.ReportTypes.Any(reportType => reportType.ReportTypeId == assessmentTypeReportType.ReportTypeId));

                foreach (var reportType in reportTypesToDelete)
                {
                    assessmentTypeEntity.AssessmentTypeReportTypes.Remove(reportType);
                }

                adapter.SaveEntity(assessmentTypeEntity, false);

                return assessmentTypeEntity.AssessmentTypeId;
            }
        }
    }
}
