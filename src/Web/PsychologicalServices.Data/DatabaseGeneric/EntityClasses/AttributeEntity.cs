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
	/// Entity class which represents the entity 'Attribute'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AttributeEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AppointmentAttributeEntity> _appointmentAttributes;
		private EntityCollection<AssessmentAttributeEntity> _assessmentAttributes;
		private EntityCollection<CompanyAttributeEntity> _companyAttributes;



		private AttributeTypeEntity _attributeType;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AttributeType</summary>
			public static readonly string AttributeType = "AttributeType";
			/// <summary>Member name AppointmentAttributes</summary>
			public static readonly string AppointmentAttributes = "AppointmentAttributes";
			/// <summary>Member name AssessmentAttributes</summary>
			public static readonly string AssessmentAttributes = "AssessmentAttributes";
			/// <summary>Member name CompanyAttributes</summary>
			public static readonly string CompanyAttributes = "CompanyAttributes";




		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AttributeEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AttributeEntity():base("AttributeEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AttributeEntity(IEntityFields2 fields):base("AttributeEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AttributeEntity</param>
		public AttributeEntity(IValidator validator):base("AttributeEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="attributeId">PK value for Attribute which data should be fetched into this Attribute object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AttributeEntity(System.Int32 attributeId):base("AttributeEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.AttributeId = attributeId;
		}

		/// <summary> CTor</summary>
		/// <param name="attributeId">PK value for Attribute which data should be fetched into this Attribute object</param>
		/// <param name="validator">The custom validator object for this AttributeEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AttributeEntity(System.Int32 attributeId, IValidator validator):base("AttributeEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.AttributeId = attributeId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AttributeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_appointmentAttributes = (EntityCollection<AppointmentAttributeEntity>)info.GetValue("_appointmentAttributes", typeof(EntityCollection<AppointmentAttributeEntity>));
				_assessmentAttributes = (EntityCollection<AssessmentAttributeEntity>)info.GetValue("_assessmentAttributes", typeof(EntityCollection<AssessmentAttributeEntity>));
				_companyAttributes = (EntityCollection<CompanyAttributeEntity>)info.GetValue("_companyAttributes", typeof(EntityCollection<CompanyAttributeEntity>));



				_attributeType = (AttributeTypeEntity)info.GetValue("_attributeType", typeof(AttributeTypeEntity));
				if(_attributeType!=null)
				{
					_attributeType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AttributeFieldIndex)fieldIndex)
			{
				case AttributeFieldIndex.AttributeTypeId:
					DesetupSyncAttributeType(true, false);
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
				case "AttributeType":
					this.AttributeType = (AttributeTypeEntity)entity;
					break;
				case "AppointmentAttributes":
					this.AppointmentAttributes.Add((AppointmentAttributeEntity)entity);
					break;
				case "AssessmentAttributes":
					this.AssessmentAttributes.Add((AssessmentAttributeEntity)entity);
					break;
				case "CompanyAttributes":
					this.CompanyAttributes.Add((CompanyAttributeEntity)entity);
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
			return AttributeEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AttributeType":
					toReturn.Add(AttributeEntity.Relations.AttributeTypeEntityUsingAttributeTypeId);
					break;
				case "AppointmentAttributes":
					toReturn.Add(AttributeEntity.Relations.AppointmentAttributeEntityUsingAttributeId);
					break;
				case "AssessmentAttributes":
					toReturn.Add(AttributeEntity.Relations.AssessmentAttributeEntityUsingAttributeId);
					break;
				case "CompanyAttributes":
					toReturn.Add(AttributeEntity.Relations.CompanyAttributeEntityUsingAttributeId);
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
				case "AttributeType":
					SetupSyncAttributeType(relatedEntity);
					break;
				case "AppointmentAttributes":
					this.AppointmentAttributes.Add((AppointmentAttributeEntity)relatedEntity);
					break;
				case "AssessmentAttributes":
					this.AssessmentAttributes.Add((AssessmentAttributeEntity)relatedEntity);
					break;
				case "CompanyAttributes":
					this.CompanyAttributes.Add((CompanyAttributeEntity)relatedEntity);
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
				case "AttributeType":
					DesetupSyncAttributeType(false, true);
					break;
				case "AppointmentAttributes":
					base.PerformRelatedEntityRemoval(this.AppointmentAttributes, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AssessmentAttributes":
					base.PerformRelatedEntityRemoval(this.AssessmentAttributes, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CompanyAttributes":
					base.PerformRelatedEntityRemoval(this.CompanyAttributes, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_attributeType!=null)
			{
				toReturn.Add(_attributeType);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AppointmentAttributes);
			toReturn.Add(this.AssessmentAttributes);
			toReturn.Add(this.CompanyAttributes);

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
				info.AddValue("_appointmentAttributes", ((_appointmentAttributes!=null) && (_appointmentAttributes.Count>0) && !this.MarkedForDeletion)?_appointmentAttributes:null);
				info.AddValue("_assessmentAttributes", ((_assessmentAttributes!=null) && (_assessmentAttributes.Count>0) && !this.MarkedForDeletion)?_assessmentAttributes:null);
				info.AddValue("_companyAttributes", ((_companyAttributes!=null) && (_companyAttributes.Count>0) && !this.MarkedForDeletion)?_companyAttributes:null);



				info.AddValue("_attributeType", (!this.MarkedForDeletion?_attributeType:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AttributeFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AttributeFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AttributeRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AppointmentAttribute' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAppointmentAttributes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AppointmentAttributeFields.AttributeId, null, ComparisonOperator.Equal, this.AttributeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AssessmentAttribute' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessmentAttributes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentAttributeFields.AttributeId, null, ComparisonOperator.Equal, this.AttributeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CompanyAttribute' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCompanyAttributes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CompanyAttributeFields.AttributeId, null, ComparisonOperator.Equal, this.AttributeId));
			return bucket;
		}




		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AttributeType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAttributeType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AttributeTypeFields.AttributeTypeId, null, ComparisonOperator.Equal, this.AttributeTypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(PsychologicalServices.Data.EntityType.AttributeEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AttributeEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._appointmentAttributes);
			collectionsQueue.Enqueue(this._assessmentAttributes);
			collectionsQueue.Enqueue(this._companyAttributes);



		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._appointmentAttributes = (EntityCollection<AppointmentAttributeEntity>) collectionsQueue.Dequeue();
			this._assessmentAttributes = (EntityCollection<AssessmentAttributeEntity>) collectionsQueue.Dequeue();
			this._companyAttributes = (EntityCollection<CompanyAttributeEntity>) collectionsQueue.Dequeue();



		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._appointmentAttributes != null)
			{
				return true;
			}
			if (this._assessmentAttributes != null)
			{
				return true;
			}
			if (this._companyAttributes != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AppointmentAttributeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentAttributeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AssessmentAttributeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentAttributeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CompanyAttributeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyAttributeEntityFactory))) : null);



		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("AttributeType", _attributeType);
			toReturn.Add("AppointmentAttributes", _appointmentAttributes);
			toReturn.Add("AssessmentAttributes", _assessmentAttributes);
			toReturn.Add("CompanyAttributes", _companyAttributes);




			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_appointmentAttributes!=null)
			{
				_appointmentAttributes.ActiveContext = base.ActiveContext;
			}
			if(_assessmentAttributes!=null)
			{
				_assessmentAttributes.ActiveContext = base.ActiveContext;
			}
			if(_companyAttributes!=null)
			{
				_companyAttributes.ActiveContext = base.ActiveContext;
			}



			if(_attributeType!=null)
			{
				_attributeType.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_appointmentAttributes = null;
			_assessmentAttributes = null;
			_companyAttributes = null;



			_attributeType = null;

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

			_fieldsCustomProperties.Add("AttributeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AttributeTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _attributeType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAttributeType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _attributeType, new PropertyChangedEventHandler( OnAttributeTypePropertyChanged ), "AttributeType", AttributeEntity.Relations.AttributeTypeEntityUsingAttributeTypeId, true, signalRelatedEntity, "Attributes", resetFKFields, new int[] { (int)AttributeFieldIndex.AttributeTypeId } );		
			_attributeType = null;
		}

		/// <summary> setups the sync logic for member _attributeType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAttributeType(IEntity2 relatedEntity)
		{
			if(_attributeType!=relatedEntity)
			{
				DesetupSyncAttributeType(true, true);
				_attributeType = (AttributeTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _attributeType, new PropertyChangedEventHandler( OnAttributeTypePropertyChanged ), "AttributeType", AttributeEntity.Relations.AttributeTypeEntityUsingAttributeTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAttributeTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AttributeEntity</param>
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
		public  static AttributeRelations Relations
		{
			get	{ return new AttributeRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AppointmentAttribute' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAppointmentAttributes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AppointmentAttributeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentAttributeEntityFactory))),
					(IEntityRelation)GetRelationsForField("AppointmentAttributes")[0], (int)PsychologicalServices.Data.EntityType.AttributeEntity, (int)PsychologicalServices.Data.EntityType.AppointmentAttributeEntity, 0, null, null, null, null, "AppointmentAttributes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AssessmentAttribute' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssessmentAttributes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AssessmentAttributeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentAttributeEntityFactory))),
					(IEntityRelation)GetRelationsForField("AssessmentAttributes")[0], (int)PsychologicalServices.Data.EntityType.AttributeEntity, (int)PsychologicalServices.Data.EntityType.AssessmentAttributeEntity, 0, null, null, null, null, "AssessmentAttributes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("CompanyAttributes")[0], (int)PsychologicalServices.Data.EntityType.AttributeEntity, (int)PsychologicalServices.Data.EntityType.CompanyAttributeEntity, 0, null, null, null, null, "CompanyAttributes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}




		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AttributeType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAttributeType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AttributeTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("AttributeType")[0], (int)PsychologicalServices.Data.EntityType.AttributeEntity, (int)PsychologicalServices.Data.EntityType.AttributeTypeEntity, 0, null, null, null, null, "AttributeType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AttributeEntity.CustomProperties;}
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
			get { return AttributeEntity.FieldsCustomProperties;}
		}

		/// <summary> The AttributeId property of the Entity Attribute<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Attributes"."AttributeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 AttributeId
		{
			get { return (System.Int32)GetValue((int)AttributeFieldIndex.AttributeId, true); }
			set	{ SetValue((int)AttributeFieldIndex.AttributeId, value); }
		}

		/// <summary> The Name property of the Entity Attribute<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Attributes"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)AttributeFieldIndex.Name, true); }
			set	{ SetValue((int)AttributeFieldIndex.Name, value); }
		}

		/// <summary> The AttributeTypeId property of the Entity Attribute<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Attributes"."AttributeTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 AttributeTypeId
		{
			get { return (System.Int32)GetValue((int)AttributeFieldIndex.AttributeTypeId, true); }
			set	{ SetValue((int)AttributeFieldIndex.AttributeTypeId, value); }
		}

		/// <summary> The IsActive property of the Entity Attribute<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Attributes"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)AttributeFieldIndex.IsActive, true); }
			set	{ SetValue((int)AttributeFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AppointmentAttributeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AppointmentAttributeEntity))]
		public virtual EntityCollection<AppointmentAttributeEntity> AppointmentAttributes
		{
			get
			{
				if(_appointmentAttributes==null)
				{
					_appointmentAttributes = new EntityCollection<AppointmentAttributeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentAttributeEntityFactory)));
					_appointmentAttributes.SetContainingEntityInfo(this, "Attribute");
				}
				return _appointmentAttributes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AssessmentAttributeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AssessmentAttributeEntity))]
		public virtual EntityCollection<AssessmentAttributeEntity> AssessmentAttributes
		{
			get
			{
				if(_assessmentAttributes==null)
				{
					_assessmentAttributes = new EntityCollection<AssessmentAttributeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentAttributeEntityFactory)));
					_assessmentAttributes.SetContainingEntityInfo(this, "Attribute");
				}
				return _assessmentAttributes;
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
					_companyAttributes.SetContainingEntityInfo(this, "Attribute");
				}
				return _companyAttributes;
			}
		}




		/// <summary> Gets / sets related entity of type 'AttributeTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AttributeTypeEntity AttributeType
		{
			get
			{
				return _attributeType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAttributeType(value);
				}
				else
				{
					if(value==null)
					{
						if(_attributeType != null)
						{
							_attributeType.UnsetRelatedEntity(this, "Attributes");
						}
					}
					else
					{
						if(_attributeType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Attributes");
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
			get { return (int)PsychologicalServices.Data.EntityType.AttributeEntity; }
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
