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
using System.ComponentModel;
using System.Collections.Generic;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;
using PsychologicalServices.Data;
using PsychologicalServices.Data.HelperClasses;
using PsychologicalServices.Data.FactoryClasses;
using PsychologicalServices.Data.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PsychologicalServices.Data.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'Company'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CompanyEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AppointmentStatusInvoiceRateEntity> _appointmentStatusInvoiceRates;
		private EntityCollection<AssessmentEntity> _assessments;
		private EntityCollection<AssessmentTypeInvoiceAmountEntity> _assessmentTypeInvoiceAmounts;

		private EntityCollection<CompanyAttributeEntity> _companyAttributes;
		private EntityCollection<IssueInDisputeInvoiceAmountEntity> _issueInDisputeInvoiceAmounts;
		private EntityCollection<PsychometristInvoiceAmountEntity> _psychometristInvoiceAmounts;
		private EntityCollection<ReferralSourceInvoiceConfigurationEntity> _referralSourceInvoiceConfigurations;
		private EntityCollection<UserEntity> _users;






















		private AddressEntity _newAppointmentLocation;
		private AddressEntity _address;
		private AppointmentStatusEntity _newAppointmentStatus;
		private AssessmentTypeEntity _newAssessmentAssessmentType;
		private ReportStatusEntity _newAssessmentReportStatus;
		private UserEntity _newAppointmentPsychometrist;
		private UserEntity _newAppointmentPsychologist;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name NewAppointmentLocation</summary>
			public static readonly string NewAppointmentLocation = "NewAppointmentLocation";
			/// <summary>Member name Address</summary>
			public static readonly string Address = "Address";
			/// <summary>Member name NewAppointmentStatus</summary>
			public static readonly string NewAppointmentStatus = "NewAppointmentStatus";
			/// <summary>Member name NewAssessmentAssessmentType</summary>
			public static readonly string NewAssessmentAssessmentType = "NewAssessmentAssessmentType";
			/// <summary>Member name NewAssessmentReportStatus</summary>
			public static readonly string NewAssessmentReportStatus = "NewAssessmentReportStatus";
			/// <summary>Member name NewAppointmentPsychometrist</summary>
			public static readonly string NewAppointmentPsychometrist = "NewAppointmentPsychometrist";
			/// <summary>Member name NewAppointmentPsychologist</summary>
			public static readonly string NewAppointmentPsychologist = "NewAppointmentPsychologist";
			/// <summary>Member name AppointmentStatusInvoiceRates</summary>
			public static readonly string AppointmentStatusInvoiceRates = "AppointmentStatusInvoiceRates";
			/// <summary>Member name Assessments</summary>
			public static readonly string Assessments = "Assessments";
			/// <summary>Member name AssessmentTypeInvoiceAmounts</summary>
			public static readonly string AssessmentTypeInvoiceAmounts = "AssessmentTypeInvoiceAmounts";

			/// <summary>Member name CompanyAttributes</summary>
			public static readonly string CompanyAttributes = "CompanyAttributes";
			/// <summary>Member name IssueInDisputeInvoiceAmounts</summary>
			public static readonly string IssueInDisputeInvoiceAmounts = "IssueInDisputeInvoiceAmounts";
			/// <summary>Member name PsychometristInvoiceAmounts</summary>
			public static readonly string PsychometristInvoiceAmounts = "PsychometristInvoiceAmounts";
			/// <summary>Member name ReferralSourceInvoiceConfigurations</summary>
			public static readonly string ReferralSourceInvoiceConfigurations = "ReferralSourceInvoiceConfigurations";
			/// <summary>Member name Users</summary>
			public static readonly string Users = "Users";























		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CompanyEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CompanyEntity():base("CompanyEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CompanyEntity(IEntityFields2 fields):base("CompanyEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CompanyEntity</param>
		public CompanyEntity(IValidator validator):base("CompanyEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="companyId">PK value for Company which data should be fetched into this Company object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CompanyEntity(System.Int32 companyId):base("CompanyEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CompanyId = companyId;
		}

		/// <summary> CTor</summary>
		/// <param name="companyId">PK value for Company which data should be fetched into this Company object</param>
		/// <param name="validator">The custom validator object for this CompanyEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CompanyEntity(System.Int32 companyId, IValidator validator):base("CompanyEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CompanyId = companyId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CompanyEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_appointmentStatusInvoiceRates = (EntityCollection<AppointmentStatusInvoiceRateEntity>)info.GetValue("_appointmentStatusInvoiceRates", typeof(EntityCollection<AppointmentStatusInvoiceRateEntity>));
				_assessments = (EntityCollection<AssessmentEntity>)info.GetValue("_assessments", typeof(EntityCollection<AssessmentEntity>));
				_assessmentTypeInvoiceAmounts = (EntityCollection<AssessmentTypeInvoiceAmountEntity>)info.GetValue("_assessmentTypeInvoiceAmounts", typeof(EntityCollection<AssessmentTypeInvoiceAmountEntity>));

				_companyAttributes = (EntityCollection<CompanyAttributeEntity>)info.GetValue("_companyAttributes", typeof(EntityCollection<CompanyAttributeEntity>));
				_issueInDisputeInvoiceAmounts = (EntityCollection<IssueInDisputeInvoiceAmountEntity>)info.GetValue("_issueInDisputeInvoiceAmounts", typeof(EntityCollection<IssueInDisputeInvoiceAmountEntity>));
				_psychometristInvoiceAmounts = (EntityCollection<PsychometristInvoiceAmountEntity>)info.GetValue("_psychometristInvoiceAmounts", typeof(EntityCollection<PsychometristInvoiceAmountEntity>));
				_referralSourceInvoiceConfigurations = (EntityCollection<ReferralSourceInvoiceConfigurationEntity>)info.GetValue("_referralSourceInvoiceConfigurations", typeof(EntityCollection<ReferralSourceInvoiceConfigurationEntity>));
				_users = (EntityCollection<UserEntity>)info.GetValue("_users", typeof(EntityCollection<UserEntity>));






















				_newAppointmentLocation = (AddressEntity)info.GetValue("_newAppointmentLocation", typeof(AddressEntity));
				if(_newAppointmentLocation!=null)
				{
					_newAppointmentLocation.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_address = (AddressEntity)info.GetValue("_address", typeof(AddressEntity));
				if(_address!=null)
				{
					_address.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_newAppointmentStatus = (AppointmentStatusEntity)info.GetValue("_newAppointmentStatus", typeof(AppointmentStatusEntity));
				if(_newAppointmentStatus!=null)
				{
					_newAppointmentStatus.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_newAssessmentAssessmentType = (AssessmentTypeEntity)info.GetValue("_newAssessmentAssessmentType", typeof(AssessmentTypeEntity));
				if(_newAssessmentAssessmentType!=null)
				{
					_newAssessmentAssessmentType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_newAssessmentReportStatus = (ReportStatusEntity)info.GetValue("_newAssessmentReportStatus", typeof(ReportStatusEntity));
				if(_newAssessmentReportStatus!=null)
				{
					_newAssessmentReportStatus.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_newAppointmentPsychometrist = (UserEntity)info.GetValue("_newAppointmentPsychometrist", typeof(UserEntity));
				if(_newAppointmentPsychometrist!=null)
				{
					_newAppointmentPsychometrist.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_newAppointmentPsychologist = (UserEntity)info.GetValue("_newAppointmentPsychologist", typeof(UserEntity));
				if(_newAppointmentPsychologist!=null)
				{
					_newAppointmentPsychologist.AfterSave+=new EventHandler(OnEntityAfterSave);
				}

				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((CompanyFieldIndex)fieldIndex)
			{
				case CompanyFieldIndex.AddressId:
					DesetupSyncAddress(true, false);
					break;
				case CompanyFieldIndex.NewAppointmentLocationId:
					DesetupSyncNewAppointmentLocation(true, false);
					break;
				case CompanyFieldIndex.NewAppointmentPsychologistId:
					DesetupSyncNewAppointmentPsychologist(true, false);
					break;
				case CompanyFieldIndex.NewAppointmentPsychometristId:
					DesetupSyncNewAppointmentPsychometrist(true, false);
					break;
				case CompanyFieldIndex.NewAppointmentStatusId:
					DesetupSyncNewAppointmentStatus(true, false);
					break;
				case CompanyFieldIndex.NewAssessmentReportStatusId:
					DesetupSyncNewAssessmentReportStatus(true, false);
					break;
				case CompanyFieldIndex.NewAssessmentAssessmentTypeId:
					DesetupSyncNewAssessmentAssessmentType(true, false);
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}
				
		/// <summary>Gets the inheritance info provider instance of the project this entity instance is located in. </summary>
		/// <returns>ready to use inheritance info provider instance.</returns>
		protected override IInheritanceInfoProvider GetInheritanceInfoProvider()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntityProperty(string propertyName, IEntity2 entity)
		{
			switch(propertyName)
			{
				case "NewAppointmentLocation":
					this.NewAppointmentLocation = (AddressEntity)entity;
					break;
				case "Address":
					this.Address = (AddressEntity)entity;
					break;
				case "NewAppointmentStatus":
					this.NewAppointmentStatus = (AppointmentStatusEntity)entity;
					break;
				case "NewAssessmentAssessmentType":
					this.NewAssessmentAssessmentType = (AssessmentTypeEntity)entity;
					break;
				case "NewAssessmentReportStatus":
					this.NewAssessmentReportStatus = (ReportStatusEntity)entity;
					break;
				case "NewAppointmentPsychometrist":
					this.NewAppointmentPsychometrist = (UserEntity)entity;
					break;
				case "NewAppointmentPsychologist":
					this.NewAppointmentPsychologist = (UserEntity)entity;
					break;
				case "AppointmentStatusInvoiceRates":
					this.AppointmentStatusInvoiceRates.Add((AppointmentStatusInvoiceRateEntity)entity);
					break;
				case "Assessments":
					this.Assessments.Add((AssessmentEntity)entity);
					break;
				case "AssessmentTypeInvoiceAmounts":
					this.AssessmentTypeInvoiceAmounts.Add((AssessmentTypeInvoiceAmountEntity)entity);
					break;

				case "CompanyAttributes":
					this.CompanyAttributes.Add((CompanyAttributeEntity)entity);
					break;
				case "IssueInDisputeInvoiceAmounts":
					this.IssueInDisputeInvoiceAmounts.Add((IssueInDisputeInvoiceAmountEntity)entity);
					break;
				case "PsychometristInvoiceAmounts":
					this.PsychometristInvoiceAmounts.Add((PsychometristInvoiceAmountEntity)entity);
					break;
				case "ReferralSourceInvoiceConfigurations":
					this.ReferralSourceInvoiceConfigurations.Add((ReferralSourceInvoiceConfigurationEntity)entity);
					break;
				case "Users":
					this.Users.Add((UserEntity)entity);
					break;























				default:
					break;
			}
		}
		
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return CompanyEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "NewAppointmentLocation":
					toReturn.Add(CompanyEntity.Relations.AddressEntityUsingNewAppointmentLocationId);
					break;
				case "Address":
					toReturn.Add(CompanyEntity.Relations.AddressEntityUsingAddressId);
					break;
				case "NewAppointmentStatus":
					toReturn.Add(CompanyEntity.Relations.AppointmentStatusEntityUsingNewAppointmentStatusId);
					break;
				case "NewAssessmentAssessmentType":
					toReturn.Add(CompanyEntity.Relations.AssessmentTypeEntityUsingNewAssessmentAssessmentTypeId);
					break;
				case "NewAssessmentReportStatus":
					toReturn.Add(CompanyEntity.Relations.ReportStatusEntityUsingNewAssessmentReportStatusId);
					break;
				case "NewAppointmentPsychometrist":
					toReturn.Add(CompanyEntity.Relations.UserEntityUsingNewAppointmentPsychometristId);
					break;
				case "NewAppointmentPsychologist":
					toReturn.Add(CompanyEntity.Relations.UserEntityUsingNewAppointmentPsychologistId);
					break;
				case "AppointmentStatusInvoiceRates":
					toReturn.Add(CompanyEntity.Relations.AppointmentStatusInvoiceRateEntityUsingCompanyId);
					break;
				case "Assessments":
					toReturn.Add(CompanyEntity.Relations.AssessmentEntityUsingCompanyId);
					break;
				case "AssessmentTypeInvoiceAmounts":
					toReturn.Add(CompanyEntity.Relations.AssessmentTypeInvoiceAmountEntityUsingCompanyId);
					break;

				case "CompanyAttributes":
					toReturn.Add(CompanyEntity.Relations.CompanyAttributeEntityUsingCompanyId);
					break;
				case "IssueInDisputeInvoiceAmounts":
					toReturn.Add(CompanyEntity.Relations.IssueInDisputeInvoiceAmountEntityUsingCompanyId);
					break;
				case "PsychometristInvoiceAmounts":
					toReturn.Add(CompanyEntity.Relations.PsychometristInvoiceAmountEntityUsingCompanyId);
					break;
				case "ReferralSourceInvoiceConfigurations":
					toReturn.Add(CompanyEntity.Relations.ReferralSourceInvoiceConfigurationEntityUsingCompanyId);
					break;
				case "Users":
					toReturn.Add(CompanyEntity.Relations.UserEntityUsingCompanyId);
					break;























				default:

					break;				
			}
			return toReturn;
		}
#if !CF
		/// <summary>Checks if the relation mapped by the property with the name specified is a one way / single sided relation. If the passed in name is null, it
		/// will return true if the entity has any single-sided relation</summary>
		/// <param name="propertyName">Name of the property which is mapped onto the relation to check, or null to check if the entity has any relation/ which is single sided</param>
		/// <returns>true if the relation is single sided / one way (so the opposite relation isn't present), false otherwise</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override bool CheckOneWayRelations(string propertyName)
		{
			// use template trick to calculate the # of single-sided / oneway relations
			int numberOfOneWayRelations = 0+1+1+1+1+1;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));
				case "NewAppointmentLocation":
					return true;

				case "NewAppointmentStatus":
					return true;

				case "NewAssessmentReportStatus":
					return true;
				case "NewAppointmentPsychometrist":
					return true;
				case "NewAppointmentPsychologist":
					return true;

				default:
					return base.CheckOneWayRelations(propertyName);
			}
		}
#endif
		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntity(IEntity2 relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "NewAppointmentLocation":
					SetupSyncNewAppointmentLocation(relatedEntity);
					break;
				case "Address":
					SetupSyncAddress(relatedEntity);
					break;
				case "NewAppointmentStatus":
					SetupSyncNewAppointmentStatus(relatedEntity);
					break;
				case "NewAssessmentAssessmentType":
					SetupSyncNewAssessmentAssessmentType(relatedEntity);
					break;
				case "NewAssessmentReportStatus":
					SetupSyncNewAssessmentReportStatus(relatedEntity);
					break;
				case "NewAppointmentPsychometrist":
					SetupSyncNewAppointmentPsychometrist(relatedEntity);
					break;
				case "NewAppointmentPsychologist":
					SetupSyncNewAppointmentPsychologist(relatedEntity);
					break;
				case "AppointmentStatusInvoiceRates":
					this.AppointmentStatusInvoiceRates.Add((AppointmentStatusInvoiceRateEntity)relatedEntity);
					break;
				case "Assessments":
					this.Assessments.Add((AssessmentEntity)relatedEntity);
					break;
				case "AssessmentTypeInvoiceAmounts":
					this.AssessmentTypeInvoiceAmounts.Add((AssessmentTypeInvoiceAmountEntity)relatedEntity);
					break;

				case "CompanyAttributes":
					this.CompanyAttributes.Add((CompanyAttributeEntity)relatedEntity);
					break;
				case "IssueInDisputeInvoiceAmounts":
					this.IssueInDisputeInvoiceAmounts.Add((IssueInDisputeInvoiceAmountEntity)relatedEntity);
					break;
				case "PsychometristInvoiceAmounts":
					this.PsychometristInvoiceAmounts.Add((PsychometristInvoiceAmountEntity)relatedEntity);
					break;
				case "ReferralSourceInvoiceConfigurations":
					this.ReferralSourceInvoiceConfigurations.Add((ReferralSourceInvoiceConfigurationEntity)relatedEntity);
					break;
				case "Users":
					this.Users.Add((UserEntity)relatedEntity);
					break;

				default:
					break;
			}
		}

		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void UnsetRelatedEntity(IEntity2 relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "NewAppointmentLocation":
					DesetupSyncNewAppointmentLocation(false, true);
					break;
				case "Address":
					DesetupSyncAddress(false, true);
					break;
				case "NewAppointmentStatus":
					DesetupSyncNewAppointmentStatus(false, true);
					break;
				case "NewAssessmentAssessmentType":
					DesetupSyncNewAssessmentAssessmentType(false, true);
					break;
				case "NewAssessmentReportStatus":
					DesetupSyncNewAssessmentReportStatus(false, true);
					break;
				case "NewAppointmentPsychometrist":
					DesetupSyncNewAppointmentPsychometrist(false, true);
					break;
				case "NewAppointmentPsychologist":
					DesetupSyncNewAppointmentPsychologist(false, true);
					break;
				case "AppointmentStatusInvoiceRates":
					base.PerformRelatedEntityRemoval(this.AppointmentStatusInvoiceRates, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Assessments":
					base.PerformRelatedEntityRemoval(this.Assessments, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AssessmentTypeInvoiceAmounts":
					base.PerformRelatedEntityRemoval(this.AssessmentTypeInvoiceAmounts, relatedEntity, signalRelatedEntityManyToOne);
					break;

				case "CompanyAttributes":
					base.PerformRelatedEntityRemoval(this.CompanyAttributes, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "IssueInDisputeInvoiceAmounts":
					base.PerformRelatedEntityRemoval(this.IssueInDisputeInvoiceAmounts, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PsychometristInvoiceAmounts":
					base.PerformRelatedEntityRemoval(this.PsychometristInvoiceAmounts, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ReferralSourceInvoiceConfigurations":
					base.PerformRelatedEntityRemoval(this.ReferralSourceInvoiceConfigurations, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Users":
					base.PerformRelatedEntityRemoval(this.Users, relatedEntity, signalRelatedEntityManyToOne);
					break;

				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependingRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_newAppointmentLocation!=null)
			{
				toReturn.Add(_newAppointmentLocation);
			}
			if(_address!=null)
			{
				toReturn.Add(_address);
			}
			if(_newAppointmentStatus!=null)
			{
				toReturn.Add(_newAppointmentStatus);
			}
			if(_newAssessmentAssessmentType!=null)
			{
				toReturn.Add(_newAssessmentAssessmentType);
			}
			if(_newAssessmentReportStatus!=null)
			{
				toReturn.Add(_newAssessmentReportStatus);
			}
			if(_newAppointmentPsychometrist!=null)
			{
				toReturn.Add(_newAppointmentPsychometrist);
			}
			if(_newAppointmentPsychologist!=null)
			{
				toReturn.Add(_newAppointmentPsychologist);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AppointmentStatusInvoiceRates);
			toReturn.Add(this.Assessments);
			toReturn.Add(this.AssessmentTypeInvoiceAmounts);

			toReturn.Add(this.CompanyAttributes);
			toReturn.Add(this.IssueInDisputeInvoiceAmounts);
			toReturn.Add(this.PsychometristInvoiceAmounts);
			toReturn.Add(this.ReferralSourceInvoiceConfigurations);
			toReturn.Add(this.Users);

			return toReturn;
		}
		


		/// <summary>ISerializable member. Does custom serialization so event handlers do not get serialized. Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				info.AddValue("_appointmentStatusInvoiceRates", ((_appointmentStatusInvoiceRates!=null) && (_appointmentStatusInvoiceRates.Count>0) && !this.MarkedForDeletion)?_appointmentStatusInvoiceRates:null);
				info.AddValue("_assessments", ((_assessments!=null) && (_assessments.Count>0) && !this.MarkedForDeletion)?_assessments:null);
				info.AddValue("_assessmentTypeInvoiceAmounts", ((_assessmentTypeInvoiceAmounts!=null) && (_assessmentTypeInvoiceAmounts.Count>0) && !this.MarkedForDeletion)?_assessmentTypeInvoiceAmounts:null);

				info.AddValue("_companyAttributes", ((_companyAttributes!=null) && (_companyAttributes.Count>0) && !this.MarkedForDeletion)?_companyAttributes:null);
				info.AddValue("_issueInDisputeInvoiceAmounts", ((_issueInDisputeInvoiceAmounts!=null) && (_issueInDisputeInvoiceAmounts.Count>0) && !this.MarkedForDeletion)?_issueInDisputeInvoiceAmounts:null);
				info.AddValue("_psychometristInvoiceAmounts", ((_psychometristInvoiceAmounts!=null) && (_psychometristInvoiceAmounts.Count>0) && !this.MarkedForDeletion)?_psychometristInvoiceAmounts:null);
				info.AddValue("_referralSourceInvoiceConfigurations", ((_referralSourceInvoiceConfigurations!=null) && (_referralSourceInvoiceConfigurations.Count>0) && !this.MarkedForDeletion)?_referralSourceInvoiceConfigurations:null);
				info.AddValue("_users", ((_users!=null) && (_users.Count>0) && !this.MarkedForDeletion)?_users:null);






















				info.AddValue("_newAppointmentLocation", (!this.MarkedForDeletion?_newAppointmentLocation:null));
				info.AddValue("_address", (!this.MarkedForDeletion?_address:null));
				info.AddValue("_newAppointmentStatus", (!this.MarkedForDeletion?_newAppointmentStatus:null));
				info.AddValue("_newAssessmentAssessmentType", (!this.MarkedForDeletion?_newAssessmentAssessmentType:null));
				info.AddValue("_newAssessmentReportStatus", (!this.MarkedForDeletion?_newAssessmentReportStatus:null));
				info.AddValue("_newAppointmentPsychometrist", (!this.MarkedForDeletion?_newAppointmentPsychometrist:null));
				info.AddValue("_newAppointmentPsychologist", (!this.MarkedForDeletion?_newAppointmentPsychologist:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CompanyFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CompanyFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CompanyRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AppointmentStatusInvoiceRate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAppointmentStatusInvoiceRates()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AppointmentStatusInvoiceRateFields.CompanyId, null, ComparisonOperator.Equal, this.CompanyId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Assessment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentFields.CompanyId, null, ComparisonOperator.Equal, this.CompanyId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AssessmentTypeInvoiceAmount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessmentTypeInvoiceAmounts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentTypeInvoiceAmountFields.CompanyId, null, ComparisonOperator.Equal, this.CompanyId));
			return bucket;
		}


		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CompanyAttribute' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCompanyAttributes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CompanyAttributeFields.CompanyId, null, ComparisonOperator.Equal, this.CompanyId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IssueInDisputeInvoiceAmount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIssueInDisputeInvoiceAmounts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IssueInDisputeInvoiceAmountFields.CompanyId, null, ComparisonOperator.Equal, this.CompanyId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PsychometristInvoiceAmount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPsychometristInvoiceAmounts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PsychometristInvoiceAmountFields.CompanyId, null, ComparisonOperator.Equal, this.CompanyId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ReferralSourceInvoiceConfiguration' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReferralSourceInvoiceConfigurations()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceInvoiceConfigurationFields.CompanyId, null, ComparisonOperator.Equal, this.CompanyId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'User' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUsers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.CompanyId, null, ComparisonOperator.Equal, this.CompanyId));
			return bucket;
		}























		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Address' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNewAppointmentLocation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.NewAppointmentLocationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Address' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AppointmentStatus' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNewAppointmentStatus()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AppointmentStatusFields.AppointmentStatusId, null, ComparisonOperator.Equal, this.NewAppointmentStatusId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AssessmentType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNewAssessmentAssessmentType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentTypeFields.AssessmentTypeId, null, ComparisonOperator.Equal, this.NewAssessmentAssessmentTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ReportStatus' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNewAssessmentReportStatus()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReportStatusFields.ReportStatusId, null, ComparisonOperator.Equal, this.NewAssessmentReportStatusId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'User' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNewAppointmentPsychometrist()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.NewAppointmentPsychometristId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'User' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNewAppointmentPsychologist()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.NewAppointmentPsychologistId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(PsychologicalServices.Data.EntityType.CompanyEntity);
		}

		/// <summary>
		/// Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)
		/// </summary>
		/// <returns></returns>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return new TypeDefaultValue();
		}

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._appointmentStatusInvoiceRates);
			collectionsQueue.Enqueue(this._assessments);
			collectionsQueue.Enqueue(this._assessmentTypeInvoiceAmounts);

			collectionsQueue.Enqueue(this._companyAttributes);
			collectionsQueue.Enqueue(this._issueInDisputeInvoiceAmounts);
			collectionsQueue.Enqueue(this._psychometristInvoiceAmounts);
			collectionsQueue.Enqueue(this._referralSourceInvoiceConfigurations);
			collectionsQueue.Enqueue(this._users);






















		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._appointmentStatusInvoiceRates = (EntityCollection<AppointmentStatusInvoiceRateEntity>) collectionsQueue.Dequeue();
			this._assessments = (EntityCollection<AssessmentEntity>) collectionsQueue.Dequeue();
			this._assessmentTypeInvoiceAmounts = (EntityCollection<AssessmentTypeInvoiceAmountEntity>) collectionsQueue.Dequeue();

			this._companyAttributes = (EntityCollection<CompanyAttributeEntity>) collectionsQueue.Dequeue();
			this._issueInDisputeInvoiceAmounts = (EntityCollection<IssueInDisputeInvoiceAmountEntity>) collectionsQueue.Dequeue();
			this._psychometristInvoiceAmounts = (EntityCollection<PsychometristInvoiceAmountEntity>) collectionsQueue.Dequeue();
			this._referralSourceInvoiceConfigurations = (EntityCollection<ReferralSourceInvoiceConfigurationEntity>) collectionsQueue.Dequeue();
			this._users = (EntityCollection<UserEntity>) collectionsQueue.Dequeue();






















		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._appointmentStatusInvoiceRates != null)
			{
				return true;
			}
			if (this._assessments != null)
			{
				return true;
			}
			if (this._assessmentTypeInvoiceAmounts != null)
			{
				return true;
			}

			if (this._companyAttributes != null)
			{
				return true;
			}
			if (this._issueInDisputeInvoiceAmounts != null)
			{
				return true;
			}
			if (this._psychometristInvoiceAmounts != null)
			{
				return true;
			}
			if (this._referralSourceInvoiceConfigurations != null)
			{
				return true;
			}
			if (this._users != null)
			{
				return true;
			}






















			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AppointmentStatusInvoiceRateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentStatusInvoiceRateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AssessmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AssessmentTypeInvoiceAmountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentTypeInvoiceAmountEntityFactory))) : null);

			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CompanyAttributeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyAttributeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IssueInDisputeInvoiceAmountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IssueInDisputeInvoiceAmountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PsychometristInvoiceAmountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PsychometristInvoiceAmountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReferralSourceInvoiceConfigurationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceInvoiceConfigurationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))) : null);






















		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("NewAppointmentLocation", _newAppointmentLocation);
			toReturn.Add("Address", _address);
			toReturn.Add("NewAppointmentStatus", _newAppointmentStatus);
			toReturn.Add("NewAssessmentAssessmentType", _newAssessmentAssessmentType);
			toReturn.Add("NewAssessmentReportStatus", _newAssessmentReportStatus);
			toReturn.Add("NewAppointmentPsychometrist", _newAppointmentPsychometrist);
			toReturn.Add("NewAppointmentPsychologist", _newAppointmentPsychologist);
			toReturn.Add("AppointmentStatusInvoiceRates", _appointmentStatusInvoiceRates);
			toReturn.Add("Assessments", _assessments);
			toReturn.Add("AssessmentTypeInvoiceAmounts", _assessmentTypeInvoiceAmounts);

			toReturn.Add("CompanyAttributes", _companyAttributes);
			toReturn.Add("IssueInDisputeInvoiceAmounts", _issueInDisputeInvoiceAmounts);
			toReturn.Add("PsychometristInvoiceAmounts", _psychometristInvoiceAmounts);
			toReturn.Add("ReferralSourceInvoiceConfigurations", _referralSourceInvoiceConfigurations);
			toReturn.Add("Users", _users);























			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_appointmentStatusInvoiceRates!=null)
			{
				_appointmentStatusInvoiceRates.ActiveContext = base.ActiveContext;
			}
			if(_assessments!=null)
			{
				_assessments.ActiveContext = base.ActiveContext;
			}
			if(_assessmentTypeInvoiceAmounts!=null)
			{
				_assessmentTypeInvoiceAmounts.ActiveContext = base.ActiveContext;
			}

			if(_companyAttributes!=null)
			{
				_companyAttributes.ActiveContext = base.ActiveContext;
			}
			if(_issueInDisputeInvoiceAmounts!=null)
			{
				_issueInDisputeInvoiceAmounts.ActiveContext = base.ActiveContext;
			}
			if(_psychometristInvoiceAmounts!=null)
			{
				_psychometristInvoiceAmounts.ActiveContext = base.ActiveContext;
			}
			if(_referralSourceInvoiceConfigurations!=null)
			{
				_referralSourceInvoiceConfigurations.ActiveContext = base.ActiveContext;
			}
			if(_users!=null)
			{
				_users.ActiveContext = base.ActiveContext;
			}






















			if(_newAppointmentLocation!=null)
			{
				_newAppointmentLocation.ActiveContext = base.ActiveContext;
			}
			if(_address!=null)
			{
				_address.ActiveContext = base.ActiveContext;
			}
			if(_newAppointmentStatus!=null)
			{
				_newAppointmentStatus.ActiveContext = base.ActiveContext;
			}
			if(_newAssessmentAssessmentType!=null)
			{
				_newAssessmentAssessmentType.ActiveContext = base.ActiveContext;
			}
			if(_newAssessmentReportStatus!=null)
			{
				_newAssessmentReportStatus.ActiveContext = base.ActiveContext;
			}
			if(_newAppointmentPsychometrist!=null)
			{
				_newAppointmentPsychometrist.ActiveContext = base.ActiveContext;
			}
			if(_newAppointmentPsychologist!=null)
			{
				_newAppointmentPsychologist.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_appointmentStatusInvoiceRates = null;
			_assessments = null;
			_assessmentTypeInvoiceAmounts = null;

			_companyAttributes = null;
			_issueInDisputeInvoiceAmounts = null;
			_psychometristInvoiceAmounts = null;
			_referralSourceInvoiceConfigurations = null;
			_users = null;






















			_newAppointmentLocation = null;
			_address = null;
			_newAppointmentStatus = null;
			_newAssessmentAssessmentType = null;
			_newAssessmentReportStatus = null;
			_newAppointmentPsychometrist = null;
			_newAppointmentPsychologist = null;

			PerformDependencyInjection();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();

			Dictionary<string, string> fieldHashtable = null;
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CompanyId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Phone", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Fax", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TaxId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NewAppointmentTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NewAppointmentLocationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NewAppointmentPsychologistId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NewAppointmentPsychometristId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NewAppointmentStatusId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NewAssessmentReportStatusId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NewAssessmentSummaryNoteText", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Timezone", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReplyToEmail", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NewAssessmentAssessmentTypeId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _newAppointmentLocation</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNewAppointmentLocation(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _newAppointmentLocation, new PropertyChangedEventHandler( OnNewAppointmentLocationPropertyChanged ), "NewAppointmentLocation", CompanyEntity.Relations.AddressEntityUsingNewAppointmentLocationId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)CompanyFieldIndex.NewAppointmentLocationId } );		
			_newAppointmentLocation = null;
		}

		/// <summary> setups the sync logic for member _newAppointmentLocation</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNewAppointmentLocation(IEntity2 relatedEntity)
		{
			if(_newAppointmentLocation!=relatedEntity)
			{
				DesetupSyncNewAppointmentLocation(true, true);
				_newAppointmentLocation = (AddressEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _newAppointmentLocation, new PropertyChangedEventHandler( OnNewAppointmentLocationPropertyChanged ), "NewAppointmentLocation", CompanyEntity.Relations.AddressEntityUsingNewAppointmentLocationId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNewAppointmentLocationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _address</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAddress(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", CompanyEntity.Relations.AddressEntityUsingAddressId, true, signalRelatedEntity, "Companies", resetFKFields, new int[] { (int)CompanyFieldIndex.AddressId } );		
			_address = null;
		}

		/// <summary> setups the sync logic for member _address</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAddress(IEntity2 relatedEntity)
		{
			if(_address!=relatedEntity)
			{
				DesetupSyncAddress(true, true);
				_address = (AddressEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", CompanyEntity.Relations.AddressEntityUsingAddressId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAddressPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _newAppointmentStatus</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNewAppointmentStatus(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _newAppointmentStatus, new PropertyChangedEventHandler( OnNewAppointmentStatusPropertyChanged ), "NewAppointmentStatus", CompanyEntity.Relations.AppointmentStatusEntityUsingNewAppointmentStatusId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)CompanyFieldIndex.NewAppointmentStatusId } );		
			_newAppointmentStatus = null;
		}

		/// <summary> setups the sync logic for member _newAppointmentStatus</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNewAppointmentStatus(IEntity2 relatedEntity)
		{
			if(_newAppointmentStatus!=relatedEntity)
			{
				DesetupSyncNewAppointmentStatus(true, true);
				_newAppointmentStatus = (AppointmentStatusEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _newAppointmentStatus, new PropertyChangedEventHandler( OnNewAppointmentStatusPropertyChanged ), "NewAppointmentStatus", CompanyEntity.Relations.AppointmentStatusEntityUsingNewAppointmentStatusId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNewAppointmentStatusPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _newAssessmentAssessmentType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNewAssessmentAssessmentType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _newAssessmentAssessmentType, new PropertyChangedEventHandler( OnNewAssessmentAssessmentTypePropertyChanged ), "NewAssessmentAssessmentType", CompanyEntity.Relations.AssessmentTypeEntityUsingNewAssessmentAssessmentTypeId, true, signalRelatedEntity, "Companies", resetFKFields, new int[] { (int)CompanyFieldIndex.NewAssessmentAssessmentTypeId } );		
			_newAssessmentAssessmentType = null;
		}

		/// <summary> setups the sync logic for member _newAssessmentAssessmentType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNewAssessmentAssessmentType(IEntity2 relatedEntity)
		{
			if(_newAssessmentAssessmentType!=relatedEntity)
			{
				DesetupSyncNewAssessmentAssessmentType(true, true);
				_newAssessmentAssessmentType = (AssessmentTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _newAssessmentAssessmentType, new PropertyChangedEventHandler( OnNewAssessmentAssessmentTypePropertyChanged ), "NewAssessmentAssessmentType", CompanyEntity.Relations.AssessmentTypeEntityUsingNewAssessmentAssessmentTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNewAssessmentAssessmentTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _newAssessmentReportStatus</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNewAssessmentReportStatus(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _newAssessmentReportStatus, new PropertyChangedEventHandler( OnNewAssessmentReportStatusPropertyChanged ), "NewAssessmentReportStatus", CompanyEntity.Relations.ReportStatusEntityUsingNewAssessmentReportStatusId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)CompanyFieldIndex.NewAssessmentReportStatusId } );		
			_newAssessmentReportStatus = null;
		}

		/// <summary> setups the sync logic for member _newAssessmentReportStatus</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNewAssessmentReportStatus(IEntity2 relatedEntity)
		{
			if(_newAssessmentReportStatus!=relatedEntity)
			{
				DesetupSyncNewAssessmentReportStatus(true, true);
				_newAssessmentReportStatus = (ReportStatusEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _newAssessmentReportStatus, new PropertyChangedEventHandler( OnNewAssessmentReportStatusPropertyChanged ), "NewAssessmentReportStatus", CompanyEntity.Relations.ReportStatusEntityUsingNewAssessmentReportStatusId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNewAssessmentReportStatusPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _newAppointmentPsychometrist</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNewAppointmentPsychometrist(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _newAppointmentPsychometrist, new PropertyChangedEventHandler( OnNewAppointmentPsychometristPropertyChanged ), "NewAppointmentPsychometrist", CompanyEntity.Relations.UserEntityUsingNewAppointmentPsychometristId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)CompanyFieldIndex.NewAppointmentPsychometristId } );		
			_newAppointmentPsychometrist = null;
		}

		/// <summary> setups the sync logic for member _newAppointmentPsychometrist</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNewAppointmentPsychometrist(IEntity2 relatedEntity)
		{
			if(_newAppointmentPsychometrist!=relatedEntity)
			{
				DesetupSyncNewAppointmentPsychometrist(true, true);
				_newAppointmentPsychometrist = (UserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _newAppointmentPsychometrist, new PropertyChangedEventHandler( OnNewAppointmentPsychometristPropertyChanged ), "NewAppointmentPsychometrist", CompanyEntity.Relations.UserEntityUsingNewAppointmentPsychometristId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNewAppointmentPsychometristPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _newAppointmentPsychologist</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNewAppointmentPsychologist(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _newAppointmentPsychologist, new PropertyChangedEventHandler( OnNewAppointmentPsychologistPropertyChanged ), "NewAppointmentPsychologist", CompanyEntity.Relations.UserEntityUsingNewAppointmentPsychologistId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)CompanyFieldIndex.NewAppointmentPsychologistId } );		
			_newAppointmentPsychologist = null;
		}

		/// <summary> setups the sync logic for member _newAppointmentPsychologist</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNewAppointmentPsychologist(IEntity2 relatedEntity)
		{
			if(_newAppointmentPsychologist!=relatedEntity)
			{
				DesetupSyncNewAppointmentPsychologist(true, true);
				_newAppointmentPsychologist = (UserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _newAppointmentPsychologist, new PropertyChangedEventHandler( OnNewAppointmentPsychologistPropertyChanged ), "NewAppointmentPsychologist", CompanyEntity.Relations.UserEntityUsingNewAppointmentPsychologistId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNewAppointmentPsychologistPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CompanyEntity</param>
		/// <param name="fields">Fields of this entity</param>
		protected virtual void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			base.Fields = fields;
			base.IsNew=true;
			base.Validator = validator;
			InitClassMembers();

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static CompanyRelations Relations
		{
			get	{ return new CompanyRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AppointmentStatusInvoiceRate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAppointmentStatusInvoiceRates
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AppointmentStatusInvoiceRateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentStatusInvoiceRateEntityFactory))),
					(IEntityRelation)GetRelationsForField("AppointmentStatusInvoiceRates")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.AppointmentStatusInvoiceRateEntity, 0, null, null, null, null, "AppointmentStatusInvoiceRates", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Assessment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssessments
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AssessmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("Assessments")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.AssessmentEntity, 0, null, null, null, null, "Assessments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AssessmentTypeInvoiceAmount' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssessmentTypeInvoiceAmounts
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AssessmentTypeInvoiceAmountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentTypeInvoiceAmountEntityFactory))),
					(IEntityRelation)GetRelationsForField("AssessmentTypeInvoiceAmounts")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.AssessmentTypeInvoiceAmountEntity, 0, null, null, null, null, "AssessmentTypeInvoiceAmounts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CompanyAttribute' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCompanyAttributes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CompanyAttributeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyAttributeEntityFactory))),
					(IEntityRelation)GetRelationsForField("CompanyAttributes")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.CompanyAttributeEntity, 0, null, null, null, null, "CompanyAttributes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IssueInDisputeInvoiceAmount' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIssueInDisputeInvoiceAmounts
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<IssueInDisputeInvoiceAmountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IssueInDisputeInvoiceAmountEntityFactory))),
					(IEntityRelation)GetRelationsForField("IssueInDisputeInvoiceAmounts")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.IssueInDisputeInvoiceAmountEntity, 0, null, null, null, null, "IssueInDisputeInvoiceAmounts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PsychometristInvoiceAmount' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPsychometristInvoiceAmounts
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PsychometristInvoiceAmountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PsychometristInvoiceAmountEntityFactory))),
					(IEntityRelation)GetRelationsForField("PsychometristInvoiceAmounts")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.PsychometristInvoiceAmountEntity, 0, null, null, null, null, "PsychometristInvoiceAmounts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReferralSourceInvoiceConfiguration' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReferralSourceInvoiceConfigurations
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ReferralSourceInvoiceConfigurationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceInvoiceConfigurationEntityFactory))),
					(IEntityRelation)GetRelationsForField("ReferralSourceInvoiceConfigurations")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.ReferralSourceInvoiceConfigurationEntity, 0, null, null, null, null, "ReferralSourceInvoiceConfigurations", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUsers
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),
					(IEntityRelation)GetRelationsForField("Users")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.UserEntity, 0, null, null, null, null, "Users", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}























		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNewAppointmentLocation
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))),
					(IEntityRelation)GetRelationsForField("NewAppointmentLocation")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.AddressEntity, 0, null, null, null, null, "NewAppointmentLocation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddress
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))),
					(IEntityRelation)GetRelationsForField("Address")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AppointmentStatus' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNewAppointmentStatus
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentStatusEntityFactory))),
					(IEntityRelation)GetRelationsForField("NewAppointmentStatus")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.AppointmentStatusEntity, 0, null, null, null, null, "NewAppointmentStatus", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AssessmentType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNewAssessmentAssessmentType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("NewAssessmentAssessmentType")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.AssessmentTypeEntity, 0, null, null, null, null, "NewAssessmentAssessmentType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReportStatus' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNewAssessmentReportStatus
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ReportStatusEntityFactory))),
					(IEntityRelation)GetRelationsForField("NewAssessmentReportStatus")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.ReportStatusEntity, 0, null, null, null, null, "NewAssessmentReportStatus", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNewAppointmentPsychometrist
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),
					(IEntityRelation)GetRelationsForField("NewAppointmentPsychometrist")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.UserEntity, 0, null, null, null, null, "NewAppointmentPsychometrist", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNewAppointmentPsychologist
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),
					(IEntityRelation)GetRelationsForField("NewAppointmentPsychologist")[0], (int)PsychologicalServices.Data.EntityType.CompanyEntity, (int)PsychologicalServices.Data.EntityType.UserEntity, 0, null, null, null, null, "NewAppointmentPsychologist", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CompanyEntity.CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value
		/// pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return CompanyEntity.FieldsCustomProperties;}
		}

		/// <summary> The CompanyId property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."CompanyId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 CompanyId
		{
			get { return (System.Int32)GetValue((int)CompanyFieldIndex.CompanyId, true); }
			set	{ SetValue((int)CompanyFieldIndex.CompanyId, value); }
		}

		/// <summary> The Name property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)CompanyFieldIndex.Name, true); }
			set	{ SetValue((int)CompanyFieldIndex.Name, value); }
		}

		/// <summary> The IsActive property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)CompanyFieldIndex.IsActive, true); }
			set	{ SetValue((int)CompanyFieldIndex.IsActive, value); }
		}

		/// <summary> The AddressId property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."AddressId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> AddressId
		{
			get { return (Nullable<System.Int32>)GetValue((int)CompanyFieldIndex.AddressId, false); }
			set	{ SetValue((int)CompanyFieldIndex.AddressId, value); }
		}

		/// <summary> The Phone property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."Phone"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Phone
		{
			get { return (System.String)GetValue((int)CompanyFieldIndex.Phone, true); }
			set	{ SetValue((int)CompanyFieldIndex.Phone, value); }
		}

		/// <summary> The Fax property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."Fax"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Fax
		{
			get { return (System.String)GetValue((int)CompanyFieldIndex.Fax, true); }
			set	{ SetValue((int)CompanyFieldIndex.Fax, value); }
		}

		/// <summary> The Email property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."Email"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email
		{
			get { return (System.String)GetValue((int)CompanyFieldIndex.Email, true); }
			set	{ SetValue((int)CompanyFieldIndex.Email, value); }
		}

		/// <summary> The TaxId property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."TaxId"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TaxId
		{
			get { return (System.String)GetValue((int)CompanyFieldIndex.TaxId, true); }
			set	{ SetValue((int)CompanyFieldIndex.TaxId, value); }
		}

		/// <summary> The NewAppointmentTime property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."NewAppointmentTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 NewAppointmentTime
		{
			get { return (System.Int64)GetValue((int)CompanyFieldIndex.NewAppointmentTime, true); }
			set	{ SetValue((int)CompanyFieldIndex.NewAppointmentTime, value); }
		}

		/// <summary> The NewAppointmentLocationId property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."NewAppointmentLocationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> NewAppointmentLocationId
		{
			get { return (Nullable<System.Int32>)GetValue((int)CompanyFieldIndex.NewAppointmentLocationId, false); }
			set	{ SetValue((int)CompanyFieldIndex.NewAppointmentLocationId, value); }
		}

		/// <summary> The NewAppointmentPsychologistId property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."NewAppointmentPsychologistId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> NewAppointmentPsychologistId
		{
			get { return (Nullable<System.Int32>)GetValue((int)CompanyFieldIndex.NewAppointmentPsychologistId, false); }
			set	{ SetValue((int)CompanyFieldIndex.NewAppointmentPsychologistId, value); }
		}

		/// <summary> The NewAppointmentPsychometristId property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."NewAppointmentPsychometristId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> NewAppointmentPsychometristId
		{
			get { return (Nullable<System.Int32>)GetValue((int)CompanyFieldIndex.NewAppointmentPsychometristId, false); }
			set	{ SetValue((int)CompanyFieldIndex.NewAppointmentPsychometristId, value); }
		}

		/// <summary> The NewAppointmentStatusId property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."NewAppointmentStatusId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> NewAppointmentStatusId
		{
			get { return (Nullable<System.Int32>)GetValue((int)CompanyFieldIndex.NewAppointmentStatusId, false); }
			set	{ SetValue((int)CompanyFieldIndex.NewAppointmentStatusId, value); }
		}

		/// <summary> The NewAssessmentReportStatusId property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."NewAssessmentReportStatusId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> NewAssessmentReportStatusId
		{
			get { return (Nullable<System.Int32>)GetValue((int)CompanyFieldIndex.NewAssessmentReportStatusId, false); }
			set	{ SetValue((int)CompanyFieldIndex.NewAssessmentReportStatusId, value); }
		}

		/// <summary> The NewAssessmentSummaryNoteText property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."NewAssessmentSummaryNoteText"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String NewAssessmentSummaryNoteText
		{
			get { return (System.String)GetValue((int)CompanyFieldIndex.NewAssessmentSummaryNoteText, true); }
			set	{ SetValue((int)CompanyFieldIndex.NewAssessmentSummaryNoteText, value); }
		}

		/// <summary> The Timezone property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."Timezone"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Timezone
		{
			get { return (System.String)GetValue((int)CompanyFieldIndex.Timezone, true); }
			set	{ SetValue((int)CompanyFieldIndex.Timezone, value); }
		}

		/// <summary> The ReplyToEmail property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."ReplyToEmail"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ReplyToEmail
		{
			get { return (System.String)GetValue((int)CompanyFieldIndex.ReplyToEmail, true); }
			set	{ SetValue((int)CompanyFieldIndex.ReplyToEmail, value); }
		}

		/// <summary> The NewAssessmentAssessmentTypeId property of the Entity Company<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Companies"."NewAssessmentAssessmentTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> NewAssessmentAssessmentTypeId
		{
			get { return (Nullable<System.Int32>)GetValue((int)CompanyFieldIndex.NewAssessmentAssessmentTypeId, false); }
			set	{ SetValue((int)CompanyFieldIndex.NewAssessmentAssessmentTypeId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AppointmentStatusInvoiceRateEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AppointmentStatusInvoiceRateEntity))]
		public virtual EntityCollection<AppointmentStatusInvoiceRateEntity> AppointmentStatusInvoiceRates
		{
			get
			{
				if(_appointmentStatusInvoiceRates==null)
				{
					_appointmentStatusInvoiceRates = new EntityCollection<AppointmentStatusInvoiceRateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentStatusInvoiceRateEntityFactory)));
					_appointmentStatusInvoiceRates.SetContainingEntityInfo(this, "Company");
				}
				return _appointmentStatusInvoiceRates;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AssessmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AssessmentEntity))]
		public virtual EntityCollection<AssessmentEntity> Assessments
		{
			get
			{
				if(_assessments==null)
				{
					_assessments = new EntityCollection<AssessmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentEntityFactory)));
					_assessments.SetContainingEntityInfo(this, "Company");
				}
				return _assessments;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AssessmentTypeInvoiceAmountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AssessmentTypeInvoiceAmountEntity))]
		public virtual EntityCollection<AssessmentTypeInvoiceAmountEntity> AssessmentTypeInvoiceAmounts
		{
			get
			{
				if(_assessmentTypeInvoiceAmounts==null)
				{
					_assessmentTypeInvoiceAmounts = new EntityCollection<AssessmentTypeInvoiceAmountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentTypeInvoiceAmountEntityFactory)));
					_assessmentTypeInvoiceAmounts.SetContainingEntityInfo(this, "Company");
				}
				return _assessmentTypeInvoiceAmounts;
			}
		}


		/// <summary> Gets the EntityCollection with the related entities of type 'CompanyAttributeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CompanyAttributeEntity))]
		public virtual EntityCollection<CompanyAttributeEntity> CompanyAttributes
		{
			get
			{
				if(_companyAttributes==null)
				{
					_companyAttributes = new EntityCollection<CompanyAttributeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyAttributeEntityFactory)));
					_companyAttributes.SetContainingEntityInfo(this, "Company");
				}
				return _companyAttributes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IssueInDisputeInvoiceAmountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IssueInDisputeInvoiceAmountEntity))]
		public virtual EntityCollection<IssueInDisputeInvoiceAmountEntity> IssueInDisputeInvoiceAmounts
		{
			get
			{
				if(_issueInDisputeInvoiceAmounts==null)
				{
					_issueInDisputeInvoiceAmounts = new EntityCollection<IssueInDisputeInvoiceAmountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IssueInDisputeInvoiceAmountEntityFactory)));
					_issueInDisputeInvoiceAmounts.SetContainingEntityInfo(this, "Company");
				}
				return _issueInDisputeInvoiceAmounts;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PsychometristInvoiceAmountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PsychometristInvoiceAmountEntity))]
		public virtual EntityCollection<PsychometristInvoiceAmountEntity> PsychometristInvoiceAmounts
		{
			get
			{
				if(_psychometristInvoiceAmounts==null)
				{
					_psychometristInvoiceAmounts = new EntityCollection<PsychometristInvoiceAmountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PsychometristInvoiceAmountEntityFactory)));
					_psychometristInvoiceAmounts.SetContainingEntityInfo(this, "Company");
				}
				return _psychometristInvoiceAmounts;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ReferralSourceInvoiceConfigurationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ReferralSourceInvoiceConfigurationEntity))]
		public virtual EntityCollection<ReferralSourceInvoiceConfigurationEntity> ReferralSourceInvoiceConfigurations
		{
			get
			{
				if(_referralSourceInvoiceConfigurations==null)
				{
					_referralSourceInvoiceConfigurations = new EntityCollection<ReferralSourceInvoiceConfigurationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceInvoiceConfigurationEntityFactory)));
					_referralSourceInvoiceConfigurations.SetContainingEntityInfo(this, "Company");
				}
				return _referralSourceInvoiceConfigurations;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UserEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(UserEntity))]
		public virtual EntityCollection<UserEntity> Users
		{
			get
			{
				if(_users==null)
				{
					_users = new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory)));
					_users.SetContainingEntityInfo(this, "Company");
				}
				return _users;
			}
		}























		/// <summary> Gets / sets related entity of type 'AddressEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AddressEntity NewAppointmentLocation
		{
			get
			{
				return _newAppointmentLocation;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNewAppointmentLocation(value);
				}
				else
				{
					if(value==null)
					{
						if(_newAppointmentLocation != null)
						{
							UnsetRelatedEntity(_newAppointmentLocation, "NewAppointmentLocation");
						}
					}
					else
					{
						if(_newAppointmentLocation!=value)
						{
							SetRelatedEntity((IEntity2)value, "NewAppointmentLocation");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'AddressEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AddressEntity Address
		{
			get
			{
				return _address;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAddress(value);
				}
				else
				{
					if(value==null)
					{
						if(_address != null)
						{
							_address.UnsetRelatedEntity(this, "Companies");
						}
					}
					else
					{
						if(_address!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Companies");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'AppointmentStatusEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AppointmentStatusEntity NewAppointmentStatus
		{
			get
			{
				return _newAppointmentStatus;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNewAppointmentStatus(value);
				}
				else
				{
					if(value==null)
					{
						if(_newAppointmentStatus != null)
						{
							UnsetRelatedEntity(_newAppointmentStatus, "NewAppointmentStatus");
						}
					}
					else
					{
						if(_newAppointmentStatus!=value)
						{
							SetRelatedEntity((IEntity2)value, "NewAppointmentStatus");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'AssessmentTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AssessmentTypeEntity NewAssessmentAssessmentType
		{
			get
			{
				return _newAssessmentAssessmentType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNewAssessmentAssessmentType(value);
				}
				else
				{
					if(value==null)
					{
						if(_newAssessmentAssessmentType != null)
						{
							_newAssessmentAssessmentType.UnsetRelatedEntity(this, "Companies");
						}
					}
					else
					{
						if(_newAssessmentAssessmentType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Companies");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ReportStatusEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ReportStatusEntity NewAssessmentReportStatus
		{
			get
			{
				return _newAssessmentReportStatus;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNewAssessmentReportStatus(value);
				}
				else
				{
					if(value==null)
					{
						if(_newAssessmentReportStatus != null)
						{
							UnsetRelatedEntity(_newAssessmentReportStatus, "NewAssessmentReportStatus");
						}
					}
					else
					{
						if(_newAssessmentReportStatus!=value)
						{
							SetRelatedEntity((IEntity2)value, "NewAssessmentReportStatus");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual UserEntity NewAppointmentPsychometrist
		{
			get
			{
				return _newAppointmentPsychometrist;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNewAppointmentPsychometrist(value);
				}
				else
				{
					if(value==null)
					{
						if(_newAppointmentPsychometrist != null)
						{
							UnsetRelatedEntity(_newAppointmentPsychometrist, "NewAppointmentPsychometrist");
						}
					}
					else
					{
						if(_newAppointmentPsychometrist!=value)
						{
							SetRelatedEntity((IEntity2)value, "NewAppointmentPsychometrist");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual UserEntity NewAppointmentPsychologist
		{
			get
			{
				return _newAppointmentPsychologist;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNewAppointmentPsychologist(value);
				}
				else
				{
					if(value==null)
					{
						if(_newAppointmentPsychologist != null)
						{
							UnsetRelatedEntity(_newAppointmentPsychologist, "NewAppointmentPsychologist");
						}
					}
					else
					{
						if(_newAppointmentPsychologist!=value)
						{
							SetRelatedEntity((IEntity2)value, "NewAppointmentPsychologist");
						}
					}
				}
			}
		}

	
		
		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}
		
		/// <summary>Returns the PsychologicalServices.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)PsychologicalServices.Data.EntityType.CompanyEntity; }
		}
		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}
