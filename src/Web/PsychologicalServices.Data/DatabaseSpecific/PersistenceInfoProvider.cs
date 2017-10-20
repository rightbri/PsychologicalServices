///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SqlServerSpecific.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PsychologicalServices.Data.DatabaseSpecific
{
	/// <summary>
	/// Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.
	/// </summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the PersistenceInfoProviderBase class is threadsafe.</remarks>
	internal sealed class PersistenceInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();
		#endregion
		
		/// <summary>private ctor to prevent instances of this class.</summary>
		private PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			base.InitClass((61 + 0));
			InitAddressEntityMappings();
			InitAddressAddressTypeEntityMappings();
			InitAddressTypeEntityMappings();
			InitAppointmentEntityMappings();
			InitAppointmentAttributeEntityMappings();
			InitAppointmentSequenceEntityMappings();
			InitAppointmentStatusEntityMappings();
			InitAppointmentStatusInvoiceRateEntityMappings();
			InitArbitrationEntityMappings();
			InitAssessmentEntityMappings();
			InitAssessmentAttributeEntityMappings();
			InitAssessmentClaimEntityMappings();
			InitAssessmentColorEntityMappings();
			InitAssessmentMedRehabEntityMappings();
			InitAssessmentNoteEntityMappings();
			InitAssessmentReportEntityMappings();
			InitAssessmentReportIssueInDisputeEntityMappings();
			InitAssessmentTypeEntityMappings();
			InitAssessmentTypeAttributeTypeEntityMappings();
			InitAssessmentTypeInvoiceAmountEntityMappings();
			InitAssessmentTypeReportTypeEntityMappings();
			InitAttributeEntityMappings();
			InitAttributeTypeEntityMappings();
			InitCalendarNoteEntityMappings();
			InitCityEntityMappings();
			InitClaimEntityMappings();
			InitClaimantEntityMappings();
			InitColorEntityMappings();
			InitCompanyEntityMappings();
			InitCompanyAttributeEntityMappings();
			InitContactEntityMappings();
			InitContactTypeEntityMappings();
			InitEmployerEntityMappings();
			InitEmployerTypeEntityMappings();
			InitInvoiceEntityMappings();
			InitInvoiceAppointmentEntityMappings();
			InitInvoiceDocumentEntityMappings();
			InitInvoiceLineEntityMappings();
			InitInvoiceStatusEntityMappings();
			InitInvoiceStatusChangeEntityMappings();
			InitInvoiceStatusPathsEntityMappings();
			InitInvoiceTypeEntityMappings();
			InitIssueInDisputeEntityMappings();
			InitIssueInDisputeInvoiceAmountEntityMappings();
			InitNoteEntityMappings();
			InitPsychometristInvoiceAmountEntityMappings();
			InitReferralSourceEntityMappings();
			InitReferralSourceInvoiceConfigurationEntityMappings();
			InitReferralSourceTypeEntityMappings();
			InitReferralTypeEntityMappings();
			InitReferralTypeIssueInDisputeEntityMappings();
			InitReportStatusEntityMappings();
			InitReportTypeEntityMappings();
			InitRightEntityMappings();
			InitRoleEntityMappings();
			InitRoleRightEntityMappings();
			InitUserEntityMappings();
			InitUserNoteEntityMappings();
			InitUserRoleEntityMappings();
			InitUserTravelFeeEntityMappings();
			InitUserUnavailabilityEntityMappings();

		}


		/// <summary>Inits AddressEntity's mappings</summary>
		private void InitAddressEntityMappings()
		{
			base.AddElementMapping( "AddressEntity", "PsychologicalServices", @"dbo", "Addresses", 7 );
			base.AddElementFieldMapping( "AddressEntity", "AddressId", "AddressId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AddressEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "AddressEntity", "Street", "Street", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "AddressEntity", "Suite", "Suite", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "AddressEntity", "CityId", "CityId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			base.AddElementFieldMapping( "AddressEntity", "PostalCode", "PostalCode", false, (int)SqlDbType.NVarChar, 10, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "AddressEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 6 );
		}
		/// <summary>Inits AddressAddressTypeEntity's mappings</summary>
		private void InitAddressAddressTypeEntityMappings()
		{
			base.AddElementMapping( "AddressAddressTypeEntity", "PsychologicalServices", @"dbo", "AddressAddressTypes", 2 );
			base.AddElementFieldMapping( "AddressAddressTypeEntity", "AddressId", "AddressId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AddressAddressTypeEntity", "AddressTypeId", "AddressTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits AddressTypeEntity's mappings</summary>
		private void InitAddressTypeEntityMappings()
		{
			base.AddElementMapping( "AddressTypeEntity", "PsychologicalServices", @"dbo", "AddressTypes", 3 );
			base.AddElementFieldMapping( "AddressTypeEntity", "AddressTypeId", "AddressTypeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AddressTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "AddressTypeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits AppointmentEntity's mappings</summary>
		private void InitAppointmentEntityMappings()
		{
			base.AddElementMapping( "AppointmentEntity", "PsychologicalServices", @"dbo", "Appointments", 11 );
			base.AddElementFieldMapping( "AppointmentEntity", "AppointmentId", "AppointmentId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AppointmentEntity", "LocationId", "LocationId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "AppointmentEntity", "AppointmentTime", "AppointmentTime", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 2 );
			base.AddElementFieldMapping( "AppointmentEntity", "PsychometristId", "PsychometristId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "AppointmentEntity", "PsychologistId", "PsychologistId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			base.AddElementFieldMapping( "AppointmentEntity", "AppointmentStatusId", "AppointmentStatusId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			base.AddElementFieldMapping( "AppointmentEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
			base.AddElementFieldMapping( "AppointmentEntity", "CreateDate", "CreateDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 7 );
			base.AddElementFieldMapping( "AppointmentEntity", "CreateUserId", "CreateUserId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 8 );
			base.AddElementFieldMapping( "AppointmentEntity", "UpdateDate", "UpdateDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 9 );
			base.AddElementFieldMapping( "AppointmentEntity", "UpdateUserId", "UpdateUserId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 10 );
		}
		/// <summary>Inits AppointmentAttributeEntity's mappings</summary>
		private void InitAppointmentAttributeEntityMappings()
		{
			base.AddElementMapping( "AppointmentAttributeEntity", "PsychologicalServices", @"dbo", "AppointmentAttributes", 3 );
			base.AddElementFieldMapping( "AppointmentAttributeEntity", "AppointmentId", "AppointmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AppointmentAttributeEntity", "AttributeId", "AttributeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "AppointmentAttributeEntity", "Value", "Value", true, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits AppointmentSequenceEntity's mappings</summary>
		private void InitAppointmentSequenceEntityMappings()
		{
			base.AddElementMapping( "AppointmentSequenceEntity", "PsychologicalServices", @"dbo", "AppointmentSequences", 3 );
			base.AddElementFieldMapping( "AppointmentSequenceEntity", "AppointmentSequenceId", "AppointmentSequenceId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AppointmentSequenceEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "AppointmentSequenceEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits AppointmentStatusEntity's mappings</summary>
		private void InitAppointmentStatusEntityMappings()
		{
			base.AddElementMapping( "AppointmentStatusEntity", "PsychologicalServices", @"dbo", "AppointmentStatuses", 9 );
			base.AddElementFieldMapping( "AppointmentStatusEntity", "AppointmentStatusId", "AppointmentStatusId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AppointmentStatusEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "AppointmentStatusEntity", "Description", "Description", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "AppointmentStatusEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
			base.AddElementFieldMapping( "AppointmentStatusEntity", "NotifyReferralSource", "NotifyReferralSource", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 4 );
			base.AddElementFieldMapping( "AppointmentStatusEntity", "CanInvoice", "CanInvoice", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 5 );
			base.AddElementFieldMapping( "AppointmentStatusEntity", "Sort", "Sort", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
			base.AddElementFieldMapping( "AppointmentStatusEntity", "ShowOnSchedule", "ShowOnSchedule", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 7 );
			base.AddElementFieldMapping( "AppointmentStatusEntity", "ClaimantSeen", "ClaimantSeen", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 8 );
		}
		/// <summary>Inits AppointmentStatusInvoiceRateEntity's mappings</summary>
		private void InitAppointmentStatusInvoiceRateEntityMappings()
		{
			base.AddElementMapping( "AppointmentStatusInvoiceRateEntity", "PsychologicalServices", @"dbo", "AppointmentStatusInvoiceRates", 10 );
			base.AddElementFieldMapping( "AppointmentStatusInvoiceRateEntity", "CompanyId", "CompanyId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AppointmentStatusInvoiceRateEntity", "ReferralSourceId", "ReferralSourceId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "AppointmentStatusInvoiceRateEntity", "AppointmentStatusId", "AppointmentStatusId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "AppointmentStatusInvoiceRateEntity", "AppointmentSequenceId", "AppointmentSequenceId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "AppointmentStatusInvoiceRateEntity", "InvoiceRate", "InvoiceRate", false, (int)SqlDbType.Decimal, 0, 2, 3, false, "", null, typeof(System.Decimal), 4 );
			base.AddElementFieldMapping( "AppointmentStatusInvoiceRateEntity", "ApplyCompletionFee", "ApplyCompletionFee", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 5 );
			base.AddElementFieldMapping( "AppointmentStatusInvoiceRateEntity", "ApplyLargeFileFee", "ApplyLargeFileFee", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 6 );
			base.AddElementFieldMapping( "AppointmentStatusInvoiceRateEntity", "ApplyTravelFee", "ApplyTravelFee", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 7 );
			base.AddElementFieldMapping( "AppointmentStatusInvoiceRateEntity", "ApplyIssueInDisputeFees", "ApplyIssueInDisputeFees", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 8 );
			base.AddElementFieldMapping( "AppointmentStatusInvoiceRateEntity", "ApplyExtraReportFees", "ApplyExtraReportFees", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 9 );
		}
		/// <summary>Inits ArbitrationEntity's mappings</summary>
		private void InitArbitrationEntityMappings()
		{
			base.AddElementMapping( "ArbitrationEntity", "PsychologicalServices", @"dbo", "Arbitrations", 8 );
			base.AddElementFieldMapping( "ArbitrationEntity", "ArbitrationId", "ArbitrationId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ArbitrationEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "ArbitrationEntity", "StartDate", "StartDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 2 );
			base.AddElementFieldMapping( "ArbitrationEntity", "EndDate", "EndDate", true, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 3 );
			base.AddElementFieldMapping( "ArbitrationEntity", "AvailableDate", "AvailableDate", true, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 4 );
			base.AddElementFieldMapping( "ArbitrationEntity", "DefenseLawyerId", "DefenseLawyerId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			base.AddElementFieldMapping( "ArbitrationEntity", "DefenseFileNumber", "DefenseFileNumber", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "ArbitrationEntity", "Title", "Title", false, (int)SqlDbType.NVarChar, 250, 0, 0, false, "", null, typeof(System.String), 7 );
		}
		/// <summary>Inits AssessmentEntity's mappings</summary>
		private void InitAssessmentEntityMappings()
		{
			base.AddElementMapping( "AssessmentEntity", "PsychologicalServices", @"dbo", "Assessments", 18 );
			base.AddElementFieldMapping( "AssessmentEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentEntity", "ReferralTypeId", "ReferralTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "AssessmentEntity", "ReferralSourceId", "ReferralSourceId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "AssessmentEntity", "AssessmentTypeId", "AssessmentTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "AssessmentEntity", "CompanyId", "CompanyId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			base.AddElementFieldMapping( "AssessmentEntity", "ReportStatusId", "ReportStatusId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			base.AddElementFieldMapping( "AssessmentEntity", "FileSize", "FileSize", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
			base.AddElementFieldMapping( "AssessmentEntity", "ReferralSourceContactEmail", "ReferralSourceContactEmail", true, (int)SqlDbType.NVarChar, 4000, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "AssessmentEntity", "DocListWriterId", "DocListWriterId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 8 );
			base.AddElementFieldMapping( "AssessmentEntity", "NotesWriterId", "NotesWriterId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 9 );
			base.AddElementFieldMapping( "AssessmentEntity", "MedicalFileReceivedDate", "MedicalFileReceivedDate", true, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 10 );
			base.AddElementFieldMapping( "AssessmentEntity", "IsLargeFile", "IsLargeFile", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 11 );
			base.AddElementFieldMapping( "AssessmentEntity", "ReferralSourceFileNumber", "ReferralSourceFileNumber", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 12 );
			base.AddElementFieldMapping( "AssessmentEntity", "CreateDate", "CreateDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 13 );
			base.AddElementFieldMapping( "AssessmentEntity", "CreateUserId", "CreateUserId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 14 );
			base.AddElementFieldMapping( "AssessmentEntity", "UpdateDate", "UpdateDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 15 );
			base.AddElementFieldMapping( "AssessmentEntity", "UpdateUserId", "UpdateUserId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 16 );
			base.AddElementFieldMapping( "AssessmentEntity", "SummaryNoteId", "SummaryNoteId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 17 );
		}
		/// <summary>Inits AssessmentAttributeEntity's mappings</summary>
		private void InitAssessmentAttributeEntityMappings()
		{
			base.AddElementMapping( "AssessmentAttributeEntity", "PsychologicalServices", @"dbo", "AssessmentAttributes", 3 );
			base.AddElementFieldMapping( "AssessmentAttributeEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentAttributeEntity", "AttributeId", "AttributeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "AssessmentAttributeEntity", "Value", "Value", true, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits AssessmentClaimEntity's mappings</summary>
		private void InitAssessmentClaimEntityMappings()
		{
			base.AddElementMapping( "AssessmentClaimEntity", "PsychologicalServices", @"dbo", "AssessmentClaims", 2 );
			base.AddElementFieldMapping( "AssessmentClaimEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentClaimEntity", "ClaimId", "ClaimId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits AssessmentColorEntity's mappings</summary>
		private void InitAssessmentColorEntityMappings()
		{
			base.AddElementMapping( "AssessmentColorEntity", "PsychologicalServices", @"dbo", "AssessmentColors", 2 );
			base.AddElementFieldMapping( "AssessmentColorEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentColorEntity", "ColorId", "ColorId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits AssessmentMedRehabEntity's mappings</summary>
		private void InitAssessmentMedRehabEntityMappings()
		{
			base.AddElementMapping( "AssessmentMedRehabEntity", "PsychologicalServices", @"dbo", "AssessmentMedRehabs", 6 );
			base.AddElementFieldMapping( "AssessmentMedRehabEntity", "MedRehabId", "MedRehabId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentMedRehabEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "AssessmentMedRehabEntity", "Date", "Date", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 2 );
			base.AddElementFieldMapping( "AssessmentMedRehabEntity", "Amount", "Amount", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "AssessmentMedRehabEntity", "Description", "Description", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "AssessmentMedRehabEntity", "Deleted", "Deleted", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 5 );
		}
		/// <summary>Inits AssessmentNoteEntity's mappings</summary>
		private void InitAssessmentNoteEntityMappings()
		{
			base.AddElementMapping( "AssessmentNoteEntity", "PsychologicalServices", @"dbo", "AssessmentNotes", 3 );
			base.AddElementFieldMapping( "AssessmentNoteEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentNoteEntity", "NoteId", "NoteId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "AssessmentNoteEntity", "ShowOnCalendar", "ShowOnCalendar", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits AssessmentReportEntity's mappings</summary>
		private void InitAssessmentReportEntityMappings()
		{
			base.AddElementMapping( "AssessmentReportEntity", "PsychologicalServices", @"dbo", "AssessmentReports", 4 );
			base.AddElementFieldMapping( "AssessmentReportEntity", "ReportId", "ReportId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentReportEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "AssessmentReportEntity", "ReportTypeId", "ReportTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "AssessmentReportEntity", "IsAdditional", "IsAdditional", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
		}
		/// <summary>Inits AssessmentReportIssueInDisputeEntity's mappings</summary>
		private void InitAssessmentReportIssueInDisputeEntityMappings()
		{
			base.AddElementMapping( "AssessmentReportIssueInDisputeEntity", "PsychologicalServices", @"dbo", "AssessmentReportIssuesInDispute", 2 );
			base.AddElementFieldMapping( "AssessmentReportIssueInDisputeEntity", "ReportId", "ReportId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentReportIssueInDisputeEntity", "IssueInDisputeId", "IssueInDisputeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits AssessmentTypeEntity's mappings</summary>
		private void InitAssessmentTypeEntityMappings()
		{
			base.AddElementMapping( "AssessmentTypeEntity", "PsychologicalServices", @"dbo", "AssessmentTypes", 6 );
			base.AddElementFieldMapping( "AssessmentTypeEntity", "AssessmentTypeId", "AssessmentTypeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "AssessmentTypeEntity", "Description", "Description", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "AssessmentTypeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
			base.AddElementFieldMapping( "AssessmentTypeEntity", "ShowOnSchedule", "ShowOnSchedule", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 4 );
			base.AddElementFieldMapping( "AssessmentTypeEntity", "PsychometristCanInvoice", "PsychometristCanInvoice", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 5 );
		}
		/// <summary>Inits AssessmentTypeAttributeTypeEntity's mappings</summary>
		private void InitAssessmentTypeAttributeTypeEntityMappings()
		{
			base.AddElementMapping( "AssessmentTypeAttributeTypeEntity", "PsychologicalServices", @"dbo", "AssessmentTypeAttributeTypes", 2 );
			base.AddElementFieldMapping( "AssessmentTypeAttributeTypeEntity", "AssessmentTypeId", "AssessmentTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentTypeAttributeTypeEntity", "AttributeTypeId", "AttributeTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits AssessmentTypeInvoiceAmountEntity's mappings</summary>
		private void InitAssessmentTypeInvoiceAmountEntityMappings()
		{
			base.AddElementMapping( "AssessmentTypeInvoiceAmountEntity", "PsychologicalServices", @"dbo", "AssessmentTypeInvoiceAmounts", 5 );
			base.AddElementFieldMapping( "AssessmentTypeInvoiceAmountEntity", "CompanyId", "CompanyId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentTypeInvoiceAmountEntity", "ReferralSourceId", "ReferralSourceId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "AssessmentTypeInvoiceAmountEntity", "AssessmentTypeId", "AssessmentTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "AssessmentTypeInvoiceAmountEntity", "SingleReportInvoiceAmount", "SingleReportInvoiceAmount", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "AssessmentTypeInvoiceAmountEntity", "ComboReportInvoiceAmount", "ComboReportInvoiceAmount", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
		}
		/// <summary>Inits AssessmentTypeReportTypeEntity's mappings</summary>
		private void InitAssessmentTypeReportTypeEntityMappings()
		{
			base.AddElementMapping( "AssessmentTypeReportTypeEntity", "PsychologicalServices", @"dbo", "AssessmentTypeReportTypes", 2 );
			base.AddElementFieldMapping( "AssessmentTypeReportTypeEntity", "AssessmentTypeId", "AssessmentTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentTypeReportTypeEntity", "ReportTypeId", "ReportTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits AttributeEntity's mappings</summary>
		private void InitAttributeEntityMappings()
		{
			base.AddElementMapping( "AttributeEntity", "PsychologicalServices", @"dbo", "Attributes", 4 );
			base.AddElementFieldMapping( "AttributeEntity", "AttributeId", "AttributeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AttributeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "AttributeEntity", "AttributeTypeId", "AttributeTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "AttributeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
		}
		/// <summary>Inits AttributeTypeEntity's mappings</summary>
		private void InitAttributeTypeEntityMappings()
		{
			base.AddElementMapping( "AttributeTypeEntity", "PsychologicalServices", @"dbo", "AttributeTypes", 4 );
			base.AddElementFieldMapping( "AttributeTypeEntity", "AttributeTypeId", "AttributeTypeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AttributeTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "AttributeTypeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
			base.AddElementFieldMapping( "AttributeTypeEntity", "ShowOnAppointment", "ShowOnAppointment", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
		}
		/// <summary>Inits CalendarNoteEntity's mappings</summary>
		private void InitCalendarNoteEntityMappings()
		{
			base.AddElementMapping( "CalendarNoteEntity", "PsychologicalServices", @"dbo", "CalendarNotes", 5 );
			base.AddElementFieldMapping( "CalendarNoteEntity", "CalendarNoteId", "CalendarNoteId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "CalendarNoteEntity", "FromDate", "FromDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 1 );
			base.AddElementFieldMapping( "CalendarNoteEntity", "ToDate", "ToDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 2 );
			base.AddElementFieldMapping( "CalendarNoteEntity", "NoteId", "NoteId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "CalendarNoteEntity", "CompanyId", "CompanyId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
		}
		/// <summary>Inits CityEntity's mappings</summary>
		private void InitCityEntityMappings()
		{
			base.AddElementMapping( "CityEntity", "PsychologicalServices", @"dbo", "Cities", 5 );
			base.AddElementFieldMapping( "CityEntity", "CityId", "CityId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "CityEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "CityEntity", "Province", "Province", false, (int)SqlDbType.NVarChar, 10, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "CityEntity", "Country", "Country", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "CityEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 4 );
		}
		/// <summary>Inits ClaimEntity's mappings</summary>
		private void InitClaimEntityMappings()
		{
			base.AddElementMapping( "ClaimEntity", "PsychologicalServices", @"dbo", "Claims", 5 );
			base.AddElementFieldMapping( "ClaimEntity", "ClaimId", "ClaimId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ClaimEntity", "ClaimantId", "ClaimantId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "ClaimEntity", "DateOfLoss", "DateOfLoss", true, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 2 );
			base.AddElementFieldMapping( "ClaimEntity", "ClaimNumber", "ClaimNumber", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "ClaimEntity", "Lawyer", "Lawyer", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 4 );
		}
		/// <summary>Inits ClaimantEntity's mappings</summary>
		private void InitClaimantEntityMappings()
		{
			base.AddElementMapping( "ClaimantEntity", "PsychologicalServices", @"dbo", "Claimants", 7 );
			base.AddElementFieldMapping( "ClaimantEntity", "ClaimantId", "ClaimantId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ClaimantEntity", "FirstName", "FirstName", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ClaimantEntity", "LastName", "LastName", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "ClaimantEntity", "Age", "Age", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "ClaimantEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 4 );
			base.AddElementFieldMapping( "ClaimantEntity", "Gender", "Gender", false, (int)SqlDbType.NChar, 1, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "ClaimantEntity", "DateOfBirth", "DateOfBirth", true, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 6 );
		}
		/// <summary>Inits ColorEntity's mappings</summary>
		private void InitColorEntityMappings()
		{
			base.AddElementMapping( "ColorEntity", "PsychologicalServices", @"dbo", "Colors", 4 );
			base.AddElementFieldMapping( "ColorEntity", "ColorId", "ColorId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ColorEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ColorEntity", "HexCode", "HexCode", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "ColorEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
		}
		/// <summary>Inits CompanyEntity's mappings</summary>
		private void InitCompanyEntityMappings()
		{
			base.AddElementMapping( "CompanyEntity", "PsychologicalServices", @"dbo", "Companies", 19 );
			base.AddElementFieldMapping( "CompanyEntity", "CompanyId", "CompanyId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "CompanyEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "CompanyEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
			base.AddElementFieldMapping( "CompanyEntity", "AddressId", "AddressId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "CompanyEntity", "Phone", "Phone", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "CompanyEntity", "Fax", "Fax", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "CompanyEntity", "Email", "Email", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "CompanyEntity", "TaxId", "TaxId", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "CompanyEntity", "NewAppointmentTime", "NewAppointmentTime", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
			base.AddElementFieldMapping( "CompanyEntity", "NewAppointmentLocationId", "NewAppointmentLocationId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 9 );
			base.AddElementFieldMapping( "CompanyEntity", "NewAppointmentPsychologistId", "NewAppointmentPsychologistId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 10 );
			base.AddElementFieldMapping( "CompanyEntity", "NewAppointmentPsychometristId", "NewAppointmentPsychometristId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 11 );
			base.AddElementFieldMapping( "CompanyEntity", "NewAppointmentStatusId", "NewAppointmentStatusId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 12 );
			base.AddElementFieldMapping( "CompanyEntity", "NewAssessmentReportStatusId", "NewAssessmentReportStatusId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 13 );
			base.AddElementFieldMapping( "CompanyEntity", "NewAssessmentSummaryNoteText", "NewAssessmentSummaryNoteText", true, (int)SqlDbType.NVarChar, 2147483647, 0, 0, false, "", null, typeof(System.String), 14 );
			base.AddElementFieldMapping( "CompanyEntity", "Timezone", "Timezone", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 15 );
			base.AddElementFieldMapping( "CompanyEntity", "ReplyToEmail", "ReplyToEmail", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 16 );
			base.AddElementFieldMapping( "CompanyEntity", "NewAssessmentAssessmentTypeId", "NewAssessmentAssessmentTypeId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 17 );
			base.AddElementFieldMapping( "CompanyEntity", "InvoiceCounter", "InvoiceCounter", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 18 );
		}
		/// <summary>Inits CompanyAttributeEntity's mappings</summary>
		private void InitCompanyAttributeEntityMappings()
		{
			base.AddElementMapping( "CompanyAttributeEntity", "PsychologicalServices", @"dbo", "CompanyAttributes", 2 );
			base.AddElementFieldMapping( "CompanyAttributeEntity", "CompanyId", "CompanyId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "CompanyAttributeEntity", "AttributeId", "AttributeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits ContactEntity's mappings</summary>
		private void InitContactEntityMappings()
		{
			base.AddElementMapping( "ContactEntity", "PsychologicalServices", @"dbo", "Contacts", 8 );
			base.AddElementFieldMapping( "ContactEntity", "ContactId", "ContactId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ContactEntity", "FirstName", "FirstName", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ContactEntity", "LastName", "LastName", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "ContactEntity", "Email", "Email", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "ContactEntity", "ContactTypeId", "ContactTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			base.AddElementFieldMapping( "ContactEntity", "AddressId", "AddressId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			base.AddElementFieldMapping( "ContactEntity", "EmployerId", "EmployerId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
			base.AddElementFieldMapping( "ContactEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 7 );
		}
		/// <summary>Inits ContactTypeEntity's mappings</summary>
		private void InitContactTypeEntityMappings()
		{
			base.AddElementMapping( "ContactTypeEntity", "PsychologicalServices", @"dbo", "ContactTypes", 3 );
			base.AddElementFieldMapping( "ContactTypeEntity", "ContactTypeId", "ContactTypeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ContactTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ContactTypeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits EmployerEntity's mappings</summary>
		private void InitEmployerEntityMappings()
		{
			base.AddElementMapping( "EmployerEntity", "PsychologicalServices", @"dbo", "Employers", 4 );
			base.AddElementFieldMapping( "EmployerEntity", "EmployerId", "EmployerId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "EmployerEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "EmployerEntity", "EmployerTypeId", "EmployerTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "EmployerEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
		}
		/// <summary>Inits EmployerTypeEntity's mappings</summary>
		private void InitEmployerTypeEntityMappings()
		{
			base.AddElementMapping( "EmployerTypeEntity", "PsychologicalServices", @"dbo", "EmployerTypes", 3 );
			base.AddElementFieldMapping( "EmployerTypeEntity", "EmployerTypeId", "EmployerTypeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "EmployerTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "EmployerTypeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits InvoiceEntity's mappings</summary>
		private void InitInvoiceEntityMappings()
		{
			base.AddElementMapping( "InvoiceEntity", "PsychologicalServices", @"dbo", "Invoices", 10 );
			base.AddElementFieldMapping( "InvoiceEntity", "InvoiceId", "InvoiceId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "InvoiceEntity", "Identifier", "Identifier", false, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "InvoiceEntity", "InvoiceDate", "InvoiceDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 2 );
			base.AddElementFieldMapping( "InvoiceEntity", "InvoiceStatusId", "InvoiceStatusId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "InvoiceEntity", "UpdateDate", "UpdateDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 4 );
			base.AddElementFieldMapping( "InvoiceEntity", "TaxRate", "TaxRate", false, (int)SqlDbType.Decimal, 0, 4, 18, false, "", null, typeof(System.Decimal), 5 );
			base.AddElementFieldMapping( "InvoiceEntity", "Total", "Total", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
			base.AddElementFieldMapping( "InvoiceEntity", "InvoiceTypeId", "InvoiceTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 7 );
			base.AddElementFieldMapping( "InvoiceEntity", "PayableToId", "PayableToId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 8 );
			base.AddElementFieldMapping( "InvoiceEntity", "InvoiceRate", "InvoiceRate", false, (int)SqlDbType.Decimal, 0, 2, 3, false, "", null, typeof(System.Decimal), 9 );
		}
		/// <summary>Inits InvoiceAppointmentEntity's mappings</summary>
		private void InitInvoiceAppointmentEntityMappings()
		{
			base.AddElementMapping( "InvoiceAppointmentEntity", "PsychologicalServices", @"dbo", "InvoiceAppointments", 3 );
			base.AddElementFieldMapping( "InvoiceAppointmentEntity", "InvoiceAppointmentId", "InvoiceAppointmentId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "InvoiceAppointmentEntity", "InvoiceId", "InvoiceId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "InvoiceAppointmentEntity", "AppointmentId", "AppointmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits InvoiceDocumentEntity's mappings</summary>
		private void InitInvoiceDocumentEntityMappings()
		{
			base.AddElementMapping( "InvoiceDocumentEntity", "PsychologicalServices", @"dbo", "InvoiceDocuments", 5 );
			base.AddElementFieldMapping( "InvoiceDocumentEntity", "InvoiceDocumentId", "InvoiceDocumentId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "InvoiceDocumentEntity", "InvoiceId", "InvoiceId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "InvoiceDocumentEntity", "Document", "Document", false, (int)SqlDbType.VarBinary, 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 2 );
			base.AddElementFieldMapping( "InvoiceDocumentEntity", "CreateDate", "CreateDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 3 );
			base.AddElementFieldMapping( "InvoiceDocumentEntity", "FileName", "FileName", false, (int)SqlDbType.VarChar, 150, 0, 0, false, "", null, typeof(System.String), 4 );
		}
		/// <summary>Inits InvoiceLineEntity's mappings</summary>
		private void InitInvoiceLineEntityMappings()
		{
			base.AddElementMapping( "InvoiceLineEntity", "PsychologicalServices", @"dbo", "InvoiceLines", 6 );
			base.AddElementFieldMapping( "InvoiceLineEntity", "InvoiceLineId", "InvoiceLineId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "InvoiceLineEntity", "InvoiceAppointmentId", "InvoiceAppointmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "InvoiceLineEntity", "Description", "Description", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "InvoiceLineEntity", "Amount", "Amount", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "InvoiceLineEntity", "IsCustom", "IsCustom", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 4 );
			base.AddElementFieldMapping( "InvoiceLineEntity", "ApplyInvoiceRate", "ApplyInvoiceRate", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 5 );
		}
		/// <summary>Inits InvoiceStatusEntity's mappings</summary>
		private void InitInvoiceStatusEntityMappings()
		{
			base.AddElementMapping( "InvoiceStatusEntity", "PsychologicalServices", @"dbo", "InvoiceStatuses", 6 );
			base.AddElementFieldMapping( "InvoiceStatusEntity", "InvoiceStatusId", "InvoiceStatusId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "InvoiceStatusEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "InvoiceStatusEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
			base.AddElementFieldMapping( "InvoiceStatusEntity", "CanEdit", "CanEdit", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
			base.AddElementFieldMapping( "InvoiceStatusEntity", "SaveDocument", "SaveDocument", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 4 );
			base.AddElementFieldMapping( "InvoiceStatusEntity", "ActionName", "ActionName", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits InvoiceStatusChangeEntity's mappings</summary>
		private void InitInvoiceStatusChangeEntityMappings()
		{
			base.AddElementMapping( "InvoiceStatusChangeEntity", "PsychologicalServices", @"dbo", "InvoiceStatusChanges", 4 );
			base.AddElementFieldMapping( "InvoiceStatusChangeEntity", "InvoiceStatusChangeId", "InvoiceStatusChangeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "InvoiceStatusChangeEntity", "InvoiceId", "InvoiceId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "InvoiceStatusChangeEntity", "InvoiceStatusId", "InvoiceStatusId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "InvoiceStatusChangeEntity", "UpdateDate", "UpdateDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 3 );
		}
		/// <summary>Inits InvoiceStatusPathsEntity's mappings</summary>
		private void InitInvoiceStatusPathsEntityMappings()
		{
			base.AddElementMapping( "InvoiceStatusPathsEntity", "PsychologicalServices", @"dbo", "InvoiceStatusPaths", 3 );
			base.AddElementFieldMapping( "InvoiceStatusPathsEntity", "InvoiceStatusPathId", "InvoiceStatusPathId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "InvoiceStatusPathsEntity", "InvoiceStatusId", "InvoiceStatusId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "InvoiceStatusPathsEntity", "NextInvoiceStatusId", "NextInvoiceStatusId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits InvoiceTypeEntity's mappings</summary>
		private void InitInvoiceTypeEntityMappings()
		{
			base.AddElementMapping( "InvoiceTypeEntity", "PsychologicalServices", @"dbo", "InvoiceTypes", 3 );
			base.AddElementFieldMapping( "InvoiceTypeEntity", "InvoiceTypeId", "InvoiceTypeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "InvoiceTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "InvoiceTypeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits IssueInDisputeEntity's mappings</summary>
		private void InitIssueInDisputeEntityMappings()
		{
			base.AddElementMapping( "IssueInDisputeEntity", "PsychologicalServices", @"dbo", "IssuesInDispute", 3 );
			base.AddElementFieldMapping( "IssueInDisputeEntity", "IssueInDisputeId", "IssueInDisputeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "IssueInDisputeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "IssueInDisputeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits IssueInDisputeInvoiceAmountEntity's mappings</summary>
		private void InitIssueInDisputeInvoiceAmountEntityMappings()
		{
			base.AddElementMapping( "IssueInDisputeInvoiceAmountEntity", "PsychologicalServices", @"dbo", "IssueInDisputeInvoiceAmounts", 3 );
			base.AddElementFieldMapping( "IssueInDisputeInvoiceAmountEntity", "CompanyId", "CompanyId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "IssueInDisputeInvoiceAmountEntity", "IssueInDisputeId", "IssueInDisputeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "IssueInDisputeInvoiceAmountEntity", "InvoiceAmount", "InvoiceAmount", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits NoteEntity's mappings</summary>
		private void InitNoteEntityMappings()
		{
			base.AddElementMapping( "NoteEntity", "PsychologicalServices", @"dbo", "Notes", 6 );
			base.AddElementFieldMapping( "NoteEntity", "NoteId", "NoteId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "NoteEntity", "Note", "Note", false, (int)SqlDbType.NVarChar, 2147483647, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "NoteEntity", "UpdateUserId", "UpdateUserId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "NoteEntity", "UpdateDate", "UpdateDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 3 );
			base.AddElementFieldMapping( "NoteEntity", "CreateUserId", "CreateUserId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			base.AddElementFieldMapping( "NoteEntity", "CreateDate", "CreateDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 5 );
		}
		/// <summary>Inits PsychometristInvoiceAmountEntity's mappings</summary>
		private void InitPsychometristInvoiceAmountEntityMappings()
		{
			base.AddElementMapping( "PsychometristInvoiceAmountEntity", "PsychologicalServices", @"dbo", "PsychometristInvoiceAmounts", 5 );
			base.AddElementFieldMapping( "PsychometristInvoiceAmountEntity", "AssessmentTypeId", "AssessmentTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "PsychometristInvoiceAmountEntity", "AppointmentStatusId", "AppointmentStatusId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "PsychometristInvoiceAmountEntity", "CompanyId", "CompanyId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "PsychometristInvoiceAmountEntity", "AppointmentSequenceId", "AppointmentSequenceId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "PsychometristInvoiceAmountEntity", "InvoiceAmount", "InvoiceAmount", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
		}
		/// <summary>Inits ReferralSourceEntity's mappings</summary>
		private void InitReferralSourceEntityMappings()
		{
			base.AddElementMapping( "ReferralSourceEntity", "PsychologicalServices", @"dbo", "ReferralSources", 6 );
			base.AddElementFieldMapping( "ReferralSourceEntity", "ReferralSourceId", "ReferralSourceId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ReferralSourceEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ReferralSourceEntity", "ReferralSourceTypeId", "ReferralSourceTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "ReferralSourceEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
			base.AddElementFieldMapping( "ReferralSourceEntity", "AddressId", "AddressId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			base.AddElementFieldMapping( "ReferralSourceEntity", "InvoicesContactEmail", "InvoicesContactEmail", true, (int)SqlDbType.NVarChar, 4000, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits ReferralSourceInvoiceConfigurationEntity's mappings</summary>
		private void InitReferralSourceInvoiceConfigurationEntityMappings()
		{
			base.AddElementMapping( "ReferralSourceInvoiceConfigurationEntity", "PsychologicalServices", @"dbo", "ReferralSourceInvoiceConfiguration", 6 );
			base.AddElementFieldMapping( "ReferralSourceInvoiceConfigurationEntity", "ReferralSourceId", "ReferralSourceId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ReferralSourceInvoiceConfigurationEntity", "CompanyId", "CompanyId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "ReferralSourceInvoiceConfigurationEntity", "LargeFileSize", "LargeFileSize", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "ReferralSourceInvoiceConfigurationEntity", "LargeFileFee", "LargeFileFee", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "ReferralSourceInvoiceConfigurationEntity", "ExtraReportFee", "ExtraReportFee", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			base.AddElementFieldMapping( "ReferralSourceInvoiceConfigurationEntity", "CompletionFeeAmount", "CompletionFeeAmount", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
		}
		/// <summary>Inits ReferralSourceTypeEntity's mappings</summary>
		private void InitReferralSourceTypeEntityMappings()
		{
			base.AddElementMapping( "ReferralSourceTypeEntity", "PsychologicalServices", @"dbo", "ReferralSourceTypes", 3 );
			base.AddElementFieldMapping( "ReferralSourceTypeEntity", "ReferralSourceTypeId", "ReferralSourceTypeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ReferralSourceTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ReferralSourceTypeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits ReferralTypeEntity's mappings</summary>
		private void InitReferralTypeEntityMappings()
		{
			base.AddElementMapping( "ReferralTypeEntity", "PsychologicalServices", @"dbo", "ReferralTypes", 3 );
			base.AddElementFieldMapping( "ReferralTypeEntity", "ReferralTypeId", "ReferralTypeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ReferralTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ReferralTypeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits ReferralTypeIssueInDisputeEntity's mappings</summary>
		private void InitReferralTypeIssueInDisputeEntityMappings()
		{
			base.AddElementMapping( "ReferralTypeIssueInDisputeEntity", "PsychologicalServices", @"dbo", "ReferralTypeIssuesInDispute", 2 );
			base.AddElementFieldMapping( "ReferralTypeIssueInDisputeEntity", "ReferralTypeId", "ReferralTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ReferralTypeIssueInDisputeEntity", "IssueInDisputeId", "IssueInDisputeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits ReportStatusEntity's mappings</summary>
		private void InitReportStatusEntityMappings()
		{
			base.AddElementMapping( "ReportStatusEntity", "PsychologicalServices", @"dbo", "ReportStatuses", 3 );
			base.AddElementFieldMapping( "ReportStatusEntity", "ReportStatusId", "ReportStatusId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ReportStatusEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ReportStatusEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits ReportTypeEntity's mappings</summary>
		private void InitReportTypeEntityMappings()
		{
			base.AddElementMapping( "ReportTypeEntity", "PsychologicalServices", @"dbo", "ReportTypes", 3 );
			base.AddElementFieldMapping( "ReportTypeEntity", "ReportTypeId", "ReportTypeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ReportTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ReportTypeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits RightEntity's mappings</summary>
		private void InitRightEntityMappings()
		{
			base.AddElementMapping( "RightEntity", "PsychologicalServices", @"dbo", "Rights", 4 );
			base.AddElementFieldMapping( "RightEntity", "RightId", "RightId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "RightEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "RightEntity", "Description", "Description", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "RightEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
		}
		/// <summary>Inits RoleEntity's mappings</summary>
		private void InitRoleEntityMappings()
		{
			base.AddElementMapping( "RoleEntity", "PsychologicalServices", @"dbo", "Roles", 4 );
			base.AddElementFieldMapping( "RoleEntity", "RoleId", "RoleId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "RoleEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "RoleEntity", "Description", "Description", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "RoleEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
		}
		/// <summary>Inits RoleRightEntity's mappings</summary>
		private void InitRoleRightEntityMappings()
		{
			base.AddElementMapping( "RoleRightEntity", "PsychologicalServices", @"dbo", "RoleRights", 2 );
			base.AddElementFieldMapping( "RoleRightEntity", "RoleId", "RoleId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "RoleRightEntity", "RightId", "RightId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits UserEntity's mappings</summary>
		private void InitUserEntityMappings()
		{
			base.AddElementMapping( "UserEntity", "PsychologicalServices", @"dbo", "Users", 7 );
			base.AddElementFieldMapping( "UserEntity", "UserId", "UserId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "UserEntity", "FirstName", "FirstName", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "UserEntity", "LastName", "LastName", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "UserEntity", "Email", "Email", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "UserEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 4 );
			base.AddElementFieldMapping( "UserEntity", "CompanyId", "CompanyId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			base.AddElementFieldMapping( "UserEntity", "AddressId", "AddressId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
		}
		/// <summary>Inits UserNoteEntity's mappings</summary>
		private void InitUserNoteEntityMappings()
		{
			base.AddElementMapping( "UserNoteEntity", "PsychologicalServices", @"dbo", "UserNotes", 2 );
			base.AddElementFieldMapping( "UserNoteEntity", "NoteId", "NoteId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "UserNoteEntity", "UserId", "UserId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits UserRoleEntity's mappings</summary>
		private void InitUserRoleEntityMappings()
		{
			base.AddElementMapping( "UserRoleEntity", "PsychologicalServices", @"dbo", "UserRoles", 2 );
			base.AddElementFieldMapping( "UserRoleEntity", "UserId", "UserId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "UserRoleEntity", "RoleId", "RoleId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits UserTravelFeeEntity's mappings</summary>
		private void InitUserTravelFeeEntityMappings()
		{
			base.AddElementMapping( "UserTravelFeeEntity", "PsychologicalServices", @"dbo", "UserTravelFees", 3 );
			base.AddElementFieldMapping( "UserTravelFeeEntity", "UserId", "UserId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "UserTravelFeeEntity", "CityId", "CityId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "UserTravelFeeEntity", "Amount", "Amount", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits UserUnavailabilityEntity's mappings</summary>
		private void InitUserUnavailabilityEntityMappings()
		{
			base.AddElementMapping( "UserUnavailabilityEntity", "PsychologicalServices", @"dbo", "UserUnavailabilities", 4 );
			base.AddElementFieldMapping( "UserUnavailabilityEntity", "Id", "Id", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "UserUnavailabilityEntity", "UserId", "UserId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "UserUnavailabilityEntity", "StartDate", "StartDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 2 );
			base.AddElementFieldMapping( "UserUnavailabilityEntity", "EndDate", "EndDate", false, (int)SqlDbType.DateTimeOffset, 0, 0, 0, false, "", null, typeof(System.DateTimeOffset), 3 );
		}

	}
}













