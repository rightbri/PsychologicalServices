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
		private EntityCollection<AssessmentEntity> _assessments;
		private EntityCollection<ReferralSourceAppointmentStatusSettingEntity> _referralSourceAppointmentStatusSettings;
		private EntityCollection<ReportTypeInvoiceAmountEntity> _reportTypeInvoiceAmounts;








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
			/// <summary>Member name Assessments</summary>
			public static readonly string Assessments = "Assessments";
			/// <summary>Member name ReferralSourceAppointmentStatusSettings</summary>
			public static readonly string ReferralSourceAppointmentStatusSettings = "ReferralSourceAppointmentStatusSettings";
			/// <summary>Member name ReportTypeInvoiceAmounts</summary>
			public static readonly string ReportTypeInvoiceAmounts = "ReportTypeInvoiceAmounts";









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
				_assessments = (EntityCollection<AssessmentEntity>)info.GetValue("_assessments", typeof(EntityCollection<AssessmentEntity>));
				_referralSourceAppointmentStatusSettings = (EntityCollection<ReferralSourceAppointmentStatusSettingEntity>)info.GetValue("_referralSourceAppointmentStatusSettings", typeof(EntityCollection<ReferralSourceAppointmentStatusSettingEntity>));
				_reportTypeInvoiceAmounts = (EntityCollection<ReportTypeInvoiceAmountEntity>)info.GetValue("_reportTypeInvoiceAmounts", typeof(EntityCollection<ReportTypeInvoiceAmountEntity>));








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
				case "Assessments":
					this.Assessments.Add((AssessmentEntity)entity);
					break;
				case "ReferralSourceAppointmentStatusSettings":
					this.ReferralSourceAppointmentStatusSettings.Add((ReferralSourceAppointmentStatusSettingEntity)entity);
					break;
				case "ReportTypeInvoiceAmounts":
					this.ReportTypeInvoiceAmounts.Add((ReportTypeInvoiceAmountEntity)entity);
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
				case "Assessments":
					toReturn.Add(ReferralSourceEntity.Relations.AssessmentEntityUsingReferralSourceId);
					break;
				case "ReferralSourceAppointmentStatusSettings":
					toReturn.Add(ReferralSourceEntity.Relations.ReferralSourceAppointmentStatusSettingEntityUsingReferralSourceId);
					break;
				case "ReportTypeInvoiceAmounts":
					toReturn.Add(ReferralSourceEntity.Relations.ReportTypeInvoiceAmountEntityUsingReferralSourceId);
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
				case "Assessments":
					this.Assessments.Add((AssessmentEntity)relatedEntity);
					break;
				case "ReferralSourceAppointmentStatusSettings":
					this.ReferralSourceAppointmentStatusSettings.Add((ReferralSourceAppointmentStatusSettingEntity)relatedEntity);
					break;
				case "ReportTypeInvoiceAmounts":
					this.ReportTypeInvoiceAmounts.Add((ReportTypeInvoiceAmountEntity)relatedEntity);
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
				case "Assessments":
					base.PerformRelatedEntityRemoval(this.Assessments, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ReferralSourceAppointmentStatusSettings":
					base.PerformRelatedEntityRemoval(this.ReferralSourceAppointmentStatusSettings, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ReportTypeInvoiceAmounts":
					base.PerformRelatedEntityRemoval(this.ReportTypeInvoiceAmounts, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.Assessments);
			toReturn.Add(this.ReferralSourceAppointmentStatusSettings);
			toReturn.Add(this.ReportTypeInvoiceAmounts);

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
				info.AddValue("_assessments", ((_assessments!=null) && (_assessments.Count>0) && !this.MarkedForDeletion)?_assessments:null);
				info.AddValue("_referralSourceAppointmentStatusSettings", ((_referralSourceAppointmentStatusSettings!=null) && (_referralSourceAppointmentStatusSettings.Count>0) && !this.MarkedForDeletion)?_referralSourceAppointmentStatusSettings:null);
				info.AddValue("_reportTypeInvoiceAmounts", ((_reportTypeInvoiceAmounts!=null) && (_reportTypeInvoiceAmounts.Count>0) && !this.MarkedForDeletion)?_reportTypeInvoiceAmounts:null);








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
		/// the related entities of type 'Assessment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ReferralSourceAppointmentStatusSetting' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReferralSourceAppointmentStatusSettings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceAppointmentStatusSettingFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ReportTypeInvoiceAmount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReportTypeInvoiceAmounts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReportTypeInvoiceAmountFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId));
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
			collectionsQueue.Enqueue(this._assessments);
			collectionsQueue.Enqueue(this._referralSourceAppointmentStatusSettings);
			collectionsQueue.Enqueue(this._reportTypeInvoiceAmounts);








		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._assessments = (EntityCollection<AssessmentEntity>) collectionsQueue.Dequeue();
			this._referralSourceAppointmentStatusSettings = (EntityCollection<ReferralSourceAppointmentStatusSettingEntity>) collectionsQueue.Dequeue();
			this._reportTypeInvoiceAmounts = (EntityCollection<ReportTypeInvoiceAmountEntity>) collectionsQueue.Dequeue();








		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._assessments != null)
			{
				return true;
			}
			if (this._referralSourceAppointmentStatusSettings != null)
			{
				return true;
			}
			if (this._reportTypeInvoiceAmounts != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AssessmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReferralSourceAppointmentStatusSettingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceAppointmentStatusSettingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReportTypeInvoiceAmountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeInvoiceAmountEntityFactory))) : null);








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
			toReturn.Add("Assessments", _assessments);
			toReturn.Add("ReferralSourceAppointmentStatusSettings", _referralSourceAppointmentStatusSettings);
			toReturn.Add("ReportTypeInvoiceAmounts", _reportTypeInvoiceAmounts);









			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_assessments!=null)
			{
				_assessments.ActiveContext = base.ActiveContext;
			}
			if(_referralSourceAppointmentStatusSettings!=null)
			{
				_referralSourceAppointmentStatusSettings.ActiveContext = base.ActiveContext;
			}
			if(_reportTypeInvoiceAmounts!=null)
			{
				_reportTypeInvoiceAmounts.ActiveContext = base.ActiveContext;
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

			_assessments = null;
			_referralSourceAppointmentStatusSettings = null;
			_reportTypeInvoiceAmounts = null;








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

			_fieldsCustomProperties.Add("LargeFileSize", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LargeFileFeeAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AddressId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _address</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAddress(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", ReferralSourceEntity.Relations.AddressEntityUsingAddressId, true, signalRelatedEntity, "ReferralSource", resetFKFields, new int[] { (int)ReferralSourceFieldIndex.AddressId } );		
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
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReferralSourceAppointmentStatusSetting' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReferralSourceAppointmentStatusSettings
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ReferralSourceAppointmentStatusSettingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceAppointmentStatusSettingEntityFactory))),
					(IEntityRelation)GetRelationsForField("ReferralSourceAppointmentStatusSettings")[0], (int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, (int)PsychologicalServices.Data.EntityType.ReferralSourceAppointmentStatusSettingEntity, 0, null, null, null, null, "ReferralSourceAppointmentStatusSettings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReportTypeInvoiceAmount' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReportTypeInvoiceAmounts
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ReportTypeInvoiceAmountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeInvoiceAmountEntityFactory))),
					(IEntityRelation)GetRelationsForField("ReportTypeInvoiceAmounts")[0], (int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, (int)PsychologicalServices.Data.EntityType.ReportTypeInvoiceAmountEntity, 0, null, null, null, null, "ReportTypeInvoiceAmounts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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

		/// <summary> The LargeFileSize property of the Entity ReferralSource<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ReferralSources"."LargeFileSize"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 LargeFileSize
		{
			get { return (System.Int32)GetValue((int)ReferralSourceFieldIndex.LargeFileSize, true); }
			set	{ SetValue((int)ReferralSourceFieldIndex.LargeFileSize, value); }
		}

		/// <summary> The LargeFileFeeAmount property of the Entity ReferralSource<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ReferralSources"."LargeFileFeeAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 LargeFileFeeAmount
		{
			get { return (System.Int32)GetValue((int)ReferralSourceFieldIndex.LargeFileFeeAmount, true); }
			set	{ SetValue((int)ReferralSourceFieldIndex.LargeFileFeeAmount, value); }
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

		/// <summary> Gets the EntityCollection with the related entities of type 'ReferralSourceAppointmentStatusSettingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ReferralSourceAppointmentStatusSettingEntity))]
		public virtual EntityCollection<ReferralSourceAppointmentStatusSettingEntity> ReferralSourceAppointmentStatusSettings
		{
			get
			{
				if(_referralSourceAppointmentStatusSettings==null)
				{
					_referralSourceAppointmentStatusSettings = new EntityCollection<ReferralSourceAppointmentStatusSettingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceAppointmentStatusSettingEntityFactory)));
					_referralSourceAppointmentStatusSettings.SetContainingEntityInfo(this, "ReferralSource");
				}
				return _referralSourceAppointmentStatusSettings;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ReportTypeInvoiceAmountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ReportTypeInvoiceAmountEntity))]
		public virtual EntityCollection<ReportTypeInvoiceAmountEntity> ReportTypeInvoiceAmounts
		{
			get
			{
				if(_reportTypeInvoiceAmounts==null)
				{
					_reportTypeInvoiceAmounts = new EntityCollection<ReportTypeInvoiceAmountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeInvoiceAmountEntityFactory)));
					_reportTypeInvoiceAmounts.SetContainingEntityInfo(this, "ReferralSource");
				}
				return _reportTypeInvoiceAmounts;
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
							_address.UnsetRelatedEntity(this, "ReferralSource");
						}
					}
					else
					{
						if(_address!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ReferralSource");
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
