using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Models.Addresses;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.CalendarNotes;
using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Colors;
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
    public static class GenProExtensions
    {
        public static Color ToColor(this ColorEntity color)
        {
            return null != color
                ? new Color
                {
                    ColorId = color.ColorId,
                    Name = color.Name,
                    HexCode = color.HexCode,
                    IsActive = color.IsActive,
                }
                : null;
        }

        public static MedRehab ToMedRehab(this AssessmentMedRehabEntity medRehab)
        {
            return null != medRehab
                ? new MedRehab
                {
                    MedRehabId = medRehab.MedRehabId,
                    Date = medRehab.Date,
                    Amount = medRehab.Amount,
                    Description = medRehab.Description,
                    Deleted = medRehab.Deleted,
                    AssessmentId = medRehab.AssessmentId,
                }
                : null;
        }

        public static CalendarNote ToCalendarNote(this CalendarNoteEntity calendarNote)
        {
            return null != calendarNote
                ? new CalendarNote
                {
                    CalendarNoteId = calendarNote.CalendarNoteId,
                    FromDate = calendarNote.FromDate,
                    ToDate = calendarNote.ToDate,
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
                    CreateDate = note.CreateDate,
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
                    ReportType = invoiceAmount.ReportType.ToReportType(),
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
                    DateOfBirth = claimant.DateOfBirth,
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
                    LargeFileSize = referralSource.LargeFileSize,
                    LargeFileFeeAmount = referralSource.LargeFileFeeAmount,
                    IsActive = referralSource.IsActive,
                    ReferralSourceType = referralSource.ReferralSourceType.ToReferralSourceType(),
                    InvoiceAmounts = referralSource.InvoiceAmounts.Select(invoiceAmount => invoiceAmount.ToInvoiceAmount()),
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
                    IssuesInDispute = referralType.ReferralTypeIssuesInDispute.Select(referralTypeIssueInDispute => referralTypeIssueInDispute.IssueInDispute.ToIssueInDispute()),
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
                    ReportTypes = assessmentType.AssessmentTypeReportTypes.Select(assessmentTypeReportType => assessmentTypeReportType.ReportType.ToReportType()),
                }
                : null;
        }

        public static Assessment ToAssessment(this AssessmentEntity assessment)
        {
            return null != assessment
                ? new Assessment
                {
                    AssessmentId = assessment.AssessmentId,
                    MedicalFileReceivedDate = assessment.MedicalFileReceivedDate,
                    FileSize = assessment.FileSize,
                    ReferralSourceContactEmail = assessment.ReferralSourceContactEmail,
                    Deleted = assessment.Deleted,
                    Psychiatrist = assessment.Psychiatrist,
                    TypicalDay = assessment.TypicalDay,
                    WorkHistory = assessment.WorkHistory,
                    AssessmentType = assessment.AssessmentType.ToAssessmentType(),
                    ReferralType = assessment.ReferralType.ToReferralType(),
                    ReferralSource = assessment.ReferralSource.ToReferralSource(),
                    ReportStatus = assessment.ReportStatus.ToReportStatus(),
                    DocListWriter = assessment.DocListWriter.ToUser(),
                    NotesWriter = assessment.NotesWriter.ToUser(),
                    Company = assessment.Company.ToCompany(),
                    Claims = assessment.AssessmentClaims.Select(assessmentClaim => assessmentClaim.Claim.ToClaim()),
                    Appointments = assessment.Appointments.Select(appointment => appointment.ToAppointment()),
                    IssuesInDispute = assessment.AssessmentIssuesInDispute.Select(assessmentIssueInDispute => assessmentIssueInDispute.IssueInDispute.ToIssueInDispute()),
                    MedRehabs = assessment.AssessmentMedRehabs.Select(assessmentMedRehab => assessmentMedRehab.ToMedRehab()),
                    Notes = assessment.AssessmentNotes.Select(assessmentNote => assessmentNote.Note.ToNote()),
                    Colors = assessment.AssessmentColors.Select(assessmentColor => assessmentColor.Color.ToColor()),
                }
                : null;
        }

        public static Assessment ToAppointmentAssessment(this AssessmentEntity assessment)
        {
            return null != assessment
                ? new Assessment
                {
                    AssessmentId = assessment.AssessmentId,
                    MedicalFileReceivedDate = assessment.MedicalFileReceivedDate,
                    FileSize = assessment.FileSize,
                    ReferralSourceContactEmail = assessment.ReferralSourceContactEmail,
                    Deleted = assessment.Deleted,
                    AssessmentType = assessment.AssessmentType.ToAssessmentType(),
                    ReferralType = assessment.ReferralType.ToReferralType(),
                    ReferralSource = assessment.ReferralSource.ToReferralSource(),
                    ReportStatus = assessment.ReportStatus.ToReportStatus(),
                    DocListWriter = assessment.DocListWriter.ToUser(),
                    NotesWriter = assessment.NotesWriter.ToUser(),
                    Company = assessment.Company.ToCompany(),
                    Claims = assessment.AssessmentClaims.Select(assessmentClaim => assessmentClaim.Claim.ToClaim()),
                    //Appointments = assessment.Appointments.Select(appointment => appointment.ToAppointment()),
                    IssuesInDispute = assessment.AssessmentIssuesInDispute.Select(assessmentIssueInDispute => assessmentIssueInDispute.IssueInDispute.ToIssueInDispute()),
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
                    //convenience property
                    CompanyId = appointment.Assessment.CompanyId,
                    AppointmentTime = appointment.AppointmentTime,
                    PsychometristConfirmed = appointment.PsychometristConfirmed,
                    Deleted = appointment.Deleted,
                    Location = appointment.Location.ToAddress(),
                    Psychometrist = appointment.Psychometrist.ToUser(),
                    Psychologist = appointment.Psychologist.ToUser(),
                    AppointmentStatus = appointment.AppointmentStatus.ToAppointmentStatus(),
                    AppointmentTasks = appointment.AppointmentTasks.Select(appointmentTask => appointmentTask.Task.ToTask()),
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
                    Name = address.Name,
                    IsActive = address.IsActive,
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
                    Rights = role.RoleRights.Select(roleRight => roleRight.Right.ToRight()).ToList(),
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
                    Roles = user.UserRoles.Select(userRole => userRole.Role.ToRole()).ToList(),
                }
                : null;
        }
    }
}
