﻿using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Models.Addresses;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Arbitrations;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Attributes;
using PsychologicalServices.Models.CalendarNotes;
using PsychologicalServices.Models.Cities;
using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Colors;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Contacts;
using PsychologicalServices.Models.Employers;
using PsychologicalServices.Models.Invoices;
using PsychologicalServices.Models.Notes;
using PsychologicalServices.Models.Referrals;
using PsychologicalServices.Models.Reports;
using PsychologicalServices.Models.Rights;
using PsychologicalServices.Models.Roles;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Common.Repository
{
    public static class GenProExtensions
    {
        public static IssueInDisputeInvoiceAmount ToIssueInDisputeInvoiceAmount(this IssueInDisputeInvoiceAmountEntity issueInDisputeInvoiceAmount)
        {
            return null != issueInDisputeInvoiceAmount
                ? new IssueInDisputeInvoiceAmount
                {
                    IssueInDispute = issueInDisputeInvoiceAmount.IssueInDispute.ToIssueInDispute(),
                    InvoiceAmount = issueInDisputeInvoiceAmount.InvoiceAmount,
                }
                : null;
        }

        public static PsychometristInvoiceAmount ToPsychometristInvoiceAmount(this PsychometristInvoiceAmountEntity psychometristInvoiceAmount)
        {
            return psychometristInvoiceAmount != null
                ? new PsychometristInvoiceAmount
                {
                    AssessmentTypeId = psychometristInvoiceAmount.AssessmentTypeId,
                    AppointmentStatusId = psychometristInvoiceAmount.AppointmentStatusId,
                    AppointmentSequenceId = psychometristInvoiceAmount.AppointmentSequenceId,
                    CompanyId = psychometristInvoiceAmount.CompanyId,
                    InvoiceAmount = psychometristInvoiceAmount.InvoiceAmount,
                }
                : null;
        }

        public static Arbitration ToArbitration(this ArbitrationEntity arbitration)
        {
            return null != arbitration
                ? new Arbitration
                {
                    ArbitrationId = arbitration.ArbitrationId,
                    Assessment = arbitration.Assessment.ToAppointmentAssessment(),
                    Title = arbitration.Title,
                    StartDate = arbitration.StartDate,
                    EndDate = arbitration.EndDate,
                    AvailableDate = arbitration.AvailableDate,
                    DefenseLawyer = arbitration.DefenseLawyer.ToContact(),
                    DefenseFileNumber = arbitration.DefenseFileNumber,
                }
                : null;
        }

        public static Contact ToContact(this ContactEntity contact)
        {
            return null != contact
                ? new Contact
                {
                    ContactId = contact.ContactId,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    IsActive = contact.IsActive,
                    ContactType = contact.ContactType.ToContactType(),
                    Employer = contact.Employer.ToEmployer(),
                    Address = contact.Address.ToAddress(),
                }
                : null;
        }

        public static ContactType ToContactType(this ContactTypeEntity contactType)
        {
            return null != contactType
                ? new ContactType
                {
                    ContactTypeId = contactType.ContactTypeId,
                    Name = contactType.Name,
                    IsActive = contactType.IsActive,
                }
                : null;
        }

        public static Employer ToEmployer(this EmployerEntity employer)
        {
            return null != employer
                ? new Employer
                {
                    EmployerId = employer.EmployerId,
                    Name = employer.Name,
                    EmployerType = employer.EmployerType.ToEmployerType(),
                    IsActive = employer.IsActive,
                }
                : null;
        }

        public static EmployerType ToEmployerType(this EmployerTypeEntity employerType)
        {
            return null != employerType
                ? new EmployerType
                {
                    EmployerTypeId = employerType.EmployerTypeId,
                    Name = employerType.Name,
                    IsActive = employerType.IsActive,
                }
                : null;
        }
        
        public static InvoiceType ToInvoiceType(this InvoiceTypeEntity invoiceType)
        {
            return null != invoiceType
                ? new InvoiceType
                {
                    InvoiceTypeId = invoiceType.InvoiceTypeId,
                    Name = invoiceType.Name,
                    CanSend = invoiceType.CanSend,
                    IsActive = invoiceType.IsActive,
                }
                : null;
        }

        public static AppointmentSequence ToAppointmentSequence(this AppointmentSequenceEntity appointmentSequence)
        {
            return null != appointmentSequence
                ? new AppointmentSequence
                {
                    AppointmentSequenceId = appointmentSequence.AppointmentSequenceId,
                    Name = appointmentSequence.Name,
                    IsActive = appointmentSequence.IsActive,
                }
                : null;
        }

        public static InvoiceDocumentSendLog ToInvoiceDocumentSendLog(this InvoiceDocumentSendLogEntity invoiceDocumentSendLog)
        {
            return null != invoiceDocumentSendLog
                ? new InvoiceDocumentSendLog
                {
                    InvoiceDocumentSendLogId = invoiceDocumentSendLog.InvoiceDocumentSendLogId,
                    InvoiceDocumentId = invoiceDocumentSendLog.InvoiceDocumentId,
                    Recipients = invoiceDocumentSendLog.Recipients,
                    SentDate = invoiceDocumentSendLog.SentDate,
                }
                : null;
        }

        public static InvoiceDocument ToInvoiceDocument(this InvoiceDocumentEntity invoiceDocument)
        {
            return null != invoiceDocument
                ? new InvoiceDocument
                {
                    InvoiceDocumentId = invoiceDocument.InvoiceDocumentId,
                    FileName = invoiceDocument.FileName,
                    CreateDate = invoiceDocument.CreateDate,
                    Content = invoiceDocument.Document,
                    SendLogs = invoiceDocument.InvoiceDocumentSendLogs.Select(idsl => idsl.ToInvoiceDocumentSendLog()),
                }
                : null;
        }

        private static InvoiceEntity ToInvoiceEntityBase(this Invoice invoice)
        {
            var invoiceEntity = new InvoiceEntity
            {
                InvoiceId = invoice.InvoiceId,
                IsNew = invoice.IsNew(),
                Identifier = invoice.Identifier,
                InvoiceDate = invoice.InvoiceDate,
                InvoiceRate = invoice.InvoiceRate,
                InvoiceStatusId = invoice.InvoiceStatus.InvoiceStatusId,
                InvoiceTypeId = invoice.InvoiceType.InvoiceTypeId,
                TaxRate = invoice.TaxRate,
                Total = invoice.Total,
                UpdateDate = invoice.UpdateDate,
                PayableToId = invoice.PayableTo.UserId,
            };

            return invoiceEntity;
        }

        private static InvoiceLineEntity ToInvoiceLineEntity(this InvoiceLine invoiceLine)
        {
            return new InvoiceLineEntity
            {
                InvoiceLineId = invoiceLine.InvoiceLineId,
                InvoiceAppointmentId = invoiceLine.InvoiceAppointmentId,
                Amount = invoiceLine.Amount,
                Description = invoiceLine.Description,
                IsCustom = invoiceLine.IsCustom,
                ApplyInvoiceRate = invoiceLine.ApplyInvoiceRate,
                OriginalAmount = invoiceLine.OriginalAmount,
            };
        }

        public static InvoiceEntity ToInvoiceEntity(this Invoice invoice)
        {
            var invoiceEntity = invoice.ToInvoiceEntityBase();

            foreach (var invoiceAppointment in invoice.Appointments)
            {
                var invoiceAppointmentEntity = new InvoiceAppointmentEntity
                {
                    InvoiceAppointmentId = invoiceAppointment.InvoiceAppointmentId,
                    AppointmentId = invoiceAppointment.Appointment.AppointmentId,
                };

                invoiceAppointmentEntity.InvoiceLines.AddRange(
                    invoiceAppointment.Lines.Select(invoiceLine => invoiceLine.ToInvoiceLineEntity())
                );

                invoiceEntity.InvoiceAppointments.Add(invoiceAppointmentEntity);
            }

            return invoiceEntity;
        }

        public static InvoiceEntity AddToAppointment(this Invoice invoice, AppointmentEntity appointmentEntity)
        {
            var invoiceEntity = invoice.ToInvoiceEntityBase();

            foreach (var invoiceAppointment in invoice.Appointments)
            {
                var invoiceAppointmentEntity = new InvoiceAppointmentEntity
                {
                    Invoice = invoiceEntity,
                };
                
                invoiceAppointmentEntity.InvoiceLines.AddRange(
                    invoiceAppointment.Lines.Select(invoiceLine => invoiceLine.ToInvoiceLineEntity())
                );
                
                appointmentEntity.InvoiceAppointments.Add(invoiceAppointmentEntity);
            }

            return invoiceEntity;
        }

        public static Invoice ToInvoice(this InvoiceEntity invoice)
        {
            return null != invoice
                ? new Invoice
                {
                    InvoiceId = invoice.InvoiceId,
                    Identifier = invoice.Identifier,
                    InvoiceDate = invoice.InvoiceDate,
                    InvoiceRate = invoice.InvoiceRate,
                    InvoiceStatus = invoice.InvoiceStatus.ToInvoiceStatus(),
                    InvoiceType = invoice.InvoiceType.ToInvoiceType(),
                    PayableTo = invoice.PayableTo.ToUser(),
                    UpdateDate = invoice.UpdateDate,
                    TaxRate = invoice.TaxRate,
                    Total = invoice.Total,
                    Appointments = invoice.InvoiceAppointments.Select(invoiceAppointment => invoiceAppointment.ToInvoiceAppointment()),
                    StatusChanges = invoice.InvoiceStatusChanges.Select(invoiceStatusChange => invoiceStatusChange.ToInvoiceStatusChange()),
                    Documents = invoice.InvoiceDocuments.Select(invoiceDocument => invoiceDocument.ToInvoiceDocument()),
                }
                : null;
        }

        public static InvoiceAppointment ToInvoiceAppointment(this InvoiceAppointmentEntity invoiceAppointment)
        {
            return null != invoiceAppointment
                ? new InvoiceAppointment
                {
                    InvoiceAppointmentId = invoiceAppointment.InvoiceAppointmentId,
                    Appointment = invoiceAppointment.Appointment.ToAppointment(),
                    Lines = invoiceAppointment.InvoiceLines.Select(invoiceLine => invoiceLine.ToInvoiceLine()),
                }
                : null;
        }

        public static InvoiceStatusChange ToInvoiceStatusChange(this InvoiceStatusChangeEntity invoiceStatusChange)
        {
            return null != invoiceStatusChange
                ? new InvoiceStatusChange
                {
                    InvoiceStatusChangeId = invoiceStatusChange.InvoiceStatusChangeId,
                    InvoiceStatus = invoiceStatusChange.InvoiceStatus.ToInvoiceStatus(),
                    UpdateDate = invoiceStatusChange.UpdateDate,
                }
                : null;
        }

        public static InvoiceLine ToInvoiceLine(this InvoiceLineEntity invoiceLine)
        {
            return null != invoiceLine
                ? new InvoiceLine
                {
                    InvoiceLineId = invoiceLine.InvoiceLineId,
                    InvoiceAppointmentId = invoiceLine.InvoiceAppointmentId,
                    Description = invoiceLine.Description,
                    Amount = invoiceLine.Amount,
                    IsCustom = invoiceLine.IsCustom,
                    ApplyInvoiceRate = invoiceLine.ApplyInvoiceRate,
                    OriginalAmount = invoiceLine.OriginalAmount,
                }
                : null;
        }

        public static InvoiceStatusEntity ToInvoiceStatusEntity(this InvoiceStatus invoiceStatus)
        {
            return null != invoiceStatus
                ? new InvoiceStatusEntity
                {
                    IsNew = invoiceStatus.InvoiceStatusId == 0,
                    InvoiceStatusId = invoiceStatus.InvoiceStatusId,
                    Name = invoiceStatus.Name,
                    ActionName = invoiceStatus.ActionName,
                    IsActive = invoiceStatus.IsActive,
                    CanEdit = invoiceStatus.CanEdit,
                    SaveDocument = invoiceStatus.SaveDocument,
                }
                : null;
        }

        public static InvoiceStatus ToInvoiceStatus(this InvoiceStatusEntity invoiceStatus)
        {
            return null != invoiceStatus
                ? new InvoiceStatus
                {
                    InvoiceStatusId = invoiceStatus.InvoiceStatusId,
                    Name = invoiceStatus.Name,
                    ActionName = invoiceStatus.ActionName,
                    IsActive = invoiceStatus.IsActive,
                    CanEdit = invoiceStatus.CanEdit,
                    SaveDocument = invoiceStatus.SaveDocument,
                    NextInvoiceStatuses = invoiceStatus.InvoiceStatusPaths
                        .Where(invoiceStatusPath => invoiceStatusPath.NextInvoiceStatusId.HasValue)
                        .Select(invoiceStatusPath => invoiceStatusPath.NextInvoiceStatus.ToInvoiceStatus()),
                }
                : null;
        }

        public static City ToCity(this CityEntity city)
        {
            return city != null
                ? new City
                {
                    CityId = city.CityId,
                    Name = city.Name,
                    Province = city.Province,
                    Country = city.Country,
                    IsActive = city.IsActive,
                }
                : null;
        }

        public static UserTravelFee ToUserTravelFee(this UserTravelFeeEntity userTravelFee)
        {
            return userTravelFee != null
                ? new UserTravelFee
                {
                    City = userTravelFee.City.ToCity(),
                    Amount = userTravelFee.Amount
                }
                : null;
        }

        public static Unavailability ToUnavailability(this UserUnavailabilityEntity unavailability)
        {
            return unavailability != null
                ? new Unavailability
                {
                    Id = unavailability.Id,
                    StartDate = unavailability.StartDate,
                    EndDate = unavailability.EndDate,
                }
                : null;
        }

        public static Report ToReport(this AssessmentReportEntity report)
        {
            return null != report
                ? new Report
                {
                    ReportId = report.ReportId,
                    AssessmentId = report.AssessmentId,
                    ReportType = report.ReportType.ToReportType(),
                    IsAdditional = report.IsAdditional,
                    IssuesInDispute = report.AssessmentReportIssuesInDispute.Select(assessmentReportIssueInDispute => assessmentReportIssueInDispute.IssueInDispute.ToIssueInDispute()),
                }
                : null;
        }

        public static AttributeValue ToAttributeValue(this AppointmentAttributeEntity appointmentAttribute)
        {
            return null != appointmentAttribute
                ? new AttributeValue
                {
                    Attribute = appointmentAttribute.Attribute.ToAttribute(),
                    Value = appointmentAttribute.Value,
                }
                : null;
        }

        public static AttributeValue ToAttributeValue(this AssessmentAttributeEntity assessmentAttribute)
        {
            return null != assessmentAttribute
                ? new AttributeValue
                {
                    Attribute = assessmentAttribute.Attribute.ToAttribute(),
                    Value = assessmentAttribute.Value,
                }
                : null;
        }

        public static Models.Attributes.Attribute ToAttribute(this AttributeEntity attribute)
        {
            return null != attribute
                ? new Models.Attributes.Attribute
                {
                    AttributeId = attribute.AttributeId,
                    Name = attribute.Name,
                    AttributeType = attribute.AttributeType.ToAttributeType(),
                    IsActive = attribute.IsActive,
                    Companies = attribute.CompanyAttributes.Select(companyAttribute => companyAttribute.Company.ToCompany()),
                }
                : null;
        }

        public static AttributeType ToAttributeType(this AttributeTypeEntity attributeType)
        {
            return null != attributeType
                ? new AttributeType
                {
                    AttributeTypeId = attributeType.AttributeTypeId,
                    Name = attributeType.Name,
                    ShowOnAppointment = attributeType.ShowOnAppointment,
                    IsActive = attributeType.IsActive,
                }
                : null;
        }

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
                    Company = calendarNote.Company.ToCompany(),
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
                    CreateUser = note.CreateUser.ToUser(),
                    UpdateUser = note.UpdateUser.ToUser(),
                    Recipients = note.UserNotes.Select(userNote => userNote.User.ToUser()),
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
                    Lawyer = claim.Lawyer,
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
                    InvoicesContactEmail = referralSource.InvoicesContactEmail,
                    IsActive = referralSource.IsActive,
                    ReferralSourceType = referralSource.ReferralSourceType.ToReferralSourceType(),
                    Address = referralSource.Address.ToAddress(),
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
                    IsActive = assessmentType.IsActive,
                    ShowOnSchedule = assessmentType.ShowOnSchedule,
                    PsychometristCanInvoice = assessmentType.PsychometristCanInvoice,
                    ReportTypes = assessmentType.AssessmentTypeReportTypes.Select(assessmentTypeReportType => assessmentTypeReportType.ReportType.ToReportType()),
                    AttributeTypes = assessmentType.AssessmentTypeAttributeTypes.Select(assessmentTypeAttributeType => assessmentTypeAttributeType.AttributeType.ToAttributeType()),
                }
                : null;
        }

        public static AssessmentNote ToAssessmentNote(this AssessmentNoteEntity assessmentNote)
        {
            return null != assessmentNote
                ? new AssessmentNote
                {
                    ShowOnCalendar = assessmentNote.ShowOnCalendar,
                    Note = assessmentNote.Note.ToNote(),
                }
                : null;
        }

        public static AssessmentSearchResult ToAssessmentSearchResult(this AppointmentEntity appointment)
        {
            return null != appointment
                ? new AssessmentSearchResult
                {
                    AssessmentId = appointment.Assessment.AssessmentId,
                    AssessmentType = appointment.Assessment.AssessmentType.Name,
                    ReferralSource = appointment.Assessment.ReferralSource.Name,
                    Claimant = appointment.Assessment.AssessmentClaims.Any()
                        ? appointment.Assessment.AssessmentClaims.Select(assessmentClaim => $"{assessmentClaim.Claim.Claimant.FirstName} {assessmentClaim.Claim.Claimant.LastName}").First()
                        : "",
                    AppointmentTime = appointment.AppointmentTime,
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
                    ReferralSourceFileNumber = assessment.ReferralSourceFileNumber,
                    ReferralSourceContactEmail = assessment.ReferralSourceContactEmail,
                    IsLargeFile = assessment.IsLargeFile,
                    AssessmentType = assessment.AssessmentType.ToAssessmentType(),
                    ReferralType = assessment.ReferralType.ToReferralType(),
                    ReferralSource = assessment.ReferralSource.ToReferralSource(),
                    ReportStatus = assessment.ReportStatus.ToReportStatus(),
                    DocListWriter = assessment.DocListWriter.ToUser(),
                    NotesWriter = assessment.NotesWriter.ToUser(),
                    Company = assessment.Company.ToCompany(),
                    Claims = assessment.AssessmentClaims.Select(assessmentClaim => assessmentClaim.Claim.ToClaim()),
                    Appointments = assessment.Appointments.Select(appointment => appointment.ToAppointment()),
                    MedRehabs = assessment.AssessmentMedRehabs.Select(assessmentMedRehab => assessmentMedRehab.ToMedRehab()),
                    AssessmentNotes = assessment.AssessmentNotes.Select(assessmentNote => assessmentNote.ToAssessmentNote()),
                    Colors = assessment.AssessmentColors.Select(assessmentColor => assessmentColor.Color.ToColor()),
                    Attributes = assessment.AssessmentAttributes.Select(assessmentAttribute => assessmentAttribute.ToAttributeValue()),
                    Reports = assessment.AssessmentReports.Select(assessmentReport => assessmentReport.ToReport()),
                    Arbitrations = assessment.Arbitrations.Select(arbitration => arbitration.ToArbitration()),
                    CreateDate = assessment.CreateDate,
                    CreateUser = assessment.CreateUser.ToUser(),
                    UpdateDate = assessment.UpdateDate,
                    UpdateUser = assessment.UpdateUser.ToUser(),
                    Summary = assessment.Summary.ToNote(),
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
                    ReferralSourceFileNumber = assessment.ReferralSourceFileNumber,
                    ReferralSourceContactEmail = assessment.ReferralSourceContactEmail,
                    IsLargeFile = assessment.IsLargeFile,
                    AssessmentType = assessment.AssessmentType.ToAssessmentType(),
                    ReferralType = assessment.ReferralType.ToReferralType(),
                    ReferralSource = assessment.ReferralSource.ToReferralSource(),
                    ReportStatus = assessment.ReportStatus.ToReportStatus(),
                    DocListWriter = assessment.DocListWriter.ToUser(),
                    NotesWriter = assessment.NotesWriter.ToUser(),
                    Company = assessment.Company.ToCompany(),
                    Claims = assessment.AssessmentClaims.Select(assessmentClaim => assessmentClaim.Claim.ToClaim()),
                    Attributes = assessment.AssessmentAttributes.Select(assessmentAttribute => assessmentAttribute.ToAttributeValue()),
                    Reports = assessment.AssessmentReports.Select(assessmentReport => assessmentReport.ToReport()),
                    MedRehabs = assessment.AssessmentMedRehabs.Select(assessmentMedRehab => assessmentMedRehab.ToMedRehab()),
                    AssessmentNotes = assessment.AssessmentNotes.Select(assessmentNote => assessmentNote.ToAssessmentNote()),
                    Colors = assessment.AssessmentColors.Select(assessmentColor => assessmentColor.Color.ToColor()),
                    Summary = assessment.Summary.ToNote(),
                    //Appointments
                    //Arbitrations
                    //CreateUser
                    //UpdateUser
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
                    CanInvoice = appointmentStatus.CanInvoice,
                    ShowOnSchedule = appointmentStatus.ShowOnSchedule,
                    ClaimantSeen = appointmentStatus.ClaimantSeen,
                    IsActive = appointmentStatus.IsActive,
                    Sort = appointmentStatus.Sort,
                }
                : null;
        }

        public static Appointment ToAppointment(this AppointmentEntity appointment)
        {
            return null != appointment
                ? new Appointment
                {
                    AppointmentId = appointment.AppointmentId,
                    AppointmentTime = appointment.AppointmentTime,
                    Location = appointment.Location.ToAddress(),
                    Psychometrist = appointment.Psychometrist.ToUser(),
                    Psychologist = appointment.Psychologist.ToUser(),
                    AppointmentStatus = appointment.AppointmentStatus.ToAppointmentStatus(),
                    Assessment = appointment.Assessment.ToAppointmentAssessment(),
                    Attributes = appointment.AppointmentAttributes.Select(appointmentAttribute => appointmentAttribute.ToAttributeValue()),
                    CreateDate = appointment.CreateDate,
                    CreateUser = appointment.CreateUser.ToUser(),
                    UpdateDate = appointment.UpdateDate,
                    UpdateUser = appointment.UpdateUser.ToUser(),
                    RoomRentalBillableAmount = appointment.RoomRentalBillableAmount,
                    IsCompletion = appointment.IsCompletion(),
                }
                : null;
        }

        public static Appointment ToPsychologistInvoiceAppointment(this AppointmentEntity appointment)
        {
            return null != appointment
                ? new Appointment
                {
                    AppointmentId = appointment.AppointmentId,
                    AppointmentTime = appointment.AppointmentTime,
                    Location = appointment.Location.ToAddress(),
                    Psychometrist = appointment.Psychometrist.ToUser(),
                    Psychologist = appointment.Psychologist.ToUser(),
                    AppointmentStatus = appointment.AppointmentStatus.ToAppointmentStatus(),
                    Assessment = appointment.Assessment.ToPsychologistInvoiceAssessment(),
                    Attributes = appointment.AppointmentAttributes.Select(appointmentAttribute => appointmentAttribute.ToAttributeValue()),
                    CreateDate = appointment.CreateDate,
                    CreateUser = appointment.CreateUser.ToUser(),
                    UpdateDate = appointment.UpdateDate,
                    UpdateUser = appointment.UpdateUser.ToUser(),
                    RoomRentalBillableAmount = appointment.RoomRentalBillableAmount,
                    IsCompletion = appointment.IsCompletion(),
                }
                : null;
        }

        public static Assessment ToPsychologistInvoiceAssessment(this AssessmentEntity assessment)
        {
            return null != assessment
                ? new Assessment
                {
                    AssessmentId = assessment.AssessmentId,
                    MedicalFileReceivedDate = assessment.MedicalFileReceivedDate,
                    FileSize = assessment.FileSize,
                    ReferralSourceFileNumber = assessment.ReferralSourceFileNumber,
                    ReferralSourceContactEmail = assessment.ReferralSourceContactEmail,
                    IsLargeFile = assessment.IsLargeFile,
                    AssessmentType = assessment.AssessmentType.ToAssessmentType(),
                    ReferralType = assessment.ReferralType.ToReferralType(),
                    ReferralSource = assessment.ReferralSource.ToReferralSource(),
                    ReportStatus = assessment.ReportStatus.ToReportStatus(),
                    Company = assessment.Company.ToCompany(),
                    Claims = assessment.AssessmentClaims.Select(assessmentClaim => assessmentClaim.Claim.ToClaim()),
                    Reports = assessment.AssessmentReports.Select(assessmentReport => assessmentReport.ToReport()),
                    Appointments = assessment.Appointments.Select(appointment => appointment.ToAppointment()),
                }
                : null;
        }
        
        public static bool IsCompletion(this AppointmentEntity appointment)
        {
            return
                null != appointment &&
                null != appointment.Assessment &&
                null != appointment.Assessment.Appointments &&
                appointment.IsCompletion(appointment.Assessment.Appointments);
        }
        
        public static bool IsCompletion(this AppointmentEntity appointment, IEnumerable<AppointmentEntity> appointments)
        {
            return
                null != appointment &&
                null != appointments &&
                appointments.Any(appt =>
                    appt.AssessmentId == appointment.AssessmentId &&
                    appt.AppointmentStatusId == AppointmentStatus.Incomplete &&
                    appt.AppointmentTime < appointment.AppointmentTime
                );
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
                    Name = address.Name,
                    Street = address.Street,
                    Suite = address.Suite,
                    City = address.City.ToCity(),
                    PostalCode = address.PostalCode,
                    AddressTypes = address.AddressAddressTypes.Select(addressAddressType => addressAddressType.AddressType.ToAddressType()),
                    IsActive = address.IsActive,
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
                    Address = company.Address.ToAddress(),
                    IsActive = company.IsActive,
                    Phone = company.Phone,
                    Fax = company.Fax,
                    Email = company.Email,
                    ReplyToEmail = company.ReplyToEmail,
                    TaxId = company.TaxId,
                    Timezone = company.Timezone,
                    NewAppointmentTime = TimeSpan.FromTicks(company.NewAppointmentTime),
                    NewAppointmentLocation = company.NewAppointmentLocation.ToAddress(),
                    NewAppointmentPsychologist = company.NewAppointmentPsychologist.ToUser(),
                    NewAppointmentPsychometrist = company.NewAppointmentPsychometrist.ToUser(),
                    NewAppointmentStatus = company.NewAppointmentStatus.ToAppointmentStatus(),
                    NewAssessmentAssessmentType = company.NewAssessmentAssessmentType.ToAssessmentType(),
                    NewAssessmentReportStatus = company.NewAssessmentReportStatus.ToReportStatus(),
                    NewAssessmentSummary = new Note
                    {
                        NoteText = company.NewAssessmentSummaryNoteText.Replace("\\r","\r").Replace("\\n","\n"),
                    }
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
                    IsActive = user.IsActive,
                    Company = user.Company.ToCompany(),
                    Roles = user.UserRoles.Select(userRole => userRole.Role.ToRole()).ToList(),
                    Unavailability = user.UserUnavailabilities.Select(userUnavailability => userUnavailability.ToUnavailability()),
                    TravelFees = user.UserTravelFees.Select(userTravelFee => userTravelFee.ToUserTravelFee()),
                    Address = user.Address.ToAddress(),
                }
                : null;
        }

        public static User ToPsychometristScheduleUser(this UserEntity user)
        {
            return null != user
                ? new User
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    Company = user.Company.ToCompany(),
                    Roles = user.UserRoles.Select(userRole => userRole.Role.ToRole()).ToList(),
                    PsychometristAppointments = user.PsychometristAppointments.Select(appointment => appointment.ToAppointment()),
                }
                : null;
        }

        public static User ToUserLite(this UserEntity user)
        {
            return null != user
                ? new User
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    Company = user.Company.ToCompany(),
                    Roles = user.UserRoles.Select(userRole => userRole.Role.ToRole()).ToList(),
                    Unavailability = user.UserUnavailabilities.Select(userUnavailability => userUnavailability.ToUnavailability()),
                }
                : null;
        }
    }
}
