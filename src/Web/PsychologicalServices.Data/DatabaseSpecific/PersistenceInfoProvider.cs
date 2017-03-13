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
			base.InitClass((36 + 0));
			InitAddressEntityMappings();
			InitAddressTypeEntityMappings();
			InitAppointmentEntityMappings();
			InitAppointmentAttributeEntityMappings();
			InitAppointmentStatusEntityMappings();
			InitAssessmentEntityMappings();
			InitAssessmentAttributeEntityMappings();
			InitAssessmentClaimEntityMappings();
			InitAssessmentColorEntityMappings();
			InitAssessmentIssueInDisputeEntityMappings();
			InitAssessmentMedRehabEntityMappings();
			InitAssessmentNoteEntityMappings();
			InitAssessmentTypeEntityMappings();
			InitAssessmentTypeReportTypeEntityMappings();
			InitAttributeEntityMappings();
			InitAttributeTypeEntityMappings();
			InitCalendarNoteEntityMappings();
			InitClaimEntityMappings();
			InitClaimantEntityMappings();
			InitColorEntityMappings();
			InitCompanyEntityMappings();
			InitCompanyAttributeEntityMappings();
			InitInvoiceAmountEntityMappings();
			InitIssueInDisputeEntityMappings();
			InitNoteEntityMappings();
			InitReferralSourceEntityMappings();
			InitReferralSourceTypeEntityMappings();
			InitReferralTypeEntityMappings();
			InitReferralTypeIssueInDisputeEntityMappings();
			InitReportStatusEntityMappings();
			InitReportTypeEntityMappings();
			InitRightEntityMappings();
			InitRoleEntityMappings();
			InitRoleRightEntityMappings();
			InitUserEntityMappings();
			InitUserRoleEntityMappings();

		}


		/// <summary>Inits AddressEntity's mappings</summary>
		private void InitAddressEntityMappings()
		{
			base.AddElementMapping( "AddressEntity", "PsychologicalServices", @"dbo", "Addresses", 10 );
			base.AddElementFieldMapping( "AddressEntity", "AddressId", "AddressId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AddressEntity", "Street", "Address", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "AddressEntity", "Suite", "Suite", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "AddressEntity", "City", "City", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "AddressEntity", "Province", "Province", false, (int)SqlDbType.NVarChar, 10, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "AddressEntity", "PostalCode", "PostalCode", false, (int)SqlDbType.NVarChar, 10, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "AddressEntity", "Country", "Country", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "AddressEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 7 );
			base.AddElementFieldMapping( "AddressEntity", "AddressTypeId", "AddressTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 8 );
			base.AddElementFieldMapping( "AddressEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 9 );
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
			base.AddElementMapping( "AppointmentEntity", "PsychologicalServices", @"dbo", "Appointments", 9 );
			base.AddElementFieldMapping( "AppointmentEntity", "AppointmentId", "AppointmentId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AppointmentEntity", "LocationId", "AddressId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "AppointmentEntity", "AppointmentTime", "AppointmentTime", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "AppointmentEntity", "PsychometristId", "PsychometristId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "AppointmentEntity", "PsychologistId", "PsychologistId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			base.AddElementFieldMapping( "AppointmentEntity", "AppointmentStatusId", "AppointmentStatusId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			base.AddElementFieldMapping( "AppointmentEntity", "Deleted", "Deleted", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 6 );
			base.AddElementFieldMapping( "AppointmentEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 7 );
			base.AddElementFieldMapping( "AppointmentEntity", "PsychometristConfirmed", "PsychometristConfirmed", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 8 );
		}
		/// <summary>Inits AppointmentAttributeEntity's mappings</summary>
		private void InitAppointmentAttributeEntityMappings()
		{
			base.AddElementMapping( "AppointmentAttributeEntity", "PsychologicalServices", @"dbo", "AppointmentAttributes", 2 );
			base.AddElementFieldMapping( "AppointmentAttributeEntity", "AppointmentId", "AppointmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AppointmentAttributeEntity", "AttributeId", "AttributeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits AppointmentStatusEntity's mappings</summary>
		private void InitAppointmentStatusEntityMappings()
		{
			base.AddElementMapping( "AppointmentStatusEntity", "PsychologicalServices", @"dbo", "AppointmentStatuses", 5 );
			base.AddElementFieldMapping( "AppointmentStatusEntity", "AppointmentStatusId", "AppointmentStatusId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AppointmentStatusEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "AppointmentStatusEntity", "Description", "Description", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "AppointmentStatusEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
			base.AddElementFieldMapping( "AppointmentStatusEntity", "NotifyReferralSource", "NotifyReferralSource", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 4 );
		}
		/// <summary>Inits AssessmentEntity's mappings</summary>
		private void InitAssessmentEntityMappings()
		{
			base.AddElementMapping( "AssessmentEntity", "PsychologicalServices", @"dbo", "Assessments", 13 );
			base.AddElementFieldMapping( "AssessmentEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentEntity", "ReferralTypeId", "ReferralTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "AssessmentEntity", "ReferralSourceId", "ReferralSourceId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "AssessmentEntity", "AssessmentTypeId", "AssessmentTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "AssessmentEntity", "Deleted", "Deleted", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 4 );
			base.AddElementFieldMapping( "AssessmentEntity", "CompanyId", "CompanyId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			base.AddElementFieldMapping( "AssessmentEntity", "ReportStatusId", "ReportStatusId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
			base.AddElementFieldMapping( "AssessmentEntity", "FileSize", "FileSize", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 7 );
			base.AddElementFieldMapping( "AssessmentEntity", "ReferralSourceContactEmail", "ReferralSourceContactEmail", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "AssessmentEntity", "DocListWriterId", "DocListWriterId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 9 );
			base.AddElementFieldMapping( "AssessmentEntity", "NotesWriterId", "NotesWriterId", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 10 );
			base.AddElementFieldMapping( "AssessmentEntity", "MedicalFileReceivedDate", "MedicalFileReceivedDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 11 );
			base.AddElementFieldMapping( "AssessmentEntity", "IsLargeFile", "IsLargeFile", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 12 );
		}
		/// <summary>Inits AssessmentAttributeEntity's mappings</summary>
		private void InitAssessmentAttributeEntityMappings()
		{
			base.AddElementMapping( "AssessmentAttributeEntity", "PsychologicalServices", @"dbo", "AssessmentAttributes", 2 );
			base.AddElementFieldMapping( "AssessmentAttributeEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentAttributeEntity", "AttributeId", "AttributeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
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
		/// <summary>Inits AssessmentIssueInDisputeEntity's mappings</summary>
		private void InitAssessmentIssueInDisputeEntityMappings()
		{
			base.AddElementMapping( "AssessmentIssueInDisputeEntity", "PsychologicalServices", @"dbo", "AssessmentIssuesInDispute", 2 );
			base.AddElementFieldMapping( "AssessmentIssueInDisputeEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentIssueInDisputeEntity", "IssueIsDisputeId", "IssueIsDisputeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits AssessmentMedRehabEntity's mappings</summary>
		private void InitAssessmentMedRehabEntityMappings()
		{
			base.AddElementMapping( "AssessmentMedRehabEntity", "PsychologicalServices", @"dbo", "AssessmentMedRehabs", 6 );
			base.AddElementFieldMapping( "AssessmentMedRehabEntity", "MedRehabId", "MedRehabId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentMedRehabEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "AssessmentMedRehabEntity", "Date", "Date", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "AssessmentMedRehabEntity", "Amount", "Amount", false, (int)SqlDbType.Decimal, 0, 0, 18, false, "", null, typeof(System.Decimal), 3 );
			base.AddElementFieldMapping( "AssessmentMedRehabEntity", "Description", "Description", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "AssessmentMedRehabEntity", "Deleted", "Deleted", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 5 );
		}
		/// <summary>Inits AssessmentNoteEntity's mappings</summary>
		private void InitAssessmentNoteEntityMappings()
		{
			base.AddElementMapping( "AssessmentNoteEntity", "PsychologicalServices", @"dbo", "AssessmentNotes", 2 );
			base.AddElementFieldMapping( "AssessmentNoteEntity", "AssessmentId", "AssessmentId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentNoteEntity", "NoteId", "NoteId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits AssessmentTypeEntity's mappings</summary>
		private void InitAssessmentTypeEntityMappings()
		{
			base.AddElementMapping( "AssessmentTypeEntity", "PsychologicalServices", @"dbo", "AssessmentTypes", 5 );
			base.AddElementFieldMapping( "AssessmentTypeEntity", "AssessmentTypeId", "AssessmentTypeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AssessmentTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "AssessmentTypeEntity", "Description", "Description", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "AssessmentTypeEntity", "Duration", "Duration", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "AssessmentTypeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 4 );
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
			base.AddElementMapping( "AttributeTypeEntity", "PsychologicalServices", @"dbo", "AttributeTypes", 3 );
			base.AddElementFieldMapping( "AttributeTypeEntity", "AttributeTypeId", "AttributeTypeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "AttributeTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "AttributeTypeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits CalendarNoteEntity's mappings</summary>
		private void InitCalendarNoteEntityMappings()
		{
			base.AddElementMapping( "CalendarNoteEntity", "PsychologicalServices", @"dbo", "CalendarNotes", 4 );
			base.AddElementFieldMapping( "CalendarNoteEntity", "CalendarNoteId", "CalendarNoteId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "CalendarNoteEntity", "FromDate", "FromDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 1 );
			base.AddElementFieldMapping( "CalendarNoteEntity", "ToDate", "ToDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "CalendarNoteEntity", "NoteId", "NoteId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
		}
		/// <summary>Inits ClaimEntity's mappings</summary>
		private void InitClaimEntityMappings()
		{
			base.AddElementMapping( "ClaimEntity", "PsychologicalServices", @"dbo", "Claims", 5 );
			base.AddElementFieldMapping( "ClaimEntity", "ClaimId", "ClaimId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ClaimEntity", "ClaimantId", "ClaimantId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "ClaimEntity", "DateOfLoss", "DateOfLoss", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "ClaimEntity", "ClaimNumber", "ClaimNumber", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "ClaimEntity", "Deleted", "Deleted", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 4 );
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
			base.AddElementFieldMapping( "ClaimantEntity", "DateOfBirth", "DateOfBirth", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 6 );
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
			base.AddElementMapping( "CompanyEntity", "PsychologicalServices", @"dbo", "Companies", 3 );
			base.AddElementFieldMapping( "CompanyEntity", "CompanyId", "CompanyId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "CompanyEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "CompanyEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
		}
		/// <summary>Inits CompanyAttributeEntity's mappings</summary>
		private void InitCompanyAttributeEntityMappings()
		{
			base.AddElementMapping( "CompanyAttributeEntity", "PsychologicalServices", @"dbo", "CompanyAttributes", 2 );
			base.AddElementFieldMapping( "CompanyAttributeEntity", "CompanyId", "CompanyId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "CompanyAttributeEntity", "AttributeId", "AttributeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits InvoiceAmountEntity's mappings</summary>
		private void InitInvoiceAmountEntityMappings()
		{
			base.AddElementMapping( "InvoiceAmountEntity", "PsychologicalServices", @"dbo", "InvoiceAmounts", 3 );
			base.AddElementFieldMapping( "InvoiceAmountEntity", "ReferralSourceId", "ReferralSourceId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "InvoiceAmountEntity", "ReportTypeId", "ReportTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "InvoiceAmountEntity", "InvoiceAmount", "InvoiceAmount", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits IssueInDisputeEntity's mappings</summary>
		private void InitIssueInDisputeEntityMappings()
		{
			base.AddElementMapping( "IssueInDisputeEntity", "PsychologicalServices", @"dbo", "IssuesInDispute", 4 );
			base.AddElementFieldMapping( "IssueInDisputeEntity", "IssueInDisputeId", "IssueInDisputeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "IssueInDisputeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "IssueInDisputeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
			base.AddElementFieldMapping( "IssueInDisputeEntity", "Instructions", "Instructions", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
		}
		/// <summary>Inits NoteEntity's mappings</summary>
		private void InitNoteEntityMappings()
		{
			base.AddElementMapping( "NoteEntity", "PsychologicalServices", @"dbo", "Notes", 7 );
			base.AddElementFieldMapping( "NoteEntity", "NoteId", "NoteId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "NoteEntity", "Note", "Note", false, (int)SqlDbType.NVarChar, 1000, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "NoteEntity", "UpdateUserId", "UpdateUserId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "NoteEntity", "UpdateDate", "UpdateDate", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
			base.AddElementFieldMapping( "NoteEntity", "CreateUserId", "CreateUserId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			base.AddElementFieldMapping( "NoteEntity", "CreateDate", "CreateDate", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 5 );
			base.AddElementFieldMapping( "NoteEntity", "Deleted", "Deleted", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 6 );
		}
		/// <summary>Inits ReferralSourceEntity's mappings</summary>
		private void InitReferralSourceEntityMappings()
		{
			base.AddElementMapping( "ReferralSourceEntity", "PsychologicalServices", @"dbo", "ReferralSources", 6 );
			base.AddElementFieldMapping( "ReferralSourceEntity", "ReferralSourceId", "ReferralSourceId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ReferralSourceEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ReferralSourceEntity", "ReferralSourceTypeId", "ReferralSourceTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "ReferralSourceEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
			base.AddElementFieldMapping( "ReferralSourceEntity", "LargeFileSize", "LargeFileSize", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			base.AddElementFieldMapping( "ReferralSourceEntity", "LargeFileFeeAmount", "LargeFileFeeAmount", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
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
			base.AddElementMapping( "ReportTypeEntity", "PsychologicalServices", @"dbo", "ReportTypes", 4 );
			base.AddElementFieldMapping( "ReportTypeEntity", "ReportTypeId", "ReportTypeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ReportTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ReportTypeEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
			base.AddElementFieldMapping( "ReportTypeEntity", "NumberOfReports", "NumberOfReports", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
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
			base.AddElementMapping( "UserEntity", "PsychologicalServices", @"dbo", "Users", 6 );
			base.AddElementFieldMapping( "UserEntity", "UserId", "UserId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "UserEntity", "FirstName", "FirstName", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "UserEntity", "LastName", "LastName", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "UserEntity", "Email", "Email", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "UserEntity", "IsActive", "IsActive", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 4 );
			base.AddElementFieldMapping( "UserEntity", "CompanyId", "CompanyId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
		}
		/// <summary>Inits UserRoleEntity's mappings</summary>
		private void InitUserRoleEntityMappings()
		{
			base.AddElementMapping( "UserRoleEntity", "PsychologicalServices", @"dbo", "UserRoles", 2 );
			base.AddElementFieldMapping( "UserRoleEntity", "UserId", "UserId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "UserRoleEntity", "RoleId", "RoleId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}

	}
}













