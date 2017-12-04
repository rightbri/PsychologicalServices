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
	/// Entity class which represents the entity 'ReferralSource'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ReferralSourceEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AppointmentStatusInvoiceRateEntity> _appointmentStatusInvoiceRates;
		private EntityCollection<AssessmentEntity> _assessments;
		private EntityCollection<AssessmentTypeInvoiceAmountEntity> _assessmentTypeInvoiceAmounts;
		private EntityCollection<ReferralSourceInvoiceConfigurationEntity> _referralSourceInvoiceConfiguration;
		private EntityCollection<AppointmentSequenceEntity> _appointmentSequenceCollectionViaAppointmentStatusInvoiceRates;
		private EntityCollection<AppointmentStatusEntity> _appointmentStatusCollectionViaAppointmentStatusInvoiceRates;
		private EntityCollection<AssessmentTypeEntity> _assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts;

		private EntityCollection<CompanyEntity> _companyCollectionViaAssessmentTypeInvoiceAmounts;

		private EntityCollection<CompanyEntity> _companyCollectionViaReferralSourceInvoiceConfiguration;
		private EntityCollection<CompanyEntity> _companyCollectionViaAppointmentStatusInvoiceRates;









		private AddressEntity _address;
		private ReferralSourceTypeEntity _referralSourceType;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Address</summary>
			public static readonly string Address = "Address";
			/// <summary>Member name ReferralSourceType</summary>
			public static readonly string ReferralSourceType = "ReferralSourceType";
			/// <summary>Member name AppointmentStatusInvoiceRates</summary>
			public static readonly string AppointmentStatusInvoiceRates = "AppointmentStatusInvoiceRates";
			/// <summary>Member name Assessments</summary>
			public static readonly string Assessments = "Assessments";
			/// <summary>Member name AssessmentTypeInvoiceAmounts</summary>
			public static readonly string AssessmentTypeInvoiceAmounts = "AssessmentTypeInvoiceAmounts";
			/// <summary>Member name ReferralSourceInvoiceConfiguration</summary>
			public static readonly string ReferralSourceInvoiceConfiguration = "ReferralSourceInvoiceConfiguration";
			/// <summary>Member name AppointmentSequenceCollectionViaAppointmentStatusInvoiceRates</summary>
			public static readonly string AppointmentSequenceCollectionViaAppointmentStatusInvoiceRates = "AppointmentSequenceCollectionViaAppointmentStatusInvoiceRates";
			/// <summary>Member name AppointmentStatusCollectionViaAppointmentStatusInvoiceRates</summary>
			public static readonly string AppointmentStatusCollectionViaAppointmentStatusInvoiceRates = "AppointmentStatusCollectionViaAppointmentStatusInvoiceRates";
			/// <summary>Member name AssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts</summary>
			public static readonly string AssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts = "AssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts";

			/// <summary>Member name CompanyCollectionViaAssessmentTypeInvoiceAmounts</summary>
			public static readonly string CompanyCollectionViaAssessmentTypeInvoiceAmounts = "CompanyCollectionViaAssessmentTypeInvoiceAmounts";

			/// <summary>Member name CompanyCollectionViaReferralSourceInvoiceConfiguration</summary>
			public static readonly string CompanyCollectionViaReferralSourceInvoiceConfiguration = "CompanyCollectionViaReferralSourceInvoiceConfiguration";
			/// <summary>Member name CompanyCollectionViaAppointmentStatusInvoiceRates</summary>
			public static readonly string CompanyCollectionViaAppointmentStatusInvoiceRates = "CompanyCollectionViaAppointmentStatusInvoiceRates";










		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ReferralSourceEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ReferralSourceEntity():base("ReferralSourceEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ReferralSourceEntity(IEntityFields2 fields):base("ReferralSourceEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ReferralSourceEntity</param>
		public ReferralSourceEntity(IValidator validator):base("ReferralSourceEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="referralSourceId">PK value for ReferralSource which data should be fetched into this ReferralSource object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ReferralSourceEntity(System.Int32 referralSourceId):base("ReferralSourceEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ReferralSourceId = referralSourceId;
		}

		/// <summary> CTor</summary>
		/// <param name="referralSourceId">PK value for ReferralSource which data should be fetched into this ReferralSource object</param>
		/// <param name="validator">The custom validator object for this ReferralSourceEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ReferralSourceEntity(System.Int32 referralSourceId, IValidator validator):base("ReferralSourceEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ReferralSourceId = referralSourceId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ReferralSourceEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_appointmentStatusInvoiceRates = (EntityCollection<AppointmentStatusInvoiceRateEntity>)info.GetValue("_appointmentStatusInvoiceRates", typeof(EntityCollection<AppointmentStatusInvoiceRateEntity>));
				_assessments = (EntityCollection<AssessmentEntity>)info.GetValue("_assessments", typeof(EntityCollection<AssessmentEntity>));
				_assessmentTypeInvoiceAmounts = (EntityCollection<AssessmentTypeInvoiceAmountEntity>)info.GetValue("_assessmentTypeInvoiceAmounts", typeof(EntityCollection<AssessmentTypeInvoiceAmountEntity>));
				_referralSourceInvoiceConfiguration = (EntityCollection<ReferralSourceInvoiceConfigurationEntity>)info.GetValue("_referralSourceInvoiceConfiguration", typeof(EntityCollection<ReferralSourceInvoiceConfigurationEntity>));
				_appointmentSequenceCollectionViaAppointmentStatusInvoiceRates = (EntityCollection<AppointmentSequenceEntity>)info.GetValue("_appointmentSequenceCollectionViaAppointmentStatusInvoiceRates", typeof(EntityCollection<AppointmentSequenceEntity>));
				_appointmentStatusCollectionViaAppointmentStatusInvoiceRates = (EntityCollection<AppointmentStatusEntity>)info.GetValue("_appointmentStatusCollectionViaAppointmentStatusInvoiceRates", typeof(EntityCollection<AppointmentStatusEntity>));
				_assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts = (EntityCollection<AssessmentTypeEntity>)info.GetValue("_assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts", typeof(EntityCollection<AssessmentTypeEntity>));

				_companyCollectionViaAssessmentTypeInvoiceAmounts = (EntityCollection<CompanyEntity>)info.GetValue("_companyCollectionViaAssessmentTypeInvoiceAmounts", typeof(EntityCollection<CompanyEntity>));

				_companyCollectionViaReferralSourceInvoiceConfiguration = (EntityCollection<CompanyEntity>)info.GetValue("_companyCollectionViaReferralSourceInvoiceConfiguration", typeof(EntityCollection<CompanyEntity>));
				_companyCollectionViaAppointmentStatusInvoiceRates = (EntityCollection<CompanyEntity>)info.GetValue("_companyCollectionViaAppointmentStatusInvoiceRates", typeof(EntityCollection<CompanyEntity>));









				_address = (AddressEntity)info.GetValue("_address", typeof(AddressEntity));
				if(_address!=null)
				{
					_address.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_referralSourceType = (ReferralSourceTypeEntity)info.GetValue("_referralSourceType", typeof(ReferralSourceTypeEntity));
				if(_referralSourceType!=null)
				{
					_referralSourceType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ReferralSourceFieldIndex)fieldIndex)
			{
				case ReferralSourceFieldIndex.ReferralSourceTypeId:
					DesetupSyncReferralSourceType(true, false);
					break;
				case ReferralSourceFieldIndex.AddressId:
					DesetupSyncAddress(true, false);
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
				case "Address":
					this.Address = (AddressEntity)entity;
					break;
				case "ReferralSourceType":
					this.ReferralSourceType = (ReferralSourceTypeEntity)entity;
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
				case "ReferralSourceInvoiceConfiguration":
					this.ReferralSourceInvoiceConfiguration.Add((ReferralSourceInvoiceConfigurationEntity)entity);
					break;
				case "AppointmentSequenceCollectionViaAppointmentStatusInvoiceRates":
					this.AppointmentSequenceCollectionViaAppointmentStatusInvoiceRates.IsReadOnly = false;
					this.AppointmentSequenceCollectionViaAppointmentStatusInvoiceRates.Add((AppointmentSequenceEntity)entity);
					this.AppointmentSequenceCollectionViaAppointmentStatusInvoiceRates.IsReadOnly = true;
					break;
				case "AppointmentStatusCollectionViaAppointmentStatusInvoiceRates":
					this.AppointmentStatusCollectionViaAppointmentStatusInvoiceRates.IsReadOnly = false;
					this.AppointmentStatusCollectionViaAppointmentStatusInvoiceRates.Add((AppointmentStatusEntity)entity);
					this.AppointmentStatusCollectionViaAppointmentStatusInvoiceRates.IsReadOnly = true;
					break;
				case "AssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts":
					this.AssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts.IsReadOnly = false;
					this.AssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts.Add((AssessmentTypeEntity)entity);
					this.AssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts.IsReadOnly = true;
					break;

				case "CompanyCollectionViaAssessmentTypeInvoiceAmounts":
					this.CompanyCollectionViaAssessmentTypeInvoiceAmounts.IsReadOnly = false;
					this.CompanyCollectionViaAssessmentTypeInvoiceAmounts.Add((CompanyEntity)entity);
					this.CompanyCollectionViaAssessmentTypeInvoiceAmounts.IsReadOnly = true;
					break;

				case "CompanyCollectionViaReferralSourceInvoiceConfiguration":
					this.CompanyCollectionViaReferralSourceInvoiceConfiguration.IsReadOnly = false;
					this.CompanyCollectionViaReferralSourceInvoiceConfiguration.Add((CompanyEntity)entity);
					this.CompanyCollectionViaReferralSourceInvoiceConfiguration.IsReadOnly = true;
					break;
				case "CompanyCollectionViaAppointmentStatusInvoiceRates":
					this.CompanyCollectionViaAppointmentStatusInvoiceRates.IsReadOnly = false;
					this.CompanyCollectionViaAppointmentStatusInvoiceRates.Add((CompanyEntity)entity);
					this.CompanyCollectionViaAppointmentStatusInvoiceRates.IsReadOnly = true;
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
			return ReferralSourceEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Address":
					toReturn.Add(ReferralSourceEntity.Relations.AddressEntityUsingAddressId);
					break;
				case "ReferralSourceType":
					toReturn.Add(ReferralSourceEntity.Relations.ReferralSourceTypeEntityUsingReferralSourceTypeId);
					break;
				case "AppointmentStatusInvoiceRates":
					toReturn.Add(ReferralSourceEntity.Relations.AppointmentStatusInvoiceRateEntityUsingReferralSourceId);
					break;
				case "Assessments":
					toReturn.Add(ReferralSourceEntity.Relations.AssessmentEntityUsingReferralSourceId);
					break;
				case "AssessmentTypeInvoiceAmounts":
					toReturn.Add(ReferralSourceEntity.Relations.AssessmentTypeInvoiceAmountEntityUsingReferralSourceId);
					break;
				case "ReferralSourceInvoiceConfiguration":
					toReturn.Add(ReferralSourceEntity.Relations.ReferralSourceInvoiceConfigurationEntityUsingReferralSourceId);
					break;
				case "AppointmentSequenceCollectionViaAppointmentStatusInvoiceRates":
					toReturn.Add(ReferralSourceEntity.Relations.AppointmentStatusInvoiceRateEntityUsingReferralSourceId, "ReferralSourceEntity__", "AppointmentStatusInvoiceRate_", JoinHint.None);
					toReturn.Add(AppointmentStatusInvoiceRateEntity.Relations.AppointmentSequenceEntityUsingAppointmentSequenceId, "AppointmentStatusInvoiceRate_", string.Empty, JoinHint.None);
					break;
				case "AppointmentStatusCollectionViaAppointmentStatusInvoiceRates":
					toReturn.Add(ReferralSourceEntity.Relations.AppointmentStatusInvoiceRateEntityUsingReferralSourceId, "ReferralSourceEntity__", "AppointmentStatusInvoiceRate_", JoinHint.None);
					toReturn.Add(AppointmentStatusInvoiceRateEntity.Relations.AppointmentStatusEntityUsingAppointmentStatusId, "AppointmentStatusInvoiceRate_", string.Empty, JoinHint.None);
					break;
				case "AssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts":
					toReturn.Add(ReferralSourceEntity.Relations.AssessmentTypeInvoiceAmountEntityUsingReferralSourceId, "ReferralSourceEntity__", "AssessmentTypeInvoiceAmount_", JoinHint.None);
					toReturn.Add(AssessmentTypeInvoiceAmountEntity.Relations.AssessmentTypeEntityUsingAssessmentTypeId, "AssessmentTypeInvoiceAmount_", string.Empty, JoinHint.None);
					break;

				case "CompanyCollectionViaAssessmentTypeInvoiceAmounts":
					toReturn.Add(ReferralSourceEntity.Relations.AssessmentTypeInvoiceAmountEntityUsingReferralSourceId, "ReferralSourceEntity__", "AssessmentTypeInvoiceAmount_", JoinHint.None);
					toReturn.Add(AssessmentTypeInvoiceAmountEntity.Relations.CompanyEntityUsingCompanyId, "AssessmentTypeInvoiceAmount_", string.Empty, JoinHint.None);
					break;

				case "CompanyCollectionViaReferralSourceInvoiceConfiguration":
					toReturn.Add(ReferralSourceEntity.Relations.ReferralSourceInvoiceConfigurationEntityUsingReferralSourceId, "ReferralSourceEntity__", "ReferralSourceInvoiceConfiguration_", JoinHint.None);
					toReturn.Add(ReferralSourceInvoiceConfigurationEntity.Relations.CompanyEntityUsingCompanyId, "ReferralSourceInvoiceConfiguration_", string.Empty, JoinHint.None);
					break;
				case "CompanyCollectionViaAppointmentStatusInvoiceRates":
					toReturn.Add(ReferralSourceEntity.Relations.AppointmentStatusInvoiceRateEntityUsingReferralSourceId, "ReferralSourceEntity__", "AppointmentStatusInvoiceRate_", JoinHint.None);
					toReturn.Add(AppointmentStatusInvoiceRateEntity.Relations.CompanyEntityUsingCompanyId, "AppointmentStatusInvoiceRate_", string.Empty, JoinHint.None);
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
			int numberOfOneWayRelations = 0;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));



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
				case "Address":
					SetupSyncAddress(relatedEntity);
					break;
				case "ReferralSourceType":
					SetupSyncReferralSourceType(relatedEntity);
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
				case "ReferralSourceInvoiceConfiguration":
					this.ReferralSourceInvoiceConfiguration.Add((ReferralSourceInvoiceConfigurationEntity)relatedEntity);
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
				case "Address":
					DesetupSyncAddress(false, true);
					break;
				case "ReferralSourceType":
					DesetupSyncReferralSourceType(false, true);
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
				case "ReferralSourceInvoiceConfiguration":
					base.PerformRelatedEntityRemoval(this.ReferralSourceInvoiceConfiguration, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_address!=null)
			{
				toReturn.Add(_address);
			}
			if(_referralSourceType!=null)
			{
				toReturn.Add(_referralSourceType);
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
			toReturn.Add(this.ReferralSourceInvoiceConfiguration);

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
				info.AddValue("_referralSourceInvoiceConfiguration", ((_referralSourceInvoiceConfiguration!=null) && (_referralSourceInvoiceConfiguration.Count>0) && !this.MarkedForDeletion)?_referralSourceInvoiceConfiguration:null);
				info.AddValue("_appointmentSequenceCollectionViaAppointmentStatusInvoiceRates", ((_appointmentSequenceCollectionViaAppointmentStatusInvoiceRates!=null) && (_appointmentSequenceCollectionViaAppointmentStatusInvoiceRates.Count>0) && !this.MarkedForDeletion)?_appointmentSequenceCollectionViaAppointmentStatusInvoiceRates:null);
				info.AddValue("_appointmentStatusCollectionViaAppointmentStatusInvoiceRates", ((_appointmentStatusCollectionViaAppointmentStatusInvoiceRates!=null) && (_appointmentStatusCollectionViaAppointmentStatusInvoiceRates.Count>0) && !this.MarkedForDeletion)?_appointmentStatusCollectionViaAppointmentStatusInvoiceRates:null);
				info.AddValue("_assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts", ((_assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts!=null) && (_assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts.Count>0) && !this.MarkedForDeletion)?_assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts:null);

				info.AddValue("_companyCollectionViaAssessmentTypeInvoiceAmounts", ((_companyCollectionViaAssessmentTypeInvoiceAmounts!=null) && (_companyCollectionViaAssessmentTypeInvoiceAmounts.Count>0) && !this.MarkedForDeletion)?_companyCollectionViaAssessmentTypeInvoiceAmounts:null);

				info.AddValue("_companyCollectionViaReferralSourceInvoiceConfiguration", ((_companyCollectionViaReferralSourceInvoiceConfiguration!=null) && (_companyCollectionViaReferralSourceInvoiceConfiguration.Count>0) && !this.MarkedForDeletion)?_companyCollectionViaReferralSourceInvoiceConfiguration:null);
				info.AddValue("_companyCollectionViaAppointmentStatusInvoiceRates", ((_companyCollectionViaAppointmentStatusInvoiceRates!=null) && (_companyCollectionViaAppointmentStatusInvoiceRates.Count>0) && !this.MarkedForDeletion)?_companyCollectionViaAppointmentStatusInvoiceRates:null);









				info.AddValue("_address", (!this.MarkedForDeletion?_address:null));
				info.AddValue("_referralSourceType", (!this.MarkedForDeletion?_referralSourceType:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ReferralSourceFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ReferralSourceFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ReferralSourceRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AppointmentStatusInvoiceRate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAppointmentStatusInvoiceRates()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AppointmentStatusInvoiceRateFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Assessment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AssessmentTypeInvoiceAmount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessmentTypeInvoiceAmounts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentTypeInvoiceAmountFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ReferralSourceInvoiceConfiguration' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReferralSourceInvoiceConfiguration()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceInvoiceConfigurationFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AppointmentSequence' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAppointmentSequenceCollectionViaAppointmentStatusInvoiceRates()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AppointmentSequenceCollectionViaAppointmentStatusInvoiceRates"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId, "ReferralSourceEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AppointmentStatus' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAppointmentStatusCollectionViaAppointmentStatusInvoiceRates()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AppointmentStatusCollectionViaAppointmentStatusInvoiceRates"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId, "ReferralSourceEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AssessmentType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId, "ReferralSourceEntity__"));
			return bucket;
		}


		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Company' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCompanyCollectionViaAssessmentTypeInvoiceAmounts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CompanyCollectionViaAssessmentTypeInvoiceAmounts"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId, "ReferralSourceEntity__"));
			return bucket;
		}


		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Company' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCompanyCollectionViaReferralSourceInvoiceConfiguration()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CompanyCollectionViaReferralSourceInvoiceConfiguration"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId, "ReferralSourceEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Company' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCompanyCollectionViaAppointmentStatusInvoiceRates()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CompanyCollectionViaAppointmentStatusInvoiceRates"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId, "ReferralSourceEntity__"));
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
		/// the related entity of type 'ReferralSourceType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReferralSourceType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceTypeFields.ReferralSourceTypeId, null, ComparisonOperator.Equal, this.ReferralSourceTypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(PsychologicalServices.Data.EntityType.ReferralSourceEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceEntityFactory));
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
			collectionsQueue.Enqueue(this._referralSourceInvoiceConfiguration);
			collectionsQueue.Enqueue(this._appointmentSequenceCollectionViaAppointmentStatusInvoiceRates);
			collectionsQueue.Enqueue(this._appointmentStatusCollectionViaAppointmentStatusInvoiceRates);
			collectionsQueue.Enqueue(this._assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts);

			collectionsQueue.Enqueue(this._companyCollectionViaAssessmentTypeInvoiceAmounts);

			collectionsQueue.Enqueue(this._companyCollectionViaReferralSourceInvoiceConfiguration);
			collectionsQueue.Enqueue(this._companyCollectionViaAppointmentStatusInvoiceRates);









		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._appointmentStatusInvoiceRates = (EntityCollection<AppointmentStatusInvoiceRateEntity>) collectionsQueue.Dequeue();
			this._assessments = (EntityCollection<AssessmentEntity>) collectionsQueue.Dequeue();
			this._assessmentTypeInvoiceAmounts = (EntityCollection<AssessmentTypeInvoiceAmountEntity>) collectionsQueue.Dequeue();
			this._referralSourceInvoiceConfiguration = (EntityCollection<ReferralSourceInvoiceConfigurationEntity>) collectionsQueue.Dequeue();
			this._appointmentSequenceCollectionViaAppointmentStatusInvoiceRates = (EntityCollection<AppointmentSequenceEntity>) collectionsQueue.Dequeue();
			this._appointmentStatusCollectionViaAppointmentStatusInvoiceRates = (EntityCollection<AppointmentStatusEntity>) collectionsQueue.Dequeue();
			this._assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts = (EntityCollection<AssessmentTypeEntity>) collectionsQueue.Dequeue();

			this._companyCollectionViaAssessmentTypeInvoiceAmounts = (EntityCollection<CompanyEntity>) collectionsQueue.Dequeue();

			this._companyCollectionViaReferralSourceInvoiceConfiguration = (EntityCollection<CompanyEntity>) collectionsQueue.Dequeue();
			this._companyCollectionViaAppointmentStatusInvoiceRates = (EntityCollection<CompanyEntity>) collectionsQueue.Dequeue();









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
			if (this._referralSourceInvoiceConfiguration != null)
			{
				return true;
			}
			if (this._appointmentSequenceCollectionViaAppointmentStatusInvoiceRates != null)
			{
				return true;
			}
			if (this._appointmentStatusCollectionViaAppointmentStatusInvoiceRates != null)
			{
				return true;
			}
			if (this._assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts != null)
			{
				return true;
			}

			if (this._companyCollectionViaAssessmentTypeInvoiceAmounts != null)
			{
				return true;
			}

			if (this._companyCollectionViaReferralSourceInvoiceConfiguration != null)
			{
				return true;
			}
			if (this._companyCollectionViaAppointmentStatusInvoiceRates != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReferralSourceInvoiceConfigurationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceInvoiceConfigurationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AppointmentSequenceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentSequenceEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AppointmentStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentStatusEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AssessmentTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentTypeEntityFactory))) : null);

			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CompanyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory))) : null);

			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CompanyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CompanyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory))) : null);









		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Address", _address);
			toReturn.Add("ReferralSourceType", _referralSourceType);
			toReturn.Add("AppointmentStatusInvoiceRates", _appointmentStatusInvoiceRates);
			toReturn.Add("Assessments", _assessments);
			toReturn.Add("AssessmentTypeInvoiceAmounts", _assessmentTypeInvoiceAmounts);
			toReturn.Add("ReferralSourceInvoiceConfiguration", _referralSourceInvoiceConfiguration);
			toReturn.Add("AppointmentSequenceCollectionViaAppointmentStatusInvoiceRates", _appointmentSequenceCollectionViaAppointmentStatusInvoiceRates);
			toReturn.Add("AppointmentStatusCollectionViaAppointmentStatusInvoiceRates", _appointmentStatusCollectionViaAppointmentStatusInvoiceRates);
			toReturn.Add("AssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts", _assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts);

			toReturn.Add("CompanyCollectionViaAssessmentTypeInvoiceAmounts", _companyCollectionViaAssessmentTypeInvoiceAmounts);

			toReturn.Add("CompanyCollectionViaReferralSourceInvoiceConfiguration", _companyCollectionViaReferralSourceInvoiceConfiguration);
			toReturn.Add("CompanyCollectionViaAppointmentStatusInvoiceRates", _companyCollectionViaAppointmentStatusInvoiceRates);










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
			if(_referralSourceInvoiceConfiguration!=null)
			{
				_referralSourceInvoiceConfiguration.ActiveContext = base.ActiveContext;
			}
			if(_appointmentSequenceCollectionViaAppointmentStatusInvoiceRates!=null)
			{
				_appointmentSequenceCollectionViaAppointmentStatusInvoiceRates.ActiveContext = base.ActiveContext;
			}
			if(_appointmentStatusCollectionViaAppointmentStatusInvoiceRates!=null)
			{
				_appointmentStatusCollectionViaAppointmentStatusInvoiceRates.ActiveContext = base.ActiveContext;
			}
			if(_assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts!=null)
			{
				_assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts.ActiveContext = base.ActiveContext;
			}

			if(_companyCollectionViaAssessmentTypeInvoiceAmounts!=null)
			{
				_companyCollectionViaAssessmentTypeInvoiceAmounts.ActiveContext = base.ActiveContext;
			}

			if(_companyCollectionViaReferralSourceInvoiceConfiguration!=null)
			{
				_companyCollectionViaReferralSourceInvoiceConfiguration.ActiveContext = base.ActiveContext;
			}
			if(_companyCollectionViaAppointmentStatusInvoiceRates!=null)
			{
				_companyCollectionViaAppointmentStatusInvoiceRates.ActiveContext = base.ActiveContext;
			}









			if(_address!=null)
			{
				_address.ActiveContext = base.ActiveContext;
			}
			if(_referralSourceType!=null)
			{
				_referralSourceType.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_appointmentStatusInvoiceRates = null;
			_assessments = null;
			_assessmentTypeInvoiceAmounts = null;
			_referralSourceInvoiceConfiguration = null;
			_appointmentSequenceCollectionViaAppointmentStatusInvoiceRates = null;
			_appointmentStatusCollectionViaAppointmentStatusInvoiceRates = null;
			_assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts = null;

			_companyCollectionViaAssessmentTypeInvoiceAmounts = null;

			_companyCollectionViaReferralSourceInvoiceConfiguration = null;
			_companyCollectionViaAppointmentStatusInvoiceRates = null;









			_address = null;
			_referralSourceType = null;

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

			_fieldsCustomProperties.Add("ReferralSourceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReferralSourceTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InvoicesContactEmail", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _address</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAddress(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", ReferralSourceEntity.Relations.AddressEntityUsingAddressId, true, signalRelatedEntity, "ReferralSources", resetFKFields, new int[] { (int)ReferralSourceFieldIndex.AddressId } );		
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
				base.PerformSetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", ReferralSourceEntity.Relations.AddressEntityUsingAddressId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _referralSourceType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncReferralSourceType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _referralSourceType, new PropertyChangedEventHandler( OnReferralSourceTypePropertyChanged ), "ReferralSourceType", ReferralSourceEntity.Relations.ReferralSourceTypeEntityUsingReferralSourceTypeId, true, signalRelatedEntity, "ReferralSources", resetFKFields, new int[] { (int)ReferralSourceFieldIndex.ReferralSourceTypeId } );		
			_referralSourceType = null;
		}

		/// <summary> setups the sync logic for member _referralSourceType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncReferralSourceType(IEntity2 relatedEntity)
		{
			if(_referralSourceType!=relatedEntity)
			{
				DesetupSyncReferralSourceType(true, true);
				_referralSourceType = (ReferralSourceTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _referralSourceType, new PropertyChangedEventHandler( OnReferralSourceTypePropertyChanged ), "ReferralSourceType", ReferralSourceEntity.Relations.ReferralSourceTypeEntityUsingReferralSourceTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnReferralSourceTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ReferralSourceEntity</param>
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
		public  static ReferralSourceRelations Relations
		{
			get	{ return new ReferralSourceRelations(); }
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
					(IEntityRelation)GetRelationsForField("AppointmentStatusInvoiceRates")[0], (int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, (int)PsychologicalServices.Data.EntityType.AppointmentStatusInvoiceRateEntity, 0, null, null, null, null, "AppointmentStatusInvoiceRates", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("Assessments")[0], (int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, (int)PsychologicalServices.Data.EntityType.AssessmentEntity, 0, null, null, null, null, "Assessments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("AssessmentTypeInvoiceAmounts")[0], (int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, (int)PsychologicalServices.Data.EntityType.AssessmentTypeInvoiceAmountEntity, 0, null, null, null, null, "AssessmentTypeInvoiceAmounts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReferralSourceInvoiceConfiguration' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReferralSourceInvoiceConfiguration
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ReferralSourceInvoiceConfigurationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceInvoiceConfigurationEntityFactory))),
					(IEntityRelation)GetRelationsForField("ReferralSourceInvoiceConfiguration")[0], (int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, (int)PsychologicalServices.Data.EntityType.ReferralSourceInvoiceConfigurationEntity, 0, null, null, null, null, "ReferralSourceInvoiceConfiguration", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AppointmentSequence' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAppointmentSequenceCollectionViaAppointmentStatusInvoiceRates
		{
			get
			{
				IEntityRelation intermediateRelation = ReferralSourceEntity.Relations.AppointmentStatusInvoiceRateEntityUsingReferralSourceId;
				intermediateRelation.SetAliases(string.Empty, "AppointmentStatusInvoiceRate_");
				return new PrefetchPathElement2(new EntityCollection<AppointmentSequenceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentSequenceEntityFactory))), intermediateRelation,
					(int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, (int)PsychologicalServices.Data.EntityType.AppointmentSequenceEntity, 0, null, null, GetRelationsForField("AppointmentSequenceCollectionViaAppointmentStatusInvoiceRates"), null, "AppointmentSequenceCollectionViaAppointmentStatusInvoiceRates", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AppointmentStatus' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAppointmentStatusCollectionViaAppointmentStatusInvoiceRates
		{
			get
			{
				IEntityRelation intermediateRelation = ReferralSourceEntity.Relations.AppointmentStatusInvoiceRateEntityUsingReferralSourceId;
				intermediateRelation.SetAliases(string.Empty, "AppointmentStatusInvoiceRate_");
				return new PrefetchPathElement2(new EntityCollection<AppointmentStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentStatusEntityFactory))), intermediateRelation,
					(int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, (int)PsychologicalServices.Data.EntityType.AppointmentStatusEntity, 0, null, null, GetRelationsForField("AppointmentStatusCollectionViaAppointmentStatusInvoiceRates"), null, "AppointmentStatusCollectionViaAppointmentStatusInvoiceRates", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AssessmentType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts
		{
			get
			{
				IEntityRelation intermediateRelation = ReferralSourceEntity.Relations.AssessmentTypeInvoiceAmountEntityUsingReferralSourceId;
				intermediateRelation.SetAliases(string.Empty, "AssessmentTypeInvoiceAmount_");
				return new PrefetchPathElement2(new EntityCollection<AssessmentTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentTypeEntityFactory))), intermediateRelation,
					(int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, (int)PsychologicalServices.Data.EntityType.AssessmentTypeEntity, 0, null, null, GetRelationsForField("AssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts"), null, "AssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}


		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Company' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCompanyCollectionViaAssessmentTypeInvoiceAmounts
		{
			get
			{
				IEntityRelation intermediateRelation = ReferralSourceEntity.Relations.AssessmentTypeInvoiceAmountEntityUsingReferralSourceId;
				intermediateRelation.SetAliases(string.Empty, "AssessmentTypeInvoiceAmount_");
				return new PrefetchPathElement2(new EntityCollection<CompanyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory))), intermediateRelation,
					(int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, (int)PsychologicalServices.Data.EntityType.CompanyEntity, 0, null, null, GetRelationsForField("CompanyCollectionViaAssessmentTypeInvoiceAmounts"), null, "CompanyCollectionViaAssessmentTypeInvoiceAmounts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}


		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Company' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCompanyCollectionViaReferralSourceInvoiceConfiguration
		{
			get
			{
				IEntityRelation intermediateRelation = ReferralSourceEntity.Relations.ReferralSourceInvoiceConfigurationEntityUsingReferralSourceId;
				intermediateRelation.SetAliases(string.Empty, "ReferralSourceInvoiceConfiguration_");
				return new PrefetchPathElement2(new EntityCollection<CompanyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory))), intermediateRelation,
					(int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, (int)PsychologicalServices.Data.EntityType.CompanyEntity, 0, null, null, GetRelationsForField("CompanyCollectionViaReferralSourceInvoiceConfiguration"), null, "CompanyCollectionViaReferralSourceInvoiceConfiguration", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Company' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCompanyCollectionViaAppointmentStatusInvoiceRates
		{
			get
			{
				IEntityRelation intermediateRelation = ReferralSourceEntity.Relations.AppointmentStatusInvoiceRateEntityUsingReferralSourceId;
				intermediateRelation.SetAliases(string.Empty, "AppointmentStatusInvoiceRate_");
				return new PrefetchPathElement2(new EntityCollection<CompanyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory))), intermediateRelation,
					(int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, (int)PsychologicalServices.Data.EntityType.CompanyEntity, 0, null, null, GetRelationsForField("CompanyCollectionViaAppointmentStatusInvoiceRates"), null, "CompanyCollectionViaAppointmentStatusInvoiceRates", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Address")[0], (int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, (int)PsychologicalServices.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReferralSourceType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReferralSourceType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("ReferralSourceType")[0], (int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, (int)PsychologicalServices.Data.EntityType.ReferralSourceTypeEntity, 0, null, null, null, null, "ReferralSourceType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ReferralSourceEntity.CustomProperties;}
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
			get { return ReferralSourceEntity.FieldsCustomProperties;}
		}

		/// <summary> The ReferralSourceId property of the Entity ReferralSource<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ReferralSources"."ReferralSourceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ReferralSourceId
		{
			get { return (System.Int32)GetValue((int)ReferralSourceFieldIndex.ReferralSourceId, true); }
			set	{ SetValue((int)ReferralSourceFieldIndex.ReferralSourceId, value); }
		}

		/// <summary> The Name property of the Entity ReferralSource<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ReferralSources"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)ReferralSourceFieldIndex.Name, true); }
			set	{ SetValue((int)ReferralSourceFieldIndex.Name, value); }
		}

		/// <summary> The ReferralSourceTypeId property of the Entity ReferralSource<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ReferralSources"."ReferralSourceTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ReferralSourceTypeId
		{
			get { return (System.Int32)GetValue((int)ReferralSourceFieldIndex.ReferralSourceTypeId, true); }
			set	{ SetValue((int)ReferralSourceFieldIndex.ReferralSourceTypeId, value); }
		}

		/// <summary> The IsActive property of the Entity ReferralSource<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ReferralSources"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ReferralSourceFieldIndex.IsActive, true); }
			set	{ SetValue((int)ReferralSourceFieldIndex.IsActive, value); }
		}

		/// <summary> The AddressId property of the Entity ReferralSource<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ReferralSources"."AddressId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> AddressId
		{
			get { return (Nullable<System.Int32>)GetValue((int)ReferralSourceFieldIndex.AddressId, false); }
			set	{ SetValue((int)ReferralSourceFieldIndex.AddressId, value); }
		}

		/// <summary> The InvoicesContactEmail property of the Entity ReferralSource<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ReferralSources"."InvoicesContactEmail"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 4000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String InvoicesContactEmail
		{
			get { return (System.String)GetValue((int)ReferralSourceFieldIndex.InvoicesContactEmail, true); }
			set	{ SetValue((int)ReferralSourceFieldIndex.InvoicesContactEmail, value); }
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
					_appointmentStatusInvoiceRates.SetContainingEntityInfo(this, "ReferralSource");
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
					_assessments.SetContainingEntityInfo(this, "ReferralSource");
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
					_assessmentTypeInvoiceAmounts.SetContainingEntityInfo(this, "ReferralSource");
				}
				return _assessmentTypeInvoiceAmounts;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ReferralSourceInvoiceConfigurationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ReferralSourceInvoiceConfigurationEntity))]
		public virtual EntityCollection<ReferralSourceInvoiceConfigurationEntity> ReferralSourceInvoiceConfiguration
		{
			get
			{
				if(_referralSourceInvoiceConfiguration==null)
				{
					_referralSourceInvoiceConfiguration = new EntityCollection<ReferralSourceInvoiceConfigurationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceInvoiceConfigurationEntityFactory)));
					_referralSourceInvoiceConfiguration.SetContainingEntityInfo(this, "ReferralSource");
				}
				return _referralSourceInvoiceConfiguration;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AppointmentSequenceEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AppointmentSequenceEntity))]
		public virtual EntityCollection<AppointmentSequenceEntity> AppointmentSequenceCollectionViaAppointmentStatusInvoiceRates
		{
			get
			{
				if(_appointmentSequenceCollectionViaAppointmentStatusInvoiceRates==null)
				{
					_appointmentSequenceCollectionViaAppointmentStatusInvoiceRates = new EntityCollection<AppointmentSequenceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentSequenceEntityFactory)));
					_appointmentSequenceCollectionViaAppointmentStatusInvoiceRates.IsReadOnly=true;
				}
				return _appointmentSequenceCollectionViaAppointmentStatusInvoiceRates;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AppointmentStatusEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AppointmentStatusEntity))]
		public virtual EntityCollection<AppointmentStatusEntity> AppointmentStatusCollectionViaAppointmentStatusInvoiceRates
		{
			get
			{
				if(_appointmentStatusCollectionViaAppointmentStatusInvoiceRates==null)
				{
					_appointmentStatusCollectionViaAppointmentStatusInvoiceRates = new EntityCollection<AppointmentStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentStatusEntityFactory)));
					_appointmentStatusCollectionViaAppointmentStatusInvoiceRates.IsReadOnly=true;
				}
				return _appointmentStatusCollectionViaAppointmentStatusInvoiceRates;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AssessmentTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AssessmentTypeEntity))]
		public virtual EntityCollection<AssessmentTypeEntity> AssessmentTypeCollectionViaAssessmentTypeInvoiceAmounts
		{
			get
			{
				if(_assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts==null)
				{
					_assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts = new EntityCollection<AssessmentTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentTypeEntityFactory)));
					_assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts.IsReadOnly=true;
				}
				return _assessmentTypeCollectionViaAssessmentTypeInvoiceAmounts;
			}
		}


		/// <summary> Gets the EntityCollection with the related entities of type 'CompanyEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CompanyEntity))]
		public virtual EntityCollection<CompanyEntity> CompanyCollectionViaAssessmentTypeInvoiceAmounts
		{
			get
			{
				if(_companyCollectionViaAssessmentTypeInvoiceAmounts==null)
				{
					_companyCollectionViaAssessmentTypeInvoiceAmounts = new EntityCollection<CompanyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory)));
					_companyCollectionViaAssessmentTypeInvoiceAmounts.IsReadOnly=true;
				}
				return _companyCollectionViaAssessmentTypeInvoiceAmounts;
			}
		}


		/// <summary> Gets the EntityCollection with the related entities of type 'CompanyEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CompanyEntity))]
		public virtual EntityCollection<CompanyEntity> CompanyCollectionViaReferralSourceInvoiceConfiguration
		{
			get
			{
				if(_companyCollectionViaReferralSourceInvoiceConfiguration==null)
				{
					_companyCollectionViaReferralSourceInvoiceConfiguration = new EntityCollection<CompanyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory)));
					_companyCollectionViaReferralSourceInvoiceConfiguration.IsReadOnly=true;
				}
				return _companyCollectionViaReferralSourceInvoiceConfiguration;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CompanyEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CompanyEntity))]
		public virtual EntityCollection<CompanyEntity> CompanyCollectionViaAppointmentStatusInvoiceRates
		{
			get
			{
				if(_companyCollectionViaAppointmentStatusInvoiceRates==null)
				{
					_companyCollectionViaAppointmentStatusInvoiceRates = new EntityCollection<CompanyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory)));
					_companyCollectionViaAppointmentStatusInvoiceRates.IsReadOnly=true;
				}
				return _companyCollectionViaAppointmentStatusInvoiceRates;
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
							_address.UnsetRelatedEntity(this, "ReferralSources");
						}
					}
					else
					{
						if(_address!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ReferralSources");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ReferralSourceTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ReferralSourceTypeEntity ReferralSourceType
		{
			get
			{
				return _referralSourceType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncReferralSourceType(value);
				}
				else
				{
					if(value==null)
					{
						if(_referralSourceType != null)
						{
							_referralSourceType.UnsetRelatedEntity(this, "ReferralSources");
						}
					}
					else
					{
						if(_referralSourceType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ReferralSources");
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
			get { return (int)PsychologicalServices.Data.EntityType.ReferralSourceEntity; }
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
