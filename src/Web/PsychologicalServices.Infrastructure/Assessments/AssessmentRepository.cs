﻿using PsychologicalServices.Data;
using PsychologicalServices.Data.DatabaseSpecific;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Attributes;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Invoices;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Assessments
{
    public class AssessmentRepository : RepositoryBase, IAssessmentRepository
    {
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly ICompanyRepository _companyRepository = null;
        private readonly IAttributeRepository _attributeRepository = null;
        private readonly IPsychologistInvoiceGenerator _invoiceGenerator = null;
        private readonly IDate _date = null;

        public AssessmentRepository(
            IDataAccessAdapterFactory adapterFactory,
            IAppointmentRepository appointmentRepository,
            ICompanyRepository companyRepository,
            IAttributeRepository attributeRepository,
            IPsychologistInvoiceGenerator invoiceGenerator,
            IDate date
        ) : base(adapterFactory)
        {
            _appointmentRepository = appointmentRepository;
            _companyRepository = companyRepository;
            _attributeRepository = attributeRepository;
            _invoiceGenerator = invoiceGenerator;
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
                            .Prefetch<AssessmentTypeAttributeTypeEntity>(assessmentType => assessmentType.AssessmentTypeAttributeTypes)
                                .SubPath(assessmentTypeAttributeTypePath => assessmentTypeAttributeTypePath
                                    .Prefetch<AttributeTypeEntity>(assessmentTypeAttributeType => assessmentTypeAttributeType.AttributeType)
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
                    .Prefetch<ClaimantEntity>(assessment => assessment.Claimant)
                        .SubPath(claimantPath => claimantPath
                            .Prefetch<ClaimEntity>(claimant => claimant.Claims)
                        )
                    .Prefetch<CredibilityEntity>(assessment => assessment.NeurocognitiveCredibility)
                    .Prefetch<CredibilityEntity>(assessment => assessment.PsychologicalCredibility)
                    .Prefetch<DiagnosisFoundResponseEntity>(assessment => assessment.DiagnosisFoundResponse)
                    .Prefetch<AssessmentClaimEntity>(assessment => assessment.AssessmentClaims)
                        .SubPath(assessmentClaimPath => assessmentClaimPath
                            .Prefetch<ClaimEntity>(assessmentClaim => assessmentClaim.Claim)
                        )
                    .Prefetch<AppointmentEntity>(assessment => assessment.Appointments)
                        .SubPath(appointmentPath => appointmentPath
                            .Prefetch<AddressEntity>(appointment => appointment.Location)
                            .Prefetch<UserEntity>(appointment => appointment.Psychologist)
                            .Prefetch<UserEntity>(appointment => appointment.Psychometrist)
                            .Prefetch<AppointmentStatusEntity>(appointment => appointment.AppointmentStatus)
                            .Prefetch<AppointmentAttributeEntity>(appointment => appointment.AppointmentAttributes)
                                .FilterOn(appointmentAttribute => appointmentAttribute.Attribute.IsActive)
                                .SubPath(appointmentAttributePath => appointmentAttributePath
                                    .Prefetch<AttributeEntity>(appointmentAttribute => appointmentAttribute.Attribute)
                                        .SubPath(attributePath => attributePath
                                            .Prefetch<AttributeTypeEntity>(attribute => attribute.AttributeType)
                                        )
                                )
                            .Prefetch<UserEntity>(appointment => appointment.CreateUser)
                            .Prefetch<UserEntity>(appointment => appointment.UpdateUser)
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
                    .Prefetch<NoteEntity>(assessment => assessment.Summary)
                    .Prefetch<UserEntity>(assessment => assessment.CreateUser)
                    .Prefetch<UserEntity>(assessment => assessment.UpdateUser)
                );

        private static readonly Func<IPathEdgeRootParser<AppointmentEntity>, IPathEdgeRootParser<AppointmentEntity>>
            AssessmentSearchPath =
                (appointmentPath => appointmentPath
                    .Prefetch<AssessmentEntity>(appointment => appointment.Assessment)
                        .SubPath(assessmentPath => assessmentPath
                            .Prefetch<AssessmentTypeEntity>(assessment => assessment.AssessmentType)
                            .Prefetch<ReferralSourceEntity>(assessment => assessment.ReferralSource)
                            .Prefetch<ClaimantEntity>(assessment => assessment.Claimant)
                        )
                );

        private static readonly Func<IPathEdgeRootParser<AssessmentTypeEntity>, IPathEdgeRootParser<AssessmentTypeEntity>>
            AssessmentTypePath = (assessmentTypePath => assessmentTypePath
                .Prefetch<AssessmentTypeReportTypeEntity>(assessmentType => assessmentType.AssessmentTypeReportTypes)
                    .SubPath(assessmentTypeReportTypePath => assessmentTypeReportTypePath
                        .Prefetch<ReportTypeEntity>(assessmentTypeReportType => assessmentTypeReportType.ReportType)
                    )
                .Prefetch<AssessmentTypeAttributeTypeEntity>(assessmentType => assessmentType.AssessmentTypeAttributeTypes)
                    .SubPath(assessmentTypeAttributeTypePath => assessmentTypeAttributeTypePath
                        .Prefetch<AttributeTypeEntity>(assessmentTypeAttributeType => assessmentTypeAttributeType.AttributeType)
                    )
            );

        private Func<IPathEdgeRootParser<AssessmentEntity>, IPathEdgeRootParser<AssessmentEntity>> GetAssessmentTestingResultsPath(string name)
        {
            return (assessmentPath => assessmentPath
                .Prefetch<ClaimantEntity>(assessment => assessment.Claimant)
                .Prefetch<AssessmentClaimEntity>(assessment => assessment.AssessmentClaims)
                    .SubPath(assessmentClaimsPath => assessmentClaimsPath
                        .Prefetch<ClaimEntity>(assessmentClaim => assessmentClaim.Claim)
                    )
                .Prefetch<AssessmentTypeEntity>(assessment => assessment.AssessmentType)
                .Prefetch<AssessmentReportEntity>(assessment => assessment.AssessmentReports)
                    .SubPath(assessmentReportPath => assessmentReportPath
                        .Prefetch<AssessmentReportIssueInDisputeEntity>(assessmentReport => assessmentReport.AssessmentReportIssuesInDispute)
                            .SubPath(assessmentReportIssueInDisputePath => assessmentReportIssueInDisputePath
                                .Prefetch<IssueInDisputeEntity>(assessmentReportIssueInDispute => assessmentReportIssueInDispute.IssueInDispute)
                            )
                    )
                .Prefetch<AssessmentMedRehabEntity>(assessment => assessment.AssessmentMedRehabs)
                .Prefetch<AppointmentEntity>(assessment => assessment.Appointments)
                .Prefetch<AssessmentTestingResultEntity>(assessment => assessment.AssessmentTestingResults)
                    .FilterOn(testingResults => testingResults.Name == name)
            );
        }

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
        
        public Assessment GetNewAssessment(int companyId, DateTime appointmentTime)
        {
            var company = _companyRepository.GetCompany(companyId);

            if (null == company)
            {
                throw new ArgumentOutOfRangeException("companyId");
            }

            var appointment = _appointmentRepository.NewAppointment(companyId, appointmentTime);
            
            return new Assessment
            {
                AssessmentType = company.NewAssessmentAssessmentType,
                Appointments = new List<Appointment>(new[] { appointment }),
                Attributes = Enumerable.Empty<Models.Attributes.AttributeValue>(),
                Claims = Enumerable.Empty<Models.Claims.Claim>(),
                Colors = Enumerable.Empty<Models.Colors.Color>(),
                Company = company,
                MedRehabs = Enumerable.Empty<Models.Claims.MedRehab>(),
                AssessmentNotes = Enumerable.Empty<Models.Assessments.AssessmentNote>(),
                Reports = Enumerable.Empty<Models.Reports.Report>(),
                ReportStatus = company.NewAssessmentReportStatus,
                Summary = company.NewAssessmentSummary,
            };
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

        public AssessmentTestingResults GetAssessmentTestingResults(int assessmentId, string name)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var testingResults = meta.Assessment
                    .WithPath(GetAssessmentTestingResultsPath(name))
                    .Where(assessment => assessment.AssessmentId == assessmentId)
                    .SingleOrDefault()
                    .ToAssessmentTestingResults(name);

                return testingResults;
            }
        }

        public IEnumerable<AssessmentSearchResult> SearchAssessments(AssessmentSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var appointments = meta.Appointment
                    .WithPath(AssessmentSearchPath);

                if (null != criteria)
                {
                    appointments = appointments.Where(appointment => appointment.Assessment.CompanyId == criteria.CompanyId);

                    if (criteria.AssessmentId.HasValue)
                    {
                        appointments = appointments.Where(appointment => appointment.AssessmentId == criteria.AssessmentId.Value);
                    }

                    if (criteria.ReferralSourceId.HasValue)
                    {
                        appointments = appointments.Where(appointment => appointment.Assessment.ReferralSourceId == criteria.ReferralSourceId.Value);
                    }

                    if (criteria.ClaimantId.HasValue)
                    {
                        appointments = appointments.Where(appointment =>
                            appointment.Assessment.ClaimantId == criteria.ClaimantId
                        );
                    }

                    if (criteria.AppointmentTimeStart.HasValue)
                    {
                        appointments = appointments.Where(appointment => appointment.AppointmentTime >= criteria.AppointmentTimeStart);
                    }

                    if (criteria.AppointmentTimeEnd.HasValue)
                    {
                        appointments = appointments.Where(appointment => appointment.AppointmentTime >= criteria.AppointmentTimeEnd);
                    }

                    if (criteria.NeedsStatusUpdate.HasValue)
                    {
                        appointments = appointments.Where(appointment =>
                            appointment.AppointmentStatus.IsFinalStatus != criteria.NeedsStatusUpdate.Value &&
                            appointment.AppointmentTime < _date.UtcNow
                        );
                    }
                }

                return Execute<AppointmentEntity>(
                        (ILLBLGenProQuery)
                        appointments
                            .OrderByDescending(appointment => appointment.AppointmentTime)
                    )
                    .Select(appointment => appointment.ToAssessmentSearchResult())
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
                            .WithPath(AssessmentTypePath)
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

                    prefetch.Add(AssessmentEntity.PrefetchPathSummary);

                    prefetch.Add(AssessmentEntity.PrefetchPathNeurocognitiveCredibility);

                    prefetch.Add(AssessmentEntity.PrefetchPathPsychologicalCredibility);

                    prefetch.Add(AssessmentEntity.PrefetchPathDiagnosisFoundResponse);

                    var appointmentsPath = prefetch.Add(AssessmentEntity.PrefetchPathAppointments);

                    appointmentsPath
                        .SubPath.Add(AppointmentEntity.PrefetchPathAppointmentAttributes);
                    
                    prefetch.Add(AssessmentEntity.PrefetchPathAssessmentClaims)
                        .SubPath.Add(AssessmentClaimEntity.PrefetchPathClaim);

                    prefetch.Add(AssessmentEntity.PrefetchPathAssessmentMedRehabs);

                    prefetch.Add(AssessmentEntity.PrefetchPathAssessmentNotes)
                        .SubPath.Add(AssessmentNoteEntity.PrefetchPathNote);

                    prefetch.Add(AssessmentEntity.PrefetchPathAssessmentColors);

                    prefetch.Add(AssessmentEntity.PrefetchPathAssessmentAttributes);

                    prefetch.Add(AssessmentEntity.PrefetchPathAssessmentReports)
                        .SubPath.Add(AssessmentReportEntity.PrefetchPathAssessmentReportIssuesInDispute)
                            .SubPath.Add(AssessmentReportIssueInDisputeEntity.PrefetchPathIssueInDispute);

                    adapter.FetchEntity(assessmentEntity, prefetch);
                }
                else
                {
                    assessmentEntity.CreateDate = _date.UtcNow;
                    assessmentEntity.CreateUserId = assessment.CreateUser.UserId;
                }

                assessmentEntity.AssessmentTypeId = assessment.AssessmentType.AssessmentTypeId;
                assessmentEntity.ReferralTypeId = assessment.ReferralType.ReferralTypeId;
                assessmentEntity.ReferralSourceId = assessment.ReferralSource.ReferralSourceId;
                assessmentEntity.ReportStatusId = assessment.ReportStatus.ReportStatusId;
                assessmentEntity.CompanyId = assessment.Company.CompanyId;
                assessmentEntity.IsLargeFile = assessment.IsLargeFile;
                assessmentEntity.IsReassessment = assessment.IsReassessment;
                assessmentEntity.UpdateDate = _date.UtcNow;
                assessmentEntity.UpdateUserId = assessment.UpdateUser.UserId;

                if (null == assessment.Claimant)
                {
                    assessmentEntity.SetNewFieldValue((int)AssessmentFieldIndex.ClaimantId, null);
                }
                else
                {
                    assessmentEntity.ClaimantId = assessment.Claimant.ClaimantId;
                }

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

                if (null == assessment.PsychologistFoundInFavorOfClaimant)
                {
                    assessmentEntity.SetNewFieldValue((int)AssessmentFieldIndex.PsychologistFoundInFavorOfClaimant, null);
                }
                else
                {
                    assessmentEntity.PsychologistFoundInFavorOfClaimant = assessment.PsychologistFoundInFavorOfClaimant;
                }

                if (null == assessment.NeurocognitiveCredibility)
                {
                    assessmentEntity.SetNewFieldValue((int)AssessmentFieldIndex.NeurocognitiveCredibilityId, null);
                }
                else
                {
                    assessmentEntity.NeurocognitiveCredibilityId = assessment.NeurocognitiveCredibility.CredibilityId;
                }

                if (null == assessment.PsychologicalCredibility)
                {
                    assessmentEntity.SetNewFieldValue((int)AssessmentFieldIndex.PsychologicalCredibilityId, null);
                }
                else
                {
                    assessmentEntity.PsychologicalCredibilityId = assessment.PsychologicalCredibility.CredibilityId;
                }

                if (null == assessment.DiagnosisFoundResponse)
                {
                    assessmentEntity.SetNewFieldValue((int)AssessmentFieldIndex.DiagnosisFoundReponseId, null);
                }
                else
                {
                    assessmentEntity.DiagnosisFoundReponseId = assessment.DiagnosisFoundResponse.DiagnosisFoundResponseId;
                }

                if (null == assessment.PreviouslySeenDate)
                {
                    assessmentEntity.SetNewFieldValue((int)AssessmentFieldIndex.PreviouslySeenDate, null);
                }
                else
                {
                    assessmentEntity.PreviouslySeenDate = assessment.PreviouslySeenDate;
                }

                #region appointments

                var appointmentsToAdd = assessment.Appointments
                    .Where(appointment =>
                        appointment.AppointmentId == 0 ||
                        !assessmentEntity.Appointments.Any(appointmentEntity =>
                            appointmentEntity.AppointmentId == appointment.AppointmentId
                        )
                    )
                    .ToList();

                var appointmentsToRemove = assessmentEntity.Appointments
                    .Where(appointmentEntity =>
                        !assessment.Appointments.Any(appointment =>
                            appointment.AppointmentId == appointmentEntity.AppointmentId
                        )
                    )
                    .ToList();

                var appointmentsToUpdate = assessment.Appointments
                    .Where(appointment =>
                        assessmentEntity.Appointments.Any(appointmentEntity =>
                            appointmentEntity.AppointmentId == appointment.AppointmentId &&
                            (
                                appointmentEntity.AppointmentStatusId != appointment.AppointmentStatus.AppointmentStatusId ||
                                appointmentEntity.AppointmentTime != appointment.AppointmentTime ||
                                appointmentEntity.LocationId != appointment.Location.AddressId ||
                                appointmentEntity.PsychologistId != appointment.Psychologist.UserId ||
                                appointmentEntity.PsychometristId != appointment.Psychometrist.UserId ||
                                //appointment attributes removed
                                appointmentEntity.AppointmentAttributes.Any(appointmentAttribute =>
                                    !appointment.Attributes.Any(attributeValue =>
                                        attributeValue.Attribute.AttributeId == appointmentAttribute.AttributeId
                                    )
                                ) ||
                                //appointment attributes added
                                appointment.Attributes.Any(attributeValue =>
                                    !appointmentEntity.AppointmentAttributes.Any(appointmentAttribute =>
                                        appointmentAttribute.AttributeId == attributeValue.Attribute.AttributeId
                                    )
                                ) ||
                                appointment.Attributes.Any(attributeValue =>
                                    appointmentEntity.AppointmentAttributes.Any(appointmentAttribute =>
                                        appointmentAttribute.AttributeId == attributeValue.Attribute.AttributeId &&
                                        appointmentAttribute.Value != attributeValue.Value
                                    )
                                ) ||
                                appointmentEntity.RoomRentalBillableAmount != appointment.RoomRentalBillableAmount ||
                                appointmentEntity.PsychologistInvoiceLock != appointment.PsychologistInvoiceLock ||
                                appointmentEntity.CancellationDate != appointment.CancellationDate                            )
                        )
                    )
                    .ToList();

                foreach (var appointment in appointmentsToRemove)
                {
                    foreach (var appointmentAttribute in appointment.AppointmentAttributes)
                    {
                        uow.AddForDelete(appointmentAttribute);
                    }

                    uow.AddForDelete(appointment);
                }
                
                foreach (var appointment in appointmentsToUpdate)
                {
                    var appointmentEntity = assessmentEntity.Appointments.Single(entity => entity.AppointmentId == appointment.AppointmentId);

                    appointmentEntity.AppointmentStatusId = appointment.AppointmentStatus.AppointmentStatusId;
                    appointmentEntity.AppointmentTime = appointment.AppointmentTime;
                    appointmentEntity.LocationId = appointment.Location.AddressId;
                    appointmentEntity.PsychologistId = appointment.Psychologist.UserId;
                    appointmentEntity.PsychometristId = appointment.Psychometrist.UserId;
                    appointmentEntity.UpdateDate = _date.UtcNow;
                    appointmentEntity.UpdateUserId = assessment.UpdateUser.UserId;
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

                    var appointmentAttributesToAdd = appointment.Attributes.Where(attribute =>
                        !appointmentEntity.AppointmentAttributes.Any(appointmentAttribute =>
                            appointmentAttribute.AttributeId == attribute.Attribute.AttributeId
                        )
                    )
                    .ToList();
                    
                    var appointmentAttributesToRemove = appointmentEntity.AppointmentAttributes.Where(appointmentAttribute =>
                        !appointment.Attributes.Any(attribute => attribute.Attribute.AttributeId == appointmentAttribute.AttributeId)
                    )
                    .ToList();

                    foreach (var attribute in appointmentAttributesToRemove)
                    {
                        uow.AddForDelete(attribute);
                    }

                    var appointmentAttributesToUpdate = appointment.Attributes
                        .Where(attribute =>
                            appointmentEntity.AppointmentAttributes.Any(appointmentAttribute =>
                                appointmentAttribute.AttributeId == attribute.Attribute.AttributeId &&
                                appointmentAttribute.Value != attribute.Value
                        )
                    )
                    .ToList();

                    foreach (var attribute in appointmentAttributesToUpdate)
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

                    appointmentEntity.AppointmentAttributes.AddRange(
                        appointmentAttributesToAdd.Select(attribute => new AppointmentAttributeEntity
                        {
                            AttributeId = attribute.Attribute.AttributeId,
                            Value = attribute.Value,
                        })
                    );
                }
                
                foreach (var appointment in appointmentsToAdd)
                {
                    var appointmentEntity = new AppointmentEntity
                    {
                        AppointmentStatusId = appointment.AppointmentStatus.AppointmentStatusId,
                        AppointmentTime = appointment.AppointmentTime,
                        LocationId = appointment.Location.AddressId,
                        PsychologistId = appointment.Psychologist.UserId,
                        PsychometristId = appointment.Psychometrist.UserId,
                        CreateDate = _date.UtcNow,
                        CreateUserId = assessment.CreateUser.UserId,
                        UpdateDate = _date.UtcNow,
                        UpdateUserId = assessment.UpdateUser.UserId,
                        RoomRentalBillableAmount = appointment.RoomRentalBillableAmount,
                        PsychologistInvoiceLock = appointment.PsychologistInvoiceLock,
                        CancellationDate = appointment.CancellationDate,
                        CancellationReason = appointment.CancellationReason,
                    };

                    appointmentEntity.AppointmentAttributes.AddRange(
                        appointment.Attributes.Select(attribute =>
                            new AppointmentAttributeEntity
                            {
                                AttributeId = attribute.Attribute.AttributeId,
                                Value = attribute.Value,
                            }
                        )
                    );

                    assessmentEntity.Appointments.Add(appointmentEntity);
                }

                #endregion

                #region claims

                var claimsToAdd = assessment.Claims
                    .Where(claim => !assessmentEntity.AssessmentClaims.Any(assessmentClaim => assessmentClaim.ClaimId == claim.ClaimId))
                    .ToList();

                var claimsToRemove = assessmentEntity.AssessmentClaims
                    .Where(assessmentClaim => !assessment.Claims.Any(claim => claim.ClaimId == assessmentClaim.ClaimId))
                    .ToList();

                foreach (var assessmentClaim in claimsToRemove)
                {
                    uow.AddForDelete(assessmentClaim);
                }

                assessmentEntity.AssessmentClaims.AddRange(
                    claimsToAdd.Select(claim => new AssessmentClaimEntity
                    {
                        AssessmentId = assessment.AssessmentId,
                        ClaimId = claim.ClaimId
                    })
                );

                #endregion

                #region med rehabs

                var medRehabsToAdd = assessment.MedRehabs
                    .Where(medRehab =>
                        !assessmentEntity.AssessmentMedRehabs.Any(assessmentMedRehab => assessmentMedRehab.MedRehabId == medRehab.MedRehabId)
                    )
                    .ToList();

                var medRehabsToRemove = assessmentEntity.AssessmentMedRehabs
                    .Where(assessmentMedRehab =>
                        !assessment.MedRehabs.Any(medRehab => medRehab.MedRehabId == assessmentMedRehab.MedRehabId)
                    )
                    .ToList();

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
                    )
                    .ToList();

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

                var notesToAdd = assessment.AssessmentNotes
                    .Where(note =>
                        !assessmentEntity.AssessmentNotes.Any(assessmentNote => assessmentNote.NoteId == note.Note.NoteId)
                    )
                    .ToList();

                var notesToRemove = assessmentEntity.AssessmentNotes
                    .Where(assessmentNote =>
                        !assessment.AssessmentNotes.Any(note => note.Note.NoteId == assessmentNote.NoteId)
                    )
                    .ToList();

                var notesToUpdate = assessment.AssessmentNotes
                    .Where(note => assessmentEntity.AssessmentNotes
                        .Any(assessmentNote =>
                            assessmentNote.NoteId == note.Note.NoteId &&
                            (
                            assessmentNote.Note.Note != note.Note.NoteText ||
                            assessmentNote.ShowOnCalendar != note.ShowOnCalendar
                            )
                        )
                    )
                    .ToList();

                foreach (var assessmentNote in notesToRemove)
                {
                    uow.AddForDelete(assessmentNote);
                    uow.AddForDelete(assessmentNote.Note);
                }

                foreach (var note in notesToUpdate)
                {
                    var noteEntity = assessmentEntity.AssessmentNotes
                        .Where(assessmentNote => assessmentNote.NoteId == note.Note.NoteId)
                        .SingleOrDefault();

                    if (null != noteEntity)
                    {
                        noteEntity.Note.Note = note.Note.NoteText;
                        noteEntity.ShowOnCalendar = note.ShowOnCalendar;
                        noteEntity.Note.UpdateUserId = note.Note.UpdateUser.UserId;
                        noteEntity.Note.UpdateDate = _date.UtcNow;
                    }
                }

                assessmentEntity.AssessmentNotes.AddRange(
                    notesToAdd.Select(note => new AssessmentNoteEntity
                    {
                        ShowOnCalendar = note.ShowOnCalendar,
                        Note = new NoteEntity
                        {
                            CreateUserId = note.Note.CreateUser.UserId,
                            Note = note.Note.NoteText,
                            UpdateUserId = note.Note.UpdateUser.UserId,
                        }
                    })
                );

                #endregion

                #region colors

                var colorsToAdd = assessment.Colors
                    .Where(color =>
                        !assessmentEntity.AssessmentColors.Any(assessmentColor => assessmentColor.ColorId == color.ColorId)
                    )
                    .ToList();

                var colorsToRemove = assessmentEntity.AssessmentColors
                    .Where(assessmentColor =>
                        !assessment.Colors.Any(color => color.ColorId == assessmentColor.ColorId)
                    )
                    .ToList();

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

                if (!isNew)
                {
                    var assessmentAttributesToRemove = assessmentEntity.AssessmentAttributes.Where(assessmentAttribute =>
                            !assessment.Attributes.Any(attributeValue =>
                                attributeValue.Attribute.AttributeId == assessmentAttribute.AttributeId
                            )
                        )
                        .ToList();

                    foreach (var attribute in assessmentAttributesToRemove)
                    {
                        uow.AddForDelete(attribute);
                    }

                    var attributesToUpdate = assessment.Attributes
                        .Where(attribute =>
                            assessmentEntity.AssessmentAttributes.Any(assessmentAttribute =>
                                assessmentAttribute.AttributeId == attribute.Attribute.AttributeId &&
                                assessmentAttribute.Value != attribute.Value
                        )
                    )
                    .ToList();

                    foreach (var attribute in attributesToUpdate)
                    {
                        var assessmentAttribute = assessmentEntity.AssessmentAttributes.SingleOrDefault(aa => aa.AttributeId == attribute.Attribute.AttributeId);
                        if (null != assessmentAttribute)
                        {
                            if (null == attribute.Value)
                            {
                                assessmentAttribute.SetNewFieldValue((int)AssessmentAttributeFieldIndex.Value, null);
                            }
                            else
                            {
                                assessmentAttribute.Value = attribute.Value;
                            }
                        }
                    }
                }
                
                var assessmentAttributesToAdd = assessment.Attributes.Where(attributeValue =>
                        !assessmentEntity.AssessmentAttributes.Any(assessmentAttribute =>
                            assessmentAttribute.AttributeId == attributeValue.Attribute.AttributeId
                        )
                    )
                    .ToList();

                assessmentEntity.AssessmentAttributes.AddRange(
                    assessmentAttributesToAdd.Select(attributeValue => new AssessmentAttributeEntity
                    {
                        AttributeId = attributeValue.Attribute.AttributeId,
                        Value = attributeValue.Value,
                    })
                );

                #endregion

                #region reports

                var reportsToAdd = assessment.Reports
                    .Where(report =>
                        !assessmentEntity.AssessmentReports.Any(assessmentReport => assessmentReport.ReportId == report.ReportId)
                    )
                    .ToList();

                var reportsToRemove = assessmentEntity.AssessmentReports
                    .Where(assessmentReport =>
                        !assessment.Reports.Any(report => report.ReportId == assessmentReport.ReportId)
                    )
                    .ToList();
                
                var reportsToUpdate = assessment.Reports
                    .Where(report =>
                        assessmentEntity.AssessmentReports.Any(assessmentReport =>
                            report.ReportId == assessmentReport.ReportId &&
                            (
                                report.ReportType.ReportTypeId != assessmentReport.ReportTypeId ||
                                report.IsAdditional != assessmentReport.IsAdditional ||
                                report.IssuesInDispute.Any(issueInDispute => 
                                    !assessmentReport.AssessmentReportIssuesInDispute.Any(assessmentReportIssueInDispute => assessmentReportIssueInDispute.IssueInDisputeId == issueInDispute.IssueInDisputeId)
                                ) ||
                                assessmentReport.AssessmentReportIssuesInDispute.Any(assessmentReportIssueInDispute =>
                                    !report.IssuesInDispute.Any(issueInDispute => issueInDispute.IssueInDisputeId == assessmentReportIssueInDispute.IssueInDisputeId)
                                )
                            )
                        )
                    )
                    .ToList();

                foreach (var report in reportsToRemove)
                {
                    foreach (var issueInDispute in report.AssessmentReportIssuesInDispute)
                    {
                        uow.AddForDelete(issueInDispute);
                    }

                    uow.AddForDelete(report);
                }

                foreach (var report in reportsToUpdate)
                {
                    var reportEntity = assessmentEntity.AssessmentReports.SingleOrDefault(assessmentReport => assessmentReport.ReportId == report.ReportId);

                    if (null != reportEntity)
                    {
                        reportEntity.ReportTypeId = report.ReportType.ReportTypeId;
                        reportEntity.IsAdditional = report.IsAdditional;

                        #region issues in dispute

                        var issuesInDisputeToAdd = report.IssuesInDispute
                            .Where(issueInDispute =>
                                !reportEntity.AssessmentReportIssuesInDispute.Any(assessmentReportIssueInDispute => assessmentReportIssueInDispute.IssueInDisputeId == issueInDispute.IssueInDisputeId)
                            );

                        var issuesInDisputeToRemove = reportEntity.AssessmentReportIssuesInDispute
                            .Where(assessmentReportIssueInDispute =>
                                !report.IssuesInDispute.Any(issueInDispute => issueInDispute.IssueInDisputeId == assessmentReportIssueInDispute.IssueInDisputeId)
                            );

                        reportEntity.AssessmentReportIssuesInDispute.AddRange(
                            issuesInDisputeToAdd.Select(issueInDispute => new AssessmentReportIssueInDisputeEntity
                            {
                                ReportId = report.ReportId,
                                IssueInDisputeId = issueInDispute.IssueInDisputeId,
                            })
                        );

                        foreach (var issueInDispute in issuesInDisputeToRemove)
                        {
                            uow.AddForDelete(issueInDispute);
                        }

                        #endregion
                    }
                }

                assessmentEntity.AssessmentReports.AddRange(
                    reportsToAdd.Select(report =>
                        {
                            var assessmentReport = new AssessmentReportEntity
                            {
                                ReportTypeId = report.ReportType.ReportTypeId,
                                IsAdditional = report.IsAdditional,
                            };

                            assessmentReport.AssessmentReportIssuesInDispute.AddRange(
                                report.IssuesInDispute.Select(issueInDispute => new AssessmentReportIssueInDisputeEntity
                                {
                                    IssueInDisputeId = issueInDispute.IssueInDisputeId,
                                })
                            );

                            return assessmentReport;
                        }
                    )
                );

                #endregion
                
                #region summary

                var updateSummaryNote =
                    assessmentEntity.SummaryNoteId.HasValue &&
                    null != assessment.Summary &&
                    assessmentEntity.Summary.Note != assessment.Summary.NoteText;
                if (updateSummaryNote)
                {
                    //update summary note
                    assessmentEntity.Summary.Note = assessment.Summary.NoteText;
                    assessmentEntity.Summary.UpdateDate = _date.UtcNow;
                    assessmentEntity.Summary.UpdateUserId = assessment.UpdateUser.UserId;
                }

                var addSummaryNote =
                    !assessmentEntity.SummaryNoteId.HasValue &&
                    null != assessment.Summary &&
                    !string.IsNullOrWhiteSpace(assessment.Summary.NoteText);
                if (addSummaryNote)
                {
                    //add summary note
                    assessmentEntity.Summary = new NoteEntity
                    {
                        CreateDate = _date.UtcNow,
                        CreateUserId = assessment.UpdateUser.UserId,
                        UpdateDate = _date.UtcNow,
                        UpdateUserId = assessment.UpdateUser.UserId,
                        Note = assessment.Summary.NoteText,
                    };
                }

                #endregion
                
                uow.AddForSave(assessmentEntity);

                uow.Commit(adapter);

                return assessmentEntity.AssessmentId;
            }
        }

        public bool SaveAssessmentTestingResults(AssessmentTestingResults testingResults)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var assessmentEntity = new AssessmentEntity
                {
                    AssessmentId = testingResults.Assessment.AssessmentId,
                };

                var prefetch = new PrefetchPath2(EntityType.AssessmentEntity);

                prefetch.Add(AssessmentEntity.PrefetchPathAssessmentTestingResults);

                var assessmentExists = adapter.FetchEntity(assessmentEntity, prefetch);

                if (!assessmentExists)
                {
                    return false;
                }

                var entity = assessmentEntity.AssessmentTestingResults
                    .SingleOrDefault(e => e.Name == testingResults.Name)
                    ?? new AssessmentTestingResultEntity
                    {
                        AssessmentId = testingResults.Assessment.AssessmentId,
                        Name = testingResults.Name
                    };

                entity.Responses = testingResults.Responses;

                var saved = adapter.SaveEntity(entity, false);

                return saved;
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
                assessmentTypeEntity.IsActive = assessmentType.IsActive;
                assessmentTypeEntity.ShowOnSchedule = assessmentType.ShowOnSchedule;

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

        public int DeleteAssessment(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var rowsAffected = ActionProcedures.DeleteAssessment(id, (DataAccessAdapter)adapter);

                return rowsAffected;
            }
        }

        public bool DeleteAssessmentTestingResults(int assessmentId, string name)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var success = adapter.DeleteEntity(
                    new AssessmentTestingResultEntity(assessmentId, name)
                );

                return success;
            }
        }
    }
}
