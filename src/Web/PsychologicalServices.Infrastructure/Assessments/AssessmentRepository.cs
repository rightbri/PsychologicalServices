using PsychologicalServices.Data;
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
                    .Prefetch<CredibilityEntity>(assessment => assessment.NeurocognitiveCredibility)
                    .Prefetch<CredibilityEntity>(assessment => assessment.PsychologicalCredibility)
                    .Prefetch<DiagnosisFoundResponseEntity>(assessment => assessment.DiagnosisFoundResponse)
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
                                    //.Prefetch<UserNoteEntity>(note => note.UserNotes)
                                    //    .SubPath(userNotePath => userNotePath
                                    //        .Prefetch<UserEntity>(userNote => userNote.User)
                                    //    )
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
                            .Prefetch<AssessmentReportIssueInDisputeEntity>(assessmentReport => assessmentReport.AssessmentReportIssuesInDispute)
                                .SubPath(assessmentReportIssueInDisputePath => assessmentReportIssueInDisputePath
                                    .Prefetch<IssueInDisputeEntity>(assessmentReportIssueInDispute => assessmentReportIssueInDispute.IssueInDispute)
                                )
                        )
                    .Prefetch<ArbitrationEntity>(assessment => assessment.Arbitrations)
                        .SubPath(arbitrationPath => arbitrationPath
                            .Prefetch<ContactEntity>(arbitration => arbitration.DefenseLawyer)
                                .SubPath(contactPath => contactPath
                                    .Prefetch<ContactTypeEntity>(contact => contact.ContactType)
                                    .Prefetch<EmployerEntity>(contact => contact.Employer)
                                    .Prefetch<AddressEntity>(contact => contact.Address)
                                )
                            .Prefetch<NoteEntity>(arbitration => arbitration.Note)
                                .SubPath(notePath => notePath
                                    .Prefetch<UserEntity>(note => note.CreateUser)
                                    .Prefetch<UserEntity>(note => note.UpdateUser)
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
                            .Prefetch<AssessmentClaimEntity>(assessment => assessment.AssessmentClaims)
                                .SubPath(assessmentClaimPath => assessmentClaimPath
                                    .Prefetch<ClaimEntity>(assessmentClaim => assessmentClaim.Claim)
                                        .SubPath(claimPath => claimPath
                                            .Prefetch<ClaimantEntity>(claim => claim.Claimant)
                                        )
                                )
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
                Arbitrations = Enumerable.Empty<Models.Arbitrations.Arbitration>(),
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
                            appointment.Assessment.AssessmentClaims.Any(assessmentClaim =>
                                assessmentClaim.Claim.ClaimantId == criteria.ClaimantId
                            )
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

                    var invoiceAppointmentsPath = appointmentsPath
                        .SubPath.Add(AppointmentEntity.PrefetchPathInvoiceAppointments);

                    invoiceAppointmentsPath
                        .SubPath.Add(InvoiceAppointmentEntity.PrefetchPathInvoiceLines);

                    invoiceAppointmentsPath
                        .SubPath.Add(InvoiceAppointmentEntity.PrefetchPathInvoice);
                    
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

                    var arbitrationsPath = prefetch.Add(AssessmentEntity.PrefetchPathArbitrations);

                    arbitrationsPath
                        .SubPath.Add(ArbitrationEntity.PrefetchPathNote);

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
                assessmentEntity.UpdateDate = _date.UtcNow;
                assessmentEntity.UpdateUserId = assessment.UpdateUser.UserId;

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
                                appointmentEntity.RoomRentalBillableAmount != appointment.RoomRentalBillableAmount
                            )
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

                    if (null == appointment.RoomRentalBillableAmount)
                    {
                        appointmentEntity.SetNewFieldValue((int)AppointmentFieldIndex.RoomRentalBillableAmount, null);
                    }
                    else
                    {
                        appointmentEntity.RoomRentalBillableAmount = appointment.RoomRentalBillableAmount;
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

                var claimsToUpdate = assessment.Claims
                    .Where(claim => assessmentEntity.AssessmentClaims
                        .Any(assessmentClaim =>
                            assessmentClaim.ClaimId == claim.ClaimId &&
                            (
                            assessmentClaim.Claim.ClaimantId != claim.Claimant.ClaimantId ||
                            assessmentClaim.Claim.ClaimNumber != claim.ClaimNumber ||
                            assessmentClaim.Claim.DateOfLoss != claim.DateOfLoss ||
                            assessmentClaim.Claim.Lawyer != claim.Lawyer ||
                            assessmentClaim.Claim.InsuranceCompany != claim.InsuranceCompany
                            )
                        )
                    )
                    .ToList();
                
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
                        claimEntity.Lawyer = claim.Lawyer;
                        claimEntity.InsuranceCompany = claim.InsuranceCompany;
                        claimEntity.ClaimantId = claim.Claimant.ClaimantId;

                        if (claim.Claimant.IsNew())
                        {
                            claimEntity.Claimant = new ClaimantEntity
                            {
                                FirstName = claim.Claimant.FirstName,
                                LastName = claim.Claimant.LastName,
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
                                DateOfBirth = claim.Claimant.DateOfBirth,
                                Gender = claim.Claimant.Gender,
                                IsActive = claim.Claimant.IsActive,
                            }
                            : null,
                            ClaimNumber = claim.ClaimNumber,
                            DateOfLoss = claim.DateOfLoss,
                            Lawyer = claim.Lawyer,
                            InsuranceCompany = claim.InsuranceCompany,
                        },
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

                #region arbitrations

                var arbitrationsToAdd = assessment.Arbitrations
                    .Where(arbitration =>
                        !assessmentEntity.Arbitrations.Any(assessmentArbitration => assessmentArbitration.ArbitrationId == arbitration.ArbitrationId)
                    )
                    .ToList();

                var arbitrationsToRemove = assessmentEntity.Arbitrations
                    .Where(assessmentArbitration =>
                        !assessment.Arbitrations.Any(arbitration => arbitration.ArbitrationId == assessmentArbitration.ArbitrationId)
                    )
                    .ToList();

                var arbitrationsToUpdate = assessment.Arbitrations
                    .Where(arbitration =>
                        assessmentEntity.Arbitrations.Any(assessmentArbitration =>
                            arbitration.ArbitrationId == assessmentArbitration.ArbitrationId &&
                            (
                                arbitration.Title != assessmentArbitration.Title ||
                                (null == arbitration.DefenseLawyer && assessmentArbitration.DefenseLawyerId.HasValue) ||
                                (null != arbitration.DefenseLawyer && !assessmentArbitration.DefenseLawyerId.HasValue) ||
                                (null != arbitration.DefenseLawyer && assessmentArbitration.DefenseLawyerId.HasValue && arbitration.DefenseLawyer.ContactId != assessmentArbitration.DefenseLawyerId) ||
                                arbitration.DefenseFileNumber != assessmentArbitration.DefenseFileNumber ||
                                arbitration.StartDate != assessmentArbitration.StartDate ||
                                arbitration.EndDate != assessmentArbitration.EndDate ||
                                arbitration.AvailableDate != assessmentArbitration.AvailableDate ||
                                (null == arbitration.Note && assessmentArbitration.NoteId.HasValue) ||
                                (null != arbitration.Note && !assessmentArbitration.NoteId.HasValue && !string.IsNullOrWhiteSpace(arbitration.Note.NoteText)) ||
                                (null != arbitration.Note && assessmentArbitration.NoteId.HasValue && arbitration.Note.NoteText != assessmentArbitration.Note.Note)
                            )
                        )
                    )
                    .ToList();

                foreach (var arbitration in arbitrationsToRemove)
                {
                    uow.AddForDelete(arbitration);

                    if (null != arbitration.Note)
                    {
                        uow.AddForDelete(arbitration.Note);
                    }
                }

                foreach (var arbitration in arbitrationsToUpdate)
                {
                    var arbitrationEntity = assessmentEntity.Arbitrations.SingleOrDefault(assessmentArbitration => assessmentArbitration.ArbitrationId == arbitration.ArbitrationId);

                    if (null != arbitrationEntity)
                    {
                        arbitrationEntity.Title = arbitration.Title;
                        arbitrationEntity.StartDate = arbitration.StartDate;

                        if (null == arbitration.EndDate)
                        {
                            arbitrationEntity.SetNewFieldValue((int)ArbitrationFieldIndex.EndDate, null);
                        }
                        else
                        {
                            arbitrationEntity.EndDate = arbitration.EndDate;
                        }
                        
                        if (null == arbitrationEntity.AvailableDate)
                        {
                            arbitrationEntity.SetNewFieldValue((int)ArbitrationFieldIndex.AvailableDate, null);
                        }
                        else
                        {
                            arbitrationEntity.AvailableDate = arbitration.AvailableDate;
                        }
                        
                        if (null == arbitration.DefenseLawyer)
                        {
                            arbitrationEntity.SetNewFieldValue((int)ArbitrationFieldIndex.DefenseLawyerId, null);
                        }
                        else
                        {
                            arbitrationEntity.DefenseLawyerId = arbitration.DefenseLawyer.ContactId;
                        }
                        
                        if (string.IsNullOrWhiteSpace(arbitration.DefenseFileNumber))
                        {
                            arbitrationEntity.SetNewFieldValue((int)ArbitrationFieldIndex.DefenseFileNumber, null);
                        }
                        else
                        {
                            arbitrationEntity.DefenseFileNumber = arbitration.DefenseFileNumber;
                        }

                        if (null != arbitration.Note)
                        {
                            if (null == arbitrationEntity.Note)
                            {
                                if (!string.IsNullOrWhiteSpace(arbitration.Note.NoteText))
                                {
                                    arbitrationEntity.Note = new NoteEntity
                                    {
                                        Note = arbitration.Note.NoteText,
                                        CreateUserId = arbitration.Note.CreateUser.UserId,
                                        UpdateUserId = arbitration.Note.UpdateUser.UserId,
                                    };
                                }
                            }
                            else if (arbitrationEntity.Note.Note != arbitration.Note.NoteText)
                            {
                                arbitrationEntity.Note.Note = arbitration.Note.NoteText;
                                arbitrationEntity.Note.UpdateUserId = arbitration.Note.UpdateUser.UserId;
                                arbitrationEntity.Note.UpdateDate = _date.UtcNow;
                            }
                        }
                    }
                }

                assessmentEntity.Arbitrations.AddRange(
                    arbitrationsToAdd.Select(arbitration => new ArbitrationEntity
                    {
                        Title = arbitration.Title,
                        StartDate = arbitration.StartDate,
                        EndDate = arbitration.EndDate,
                        AvailableDate = arbitration.AvailableDate,
                        DefenseLawyerId = (null != arbitration.DefenseLawyer ? arbitration.DefenseLawyer.ContactId : (int?)null),
                        DefenseFileNumber = arbitration.DefenseFileNumber,
                        Note = null != arbitration.Note && !string.IsNullOrWhiteSpace(arbitration.Note.NoteText)
                            ? new NoteEntity
                            {
                                CreateUserId = arbitration.Note.CreateUser.UserId,
                                Note = arbitration.Note.NoteText,
                                UpdateUserId = arbitration.Note.UpdateUser.UserId,
                            }
                            : null,
                    })
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
    }
}
