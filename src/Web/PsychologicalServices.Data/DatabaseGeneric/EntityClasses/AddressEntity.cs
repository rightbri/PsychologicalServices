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
	/// Entity class which represents the entity 'Address'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AddressEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AddressAddressTypeEntity> _addressAddressTypes;
		private EntityCollection<AppointmentEntity> _appointments;

		private EntityCollection<CompanyEntity> _companies;
		private EntityCollection<ContactEntity> _contacts;
		private EntityCollection<ReferralSourceEntity> _referralSources;
		private EntityCollection<UserEntity> _users;






		private EntityCollection<ContactTypeEntity> _contactTypesCollectionViaContacts;
		private EntityCollection<EmployerEntity> _employerCollectionViaContacts;











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
			/// <summary>Member name City</summary>
			public static readonly string City = "City";
			/// <summary>Member name AddressAddressTypes</summary>
			public static readonly string AddressAddressTypes = "AddressAddressTypes";
			/// <summary>Member name Appointments</summary>
			public static readonly string Appointments = "Appointments";

			/// <summary>Member name Companies</summary>
			public static readonly string Companies = "Companies";
			/// <summary>Member name Contacts</summary>
			public static readonly string Contacts = "Contacts";
			/// <summary>Member name ReferralSources</summary>
			public static readonly string ReferralSources = "ReferralSources";
			/// <summary>Member name Users</summary>
			public static readonly string Users = "Users";






			/// <summary>Member name ContactTypesCollectionViaContacts</summary>
			public static readonly string ContactTypesCollectionViaContacts = "ContactTypesCollectionViaContacts";
			/// <summary>Member name EmployerCollectionViaContacts</summary>
			public static readonly string EmployerCollectionViaContacts = "EmployerCollectionViaContacts";












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
				_addressAddressTypes = (EntityCollection<AddressAddressTypeEntity>)info.GetValue("_addressAddressTypes", typeof(EntityCollection<AddressAddressTypeEntity>));
				_appointments = (EntityCollection<AppointmentEntity>)info.GetValue("_appointments", typeof(EntityCollection<AppointmentEntity>));

				_companies = (EntityCollection<CompanyEntity>)info.GetValue("_companies", typeof(EntityCollection<CompanyEntity>));
				_contacts = (EntityCollection<ContactEntity>)info.GetValue("_contacts", typeof(EntityCollection<ContactEntity>));
				_referralSources = (EntityCollection<ReferralSourceEntity>)info.GetValue("_referralSources", typeof(EntityCollection<ReferralSourceEntity>));
				_users = (EntityCollection<UserEntity>)info.GetValue("_users", typeof(EntityCollection<UserEntity>));






				_contactTypesCollectionViaContacts = (EntityCollection<ContactTypeEntity>)info.GetValue("_contactTypesCollectionViaContacts", typeof(EntityCollection<ContactTypeEntity>));
				_employerCollectionViaContacts = (EntityCollection<EmployerEntity>)info.GetValue("_employerCollectionViaContacts", typeof(EntityCollection<EmployerEntity>));











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
				case "City":
					this.City = (CityEntity)entity;
					break;
				case "AddressAddressTypes":
					this.AddressAddressTypes.Add((AddressAddressTypeEntity)entity);
					break;
				case "Appointments":
					this.Appointments.Add((AppointmentEntity)entity);
					break;

				case "Companies":
					this.Companies.Add((CompanyEntity)entity);
					break;
				case "Contacts":
					this.Contacts.Add((ContactEntity)entity);
					break;
				case "ReferralSources":
					this.ReferralSources.Add((ReferralSourceEntity)entity);
					break;
				case "Users":
					this.Users.Add((UserEntity)entity);
					break;






				case "ContactTypesCollectionViaContacts":
					this.ContactTypesCollectionViaContacts.IsReadOnly = false;
					this.ContactTypesCollectionViaContacts.Add((ContactTypeEntity)entity);
					this.ContactTypesCollectionViaContacts.IsReadOnly = true;
					break;
				case "EmployerCollectionViaContacts":
					this.EmployerCollectionViaContacts.IsReadOnly = false;
					this.EmployerCollectionViaContacts.Add((EmployerEntity)entity);
					this.EmployerCollectionViaContacts.IsReadOnly = true;
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
				case "City":
					toReturn.Add(AddressEntity.Relations.CityEntityUsingCityId);
					break;
				case "AddressAddressTypes":
					toReturn.Add(AddressEntity.Relations.AddressAddressTypeEntityUsingAddressId);
					break;
				case "Appointments":
					toReturn.Add(AddressEntity.Relations.AppointmentEntityUsingLocationId);
					break;

				case "Companies":
					toReturn.Add(AddressEntity.Relations.CompanyEntityUsingAddressId);
					break;
				case "Contacts":
					toReturn.Add(AddressEntity.Relations.ContactEntityUsingAddressId);
					break;
				case "ReferralSources":
					toReturn.Add(AddressEntity.Relations.ReferralSourceEntityUsingAddressId);
					break;
				case "Users":
					toReturn.Add(AddressEntity.Relations.UserEntityUsingAddressId);
					break;






				case "ContactTypesCollectionViaContacts":
					toReturn.Add(AddressEntity.Relations.ContactEntityUsingAddressId, "AddressEntity__", "Contact_", JoinHint.None);
					toReturn.Add(ContactEntity.Relations.ContactTypeEntityUsingContactTypeId, "Contact_", string.Empty, JoinHint.None);
					break;
				case "EmployerCollectionViaContacts":
					toReturn.Add(AddressEntity.Relations.ContactEntityUsingAddressId, "AddressEntity__", "Contact_", JoinHint.None);
					toReturn.Add(ContactEntity.Relations.EmployerEntityUsingEmployerId, "Contact_", string.Empty, JoinHint.None);
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
				case "City":
					SetupSyncCity(relatedEntity);
					break;
				case "AddressAddressTypes":
					this.AddressAddressTypes.Add((AddressAddressTypeEntity)relatedEntity);
					break;
				case "Appointments":
					this.Appointments.Add((AppointmentEntity)relatedEntity);
					break;

				case "Companies":
					this.Companies.Add((CompanyEntity)relatedEntity);
					break;
				case "Contacts":
					this.Contacts.Add((ContactEntity)relatedEntity);
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
				case "City":
					DesetupSyncCity(false, true);
					break;
				case "AddressAddressTypes":
					base.PerformRelatedEntityRemoval(this.AddressAddressTypes, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Appointments":
					base.PerformRelatedEntityRemoval(this.Appointments, relatedEntity, signalRelatedEntityManyToOne);
					break;

				case "Companies":
					base.PerformRelatedEntityRemoval(this.Companies, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Contacts":
					base.PerformRelatedEntityRemoval(this.Contacts, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.AddressAddressTypes);
			toReturn.Add(this.Appointments);

			toReturn.Add(this.Companies);
			toReturn.Add(this.Contacts);
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
				info.AddValue("_addressAddressTypes", ((_addressAddressTypes!=null) && (_addressAddressTypes.Count>0) && !this.MarkedForDeletion)?_addressAddressTypes:null);
				info.AddValue("_appointments", ((_appointments!=null) && (_appointments.Count>0) && !this.MarkedForDeletion)?_appointments:null);

				info.AddValue("_companies", ((_companies!=null) && (_companies.Count>0) && !this.MarkedForDeletion)?_companies:null);
				info.AddValue("_contacts", ((_contacts!=null) && (_contacts.Count>0) && !this.MarkedForDeletion)?_contacts:null);
				info.AddValue("_referralSources", ((_referralSources!=null) && (_referralSources.Count>0) && !this.MarkedForDeletion)?_referralSources:null);
				info.AddValue("_users", ((_users!=null) && (_users.Count>0) && !this.MarkedForDeletion)?_users:null);






				info.AddValue("_contactTypesCollectionViaContacts", ((_contactTypesCollectionViaContacts!=null) && (_contactTypesCollectionViaContacts.Count>0) && !this.MarkedForDeletion)?_contactTypesCollectionViaContacts:null);
				info.AddValue("_employerCollectionViaContacts", ((_employerCollectionViaContacts!=null) && (_employerCollectionViaContacts.Count>0) && !this.MarkedForDeletion)?_employerCollectionViaContacts:null);











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
		/// the related entities of type 'AddressAddressType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressAddressTypes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressAddressTypeFields.AddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
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
		/// the related entities of type 'Contact' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContacts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactFields.AddressId, null, ComparisonOperator.Equal, this.AddressId));
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
		/// the related entities of type 'ContactType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContactTypesCollectionViaContacts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ContactTypesCollectionViaContacts"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Employer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmployerCollectionViaContacts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmployerCollectionViaContacts"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
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
			collectionsQueue.Enqueue(this._addressAddressTypes);
			collectionsQueue.Enqueue(this._appointments);

			collectionsQueue.Enqueue(this._companies);
			collectionsQueue.Enqueue(this._contacts);
			collectionsQueue.Enqueue(this._referralSources);
			collectionsQueue.Enqueue(this._users);






			collectionsQueue.Enqueue(this._contactTypesCollectionViaContacts);
			collectionsQueue.Enqueue(this._employerCollectionViaContacts);











		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._addressAddressTypes = (EntityCollection<AddressAddressTypeEntity>) collectionsQueue.Dequeue();
			this._appointments = (EntityCollection<AppointmentEntity>) collectionsQueue.Dequeue();

			this._companies = (EntityCollection<CompanyEntity>) collectionsQueue.Dequeue();
			this._contacts = (EntityCollection<ContactEntity>) collectionsQueue.Dequeue();
			this._referralSources = (EntityCollection<ReferralSourceEntity>) collectionsQueue.Dequeue();
			this._users = (EntityCollection<UserEntity>) collectionsQueue.Dequeue();






			this._contactTypesCollectionViaContacts = (EntityCollection<ContactTypeEntity>) collectionsQueue.Dequeue();
			this._employerCollectionViaContacts = (EntityCollection<EmployerEntity>) collectionsQueue.Dequeue();











		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._addressAddressTypes != null)
			{
				return true;
			}
			if (this._appointments != null)
			{
				return true;
			}

			if (this._companies != null)
			{
				return true;
			}
			if (this._contacts != null)
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






			if (this._contactTypesCollectionViaContacts != null)
			{
				return true;
			}
			if (this._employerCollectionViaContacts != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressAddressTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressAddressTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentEntityFactory))) : null);

			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CompanyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContactEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReferralSourceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))) : null);






			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContactTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmployerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmployerEntityFactory))) : null);











		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("City", _city);
			toReturn.Add("AddressAddressTypes", _addressAddressTypes);
			toReturn.Add("Appointments", _appointments);

			toReturn.Add("Companies", _companies);
			toReturn.Add("Contacts", _contacts);
			toReturn.Add("ReferralSources", _referralSources);
			toReturn.Add("Users", _users);






			toReturn.Add("ContactTypesCollectionViaContacts", _contactTypesCollectionViaContacts);
			toReturn.Add("EmployerCollectionViaContacts", _employerCollectionViaContacts);












			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_addressAddressTypes!=null)
			{
				_addressAddressTypes.ActiveContext = base.ActiveContext;
			}
			if(_appointments!=null)
			{
				_appointments.ActiveContext = base.ActiveContext;
			}

			if(_companies!=null)
			{
				_companies.ActiveContext = base.ActiveContext;
			}
			if(_contacts!=null)
			{
				_contacts.ActiveContext = base.ActiveContext;
			}
			if(_referralSources!=null)
			{
				_referralSources.ActiveContext = base.ActiveContext;
			}
			if(_users!=null)
			{
				_users.ActiveContext = base.ActiveContext;
			}






			if(_contactTypesCollectionViaContacts!=null)
			{
				_contactTypesCollectionViaContacts.ActiveContext = base.ActiveContext;
			}
			if(_employerCollectionViaContacts!=null)
			{
				_employerCollectionViaContacts.ActiveContext = base.ActiveContext;
			}











			if(_city!=null)
			{
				_city.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_addressAddressTypes = null;
			_appointments = null;

			_companies = null;
			_contacts = null;
			_referralSources = null;
			_users = null;






			_contactTypesCollectionViaContacts = null;
			_employerCollectionViaContacts = null;











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

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

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

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AddressAddressType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressAddressTypes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AddressAddressTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressAddressTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("AddressAddressTypes")[0], (int)PsychologicalServices.Data.EntityType.AddressEntity, (int)PsychologicalServices.Data.EntityType.AddressAddressTypeEntity, 0, null, null, null, null, "AddressAddressTypes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
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
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Contact' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContacts
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ContactEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactEntityFactory))),
					(IEntityRelation)GetRelationsForField("Contacts")[0], (int)PsychologicalServices.Data.EntityType.AddressEntity, (int)PsychologicalServices.Data.EntityType.ContactEntity, 0, null, null, null, null, "Contacts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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







		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ContactType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContactTypesCollectionViaContacts
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.ContactEntityUsingAddressId;
				intermediateRelation.SetAliases(string.Empty, "Contact_");
				return new PrefetchPathElement2(new EntityCollection<ContactTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactTypeEntityFactory))), intermediateRelation,
					(int)PsychologicalServices.Data.EntityType.AddressEntity, (int)PsychologicalServices.Data.EntityType.ContactTypeEntity, 0, null, null, GetRelationsForField("ContactTypesCollectionViaContacts"), null, "ContactTypesCollectionViaContacts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Employer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmployerCollectionViaContacts
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.ContactEntityUsingAddressId;
				intermediateRelation.SetAliases(string.Empty, "Contact_");
				return new PrefetchPathElement2(new EntityCollection<EmployerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmployerEntityFactory))), intermediateRelation,
					(int)PsychologicalServices.Data.EntityType.AddressEntity, (int)PsychologicalServices.Data.EntityType.EmployerEntity, 0, null, null, GetRelationsForField("EmployerCollectionViaContacts"), null, "EmployerCollectionViaContacts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressAddressTypeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressAddressTypeEntity))]
		public virtual EntityCollection<AddressAddressTypeEntity> AddressAddressTypes
		{
			get
			{
				if(_addressAddressTypes==null)
				{
					_addressAddressTypes = new EntityCollection<AddressAddressTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressAddressTypeEntityFactory)));
					_addressAddressTypes.SetContainingEntityInfo(this, "Address");
				}
				return _addressAddressTypes;
			}
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

		/// <summary> Gets the EntityCollection with the related entities of type 'ContactEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ContactEntity))]
		public virtual EntityCollection<ContactEntity> Contacts
		{
			get
			{
				if(_contacts==null)
				{
					_contacts = new EntityCollection<ContactEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactEntityFactory)));
					_contacts.SetContainingEntityInfo(this, "Address");
				}
				return _contacts;
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







		/// <summary> Gets the EntityCollection with the related entities of type 'ContactTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ContactTypeEntity))]
		public virtual EntityCollection<ContactTypeEntity> ContactTypesCollectionViaContacts
		{
			get
			{
				if(_contactTypesCollectionViaContacts==null)
				{
					_contactTypesCollectionViaContacts = new EntityCollection<ContactTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactTypeEntityFactory)));
					_contactTypesCollectionViaContacts.IsReadOnly=true;
				}
				return _contactTypesCollectionViaContacts;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmployerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmployerEntity))]
		public virtual EntityCollection<EmployerEntity> EmployerCollectionViaContacts
		{
			get
			{
				if(_employerCollectionViaContacts==null)
				{
					_employerCollectionViaContacts = new EntityCollection<EmployerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmployerEntityFactory)));
					_employerCollectionViaContacts.IsReadOnly=true;
				}
				return _employerCollectionViaContacts;
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
