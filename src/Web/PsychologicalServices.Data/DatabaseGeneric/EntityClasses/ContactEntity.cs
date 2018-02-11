﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.3.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
	
	/// <summary>Entity class which represents the entity 'Contact'.<br/><br/></summary>
	[Serializable]
	public partial class ContactEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private EntityCollection<ArbitrationEntity> _arbitrations;
		private AddressEntity _address;
		private ContactTypeEntity _contactType;
		private EmployerEntity _employer;

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
			/// <summary>Member name ContactType</summary>
			public static readonly string ContactType = "ContactType";
			/// <summary>Member name Employer</summary>
			public static readonly string Employer = "Employer";
			/// <summary>Member name Arbitrations</summary>
			public static readonly string Arbitrations = "Arbitrations";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ContactEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public ContactEntity():base("ContactEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ContactEntity(IEntityFields2 fields):base("ContactEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ContactEntity</param>
		public ContactEntity(IValidator validator):base("ContactEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="contactId">PK value for Contact which data should be fetched into this Contact object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ContactEntity(System.Int32 contactId):base("ContactEntity")
		{
			InitClassEmpty(null, null);
			this.ContactId = contactId;
		}

		/// <summary> CTor</summary>
		/// <param name="contactId">PK value for Contact which data should be fetched into this Contact object</param>
		/// <param name="validator">The custom validator object for this ContactEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ContactEntity(System.Int32 contactId, IValidator validator):base("ContactEntity")
		{
			InitClassEmpty(validator, null);
			this.ContactId = contactId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ContactEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_arbitrations = (EntityCollection<ArbitrationEntity>)info.GetValue("_arbitrations", typeof(EntityCollection<ArbitrationEntity>));
				_address = (AddressEntity)info.GetValue("_address", typeof(AddressEntity));
				if(_address!=null)
				{
					_address.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_contactType = (ContactTypeEntity)info.GetValue("_contactType", typeof(ContactTypeEntity));
				if(_contactType!=null)
				{
					_contactType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_employer = (EmployerEntity)info.GetValue("_employer", typeof(EmployerEntity));
				if(_employer!=null)
				{
					_employer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ContactFieldIndex)fieldIndex)
			{
				case ContactFieldIndex.ContactTypeId:
					DesetupSyncContactType(true, false);
					break;
				case ContactFieldIndex.AddressId:
					DesetupSyncAddress(true, false);
					break;
				case ContactFieldIndex.EmployerId:
					DesetupSyncEmployer(true, false);
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		protected override void SetRelatedEntityProperty(string propertyName, IEntityCore entity)
		{
			switch(propertyName)
			{
				case "Address":
					this.Address = (AddressEntity)entity;
					break;
				case "ContactType":
					this.ContactType = (ContactTypeEntity)entity;
					break;
				case "Employer":
					this.Employer = (EmployerEntity)entity;
					break;
				case "Arbitrations":
					this.Arbitrations.Add((ArbitrationEntity)entity);
					break;
				default:
					this.OnSetRelatedEntityProperty(propertyName, entity);
					break;
			}
		}
		
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		protected override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		internal static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Address":
					toReturn.Add(Relations.AddressEntityUsingAddressId);
					break;
				case "ContactType":
					toReturn.Add(Relations.ContactTypeEntityUsingContactTypeId);
					break;
				case "Employer":
					toReturn.Add(Relations.EmployerEntityUsingEmployerId);
					break;
				case "Arbitrations":
					toReturn.Add(Relations.ArbitrationEntityUsingDefenseLawyerId);
					break;
				default:
					break;				
			}
			return toReturn;
		}

		/// <summary>Checks if the relation mapped by the property with the name specified is a one way / single sided relation. If the passed in name is null, it/ will return true if the entity has any single-sided relation</summary>
		/// <param name="propertyName">Name of the property which is mapped onto the relation to check, or null to check if the entity has any relation/ which is single sided</param>
		/// <returns>true if the relation is single sided / one way (so the opposite relation isn't present), false otherwise</returns>
		protected override bool CheckOneWayRelations(string propertyName)
		{
			int numberOfOneWayRelations = 0;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));
				default:
					return base.CheckOneWayRelations(propertyName);
			}
		}

		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		protected override void SetRelatedEntity(IEntityCore relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "Address":
					SetupSyncAddress(relatedEntity);
					break;
				case "ContactType":
					SetupSyncContactType(relatedEntity);
					break;
				case "Employer":
					SetupSyncEmployer(relatedEntity);
					break;
				case "Arbitrations":
					this.Arbitrations.Add((ArbitrationEntity)relatedEntity);
					break;
				default:
					break;
			}
		}

		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		protected override void UnsetRelatedEntity(IEntityCore relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "Address":
					DesetupSyncAddress(false, true);
					break;
				case "ContactType":
					DesetupSyncContactType(false, true);
					break;
				case "Employer":
					DesetupSyncEmployer(false, true);
					break;
				case "Arbitrations":
					this.PerformRelatedEntityRemoval(this.Arbitrations, relatedEntity, signalRelatedEntityManyToOne);
					break;
				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		protected override List<IEntity2> GetDependingRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		protected override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_address!=null)
			{
				toReturn.Add(_address);
			}
			if(_contactType!=null)
			{
				toReturn.Add(_contactType);
			}
			if(_employer!=null)
			{
				toReturn.Add(_employer);
			}
			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		protected override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.Arbitrations);
			return toReturn;
		}

		/// <summary>ISerializable member. Does custom serialization so event handlers do not get serialized. Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				info.AddValue("_arbitrations", ((_arbitrations!=null) && (_arbitrations.Count>0) && !this.MarkedForDeletion)?_arbitrations:null);
				info.AddValue("_address", (!this.MarkedForDeletion?_address:null));
				info.AddValue("_contactType", (!this.MarkedForDeletion?_contactType:null));
				info.AddValue("_employer", (!this.MarkedForDeletion?_employer:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new ContactRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Arbitration' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoArbitrations()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ArbitrationFields.DefenseLawyerId, null, ComparisonOperator.Equal, this.ContactId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Address' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'ContactType' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContactType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactTypeFields.ContactTypeId, null, ComparisonOperator.Equal, this.ContactTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Employer' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmployer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmployerFields.EmployerId, null, ComparisonOperator.Equal, this.EmployerId));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(ContactEntityFactory));
		}

		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._arbitrations);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._arbitrations = (EntityCollection<ArbitrationEntity>) collectionsQueue.Dequeue();

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			bool toReturn = false;
			toReturn |=(this._arbitrations != null);
			return toReturn ? true : base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ArbitrationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ArbitrationEntityFactory))) : null);
		}

		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Address", _address);
			toReturn.Add("ContactType", _contactType);
			toReturn.Add("Employer", _employer);
			toReturn.Add("Arbitrations", _arbitrations);
			return toReturn;
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
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
			Dictionary<string, string> fieldHashtable;
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ContactId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ContactTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EmployerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _address</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAddress(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _address, new PropertyChangedEventHandler(OnAddressPropertyChanged), "Address", "Contacts", PsychologicalServices.Data.RelationClasses.StaticContactRelations.AddressEntityUsingAddressIdStatic, true, new int[] { (int)ContactFieldIndex.AddressId });
		}

		/// <summary> setups the sync logic for member _address</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAddress(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", "Contacts", PsychologicalServices.Data.RelationClasses.StaticContactRelations.AddressEntityUsingAddressIdStatic, true, new string[] {  }, new int[] { (int)ContactFieldIndex.AddressId }); 
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

		/// <summary> Removes the sync logic for member _contactType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncContactType(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _contactType, new PropertyChangedEventHandler(OnContactTypePropertyChanged), "ContactType", "Contacts", PsychologicalServices.Data.RelationClasses.StaticContactRelations.ContactTypeEntityUsingContactTypeIdStatic, true, new int[] { (int)ContactFieldIndex.ContactTypeId });
		}

		/// <summary> setups the sync logic for member _contactType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncContactType(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _contactType, new PropertyChangedEventHandler( OnContactTypePropertyChanged ), "ContactType", "Contacts", PsychologicalServices.Data.RelationClasses.StaticContactRelations.ContactTypeEntityUsingContactTypeIdStatic, true, new string[] {  }, new int[] { (int)ContactFieldIndex.ContactTypeId }); 
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnContactTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _employer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEmployer(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _employer, new PropertyChangedEventHandler(OnEmployerPropertyChanged), "Employer", "Contacts", PsychologicalServices.Data.RelationClasses.StaticContactRelations.EmployerEntityUsingEmployerIdStatic, true, new int[] { (int)ContactFieldIndex.EmployerId });
		}

		/// <summary> setups the sync logic for member _employer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEmployer(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _employer, new PropertyChangedEventHandler( OnEmployerPropertyChanged ), "Employer", "Contacts", PsychologicalServices.Data.RelationClasses.StaticContactRelations.EmployerEntityUsingEmployerIdStatic, true, new string[] {  }, new int[] { (int)ContactFieldIndex.EmployerId }); 
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEmployerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ContactEntity</param>
		/// <param name="fields">Fields of this entity</param>
		private void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			this.Fields = fields ?? CreateFields();
			this.Validator = validator;
			InitClassMembers();

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END
			

			OnInitialized();

		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static ContactRelations Relations
		{
			get	{ return new ContactRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Arbitration' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathArbitrations
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<ArbitrationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ArbitrationEntityFactory))), (IEntityRelation)GetRelationsForField("Arbitrations")[0], (int)PsychologicalServices.Data.EntityType.ContactEntity, (int)PsychologicalServices.Data.EntityType.ArbitrationEntity, 0, null, null, null, null, "Arbitrations", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddress
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))),	(IEntityRelation)GetRelationsForField("Address")[0], (int)PsychologicalServices.Data.EntityType.ContactEntity, (int)PsychologicalServices.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ContactType' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContactType
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ContactTypeEntityFactory))),	(IEntityRelation)GetRelationsForField("ContactType")[0], (int)PsychologicalServices.Data.EntityType.ContactEntity, (int)PsychologicalServices.Data.EntityType.ContactTypeEntity, 0, null, null, null, null, "ContactType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Employer' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmployer
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EmployerEntityFactory))),	(IEntityRelation)GetRelationsForField("Employer")[0], (int)PsychologicalServices.Data.EntityType.ContactEntity, (int)PsychologicalServices.Data.EntityType.EmployerEntity, 0, null, null, null, null, "Employer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		protected override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		protected override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return FieldsCustomProperties;}
		}

		/// <summary> The ContactId property of the Entity Contact<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Contacts"."ContactId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ContactId
		{
			get { return (System.Int32)GetValue((int)ContactFieldIndex.ContactId, true); }
			set	{ SetValue((int)ContactFieldIndex.ContactId, value); }
		}

		/// <summary> The FirstName property of the Entity Contact<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Contacts"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)ContactFieldIndex.FirstName, true); }
			set	{ SetValue((int)ContactFieldIndex.FirstName, value); }
		}

		/// <summary> The LastName property of the Entity Contact<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Contacts"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)ContactFieldIndex.LastName, true); }
			set	{ SetValue((int)ContactFieldIndex.LastName, value); }
		}

		/// <summary> The Email property of the Entity Contact<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Contacts"."Email"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email
		{
			get { return (System.String)GetValue((int)ContactFieldIndex.Email, true); }
			set	{ SetValue((int)ContactFieldIndex.Email, value); }
		}

		/// <summary> The ContactTypeId property of the Entity Contact<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Contacts"."ContactTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ContactTypeId
		{
			get { return (System.Int32)GetValue((int)ContactFieldIndex.ContactTypeId, true); }
			set	{ SetValue((int)ContactFieldIndex.ContactTypeId, value); }
		}

		/// <summary> The AddressId property of the Entity Contact<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Contacts"."AddressId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> AddressId
		{
			get { return (Nullable<System.Int32>)GetValue((int)ContactFieldIndex.AddressId, false); }
			set	{ SetValue((int)ContactFieldIndex.AddressId, value); }
		}

		/// <summary> The EmployerId property of the Entity Contact<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Contacts"."EmployerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> EmployerId
		{
			get { return (Nullable<System.Int32>)GetValue((int)ContactFieldIndex.EmployerId, false); }
			set	{ SetValue((int)ContactFieldIndex.EmployerId, value); }
		}

		/// <summary> The IsActive property of the Entity Contact<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Contacts"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ContactFieldIndex.IsActive, true); }
			set	{ SetValue((int)ContactFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ArbitrationEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ArbitrationEntity))]
		public virtual EntityCollection<ArbitrationEntity> Arbitrations
		{
			get { return GetOrCreateEntityCollection<ArbitrationEntity, ArbitrationEntityFactory>("DefenseLawyer", true, false, ref _arbitrations);	}
		}

		/// <summary> Gets / sets related entity of type 'AddressEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual AddressEntity Address
		{
			get	{ return _address; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncAddress(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Contacts", "Address", _address, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ContactTypeEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual ContactTypeEntity ContactType
		{
			get	{ return _contactType; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncContactType(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Contacts", "ContactType", _contactType, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EmployerEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual EmployerEntity Employer
		{
			get	{ return _employer; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncEmployer(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Contacts", "Employer", _employer, true); 
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
		protected override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)PsychologicalServices.Data.EntityType.ContactEntity; }
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
