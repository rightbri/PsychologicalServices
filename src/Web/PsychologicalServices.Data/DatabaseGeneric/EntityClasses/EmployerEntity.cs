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
	
	/// <summary>Entity class which represents the entity 'Employer'.<br/><br/></summary>
	[Serializable]
	public partial class EmployerEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private EntityCollection<ContactEntity> _contacts;
		private EntityCollection<AddressEntity> _addressCollectionViaContacts;
		private EntityCollection<ContactTypeEntity> _contactTypesCollectionViaContacts;
		private EmployerTypeEntity _employerType;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name EmployerType</summary>
			public static readonly string EmployerType = "EmployerType";
			/// <summary>Member name Contacts</summary>
			public static readonly string Contacts = "Contacts";
			/// <summary>Member name AddressCollectionViaContacts</summary>
			public static readonly string AddressCollectionViaContacts = "AddressCollectionViaContacts";
			/// <summary>Member name ContactTypesCollectionViaContacts</summary>
			public static readonly string ContactTypesCollectionViaContacts = "ContactTypesCollectionViaContacts";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EmployerEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public EmployerEntity():base("EmployerEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EmployerEntity(IEntityFields2 fields):base("EmployerEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EmployerEntity</param>
		public EmployerEntity(IValidator validator):base("EmployerEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="employerId">PK value for Employer which data should be fetched into this Employer object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EmployerEntity(System.Int32 employerId):base("EmployerEntity")
		{
			InitClassEmpty(null, null);
			this.EmployerId = employerId;
		}

		/// <summary> CTor</summary>
		/// <param name="employerId">PK value for Employer which data should be fetched into this Employer object</param>
		/// <param name="validator">The custom validator object for this EmployerEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EmployerEntity(System.Int32 employerId, IValidator validator):base("EmployerEntity")
		{
			InitClassEmpty(validator, null);
			this.EmployerId = employerId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EmployerEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_contacts = (EntityCollection<ContactEntity>)info.GetValue("_contacts", typeof(EntityCollection<ContactEntity>));
				_addressCollectionViaContacts = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaContacts", typeof(EntityCollection<AddressEntity>));
				_contactTypesCollectionViaContacts = (EntityCollection<ContactTypeEntity>)info.GetValue("_contactTypesCollectionViaContacts", typeof(EntityCollection<ContactTypeEntity>));
				_employerType = (EmployerTypeEntity)info.GetValue("_employerType", typeof(EmployerTypeEntity));
				if(_employerType!=null)
				{
					_employerType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((EmployerFieldIndex)fieldIndex)
			{
				case EmployerFieldIndex.EmployerTypeId:
					DesetupSyncEmployerType(true, false);
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
				case "EmployerType":
					this.EmployerType = (EmployerTypeEntity)entity;
					break;
				case "Contacts":
					this.Contacts.Add((ContactEntity)entity);
					break;
				case "AddressCollectionViaContacts":
					this.AddressCollectionViaContacts.IsReadOnly = false;
					this.AddressCollectionViaContacts.Add((AddressEntity)entity);
					this.AddressCollectionViaContacts.IsReadOnly = true;
					break;
				case "ContactTypesCollectionViaContacts":
					this.ContactTypesCollectionViaContacts.IsReadOnly = false;
					this.ContactTypesCollectionViaContacts.Add((ContactTypeEntity)entity);
					this.ContactTypesCollectionViaContacts.IsReadOnly = true;
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
				case "EmployerType":
					toReturn.Add(Relations.EmployerTypeEntityUsingEmployerTypeId);
					break;
				case "Contacts":
					toReturn.Add(Relations.ContactEntityUsingEmployerId);
					break;
				case "AddressCollectionViaContacts":
					toReturn.Add(Relations.ContactEntityUsingEmployerId, "EmployerEntity__", "Contact_", JoinHint.None);
					toReturn.Add(ContactEntity.Relations.AddressEntityUsingAddressId, "Contact_", string.Empty, JoinHint.None);
					break;
				case "ContactTypesCollectionViaContacts":
					toReturn.Add(Relations.ContactEntityUsingEmployerId, "EmployerEntity__", "Contact_", JoinHint.None);
					toReturn.Add(ContactEntity.Relations.ContactTypeEntityUsingContactTypeId, "Contact_", string.Empty, JoinHint.None);
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
				case "EmployerType":
					SetupSyncEmployerType(relatedEntity);
					break;
				case "Contacts":
					this.Contacts.Add((ContactEntity)relatedEntity);
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
				case "EmployerType":
					DesetupSyncEmployerType(false, true);
					break;
				case "Contacts":
					this.PerformRelatedEntityRemoval(this.Contacts, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_employerType!=null)
			{
				toReturn.Add(_employerType);
			}
			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		protected override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.Contacts);
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
				info.AddValue("_contacts", ((_contacts!=null) && (_contacts.Count>0) && !this.MarkedForDeletion)?_contacts:null);
				info.AddValue("_addressCollectionViaContacts", ((_addressCollectionViaContacts!=null) && (_addressCollectionViaContacts.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaContacts:null);
				info.AddValue("_contactTypesCollectionViaContacts", ((_contactTypesCollectionViaContacts!=null) && (_contactTypesCollectionViaContacts.Count>0) && !this.MarkedForDeletion)?_contactTypesCollectionViaContacts:null);
				info.AddValue("_employerType", (!this.MarkedForDeletion?_employerType:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new EmployerRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Contact' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContacts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactFields.EmployerId, null, ComparisonOperator.Equal, this.EmployerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Address' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaContacts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaContacts"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmployerFields.EmployerId, null, ComparisonOperator.Equal, this.EmployerId, "EmployerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'ContactType' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContactTypesCollectionViaContacts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ContactTypesCollectionViaContacts"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmployerFields.EmployerId, null, ComparisonOperator.Equal, this.EmployerId, "EmployerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'EmployerType' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmployerType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmployerTypeFields.EmployerTypeId, null, ComparisonOperator.Equal, this.EmployerTypeId));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(EmployerEntityFactory));
		}

		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._contacts);
			collectionsQueue.Enqueue(this._addressCollectionViaContacts);
			collectionsQueue.Enqueue(this._contactTypesCollectionViaContacts);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._contacts = (EntityCollection<ContactEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaContacts = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._contactTypesCollectionViaContacts = (EntityCollection<ContactTypeEntity>) collectionsQueue.Dequeue();

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			bool toReturn = false;
			toReturn |=(this._contacts != null);
			toReturn |= (this._addressCollectionViaContacts != null);
			toReturn |= (this._contactTypesCollectionViaContacts != null);
			return toReturn ? true : base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContactEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContactTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactTypeEntityFactory))) : null);
		}

		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("EmployerType", _employerType);
			toReturn.Add("Contacts", _contacts);
			toReturn.Add("AddressCollectionViaContacts", _addressCollectionViaContacts);
			toReturn.Add("ContactTypesCollectionViaContacts", _contactTypesCollectionViaContacts);
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
			_fieldsCustomProperties.Add("EmployerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EmployerTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _employerType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEmployerType(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _employerType, new PropertyChangedEventHandler(OnEmployerTypePropertyChanged), "EmployerType", "Employers", PsychologicalServices.Data.RelationClasses.StaticEmployerRelations.EmployerTypeEntityUsingEmployerTypeIdStatic, true, new int[] { (int)EmployerFieldIndex.EmployerTypeId });
		}

		/// <summary> setups the sync logic for member _employerType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEmployerType(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _employerType, new PropertyChangedEventHandler( OnEmployerTypePropertyChanged ), "EmployerType", "Employers", PsychologicalServices.Data.RelationClasses.StaticEmployerRelations.EmployerTypeEntityUsingEmployerTypeIdStatic, true, new string[] {  }, new int[] { (int)EmployerFieldIndex.EmployerTypeId }); 
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEmployerTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this EmployerEntity</param>
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
		public  static EmployerRelations Relations
		{
			get	{ return new EmployerRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Contact' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContacts
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<ContactEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactEntityFactory))), (IEntityRelation)GetRelationsForField("Contacts")[0], (int)PsychologicalServices.Data.EntityType.EmployerEntity, (int)PsychologicalServices.Data.EntityType.ContactEntity, 0, null, null, null, null, "Contacts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaContacts
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.ContactEntityUsingEmployerId;
				intermediateRelation.SetAliases(string.Empty, "Contact_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)PsychologicalServices.Data.EntityType.EmployerEntity, (int)PsychologicalServices.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaContacts"), null, "AddressCollectionViaContacts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ContactType' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContactTypesCollectionViaContacts
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.ContactEntityUsingEmployerId;
				intermediateRelation.SetAliases(string.Empty, "Contact_");
				return new PrefetchPathElement2(new EntityCollection<ContactTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactTypeEntityFactory))), intermediateRelation,
					(int)PsychologicalServices.Data.EntityType.EmployerEntity, (int)PsychologicalServices.Data.EntityType.ContactTypeEntity, 0, null, null, GetRelationsForField("ContactTypesCollectionViaContacts"), null, "ContactTypesCollectionViaContacts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmployerType' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmployerType
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EmployerTypeEntityFactory))),	(IEntityRelation)GetRelationsForField("EmployerType")[0], (int)PsychologicalServices.Data.EntityType.EmployerEntity, (int)PsychologicalServices.Data.EntityType.EmployerTypeEntity, 0, null, null, null, null, "EmployerType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The EmployerId property of the Entity Employer<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Employers"."EmployerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 EmployerId
		{
			get { return (System.Int32)GetValue((int)EmployerFieldIndex.EmployerId, true); }
			set	{ SetValue((int)EmployerFieldIndex.EmployerId, value); }
		}

		/// <summary> The Name property of the Entity Employer<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Employers"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)EmployerFieldIndex.Name, true); }
			set	{ SetValue((int)EmployerFieldIndex.Name, value); }
		}

		/// <summary> The EmployerTypeId property of the Entity Employer<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Employers"."EmployerTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EmployerTypeId
		{
			get { return (System.Int32)GetValue((int)EmployerFieldIndex.EmployerTypeId, true); }
			set	{ SetValue((int)EmployerFieldIndex.EmployerTypeId, value); }
		}

		/// <summary> The IsActive property of the Entity Employer<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Employers"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)EmployerFieldIndex.IsActive, true); }
			set	{ SetValue((int)EmployerFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ContactEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ContactEntity))]
		public virtual EntityCollection<ContactEntity> Contacts
		{
			get { return GetOrCreateEntityCollection<ContactEntity, ContactEntityFactory>("Employer", true, false, ref _contacts);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> AddressCollectionViaContacts
		{
			get { return GetOrCreateEntityCollection<AddressEntity, AddressEntityFactory>("", false, true, ref _addressCollectionViaContacts);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ContactTypeEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ContactTypeEntity))]
		public virtual EntityCollection<ContactTypeEntity> ContactTypesCollectionViaContacts
		{
			get { return GetOrCreateEntityCollection<ContactTypeEntity, ContactTypeEntityFactory>("", false, true, ref _contactTypesCollectionViaContacts);	}
		}

		/// <summary> Gets / sets related entity of type 'EmployerTypeEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual EmployerTypeEntity EmployerType
		{
			get	{ return _employerType; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncEmployerType(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Employers", "EmployerType", _employerType, true); 
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
			get { return (int)PsychologicalServices.Data.EntityType.EmployerEntity; }
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
