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
	/// Entity class which represents the entity 'Address'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AddressEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AppointmentEntity> _appointments;

		private EntityCollection<CompanyEntity> _companies;
		private EntityCollection<ReferralSourceEntity> _referralSources;
		private EntityCollection<UserEntity> _users;
















		private AddressTypeEntity _addressType;
		private CityEntity _city;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AddressType</summary>
			public static readonly string AddressType = "AddressType";
			/// <summary>Member name City</summary>
			public static readonly string City = "City";
			/// <summary>Member name Appointments</summary>
			public static readonly string Appointments = "Appointments";

			/// <summary>Member name Companies</summary>
			public static readonly string Companies = "Companies";
			/// <summary>Member name ReferralSources</summary>
			public static readonly string ReferralSources = "ReferralSources";
			/// <summary>Member name Users</summary>
			public static readonly string Users = "Users";

















		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AddressEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AddressEntity():base("AddressEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AddressEntity(IEntityFields2 fields):base("AddressEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AddressEntity</param>
		public AddressEntity(IValidator validator):base("AddressEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="addressId">PK value for Address which data should be fetched into this Address object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AddressEntity(System.Int32 addressId):base("AddressEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.AddressId = addressId;
		}

		/// <summary> CTor</summary>
		/// <param name="addressId">PK value for Address which data should be fetched into this Address object</param>
		/// <param name="validator">The custom validator object for this AddressEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AddressEntity(System.Int32 addressId, IValidator validator):base("AddressEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.AddressId = addressId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AddressEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_appointments = (EntityCollection<AppointmentEntity>)info.GetValue("_appointments", typeof(EntityCollection<AppointmentEntity>));

				_companies = (EntityCollection<CompanyEntity>)info.GetValue("_companies", typeof(EntityCollection<CompanyEntity>));
				_referralSources = (EntityCollection<ReferralSourceEntity>)info.GetValue("_referralSources", typeof(EntityCollection<ReferralSourceEntity>));
				_users = (EntityCollection<UserEntity>)info.GetValue("_users", typeof(EntityCollection<UserEntity>));
















				_addressType = (AddressTypeEntity)info.GetValue("_addressType", typeof(AddressTypeEntity));
				if(_addressType!=null)
				{
					_addressType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_city = (CityEntity)info.GetValue("_city", typeof(CityEntity));
				if(_city!=null)
				{
					_city.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AddressFieldIndex)fieldIndex)
			{
				case AddressFieldIndex.CityId:
					DesetupSyncCity(true, false);
					break;
				case AddressFieldIndex.AddressTypeId:
					DesetupSyncAddressType(true, false);
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
				case "AddressType":
					this.AddressType = (AddressTypeEntity)entity;
					break;
				case "City":
					this.City = (CityEntity)entity;
					break;
				case "Appointments":
					this.Appointments.Add((AppointmentEntity)entity);
					break;

				case "Companies":
					this.Companies.Add((CompanyEntity)entity);
					break;
				case "ReferralSources":
					this.ReferralSources.Add((ReferralSourceEntity)entity);
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
			return AddressEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AddressType":
					toReturn.Add(AddressEntity.Relations.AddressTypeEntityUsingAddressTypeId);
					break;
				case "City":
					toReturn.Add(AddressEntity.Relations.CityEntityUsingCityId);
					break;
				case "Appointments":
					toReturn.Add(AddressEntity.Relations.AppointmentEntityUsingLocationId);
					break;

				case "Companies":
					toReturn.Add(AddressEntity.Relations.CompanyEntityUsingAddressId);
					break;
				case "ReferralSources":
					toReturn.Add(AddressEntity.Relations.ReferralSourceEntityUsingAddressId);
					break;
				case "Users":
					toReturn.Add(AddressEntity.Relations.UserEntityUsingAddressId);
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
				case "AddressType":
					SetupSyncAddressType(relatedEntity);
					break;
				case "City":
					SetupSyncCity(relatedEntity);
					break;
				case "Appointments":
					this.Appointments.Add((AppointmentEntity)relatedEntity);
					break;

				case "Companies":
					this.Companies.Add((CompanyEntity)relatedEntity);
					break;
				case "ReferralSources":
					this.ReferralSources.Add((ReferralSourceEntity)relatedEntity);
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
				case "AddressType":
					DesetupSyncAddressType(false, true);
					break;
				case "City":
					DesetupSyncCity(false, true);
					break;
				case "Appointments":
					base.PerformRelatedEntityRemoval(this.Appointments, relatedEntity, signalRelatedEntityManyToOne);
					break;

				case "Companies":
					base.PerformRelatedEntityRemoval(this.Companies, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ReferralSources":
					base.PerformRelatedEntityRemoval(this.ReferralSources, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_addressType!=null)
			{
				toReturn.Add(_addressType);
			}
			if(_city!=null)
			{
				toReturn.Add(_city);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.Appointments);

			toReturn.Add(this.Companies);
			toReturn.Add(this.ReferralSources);
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
				info.AddValue("_appointments", ((_appointments!=null) && (_appointments.Count>0) && !this.MarkedForDeletion)?_appointments:null);

				info.AddValue("_companies", ((_companies!=null) && (_companies.Count>0) && !this.MarkedForDeletion)?_companies:null);
				info.AddValue("_referralSources", ((_referralSources!=null) && (_referralSources.Count>0) && !this.MarkedForDeletion)?_referralSources:null);
				info.AddValue("_users", ((_users!=null) && (_users.Count>0) && !this.MarkedForDeletion)?_users:null);
















				info.AddValue("_addressType", (!this.MarkedForDeletion?_addressType:null));
				info.AddValue("_city", (!this.MarkedForDeletion?_city:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AddressFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AddressFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AddressRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Appointment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAppointments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AppointmentFields.LocationId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}


		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Company' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCompanies()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CompanyFields.AddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ReferralSource' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReferralSources()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceFields.AddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'User' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUsers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.AddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

















		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AddressType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressTypeFields.AddressTypeId, null, ComparisonOperator.Equal, this.AddressTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'City' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CityFields.CityId, null, ComparisonOperator.Equal, this.CityId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(PsychologicalServices.Data.EntityType.AddressEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._appointments);

			collectionsQueue.Enqueue(this._companies);
			collectionsQueue.Enqueue(this._referralSources);
			collectionsQueue.Enqueue(this._users);
















		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._appointments = (EntityCollection<AppointmentEntity>) collectionsQueue.Dequeue();

			this._companies = (EntityCollection<CompanyEntity>) collectionsQueue.Dequeue();
			this._referralSources = (EntityCollection<ReferralSourceEntity>) collectionsQueue.Dequeue();
			this._users = (EntityCollection<UserEntity>) collectionsQueue.Dequeue();
















		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._appointments != null)
			{
				return true;
			}

			if (this._companies != null)
			{
				return true;
			}
			if (this._referralSources != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentEntityFactory))) : null);

			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CompanyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReferralSourceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceEntityFactory))) : null);
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
			toReturn.Add("AddressType", _addressType);
			toReturn.Add("City", _city);
			toReturn.Add("Appointments", _appointments);

			toReturn.Add("Companies", _companies);
			toReturn.Add("ReferralSources", _referralSources);
			toReturn.Add("Users", _users);

















			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_appointments!=null)
			{
				_appointments.ActiveContext = base.ActiveContext;
			}

			if(_companies!=null)
			{
				_companies.ActiveContext = base.ActiveContext;
			}
			if(_referralSources!=null)
			{
				_referralSources.ActiveContext = base.ActiveContext;
			}
			if(_users!=null)
			{
				_users.ActiveContext = base.ActiveContext;
			}
















			if(_addressType!=null)
			{
				_addressType.ActiveContext = base.ActiveContext;
			}
			if(_city!=null)
			{
				_city.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_appointments = null;

			_companies = null;
			_referralSources = null;
			_users = null;
















			_addressType = null;
			_city = null;

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

			_fieldsCustomProperties.Add("AddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Street", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Suite", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CityId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PostalCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AddressTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _addressType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAddressType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _addressType, new PropertyChangedEventHandler( OnAddressTypePropertyChanged ), "AddressType", AddressEntity.Relations.AddressTypeEntityUsingAddressTypeId, true, signalRelatedEntity, "Addresses", resetFKFields, new int[] { (int)AddressFieldIndex.AddressTypeId } );		
			_addressType = null;
		}

		/// <summary> setups the sync logic for member _addressType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAddressType(IEntity2 relatedEntity)
		{
			if(_addressType!=relatedEntity)
			{
				DesetupSyncAddressType(true, true);
				_addressType = (AddressTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _addressType, new PropertyChangedEventHandler( OnAddressTypePropertyChanged ), "AddressType", AddressEntity.Relations.AddressTypeEntityUsingAddressTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAddressTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _city</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCity(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _city, new PropertyChangedEventHandler( OnCityPropertyChanged ), "City", AddressEntity.Relations.CityEntityUsingCityId, true, signalRelatedEntity, "Addresses", resetFKFields, new int[] { (int)AddressFieldIndex.CityId } );		
			_city = null;
		}

		/// <summary> setups the sync logic for member _city</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCity(IEntity2 relatedEntity)
		{
			if(_city!=relatedEntity)
			{
				DesetupSyncCity(true, true);
				_city = (CityEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _city, new PropertyChangedEventHandler( OnCityPropertyChanged ), "City", AddressEntity.Relations.CityEntityUsingCityId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCityPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AddressEntity</param>
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
		public  static AddressRelations Relations
		{
			get	{ return new AddressRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Appointment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAppointments
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("Appointments")[0], (int)PsychologicalServices.Data.EntityType.AddressEntity, (int)PsychologicalServices.Data.EntityType.AppointmentEntity, 0, null, null, null, null, "Appointments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Company' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCompanies
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CompanyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory))),
					(IEntityRelation)GetRelationsForField("Companies")[0], (int)PsychologicalServices.Data.EntityType.AddressEntity, (int)PsychologicalServices.Data.EntityType.CompanyEntity, 0, null, null, null, null, "Companies", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReferralSource' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReferralSources
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ReferralSourceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceEntityFactory))),
					(IEntityRelation)GetRelationsForField("ReferralSources")[0], (int)PsychologicalServices.Data.EntityType.AddressEntity, (int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, 0, null, null, null, null, "ReferralSources", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("Users")[0], (int)PsychologicalServices.Data.EntityType.AddressEntity, (int)PsychologicalServices.Data.EntityType.UserEntity, 0, null, null, null, null, "Users", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

















		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AddressType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AddressTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("AddressType")[0], (int)PsychologicalServices.Data.EntityType.AddressEntity, (int)PsychologicalServices.Data.EntityType.AddressTypeEntity, 0, null, null, null, null, "AddressType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'City' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCity
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory))),
					(IEntityRelation)GetRelationsForField("City")[0], (int)PsychologicalServices.Data.EntityType.AddressEntity, (int)PsychologicalServices.Data.EntityType.CityEntity, 0, null, null, null, null, "City", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AddressEntity.CustomProperties;}
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
			get { return AddressEntity.FieldsCustomProperties;}
		}

		/// <summary> The AddressId property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Addresses"."AddressId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 AddressId
		{
			get { return (System.Int32)GetValue((int)AddressFieldIndex.AddressId, true); }
			set	{ SetValue((int)AddressFieldIndex.AddressId, value); }
		}

		/// <summary> The Name property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Addresses"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)AddressFieldIndex.Name, true); }
			set	{ SetValue((int)AddressFieldIndex.Name, value); }
		}

		/// <summary> The Street property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Addresses"."Street"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Street
		{
			get { return (System.String)GetValue((int)AddressFieldIndex.Street, true); }
			set	{ SetValue((int)AddressFieldIndex.Street, value); }
		}

		/// <summary> The Suite property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Addresses"."Suite"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Suite
		{
			get { return (System.String)GetValue((int)AddressFieldIndex.Suite, true); }
			set	{ SetValue((int)AddressFieldIndex.Suite, value); }
		}

		/// <summary> The CityId property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Addresses"."CityId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CityId
		{
			get { return (System.Int32)GetValue((int)AddressFieldIndex.CityId, true); }
			set	{ SetValue((int)AddressFieldIndex.CityId, value); }
		}

		/// <summary> The PostalCode property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Addresses"."PostalCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PostalCode
		{
			get { return (System.String)GetValue((int)AddressFieldIndex.PostalCode, true); }
			set	{ SetValue((int)AddressFieldIndex.PostalCode, value); }
		}

		/// <summary> The AddressTypeId property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Addresses"."AddressTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 AddressTypeId
		{
			get { return (System.Int32)GetValue((int)AddressFieldIndex.AddressTypeId, true); }
			set	{ SetValue((int)AddressFieldIndex.AddressTypeId, value); }
		}

		/// <summary> The IsActive property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Addresses"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)AddressFieldIndex.IsActive, true); }
			set	{ SetValue((int)AddressFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AppointmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AppointmentEntity))]
		public virtual EntityCollection<AppointmentEntity> Appointments
		{
			get
			{
				if(_appointments==null)
				{
					_appointments = new EntityCollection<AppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentEntityFactory)));
					_appointments.SetContainingEntityInfo(this, "Location");
				}
				return _appointments;
			}
		}


		/// <summary> Gets the EntityCollection with the related entities of type 'CompanyEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CompanyEntity))]
		public virtual EntityCollection<CompanyEntity> Companies
		{
			get
			{
				if(_companies==null)
				{
					_companies = new EntityCollection<CompanyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory)));
					_companies.SetContainingEntityInfo(this, "Address");
				}
				return _companies;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ReferralSourceEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ReferralSourceEntity))]
		public virtual EntityCollection<ReferralSourceEntity> ReferralSources
		{
			get
			{
				if(_referralSources==null)
				{
					_referralSources = new EntityCollection<ReferralSourceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceEntityFactory)));
					_referralSources.SetContainingEntityInfo(this, "Address");
				}
				return _referralSources;
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
					_users.SetContainingEntityInfo(this, "Address");
				}
				return _users;
			}
		}

















		/// <summary> Gets / sets related entity of type 'AddressTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AddressTypeEntity AddressType
		{
			get
			{
				return _addressType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAddressType(value);
				}
				else
				{
					if(value==null)
					{
						if(_addressType != null)
						{
							_addressType.UnsetRelatedEntity(this, "Addresses");
						}
					}
					else
					{
						if(_addressType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Addresses");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CityEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CityEntity City
		{
			get
			{
				return _city;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCity(value);
				}
				else
				{
					if(value==null)
					{
						if(_city != null)
						{
							_city.UnsetRelatedEntity(this, "Addresses");
						}
					}
					else
					{
						if(_city!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Addresses");
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
			get { return (int)PsychologicalServices.Data.EntityType.AddressEntity; }
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
