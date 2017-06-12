﻿///////////////////////////////////////////////////////////////
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
			base.InitClass( (51 + 0));
			InitAddressEntityInfos();
			InitAddressTypeEntityInfos();
			InitAppointmentEntityInfos();
			InitAppointmentAttributeEntityInfos();
			InitAppointmentStatusEntityInfos();
			InitAssessmentEntityInfos();
			InitAssessmentAttributeEntityInfos();
			InitAssessmentClaimEntityInfos();
			InitAssessmentColorEntityInfos();
			InitAssessmentMedRehabEntityInfos();
			InitAssessmentNoteEntityInfos();
			InitAssessmentReportEntityInfos();
			InitAssessmentReportIssueInDisputeEntityInfos();
			InitAssessmentTypeEntityInfos();
			InitAssessmentTypeAttributeTypeEntityInfos();
			InitAssessmentTypeReportTypeEntityInfos();
			InitAttributeEntityInfos();
			InitAttributeTypeEntityInfos();
			InitCalendarNoteEntityInfos();
			InitCityEntityInfos();
			InitClaimEntityInfos();
			InitClaimantEntityInfos();
			InitColorEntityInfos();
			InitCompanyEntityInfos();
			InitCompanyAttributeEntityInfos();
			InitInvoiceEntityInfos();
			InitInvoiceAppointmentEntityInfos();
			InitInvoiceDocumentEntityInfos();
			InitInvoiceLineEntityInfos();
			InitInvoiceStatusEntityInfos();
			InitInvoiceStatusChangeEntityInfos();
			InitInvoiceStatusPathsEntityInfos();
			InitInvoiceTypeEntityInfos();
			InitIssueInDisputeEntityInfos();
			InitNoteEntityInfos();
			InitReferralSourceEntityInfos();
			InitReferralSourceAppointmentStatusSettingEntityInfos();
			InitReferralSourceTypeEntityInfos();
			InitReferralTypeEntityInfos();
			InitReferralTypeIssueInDisputeEntityInfos();
			InitReportStatusEntityInfos();
			InitReportTypeEntityInfos();
			InitReportTypeInvoiceAmountEntityInfos();
			InitRightEntityInfos();
			InitRoleEntityInfos();
			InitRoleRightEntityInfos();
			InitUserEntityInfos();
			InitUserNoteEntityInfos();
			InitUserRoleEntityInfos();
			InitUserTravelFeeEntityInfos();
			InitUserUnavailabilityEntityInfos();

			base.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits AddressEntity's FieldInfo objects</summary>
		private void InitAddressEntityInfos()
		{
			base.AddElementFieldInfo("AddressEntity", "AddressId", typeof(System.Int32), true, false, true, false,  (int)AddressFieldIndex.AddressId, 0, 0, 10);
			base.AddElementFieldInfo("AddressEntity", "Name", typeof(System.String), false, false, false, false,  (int)AddressFieldIndex.Name, 100, 0, 0);
			base.AddElementFieldInfo("AddressEntity", "Street", typeof(System.String), false, false, false, false,  (int)AddressFieldIndex.Street, 100, 0, 0);
			base.AddElementFieldInfo("AddressEntity", "Suite", typeof(System.String), false, false, false, true,  (int)AddressFieldIndex.Suite, 100, 0, 0);
			base.AddElementFieldInfo("AddressEntity", "CityId", typeof(System.Int32), false, true, false, false,  (int)AddressFieldIndex.CityId, 0, 0, 10);
			base.AddElementFieldInfo("AddressEntity", "PostalCode", typeof(System.String), false, false, false, false,  (int)AddressFieldIndex.PostalCode, 10, 0, 0);
			base.AddElementFieldInfo("AddressEntity", "AddressTypeId", typeof(System.Int32), false, true, false, false,  (int)AddressFieldIndex.AddressTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AddressEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)AddressFieldIndex.IsActive, 0, 0, 0);
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
			base.AddElementFieldInfo("AppointmentEntity", "AssessmentId", typeof(System.Int32), false, true, false, false,  (int)AppointmentFieldIndex.AssessmentId, 0, 0, 10);
			base.AddElementFieldInfo("AppointmentEntity", "CreateDate", typeof(System.DateTime), false, false, false, false,  (int)AppointmentFieldIndex.CreateDate, 0, 0, 0);
			base.AddElementFieldInfo("AppointmentEntity", "CreateUserId", typeof(System.Int32), false, true, false, false,  (int)AppointmentFieldIndex.CreateUserId, 0, 0, 10);
			base.AddElementFieldInfo("AppointmentEntity", "UpdateDate", typeof(System.DateTime), false, false, false, false,  (int)AppointmentFieldIndex.UpdateDate, 0, 0, 0);
			base.AddElementFieldInfo("AppointmentEntity", "UpdateUserId", typeof(System.Int32), false, true, false, false,  (int)AppointmentFieldIndex.UpdateUserId, 0, 0, 10);
		}
		/// <summary>Inits AppointmentAttributeEntity's FieldInfo objects</summary>
		private void InitAppointmentAttributeEntityInfos()
		{
			base.AddElementFieldInfo("AppointmentAttributeEntity", "AppointmentId", typeof(System.Int32), true, true, false, false,  (int)AppointmentAttributeFieldIndex.AppointmentId, 0, 0, 10);
			base.AddElementFieldInfo("AppointmentAttributeEntity", "AttributeId", typeof(System.Int32), true, true, false, false,  (int)AppointmentAttributeFieldIndex.AttributeId, 0, 0, 10);
		}
		/// <summary>Inits AppointmentStatusEntity's FieldInfo objects</summary>
		private void InitAppointmentStatusEntityInfos()
		{
			base.AddElementFieldInfo("AppointmentStatusEntity", "AppointmentStatusId", typeof(System.Int32), true, false, true, false,  (int)AppointmentStatusFieldIndex.AppointmentStatusId, 0, 0, 10);
			base.AddElementFieldInfo("AppointmentStatusEntity", "Name", typeof(System.String), false, false, false, false,  (int)AppointmentStatusFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("AppointmentStatusEntity", "Description", typeof(System.String), false, false, false, true,  (int)AppointmentStatusFieldIndex.Description, 100, 0, 0);
			base.AddElementFieldInfo("AppointmentStatusEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)AppointmentStatusFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("AppointmentStatusEntity", "NotifyReferralSource", typeof(System.Boolean), false, false, false, false,  (int)AppointmentStatusFieldIndex.NotifyReferralSource, 0, 0, 0);
			base.AddElementFieldInfo("AppointmentStatusEntity", "CanInvoice", typeof(System.Boolean), false, false, false, false,  (int)AppointmentStatusFieldIndex.CanInvoice, 0, 0, 0);
			base.AddElementFieldInfo("AppointmentStatusEntity", "Sort", typeof(System.Int32), false, false, false, false,  (int)AppointmentStatusFieldIndex.Sort, 0, 0, 10);
		}
		/// <summary>Inits AssessmentEntity's FieldInfo objects</summary>
		private void InitAssessmentEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentEntity", "AssessmentId", typeof(System.Int32), true, false, true, false,  (int)AssessmentFieldIndex.AssessmentId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "ReferralTypeId", typeof(System.Int32), false, true, false, false,  (int)AssessmentFieldIndex.ReferralTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "ReferralSourceId", typeof(System.Int32), false, true, false, false,  (int)AssessmentFieldIndex.ReferralSourceId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "AssessmentTypeId", typeof(System.Int32), false, true, false, false,  (int)AssessmentFieldIndex.AssessmentTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "CompanyId", typeof(System.Int32), false, true, false, false,  (int)AssessmentFieldIndex.CompanyId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "ReportStatusId", typeof(System.Int32), false, true, false, false,  (int)AssessmentFieldIndex.ReportStatusId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "FileSize", typeof(Nullable<System.Int32>), false, false, false, true,  (int)AssessmentFieldIndex.FileSize, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "ReferralSourceContactEmail", typeof(System.String), false, false, false, true,  (int)AssessmentFieldIndex.ReferralSourceContactEmail, 100, 0, 0);
			base.AddElementFieldInfo("AssessmentEntity", "DocListWriterId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)AssessmentFieldIndex.DocListWriterId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "NotesWriterId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)AssessmentFieldIndex.NotesWriterId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "MedicalFileReceivedDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)AssessmentFieldIndex.MedicalFileReceivedDate, 0, 0, 0);
			base.AddElementFieldInfo("AssessmentEntity", "IsLargeFile", typeof(System.Boolean), false, false, false, false,  (int)AssessmentFieldIndex.IsLargeFile, 0, 0, 0);
			base.AddElementFieldInfo("AssessmentEntity", "ReferralSourceFileNumber", typeof(System.String), false, false, false, true,  (int)AssessmentFieldIndex.ReferralSourceFileNumber, 50, 0, 0);
			base.AddElementFieldInfo("AssessmentEntity", "CreateDate", typeof(System.DateTime), false, false, false, false,  (int)AssessmentFieldIndex.CreateDate, 0, 0, 0);
			base.AddElementFieldInfo("AssessmentEntity", "CreateUserId", typeof(System.Int32), false, true, false, false,  (int)AssessmentFieldIndex.CreateUserId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "UpdateDate", typeof(System.DateTime), false, false, false, false,  (int)AssessmentFieldIndex.UpdateDate, 0, 0, 0);
			base.AddElementFieldInfo("AssessmentEntity", "UpdateUserId", typeof(System.Int32), false, true, false, false,  (int)AssessmentFieldIndex.UpdateUserId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentEntity", "SummaryNoteId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)AssessmentFieldIndex.SummaryNoteId, 0, 0, 10);
		}
		/// <summary>Inits AssessmentAttributeEntity's FieldInfo objects</summary>
		private void InitAssessmentAttributeEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentAttributeEntity", "AssessmentId", typeof(System.Int32), true, true, false, false,  (int)AssessmentAttributeFieldIndex.AssessmentId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentAttributeEntity", "AttributeId", typeof(System.Int32), true, true, false, false,  (int)AssessmentAttributeFieldIndex.AttributeId, 0, 0, 10);
		}
		/// <summary>Inits AssessmentClaimEntity's FieldInfo objects</summary>
		private void InitAssessmentClaimEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentClaimEntity", "AssessmentId", typeof(System.Int32), true, true, false, false,  (int)AssessmentClaimFieldIndex.AssessmentId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentClaimEntity", "ClaimId", typeof(System.Int32), true, true, false, false,  (int)AssessmentClaimFieldIndex.ClaimId, 0, 0, 10);
		}
		/// <summary>Inits AssessmentColorEntity's FieldInfo objects</summary>
		private void InitAssessmentColorEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentColorEntity", "AssessmentId", typeof(System.Int32), true, true, false, false,  (int)AssessmentColorFieldIndex.AssessmentId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentColorEntity", "ColorId", typeof(System.Int32), true, true, false, false,  (int)AssessmentColorFieldIndex.ColorId, 0, 0, 10);
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
		/// <summary>Inits AssessmentNoteEntity's FieldInfo objects</summary>
		private void InitAssessmentNoteEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentNoteEntity", "AssessmentId", typeof(System.Int32), true, true, false, false,  (int)AssessmentNoteFieldIndex.AssessmentId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentNoteEntity", "NoteId", typeof(System.Int32), true, true, false, false,  (int)AssessmentNoteFieldIndex.NoteId, 0, 0, 10);
		}
		/// <summary>Inits AssessmentReportEntity's FieldInfo objects</summary>
		private void InitAssessmentReportEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentReportEntity", "ReportId", typeof(System.Int32), true, false, true, false,  (int)AssessmentReportFieldIndex.ReportId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentReportEntity", "AssessmentId", typeof(System.Int32), false, true, false, false,  (int)AssessmentReportFieldIndex.AssessmentId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentReportEntity", "ReportTypeId", typeof(System.Int32), false, true, false, false,  (int)AssessmentReportFieldIndex.ReportTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentReportEntity", "IsAdditional", typeof(System.Boolean), false, false, false, false,  (int)AssessmentReportFieldIndex.IsAdditional, 0, 0, 0);
		}
		/// <summary>Inits AssessmentReportIssueInDisputeEntity's FieldInfo objects</summary>
		private void InitAssessmentReportIssueInDisputeEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentReportIssueInDisputeEntity", "ReportId", typeof(System.Int32), true, true, false, false,  (int)AssessmentReportIssueInDisputeFieldIndex.ReportId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentReportIssueInDisputeEntity", "IssueInDisputeId", typeof(System.Int32), true, true, false, false,  (int)AssessmentReportIssueInDisputeFieldIndex.IssueInDisputeId, 0, 0, 10);
		}
		/// <summary>Inits AssessmentTypeEntity's FieldInfo objects</summary>
		private void InitAssessmentTypeEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentTypeEntity", "AssessmentTypeId", typeof(System.Int32), true, false, true, false,  (int)AssessmentTypeFieldIndex.AssessmentTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)AssessmentTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("AssessmentTypeEntity", "Description", typeof(System.String), false, false, false, true,  (int)AssessmentTypeFieldIndex.Description, 100, 0, 0);
			base.AddElementFieldInfo("AssessmentTypeEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)AssessmentTypeFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("AssessmentTypeEntity", "InvoiceAmount", typeof(System.Int32), false, false, false, false,  (int)AssessmentTypeFieldIndex.InvoiceAmount, 0, 0, 10);
		}
		/// <summary>Inits AssessmentTypeAttributeTypeEntity's FieldInfo objects</summary>
		private void InitAssessmentTypeAttributeTypeEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentTypeAttributeTypeEntity", "AssessmentTypeId", typeof(System.Int32), true, true, false, false,  (int)AssessmentTypeAttributeTypeFieldIndex.AssessmentTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentTypeAttributeTypeEntity", "AttributeTypeId", typeof(System.Int32), true, true, false, false,  (int)AssessmentTypeAttributeTypeFieldIndex.AttributeTypeId, 0, 0, 10);
		}
		/// <summary>Inits AssessmentTypeReportTypeEntity's FieldInfo objects</summary>
		private void InitAssessmentTypeReportTypeEntityInfos()
		{
			base.AddElementFieldInfo("AssessmentTypeReportTypeEntity", "AssessmentTypeId", typeof(System.Int32), true, true, false, false,  (int)AssessmentTypeReportTypeFieldIndex.AssessmentTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AssessmentTypeReportTypeEntity", "ReportTypeId", typeof(System.Int32), true, true, false, false,  (int)AssessmentTypeReportTypeFieldIndex.ReportTypeId, 0, 0, 10);
		}
		/// <summary>Inits AttributeEntity's FieldInfo objects</summary>
		private void InitAttributeEntityInfos()
		{
			base.AddElementFieldInfo("AttributeEntity", "AttributeId", typeof(System.Int32), true, false, true, false,  (int)AttributeFieldIndex.AttributeId, 0, 0, 10);
			base.AddElementFieldInfo("AttributeEntity", "Name", typeof(System.String), false, false, false, false,  (int)AttributeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("AttributeEntity", "AttributeTypeId", typeof(System.Int32), false, true, false, false,  (int)AttributeFieldIndex.AttributeTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AttributeEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)AttributeFieldIndex.IsActive, 0, 0, 0);
		}
		/// <summary>Inits AttributeTypeEntity's FieldInfo objects</summary>
		private void InitAttributeTypeEntityInfos()
		{
			base.AddElementFieldInfo("AttributeTypeEntity", "AttributeTypeId", typeof(System.Int32), true, false, true, false,  (int)AttributeTypeFieldIndex.AttributeTypeId, 0, 0, 10);
			base.AddElementFieldInfo("AttributeTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)AttributeTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("AttributeTypeEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)AttributeTypeFieldIndex.IsActive, 0, 0, 0);
		}
		/// <summary>Inits CalendarNoteEntity's FieldInfo objects</summary>
		private void InitCalendarNoteEntityInfos()
		{
			base.AddElementFieldInfo("CalendarNoteEntity", "CalendarNoteId", typeof(System.Int32), true, false, true, false,  (int)CalendarNoteFieldIndex.CalendarNoteId, 0, 0, 10);
			base.AddElementFieldInfo("CalendarNoteEntity", "FromDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)CalendarNoteFieldIndex.FromDate, 0, 0, 0);
			base.AddElementFieldInfo("CalendarNoteEntity", "ToDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)CalendarNoteFieldIndex.ToDate, 0, 0, 0);
			base.AddElementFieldInfo("CalendarNoteEntity", "NoteId", typeof(System.Int32), false, true, false, false,  (int)CalendarNoteFieldIndex.NoteId, 0, 0, 10);
		}
		/// <summary>Inits CityEntity's FieldInfo objects</summary>
		private void InitCityEntityInfos()
		{
			base.AddElementFieldInfo("CityEntity", "CityId", typeof(System.Int32), true, false, true, false,  (int)CityFieldIndex.CityId, 0, 0, 10);
			base.AddElementFieldInfo("CityEntity", "Name", typeof(System.String), false, false, false, false,  (int)CityFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("CityEntity", "Province", typeof(System.String), false, false, false, false,  (int)CityFieldIndex.Province, 10, 0, 0);
			base.AddElementFieldInfo("CityEntity", "Country", typeof(System.String), false, false, false, false,  (int)CityFieldIndex.Country, 50, 0, 0);
			base.AddElementFieldInfo("CityEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)CityFieldIndex.IsActive, 0, 0, 0);
		}
		/// <summary>Inits ClaimEntity's FieldInfo objects</summary>
		private void InitClaimEntityInfos()
		{
			base.AddElementFieldInfo("ClaimEntity", "ClaimId", typeof(System.Int32), true, false, true, false,  (int)ClaimFieldIndex.ClaimId, 0, 0, 10);
			base.AddElementFieldInfo("ClaimEntity", "ClaimantId", typeof(System.Int32), false, true, false, false,  (int)ClaimFieldIndex.ClaimantId, 0, 0, 10);
			base.AddElementFieldInfo("ClaimEntity", "DateOfLoss", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ClaimFieldIndex.DateOfLoss, 0, 0, 0);
			base.AddElementFieldInfo("ClaimEntity", "ClaimNumber", typeof(System.String), false, false, false, true,  (int)ClaimFieldIndex.ClaimNumber, 50, 0, 0);
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
		/// <summary>Inits ColorEntity's FieldInfo objects</summary>
		private void InitColorEntityInfos()
		{
			base.AddElementFieldInfo("ColorEntity", "ColorId", typeof(System.Int32), true, false, true, false,  (int)ColorFieldIndex.ColorId, 0, 0, 10);
			base.AddElementFieldInfo("ColorEntity", "Name", typeof(System.String), false, false, false, false,  (int)ColorFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ColorEntity", "HexCode", typeof(System.String), false, false, false, false,  (int)ColorFieldIndex.HexCode, 50, 0, 0);
			base.AddElementFieldInfo("ColorEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)ColorFieldIndex.IsActive, 0, 0, 0);
		}
		/// <summary>Inits CompanyEntity's FieldInfo objects</summary>
		private void InitCompanyEntityInfos()
		{
			base.AddElementFieldInfo("CompanyEntity", "CompanyId", typeof(System.Int32), true, false, true, false,  (int)CompanyFieldIndex.CompanyId, 0, 0, 10);
			base.AddElementFieldInfo("CompanyEntity", "Name", typeof(System.String), false, false, false, false,  (int)CompanyFieldIndex.Name, 100, 0, 0);
			base.AddElementFieldInfo("CompanyEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)CompanyFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("CompanyEntity", "AddressId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)CompanyFieldIndex.AddressId, 0, 0, 10);
			base.AddElementFieldInfo("CompanyEntity", "Phone", typeof(System.String), false, false, false, true,  (int)CompanyFieldIndex.Phone, 50, 0, 0);
			base.AddElementFieldInfo("CompanyEntity", "Fax", typeof(System.String), false, false, false, true,  (int)CompanyFieldIndex.Fax, 50, 0, 0);
			base.AddElementFieldInfo("CompanyEntity", "Email", typeof(System.String), false, false, false, true,  (int)CompanyFieldIndex.Email, 100, 0, 0);
			base.AddElementFieldInfo("CompanyEntity", "TaxId", typeof(System.String), false, false, false, true,  (int)CompanyFieldIndex.TaxId, 50, 0, 0);
			base.AddElementFieldInfo("CompanyEntity", "NewAppointmentTime", typeof(Nullable<System.Int64>), false, false, false, true,  (int)CompanyFieldIndex.NewAppointmentTime, 0, 0, 19);
			base.AddElementFieldInfo("CompanyEntity", "NewAppointmentLocationId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)CompanyFieldIndex.NewAppointmentLocationId, 0, 0, 10);
			base.AddElementFieldInfo("CompanyEntity", "NewAppointmentPsychologistId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)CompanyFieldIndex.NewAppointmentPsychologistId, 0, 0, 10);
			base.AddElementFieldInfo("CompanyEntity", "NewAppointmentPsychometristId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)CompanyFieldIndex.NewAppointmentPsychometristId, 0, 0, 10);
			base.AddElementFieldInfo("CompanyEntity", "NewAppointmentStatusId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)CompanyFieldIndex.NewAppointmentStatusId, 0, 0, 10);
			base.AddElementFieldInfo("CompanyEntity", "NewAssessmentReportStatusId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)CompanyFieldIndex.NewAssessmentReportStatusId, 0, 0, 10);
			base.AddElementFieldInfo("CompanyEntity", "NewAssessmentSummaryNoteText", typeof(System.String), false, false, false, true,  (int)CompanyFieldIndex.NewAssessmentSummaryNoteText, 2147483647, 0, 0);
		}
		/// <summary>Inits CompanyAttributeEntity's FieldInfo objects</summary>
		private void InitCompanyAttributeEntityInfos()
		{
			base.AddElementFieldInfo("CompanyAttributeEntity", "CompanyId", typeof(System.Int32), true, true, false, false,  (int)CompanyAttributeFieldIndex.CompanyId, 0, 0, 10);
			base.AddElementFieldInfo("CompanyAttributeEntity", "AttributeId", typeof(System.Int32), true, true, false, false,  (int)CompanyAttributeFieldIndex.AttributeId, 0, 0, 10);
		}
		/// <summary>Inits InvoiceEntity's FieldInfo objects</summary>
		private void InitInvoiceEntityInfos()
		{
			base.AddElementFieldInfo("InvoiceEntity", "InvoiceId", typeof(System.Int32), true, false, true, false,  (int)InvoiceFieldIndex.InvoiceId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceEntity", "Identifier", typeof(System.String), false, false, false, false,  (int)InvoiceFieldIndex.Identifier, 20, 0, 0);
			base.AddElementFieldInfo("InvoiceEntity", "InvoiceDate", typeof(System.DateTime), false, false, false, false,  (int)InvoiceFieldIndex.InvoiceDate, 0, 0, 0);
			base.AddElementFieldInfo("InvoiceEntity", "InvoiceStatusId", typeof(System.Int32), false, true, false, false,  (int)InvoiceFieldIndex.InvoiceStatusId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceEntity", "UpdateDate", typeof(System.DateTime), false, false, false, false,  (int)InvoiceFieldIndex.UpdateDate, 0, 0, 0);
			base.AddElementFieldInfo("InvoiceEntity", "TaxRate", typeof(System.Decimal), false, false, false, false,  (int)InvoiceFieldIndex.TaxRate, 0, 4, 18);
			base.AddElementFieldInfo("InvoiceEntity", "Total", typeof(System.Decimal), false, false, false, false,  (int)InvoiceFieldIndex.Total, 0, 4, 18);
			base.AddElementFieldInfo("InvoiceEntity", "InvoiceTypeId", typeof(System.Int32), false, true, false, false,  (int)InvoiceFieldIndex.InvoiceTypeId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceEntity", "PayableToId", typeof(System.Int32), false, true, false, false,  (int)InvoiceFieldIndex.PayableToId, 0, 0, 10);
		}
		/// <summary>Inits InvoiceAppointmentEntity's FieldInfo objects</summary>
		private void InitInvoiceAppointmentEntityInfos()
		{
			base.AddElementFieldInfo("InvoiceAppointmentEntity", "InvoiceAppointmentId", typeof(System.Int32), true, false, true, false,  (int)InvoiceAppointmentFieldIndex.InvoiceAppointmentId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceAppointmentEntity", "InvoiceId", typeof(System.Int32), false, true, false, false,  (int)InvoiceAppointmentFieldIndex.InvoiceId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceAppointmentEntity", "AppointmentId", typeof(System.Int32), false, true, false, false,  (int)InvoiceAppointmentFieldIndex.AppointmentId, 0, 0, 10);
		}
		/// <summary>Inits InvoiceDocumentEntity's FieldInfo objects</summary>
		private void InitInvoiceDocumentEntityInfos()
		{
			base.AddElementFieldInfo("InvoiceDocumentEntity", "InvoiceDocumentId", typeof(System.Int32), true, false, true, false,  (int)InvoiceDocumentFieldIndex.InvoiceDocumentId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceDocumentEntity", "InvoiceId", typeof(System.Int32), false, true, false, false,  (int)InvoiceDocumentFieldIndex.InvoiceId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceDocumentEntity", "Document", typeof(System.Byte[]), false, false, false, false,  (int)InvoiceDocumentFieldIndex.Document, 2147483647, 0, 0);
			base.AddElementFieldInfo("InvoiceDocumentEntity", "CreateDate", typeof(System.DateTime), false, false, false, false,  (int)InvoiceDocumentFieldIndex.CreateDate, 0, 0, 0);
			base.AddElementFieldInfo("InvoiceDocumentEntity", "FileName", typeof(System.String), false, false, false, false,  (int)InvoiceDocumentFieldIndex.FileName, 50, 0, 0);
		}
		/// <summary>Inits InvoiceLineEntity's FieldInfo objects</summary>
		private void InitInvoiceLineEntityInfos()
		{
			base.AddElementFieldInfo("InvoiceLineEntity", "InvoiceLineId", typeof(System.Int32), true, false, true, false,  (int)InvoiceLineFieldIndex.InvoiceLineId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceLineEntity", "InvoiceAppointmentId", typeof(System.Int32), false, true, false, false,  (int)InvoiceLineFieldIndex.InvoiceAppointmentId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceLineEntity", "Description", typeof(System.String), false, false, false, false,  (int)InvoiceLineFieldIndex.Description, 100, 0, 0);
			base.AddElementFieldInfo("InvoiceLineEntity", "Amount", typeof(System.Decimal), false, false, false, false,  (int)InvoiceLineFieldIndex.Amount, 0, 4, 18);
			base.AddElementFieldInfo("InvoiceLineEntity", "IsCustom", typeof(System.Boolean), false, false, false, false,  (int)InvoiceLineFieldIndex.IsCustom, 0, 0, 0);
		}
		/// <summary>Inits InvoiceStatusEntity's FieldInfo objects</summary>
		private void InitInvoiceStatusEntityInfos()
		{
			base.AddElementFieldInfo("InvoiceStatusEntity", "InvoiceStatusId", typeof(System.Int32), true, false, true, false,  (int)InvoiceStatusFieldIndex.InvoiceStatusId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceStatusEntity", "Name", typeof(System.String), false, false, false, false,  (int)InvoiceStatusFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("InvoiceStatusEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)InvoiceStatusFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("InvoiceStatusEntity", "CanEdit", typeof(System.Boolean), false, false, false, false,  (int)InvoiceStatusFieldIndex.CanEdit, 0, 0, 0);
			base.AddElementFieldInfo("InvoiceStatusEntity", "SaveDocument", typeof(System.Boolean), false, false, false, false,  (int)InvoiceStatusFieldIndex.SaveDocument, 0, 0, 0);
			base.AddElementFieldInfo("InvoiceStatusEntity", "ActionName", typeof(System.String), false, false, false, false,  (int)InvoiceStatusFieldIndex.ActionName, 50, 0, 0);
		}
		/// <summary>Inits InvoiceStatusChangeEntity's FieldInfo objects</summary>
		private void InitInvoiceStatusChangeEntityInfos()
		{
			base.AddElementFieldInfo("InvoiceStatusChangeEntity", "InvoiceStatusChangeId", typeof(System.Int32), true, false, true, false,  (int)InvoiceStatusChangeFieldIndex.InvoiceStatusChangeId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceStatusChangeEntity", "InvoiceId", typeof(System.Int32), false, true, false, false,  (int)InvoiceStatusChangeFieldIndex.InvoiceId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceStatusChangeEntity", "InvoiceStatusId", typeof(System.Int32), false, true, false, false,  (int)InvoiceStatusChangeFieldIndex.InvoiceStatusId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceStatusChangeEntity", "UpdateDate", typeof(System.DateTime), false, false, false, false,  (int)InvoiceStatusChangeFieldIndex.UpdateDate, 0, 0, 0);
		}
		/// <summary>Inits InvoiceStatusPathsEntity's FieldInfo objects</summary>
		private void InitInvoiceStatusPathsEntityInfos()
		{
			base.AddElementFieldInfo("InvoiceStatusPathsEntity", "InvoiceStatusPathId", typeof(System.Int32), true, false, true, false,  (int)InvoiceStatusPathsFieldIndex.InvoiceStatusPathId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceStatusPathsEntity", "InvoiceStatusId", typeof(System.Int32), false, true, false, false,  (int)InvoiceStatusPathsFieldIndex.InvoiceStatusId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceStatusPathsEntity", "NextInvoiceStatusId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)InvoiceStatusPathsFieldIndex.NextInvoiceStatusId, 0, 0, 10);
		}
		/// <summary>Inits InvoiceTypeEntity's FieldInfo objects</summary>
		private void InitInvoiceTypeEntityInfos()
		{
			base.AddElementFieldInfo("InvoiceTypeEntity", "InvoiceTypeId", typeof(System.Int32), true, false, true, false,  (int)InvoiceTypeFieldIndex.InvoiceTypeId, 0, 0, 10);
			base.AddElementFieldInfo("InvoiceTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)InvoiceTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("InvoiceTypeEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)InvoiceTypeFieldIndex.IsActive, 0, 0, 0);
		}
		/// <summary>Inits IssueInDisputeEntity's FieldInfo objects</summary>
		private void InitIssueInDisputeEntityInfos()
		{
			base.AddElementFieldInfo("IssueInDisputeEntity", "IssueInDisputeId", typeof(System.Int32), true, false, true, false,  (int)IssueInDisputeFieldIndex.IssueInDisputeId, 0, 0, 10);
			base.AddElementFieldInfo("IssueInDisputeEntity", "Name", typeof(System.String), false, false, false, false,  (int)IssueInDisputeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("IssueInDisputeEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)IssueInDisputeFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("IssueInDisputeEntity", "AdditionalFee", typeof(System.Decimal), false, false, false, false,  (int)IssueInDisputeFieldIndex.AdditionalFee, 0, 4, 18);
		}
		/// <summary>Inits NoteEntity's FieldInfo objects</summary>
		private void InitNoteEntityInfos()
		{
			base.AddElementFieldInfo("NoteEntity", "NoteId", typeof(System.Int32), true, false, true, false,  (int)NoteFieldIndex.NoteId, 0, 0, 10);
			base.AddElementFieldInfo("NoteEntity", "Note", typeof(System.String), false, false, false, false,  (int)NoteFieldIndex.Note, 2147483647, 0, 0);
			base.AddElementFieldInfo("NoteEntity", "UpdateUserId", typeof(System.Int32), false, true, false, false,  (int)NoteFieldIndex.UpdateUserId, 0, 0, 10);
			base.AddElementFieldInfo("NoteEntity", "UpdateDate", typeof(System.DateTime), false, false, false, false,  (int)NoteFieldIndex.UpdateDate, 0, 0, 0);
			base.AddElementFieldInfo("NoteEntity", "CreateUserId", typeof(System.Int32), false, true, false, false,  (int)NoteFieldIndex.CreateUserId, 0, 0, 10);
			base.AddElementFieldInfo("NoteEntity", "CreateDate", typeof(System.DateTime), false, false, false, false,  (int)NoteFieldIndex.CreateDate, 0, 0, 0);
		}
		/// <summary>Inits ReferralSourceEntity's FieldInfo objects</summary>
		private void InitReferralSourceEntityInfos()
		{
			base.AddElementFieldInfo("ReferralSourceEntity", "ReferralSourceId", typeof(System.Int32), true, false, true, false,  (int)ReferralSourceFieldIndex.ReferralSourceId, 0, 0, 10);
			base.AddElementFieldInfo("ReferralSourceEntity", "Name", typeof(System.String), false, false, false, false,  (int)ReferralSourceFieldIndex.Name, 100, 0, 0);
			base.AddElementFieldInfo("ReferralSourceEntity", "ReferralSourceTypeId", typeof(System.Int32), false, true, false, false,  (int)ReferralSourceFieldIndex.ReferralSourceTypeId, 0, 0, 10);
			base.AddElementFieldInfo("ReferralSourceEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)ReferralSourceFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("ReferralSourceEntity", "LargeFileSize", typeof(System.Int32), false, false, false, false,  (int)ReferralSourceFieldIndex.LargeFileSize, 0, 0, 10);
			base.AddElementFieldInfo("ReferralSourceEntity", "LargeFileFeeAmount", typeof(System.Int32), false, false, false, false,  (int)ReferralSourceFieldIndex.LargeFileFeeAmount, 0, 0, 10);
			base.AddElementFieldInfo("ReferralSourceEntity", "AddressId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)ReferralSourceFieldIndex.AddressId, 0, 0, 10);
		}
		/// <summary>Inits ReferralSourceAppointmentStatusSettingEntity's FieldInfo objects</summary>
		private void InitReferralSourceAppointmentStatusSettingEntityInfos()
		{
			base.AddElementFieldInfo("ReferralSourceAppointmentStatusSettingEntity", "ReferralSourceId", typeof(System.Int32), true, true, false, false,  (int)ReferralSourceAppointmentStatusSettingFieldIndex.ReferralSourceId, 0, 0, 10);
			base.AddElementFieldInfo("ReferralSourceAppointmentStatusSettingEntity", "AppointmentStatusId", typeof(System.Int32), true, true, false, false,  (int)ReferralSourceAppointmentStatusSettingFieldIndex.AppointmentStatusId, 0, 0, 10);
			base.AddElementFieldInfo("ReferralSourceAppointmentStatusSettingEntity", "InvoiceTypeId", typeof(System.Int32), true, true, false, false,  (int)ReferralSourceAppointmentStatusSettingFieldIndex.InvoiceTypeId, 0, 0, 10);
			base.AddElementFieldInfo("ReferralSourceAppointmentStatusSettingEntity", "InvoiceRate", typeof(System.Decimal), false, false, false, false,  (int)ReferralSourceAppointmentStatusSettingFieldIndex.InvoiceRate, 0, 4, 18);
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
		}
		/// <summary>Inits ReportTypeInvoiceAmountEntity's FieldInfo objects</summary>
		private void InitReportTypeInvoiceAmountEntityInfos()
		{
			base.AddElementFieldInfo("ReportTypeInvoiceAmountEntity", "ReferralSourceId", typeof(System.Int32), true, true, false, false,  (int)ReportTypeInvoiceAmountFieldIndex.ReferralSourceId, 0, 0, 10);
			base.AddElementFieldInfo("ReportTypeInvoiceAmountEntity", "ReportTypeId", typeof(System.Int32), true, true, false, false,  (int)ReportTypeInvoiceAmountFieldIndex.ReportTypeId, 0, 0, 10);
			base.AddElementFieldInfo("ReportTypeInvoiceAmountEntity", "InvoiceAmount", typeof(System.Int32), false, false, false, false,  (int)ReportTypeInvoiceAmountFieldIndex.InvoiceAmount, 0, 0, 10);
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
		/// <summary>Inits UserEntity's FieldInfo objects</summary>
		private void InitUserEntityInfos()
		{
			base.AddElementFieldInfo("UserEntity", "UserId", typeof(System.Int32), true, false, true, false,  (int)UserFieldIndex.UserId, 0, 0, 10);
			base.AddElementFieldInfo("UserEntity", "FirstName", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.FirstName, 100, 0, 0);
			base.AddElementFieldInfo("UserEntity", "LastName", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.LastName, 100, 0, 0);
			base.AddElementFieldInfo("UserEntity", "Email", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Email, 100, 0, 0);
			base.AddElementFieldInfo("UserEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)UserFieldIndex.IsActive, 0, 0, 0);
			base.AddElementFieldInfo("UserEntity", "CompanyId", typeof(System.Int32), false, true, false, false,  (int)UserFieldIndex.CompanyId, 0, 0, 10);
			base.AddElementFieldInfo("UserEntity", "AddressId", typeof(System.Int32), false, true, false, false,  (int)UserFieldIndex.AddressId, 0, 0, 10);
		}
		/// <summary>Inits UserNoteEntity's FieldInfo objects</summary>
		private void InitUserNoteEntityInfos()
		{
			base.AddElementFieldInfo("UserNoteEntity", "NoteId", typeof(System.Int32), true, true, false, false,  (int)UserNoteFieldIndex.NoteId, 0, 0, 10);
			base.AddElementFieldInfo("UserNoteEntity", "UserId", typeof(System.Int32), true, true, false, false,  (int)UserNoteFieldIndex.UserId, 0, 0, 10);
		}
		/// <summary>Inits UserRoleEntity's FieldInfo objects</summary>
		private void InitUserRoleEntityInfos()
		{
			base.AddElementFieldInfo("UserRoleEntity", "UserId", typeof(System.Int32), true, true, false, false,  (int)UserRoleFieldIndex.UserId, 0, 0, 10);
			base.AddElementFieldInfo("UserRoleEntity", "RoleId", typeof(System.Int32), true, true, false, false,  (int)UserRoleFieldIndex.RoleId, 0, 0, 10);
		}
		/// <summary>Inits UserTravelFeeEntity's FieldInfo objects</summary>
		private void InitUserTravelFeeEntityInfos()
		{
			base.AddElementFieldInfo("UserTravelFeeEntity", "UserId", typeof(System.Int32), true, true, false, false,  (int)UserTravelFeeFieldIndex.UserId, 0, 0, 10);
			base.AddElementFieldInfo("UserTravelFeeEntity", "CityId", typeof(System.Int32), true, true, false, false,  (int)UserTravelFeeFieldIndex.CityId, 0, 0, 10);
			base.AddElementFieldInfo("UserTravelFeeEntity", "Amount", typeof(System.Int32), false, false, false, false,  (int)UserTravelFeeFieldIndex.Amount, 0, 0, 10);
		}
		/// <summary>Inits UserUnavailabilityEntity's FieldInfo objects</summary>
		private void InitUserUnavailabilityEntityInfos()
		{
			base.AddElementFieldInfo("UserUnavailabilityEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)UserUnavailabilityFieldIndex.Id, 0, 0, 10);
			base.AddElementFieldInfo("UserUnavailabilityEntity", "UserId", typeof(System.Int32), false, true, false, false,  (int)UserUnavailabilityFieldIndex.UserId, 0, 0, 10);
			base.AddElementFieldInfo("UserUnavailabilityEntity", "StartDate", typeof(System.DateTime), false, false, false, false,  (int)UserUnavailabilityFieldIndex.StartDate, 0, 0, 0);
			base.AddElementFieldInfo("UserUnavailabilityEntity", "EndDate", typeof(System.DateTime), false, false, false, false,  (int)UserUnavailabilityFieldIndex.EndDate, 0, 0, 0);
		}
		
	}
}




