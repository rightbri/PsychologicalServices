///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.Linq
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.FactoryClasses;
using PsychologicalServices.Data.HelperClasses;
using PsychologicalServices.Data.RelationClasses;

namespace PsychologicalServices.Data.Linq
{
	/// <summary>Meta-data class for the construction of Linq queries which are to be executed using LLBLGen Pro code.</summary>
	public partial class LinqMetaData: ILinqMetaData
	{
		#region Class Member Declarations
		private IDataAccessAdapter _adapterToUse;
		private FunctionMappingStore _customFunctionMappings;
		private Context _contextToUse;
		#endregion
		
		/// <summary>CTor. Using this ctor will leave the IDataAccessAdapter object to use empty. To be able to execute the query, an IDataAccessAdapter instance
		/// is required, and has to be set on the LLBLGenProProvider2 object in the query to execute. </summary>
		public LinqMetaData() : this(null, null)
		{
		}
		
		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse) : this (adapterToUse, null)
		{
		}

		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <param name="customFunctionMappings">The custom function mappings to use. These take higher precedence than the ones in the DQE to use.</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse, FunctionMappingStore customFunctionMappings)
		{
			_adapterToUse = adapterToUse;
			_customFunctionMappings = customFunctionMappings;
		}
	
		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <param name="typeOfEntity">the type of the entity to get the datasource for</param>
		/// <returns>the requested datasource</returns>
		public IDataSource GetQueryableForEntity(int typeOfEntity)
		{
			IDataSource toReturn = null;
			switch((PsychologicalServices.Data.EntityType)typeOfEntity)
			{
				case PsychologicalServices.Data.EntityType.AddressEntity:
					toReturn = this.Address;
					break;
				case PsychologicalServices.Data.EntityType.AddressAddressTypeEntity:
					toReturn = this.AddressAddressType;
					break;
				case PsychologicalServices.Data.EntityType.AddressTypeEntity:
					toReturn = this.AddressType;
					break;
				case PsychologicalServices.Data.EntityType.AppointmentEntity:
					toReturn = this.Appointment;
					break;
				case PsychologicalServices.Data.EntityType.AppointmentAttributeEntity:
					toReturn = this.AppointmentAttribute;
					break;
				case PsychologicalServices.Data.EntityType.AppointmentSequenceEntity:
					toReturn = this.AppointmentSequence;
					break;
				case PsychologicalServices.Data.EntityType.AppointmentStatusEntity:
					toReturn = this.AppointmentStatus;
					break;
				case PsychologicalServices.Data.EntityType.AppointmentStatusInvoiceRateEntity:
					toReturn = this.AppointmentStatusInvoiceRate;
					break;
				case PsychologicalServices.Data.EntityType.ArbitrationEntity:
					toReturn = this.Arbitration;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentEntity:
					toReturn = this.Assessment;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentAttributeEntity:
					toReturn = this.AssessmentAttribute;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentClaimEntity:
					toReturn = this.AssessmentClaim;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentColorEntity:
					toReturn = this.AssessmentColor;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentMedRehabEntity:
					toReturn = this.AssessmentMedRehab;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentNoteEntity:
					toReturn = this.AssessmentNote;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentReportEntity:
					toReturn = this.AssessmentReport;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentReportIssueInDisputeEntity:
					toReturn = this.AssessmentReportIssueInDispute;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentTypeEntity:
					toReturn = this.AssessmentType;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentTypeAttributeTypeEntity:
					toReturn = this.AssessmentTypeAttributeType;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentTypeInvoiceAmountEntity:
					toReturn = this.AssessmentTypeInvoiceAmount;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentTypeReportTypeEntity:
					toReturn = this.AssessmentTypeReportType;
					break;
				case PsychologicalServices.Data.EntityType.AttributeEntity:
					toReturn = this.Attribute;
					break;
				case PsychologicalServices.Data.EntityType.AttributeTypeEntity:
					toReturn = this.AttributeType;
					break;
				case PsychologicalServices.Data.EntityType.CalendarNoteEntity:
					toReturn = this.CalendarNote;
					break;
				case PsychologicalServices.Data.EntityType.CityEntity:
					toReturn = this.City;
					break;
				case PsychologicalServices.Data.EntityType.ClaimEntity:
					toReturn = this.Claim;
					break;
				case PsychologicalServices.Data.EntityType.ClaimantEntity:
					toReturn = this.Claimant;
					break;
				case PsychologicalServices.Data.EntityType.ColorEntity:
					toReturn = this.Color;
					break;
				case PsychologicalServices.Data.EntityType.CompanyEntity:
					toReturn = this.Company;
					break;
				case PsychologicalServices.Data.EntityType.CompanyAttributeEntity:
					toReturn = this.CompanyAttribute;
					break;
				case PsychologicalServices.Data.EntityType.ContactEntity:
					toReturn = this.Contact;
					break;
				case PsychologicalServices.Data.EntityType.ContactTypeEntity:
					toReturn = this.ContactType;
					break;
				case PsychologicalServices.Data.EntityType.EmployerEntity:
					toReturn = this.Employer;
					break;
				case PsychologicalServices.Data.EntityType.EmployerTypeEntity:
					toReturn = this.EmployerType;
					break;
				case PsychologicalServices.Data.EntityType.InvoiceEntity:
					toReturn = this.Invoice;
					break;
				case PsychologicalServices.Data.EntityType.InvoiceAppointmentEntity:
					toReturn = this.InvoiceAppointment;
					break;
				case PsychologicalServices.Data.EntityType.InvoiceDocumentEntity:
					toReturn = this.InvoiceDocument;
					break;
				case PsychologicalServices.Data.EntityType.InvoiceLineEntity:
					toReturn = this.InvoiceLine;
					break;
				case PsychologicalServices.Data.EntityType.InvoiceStatusEntity:
					toReturn = this.InvoiceStatus;
					break;
				case PsychologicalServices.Data.EntityType.InvoiceStatusChangeEntity:
					toReturn = this.InvoiceStatusChange;
					break;
				case PsychologicalServices.Data.EntityType.InvoiceStatusPathsEntity:
					toReturn = this.InvoiceStatusPaths;
					break;
				case PsychologicalServices.Data.EntityType.InvoiceTypeEntity:
					toReturn = this.InvoiceType;
					break;
				case PsychologicalServices.Data.EntityType.IssueInDisputeEntity:
					toReturn = this.IssueInDispute;
					break;
				case PsychologicalServices.Data.EntityType.IssueInDisputeInvoiceAmountEntity:
					toReturn = this.IssueInDisputeInvoiceAmount;
					break;
				case PsychologicalServices.Data.EntityType.NoteEntity:
					toReturn = this.Note;
					break;
				case PsychologicalServices.Data.EntityType.PsychometristInvoiceAmountEntity:
					toReturn = this.PsychometristInvoiceAmount;
					break;
				case PsychologicalServices.Data.EntityType.ReferralSourceEntity:
					toReturn = this.ReferralSource;
					break;
				case PsychologicalServices.Data.EntityType.ReferralSourceInvoiceConfigurationEntity:
					toReturn = this.ReferralSourceInvoiceConfiguration;
					break;
				case PsychologicalServices.Data.EntityType.ReferralSourceTypeEntity:
					toReturn = this.ReferralSourceType;
					break;
				case PsychologicalServices.Data.EntityType.ReferralTypeEntity:
					toReturn = this.ReferralType;
					break;
				case PsychologicalServices.Data.EntityType.ReferralTypeIssueInDisputeEntity:
					toReturn = this.ReferralTypeIssueInDispute;
					break;
				case PsychologicalServices.Data.EntityType.ReportStatusEntity:
					toReturn = this.ReportStatus;
					break;
				case PsychologicalServices.Data.EntityType.ReportTypeEntity:
					toReturn = this.ReportType;
					break;
				case PsychologicalServices.Data.EntityType.RightEntity:
					toReturn = this.Right;
					break;
				case PsychologicalServices.Data.EntityType.RoleEntity:
					toReturn = this.Role;
					break;
				case PsychologicalServices.Data.EntityType.RoleRightEntity:
					toReturn = this.RoleRight;
					break;
				case PsychologicalServices.Data.EntityType.UserEntity:
					toReturn = this.User;
					break;
				case PsychologicalServices.Data.EntityType.UserNoteEntity:
					toReturn = this.UserNote;
					break;
				case PsychologicalServices.Data.EntityType.UserRoleEntity:
					toReturn = this.UserRole;
					break;
				case PsychologicalServices.Data.EntityType.UserTravelFeeEntity:
					toReturn = this.UserTravelFee;
					break;
				case PsychologicalServices.Data.EntityType.UserUnavailabilityEntity:
					toReturn = this.UserUnavailability;
					break;
				default:
					toReturn = null;
					break;
			}
			return toReturn;
		}

		/// <summary>returns the datasource to use in a Linq query when targeting AddressEntity instances in the database.</summary>
		public DataSource2<AddressEntity> Address
		{
			get { return new DataSource2<AddressEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AddressAddressTypeEntity instances in the database.</summary>
		public DataSource2<AddressAddressTypeEntity> AddressAddressType
		{
			get { return new DataSource2<AddressAddressTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AddressTypeEntity instances in the database.</summary>
		public DataSource2<AddressTypeEntity> AddressType
		{
			get { return new DataSource2<AddressTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AppointmentEntity instances in the database.</summary>
		public DataSource2<AppointmentEntity> Appointment
		{
			get { return new DataSource2<AppointmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AppointmentAttributeEntity instances in the database.</summary>
		public DataSource2<AppointmentAttributeEntity> AppointmentAttribute
		{
			get { return new DataSource2<AppointmentAttributeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AppointmentSequenceEntity instances in the database.</summary>
		public DataSource2<AppointmentSequenceEntity> AppointmentSequence
		{
			get { return new DataSource2<AppointmentSequenceEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AppointmentStatusEntity instances in the database.</summary>
		public DataSource2<AppointmentStatusEntity> AppointmentStatus
		{
			get { return new DataSource2<AppointmentStatusEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AppointmentStatusInvoiceRateEntity instances in the database.</summary>
		public DataSource2<AppointmentStatusInvoiceRateEntity> AppointmentStatusInvoiceRate
		{
			get { return new DataSource2<AppointmentStatusInvoiceRateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ArbitrationEntity instances in the database.</summary>
		public DataSource2<ArbitrationEntity> Arbitration
		{
			get { return new DataSource2<ArbitrationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentEntity instances in the database.</summary>
		public DataSource2<AssessmentEntity> Assessment
		{
			get { return new DataSource2<AssessmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentAttributeEntity instances in the database.</summary>
		public DataSource2<AssessmentAttributeEntity> AssessmentAttribute
		{
			get { return new DataSource2<AssessmentAttributeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentClaimEntity instances in the database.</summary>
		public DataSource2<AssessmentClaimEntity> AssessmentClaim
		{
			get { return new DataSource2<AssessmentClaimEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentColorEntity instances in the database.</summary>
		public DataSource2<AssessmentColorEntity> AssessmentColor
		{
			get { return new DataSource2<AssessmentColorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentMedRehabEntity instances in the database.</summary>
		public DataSource2<AssessmentMedRehabEntity> AssessmentMedRehab
		{
			get { return new DataSource2<AssessmentMedRehabEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentNoteEntity instances in the database.</summary>
		public DataSource2<AssessmentNoteEntity> AssessmentNote
		{
			get { return new DataSource2<AssessmentNoteEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentReportEntity instances in the database.</summary>
		public DataSource2<AssessmentReportEntity> AssessmentReport
		{
			get { return new DataSource2<AssessmentReportEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentReportIssueInDisputeEntity instances in the database.</summary>
		public DataSource2<AssessmentReportIssueInDisputeEntity> AssessmentReportIssueInDispute
		{
			get { return new DataSource2<AssessmentReportIssueInDisputeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentTypeEntity instances in the database.</summary>
		public DataSource2<AssessmentTypeEntity> AssessmentType
		{
			get { return new DataSource2<AssessmentTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentTypeAttributeTypeEntity instances in the database.</summary>
		public DataSource2<AssessmentTypeAttributeTypeEntity> AssessmentTypeAttributeType
		{
			get { return new DataSource2<AssessmentTypeAttributeTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentTypeInvoiceAmountEntity instances in the database.</summary>
		public DataSource2<AssessmentTypeInvoiceAmountEntity> AssessmentTypeInvoiceAmount
		{
			get { return new DataSource2<AssessmentTypeInvoiceAmountEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentTypeReportTypeEntity instances in the database.</summary>
		public DataSource2<AssessmentTypeReportTypeEntity> AssessmentTypeReportType
		{
			get { return new DataSource2<AssessmentTypeReportTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AttributeEntity instances in the database.</summary>
		public DataSource2<AttributeEntity> Attribute
		{
			get { return new DataSource2<AttributeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AttributeTypeEntity instances in the database.</summary>
		public DataSource2<AttributeTypeEntity> AttributeType
		{
			get { return new DataSource2<AttributeTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CalendarNoteEntity instances in the database.</summary>
		public DataSource2<CalendarNoteEntity> CalendarNote
		{
			get { return new DataSource2<CalendarNoteEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CityEntity instances in the database.</summary>
		public DataSource2<CityEntity> City
		{
			get { return new DataSource2<CityEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ClaimEntity instances in the database.</summary>
		public DataSource2<ClaimEntity> Claim
		{
			get { return new DataSource2<ClaimEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ClaimantEntity instances in the database.</summary>
		public DataSource2<ClaimantEntity> Claimant
		{
			get { return new DataSource2<ClaimantEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ColorEntity instances in the database.</summary>
		public DataSource2<ColorEntity> Color
		{
			get { return new DataSource2<ColorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CompanyEntity instances in the database.</summary>
		public DataSource2<CompanyEntity> Company
		{
			get { return new DataSource2<CompanyEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CompanyAttributeEntity instances in the database.</summary>
		public DataSource2<CompanyAttributeEntity> CompanyAttribute
		{
			get { return new DataSource2<CompanyAttributeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ContactEntity instances in the database.</summary>
		public DataSource2<ContactEntity> Contact
		{
			get { return new DataSource2<ContactEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ContactTypeEntity instances in the database.</summary>
		public DataSource2<ContactTypeEntity> ContactType
		{
			get { return new DataSource2<ContactTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EmployerEntity instances in the database.</summary>
		public DataSource2<EmployerEntity> Employer
		{
			get { return new DataSource2<EmployerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EmployerTypeEntity instances in the database.</summary>
		public DataSource2<EmployerTypeEntity> EmployerType
		{
			get { return new DataSource2<EmployerTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InvoiceEntity instances in the database.</summary>
		public DataSource2<InvoiceEntity> Invoice
		{
			get { return new DataSource2<InvoiceEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InvoiceAppointmentEntity instances in the database.</summary>
		public DataSource2<InvoiceAppointmentEntity> InvoiceAppointment
		{
			get { return new DataSource2<InvoiceAppointmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InvoiceDocumentEntity instances in the database.</summary>
		public DataSource2<InvoiceDocumentEntity> InvoiceDocument
		{
			get { return new DataSource2<InvoiceDocumentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InvoiceLineEntity instances in the database.</summary>
		public DataSource2<InvoiceLineEntity> InvoiceLine
		{
			get { return new DataSource2<InvoiceLineEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InvoiceStatusEntity instances in the database.</summary>
		public DataSource2<InvoiceStatusEntity> InvoiceStatus
		{
			get { return new DataSource2<InvoiceStatusEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InvoiceStatusChangeEntity instances in the database.</summary>
		public DataSource2<InvoiceStatusChangeEntity> InvoiceStatusChange
		{
			get { return new DataSource2<InvoiceStatusChangeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InvoiceStatusPathsEntity instances in the database.</summary>
		public DataSource2<InvoiceStatusPathsEntity> InvoiceStatusPaths
		{
			get { return new DataSource2<InvoiceStatusPathsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InvoiceTypeEntity instances in the database.</summary>
		public DataSource2<InvoiceTypeEntity> InvoiceType
		{
			get { return new DataSource2<InvoiceTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting IssueInDisputeEntity instances in the database.</summary>
		public DataSource2<IssueInDisputeEntity> IssueInDispute
		{
			get { return new DataSource2<IssueInDisputeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting IssueInDisputeInvoiceAmountEntity instances in the database.</summary>
		public DataSource2<IssueInDisputeInvoiceAmountEntity> IssueInDisputeInvoiceAmount
		{
			get { return new DataSource2<IssueInDisputeInvoiceAmountEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NoteEntity instances in the database.</summary>
		public DataSource2<NoteEntity> Note
		{
			get { return new DataSource2<NoteEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PsychometristInvoiceAmountEntity instances in the database.</summary>
		public DataSource2<PsychometristInvoiceAmountEntity> PsychometristInvoiceAmount
		{
			get { return new DataSource2<PsychometristInvoiceAmountEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ReferralSourceEntity instances in the database.</summary>
		public DataSource2<ReferralSourceEntity> ReferralSource
		{
			get { return new DataSource2<ReferralSourceEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ReferralSourceInvoiceConfigurationEntity instances in the database.</summary>
		public DataSource2<ReferralSourceInvoiceConfigurationEntity> ReferralSourceInvoiceConfiguration
		{
			get { return new DataSource2<ReferralSourceInvoiceConfigurationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ReferralSourceTypeEntity instances in the database.</summary>
		public DataSource2<ReferralSourceTypeEntity> ReferralSourceType
		{
			get { return new DataSource2<ReferralSourceTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ReferralTypeEntity instances in the database.</summary>
		public DataSource2<ReferralTypeEntity> ReferralType
		{
			get { return new DataSource2<ReferralTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ReferralTypeIssueInDisputeEntity instances in the database.</summary>
		public DataSource2<ReferralTypeIssueInDisputeEntity> ReferralTypeIssueInDispute
		{
			get { return new DataSource2<ReferralTypeIssueInDisputeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ReportStatusEntity instances in the database.</summary>
		public DataSource2<ReportStatusEntity> ReportStatus
		{
			get { return new DataSource2<ReportStatusEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ReportTypeEntity instances in the database.</summary>
		public DataSource2<ReportTypeEntity> ReportType
		{
			get { return new DataSource2<ReportTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RightEntity instances in the database.</summary>
		public DataSource2<RightEntity> Right
		{
			get { return new DataSource2<RightEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RoleEntity instances in the database.</summary>
		public DataSource2<RoleEntity> Role
		{
			get { return new DataSource2<RoleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RoleRightEntity instances in the database.</summary>
		public DataSource2<RoleRightEntity> RoleRight
		{
			get { return new DataSource2<RoleRightEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserEntity instances in the database.</summary>
		public DataSource2<UserEntity> User
		{
			get { return new DataSource2<UserEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserNoteEntity instances in the database.</summary>
		public DataSource2<UserNoteEntity> UserNote
		{
			get { return new DataSource2<UserNoteEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserRoleEntity instances in the database.</summary>
		public DataSource2<UserRoleEntity> UserRole
		{
			get { return new DataSource2<UserRoleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserTravelFeeEntity instances in the database.</summary>
		public DataSource2<UserTravelFeeEntity> UserTravelFee
		{
			get { return new DataSource2<UserTravelFeeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserUnavailabilityEntity instances in the database.</summary>
		public DataSource2<UserUnavailabilityEntity> UserUnavailability
		{
			get { return new DataSource2<UserUnavailabilityEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		
		#region Class Property Declarations
		/// <summary> Gets / sets the IDataAccessAdapter to use for the queries created with this meta data object.</summary>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public IDataAccessAdapter AdapterToUse
		{
			get { return _adapterToUse;}
			set { _adapterToUse = value;}
		}

		/// <summary>Gets or sets the custom function mappings to use. These take higher precedence than the ones in the DQE to use</summary>
		public FunctionMappingStore CustomFunctionMappings
		{
			get { return _customFunctionMappings; }
			set { _customFunctionMappings = value; }
		}
		
		/// <summary>Gets or sets the Context instance to use for entity fetches.</summary>
		public Context ContextToUse
		{
			get { return _contextToUse;}
			set { _contextToUse = value;}
		}
		#endregion
	}
}