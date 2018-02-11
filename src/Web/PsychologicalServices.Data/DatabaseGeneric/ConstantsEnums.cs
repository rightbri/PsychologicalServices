﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.3.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;

namespace PsychologicalServices.Data
{
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Address.</summary>
	public enum AddressFieldIndex
	{
		///<summary>AddressId. </summary>
		AddressId,
		///<summary>Name. </summary>
		Name,
		///<summary>Street. </summary>
		Street,
		///<summary>Suite. </summary>
		Suite,
		///<summary>CityId. </summary>
		CityId,
		///<summary>PostalCode. </summary>
		PostalCode,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AddressAddressType.</summary>
	public enum AddressAddressTypeFieldIndex
	{
		///<summary>AddressId. </summary>
		AddressId,
		///<summary>AddressTypeId. </summary>
		AddressTypeId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AddressType.</summary>
	public enum AddressTypeFieldIndex
	{
		///<summary>AddressTypeId. </summary>
		AddressTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Appointment.</summary>
	public enum AppointmentFieldIndex
	{
		///<summary>AppointmentId. </summary>
		AppointmentId,
		///<summary>LocationId. </summary>
		LocationId,
		///<summary>AppointmentTime. </summary>
		AppointmentTime,
		///<summary>PsychometristId. </summary>
		PsychometristId,
		///<summary>PsychologistId. </summary>
		PsychologistId,
		///<summary>AppointmentStatusId. </summary>
		AppointmentStatusId,
		///<summary>AssessmentId. </summary>
		AssessmentId,
		///<summary>CreateDate. </summary>
		CreateDate,
		///<summary>CreateUserId. </summary>
		CreateUserId,
		///<summary>UpdateDate. </summary>
		UpdateDate,
		///<summary>UpdateUserId. </summary>
		UpdateUserId,
		///<summary>RoomRentalBillableAmount. </summary>
		RoomRentalBillableAmount,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AppointmentAttribute.</summary>
	public enum AppointmentAttributeFieldIndex
	{
		///<summary>AppointmentId. </summary>
		AppointmentId,
		///<summary>AttributeId. </summary>
		AttributeId,
		///<summary>Value. </summary>
		Value,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AppointmentSequence.</summary>
	public enum AppointmentSequenceFieldIndex
	{
		///<summary>AppointmentSequenceId. </summary>
		AppointmentSequenceId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AppointmentStatus.</summary>
	public enum AppointmentStatusFieldIndex
	{
		///<summary>AppointmentStatusId. </summary>
		AppointmentStatusId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>NotifyReferralSource. </summary>
		NotifyReferralSource,
		///<summary>CanInvoice. </summary>
		CanInvoice,
		///<summary>Sort. </summary>
		Sort,
		///<summary>ShowOnSchedule. </summary>
		ShowOnSchedule,
		///<summary>ClaimantSeen. </summary>
		ClaimantSeen,
		///<summary>IsFinalStatus. </summary>
		IsFinalStatus,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AppointmentStatusInvoiceRate.</summary>
	public enum AppointmentStatusInvoiceRateFieldIndex
	{
		///<summary>CompanyId. </summary>
		CompanyId,
		///<summary>ReferralSourceId. </summary>
		ReferralSourceId,
		///<summary>AppointmentStatusId. </summary>
		AppointmentStatusId,
		///<summary>AppointmentSequenceId. </summary>
		AppointmentSequenceId,
		///<summary>InvoiceRate. </summary>
		InvoiceRate,
		///<summary>ApplyCompletionFee. </summary>
		ApplyCompletionFee,
		///<summary>ApplyLargeFileFee. </summary>
		ApplyLargeFileFee,
		///<summary>ApplyTravelFee. </summary>
		ApplyTravelFee,
		///<summary>ApplyIssueInDisputeFees. </summary>
		ApplyIssueInDisputeFees,
		///<summary>ApplyExtraReportFees. </summary>
		ApplyExtraReportFees,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Arbitration.</summary>
	public enum ArbitrationFieldIndex
	{
		///<summary>ArbitrationId. </summary>
		ArbitrationId,
		///<summary>AssessmentId. </summary>
		AssessmentId,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>EndDate. </summary>
		EndDate,
		///<summary>AvailableDate. </summary>
		AvailableDate,
		///<summary>DefenseLawyerId. </summary>
		DefenseLawyerId,
		///<summary>DefenseFileNumber. </summary>
		DefenseFileNumber,
		///<summary>Title. </summary>
		Title,
		///<summary>NoteId. </summary>
		NoteId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Assessment.</summary>
	public enum AssessmentFieldIndex
	{
		///<summary>AssessmentId. </summary>
		AssessmentId,
		///<summary>ReferralTypeId. </summary>
		ReferralTypeId,
		///<summary>ReferralSourceId. </summary>
		ReferralSourceId,
		///<summary>AssessmentTypeId. </summary>
		AssessmentTypeId,
		///<summary>CompanyId. </summary>
		CompanyId,
		///<summary>ReportStatusId. </summary>
		ReportStatusId,
		///<summary>FileSize. </summary>
		FileSize,
		///<summary>ReferralSourceContactEmail. </summary>
		ReferralSourceContactEmail,
		///<summary>DocListWriterId. </summary>
		DocListWriterId,
		///<summary>NotesWriterId. </summary>
		NotesWriterId,
		///<summary>MedicalFileReceivedDate. </summary>
		MedicalFileReceivedDate,
		///<summary>IsLargeFile. </summary>
		IsLargeFile,
		///<summary>ReferralSourceFileNumber. </summary>
		ReferralSourceFileNumber,
		///<summary>CreateDate. </summary>
		CreateDate,
		///<summary>CreateUserId. </summary>
		CreateUserId,
		///<summary>UpdateDate. </summary>
		UpdateDate,
		///<summary>UpdateUserId. </summary>
		UpdateUserId,
		///<summary>SummaryNoteId. </summary>
		SummaryNoteId,
		///<summary>PsychologistFoundInFavorOfClaimant. </summary>
		PsychologistFoundInFavorOfClaimant,
		///<summary>NeurocognitiveCredibilityId. </summary>
		NeurocognitiveCredibilityId,
		///<summary>PsychologicalCredibilityId. </summary>
		PsychologicalCredibilityId,
		///<summary>DiagnosisFoundReponseId. </summary>
		DiagnosisFoundReponseId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentAttribute.</summary>
	public enum AssessmentAttributeFieldIndex
	{
		///<summary>AssessmentId. </summary>
		AssessmentId,
		///<summary>AttributeId. </summary>
		AttributeId,
		///<summary>Value. </summary>
		Value,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentClaim.</summary>
	public enum AssessmentClaimFieldIndex
	{
		///<summary>AssessmentId. </summary>
		AssessmentId,
		///<summary>ClaimId. </summary>
		ClaimId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentColor.</summary>
	public enum AssessmentColorFieldIndex
	{
		///<summary>AssessmentId. </summary>
		AssessmentId,
		///<summary>ColorId. </summary>
		ColorId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentMedRehab.</summary>
	public enum AssessmentMedRehabFieldIndex
	{
		///<summary>MedRehabId. </summary>
		MedRehabId,
		///<summary>AssessmentId. </summary>
		AssessmentId,
		///<summary>Date. </summary>
		Date,
		///<summary>Amount. </summary>
		Amount,
		///<summary>Description. </summary>
		Description,
		///<summary>Deleted. </summary>
		Deleted,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentNote.</summary>
	public enum AssessmentNoteFieldIndex
	{
		///<summary>AssessmentId. </summary>
		AssessmentId,
		///<summary>NoteId. </summary>
		NoteId,
		///<summary>ShowOnCalendar. </summary>
		ShowOnCalendar,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentReport.</summary>
	public enum AssessmentReportFieldIndex
	{
		///<summary>ReportId. </summary>
		ReportId,
		///<summary>AssessmentId. </summary>
		AssessmentId,
		///<summary>ReportTypeId. </summary>
		ReportTypeId,
		///<summary>IsAdditional. </summary>
		IsAdditional,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentReportIssueInDispute.</summary>
	public enum AssessmentReportIssueInDisputeFieldIndex
	{
		///<summary>ReportId. </summary>
		ReportId,
		///<summary>IssueInDisputeId. </summary>
		IssueInDisputeId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentType.</summary>
	public enum AssessmentTypeFieldIndex
	{
		///<summary>AssessmentTypeId. </summary>
		AssessmentTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ShowOnSchedule. </summary>
		ShowOnSchedule,
		///<summary>PsychometristCanInvoice. </summary>
		PsychometristCanInvoice,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentTypeAttributeType.</summary>
	public enum AssessmentTypeAttributeTypeFieldIndex
	{
		///<summary>AssessmentTypeId. </summary>
		AssessmentTypeId,
		///<summary>AttributeTypeId. </summary>
		AttributeTypeId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentTypeInvoiceAmount.</summary>
	public enum AssessmentTypeInvoiceAmountFieldIndex
	{
		///<summary>CompanyId. </summary>
		CompanyId,
		///<summary>ReferralSourceId. </summary>
		ReferralSourceId,
		///<summary>AssessmentTypeId. </summary>
		AssessmentTypeId,
		///<summary>SingleReportInvoiceAmount. </summary>
		SingleReportInvoiceAmount,
		///<summary>ComboReportInvoiceAmount. </summary>
		ComboReportInvoiceAmount,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentTypeReportType.</summary>
	public enum AssessmentTypeReportTypeFieldIndex
	{
		///<summary>AssessmentTypeId. </summary>
		AssessmentTypeId,
		///<summary>ReportTypeId. </summary>
		ReportTypeId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Attribute.</summary>
	public enum AttributeFieldIndex
	{
		///<summary>AttributeId. </summary>
		AttributeId,
		///<summary>Name. </summary>
		Name,
		///<summary>AttributeTypeId. </summary>
		AttributeTypeId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AttributeType.</summary>
	public enum AttributeTypeFieldIndex
	{
		///<summary>AttributeTypeId. </summary>
		AttributeTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ShowOnAppointment. </summary>
		ShowOnAppointment,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CalendarNote.</summary>
	public enum CalendarNoteFieldIndex
	{
		///<summary>CalendarNoteId. </summary>
		CalendarNoteId,
		///<summary>FromDate. </summary>
		FromDate,
		///<summary>ToDate. </summary>
		ToDate,
		///<summary>NoteId. </summary>
		NoteId,
		///<summary>CompanyId. </summary>
		CompanyId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: City.</summary>
	public enum CityFieldIndex
	{
		///<summary>CityId. </summary>
		CityId,
		///<summary>Name. </summary>
		Name,
		///<summary>Province. </summary>
		Province,
		///<summary>Country. </summary>
		Country,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Claim.</summary>
	public enum ClaimFieldIndex
	{
		///<summary>ClaimId. </summary>
		ClaimId,
		///<summary>ClaimantId. </summary>
		ClaimantId,
		///<summary>DateOfLoss. </summary>
		DateOfLoss,
		///<summary>ClaimNumber. </summary>
		ClaimNumber,
		///<summary>Lawyer. </summary>
		Lawyer,
		///<summary>InsuranceCompany. </summary>
		InsuranceCompany,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Claimant.</summary>
	public enum ClaimantFieldIndex
	{
		///<summary>ClaimantId. </summary>
		ClaimantId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>Gender. </summary>
		Gender,
		///<summary>DateOfBirth. </summary>
		DateOfBirth,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Color.</summary>
	public enum ColorFieldIndex
	{
		///<summary>ColorId. </summary>
		ColorId,
		///<summary>Name. </summary>
		Name,
		///<summary>HexCode. </summary>
		HexCode,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Company.</summary>
	public enum CompanyFieldIndex
	{
		///<summary>CompanyId. </summary>
		CompanyId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>AddressId. </summary>
		AddressId,
		///<summary>Phone. </summary>
		Phone,
		///<summary>Fax. </summary>
		Fax,
		///<summary>Email. </summary>
		Email,
		///<summary>TaxId. </summary>
		TaxId,
		///<summary>NewAppointmentTime. </summary>
		NewAppointmentTime,
		///<summary>NewAppointmentLocationId. </summary>
		NewAppointmentLocationId,
		///<summary>NewAppointmentPsychologistId. </summary>
		NewAppointmentPsychologistId,
		///<summary>NewAppointmentPsychometristId. </summary>
		NewAppointmentPsychometristId,
		///<summary>NewAppointmentStatusId. </summary>
		NewAppointmentStatusId,
		///<summary>NewAssessmentReportStatusId. </summary>
		NewAssessmentReportStatusId,
		///<summary>NewAssessmentSummaryNoteText. </summary>
		NewAssessmentSummaryNoteText,
		///<summary>Timezone. </summary>
		Timezone,
		///<summary>ReplyToEmail. </summary>
		ReplyToEmail,
		///<summary>NewAssessmentAssessmentTypeId. </summary>
		NewAssessmentAssessmentTypeId,
		///<summary>InvoiceCounter. </summary>
		InvoiceCounter,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CompanyAttribute.</summary>
	public enum CompanyAttributeFieldIndex
	{
		///<summary>CompanyId. </summary>
		CompanyId,
		///<summary>AttributeId. </summary>
		AttributeId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Contact.</summary>
	public enum ContactFieldIndex
	{
		///<summary>ContactId. </summary>
		ContactId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>Email. </summary>
		Email,
		///<summary>ContactTypeId. </summary>
		ContactTypeId,
		///<summary>AddressId. </summary>
		AddressId,
		///<summary>EmployerId. </summary>
		EmployerId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ContactType.</summary>
	public enum ContactTypeFieldIndex
	{
		///<summary>ContactTypeId. </summary>
		ContactTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Credibility.</summary>
	public enum CredibilityFieldIndex
	{
		///<summary>CredibilityId. </summary>
		CredibilityId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: DiagnosisFoundResponse.</summary>
	public enum DiagnosisFoundResponseFieldIndex
	{
		///<summary>DiagnosisFoundResponseId. </summary>
		DiagnosisFoundResponseId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Employer.</summary>
	public enum EmployerFieldIndex
	{
		///<summary>EmployerId. </summary>
		EmployerId,
		///<summary>Name. </summary>
		Name,
		///<summary>EmployerTypeId. </summary>
		EmployerTypeId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EmployerType.</summary>
	public enum EmployerTypeFieldIndex
	{
		///<summary>EmployerTypeId. </summary>
		EmployerTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Event.</summary>
	public enum EventFieldIndex
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>Description. </summary>
		Description,
		///<summary>Location. </summary>
		Location,
		///<summary>Time. </summary>
		Time,
		///<summary>Url. </summary>
		Url,
		///<summary>Expires. </summary>
		Expires,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CompanyId. </summary>
		CompanyId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Invoice.</summary>
	public enum InvoiceFieldIndex
	{
		///<summary>InvoiceId. </summary>
		InvoiceId,
		///<summary>Identifier. </summary>
		Identifier,
		///<summary>InvoiceDate. </summary>
		InvoiceDate,
		///<summary>InvoiceStatusId. </summary>
		InvoiceStatusId,
		///<summary>UpdateDate. </summary>
		UpdateDate,
		///<summary>TaxRate. </summary>
		TaxRate,
		///<summary>Total. </summary>
		Total,
		///<summary>InvoiceTypeId. </summary>
		InvoiceTypeId,
		///<summary>PayableToId. </summary>
		PayableToId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InvoiceAppointment.</summary>
	public enum InvoiceAppointmentFieldIndex
	{
		///<summary>InvoiceAppointmentId. </summary>
		InvoiceAppointmentId,
		///<summary>InvoiceId. </summary>
		InvoiceId,
		///<summary>AppointmentId. </summary>
		AppointmentId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InvoiceDocument.</summary>
	public enum InvoiceDocumentFieldIndex
	{
		///<summary>InvoiceDocumentId. </summary>
		InvoiceDocumentId,
		///<summary>InvoiceId. </summary>
		InvoiceId,
		///<summary>Document. </summary>
		Document,
		///<summary>CreateDate. </summary>
		CreateDate,
		///<summary>FileName. </summary>
		FileName,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InvoiceDocumentSendLog.</summary>
	public enum InvoiceDocumentSendLogFieldIndex
	{
		///<summary>InvoiceDocumentSendLogId. </summary>
		InvoiceDocumentSendLogId,
		///<summary>InvoiceDocumentId. </summary>
		InvoiceDocumentId,
		///<summary>Recipients. </summary>
		Recipients,
		///<summary>SentDate. </summary>
		SentDate,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InvoiceLine.</summary>
	public enum InvoiceLineFieldIndex
	{
		///<summary>InvoiceLineId. </summary>
		InvoiceLineId,
		///<summary>Description. </summary>
		Description,
		///<summary>Amount. </summary>
		Amount,
		///<summary>IsCustom. </summary>
		IsCustom,
		///<summary>OriginalAmount. </summary>
		OriginalAmount,
		///<summary>InvoiceLineGroupId. </summary>
		InvoiceLineGroupId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InvoiceLineGroup.</summary>
	public enum InvoiceLineGroupFieldIndex
	{
		///<summary>InvoiceLineGroupId. </summary>
		InvoiceLineGroupId,
		///<summary>InvoiceId. </summary>
		InvoiceId,
		///<summary>Description. </summary>
		Description,
		///<summary>Sort. </summary>
		Sort,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InvoiceLineGroupAppointment.</summary>
	public enum InvoiceLineGroupAppointmentFieldIndex
	{
		///<summary>InvoiceLineGroupId. </summary>
		InvoiceLineGroupId,
		///<summary>AppointmentId. </summary>
		AppointmentId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InvoiceStatus.</summary>
	public enum InvoiceStatusFieldIndex
	{
		///<summary>InvoiceStatusId. </summary>
		InvoiceStatusId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CanEdit. </summary>
		CanEdit,
		///<summary>SaveDocument. </summary>
		SaveDocument,
		///<summary>ActionName. </summary>
		ActionName,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InvoiceStatusChange.</summary>
	public enum InvoiceStatusChangeFieldIndex
	{
		///<summary>InvoiceStatusChangeId. </summary>
		InvoiceStatusChangeId,
		///<summary>InvoiceId. </summary>
		InvoiceId,
		///<summary>InvoiceStatusId. </summary>
		InvoiceStatusId,
		///<summary>UpdateDate. </summary>
		UpdateDate,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InvoiceStatusPaths.</summary>
	public enum InvoiceStatusPathsFieldIndex
	{
		///<summary>InvoiceStatusPathId. </summary>
		InvoiceStatusPathId,
		///<summary>InvoiceStatusId. </summary>
		InvoiceStatusId,
		///<summary>NextInvoiceStatusId. </summary>
		NextInvoiceStatusId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InvoiceType.</summary>
	public enum InvoiceTypeFieldIndex
	{
		///<summary>InvoiceTypeId. </summary>
		InvoiceTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CanSend. </summary>
		CanSend,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: IssueInDispute.</summary>
	public enum IssueInDisputeFieldIndex
	{
		///<summary>IssueInDisputeId. </summary>
		IssueInDisputeId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: IssueInDisputeInvoiceAmount.</summary>
	public enum IssueInDisputeInvoiceAmountFieldIndex
	{
		///<summary>CompanyId. </summary>
		CompanyId,
		///<summary>IssueInDisputeId. </summary>
		IssueInDisputeId,
		///<summary>InvoiceAmount. </summary>
		InvoiceAmount,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Note.</summary>
	public enum NoteFieldIndex
	{
		///<summary>NoteId. </summary>
		NoteId,
		///<summary>Note. </summary>
		Note,
		///<summary>UpdateUserId. </summary>
		UpdateUserId,
		///<summary>UpdateDate. </summary>
		UpdateDate,
		///<summary>CreateUserId. </summary>
		CreateUserId,
		///<summary>CreateDate. </summary>
		CreateDate,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PsychometristInvoiceAmount.</summary>
	public enum PsychometristInvoiceAmountFieldIndex
	{
		///<summary>AssessmentTypeId. </summary>
		AssessmentTypeId,
		///<summary>AppointmentStatusId. </summary>
		AppointmentStatusId,
		///<summary>CompanyId. </summary>
		CompanyId,
		///<summary>AppointmentSequenceId. </summary>
		AppointmentSequenceId,
		///<summary>InvoiceAmount. </summary>
		InvoiceAmount,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ReferralSource.</summary>
	public enum ReferralSourceFieldIndex
	{
		///<summary>ReferralSourceId. </summary>
		ReferralSourceId,
		///<summary>Name. </summary>
		Name,
		///<summary>ReferralSourceTypeId. </summary>
		ReferralSourceTypeId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>AddressId. </summary>
		AddressId,
		///<summary>InvoicesContactEmail. </summary>
		InvoicesContactEmail,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ReferralSourceInvoiceConfiguration.</summary>
	public enum ReferralSourceInvoiceConfigurationFieldIndex
	{
		///<summary>ReferralSourceId. </summary>
		ReferralSourceId,
		///<summary>CompanyId. </summary>
		CompanyId,
		///<summary>LargeFileSize. </summary>
		LargeFileSize,
		///<summary>LargeFileFee. </summary>
		LargeFileFee,
		///<summary>ExtraReportFee. </summary>
		ExtraReportFee,
		///<summary>CompletionFeeAmount. </summary>
		CompletionFeeAmount,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ReferralSourceType.</summary>
	public enum ReferralSourceTypeFieldIndex
	{
		///<summary>ReferralSourceTypeId. </summary>
		ReferralSourceTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ReferralType.</summary>
	public enum ReferralTypeFieldIndex
	{
		///<summary>ReferralTypeId. </summary>
		ReferralTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ReferralTypeIssueInDispute.</summary>
	public enum ReferralTypeIssueInDisputeFieldIndex
	{
		///<summary>ReferralTypeId. </summary>
		ReferralTypeId,
		///<summary>IssueInDisputeId. </summary>
		IssueInDisputeId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ReportStatus.</summary>
	public enum ReportStatusFieldIndex
	{
		///<summary>ReportStatusId. </summary>
		ReportStatusId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ReportType.</summary>
	public enum ReportTypeFieldIndex
	{
		///<summary>ReportTypeId. </summary>
		ReportTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Right.</summary>
	public enum RightFieldIndex
	{
		///<summary>RightId. </summary>
		RightId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Role.</summary>
	public enum RoleFieldIndex
	{
		///<summary>RoleId. </summary>
		RoleId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RoleRight.</summary>
	public enum RoleRightFieldIndex
	{
		///<summary>RoleId. </summary>
		RoleId,
		///<summary>RightId. </summary>
		RightId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: User.</summary>
	public enum UserFieldIndex
	{
		///<summary>UserId. </summary>
		UserId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>Email. </summary>
		Email,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CompanyId. </summary>
		CompanyId,
		///<summary>AddressId. </summary>
		AddressId,
		///<summary>DateInactivated. </summary>
		DateInactivated,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UserNote.</summary>
	public enum UserNoteFieldIndex
	{
		///<summary>NoteId. </summary>
		NoteId,
		///<summary>UserId. </summary>
		UserId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UserRole.</summary>
	public enum UserRoleFieldIndex
	{
		///<summary>UserId. </summary>
		UserId,
		///<summary>RoleId. </summary>
		RoleId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UserTravelFee.</summary>
	public enum UserTravelFeeFieldIndex
	{
		///<summary>UserId. </summary>
		UserId,
		///<summary>CityId. </summary>
		CityId,
		///<summary>Amount. </summary>
		Amount,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UserUnavailability.</summary>
	public enum UserUnavailabilityFieldIndex
	{
		///<summary>Id. </summary>
		Id,
		///<summary>UserId. </summary>
		UserId,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>EndDate. </summary>
		EndDate,
		/// <summary></summary>
		AmountOfFields
	}



	/// <summary>Enum definition for all the entity types defined in this namespace. Used by the entityfields factory.</summary>
	public enum EntityType
	{
		///<summary>Address</summary>
		AddressEntity,
		///<summary>AddressAddressType</summary>
		AddressAddressTypeEntity,
		///<summary>AddressType</summary>
		AddressTypeEntity,
		///<summary>Appointment</summary>
		AppointmentEntity,
		///<summary>AppointmentAttribute</summary>
		AppointmentAttributeEntity,
		///<summary>AppointmentSequence</summary>
		AppointmentSequenceEntity,
		///<summary>AppointmentStatus</summary>
		AppointmentStatusEntity,
		///<summary>AppointmentStatusInvoiceRate</summary>
		AppointmentStatusInvoiceRateEntity,
		///<summary>Arbitration</summary>
		ArbitrationEntity,
		///<summary>Assessment</summary>
		AssessmentEntity,
		///<summary>AssessmentAttribute</summary>
		AssessmentAttributeEntity,
		///<summary>AssessmentClaim</summary>
		AssessmentClaimEntity,
		///<summary>AssessmentColor</summary>
		AssessmentColorEntity,
		///<summary>AssessmentMedRehab</summary>
		AssessmentMedRehabEntity,
		///<summary>AssessmentNote</summary>
		AssessmentNoteEntity,
		///<summary>AssessmentReport</summary>
		AssessmentReportEntity,
		///<summary>AssessmentReportIssueInDispute</summary>
		AssessmentReportIssueInDisputeEntity,
		///<summary>AssessmentType</summary>
		AssessmentTypeEntity,
		///<summary>AssessmentTypeAttributeType</summary>
		AssessmentTypeAttributeTypeEntity,
		///<summary>AssessmentTypeInvoiceAmount</summary>
		AssessmentTypeInvoiceAmountEntity,
		///<summary>AssessmentTypeReportType</summary>
		AssessmentTypeReportTypeEntity,
		///<summary>Attribute</summary>
		AttributeEntity,
		///<summary>AttributeType</summary>
		AttributeTypeEntity,
		///<summary>CalendarNote</summary>
		CalendarNoteEntity,
		///<summary>City</summary>
		CityEntity,
		///<summary>Claim</summary>
		ClaimEntity,
		///<summary>Claimant</summary>
		ClaimantEntity,
		///<summary>Color</summary>
		ColorEntity,
		///<summary>Company</summary>
		CompanyEntity,
		///<summary>CompanyAttribute</summary>
		CompanyAttributeEntity,
		///<summary>Contact</summary>
		ContactEntity,
		///<summary>ContactType</summary>
		ContactTypeEntity,
		///<summary>Credibility</summary>
		CredibilityEntity,
		///<summary>DiagnosisFoundResponse</summary>
		DiagnosisFoundResponseEntity,
		///<summary>Employer</summary>
		EmployerEntity,
		///<summary>EmployerType</summary>
		EmployerTypeEntity,
		///<summary>Event</summary>
		EventEntity,
		///<summary>Invoice</summary>
		InvoiceEntity,
		///<summary>InvoiceAppointment</summary>
		InvoiceAppointmentEntity,
		///<summary>InvoiceDocument</summary>
		InvoiceDocumentEntity,
		///<summary>InvoiceDocumentSendLog</summary>
		InvoiceDocumentSendLogEntity,
		///<summary>InvoiceLine</summary>
		InvoiceLineEntity,
		///<summary>InvoiceLineGroup</summary>
		InvoiceLineGroupEntity,
		///<summary>InvoiceLineGroupAppointment</summary>
		InvoiceLineGroupAppointmentEntity,
		///<summary>InvoiceStatus</summary>
		InvoiceStatusEntity,
		///<summary>InvoiceStatusChange</summary>
		InvoiceStatusChangeEntity,
		///<summary>InvoiceStatusPaths</summary>
		InvoiceStatusPathsEntity,
		///<summary>InvoiceType</summary>
		InvoiceTypeEntity,
		///<summary>IssueInDispute</summary>
		IssueInDisputeEntity,
		///<summary>IssueInDisputeInvoiceAmount</summary>
		IssueInDisputeInvoiceAmountEntity,
		///<summary>Note</summary>
		NoteEntity,
		///<summary>PsychometristInvoiceAmount</summary>
		PsychometristInvoiceAmountEntity,
		///<summary>ReferralSource</summary>
		ReferralSourceEntity,
		///<summary>ReferralSourceInvoiceConfiguration</summary>
		ReferralSourceInvoiceConfigurationEntity,
		///<summary>ReferralSourceType</summary>
		ReferralSourceTypeEntity,
		///<summary>ReferralType</summary>
		ReferralTypeEntity,
		///<summary>ReferralTypeIssueInDispute</summary>
		ReferralTypeIssueInDisputeEntity,
		///<summary>ReportStatus</summary>
		ReportStatusEntity,
		///<summary>ReportType</summary>
		ReportTypeEntity,
		///<summary>Right</summary>
		RightEntity,
		///<summary>Role</summary>
		RoleEntity,
		///<summary>RoleRight</summary>
		RoleRightEntity,
		///<summary>User</summary>
		UserEntity,
		///<summary>UserNote</summary>
		UserNoteEntity,
		///<summary>UserRole</summary>
		UserRoleEntity,
		///<summary>UserTravelFee</summary>
		UserTravelFeeEntity,
		///<summary>UserUnavailability</summary>
		UserUnavailabilityEntity
	}


	#region Custom ConstantsEnums Code
	
	// __LLBLGENPRO_USER_CODE_REGION_START CustomUserConstants
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	#endregion

	#region Included code

	#endregion
}

