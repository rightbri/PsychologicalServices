﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.3.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
////////////////////////////////////////////////////////////// 
using System;
using System.Linq;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;

namespace PsychologicalServices.Data.FactoryClasses
{
	/// <summary>Factory class to produce DynamicQuery instances and EntityQuery instances</summary>
	public partial class QueryFactory
	{
		private int _aliasCounter = 0;

		/// <summary>Creates a new DynamicQuery instance with no alias set.</summary>
		/// <returns>Ready to use DynamicQuery instance</returns>
		public DynamicQuery Create()
		{
			return Create(string.Empty);
		}

		/// <summary>Creates a new DynamicQuery instance with the alias specified as the alias set.</summary>
		/// <param name="alias">The alias.</param>
		/// <returns>Ready to use DynamicQuery instance</returns>
		public DynamicQuery Create(string alias)
		{
			return new DynamicQuery(new ElementCreator(), alias, this.GetNextAliasCounterValue());
		}

		/// <summary>Creates a new DynamicQuery which wraps the specified TableValuedFunction call</summary>
		/// <param name="toWrap">The table valued function call to wrap.</param>
		/// <returns>toWrap wrapped in a DynamicQuery.</returns>
		public DynamicQuery Create(TableValuedFunctionCall toWrap)
		{
			return this.Create().From(new TvfCallWrapper(toWrap)).Select(toWrap.GetFieldsAsArray().Select(f => this.Field(toWrap.Alias, f.Alias)).ToArray());
		}

		/// <summary>Creates a new EntityQuery for the entity of the type specified with no alias set.</summary>
		/// <typeparam name="TEntity">The type of the entity to produce the query for.</typeparam>
		/// <returns>ready to use EntityQuery instance</returns>
		public EntityQuery<TEntity> Create<TEntity>()
			where TEntity : IEntityCore
		{
			return Create<TEntity>(string.Empty);
		}

		/// <summary>Creates a new EntityQuery for the entity of the type specified with the alias specified as the alias set.</summary>
		/// <typeparam name="TEntity">The type of the entity to produce the query for.</typeparam>
		/// <param name="alias">The alias.</param>
		/// <returns>ready to use EntityQuery instance</returns>
		public EntityQuery<TEntity> Create<TEntity>(string alias)
			where TEntity : IEntityCore
		{
			return new EntityQuery<TEntity>(new ElementCreator(), alias, this.GetNextAliasCounterValue());
		}
				
		/// <summary>Creates a new field object with the name specified and of resulttype 'object'. Used for referring to aliased fields in another projection.</summary>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField2 Field(string fieldName)
		{
			return Field<object>(string.Empty, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'object'. Used for referring to aliased fields in another projection.</summary>
		/// <param name="targetAlias">The alias of the table/query to target.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField2 Field(string targetAlias, string fieldName)
		{
			return Field<object>(targetAlias, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'TValue'. Used for referring to aliased fields in another projection.</summary>
		/// <typeparam name="TValue">The type of the value represented by the field.</typeparam>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField2 Field<TValue>(string fieldName)
		{
			return Field<TValue>(string.Empty, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'TValue'. Used for referring to aliased fields in another projection.</summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="targetAlias">The alias of the table/query to target.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField2 Field<TValue>(string targetAlias, string fieldName)
		{
			return new EntityField2(fieldName, targetAlias, typeof(TValue));
		}
		
		/// <summary>Gets the next alias counter value to produce artifical aliases with</summary>
		private int GetNextAliasCounterValue()
		{
			_aliasCounter++;
			return _aliasCounter;
		}
		

		/// <summary>Creates and returns a new EntityQuery for the Address entity</summary>
		public EntityQuery<AddressEntity> Address
		{
			get { return Create<AddressEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AddressAddressType entity</summary>
		public EntityQuery<AddressAddressTypeEntity> AddressAddressType
		{
			get { return Create<AddressAddressTypeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AddressType entity</summary>
		public EntityQuery<AddressTypeEntity> AddressType
		{
			get { return Create<AddressTypeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Appointment entity</summary>
		public EntityQuery<AppointmentEntity> Appointment
		{
			get { return Create<AppointmentEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AppointmentAttribute entity</summary>
		public EntityQuery<AppointmentAttributeEntity> AppointmentAttribute
		{
			get { return Create<AppointmentAttributeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AppointmentSequence entity</summary>
		public EntityQuery<AppointmentSequenceEntity> AppointmentSequence
		{
			get { return Create<AppointmentSequenceEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AppointmentStatus entity</summary>
		public EntityQuery<AppointmentStatusEntity> AppointmentStatus
		{
			get { return Create<AppointmentStatusEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AppointmentStatusInvoiceRate entity</summary>
		public EntityQuery<AppointmentStatusInvoiceRateEntity> AppointmentStatusInvoiceRate
		{
			get { return Create<AppointmentStatusInvoiceRateEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Arbitration entity</summary>
		public EntityQuery<ArbitrationEntity> Arbitration
		{
			get { return Create<ArbitrationEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ArbitrationClaim entity</summary>
		public EntityQuery<ArbitrationClaimEntity> ArbitrationClaim
		{
			get { return Create<ArbitrationClaimEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ArbitrationStatus entity</summary>
		public EntityQuery<ArbitrationStatusEntity> ArbitrationStatus
		{
			get { return Create<ArbitrationStatusEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Assessment entity</summary>
		public EntityQuery<AssessmentEntity> Assessment
		{
			get { return Create<AssessmentEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AssessmentAttribute entity</summary>
		public EntityQuery<AssessmentAttributeEntity> AssessmentAttribute
		{
			get { return Create<AssessmentAttributeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AssessmentClaim entity</summary>
		public EntityQuery<AssessmentClaimEntity> AssessmentClaim
		{
			get { return Create<AssessmentClaimEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AssessmentColor entity</summary>
		public EntityQuery<AssessmentColorEntity> AssessmentColor
		{
			get { return Create<AssessmentColorEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AssessmentMedRehab entity</summary>
		public EntityQuery<AssessmentMedRehabEntity> AssessmentMedRehab
		{
			get { return Create<AssessmentMedRehabEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AssessmentNote entity</summary>
		public EntityQuery<AssessmentNoteEntity> AssessmentNote
		{
			get { return Create<AssessmentNoteEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AssessmentReport entity</summary>
		public EntityQuery<AssessmentReportEntity> AssessmentReport
		{
			get { return Create<AssessmentReportEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AssessmentReportIssueInDispute entity</summary>
		public EntityQuery<AssessmentReportIssueInDisputeEntity> AssessmentReportIssueInDispute
		{
			get { return Create<AssessmentReportIssueInDisputeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AssessmentTestingResult entity</summary>
		public EntityQuery<AssessmentTestingResultEntity> AssessmentTestingResult
		{
			get { return Create<AssessmentTestingResultEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AssessmentType entity</summary>
		public EntityQuery<AssessmentTypeEntity> AssessmentType
		{
			get { return Create<AssessmentTypeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AssessmentTypeAttributeType entity</summary>
		public EntityQuery<AssessmentTypeAttributeTypeEntity> AssessmentTypeAttributeType
		{
			get { return Create<AssessmentTypeAttributeTypeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AssessmentTypeInvoiceAmount entity</summary>
		public EntityQuery<AssessmentTypeInvoiceAmountEntity> AssessmentTypeInvoiceAmount
		{
			get { return Create<AssessmentTypeInvoiceAmountEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AssessmentTypeReportType entity</summary>
		public EntityQuery<AssessmentTypeReportTypeEntity> AssessmentTypeReportType
		{
			get { return Create<AssessmentTypeReportTypeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Attribute entity</summary>
		public EntityQuery<AttributeEntity> Attribute
		{
			get { return Create<AttributeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AttributeType entity</summary>
		public EntityQuery<AttributeTypeEntity> AttributeType
		{
			get { return Create<AttributeTypeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the CalendarNote entity</summary>
		public EntityQuery<CalendarNoteEntity> CalendarNote
		{
			get { return Create<CalendarNoteEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the City entity</summary>
		public EntityQuery<CityEntity> City
		{
			get { return Create<CityEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Claim entity</summary>
		public EntityQuery<ClaimEntity> Claim
		{
			get { return Create<ClaimEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Claimant entity</summary>
		public EntityQuery<ClaimantEntity> Claimant
		{
			get { return Create<ClaimantEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Color entity</summary>
		public EntityQuery<ColorEntity> Color
		{
			get { return Create<ColorEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Company entity</summary>
		public EntityQuery<CompanyEntity> Company
		{
			get { return Create<CompanyEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the CompanyAttribute entity</summary>
		public EntityQuery<CompanyAttributeEntity> CompanyAttribute
		{
			get { return Create<CompanyAttributeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ConsultingAgreement entity</summary>
		public EntityQuery<ConsultingAgreementEntity> ConsultingAgreement
		{
			get { return Create<ConsultingAgreementEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Contact entity</summary>
		public EntityQuery<ContactEntity> Contact
		{
			get { return Create<ContactEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ContactType entity</summary>
		public EntityQuery<ContactTypeEntity> ContactType
		{
			get { return Create<ContactTypeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Credibility entity</summary>
		public EntityQuery<CredibilityEntity> Credibility
		{
			get { return Create<CredibilityEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the DiagnosisFoundResponse entity</summary>
		public EntityQuery<DiagnosisFoundResponseEntity> DiagnosisFoundResponse
		{
			get { return Create<DiagnosisFoundResponseEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Document entity</summary>
		public EntityQuery<DocumentEntity> Document
		{
			get { return Create<DocumentEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Employer entity</summary>
		public EntityQuery<EmployerEntity> Employer
		{
			get { return Create<EmployerEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the EmployerType entity</summary>
		public EntityQuery<EmployerTypeEntity> EmployerType
		{
			get { return Create<EmployerTypeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Event entity</summary>
		public EntityQuery<EventEntity> Event
		{
			get { return Create<EventEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the GoseAccidentTimeframe entity</summary>
		public EntityQuery<GoseAccidentTimeframeEntity> GoseAccidentTimeframe
		{
			get { return Create<GoseAccidentTimeframeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the GoseFamilyAndFriendshipsDisruptionLevel entity</summary>
		public EntityQuery<GoseFamilyAndFriendshipsDisruptionLevelEntity> GoseFamilyAndFriendshipsDisruptionLevel
		{
			get { return Create<GoseFamilyAndFriendshipsDisruptionLevelEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the GoseInterview entity</summary>
		public EntityQuery<GoseInterviewEntity> GoseInterview
		{
			get { return Create<GoseInterviewEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the GoseRespondentType entity</summary>
		public EntityQuery<GoseRespondentTypeEntity> GoseRespondentType
		{
			get { return Create<GoseRespondentTypeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the GoseReturnToNormalLifeOutcomeFactor entity</summary>
		public EntityQuery<GoseReturnToNormalLifeOutcomeFactorEntity> GoseReturnToNormalLifeOutcomeFactor
		{
			get { return Create<GoseReturnToNormalLifeOutcomeFactorEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the GoseSocialAndLeisureRestrictionExtent entity</summary>
		public EntityQuery<GoseSocialAndLeisureRestrictionExtentEntity> GoseSocialAndLeisureRestrictionExtent
		{
			get { return Create<GoseSocialAndLeisureRestrictionExtentEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the GoseWorkRestrictionLevel entity</summary>
		public EntityQuery<GoseWorkRestrictionLevelEntity> GoseWorkRestrictionLevel
		{
			get { return Create<GoseWorkRestrictionLevelEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Invoice entity</summary>
		public EntityQuery<InvoiceEntity> Invoice
		{
			get { return Create<InvoiceEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the InvoiceDocument entity</summary>
		public EntityQuery<InvoiceDocumentEntity> InvoiceDocument
		{
			get { return Create<InvoiceDocumentEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the InvoiceDocumentSendLog entity</summary>
		public EntityQuery<InvoiceDocumentSendLogEntity> InvoiceDocumentSendLog
		{
			get { return Create<InvoiceDocumentSendLogEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the InvoiceLine entity</summary>
		public EntityQuery<InvoiceLineEntity> InvoiceLine
		{
			get { return Create<InvoiceLineEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the InvoiceLineGroup entity</summary>
		public EntityQuery<InvoiceLineGroupEntity> InvoiceLineGroup
		{
			get { return Create<InvoiceLineGroupEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the InvoiceLineGroupAppointment entity</summary>
		public EntityQuery<InvoiceLineGroupAppointmentEntity> InvoiceLineGroupAppointment
		{
			get { return Create<InvoiceLineGroupAppointmentEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the InvoiceLineGroupArbitration entity</summary>
		public EntityQuery<InvoiceLineGroupArbitrationEntity> InvoiceLineGroupArbitration
		{
			get { return Create<InvoiceLineGroupArbitrationEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the InvoiceLineGroupConsultingAgreement entity</summary>
		public EntityQuery<InvoiceLineGroupConsultingAgreementEntity> InvoiceLineGroupConsultingAgreement
		{
			get { return Create<InvoiceLineGroupConsultingAgreementEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the InvoiceLineGroupRawTestData entity</summary>
		public EntityQuery<InvoiceLineGroupRawTestDataEntity> InvoiceLineGroupRawTestData
		{
			get { return Create<InvoiceLineGroupRawTestDataEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the InvoiceStatus entity</summary>
		public EntityQuery<InvoiceStatusEntity> InvoiceStatus
		{
			get { return Create<InvoiceStatusEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the InvoiceStatusChange entity</summary>
		public EntityQuery<InvoiceStatusChangeEntity> InvoiceStatusChange
		{
			get { return Create<InvoiceStatusChangeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the InvoiceStatusPaths entity</summary>
		public EntityQuery<InvoiceStatusPathsEntity> InvoiceStatusPaths
		{
			get { return Create<InvoiceStatusPathsEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the InvoiceType entity</summary>
		public EntityQuery<InvoiceTypeEntity> InvoiceType
		{
			get { return Create<InvoiceTypeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the IssueInDispute entity</summary>
		public EntityQuery<IssueInDisputeEntity> IssueInDispute
		{
			get { return Create<IssueInDisputeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the IssueInDisputeInvoiceAmount entity</summary>
		public EntityQuery<IssueInDisputeInvoiceAmountEntity> IssueInDisputeInvoiceAmount
		{
			get { return Create<IssueInDisputeInvoiceAmountEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Note entity</summary>
		public EntityQuery<NoteEntity> Note
		{
			get { return Create<NoteEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the PhoneLog entity</summary>
		public EntityQuery<PhoneLogEntity> PhoneLog
		{
			get { return Create<PhoneLogEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the PsychometristInvoiceAmount entity</summary>
		public EntityQuery<PsychometristInvoiceAmountEntity> PsychometristInvoiceAmount
		{
			get { return Create<PsychometristInvoiceAmountEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the RawTestData entity</summary>
		public EntityQuery<RawTestDataEntity> RawTestData
		{
			get { return Create<RawTestDataEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the RawTestDataStatus entity</summary>
		public EntityQuery<RawTestDataStatusEntity> RawTestDataStatus
		{
			get { return Create<RawTestDataStatusEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ReferralSource entity</summary>
		public EntityQuery<ReferralSourceEntity> ReferralSource
		{
			get { return Create<ReferralSourceEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ReferralSourceInvoiceConfiguration entity</summary>
		public EntityQuery<ReferralSourceInvoiceConfigurationEntity> ReferralSourceInvoiceConfiguration
		{
			get { return Create<ReferralSourceInvoiceConfigurationEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ReferralSourceType entity</summary>
		public EntityQuery<ReferralSourceTypeEntity> ReferralSourceType
		{
			get { return Create<ReferralSourceTypeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ReferralType entity</summary>
		public EntityQuery<ReferralTypeEntity> ReferralType
		{
			get { return Create<ReferralTypeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ReferralTypeIssueInDispute entity</summary>
		public EntityQuery<ReferralTypeIssueInDisputeEntity> ReferralTypeIssueInDispute
		{
			get { return Create<ReferralTypeIssueInDisputeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ReportStatus entity</summary>
		public EntityQuery<ReportStatusEntity> ReportStatus
		{
			get { return Create<ReportStatusEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ReportType entity</summary>
		public EntityQuery<ReportTypeEntity> ReportType
		{
			get { return Create<ReportTypeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Right entity</summary>
		public EntityQuery<RightEntity> Right
		{
			get { return Create<RightEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Role entity</summary>
		public EntityQuery<RoleEntity> Role
		{
			get { return Create<RoleEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the RoleRight entity</summary>
		public EntityQuery<RoleRightEntity> RoleRight
		{
			get { return Create<RoleRightEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the User entity</summary>
		public EntityQuery<UserEntity> User
		{
			get { return Create<UserEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the UserNote entity</summary>
		public EntityQuery<UserNoteEntity> UserNote
		{
			get { return Create<UserNoteEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the UserRole entity</summary>
		public EntityQuery<UserRoleEntity> UserRole
		{
			get { return Create<UserRoleEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the UserTravelFee entity</summary>
		public EntityQuery<UserTravelFeeEntity> UserTravelFee
		{
			get { return Create<UserTravelFeeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the UserUnavailability entity</summary>
		public EntityQuery<UserUnavailabilityEntity> UserUnavailability
		{
			get { return Create<UserUnavailabilityEntity>(); }
		}


 
	}
}