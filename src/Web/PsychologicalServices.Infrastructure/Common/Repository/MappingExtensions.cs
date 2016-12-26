using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Models.Addresses;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.CalendarNotes;
using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Invoices;
using PsychologicalServices.Models.Notes;
using PsychologicalServices.Models.Referrals;
using PsychologicalServices.Models.Reports;
using PsychologicalServices.Models.Rights;
using PsychologicalServices.Models.Roles;
using PsychologicalServices.Models.Tasks;
using PsychologicalServices.Models.TaskTemplates;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Common.Repository
{
    public static class MappingExtensions
    {
        public static CalendarNote ToCalendarNote(this CalendarNoteEntity calendarNote)
        {
            return null != calendarNote
                ? new CalendarNote
                {
                    CalendarNoteId = calendarNote.CalendarNoteId,
                    FromDate = calendarNote.FromDate,
                    ToDate = calendarNote.ToDate,
                    NoteId = calendarNote.NoteId,
                    Note = calendarNote.Note.ToNote(),
                }
                : null;
        }

        public static Note ToNote(this NoteEntity note)
        {
            return null != note
                ? new Note
                {
                    NoteId = note.NoteId,
                    NoteText = note.Note,
                    CreateUserId = note.CreateUserId,
                    CreateDate = note.CreateDate,
                    UpdateUserId = note.UpdateUserId,
                    UpdateDate = note.UpdateDate,
                    Deleted = note.Deleted,
                    CreateUser = note.CreateUser.ToUser(),
                    UpdateUser = note.UpdateUser.ToUser(),
                }
                : null;
        }

        public static InvoiceAmount ToInvoiceAmount(this InvoiceAmountEntity invoiceAmount)
        {
            return null != invoiceAmount
                ? new InvoiceAmount
                {
                    ReferralSourceId = invoiceAmount.ReferralSourceId,
                    ReportTypeId = invoiceAmount.ReportTypeId,
                    Amount = invoiceAmount.InvoiceAmount,
                }
                : null;
        }

        public static Claimant ToClaimant(this ClaimantEntity claimant)
        {
            return null != claimant
                ? new Claimant
                {
                    ClaimantId = claimant.ClaimantId,
                    FirstName = claimant.FirstName,
                    LastName = claimant.LastName,
                    Age = claimant.Age,
                    Gender = claimant.Gender,
                    IsActive = claimant.IsActive,
                }
                : null;
        }

        public static Claim ToClaim(this ClaimEntity claim)
        {
            return null != claim
                ? new Claim
                {
                    ClaimId = claim.ClaimId,
                    ClaimNumber = claim.ClaimNumber,
                    DateOfLoss = claim.DateOfLoss,
                    ClaimantId = claim.ClaimantId,
                    Claimant = claim.Claimant.ToClaimant(),
                    Deleted = claim.Deleted,
                }
                : null;
        }

        public static ReportStatus ToReportStatus(this ReportStatusEntity reportStatus)
        {
            return null != reportStatus
                ? new ReportStatus
                {
                    ReportStatusId = reportStatus.ReportStatusId,
                    Name = reportStatus.Name,
                    IsActive = reportStatus.IsActive,
                }
                : null;
        }

        public static ReferralSourceType ToReferralSourceType(this ReferralSourceTypeEntity referralSourceType)
        {
            return null != referralSourceType
                ? new ReferralSourceType
                {
                    ReferralSourceTypeId = referralSourceType.ReferralSourceTypeId,
                    Name = referralSourceType.Name,
                    IsActive = referralSourceType.IsActive,
                }
                : null;
        }

        public static ReferralSource ToReferralSource(this ReferralSourceEntity referralSource)
        {
            return null != referralSource
                ? new ReferralSource
                {
                    ReferralSourceId = referralSource.ReferralSourceId,
                    Name = referralSource.Name,
                    ReferralSourceTypeId = referralSource.ReferralSourceTypeId,
                    LargeFileSize = referralSource.LargeFileSize,
                    LargeFileFeeAmount = referralSource.LargeFileFeeAmount,
                    IsActive = referralSource.IsActive,
                    ReferralSourceType = referralSource.ReferralSourceType.ToReferralSourceType(),
                }
                : null;
        }

        public static IssueInDispute ToIssueInDispute(this IssueInDisputeEntity issueInDispute)
        {
            return null != issueInDispute
                ? new IssueInDispute
                {
                    IssueInDisputeId = issueInDispute.IssueInDisputeId,
                    Name = issueInDispute.Name,
                    Instructions = issueInDispute.Instructions,
                    IsActive = issueInDispute.IsActive,
                }
                : null;
        }

        public static ReferralType ToReferralType(this ReferralTypeEntity referralType)
        {
            return null != referralType
                ? new ReferralType
                {
                    ReferralTypeId = referralType.ReferralTypeId,
                    Name = referralType.Name,
                    IsActive = referralType.IsActive,
                    IssuesInDispute = referralType.IssueInDisputeCollectionViaReferralTypeIssuesInDispute.Select(issueInDispute => issueInDispute.ToIssueInDispute()),
                }
                : null;
        }

        public static ReportType ToReportType(this ReportTypeEntity reportType)
        {
            return null != reportType
                ? new ReportType
                {
                    ReportTypeId = reportType.ReportTypeId,
                    Name = reportType.Name,
                    NumberOfReports = reportType.NumberOfReports,
                    IsActive = reportType.IsActive,
                }
                : null;
        }

        public static AssessmentType ToAssessmentType(this AssessmentTypeEntity assessmentType)
        {
            return null != assessmentType
                ? new AssessmentType
                {
                    AssessmentTypeId = assessmentType.AssessmentTypeId,
                    Name = assessmentType.Name,
                    Description = assessmentType.Description,
                    Duration = assessmentType.Duration,
                    IsActive = assessmentType.IsActive,
                    ReportTypes = assessmentType.ReportTypeCollectionViaAssessmentTypeReportTypes.Select(reportType => reportType.ToReportType()),
                }
                : null;
        }

        public static Assessment ToAssessment(this AssessmentEntity assessment)
        {
            return null != assessment
                ? new Assessment
                {
                    AssessmentId = assessment.AssessmentId,
                    AssessmentTypeId = assessment.AssessmentTypeId,
                    ReferralTypeId = assessment.ReferralTypeId,
                    ReferralSourceId = assessment.ReferralSourceId,
                    ReportStatusId = assessment.ReportStatusId,
                    DocListWriterId = assessment.DocListWriterId,
                    NotesWriterId = assessment.NotesWriterId,
                    MedicalFileReceivedDate = assessment.MedicalFileReceivedDate,
                    FileSize = assessment.FileSize,
                    ReferralSourceContactEmail = assessment.ReferralSourceContactEmail,
                    CompanyId = assessment.CompanyId,
                    Deleted = assessment.Deleted,
                    AssessmentType = assessment.AssessmentType.ToAssessmentType(),
                    ReferralType = assessment.ReferralType.ToReferralType(),
                    ReferralSource = assessment.ReferralSource.ToReferralSource(),
                    ReportStatus = assessment.ReportStatus.ToReportStatus(),
                    DocListWriter = assessment.DocListWriter.ToUser(),
                    NotesWriter = assessment.NotesWriter.ToUser(),
                    Company = assessment.Company.ToCompany(),
                    Claims = assessment.ClaimCollectionViaAssessmentClaims.Select(claim => claim.ToClaim()),
                    Appointments = assessment.Appointments.Select(appointment => appointment.ToAppointment()),
                    IssuesInDispute = assessment.IssueInDisputeCollectionViaAssessmentIssuesInDispute.Select(issueInDispute => issueInDispute.ToIssueInDispute()),
                }
                : null;
        }

        public static Assessment ToAppointmentAssessment(this AssessmentEntity assessment)
        {
            return null != assessment
                ? new Assessment
                {
                    AssessmentId = assessment.AssessmentId,
                    AssessmentTypeId = assessment.AssessmentTypeId,
                    ReferralTypeId = assessment.ReferralTypeId,
                    ReferralSourceId = assessment.ReferralSourceId,
                    ReportStatusId = assessment.ReportStatusId,
                    DocListWriterId = assessment.DocListWriterId,
                    NotesWriterId = assessment.NotesWriterId,
                    MedicalFileReceivedDate = assessment.MedicalFileReceivedDate,
                    FileSize = assessment.FileSize,
                    ReferralSourceContactEmail = assessment.ReferralSourceContactEmail,
                    CompanyId = assessment.CompanyId,
                    Deleted = assessment.Deleted,
                    AssessmentType = assessment.AssessmentType.ToAssessmentType(),
                    ReferralType = assessment.ReferralType.ToReferralType(),
                    ReferralSource = assessment.ReferralSource.ToReferralSource(),
                    ReportStatus = assessment.ReportStatus.ToReportStatus(),
                    DocListWriter = assessment.DocListWriter.ToUser(),
                    NotesWriter = assessment.NotesWriter.ToUser(),
                    Company = assessment.Company.ToCompany(),
                    Claims = assessment.ClaimCollectionViaAssessmentClaims.Select(claim => claim.ToClaim()),
                    //Appointments = assessment.Appointments.Select(appointment => appointment.ToAppointment()),
                    IssuesInDispute = assessment.IssueInDisputeCollectionViaAssessmentIssuesInDispute.Select(issueInDispute => issueInDispute.ToIssueInDispute()),
                }
                : null;
        }

        public static TaskTemplate ToTaskTemplate(this TaskTemplateEntity taskTemplate)
        {
            return null != taskTemplate
                ? new TaskTemplate
                {
                    TaskTemplateId = taskTemplate.TaskTemplateId,
                    Name = taskTemplate.Name,
                    CompanyId = taskTemplate.CompanyId,
                    IsActive = taskTemplate.IsActive,
                    Company = taskTemplate.Company.ToCompany(),
                }
                : null;
        }

        public static TaskStatus ToTaskStatus(this TaskStatusEntity taskStatus)
        {
            return null != taskStatus
                ? new TaskStatus
                {
                    TaskStatusId = taskStatus.TaskStatusId,
                    Name = taskStatus.Name,
                    IsActive = taskStatus.IsActive,
                }
                : null;
        }

        public static Task ToTask(this TaskEntity task)
        {
            return null != task
                ? new Task
                {
                    TaskId = task.TaskId,
                    TaskTemplateId = task.TaskTemplateId,
                    TaskStatusId = task.TaskStatusId,
                    TaskStatus = task.TaskStatus.ToTaskStatus(),
                    TaskTemplate = task.TaskTemplate.ToTaskTemplate(),
                }
                : null;
        }

        public static AppointmentStatus ToAppointmentStatus(this AppointmentStatusEntity appointmentStatus)
        {
            return null != appointmentStatus
                ? new AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatus.AppointmentStatusId,
                    Name = appointmentStatus.Name,
                    Description = appointmentStatus.Description,
                    NotifyReferralSource = appointmentStatus.NotifyReferralSource,
                    IsActive = appointmentStatus.IsActive,
                }
                : null;
        }

        public static Appointment ToAppointment(this AppointmentEntity appointment)
        {
            return null != appointment
                ? new Appointment
                {
                    AppointmentId = appointment.AppointmentId,
                    LocationId = appointment.LocationId,
                    PsychometristId = appointment.PsychometristId,
                    PsychologistId = appointment.PsychologistId,
                    AppointmentStatusId = appointment.AppointmentStatusId,
                    CompanyId = appointment.Assessment.CompanyId,
                    AppointmentTime = appointment.AppointmentTime,
                    AssessmentId = appointment.AssessmentId,
                    PsychometristConfirmed = appointment.PsychometristConfirmed,
                    Location = appointment.Location.ToAddress(),
                    Psychometrist = appointment.Psychometrist.ToUser(),
                    Psychologist = appointment.Psychologist.ToUser(),
                    AppointmentStatus = appointment.AppointmentStatus.ToAppointmentStatus(),
                    AppointmentTasks = appointment.TaskCollectionViaAppointmentTasks.Select(task => task.ToTask()),
                    Assessment = appointment.Assessment.ToAppointmentAssessment(),
                }
                : null;
        }

        public static AddressType ToAddressType(this AddressTypeEntity addressType)
        {
            return null != addressType
                ? new AddressType
                {
                    AddressTypeId = addressType.AddressTypeId,
                    Name = addressType.Name,
                    IsActive = addressType.IsActive,
                }
                : null;
        }

        public static Address ToAddress(this AddressEntity address)
        {
            return null != address
                ? new Address
                {
                    AddressId = address.AddressId,
                    Street = address.Street,
                    Suite = address.Suite,
                    City = address.City,
                    PostalCode = address.PostalCode,
                    Province = address.Province,
                    Country = address.Country,
                    AddressTypeId = address.AddressTypeId,
                    AddressType = address.AddressType.ToAddressType(),
                }
                : null;
        }

        public static Company ToCompany(this CompanyEntity company)
        {
            return null != company
                ? new Company
                {
                    CompanyId = company.CompanyId,
                    Name = company.Name,
                    IsActive = company.IsActive,
                }
                : null;
        }

        public static Right ToRight(this RightEntity right)
        {
            return null != right
                ? new Right
                {
                    RightId = right.RightId,
                    Name = right.Name,
                    Description = right.Description,
                    IsActive = right.IsActive,
                }
                : null;
        }

        public static Role ToRole(this RoleEntity role)
        {
            return null != role
                ? new Role
                {
                    RoleId = role.RoleId,
                    Name = role.Name,
                    Description = role.Description,
                    IsActive = role.IsActive,
                    Rights = role.RightCollectionViaRoleRights.Select(right => right.ToRight()).ToList(),
                }
                : null;
        }

        public static User ToUser(this UserEntity user)
        {
            return null != user
                ? new User
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    CompanyId = user.CompanyId,
                    IsActive = user.IsActive,
                    Company = user.Company.ToCompany(),
                    Roles = user.RoleCollectionViaUserRoles.Select(role => role.ToRole()).ToList(),
                }
                : null;
        }
    }
}
