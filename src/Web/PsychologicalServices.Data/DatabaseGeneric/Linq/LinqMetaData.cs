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
				case PsychologicalServices.Data.EntityType.AddressTypeEntity:
					toReturn = this.AddressType;
					break;
				case PsychologicalServices.Data.EntityType.AppointmentEntity:
					toReturn = this.Appointment;
					break;
				case PsychologicalServices.Data.EntityType.AppointmentStatusEntity:
					toReturn = this.AppointmentStatus;
					break;
				case PsychologicalServices.Data.EntityType.AppointmentTaskEntity:
					toReturn = this.AppointmentTask;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentEntity:
					toReturn = this.Assessment;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentClaimEntity:
					toReturn = this.AssessmentClaim;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentIssueInDisputeEntity:
					toReturn = this.AssessmentIssueInDispute;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentMedRehabEntity:
					toReturn = this.AssessmentMedRehab;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentNoteEntity:
					toReturn = this.AssessmentNote;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentTypeEntity:
					toReturn = this.AssessmentType;
					break;
				case PsychologicalServices.Data.EntityType.AssessmentTypeReportTypeEntity:
					toReturn = this.AssessmentTypeReportType;
					break;
				case PsychologicalServices.Data.EntityType.CalendarNoteEntity:
					toReturn = this.CalendarNote;
					break;
				case PsychologicalServices.Data.EntityType.ClaimEntity:
					toReturn = this.Claim;
					break;
				case PsychologicalServices.Data.EntityType.ClaimantEntity:
					toReturn = this.Claimant;
					break;
				case PsychologicalServices.Data.EntityType.CompanyEntity:
					toReturn = this.Company;
					break;
				case PsychologicalServices.Data.EntityType.InvoiceAmountEntity:
					toReturn = this.InvoiceAmount;
					break;
				case PsychologicalServices.Data.EntityType.IssueInDisputeEntity:
					toReturn = this.IssueInDispute;
					break;
				case PsychologicalServices.Data.EntityType.NoteEntity:
					toReturn = this.Note;
					break;
				case PsychologicalServices.Data.EntityType.ReferralSourceEntity:
					toReturn = this.ReferralSource;
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
				case PsychologicalServices.Data.EntityType.TaskEntity:
					toReturn = this.Task;
					break;
				case PsychologicalServices.Data.EntityType.TaskStatusEntity:
					toReturn = this.TaskStatus;
					break;
				case PsychologicalServices.Data.EntityType.TaskTemplateEntity:
					toReturn = this.TaskTemplate;
					break;
				case PsychologicalServices.Data.EntityType.UserEntity:
					toReturn = this.User;
					break;
				case PsychologicalServices.Data.EntityType.UserRoleEntity:
					toReturn = this.UserRole;
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
		
		/// <summary>returns the datasource to use in a Linq query when targeting AppointmentStatusEntity instances in the database.</summary>
		public DataSource2<AppointmentStatusEntity> AppointmentStatus
		{
			get { return new DataSource2<AppointmentStatusEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AppointmentTaskEntity instances in the database.</summary>
		public DataSource2<AppointmentTaskEntity> AppointmentTask
		{
			get { return new DataSource2<AppointmentTaskEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentEntity instances in the database.</summary>
		public DataSource2<AssessmentEntity> Assessment
		{
			get { return new DataSource2<AssessmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentClaimEntity instances in the database.</summary>
		public DataSource2<AssessmentClaimEntity> AssessmentClaim
		{
			get { return new DataSource2<AssessmentClaimEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentIssueInDisputeEntity instances in the database.</summary>
		public DataSource2<AssessmentIssueInDisputeEntity> AssessmentIssueInDispute
		{
			get { return new DataSource2<AssessmentIssueInDisputeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
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
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentTypeEntity instances in the database.</summary>
		public DataSource2<AssessmentTypeEntity> AssessmentType
		{
			get { return new DataSource2<AssessmentTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AssessmentTypeReportTypeEntity instances in the database.</summary>
		public DataSource2<AssessmentTypeReportTypeEntity> AssessmentTypeReportType
		{
			get { return new DataSource2<AssessmentTypeReportTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CalendarNoteEntity instances in the database.</summary>
		public DataSource2<CalendarNoteEntity> CalendarNote
		{
			get { return new DataSource2<CalendarNoteEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
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
		
		/// <summary>returns the datasource to use in a Linq query when targeting CompanyEntity instances in the database.</summary>
		public DataSource2<CompanyEntity> Company
		{
			get { return new DataSource2<CompanyEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InvoiceAmountEntity instances in the database.</summary>
		public DataSource2<InvoiceAmountEntity> InvoiceAmount
		{
			get { return new DataSource2<InvoiceAmountEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting IssueInDisputeEntity instances in the database.</summary>
		public DataSource2<IssueInDisputeEntity> IssueInDispute
		{
			get { return new DataSource2<IssueInDisputeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NoteEntity instances in the database.</summary>
		public DataSource2<NoteEntity> Note
		{
			get { return new DataSource2<NoteEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ReferralSourceEntity instances in the database.</summary>
		public DataSource2<ReferralSourceEntity> ReferralSource
		{
			get { return new DataSource2<ReferralSourceEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
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
		
		/// <summary>returns the datasource to use in a Linq query when targeting TaskEntity instances in the database.</summary>
		public DataSource2<TaskEntity> Task
		{
			get { return new DataSource2<TaskEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TaskStatusEntity instances in the database.</summary>
		public DataSource2<TaskStatusEntity> TaskStatus
		{
			get { return new DataSource2<TaskStatusEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TaskTemplateEntity instances in the database.</summary>
		public DataSource2<TaskTemplateEntity> TaskTemplate
		{
			get { return new DataSource2<TaskTemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserEntity instances in the database.</summary>
		public DataSource2<UserEntity> User
		{
			get { return new DataSource2<UserEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserRoleEntity instances in the database.</summary>
		public DataSource2<UserRoleEntity> UserRole
		{
			get { return new DataSource2<UserRoleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
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