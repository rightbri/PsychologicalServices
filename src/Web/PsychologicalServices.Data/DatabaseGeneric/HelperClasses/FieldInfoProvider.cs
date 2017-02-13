///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PsychologicalServices.Data.HelperClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>
	/// Singleton implementation of the FieldInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.
	/// </summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the FieldInfoProviderBase class is threadsafe.</remarks>
	internal sealed class FieldInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IFieldInfoProvider _providerInstance = new FieldInfoProviderCore();
		#endregion
		
		/// <summary>private ctor to prevent instances of this class.</summary>
		private FieldInfoProviderSingleton()
		{
		}

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static FieldInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the FieldInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IFieldInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the FieldInfoProvider. Used by singleton wrapper.</summary>
	internal class FieldInfoProviderCore : FieldInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="FieldInfoProviderCore"/> class.</summary>
		internal FieldInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			base.InitClass( (32 + 0));
			InitAddressEntityInfos();
			InitAddressTypeEntityInfos();
			InitAppointmentEntityInfos();
			InitAppointmentStatusEntityInfos();
			InitAppointmentTaskEntityInfos();
			InitAssessmentEntityInfos();
			InitAssessmentClaimEntityInfos();
			InitAssessmentIssueInDisputeEntityInfos();
			InitAssessmentMedRehabEntityInfos();
			InitAssessmentTypeEntityInfos();
			InitAssessmentTypeReportTypeEntityInfos();
			InitCalendarNoteEntityInfos();
			InitClaimEntityInfos();
			InitClaimantEntityInfos();
			InitCompanyEntityInfos();
			InitInvoiceAmountEntityInfos();
			InitIssueInDisputeEntityInfos();
			InitNoteEntityInfos();
			InitReferralSourceEntityInfos();
			InitReferralSourceTypeEntityInfos();
			InitReferralTypeEntityInfos();
			InitReferralTypeIssueInDisputeEntityInfos();
			InitReportStatusEntityInfos();
			InitReportTypeEntityInfos();
			InitRightEntityInfos();
			InitRoleEntityInfos();
			InitRoleRightEntityInfos();
			InitTaskEntityInfos();
			InitTaskStatusEntityInfos();
			InitTaskTemplateEntityInfos();
			InitUserEntityInfos();
			InitUserRoleEntityInfos();

			base.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits AddressEntity's FieldInfo objects</summary>
		private void InitAddressEntityInfos()
		{
			base.AddElementFieldInfo("AddressEntity", "AddressId", typeof(System.Int32), true, false, true, false,  (int)AddressFieldIndex.AddressId, 0, 0, 10);
			base.AddElementFieldInfo("AddressEntity", "Street", typeof(System.String), false, false, false, false,  (int)AddressFieldIndex.Street, 100, 0, 0);
			base.AddElementFieldInfo("AddressEntity", "Suite", typeof(System.String), false, false, false, true,  (int)AddressFieldIndex.Suite, 100, 0, 0);
			base.AddElementFieldInfo("AddressEntity", "City", typeof(System.String), false, false, false, false,  (int)AddressFieldIndex.City, 100, 0, 0);
			base.AddElementFieldInfo("AddressEntity", "Province", typeof(System.String), false, false, false, false,  (int)AddressFieldIndex.Province, 10, 0, 0);
			base.AddElementFieldInfo("AddressEntity", "PostalCode", typeof(System.String), false, false, false, false,  (int)AddressFieldIndex.PostalCode, 10, 0, 0);
			base.AddElementFieldInfo("AddressEntity", "Country", typeof(System.String), false, false, false, false,  (int)AddressFieldIndex.Country, 50, 0, 0);
			base.AddElementFieldInfo("AddressEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)AddressFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("AddressEntity", "AddressTypeId", typeof(System.Int32), false, true, false, false,  (int)AddressFieldIndex.AddressTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AddressEntity", "Name", typeof(System.String), false, false, false, false,  (int)AddressFieldIndex.Name, 100, 0, 0);
		}
		/// <summary>Inits AddressTypeEntity's FieldInfo objects</summary>
		private void InitAddressTypeEntityInfos()
		{
			base.AddElementFieldInfo("AddressTypeEntity", "AddressTypeId", typeof(System.Int32), true, false, true, false,  (int)AddressTypeFieldIndex.AddressTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AddressTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)AddressTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("AddressTypeEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)AddressTypeFieldIndex.IsActive, 0, 0, 0);
		}
		/// <summary>Inits AppointmentEntity's FieldInfo objects</summary>
		private void InitAppointmentEntityInfos()
		{
			base.AddElementFieldInfo("AppointmentEntity", "AppointmentId", typeof(System.Int32), true, false, true, false,  (int)AppointmentFieldIndex.AppointmentId, 0, 0, 10);
			base.AddElementFieldInfo("AppointmentEntity", "LocationId", typeof(System.Int32), false, true, false, false,  (int)AppointmentFieldIndex.LocationId, 0, 0, 10);
			base.AddElementFieldInfo("AppointmentEntity", "AppointmentTime", typeof(System.DateTime), false, false, false, false,  (int)AppointmentFieldIndex.AppointmentTime, 0, 0, 0);
			base.AddElementFieldInfo("AppointmentEntity", "PsychometristId", typeof(System.Int32), false, true, false, false,  (int)AppointmentFieldIndex.PsychometristId, 0, 0, 10);
			base.AddElementFieldInfo("AppointmentEntity", "PsychologistId", typeof(System.Int32), false, true, false, false,  (int)AppointmentFieldIndex.PsychologistId, 0, 0, 10);
			base.AddElementFieldInfo("AppointmentEntity", "AppointmentStatusId", typeof(System.Int32), false, true, false, false,  (int)AppointmentFieldIndex.AppointmentStatusId, 0, 0, 10);
			base.AddElementFieldInfo("AppointmentEntity", "Deleted", typeof(System.Boolean), false, false, false, false,  (int)AppointmentFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("AppointmentEntity", "AssessmentId", typeof(System.Int32), false, true, false, false,  (int)AppointmentFieldIndex.AssessmentId, 0, 0, 10);
			base.AddElementFieldInfo("AppointmentEntity", "PsychometristConfirmed", typeof(System.Boolean), false, false, false, false,  (int)AppointmentFieldIndex.PsychometristConfirmed, 0, 0, 0);
		}
		/// <summary>Inits AppointmentStatusEntity's FieldInfo objects</summary>
		private void InitAppointmentStatusEntityInfos()
		{
			base.AddElementFieldInfo("AppointmentStatusEntity", "AppointmentStatusId", typeof(System.Int32), true, false, true, false,  (int)AppointmentStatusFieldIndex.AppointmentStatusId, 0, 0, 10);
			base.AddElementFieldInfo("AppointmentStatusEntity", "Name", typeof(System.String), false, false, false, false,  (int)AppointmentStatusFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("AppointmentStatusEntity", "Description", typeof(System.String), false, false, false, true,  (int)AppointmentStatusFieldIndex.Description, 100, 0, 0);
			base.AddElementFieldInfo("AppointmentStatusEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)AppointmentStatusFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("AppointmentStatusEntity", "NotifyReferralSource", typeof(System.Boolean), false, false, false, false,  (int)AppointmentStatusFieldIndex.NotifyReferralSource, 0, 0, 0);
		}
		/// <summary>Inits AppointmentTaskEntity's FieldInfo objects</summary>
		private void InitAppointmentTaskEntityInfos()
		{
			base.AddElementFieldInfo("AppointmentTaskEntity", "AppointmentId", typeof(System.Int32), true, true, false, false,  (int)AppointmentTaskFieldIndex.AppointmentId, 0, 0, 10);
			base.AddElementFieldInfo("AppointmentTaskEntity", "TaskId", typeof(System.Int32), true, true, false, false,  (int)AppointmentTaskFieldIndex.TaskId, 0, 0, 10);
		}
		/// <summary>Inits AssessmentEntity's FieldInfo objects</summary>
		private void InitAssessmentEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentEntity", "AssessmentId", typeof(System.Int32), true, false, true, false,  (int)AssessmentFieldIndex.AssessmentId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "ReferralTypeId", typeof(System.Int32), false, true, false, false,  (int)AssessmentFieldIndex.ReferralTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "ReferralSourceId", typeof(System.Int32), false, true, false, false,  (int)AssessmentFieldIndex.ReferralSourceId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "AssessmentTypeId", typeof(System.Int32), false, true, false, false,  (int)AssessmentFieldIndex.AssessmentTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "Deleted", typeof(System.Boolean), false, false, false, false,  (int)AssessmentFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("AssessmentEntity", "CompanyId", typeof(System.Int32), false, true, false, false,  (int)AssessmentFieldIndex.CompanyId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "ReportStatusId", typeof(System.Int32), false, true, false, false,  (int)AssessmentFieldIndex.ReportStatusId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "FileSize", typeof(Nullable<System.Int32>), false, false, false, true,  (int)AssessmentFieldIndex.FileSize, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "ReferralSourceContactEmail", typeof(System.String), false, false, false, true,  (int)AssessmentFieldIndex.ReferralSourceContactEmail, 100, 0, 0);
			base.AddElementFieldInfo("AssessmentEntity", "DocListWriterId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)AssessmentFieldIndex.DocListWriterId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "NotesWriterId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)AssessmentFieldIndex.NotesWriterId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "MedicalFileReceivedDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)AssessmentFieldIndex.MedicalFileReceivedDate, 0, 0, 0);
		}
		/// <summary>Inits AssessmentClaimEntity's FieldInfo objects</summary>
		private void InitAssessmentClaimEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentClaimEntity", "AssessmentId", typeof(System.Int32), true, true, false, false,  (int)AssessmentClaimFieldIndex.AssessmentId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentClaimEntity", "ClaimId", typeof(System.Int32), true, true, false, false,  (int)AssessmentClaimFieldIndex.ClaimId, 0, 0, 10);
		}
		/// <summary>Inits AssessmentIssueInDisputeEntity's FieldInfo objects</summary>
		private void InitAssessmentIssueInDisputeEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentIssueInDisputeEntity", "AssessmentId", typeof(System.Int32), true, true, false, false,  (int)AssessmentIssueInDisputeFieldIndex.AssessmentId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentIssueInDisputeEntity", "IssueIsDisputeId", typeof(System.Int32), true, true, false, false,  (int)AssessmentIssueInDisputeFieldIndex.IssueIsDisputeId, 0, 0, 10);
		}
		/// <summary>Inits AssessmentMedRehabEntity's FieldInfo objects</summary>
		private void InitAssessmentMedRehabEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentMedRehabEntity", "MedRehabId", typeof(System.Int32), true, false, true, false,  (int)AssessmentMedRehabFieldIndex.MedRehabId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentMedRehabEntity", "AssessmentId", typeof(System.Int32), false, true, false, false,  (int)AssessmentMedRehabFieldIndex.AssessmentId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentMedRehabEntity", "Date", typeof(System.DateTime), false, false, false, false,  (int)AssessmentMedRehabFieldIndex.Date, 0, 0, 0);
			base.AddElementFieldInfo("AssessmentMedRehabEntity", "Amount", typeof(System.Decimal), false, false, false, false,  (int)AssessmentMedRehabFieldIndex.Amount, 0, 0, 18);
			base.AddElementFieldInfo("AssessmentMedRehabEntity", "Description", typeof(System.String), false, false, false, false,  (int)AssessmentMedRehabFieldIndex.Description, 100, 0, 0);
			base.AddElementFieldInfo("AssessmentMedRehabEntity", "Deleted", typeof(System.Boolean), false, false, false, false,  (int)AssessmentMedRehabFieldIndex.Deleted, 0, 0, 0);
		}
		/// <summary>Inits AssessmentTypeEntity's FieldInfo objects</summary>
		private void InitAssessmentTypeEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentTypeEntity", "AssessmentTypeId", typeof(System.Int32), true, false, true, false,  (int)AssessmentTypeFieldIndex.AssessmentTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)AssessmentTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("AssessmentTypeEntity", "Description", typeof(System.String), false, false, false, true,  (int)AssessmentTypeFieldIndex.Description, 100, 0, 0);
			base.AddElementFieldInfo("AssessmentTypeEntity", "Duration", typeof(System.Int32), false, false, false, false,  (int)AssessmentTypeFieldIndex.Duration, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentTypeEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)AssessmentTypeFieldIndex.IsActive, 0, 0, 0);
		}
		/// <summary>Inits AssessmentTypeReportTypeEntity's FieldInfo objects</summary>
		private void InitAssessmentTypeReportTypeEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentTypeReportTypeEntity", "AssessmentTypeId", typeof(System.Int32), true, true, false, false,  (int)AssessmentTypeReportTypeFieldIndex.AssessmentTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentTypeReportTypeEntity", "ReportTypeId", typeof(System.Int32), true, true, false, false,  (int)AssessmentTypeReportTypeFieldIndex.ReportTypeId, 0, 0, 10);
		}
		/// <summary>Inits CalendarNoteEntity's FieldInfo objects</summary>
		private void InitCalendarNoteEntityInfos()
		{
			base.AddElementFieldInfo("CalendarNoteEntity", "CalendarNoteId", typeof(System.Int32), true, false, true, false,  (int)CalendarNoteFieldIndex.CalendarNoteId, 0, 0, 10);
			base.AddElementFieldInfo("CalendarNoteEntity", "FromDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)CalendarNoteFieldIndex.FromDate, 0, 0, 0);
			base.AddElementFieldInfo("CalendarNoteEntity", "ToDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)CalendarNoteFieldIndex.ToDate, 0, 0, 0);
			base.AddElementFieldInfo("CalendarNoteEntity", "NoteId", typeof(System.Int32), false, true, false, false,  (int)CalendarNoteFieldIndex.NoteId, 0, 0, 10);
		}
		/// <summary>Inits ClaimEntity's FieldInfo objects</summary>
		private void InitClaimEntityInfos()
		{
			base.AddElementFieldInfo("ClaimEntity", "ClaimId", typeof(System.Int32), true, false, true, false,  (int)ClaimFieldIndex.ClaimId, 0, 0, 10);
			base.AddElementFieldInfo("ClaimEntity", "ClaimantId", typeof(System.Int32), false, true, false, false,  (int)ClaimFieldIndex.ClaimantId, 0, 0, 10);
			base.AddElementFieldInfo("ClaimEntity", "DateOfLoss", typeof(System.DateTime), false, false, false, false,  (int)ClaimFieldIndex.DateOfLoss, 0, 0, 0);
			base.AddElementFieldInfo("ClaimEntity", "ClaimNumber", typeof(System.String), false, false, false, false,  (int)ClaimFieldIndex.ClaimNumber, 50, 0, 0);
			base.AddElementFieldInfo("ClaimEntity", "Deleted", typeof(System.Boolean), false, false, false, false,  (int)ClaimFieldIndex.Deleted, 0, 0, 0);
		}
		/// <summary>Inits ClaimantEntity's FieldInfo objects</summary>
		private void InitClaimantEntityInfos()
		{
			base.AddElementFieldInfo("ClaimantEntity", "ClaimantId", typeof(System.Int32), true, false, true, false,  (int)ClaimantFieldIndex.ClaimantId, 0, 0, 10);
			base.AddElementFieldInfo("ClaimantEntity", "FirstName", typeof(System.String), false, false, false, false,  (int)ClaimantFieldIndex.FirstName, 50, 0, 0);
			base.AddElementFieldInfo("ClaimantEntity", "LastName", typeof(System.String), false, false, false, false,  (int)ClaimantFieldIndex.LastName, 50, 0, 0);
			base.AddElementFieldInfo("ClaimantEntity", "Age", typeof(Nullable<System.Int32>), false, false, false, true,  (int)ClaimantFieldIndex.Age, 0, 0, 10);
			base.AddElementFieldInfo("ClaimantEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)ClaimantFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("ClaimantEntity", "Gender", typeof(System.String), false, false, false, false,  (int)ClaimantFieldIndex.Gender, 1, 0, 0);
			base.AddElementFieldInfo("ClaimantEntity", "DateOfBirth", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ClaimantFieldIndex.DateOfBirth, 0, 0, 0);
		}
		/// <summary>Inits CompanyEntity's FieldInfo objects</summary>
		private void InitCompanyEntityInfos()
		{
			base.AddElementFieldInfo("CompanyEntity", "CompanyId", typeof(System.Int32), true, false, true, false,  (int)CompanyFieldIndex.CompanyId, 0, 0, 10);
			base.AddElementFieldInfo("CompanyEntity", "Name", typeof(System.String), false, false, false, false,  (int)CompanyFieldIndex.Name, 100, 0, 0);
			base.AddElementFieldInfo("CompanyEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)CompanyFieldIndex.IsActive, 0, 0, 0);
		}
		/// <summary>Inits InvoiceAmountEntity's FieldInfo objects</summary>
		private void InitInvoiceAmountEntityInfos()
		{
			base.AddElementFieldInfo("InvoiceAmountEntity", "ReferralSourceId", typeof(System.Int32), true, true, false, false,  (int)InvoiceAmountFieldIndex.ReferralSourceId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceAmountEntity", "ReportTypeId", typeof(System.Int32), true, true, false, false,  (int)InvoiceAmountFieldIndex.ReportTypeId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceAmountEntity", "InvoiceAmount", typeof(System.Decimal), false, false, false, false,  (int)InvoiceAmountFieldIndex.InvoiceAmount, 0, 4, 19);
		}
		/// <summary>Inits IssueInDisputeEntity's FieldInfo objects</summary>
		private void InitIssueInDisputeEntityInfos()
		{
			base.AddElementFieldInfo("IssueInDisputeEntity", "IssueInDisputeId", typeof(System.Int32), true, false, true, false,  (int)IssueInDisputeFieldIndex.IssueInDisputeId, 0, 0, 10);
			base.AddElementFieldInfo("IssueInDisputeEntity", "Name", typeof(System.String), false, false, false, false,  (int)IssueInDisputeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("IssueInDisputeEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)IssueInDisputeFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("IssueInDisputeEntity", "Instructions", typeof(System.String), false, false, false, true,  (int)IssueInDisputeFieldIndex.Instructions, 50, 0, 0);
		}
		/// <summary>Inits NoteEntity's FieldInfo objects</summary>
		private void InitNoteEntityInfos()
		{
			base.AddElementFieldInfo("NoteEntity", "NoteId", typeof(System.Int32), true, false, true, false,  (int)NoteFieldIndex.NoteId, 0, 0, 10);
			base.AddElementFieldInfo("NoteEntity", "Note", typeof(System.String), false, false, false, false,  (int)NoteFieldIndex.Note, 1000, 0, 0);
			base.AddElementFieldInfo("NoteEntity", "UpdateUserId", typeof(System.Int32), false, true, false, false,  (int)NoteFieldIndex.UpdateUserId, 0, 0, 10);
			base.AddElementFieldInfo("NoteEntity", "UpdateDate", typeof(System.DateTime), false, false, false, false,  (int)NoteFieldIndex.UpdateDate, 0, 0, 0);
			base.AddElementFieldInfo("NoteEntity", "CreateUserId", typeof(System.Int32), false, true, false, false,  (int)NoteFieldIndex.CreateUserId, 0, 0, 10);
			base.AddElementFieldInfo("NoteEntity", "CreateDate", typeof(System.DateTime), false, false, false, false,  (int)NoteFieldIndex.CreateDate, 0, 0, 0);
			base.AddElementFieldInfo("NoteEntity", "Deleted", typeof(System.Boolean), false, false, false, false,  (int)NoteFieldIndex.Deleted, 0, 0, 0);
		}
		/// <summary>Inits ReferralSourceEntity's FieldInfo objects</summary>
		private void InitReferralSourceEntityInfos()
		{
			base.AddElementFieldInfo("ReferralSourceEntity", "ReferralSourceId", typeof(System.Int32), true, false, true, false,  (int)ReferralSourceFieldIndex.ReferralSourceId, 0, 0, 10);
			base.AddElementFieldInfo("ReferralSourceEntity", "Name", typeof(System.String), false, false, false, false,  (int)ReferralSourceFieldIndex.Name, 100, 0, 0);
			base.AddElementFieldInfo("ReferralSourceEntity", "ReferralSourceTypeId", typeof(System.Int32), false, true, false, false,  (int)ReferralSourceFieldIndex.ReferralSourceTypeId, 0, 0, 10);
			base.AddElementFieldInfo("ReferralSourceEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)ReferralSourceFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("ReferralSourceEntity", "LargeFileSize", typeof(System.Int32), false, false, false, false,  (int)ReferralSourceFieldIndex.LargeFileSize, 0, 0, 10);
			base.AddElementFieldInfo("ReferralSourceEntity", "LargeFileFeeAmount", typeof(System.Decimal), false, false, false, false,  (int)ReferralSourceFieldIndex.LargeFileFeeAmount, 0, 4, 19);
		}
		/// <summary>Inits ReferralSourceTypeEntity's FieldInfo objects</summary>
		private void InitReferralSourceTypeEntityInfos()
		{
			base.AddElementFieldInfo("ReferralSourceTypeEntity", "ReferralSourceTypeId", typeof(System.Int32), true, false, true, false,  (int)ReferralSourceTypeFieldIndex.ReferralSourceTypeId, 0, 0, 10);
			base.AddElementFieldInfo("ReferralSourceTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)ReferralSourceTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ReferralSourceTypeEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)ReferralSourceTypeFieldIndex.IsActive, 0, 0, 0);
		}
		/// <summary>Inits ReferralTypeEntity's FieldInfo objects</summary>
		private void InitReferralTypeEntityInfos()
		{
			base.AddElementFieldInfo("ReferralTypeEntity", "ReferralTypeId", typeof(System.Int32), true, false, true, false,  (int)ReferralTypeFieldIndex.ReferralTypeId, 0, 0, 10);
			base.AddElementFieldInfo("ReferralTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)ReferralTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ReferralTypeEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)ReferralTypeFieldIndex.IsActive, 0, 0, 0);
		}
		/// <summary>Inits ReferralTypeIssueInDisputeEntity's FieldInfo objects</summary>
		private void InitReferralTypeIssueInDisputeEntityInfos()
		{
			base.AddElementFieldInfo("ReferralTypeIssueInDisputeEntity", "ReferralTypeId", typeof(System.Int32), true, true, false, false,  (int)ReferralTypeIssueInDisputeFieldIndex.ReferralTypeId, 0, 0, 10);
			base.AddElementFieldInfo("ReferralTypeIssueInDisputeEntity", "IssueInDisputeId", typeof(System.Int32), true, true, false, false,  (int)ReferralTypeIssueInDisputeFieldIndex.IssueInDisputeId, 0, 0, 10);
		}
		/// <summary>Inits ReportStatusEntity's FieldInfo objects</summary>
		private void InitReportStatusEntityInfos()
		{
			base.AddElementFieldInfo("ReportStatusEntity", "ReportStatusId", typeof(System.Int32), true, false, true, false,  (int)ReportStatusFieldIndex.ReportStatusId, 0, 0, 10);
			base.AddElementFieldInfo("ReportStatusEntity", "Name", typeof(System.String), false, false, false, false,  (int)ReportStatusFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ReportStatusEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)ReportStatusFieldIndex.IsActive, 0, 0, 0);
		}
		/// <summary>Inits ReportTypeEntity's FieldInfo objects</summary>
		private void InitReportTypeEntityInfos()
		{
			base.AddElementFieldInfo("ReportTypeEntity", "ReportTypeId", typeof(System.Int32), true, false, true, false,  (int)ReportTypeFieldIndex.ReportTypeId, 0, 0, 10);
			base.AddElementFieldInfo("ReportTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)ReportTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ReportTypeEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)ReportTypeFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("ReportTypeEntity", "NumberOfReports", typeof(System.Int32), false, false, false, false,  (int)ReportTypeFieldIndex.NumberOfReports, 0, 0, 10);
		}
		/// <summary>Inits RightEntity's FieldInfo objects</summary>
		private void InitRightEntityInfos()
		{
			base.AddElementFieldInfo("RightEntity", "RightId", typeof(System.Int32), true, false, true, false,  (int)RightFieldIndex.RightId, 0, 0, 10);
			base.AddElementFieldInfo("RightEntity", "Name", typeof(System.String), false, false, false, false,  (int)RightFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("RightEntity", "Description", typeof(System.String), false, false, false, true,  (int)RightFieldIndex.Description, 100, 0, 0);
			base.AddElementFieldInfo("RightEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)RightFieldIndex.IsActive, 0, 0, 0);
		}
		/// <summary>Inits RoleEntity's FieldInfo objects</summary>
		private void InitRoleEntityInfos()
		{
			base.AddElementFieldInfo("RoleEntity", "RoleId", typeof(System.Int32), true, false, true, false,  (int)RoleFieldIndex.RoleId, 0, 0, 10);
			base.AddElementFieldInfo("RoleEntity", "Name", typeof(System.String), false, false, false, false,  (int)RoleFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("RoleEntity", "Description", typeof(System.String), false, false, false, true,  (int)RoleFieldIndex.Description, 100, 0, 0);
			base.AddElementFieldInfo("RoleEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)RoleFieldIndex.IsActive, 0, 0, 0);
		}
		/// <summary>Inits RoleRightEntity's FieldInfo objects</summary>
		private void InitRoleRightEntityInfos()
		{
			base.AddElementFieldInfo("RoleRightEntity", "RoleId", typeof(System.Int32), true, true, false, false,  (int)RoleRightFieldIndex.RoleId, 0, 0, 10);
			base.AddElementFieldInfo("RoleRightEntity", "RightId", typeof(System.Int32), true, true, false, false,  (int)RoleRightFieldIndex.RightId, 0, 0, 10);
		}
		/// <summary>Inits TaskEntity's FieldInfo objects</summary>
		private void InitTaskEntityInfos()
		{
			base.AddElementFieldInfo("TaskEntity", "TaskId", typeof(System.Int32), true, false, true, false,  (int)TaskFieldIndex.TaskId, 0, 0, 10);
			base.AddElementFieldInfo("TaskEntity", "TaskTemplateId", typeof(System.Int32), false, true, false, false,  (int)TaskFieldIndex.TaskTemplateId, 0, 0, 10);
			base.AddElementFieldInfo("TaskEntity", "TaskStatusId", typeof(System.Int32), false, true, false, false,  (int)TaskFieldIndex.TaskStatusId, 0, 0, 10);
		}
		/// <summary>Inits TaskStatusEntity's FieldInfo objects</summary>
		private void InitTaskStatusEntityInfos()
		{
			base.AddElementFieldInfo("TaskStatusEntity", "TaskStatusId", typeof(System.Int32), true, false, true, false,  (int)TaskStatusFieldIndex.TaskStatusId, 0, 0, 10);
			base.AddElementFieldInfo("TaskStatusEntity", "Name", typeof(System.String), false, false, false, false,  (int)TaskStatusFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("TaskStatusEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)TaskStatusFieldIndex.IsActive, 0, 0, 0);
		}
		/// <summary>Inits TaskTemplateEntity's FieldInfo objects</summary>
		private void InitTaskTemplateEntityInfos()
		{
			base.AddElementFieldInfo("TaskTemplateEntity", "TaskTemplateId", typeof(System.Int32), true, false, true, false,  (int)TaskTemplateFieldIndex.TaskTemplateId, 0, 0, 10);
			base.AddElementFieldInfo("TaskTemplateEntity", "Name", typeof(System.String), false, false, false, false,  (int)TaskTemplateFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("TaskTemplateEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)TaskTemplateFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("TaskTemplateEntity", "CompanyId", typeof(System.Int32), false, true, false, false,  (int)TaskTemplateFieldIndex.CompanyId, 0, 0, 10);
		}
		/// <summary>Inits UserEntity's FieldInfo objects</summary>
		private void InitUserEntityInfos()
		{
			base.AddElementFieldInfo("UserEntity", "UserId", typeof(System.Int32), true, false, true, false,  (int)UserFieldIndex.UserId, 0, 0, 10);
			base.AddElementFieldInfo("UserEntity", "FirstName", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.FirstName, 100, 0, 0);
			base.AddElementFieldInfo("UserEntity", "LastName", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.LastName, 100, 0, 0);
			base.AddElementFieldInfo("UserEntity", "Email", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Email, 100, 0, 0);
			base.AddElementFieldInfo("UserEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)UserFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("UserEntity", "CompanyId", typeof(System.Int32), false, true, false, false,  (int)UserFieldIndex.CompanyId, 0, 0, 10);
		}
		/// <summary>Inits UserRoleEntity's FieldInfo objects</summary>
		private void InitUserRoleEntityInfos()
		{
			base.AddElementFieldInfo("UserRoleEntity", "UserId", typeof(System.Int32), true, true, false, false,  (int)UserRoleFieldIndex.UserId, 0, 0, 10);
			base.AddElementFieldInfo("UserRoleEntity", "RoleId", typeof(System.Int32), true, true, false, false,  (int)UserRoleFieldIndex.RoleId, 0, 0, 10);
		}
		
	}
}




