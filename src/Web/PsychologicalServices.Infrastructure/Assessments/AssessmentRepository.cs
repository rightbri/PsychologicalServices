using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.HelperClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Common.Utility;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Assessments
{
    public class AssessmentRepository : RepositoryBase, IAssessmentRepository
    {
        private readonly IDate _date = null;

        public AssessmentRepository(
            IDataAccessAdapterFactory adapterFactory,
            IDate date
        ) : base(adapterFactory)
        {
            _date = date;
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<AssessmentEntity>, IPathEdgeRootParser<AssessmentEntity>>
            AssessmentPath =
                (assessmentPath => assessmentPath
                    .Prefetch<AssessmentTypeEntity>(assessment => assessment.AssessmentType)
                        .SubPath(assessmentTypePath => assessmentTypePath
                            .Prefetch<AssessmentTypeReportTypeEntity>(assessmentType => assessmentType.AssessmentTypeReportTypes)
                                .SubPath(assessmentTypeReportTypePath => assessmentTypeReportTypePath
                                    .Prefetch<ReportTypeEntity>(assessmentTypeReportType => assessmentTypeReportType.ReportType)
                                )
                        )
                    .Prefetch<ReferralTypeEntity>(assessment => assessment.ReferralType)
                        .SubPath(referralTypePath => referralTypePath
                            .Prefetch<ReferralTypeIssueInDisputeEntity>(referralType => referralType.ReferralTypeIssuesInDispute)
                                .SubPath(referralTypeIssueInDisputePath => referralTypeIssueInDisputePath
                                    .Prefetch<IssueInDisputeEntity>(referralTypeIssueInDispute => referralTypeIssueInDispute.IssueInDispute)
                                )
                        )
                    .Prefetch<ReferralSourceEntity>(assessment => assessment.ReferralSource)
                        .SubPath(referralSourcePath => referralSourcePath
                            .Prefetch<ReferralSourceTypeEntity>(referralSource => referralSource.ReferralSourceType)
                        )
                    .Prefetch<ReportStatusEntity>(assessment => assessment.ReportStatus)
                    .Prefetch<UserEntity>(assessment => assessment.DocListWriter)
                    .Prefetch<UserEntity>(assessment => assessment.NotesWriter)
                    .Prefetch<CompanyEntity>(assessment => assessment.Company)
                    .Prefetch<AssessmentClaimEntity>(assessment => assessment.AssessmentClaims)
                        .SubPath(assessmentClaimPath => assessmentClaimPath
                            .Prefetch<ClaimEntity>(assessmentClaim => assessmentClaim.Claim)
                                .SubPath(claimPath => claimPath
                                    .Prefetch<ClaimantEntity>(claim => claim.Claimant)
                                )
                        )
                    .Prefetch<AppointmentEntity>(assessment => assessment.Appointments)
                        .SubPath(appointmentPath => appointmentPath
                            .Prefetch<AddressEntity>(appointment => appointment.Location)
                                .SubPath(addressPath => addressPath
                                    .Prefetch<AddressTypeEntity>(address => address.AddressType)
                                )
                            .Prefetch<UserEntity>(appointment => appointment.Psychologist)
                            .Prefetch<UserEntity>(appointment => appointment.Psychometrist)
                            .Prefetch<AppointmentStatusEntity>(appointment => appointment.AppointmentStatus)
                            .Prefetch<AppointmentAttributeEntity>(appointment => appointment.AppointmentAttributes)
                                .SubPath(appointmentAttributePath => appointmentAttributePath
                                    .Prefetch<AttributeEntity>(appointmentAttribute => appointmentAttribute.Attribute)
                                        .SubPath(attributePath => attributePath
                                            .Prefetch<AttributeTypeEntity>(attribute => attribute.AttributeType)
                                        )
                                )
                        )
                    .Prefetch<AssessmentIssueInDisputeEntity>(assessment => assessment.AssessmentIssuesInDispute)
                        .SubPath(assessmentIssueInDisputePath => assessmentIssueInDisputePath
                            .Prefetch<IssueInDisputeEntity>(assessmentIssueInDispute => assessmentIssueInDispute.IssueInDispute)
                        )
                    .Prefetch<AssessmentMedRehabEntity>(assessment => assessment.AssessmentMedRehabs)
                    .Prefetch<AssessmentNoteEntity>(assessment => assessment.AssessmentNotes)
                        .SubPath(assessmentNotePath => assessmentNotePath
                            .Prefetch<NoteEntity>(assessmentNote => assessmentNote.Note)
                                .SubPath(notePath => notePath
                                    .Prefetch<UserEntity>(note => note.CreateUser)
                                    .Prefetch<UserEntity>(note => note.UpdateUser)
                                )
                        )
                    .Prefetch<AssessmentColorEntity>(assessment => assessment.AssessmentColors)
                        .SubPath(assessmentColorPath => assessmentColorPath
                            .Prefetch<ColorEntity>(assessmentColor => assessmentColor.Color)
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
                        )
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

                    if (criteria.ClaimantId.HasValue)
                    {
                        assessments = assessments.Where(assessment =>
                            assessment.AssessmentClaims.Any(assessmentClaim =>
                                assessmentClaim.Claim.ClaimantId == criteria.ClaimantId
                            )
                        );
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

                    prefetch.Add(AssessmentEntity.PrefetchPathAppointments)
                        .SubPath.Add(AppointmentEntity.PrefetchPathAppointmentAttributes);
                    
                    prefetch.Add(AssessmentEntity.PrefetchPathAssessmentClaims)
                        .SubPath.Add(AssessmentClaimEntity.PrefetchPathClaim);

                    prefetch.Add(AssessmentEntity.PrefetchPathAssessmentIssuesInDispute);

                    prefetch.Add(AssessmentEntity.PrefetchPathAssessmentMedRehabs);

                    prefetch.Add(AssessmentEntity.PrefetchPathAssessmentNotes)
                        .SubPath.Add(AssessmentNoteEntity.PrefetchPathNote);

                    prefetch.Add(AssessmentEntity.PrefetchPathAssessmentColors);

                    prefetch.Add(AssessmentEntity.PrefetchPathAssessmentAttributes);

                    prefetch.Add(AssessmentEntity.PrefetchPathAssessmentReports);

                    adapter.FetchEntity(assessmentEntity, prefetch);
                }

                assessmentEntity.AssessmentTypeId = assessment.AssessmentType.AssessmentTypeId;
                assessmentEntity.ReferralTypeId = assessment.ReferralType.ReferralTypeId;
                assessmentEntity.ReferralSourceId = assessment.ReferralSource.ReferralSourceId;
                assessmentEntity.ReportStatusId = assessment.ReportStatus.ReportStatusId;
                assessmentEntity.CompanyId = assessment.Company.CompanyId;
                assessmentEntity.Deleted = assessment.Deleted;
                assessmentEntity.IsLargeFile = assessment.IsLargeFile;

                if (null == assessment.MedicalFileReceivedDate)
                {
                    assessmentEntity.SetNewFieldValue((int)AssessmentFieldIndex.MedicalFileReceivedDate, null);
                }
                else
                {
                    assessmentEntity.MedicalFileReceivedDate = assessment.MedicalFileReceivedDate;
                }

                if (null == assessment.FileSize)
                {
                    assessmentEntity.SetNewFieldValue((int)AssessmentFieldIndex.FileSize, null);
                }
                else
                {
                    assessmentEntity.FileSize = assessment.FileSize;
                }

                if (string.IsNullOrWhiteSpace(assessment.ReferralSourceFileNumber))
                {
                    assessmentEntity.SetNewFieldValue((int)AssessmentFieldIndex.ReferralSourceFileNumber, null);
                }
                else
                {
                    assessmentEntity.ReferralSourceFileNumber = assessment.ReferralSourceFileNumber;
                }

                if (string.IsNullOrWhiteSpace(assessment.ReferralSourceContactEmail))
                {
                    assessmentEntity.SetNewFieldValue((int)AssessmentFieldIndex.ReferralSourceContactEmail, null);
                }
                else
                {
                    assessmentEntity.ReferralSourceContactEmail = assessment.ReferralSourceContactEmail;
                }

                if (null == assessment.DocListWriter)
                {
                    assessmentEntity.SetNewFieldValue((int)AssessmentFieldIndex.DocListWriterId, null);
                }
                else
                {
                    assessmentEntity.DocListWriterId = assessment.DocListWriter.UserId;
                }

                if (null == assessment.NotesWriter)
                {
                    assessmentEntity.SetNewFieldValue((int)AssessmentFieldIndex.NotesWriterId, null);
                }
                else
                {
                    assessmentEntity.NotesWriterId = assessment.NotesWriter.UserId;
                }
                
                #region appointments

                var appointmentsToAdd = assessment.Appointments
                    .Where(appointment =>
                        appointment.AppointmentId == 0 ||
                        !assessmentEntity.Appointments.Any(appointmentEntity =>
                            appointmentEntity.AppointmentId == appointment.AppointmentId
                        )
                    );

                var appointmentsToRemove = assessmentEntity.Appointments
                    .Where(appointmentEntity =>
                        !assessment.Appointments.Any(appointment =>
                            appointment.AppointmentId == appointmentEntity.AppointmentId
                        )
                    );

                var appointmentsToUpdate = assessment.Appointments
                    .Where(appointment =>
                        assessmentEntity.Appointments.Any(appointmentEntity =>
                            appointmentEntity.AppointmentId == appointment.AppointmentId &&
                            (
                                appointmentEntity.AppointmentStatusId != appointment.AppointmentStatus.AppointmentStatusId ||
                                appointmentEntity.AppointmentTime != appointment.AppointmentTime ||
                                appointmentEntity.Deleted != appointment.Deleted ||
                                appointmentEntity.LocationId != appointment.Location.AddressId ||
                                appointmentEntity.PsychologistId != appointment.Psychologist.UserId ||
                                appointmentEntity.PsychometristId != appointment.Psychometrist.UserId ||
                                //appointment attributes removed
                                appointmentEntity.AppointmentAttributes.Any(appointmentAttribute =>
                                    !appointment.Attributes.Any(attribute =>
                                        attribute.AttributeId == appointmentAttribute.AttributeId
                                    )
                                ) ||
                                //appointment attributes added
                                appointment.Attributes.Any(attribute =>
                                    !appointmentEntity.AppointmentAttributes.Any(appointmentAttribute =>
                                        appointmentAttribute.AttributeId == attribute.AttributeId
                                    )
                                )
                            )
                        )
                    );

                foreach (var appointment in appointmentsToRemove)
                {
                    foreach (var appointmentAttribute in appointment.AppointmentAttributes)
                    {
                        uow.AddForDelete(appointmentAttribute);
                    }

                    uow.AddForDelete(appointment);
                }

                foreach (var appointment in appointmentsToAdd)
                {
                    var appointmentEntity = new AppointmentEntity
                    {
                        AppointmentStatusId = appointment.AppointmentStatus.AppointmentStatusId,
                        AppointmentTime = appointment.AppointmentTime,
                        Deleted = appointment.Deleted,
                        LocationId = appointment.Location.AddressId,
                        PsychologistId = appointment.Psychologist.UserId,
                        PsychometristId = appointment.Psychometrist.UserId,
                    };

                    appointmentEntity.AppointmentAttributes.AddRange(
                        appointment.Attributes.Select(attribute =>
                            new AppointmentAttributeEntity
                            {
                                AttributeId = attribute.AttributeId,
                            }
                        )
                    );

                    assessmentEntity.Appointments.Add(appointmentEntity);
                }

                foreach (var appointment in appointmentsToUpdate)
                {
                    var appointmentEntity = assessmentEntity.Appointments.Single(entity => entity.AppointmentId == appointment.AppointmentId);

                    appointmentEntity.AppointmentStatusId = appointment.AppointmentStatus.AppointmentStatusId;
                    appointmentEntity.AppointmentTime = appointment.AppointmentTime;
                    appointmentEntity.Deleted = appointment.Deleted;
                    appointmentEntity.LocationId = appointment.Location.AddressId;
                    appointmentEntity.PsychologistId = appointment.Psychologist.UserId;
                    appointmentEntity.PsychometristId = appointment.Psychometrist.UserId;

                    var appointmentAttributesToAdd = appointment.Attributes.Where(attribute =>
                        !appointmentEntity.AppointmentAttributes.Any(appointmentAttribute =>
                            appointmentAttribute.AttributeId == attribute.AttributeId
                        )
                    );

                    var appointmentAttributesToRemove = appointmentEntity.AppointmentAttributes.Where(appointmentAttribute =>
                        !appointment.Attributes.Any(attribute =>
                            attribute.AttributeId == appointmentAttribute.AttributeId)
                    );

                    foreach (var attribute in appointmentAttributesToRemove)
                    {
                        uow.AddForDelete(attribute);
                    }

                    appointmentEntity.AppointmentAttributes.AddRange(
                        appointmentAttributesToAdd.Select(attribute => new AppointmentAttributeEntity
                        {
                            AttributeId = attribute.AttributeId,
                        })
                    );
                }
                
                #endregion

                #region claims

                var claimsToAdd = assessment.Claims
                    .Where(claim => !assessmentEntity.AssessmentClaims.Any(assessmentClaim => assessmentClaim.ClaimId == claim.ClaimId));

                var claimsToRemove = assessmentEntity.AssessmentClaims
                    .Where(assessmentClaim => !assessment.Claims.Any(claim => claim.ClaimId == assessmentClaim.ClaimId));

                var claimsToUpdate = assessment.Claims
                    .Where(claim => assessmentEntity.AssessmentClaims
                        .Any(assessmentClaim =>
                            assessmentClaim.ClaimId == claim.ClaimId &&
                            (
                            assessmentClaim.Claim.ClaimantId != claim.Claimant.ClaimantId ||
                            assessmentClaim.Claim.ClaimNumber != claim.ClaimNumber ||
                            assessmentClaim.Claim.DateOfLoss != claim.DateOfLoss ||
                            assessmentClaim.Claim.Deleted != claim.Deleted
                            )
                        )
                    );
                
                foreach (var assessmentClaim in claimsToRemove)
                {
                    uow.AddForDelete(assessmentClaim);
                    uow.AddForDelete(assessmentClaim.Claim);
                }

                foreach (var claim in claimsToUpdate)
                {
                    var claimEntity = assessmentEntity.AssessmentClaims
                        .Where(assessmentClaim => assessmentClaim.ClaimId == claim.ClaimId)
                        .Select(assessmentClaim => assessmentClaim.Claim)
                        .SingleOrDefault();

                    if (null != claimEntity)
                    {
                        claimEntity.ClaimNumber = claim.ClaimNumber;
                        claimEntity.DateOfLoss = claim.DateOfLoss;
                        claimEntity.Deleted = claim.Deleted;
                        claimEntity.ClaimantId = claim.Claimant.ClaimantId;

                        if (claim.Claimant.IsNew())
                        {
                            claimEntity.Claimant = new ClaimantEntity
                            {
                                FirstName = claim.Claimant.FirstName,
                                LastName = claim.Claimant.LastName,
                                Age = claim.Claimant.Age,
                                DateOfBirth = claim.Claimant.DateOfBirth,
                                Gender = claim.Claimant.Gender,
                                IsActive = claim.Claimant.IsActive,
                            };
                        }
                    }
                }

                assessmentEntity.AssessmentClaims.AddRange(
                    claimsToAdd.Select(claim => new AssessmentClaimEntity
                    {
                        Claim = new ClaimEntity
                        {
                            ClaimantId = claim.Claimant.ClaimantId,
                            Claimant = claim.Claimant.IsNew()
                            ? new ClaimantEntity
                            {
                                FirstName = claim.Claimant.FirstName,
                                LastName = claim.Claimant.LastName,
                                Age = claim.Claimant.Age,
                                DateOfBirth = claim.Claimant.DateOfBirth,
                                Gender = claim.Claimant.Gender,
                                IsActive = claim.Claimant.IsActive,
                            }
                            : null,
                            ClaimNumber = claim.ClaimNumber,
                            DateOfLoss = claim.DateOfLoss,
                            Deleted = claim.Deleted,
                        },
                    })
                );

                #endregion

                #region issues in dispute

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

                #endregion

                #region med rehabs

                var medRehabsToAdd = assessment.MedRehabs
                    .Where(medRehab =>
                        !assessmentEntity.AssessmentMedRehabs.Any(assessmentMedRehab => assessmentMedRehab.MedRehabId == medRehab.MedRehabId)
                    );

                var medRehabsToRemove = assessmentEntity.AssessmentMedRehabs
                    .Where(assessmentMedRehab =>
                        !assessment.MedRehabs.Any(medRehab => medRehab.MedRehabId == assessmentMedRehab.MedRehabId)
                    );

                var medRehabsToUpdate = assessment.MedRehabs
                    .Where(medRehab =>
                        assessmentEntity.AssessmentMedRehabs.Any(assessmentMedRehab =>
                            assessmentMedRehab.MedRehabId == medRehab.MedRehabId &&
                            (
                                assessmentMedRehab.Amount != medRehab.Amount ||
                                assessmentMedRehab.Date != medRehab.Date ||
                                assessmentMedRehab.Deleted != medRehab.Deleted ||
                                assessmentMedRehab.Description != medRehab.Description
                            )
                        )
                    );

                foreach (var medRehab in medRehabsToRemove)
                {
                    uow.AddForDelete(medRehab);
                }

                foreach (var medRehab in medRehabsToUpdate)
                {
                    var medRehabEntity = assessmentEntity.AssessmentMedRehabs
                        .Where(assessmentMedRehab => assessmentMedRehab.MedRehabId == medRehab.MedRehabId)
                        .SingleOrDefault();

                    if (null != medRehabEntity)
                    {
                        medRehabEntity.Amount = medRehab.Amount;
                        medRehabEntity.Date = medRehab.Date;
                        medRehabEntity.Deleted = medRehab.Deleted;
                        medRehabEntity.Description = medRehab.Description;
                    }
                }

                assessmentEntity.AssessmentMedRehabs.AddRange(
                    medRehabsToAdd.Select(medRehab =>
                    new AssessmentMedRehabEntity
                    {
                        Amount = medRehab.Amount,
                        AssessmentId = medRehab.AssessmentId,
                        Date = medRehab.Date,
                        Deleted = medRehab.Deleted,
                        Description = medRehab.Description,
                    })
                );

                #endregion

                #region notes

                var notesToAdd = assessment.Notes
                    .Where(note =>
                        !assessmentEntity.AssessmentNotes.Any(assessmentNote => assessmentNote.NoteId == note.NoteId)
                    );

                var notesToRemove = assessmentEntity.AssessmentNotes
                    .Where(assessmentNote =>
                        !assessment.Notes.Any(note => note.NoteId == assessmentNote.NoteId)
                    );

                var notesToUpdate = assessment.Notes
                    .Where(note => assessmentEntity.AssessmentNotes
                        .Any(assessmentNote =>
                            assessmentNote.NoteId == note.NoteId &&
                            assessmentNote.Note.Note != note.NoteText
                        )
                    );

                foreach (var assessmentNote in notesToRemove)
                {
                    uow.AddForDelete(assessmentNote);
                    uow.AddForDelete(assessmentNote.Note);
                }

                foreach (var note in notesToUpdate)
                {
                    var noteEntity = assessmentEntity.AssessmentNotes
                        .Where(assessmentNote => assessmentNote.NoteId == note.NoteId)
                        .Select(assessmentNote => assessmentNote.Note)
                        .SingleOrDefault();

                    if (null != noteEntity)
                    {
                        noteEntity.Note = note.NoteText;
                        noteEntity.UpdateUserId = note.UpdateUser.UserId;
                        noteEntity.UpdateDate = _date.Now;
                    }
                }

                assessmentEntity.AssessmentNotes.AddRange(
                    notesToAdd.Select(note => new AssessmentNoteEntity
                    {
                        Note = new NoteEntity
                        {
                            CreateUserId = note.CreateUser.UserId,
                            Note = note.NoteText,
                            UpdateUserId = note.UpdateUser.UserId,
                        }
                    })
                );

                #endregion

                #region colors

                var colorsToAdd = assessment.Colors
                    .Where(color =>
                        !assessmentEntity.AssessmentColors.Any(assessmentColor => assessmentColor.ColorId == color.ColorId)
                    );

                var colorsToRemove = assessmentEntity.AssessmentColors
                    .Where(assessmentColor =>
                        !assessment.Colors.Any(color => color.ColorId == assessmentColor.ColorId)
                    );

                assessmentEntity.AssessmentColors.AddRange(
                    colorsToAdd.Select(color => new AssessmentColorEntity
                    {
                        AssessmentId = assessment.AssessmentId,
                        ColorId = color.ColorId,
                    })
                );

                foreach (var color in colorsToRemove)
                {
                    uow.AddForDelete(color);
                }

                #endregion

                #region attributes

                var assessmentAttributesToAdd = assessment.Attributes.Where(attribute =>
                        !assessmentEntity.AssessmentAttributes.Any(assessmentAttribute =>
                            assessmentAttribute.AttributeId == attribute.AttributeId
                        )
                    );

                var assessmentAttributesToRemove = assessmentEntity.AssessmentAttributes.Where(assessmentAttribute =>
                    !assessment.Attributes.Any(attribute =>
                        attribute.AttributeId == assessmentAttribute.AttributeId)
                );

                foreach (var attribute in assessmentAttributesToRemove)
                {
                    uow.AddForDelete(attribute);
                }

                assessmentEntity.AssessmentAttributes.AddRange(
                    assessmentAttributesToAdd.Select(attribute => new AssessmentAttributeEntity
                    {
                        AttributeId = attribute.AttributeId,
                    })
                );

                #endregion

                #region reports

                var reportsToAdd = assessment.Reports
                    .Where(report =>
                        !assessmentEntity.AssessmentReports.Any(assessmentReport => assessmentReport.ReportId == report.ReportId)
                    );

                var reportsToRemove = assessmentEntity.AssessmentReports
                    .Where(assessmentReport =>
                        !assessment.Reports.Any(report => report.ReportId == assessmentReport.ReportId)
                    );
                
                foreach (var report in reportsToRemove)
                {
                    uow.AddForDelete(report);
                }

                assessmentEntity.AssessmentReports.AddRange(
                    reportsToAdd.Select(report =>
                    new AssessmentReportEntity
                    {
                        ReportTypeId = report.ReportType.ReportTypeId,
                    })
                );

                #endregion

                uow.AddForSave(assessmentEntity);

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
