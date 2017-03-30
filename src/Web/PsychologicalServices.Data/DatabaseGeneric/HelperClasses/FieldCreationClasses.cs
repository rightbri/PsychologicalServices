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
using PsychologicalServices.Data.FactoryClasses;
using PsychologicalServices.Data;

namespace PsychologicalServices.Data.HelperClasses
{
	/// <summary>Field Creation Class for entity AddressEntity</summary>
	public partial class AddressFields
	{
		/// <summary>Creates a new AddressEntity.AddressId field instance</summary>
		public static EntityField2 AddressId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AddressFieldIndex.AddressId);}
		}
		/// <summary>Creates a new AddressEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(AddressFieldIndex.Name);}
		}
		/// <summary>Creates a new AddressEntity.Street field instance</summary>
		public static EntityField2 Street
		{
			get { return (EntityField2)EntityFieldFactory.Create(AddressFieldIndex.Street);}
		}
		/// <summary>Creates a new AddressEntity.Suite field instance</summary>
		public static EntityField2 Suite
		{
			get { return (EntityField2)EntityFieldFactory.Create(AddressFieldIndex.Suite);}
		}
		/// <summary>Creates a new AddressEntity.CityId field instance</summary>
		public static EntityField2 CityId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AddressFieldIndex.CityId);}
		}
		/// <summary>Creates a new AddressEntity.PostalCode field instance</summary>
		public static EntityField2 PostalCode
		{
			get { return (EntityField2)EntityFieldFactory.Create(AddressFieldIndex.PostalCode);}
		}
		/// <summary>Creates a new AddressEntity.AddressTypeId field instance</summary>
		public static EntityField2 AddressTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AddressFieldIndex.AddressTypeId);}
		}
		/// <summary>Creates a new AddressEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(AddressFieldIndex.IsActive);}
		}
	}

	/// <summary>Field Creation Class for entity AddressTypeEntity</summary>
	public partial class AddressTypeFields
	{
		/// <summary>Creates a new AddressTypeEntity.AddressTypeId field instance</summary>
		public static EntityField2 AddressTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AddressTypeFieldIndex.AddressTypeId);}
		}
		/// <summary>Creates a new AddressTypeEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(AddressTypeFieldIndex.Name);}
		}
		/// <summary>Creates a new AddressTypeEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(AddressTypeFieldIndex.IsActive);}
		}
	}

	/// <summary>Field Creation Class for entity AppointmentEntity</summary>
	public partial class AppointmentFields
	{
		/// <summary>Creates a new AppointmentEntity.AppointmentId field instance</summary>
		public static EntityField2 AppointmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentFieldIndex.AppointmentId);}
		}
		/// <summary>Creates a new AppointmentEntity.LocationId field instance</summary>
		public static EntityField2 LocationId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentFieldIndex.LocationId);}
		}
		/// <summary>Creates a new AppointmentEntity.AppointmentTime field instance</summary>
		public static EntityField2 AppointmentTime
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentFieldIndex.AppointmentTime);}
		}
		/// <summary>Creates a new AppointmentEntity.PsychometristId field instance</summary>
		public static EntityField2 PsychometristId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentFieldIndex.PsychometristId);}
		}
		/// <summary>Creates a new AppointmentEntity.PsychologistId field instance</summary>
		public static EntityField2 PsychologistId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentFieldIndex.PsychologistId);}
		}
		/// <summary>Creates a new AppointmentEntity.AppointmentStatusId field instance</summary>
		public static EntityField2 AppointmentStatusId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentFieldIndex.AppointmentStatusId);}
		}
		/// <summary>Creates a new AppointmentEntity.Deleted field instance</summary>
		public static EntityField2 Deleted
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentFieldIndex.Deleted);}
		}
		/// <summary>Creates a new AppointmentEntity.AssessmentId field instance</summary>
		public static EntityField2 AssessmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentFieldIndex.AssessmentId);}
		}
	}

	/// <summary>Field Creation Class for entity AppointmentAttributeEntity</summary>
	public partial class AppointmentAttributeFields
	{
		/// <summary>Creates a new AppointmentAttributeEntity.AppointmentId field instance</summary>
		public static EntityField2 AppointmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentAttributeFieldIndex.AppointmentId);}
		}
		/// <summary>Creates a new AppointmentAttributeEntity.AttributeId field instance</summary>
		public static EntityField2 AttributeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentAttributeFieldIndex.AttributeId);}
		}
	}

	/// <summary>Field Creation Class for entity AppointmentStatusEntity</summary>
	public partial class AppointmentStatusFields
	{
		/// <summary>Creates a new AppointmentStatusEntity.AppointmentStatusId field instance</summary>
		public static EntityField2 AppointmentStatusId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentStatusFieldIndex.AppointmentStatusId);}
		}
		/// <summary>Creates a new AppointmentStatusEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentStatusFieldIndex.Name);}
		}
		/// <summary>Creates a new AppointmentStatusEntity.Description field instance</summary>
		public static EntityField2 Description
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentStatusFieldIndex.Description);}
		}
		/// <summary>Creates a new AppointmentStatusEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentStatusFieldIndex.IsActive);}
		}
		/// <summary>Creates a new AppointmentStatusEntity.NotifyReferralSource field instance</summary>
		public static EntityField2 NotifyReferralSource
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentStatusFieldIndex.NotifyReferralSource);}
		}
	}

	/// <summary>Field Creation Class for entity AssessmentEntity</summary>
	public partial class AssessmentFields
	{
		/// <summary>Creates a new AssessmentEntity.AssessmentId field instance</summary>
		public static EntityField2 AssessmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.AssessmentId);}
		}
		/// <summary>Creates a new AssessmentEntity.ReferralTypeId field instance</summary>
		public static EntityField2 ReferralTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.ReferralTypeId);}
		}
		/// <summary>Creates a new AssessmentEntity.ReferralSourceId field instance</summary>
		public static EntityField2 ReferralSourceId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.ReferralSourceId);}
		}
		/// <summary>Creates a new AssessmentEntity.AssessmentTypeId field instance</summary>
		public static EntityField2 AssessmentTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.AssessmentTypeId);}
		}
		/// <summary>Creates a new AssessmentEntity.Deleted field instance</summary>
		public static EntityField2 Deleted
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.Deleted);}
		}
		/// <summary>Creates a new AssessmentEntity.CompanyId field instance</summary>
		public static EntityField2 CompanyId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.CompanyId);}
		}
		/// <summary>Creates a new AssessmentEntity.ReportStatusId field instance</summary>
		public static EntityField2 ReportStatusId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.ReportStatusId);}
		}
		/// <summary>Creates a new AssessmentEntity.FileSize field instance</summary>
		public static EntityField2 FileSize
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.FileSize);}
		}
		/// <summary>Creates a new AssessmentEntity.ReferralSourceContactEmail field instance</summary>
		public static EntityField2 ReferralSourceContactEmail
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.ReferralSourceContactEmail);}
		}
		/// <summary>Creates a new AssessmentEntity.DocListWriterId field instance</summary>
		public static EntityField2 DocListWriterId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.DocListWriterId);}
		}
		/// <summary>Creates a new AssessmentEntity.NotesWriterId field instance</summary>
		public static EntityField2 NotesWriterId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.NotesWriterId);}
		}
		/// <summary>Creates a new AssessmentEntity.MedicalFileReceivedDate field instance</summary>
		public static EntityField2 MedicalFileReceivedDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.MedicalFileReceivedDate);}
		}
		/// <summary>Creates a new AssessmentEntity.IsLargeFile field instance</summary>
		public static EntityField2 IsLargeFile
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.IsLargeFile);}
		}
		/// <summary>Creates a new AssessmentEntity.ReferralSourceFileNumber field instance</summary>
		public static EntityField2 ReferralSourceFileNumber
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.ReferralSourceFileNumber);}
		}
	}

	/// <summary>Field Creation Class for entity AssessmentAttributeEntity</summary>
	public partial class AssessmentAttributeFields
	{
		/// <summary>Creates a new AssessmentAttributeEntity.AssessmentId field instance</summary>
		public static EntityField2 AssessmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentAttributeFieldIndex.AssessmentId);}
		}
		/// <summary>Creates a new AssessmentAttributeEntity.AttributeId field instance</summary>
		public static EntityField2 AttributeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentAttributeFieldIndex.AttributeId);}
		}
	}

	/// <summary>Field Creation Class for entity AssessmentClaimEntity</summary>
	public partial class AssessmentClaimFields
	{
		/// <summary>Creates a new AssessmentClaimEntity.AssessmentId field instance</summary>
		public static EntityField2 AssessmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentClaimFieldIndex.AssessmentId);}
		}
		/// <summary>Creates a new AssessmentClaimEntity.ClaimId field instance</summary>
		public static EntityField2 ClaimId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentClaimFieldIndex.ClaimId);}
		}
	}

	/// <summary>Field Creation Class for entity AssessmentColorEntity</summary>
	public partial class AssessmentColorFields
	{
		/// <summary>Creates a new AssessmentColorEntity.AssessmentId field instance</summary>
		public static EntityField2 AssessmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentColorFieldIndex.AssessmentId);}
		}
		/// <summary>Creates a new AssessmentColorEntity.ColorId field instance</summary>
		public static EntityField2 ColorId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentColorFieldIndex.ColorId);}
		}
	}

	/// <summary>Field Creation Class for entity AssessmentIssueInDisputeEntity</summary>
	public partial class AssessmentIssueInDisputeFields
	{
		/// <summary>Creates a new AssessmentIssueInDisputeEntity.AssessmentId field instance</summary>
		public static EntityField2 AssessmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentIssueInDisputeFieldIndex.AssessmentId);}
		}
		/// <summary>Creates a new AssessmentIssueInDisputeEntity.IssueIsDisputeId field instance</summary>
		public static EntityField2 IssueIsDisputeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentIssueInDisputeFieldIndex.IssueIsDisputeId);}
		}
	}

	/// <summary>Field Creation Class for entity AssessmentMedRehabEntity</summary>
	public partial class AssessmentMedRehabFields
	{
		/// <summary>Creates a new AssessmentMedRehabEntity.MedRehabId field instance</summary>
		public static EntityField2 MedRehabId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentMedRehabFieldIndex.MedRehabId);}
		}
		/// <summary>Creates a new AssessmentMedRehabEntity.AssessmentId field instance</summary>
		public static EntityField2 AssessmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentMedRehabFieldIndex.AssessmentId);}
		}
		/// <summary>Creates a new AssessmentMedRehabEntity.Date field instance</summary>
		public static EntityField2 Date
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentMedRehabFieldIndex.Date);}
		}
		/// <summary>Creates a new AssessmentMedRehabEntity.Amount field instance</summary>
		public static EntityField2 Amount
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentMedRehabFieldIndex.Amount);}
		}
		/// <summary>Creates a new AssessmentMedRehabEntity.Description field instance</summary>
		public static EntityField2 Description
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentMedRehabFieldIndex.Description);}
		}
		/// <summary>Creates a new AssessmentMedRehabEntity.Deleted field instance</summary>
		public static EntityField2 Deleted
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentMedRehabFieldIndex.Deleted);}
		}
	}

	/// <summary>Field Creation Class for entity AssessmentNoteEntity</summary>
	public partial class AssessmentNoteFields
	{
		/// <summary>Creates a new AssessmentNoteEntity.AssessmentId field instance</summary>
		public static EntityField2 AssessmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentNoteFieldIndex.AssessmentId);}
		}
		/// <summary>Creates a new AssessmentNoteEntity.NoteId field instance</summary>
		public static EntityField2 NoteId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentNoteFieldIndex.NoteId);}
		}
	}

	/// <summary>Field Creation Class for entity AssessmentReportEntity</summary>
	public partial class AssessmentReportFields
	{
		/// <summary>Creates a new AssessmentReportEntity.ReportId field instance</summary>
		public static EntityField2 ReportId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentReportFieldIndex.ReportId);}
		}
		/// <summary>Creates a new AssessmentReportEntity.AssessmentId field instance</summary>
		public static EntityField2 AssessmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentReportFieldIndex.AssessmentId);}
		}
		/// <summary>Creates a new AssessmentReportEntity.ReportTypeId field instance</summary>
		public static EntityField2 ReportTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentReportFieldIndex.ReportTypeId);}
		}
	}

	/// <summary>Field Creation Class for entity AssessmentTypeEntity</summary>
	public partial class AssessmentTypeFields
	{
		/// <summary>Creates a new AssessmentTypeEntity.AssessmentTypeId field instance</summary>
		public static EntityField2 AssessmentTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentTypeFieldIndex.AssessmentTypeId);}
		}
		/// <summary>Creates a new AssessmentTypeEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentTypeFieldIndex.Name);}
		}
		/// <summary>Creates a new AssessmentTypeEntity.Description field instance</summary>
		public static EntityField2 Description
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentTypeFieldIndex.Description);}
		}
		/// <summary>Creates a new AssessmentTypeEntity.Duration field instance</summary>
		public static EntityField2 Duration
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentTypeFieldIndex.Duration);}
		}
		/// <summary>Creates a new AssessmentTypeEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentTypeFieldIndex.IsActive);}
		}
	}

	/// <summary>Field Creation Class for entity AssessmentTypeReportTypeEntity</summary>
	public partial class AssessmentTypeReportTypeFields
	{
		/// <summary>Creates a new AssessmentTypeReportTypeEntity.AssessmentTypeId field instance</summary>
		public static EntityField2 AssessmentTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentTypeReportTypeFieldIndex.AssessmentTypeId);}
		}
		/// <summary>Creates a new AssessmentTypeReportTypeEntity.ReportTypeId field instance</summary>
		public static EntityField2 ReportTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentTypeReportTypeFieldIndex.ReportTypeId);}
		}
	}

	/// <summary>Field Creation Class for entity AttributeEntity</summary>
	public partial class AttributeFields
	{
		/// <summary>Creates a new AttributeEntity.AttributeId field instance</summary>
		public static EntityField2 AttributeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AttributeFieldIndex.AttributeId);}
		}
		/// <summary>Creates a new AttributeEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(AttributeFieldIndex.Name);}
		}
		/// <summary>Creates a new AttributeEntity.AttributeTypeId field instance</summary>
		public static EntityField2 AttributeTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AttributeFieldIndex.AttributeTypeId);}
		}
		/// <summary>Creates a new AttributeEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(AttributeFieldIndex.IsActive);}
		}
	}

	/// <summary>Field Creation Class for entity AttributeTypeEntity</summary>
	public partial class AttributeTypeFields
	{
		/// <summary>Creates a new AttributeTypeEntity.AttributeTypeId field instance</summary>
		public static EntityField2 AttributeTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AttributeTypeFieldIndex.AttributeTypeId);}
		}
		/// <summary>Creates a new AttributeTypeEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(AttributeTypeFieldIndex.Name);}
		}
		/// <summary>Creates a new AttributeTypeEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(AttributeTypeFieldIndex.IsActive);}
		}
	}

	/// <summary>Field Creation Class for entity CalendarNoteEntity</summary>
	public partial class CalendarNoteFields
	{
		/// <summary>Creates a new CalendarNoteEntity.CalendarNoteId field instance</summary>
		public static EntityField2 CalendarNoteId
		{
			get { return (EntityField2)EntityFieldFactory.Create(CalendarNoteFieldIndex.CalendarNoteId);}
		}
		/// <summary>Creates a new CalendarNoteEntity.FromDate field instance</summary>
		public static EntityField2 FromDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(CalendarNoteFieldIndex.FromDate);}
		}
		/// <summary>Creates a new CalendarNoteEntity.ToDate field instance</summary>
		public static EntityField2 ToDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(CalendarNoteFieldIndex.ToDate);}
		}
		/// <summary>Creates a new CalendarNoteEntity.NoteId field instance</summary>
		public static EntityField2 NoteId
		{
			get { return (EntityField2)EntityFieldFactory.Create(CalendarNoteFieldIndex.NoteId);}
		}
	}

	/// <summary>Field Creation Class for entity CityEntity</summary>
	public partial class CityFields
	{
		/// <summary>Creates a new CityEntity.CityId field instance</summary>
		public static EntityField2 CityId
		{
			get { return (EntityField2)EntityFieldFactory.Create(CityFieldIndex.CityId);}
		}
		/// <summary>Creates a new CityEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(CityFieldIndex.Name);}
		}
		/// <summary>Creates a new CityEntity.Province field instance</summary>
		public static EntityField2 Province
		{
			get { return (EntityField2)EntityFieldFactory.Create(CityFieldIndex.Province);}
		}
		/// <summary>Creates a new CityEntity.Country field instance</summary>
		public static EntityField2 Country
		{
			get { return (EntityField2)EntityFieldFactory.Create(CityFieldIndex.Country);}
		}
		/// <summary>Creates a new CityEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(CityFieldIndex.IsActive);}
		}
	}

	/// <summary>Field Creation Class for entity ClaimEntity</summary>
	public partial class ClaimFields
	{
		/// <summary>Creates a new ClaimEntity.ClaimId field instance</summary>
		public static EntityField2 ClaimId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ClaimFieldIndex.ClaimId);}
		}
		/// <summary>Creates a new ClaimEntity.ClaimantId field instance</summary>
		public static EntityField2 ClaimantId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ClaimFieldIndex.ClaimantId);}
		}
		/// <summary>Creates a new ClaimEntity.DateOfLoss field instance</summary>
		public static EntityField2 DateOfLoss
		{
			get { return (EntityField2)EntityFieldFactory.Create(ClaimFieldIndex.DateOfLoss);}
		}
		/// <summary>Creates a new ClaimEntity.ClaimNumber field instance</summary>
		public static EntityField2 ClaimNumber
		{
			get { return (EntityField2)EntityFieldFactory.Create(ClaimFieldIndex.ClaimNumber);}
		}
		/// <summary>Creates a new ClaimEntity.Deleted field instance</summary>
		public static EntityField2 Deleted
		{
			get { return (EntityField2)EntityFieldFactory.Create(ClaimFieldIndex.Deleted);}
		}
	}

	/// <summary>Field Creation Class for entity ClaimantEntity</summary>
	public partial class ClaimantFields
	{
		/// <summary>Creates a new ClaimantEntity.ClaimantId field instance</summary>
		public static EntityField2 ClaimantId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ClaimantFieldIndex.ClaimantId);}
		}
		/// <summary>Creates a new ClaimantEntity.FirstName field instance</summary>
		public static EntityField2 FirstName
		{
			get { return (EntityField2)EntityFieldFactory.Create(ClaimantFieldIndex.FirstName);}
		}
		/// <summary>Creates a new ClaimantEntity.LastName field instance</summary>
		public static EntityField2 LastName
		{
			get { return (EntityField2)EntityFieldFactory.Create(ClaimantFieldIndex.LastName);}
		}
		/// <summary>Creates a new ClaimantEntity.Age field instance</summary>
		public static EntityField2 Age
		{
			get { return (EntityField2)EntityFieldFactory.Create(ClaimantFieldIndex.Age);}
		}
		/// <summary>Creates a new ClaimantEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(ClaimantFieldIndex.IsActive);}
		}
		/// <summary>Creates a new ClaimantEntity.Gender field instance</summary>
		public static EntityField2 Gender
		{
			get { return (EntityField2)EntityFieldFactory.Create(ClaimantFieldIndex.Gender);}
		}
		/// <summary>Creates a new ClaimantEntity.DateOfBirth field instance</summary>
		public static EntityField2 DateOfBirth
		{
			get { return (EntityField2)EntityFieldFactory.Create(ClaimantFieldIndex.DateOfBirth);}
		}
	}

	/// <summary>Field Creation Class for entity ColorEntity</summary>
	public partial class ColorFields
	{
		/// <summary>Creates a new ColorEntity.ColorId field instance</summary>
		public static EntityField2 ColorId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ColorFieldIndex.ColorId);}
		}
		/// <summary>Creates a new ColorEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(ColorFieldIndex.Name);}
		}
		/// <summary>Creates a new ColorEntity.HexCode field instance</summary>
		public static EntityField2 HexCode
		{
			get { return (EntityField2)EntityFieldFactory.Create(ColorFieldIndex.HexCode);}
		}
		/// <summary>Creates a new ColorEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(ColorFieldIndex.IsActive);}
		}
	}

	/// <summary>Field Creation Class for entity CompanyEntity</summary>
	public partial class CompanyFields
	{
		/// <summary>Creates a new CompanyEntity.CompanyId field instance</summary>
		public static EntityField2 CompanyId
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.CompanyId);}
		}
		/// <summary>Creates a new CompanyEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.Name);}
		}
		/// <summary>Creates a new CompanyEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.IsActive);}
		}
	}

	/// <summary>Field Creation Class for entity CompanyAttributeEntity</summary>
	public partial class CompanyAttributeFields
	{
		/// <summary>Creates a new CompanyAttributeEntity.CompanyId field instance</summary>
		public static EntityField2 CompanyId
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyAttributeFieldIndex.CompanyId);}
		}
		/// <summary>Creates a new CompanyAttributeEntity.AttributeId field instance</summary>
		public static EntityField2 AttributeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyAttributeFieldIndex.AttributeId);}
		}
	}

	/// <summary>Field Creation Class for entity InvoiceAmountEntity</summary>
	public partial class InvoiceAmountFields
	{
		/// <summary>Creates a new InvoiceAmountEntity.ReferralSourceId field instance</summary>
		public static EntityField2 ReferralSourceId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceAmountFieldIndex.ReferralSourceId);}
		}
		/// <summary>Creates a new InvoiceAmountEntity.ReportTypeId field instance</summary>
		public static EntityField2 ReportTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceAmountFieldIndex.ReportTypeId);}
		}
		/// <summary>Creates a new InvoiceAmountEntity.FirstReportAmount field instance</summary>
		public static EntityField2 FirstReportAmount
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceAmountFieldIndex.FirstReportAmount);}
		}
		/// <summary>Creates a new InvoiceAmountEntity.AdditionalReportAmount field instance</summary>
		public static EntityField2 AdditionalReportAmount
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceAmountFieldIndex.AdditionalReportAmount);}
		}
	}

	/// <summary>Field Creation Class for entity IssueInDisputeEntity</summary>
	public partial class IssueInDisputeFields
	{
		/// <summary>Creates a new IssueInDisputeEntity.IssueInDisputeId field instance</summary>
		public static EntityField2 IssueInDisputeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(IssueInDisputeFieldIndex.IssueInDisputeId);}
		}
		/// <summary>Creates a new IssueInDisputeEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(IssueInDisputeFieldIndex.Name);}
		}
		/// <summary>Creates a new IssueInDisputeEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(IssueInDisputeFieldIndex.IsActive);}
		}
		/// <summary>Creates a new IssueInDisputeEntity.Instructions field instance</summary>
		public static EntityField2 Instructions
		{
			get { return (EntityField2)EntityFieldFactory.Create(IssueInDisputeFieldIndex.Instructions);}
		}
	}

	/// <summary>Field Creation Class for entity NoteEntity</summary>
	public partial class NoteFields
	{
		/// <summary>Creates a new NoteEntity.NoteId field instance</summary>
		public static EntityField2 NoteId
		{
			get { return (EntityField2)EntityFieldFactory.Create(NoteFieldIndex.NoteId);}
		}
		/// <summary>Creates a new NoteEntity.Note field instance</summary>
		public static EntityField2 Note
		{
			get { return (EntityField2)EntityFieldFactory.Create(NoteFieldIndex.Note);}
		}
		/// <summary>Creates a new NoteEntity.UpdateUserId field instance</summary>
		public static EntityField2 UpdateUserId
		{
			get { return (EntityField2)EntityFieldFactory.Create(NoteFieldIndex.UpdateUserId);}
		}
		/// <summary>Creates a new NoteEntity.UpdateDate field instance</summary>
		public static EntityField2 UpdateDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(NoteFieldIndex.UpdateDate);}
		}
		/// <summary>Creates a new NoteEntity.CreateUserId field instance</summary>
		public static EntityField2 CreateUserId
		{
			get { return (EntityField2)EntityFieldFactory.Create(NoteFieldIndex.CreateUserId);}
		}
		/// <summary>Creates a new NoteEntity.CreateDate field instance</summary>
		public static EntityField2 CreateDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(NoteFieldIndex.CreateDate);}
		}
		/// <summary>Creates a new NoteEntity.Deleted field instance</summary>
		public static EntityField2 Deleted
		{
			get { return (EntityField2)EntityFieldFactory.Create(NoteFieldIndex.Deleted);}
		}
	}

	/// <summary>Field Creation Class for entity ReferralSourceEntity</summary>
	public partial class ReferralSourceFields
	{
		/// <summary>Creates a new ReferralSourceEntity.ReferralSourceId field instance</summary>
		public static EntityField2 ReferralSourceId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceFieldIndex.ReferralSourceId);}
		}
		/// <summary>Creates a new ReferralSourceEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceFieldIndex.Name);}
		}
		/// <summary>Creates a new ReferralSourceEntity.ReferralSourceTypeId field instance</summary>
		public static EntityField2 ReferralSourceTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceFieldIndex.ReferralSourceTypeId);}
		}
		/// <summary>Creates a new ReferralSourceEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceFieldIndex.IsActive);}
		}
		/// <summary>Creates a new ReferralSourceEntity.LargeFileSize field instance</summary>
		public static EntityField2 LargeFileSize
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceFieldIndex.LargeFileSize);}
		}
		/// <summary>Creates a new ReferralSourceEntity.LargeFileFeeAmount field instance</summary>
		public static EntityField2 LargeFileFeeAmount
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceFieldIndex.LargeFileFeeAmount);}
		}
	}

	/// <summary>Field Creation Class for entity ReferralSourceTypeEntity</summary>
	public partial class ReferralSourceTypeFields
	{
		/// <summary>Creates a new ReferralSourceTypeEntity.ReferralSourceTypeId field instance</summary>
		public static EntityField2 ReferralSourceTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceTypeFieldIndex.ReferralSourceTypeId);}
		}
		/// <summary>Creates a new ReferralSourceTypeEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceTypeFieldIndex.Name);}
		}
		/// <summary>Creates a new ReferralSourceTypeEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceTypeFieldIndex.IsActive);}
		}
	}

	/// <summary>Field Creation Class for entity ReferralTypeEntity</summary>
	public partial class ReferralTypeFields
	{
		/// <summary>Creates a new ReferralTypeEntity.ReferralTypeId field instance</summary>
		public static EntityField2 ReferralTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralTypeFieldIndex.ReferralTypeId);}
		}
		/// <summary>Creates a new ReferralTypeEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralTypeFieldIndex.Name);}
		}
		/// <summary>Creates a new ReferralTypeEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralTypeFieldIndex.IsActive);}
		}
	}

	/// <summary>Field Creation Class for entity ReferralTypeIssueInDisputeEntity</summary>
	public partial class ReferralTypeIssueInDisputeFields
	{
		/// <summary>Creates a new ReferralTypeIssueInDisputeEntity.ReferralTypeId field instance</summary>
		public static EntityField2 ReferralTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralTypeIssueInDisputeFieldIndex.ReferralTypeId);}
		}
		/// <summary>Creates a new ReferralTypeIssueInDisputeEntity.IssueInDisputeId field instance</summary>
		public static EntityField2 IssueInDisputeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralTypeIssueInDisputeFieldIndex.IssueInDisputeId);}
		}
	}

	/// <summary>Field Creation Class for entity ReportStatusEntity</summary>
	public partial class ReportStatusFields
	{
		/// <summary>Creates a new ReportStatusEntity.ReportStatusId field instance</summary>
		public static EntityField2 ReportStatusId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReportStatusFieldIndex.ReportStatusId);}
		}
		/// <summary>Creates a new ReportStatusEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReportStatusFieldIndex.Name);}
		}
		/// <summary>Creates a new ReportStatusEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReportStatusFieldIndex.IsActive);}
		}
	}

	/// <summary>Field Creation Class for entity ReportTypeEntity</summary>
	public partial class ReportTypeFields
	{
		/// <summary>Creates a new ReportTypeEntity.ReportTypeId field instance</summary>
		public static EntityField2 ReportTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReportTypeFieldIndex.ReportTypeId);}
		}
		/// <summary>Creates a new ReportTypeEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReportTypeFieldIndex.Name);}
		}
		/// <summary>Creates a new ReportTypeEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReportTypeFieldIndex.IsActive);}
		}
		/// <summary>Creates a new ReportTypeEntity.NumberOfReports field instance</summary>
		public static EntityField2 NumberOfReports
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReportTypeFieldIndex.NumberOfReports);}
		}
	}

	/// <summary>Field Creation Class for entity RightEntity</summary>
	public partial class RightFields
	{
		/// <summary>Creates a new RightEntity.RightId field instance</summary>
		public static EntityField2 RightId
		{
			get { return (EntityField2)EntityFieldFactory.Create(RightFieldIndex.RightId);}
		}
		/// <summary>Creates a new RightEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(RightFieldIndex.Name);}
		}
		/// <summary>Creates a new RightEntity.Description field instance</summary>
		public static EntityField2 Description
		{
			get { return (EntityField2)EntityFieldFactory.Create(RightFieldIndex.Description);}
		}
		/// <summary>Creates a new RightEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(RightFieldIndex.IsActive);}
		}
	}

	/// <summary>Field Creation Class for entity RoleEntity</summary>
	public partial class RoleFields
	{
		/// <summary>Creates a new RoleEntity.RoleId field instance</summary>
		public static EntityField2 RoleId
		{
			get { return (EntityField2)EntityFieldFactory.Create(RoleFieldIndex.RoleId);}
		}
		/// <summary>Creates a new RoleEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(RoleFieldIndex.Name);}
		}
		/// <summary>Creates a new RoleEntity.Description field instance</summary>
		public static EntityField2 Description
		{
			get { return (EntityField2)EntityFieldFactory.Create(RoleFieldIndex.Description);}
		}
		/// <summary>Creates a new RoleEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(RoleFieldIndex.IsActive);}
		}
	}

	/// <summary>Field Creation Class for entity RoleRightEntity</summary>
	public partial class RoleRightFields
	{
		/// <summary>Creates a new RoleRightEntity.RoleId field instance</summary>
		public static EntityField2 RoleId
		{
			get { return (EntityField2)EntityFieldFactory.Create(RoleRightFieldIndex.RoleId);}
		}
		/// <summary>Creates a new RoleRightEntity.RightId field instance</summary>
		public static EntityField2 RightId
		{
			get { return (EntityField2)EntityFieldFactory.Create(RoleRightFieldIndex.RightId);}
		}
	}

	/// <summary>Field Creation Class for entity UserEntity</summary>
	public partial class UserFields
	{
		/// <summary>Creates a new UserEntity.UserId field instance</summary>
		public static EntityField2 UserId
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserFieldIndex.UserId);}
		}
		/// <summary>Creates a new UserEntity.FirstName field instance</summary>
		public static EntityField2 FirstName
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserFieldIndex.FirstName);}
		}
		/// <summary>Creates a new UserEntity.LastName field instance</summary>
		public static EntityField2 LastName
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserFieldIndex.LastName);}
		}
		/// <summary>Creates a new UserEntity.Email field instance</summary>
		public static EntityField2 Email
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserFieldIndex.Email);}
		}
		/// <summary>Creates a new UserEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserFieldIndex.IsActive);}
		}
		/// <summary>Creates a new UserEntity.CompanyId field instance</summary>
		public static EntityField2 CompanyId
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserFieldIndex.CompanyId);}
		}
	}

	/// <summary>Field Creation Class for entity UserNoteEntity</summary>
	public partial class UserNoteFields
	{
		/// <summary>Creates a new UserNoteEntity.NoteId field instance</summary>
		public static EntityField2 NoteId
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserNoteFieldIndex.NoteId);}
		}
		/// <summary>Creates a new UserNoteEntity.UserId field instance</summary>
		public static EntityField2 UserId
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserNoteFieldIndex.UserId);}
		}
	}

	/// <summary>Field Creation Class for entity UserRoleEntity</summary>
	public partial class UserRoleFields
	{
		/// <summary>Creates a new UserRoleEntity.UserId field instance</summary>
		public static EntityField2 UserId
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserRoleFieldIndex.UserId);}
		}
		/// <summary>Creates a new UserRoleEntity.RoleId field instance</summary>
		public static EntityField2 RoleId
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserRoleFieldIndex.RoleId);}
		}
	}

	/// <summary>Field Creation Class for entity UserTravelFeeEntity</summary>
	public partial class UserTravelFeeFields
	{
		/// <summary>Creates a new UserTravelFeeEntity.UserId field instance</summary>
		public static EntityField2 UserId
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserTravelFeeFieldIndex.UserId);}
		}
		/// <summary>Creates a new UserTravelFeeEntity.CityId field instance</summary>
		public static EntityField2 CityId
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserTravelFeeFieldIndex.CityId);}
		}
		/// <summary>Creates a new UserTravelFeeEntity.Amount field instance</summary>
		public static EntityField2 Amount
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserTravelFeeFieldIndex.Amount);}
		}
	}

	/// <summary>Field Creation Class for entity UserUnavailabilityEntity</summary>
	public partial class UserUnavailabilityFields
	{
		/// <summary>Creates a new UserUnavailabilityEntity.Id field instance</summary>
		public static EntityField2 Id
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserUnavailabilityFieldIndex.Id);}
		}
		/// <summary>Creates a new UserUnavailabilityEntity.UserId field instance</summary>
		public static EntityField2 UserId
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserUnavailabilityFieldIndex.UserId);}
		}
		/// <summary>Creates a new UserUnavailabilityEntity.StartDate field instance</summary>
		public static EntityField2 StartDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserUnavailabilityFieldIndex.StartDate);}
		}
		/// <summary>Creates a new UserUnavailabilityEntity.EndDate field instance</summary>
		public static EntityField2 EndDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserUnavailabilityFieldIndex.EndDate);}
		}
	}
	

}