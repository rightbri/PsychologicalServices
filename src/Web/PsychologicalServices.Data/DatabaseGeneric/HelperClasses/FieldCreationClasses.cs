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
		/// <summary>Creates a new AddressEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(AddressFieldIndex.IsActive);}
		}
	}

	/// <summary>Field Creation Class for entity AddressAddressTypeEntity</summary>
	public partial class AddressAddressTypeFields
	{
		/// <summary>Creates a new AddressAddressTypeEntity.AddressId field instance</summary>
		public static EntityField2 AddressId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AddressAddressTypeFieldIndex.AddressId);}
		}
		/// <summary>Creates a new AddressAddressTypeEntity.AddressTypeId field instance</summary>
		public static EntityField2 AddressTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AddressAddressTypeFieldIndex.AddressTypeId);}
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
		/// <summary>Creates a new AppointmentEntity.AssessmentId field instance</summary>
		public static EntityField2 AssessmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentFieldIndex.AssessmentId);}
		}
		/// <summary>Creates a new AppointmentEntity.CreateDate field instance</summary>
		public static EntityField2 CreateDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentFieldIndex.CreateDate);}
		}
		/// <summary>Creates a new AppointmentEntity.CreateUserId field instance</summary>
		public static EntityField2 CreateUserId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentFieldIndex.CreateUserId);}
		}
		/// <summary>Creates a new AppointmentEntity.UpdateDate field instance</summary>
		public static EntityField2 UpdateDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentFieldIndex.UpdateDate);}
		}
		/// <summary>Creates a new AppointmentEntity.UpdateUserId field instance</summary>
		public static EntityField2 UpdateUserId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentFieldIndex.UpdateUserId);}
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
		/// <summary>Creates a new AppointmentAttributeEntity.Value field instance</summary>
		public static EntityField2 Value
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentAttributeFieldIndex.Value);}
		}
	}

	/// <summary>Field Creation Class for entity AppointmentSequenceEntity</summary>
	public partial class AppointmentSequenceFields
	{
		/// <summary>Creates a new AppointmentSequenceEntity.AppointmentSequenceId field instance</summary>
		public static EntityField2 AppointmentSequenceId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentSequenceFieldIndex.AppointmentSequenceId);}
		}
		/// <summary>Creates a new AppointmentSequenceEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentSequenceFieldIndex.Name);}
		}
		/// <summary>Creates a new AppointmentSequenceEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentSequenceFieldIndex.IsActive);}
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
		/// <summary>Creates a new AppointmentStatusEntity.CanInvoice field instance</summary>
		public static EntityField2 CanInvoice
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentStatusFieldIndex.CanInvoice);}
		}
		/// <summary>Creates a new AppointmentStatusEntity.Sort field instance</summary>
		public static EntityField2 Sort
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentStatusFieldIndex.Sort);}
		}
		/// <summary>Creates a new AppointmentStatusEntity.ShowOnSchedule field instance</summary>
		public static EntityField2 ShowOnSchedule
		{
			get { return (EntityField2)EntityFieldFactory.Create(AppointmentStatusFieldIndex.ShowOnSchedule);}
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
		/// <summary>Creates a new AssessmentEntity.CreateDate field instance</summary>
		public static EntityField2 CreateDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.CreateDate);}
		}
		/// <summary>Creates a new AssessmentEntity.CreateUserId field instance</summary>
		public static EntityField2 CreateUserId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.CreateUserId);}
		}
		/// <summary>Creates a new AssessmentEntity.UpdateDate field instance</summary>
		public static EntityField2 UpdateDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.UpdateDate);}
		}
		/// <summary>Creates a new AssessmentEntity.UpdateUserId field instance</summary>
		public static EntityField2 UpdateUserId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.UpdateUserId);}
		}
		/// <summary>Creates a new AssessmentEntity.SummaryNoteId field instance</summary>
		public static EntityField2 SummaryNoteId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentFieldIndex.SummaryNoteId);}
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
		/// <summary>Creates a new AssessmentAttributeEntity.Value field instance</summary>
		public static EntityField2 Value
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentAttributeFieldIndex.Value);}
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
		/// <summary>Creates a new AssessmentNoteEntity.ShowOnCalendar field instance</summary>
		public static EntityField2 ShowOnCalendar
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentNoteFieldIndex.ShowOnCalendar);}
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
		/// <summary>Creates a new AssessmentReportEntity.IsAdditional field instance</summary>
		public static EntityField2 IsAdditional
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentReportFieldIndex.IsAdditional);}
		}
	}

	/// <summary>Field Creation Class for entity AssessmentReportIssueInDisputeEntity</summary>
	public partial class AssessmentReportIssueInDisputeFields
	{
		/// <summary>Creates a new AssessmentReportIssueInDisputeEntity.ReportId field instance</summary>
		public static EntityField2 ReportId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentReportIssueInDisputeFieldIndex.ReportId);}
		}
		/// <summary>Creates a new AssessmentReportIssueInDisputeEntity.IssueInDisputeId field instance</summary>
		public static EntityField2 IssueInDisputeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentReportIssueInDisputeFieldIndex.IssueInDisputeId);}
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
		/// <summary>Creates a new AssessmentTypeEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentTypeFieldIndex.IsActive);}
		}
		/// <summary>Creates a new AssessmentTypeEntity.InvoiceAmount field instance</summary>
		public static EntityField2 InvoiceAmount
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentTypeFieldIndex.InvoiceAmount);}
		}
	}

	/// <summary>Field Creation Class for entity AssessmentTypeAttributeTypeEntity</summary>
	public partial class AssessmentTypeAttributeTypeFields
	{
		/// <summary>Creates a new AssessmentTypeAttributeTypeEntity.AssessmentTypeId field instance</summary>
		public static EntityField2 AssessmentTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentTypeAttributeTypeFieldIndex.AssessmentTypeId);}
		}
		/// <summary>Creates a new AssessmentTypeAttributeTypeEntity.AttributeTypeId field instance</summary>
		public static EntityField2 AttributeTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(AssessmentTypeAttributeTypeFieldIndex.AttributeTypeId);}
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
		/// <summary>Creates a new CalendarNoteEntity.CompanyId field instance</summary>
		public static EntityField2 CompanyId
		{
			get { return (EntityField2)EntityFieldFactory.Create(CalendarNoteFieldIndex.CompanyId);}
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
		/// <summary>Creates a new ClaimEntity.Lawyer field instance</summary>
		public static EntityField2 Lawyer
		{
			get { return (EntityField2)EntityFieldFactory.Create(ClaimFieldIndex.Lawyer);}
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
		/// <summary>Creates a new CompanyEntity.AddressId field instance</summary>
		public static EntityField2 AddressId
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.AddressId);}
		}
		/// <summary>Creates a new CompanyEntity.Phone field instance</summary>
		public static EntityField2 Phone
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.Phone);}
		}
		/// <summary>Creates a new CompanyEntity.Fax field instance</summary>
		public static EntityField2 Fax
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.Fax);}
		}
		/// <summary>Creates a new CompanyEntity.Email field instance</summary>
		public static EntityField2 Email
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.Email);}
		}
		/// <summary>Creates a new CompanyEntity.TaxId field instance</summary>
		public static EntityField2 TaxId
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.TaxId);}
		}
		/// <summary>Creates a new CompanyEntity.NewAppointmentTime field instance</summary>
		public static EntityField2 NewAppointmentTime
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.NewAppointmentTime);}
		}
		/// <summary>Creates a new CompanyEntity.NewAppointmentLocationId field instance</summary>
		public static EntityField2 NewAppointmentLocationId
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.NewAppointmentLocationId);}
		}
		/// <summary>Creates a new CompanyEntity.NewAppointmentPsychologistId field instance</summary>
		public static EntityField2 NewAppointmentPsychologistId
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.NewAppointmentPsychologistId);}
		}
		/// <summary>Creates a new CompanyEntity.NewAppointmentPsychometristId field instance</summary>
		public static EntityField2 NewAppointmentPsychometristId
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.NewAppointmentPsychometristId);}
		}
		/// <summary>Creates a new CompanyEntity.NewAppointmentStatusId field instance</summary>
		public static EntityField2 NewAppointmentStatusId
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.NewAppointmentStatusId);}
		}
		/// <summary>Creates a new CompanyEntity.NewAssessmentReportStatusId field instance</summary>
		public static EntityField2 NewAssessmentReportStatusId
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.NewAssessmentReportStatusId);}
		}
		/// <summary>Creates a new CompanyEntity.NewAssessmentSummaryNoteText field instance</summary>
		public static EntityField2 NewAssessmentSummaryNoteText
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.NewAssessmentSummaryNoteText);}
		}
		/// <summary>Creates a new CompanyEntity.Timezone field instance</summary>
		public static EntityField2 Timezone
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.Timezone);}
		}
		/// <summary>Creates a new CompanyEntity.ReplyToEmail field instance</summary>
		public static EntityField2 ReplyToEmail
		{
			get { return (EntityField2)EntityFieldFactory.Create(CompanyFieldIndex.ReplyToEmail);}
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

	/// <summary>Field Creation Class for entity InvoiceEntity</summary>
	public partial class InvoiceFields
	{
		/// <summary>Creates a new InvoiceEntity.InvoiceId field instance</summary>
		public static EntityField2 InvoiceId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceFieldIndex.InvoiceId);}
		}
		/// <summary>Creates a new InvoiceEntity.Identifier field instance</summary>
		public static EntityField2 Identifier
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceFieldIndex.Identifier);}
		}
		/// <summary>Creates a new InvoiceEntity.InvoiceDate field instance</summary>
		public static EntityField2 InvoiceDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceFieldIndex.InvoiceDate);}
		}
		/// <summary>Creates a new InvoiceEntity.InvoiceStatusId field instance</summary>
		public static EntityField2 InvoiceStatusId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceFieldIndex.InvoiceStatusId);}
		}
		/// <summary>Creates a new InvoiceEntity.UpdateDate field instance</summary>
		public static EntityField2 UpdateDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceFieldIndex.UpdateDate);}
		}
		/// <summary>Creates a new InvoiceEntity.TaxRate field instance</summary>
		public static EntityField2 TaxRate
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceFieldIndex.TaxRate);}
		}
		/// <summary>Creates a new InvoiceEntity.Total field instance</summary>
		public static EntityField2 Total
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceFieldIndex.Total);}
		}
		/// <summary>Creates a new InvoiceEntity.InvoiceTypeId field instance</summary>
		public static EntityField2 InvoiceTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceFieldIndex.InvoiceTypeId);}
		}
		/// <summary>Creates a new InvoiceEntity.PayableToId field instance</summary>
		public static EntityField2 PayableToId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceFieldIndex.PayableToId);}
		}
	}

	/// <summary>Field Creation Class for entity InvoiceAppointmentEntity</summary>
	public partial class InvoiceAppointmentFields
	{
		/// <summary>Creates a new InvoiceAppointmentEntity.InvoiceAppointmentId field instance</summary>
		public static EntityField2 InvoiceAppointmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceAppointmentFieldIndex.InvoiceAppointmentId);}
		}
		/// <summary>Creates a new InvoiceAppointmentEntity.InvoiceId field instance</summary>
		public static EntityField2 InvoiceId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceAppointmentFieldIndex.InvoiceId);}
		}
		/// <summary>Creates a new InvoiceAppointmentEntity.AppointmentId field instance</summary>
		public static EntityField2 AppointmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceAppointmentFieldIndex.AppointmentId);}
		}
	}

	/// <summary>Field Creation Class for entity InvoiceDocumentEntity</summary>
	public partial class InvoiceDocumentFields
	{
		/// <summary>Creates a new InvoiceDocumentEntity.InvoiceDocumentId field instance</summary>
		public static EntityField2 InvoiceDocumentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceDocumentFieldIndex.InvoiceDocumentId);}
		}
		/// <summary>Creates a new InvoiceDocumentEntity.InvoiceId field instance</summary>
		public static EntityField2 InvoiceId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceDocumentFieldIndex.InvoiceId);}
		}
		/// <summary>Creates a new InvoiceDocumentEntity.Document field instance</summary>
		public static EntityField2 Document
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceDocumentFieldIndex.Document);}
		}
		/// <summary>Creates a new InvoiceDocumentEntity.CreateDate field instance</summary>
		public static EntityField2 CreateDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceDocumentFieldIndex.CreateDate);}
		}
		/// <summary>Creates a new InvoiceDocumentEntity.FileName field instance</summary>
		public static EntityField2 FileName
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceDocumentFieldIndex.FileName);}
		}
	}

	/// <summary>Field Creation Class for entity InvoiceLineEntity</summary>
	public partial class InvoiceLineFields
	{
		/// <summary>Creates a new InvoiceLineEntity.InvoiceLineId field instance</summary>
		public static EntityField2 InvoiceLineId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceLineFieldIndex.InvoiceLineId);}
		}
		/// <summary>Creates a new InvoiceLineEntity.InvoiceAppointmentId field instance</summary>
		public static EntityField2 InvoiceAppointmentId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceLineFieldIndex.InvoiceAppointmentId);}
		}
		/// <summary>Creates a new InvoiceLineEntity.Description field instance</summary>
		public static EntityField2 Description
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceLineFieldIndex.Description);}
		}
		/// <summary>Creates a new InvoiceLineEntity.Amount field instance</summary>
		public static EntityField2 Amount
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceLineFieldIndex.Amount);}
		}
		/// <summary>Creates a new InvoiceLineEntity.IsCustom field instance</summary>
		public static EntityField2 IsCustom
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceLineFieldIndex.IsCustom);}
		}
	}

	/// <summary>Field Creation Class for entity InvoiceStatusEntity</summary>
	public partial class InvoiceStatusFields
	{
		/// <summary>Creates a new InvoiceStatusEntity.InvoiceStatusId field instance</summary>
		public static EntityField2 InvoiceStatusId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceStatusFieldIndex.InvoiceStatusId);}
		}
		/// <summary>Creates a new InvoiceStatusEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceStatusFieldIndex.Name);}
		}
		/// <summary>Creates a new InvoiceStatusEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceStatusFieldIndex.IsActive);}
		}
		/// <summary>Creates a new InvoiceStatusEntity.CanEdit field instance</summary>
		public static EntityField2 CanEdit
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceStatusFieldIndex.CanEdit);}
		}
		/// <summary>Creates a new InvoiceStatusEntity.SaveDocument field instance</summary>
		public static EntityField2 SaveDocument
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceStatusFieldIndex.SaveDocument);}
		}
		/// <summary>Creates a new InvoiceStatusEntity.ActionName field instance</summary>
		public static EntityField2 ActionName
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceStatusFieldIndex.ActionName);}
		}
	}

	/// <summary>Field Creation Class for entity InvoiceStatusChangeEntity</summary>
	public partial class InvoiceStatusChangeFields
	{
		/// <summary>Creates a new InvoiceStatusChangeEntity.InvoiceStatusChangeId field instance</summary>
		public static EntityField2 InvoiceStatusChangeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceStatusChangeFieldIndex.InvoiceStatusChangeId);}
		}
		/// <summary>Creates a new InvoiceStatusChangeEntity.InvoiceId field instance</summary>
		public static EntityField2 InvoiceId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceStatusChangeFieldIndex.InvoiceId);}
		}
		/// <summary>Creates a new InvoiceStatusChangeEntity.InvoiceStatusId field instance</summary>
		public static EntityField2 InvoiceStatusId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceStatusChangeFieldIndex.InvoiceStatusId);}
		}
		/// <summary>Creates a new InvoiceStatusChangeEntity.UpdateDate field instance</summary>
		public static EntityField2 UpdateDate
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceStatusChangeFieldIndex.UpdateDate);}
		}
	}

	/// <summary>Field Creation Class for entity InvoiceStatusPathsEntity</summary>
	public partial class InvoiceStatusPathsFields
	{
		/// <summary>Creates a new InvoiceStatusPathsEntity.InvoiceStatusPathId field instance</summary>
		public static EntityField2 InvoiceStatusPathId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceStatusPathsFieldIndex.InvoiceStatusPathId);}
		}
		/// <summary>Creates a new InvoiceStatusPathsEntity.InvoiceStatusId field instance</summary>
		public static EntityField2 InvoiceStatusId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceStatusPathsFieldIndex.InvoiceStatusId);}
		}
		/// <summary>Creates a new InvoiceStatusPathsEntity.NextInvoiceStatusId field instance</summary>
		public static EntityField2 NextInvoiceStatusId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceStatusPathsFieldIndex.NextInvoiceStatusId);}
		}
	}

	/// <summary>Field Creation Class for entity InvoiceTypeEntity</summary>
	public partial class InvoiceTypeFields
	{
		/// <summary>Creates a new InvoiceTypeEntity.InvoiceTypeId field instance</summary>
		public static EntityField2 InvoiceTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceTypeFieldIndex.InvoiceTypeId);}
		}
		/// <summary>Creates a new InvoiceTypeEntity.Name field instance</summary>
		public static EntityField2 Name
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceTypeFieldIndex.Name);}
		}
		/// <summary>Creates a new InvoiceTypeEntity.IsActive field instance</summary>
		public static EntityField2 IsActive
		{
			get { return (EntityField2)EntityFieldFactory.Create(InvoiceTypeFieldIndex.IsActive);}
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
		/// <summary>Creates a new IssueInDisputeEntity.AdditionalFee field instance</summary>
		public static EntityField2 AdditionalFee
		{
			get { return (EntityField2)EntityFieldFactory.Create(IssueInDisputeFieldIndex.AdditionalFee);}
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
		/// <summary>Creates a new ReferralSourceEntity.AddressId field instance</summary>
		public static EntityField2 AddressId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceFieldIndex.AddressId);}
		}
	}

	/// <summary>Field Creation Class for entity ReferralSourceAppointmentStatusSettingEntity</summary>
	public partial class ReferralSourceAppointmentStatusSettingFields
	{
		/// <summary>Creates a new ReferralSourceAppointmentStatusSettingEntity.ReferralSourceId field instance</summary>
		public static EntityField2 ReferralSourceId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceAppointmentStatusSettingFieldIndex.ReferralSourceId);}
		}
		/// <summary>Creates a new ReferralSourceAppointmentStatusSettingEntity.AppointmentStatusId field instance</summary>
		public static EntityField2 AppointmentStatusId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceAppointmentStatusSettingFieldIndex.AppointmentStatusId);}
		}
		/// <summary>Creates a new ReferralSourceAppointmentStatusSettingEntity.InvoiceTypeId field instance</summary>
		public static EntityField2 InvoiceTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceAppointmentStatusSettingFieldIndex.InvoiceTypeId);}
		}
		/// <summary>Creates a new ReferralSourceAppointmentStatusSettingEntity.InvoiceRate field instance</summary>
		public static EntityField2 InvoiceRate
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceAppointmentStatusSettingFieldIndex.InvoiceRate);}
		}
		/// <summary>Creates a new ReferralSourceAppointmentStatusSettingEntity.AppointmentSequenceId field instance</summary>
		public static EntityField2 AppointmentSequenceId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceAppointmentStatusSettingFieldIndex.AppointmentSequenceId);}
		}
		/// <summary>Creates a new ReferralSourceAppointmentStatusSettingEntity.InvoiceFee field instance</summary>
		public static EntityField2 InvoiceFee
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceAppointmentStatusSettingFieldIndex.InvoiceFee);}
		}
		/// <summary>Creates a new ReferralSourceAppointmentStatusSettingEntity.ApplyTravelFee field instance</summary>
		public static EntityField2 ApplyTravelFee
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceAppointmentStatusSettingFieldIndex.ApplyTravelFee);}
		}
		/// <summary>Creates a new ReferralSourceAppointmentStatusSettingEntity.ApplyLargeFileFee field instance</summary>
		public static EntityField2 ApplyLargeFileFee
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReferralSourceAppointmentStatusSettingFieldIndex.ApplyLargeFileFee);}
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
	}

	/// <summary>Field Creation Class for entity ReportTypeInvoiceAmountEntity</summary>
	public partial class ReportTypeInvoiceAmountFields
	{
		/// <summary>Creates a new ReportTypeInvoiceAmountEntity.ReferralSourceId field instance</summary>
		public static EntityField2 ReferralSourceId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReportTypeInvoiceAmountFieldIndex.ReferralSourceId);}
		}
		/// <summary>Creates a new ReportTypeInvoiceAmountEntity.ReportTypeId field instance</summary>
		public static EntityField2 ReportTypeId
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReportTypeInvoiceAmountFieldIndex.ReportTypeId);}
		}
		/// <summary>Creates a new ReportTypeInvoiceAmountEntity.InvoiceAmount field instance</summary>
		public static EntityField2 InvoiceAmount
		{
			get { return (EntityField2)EntityFieldFactory.Create(ReportTypeInvoiceAmountFieldIndex.InvoiceAmount);}
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
		/// <summary>Creates a new UserEntity.AddressId field instance</summary>
		public static EntityField2 AddressId
		{
			get { return (EntityField2)EntityFieldFactory.Create(UserFieldIndex.AddressId);}
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