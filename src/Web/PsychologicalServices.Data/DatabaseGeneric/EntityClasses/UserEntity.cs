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
	/// Entity class which represents the entity 'User'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class UserEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations




		private EntityCollection<InvoiceEntity> _invoices;
		private EntityCollection<NoteEntity> _noteUpdater;
		private EntityCollection<NoteEntity> _noteCreator;
		private EntityCollection<UserNoteEntity> _userNotes;
		private EntityCollection<UserRoleEntity> _userRoles;
		private EntityCollection<UserTravelFeeEntity> _userTravelFees;
		private EntityCollection<UserUnavailabilityEntity> _userUnavailabilities;





















		private CompanyEntity _company;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Company</summary>
			public static readonly string Company = "Company";




			/// <summary>Member name Invoices</summary>
			public static readonly string Invoices = "Invoices";
			/// <summary>Member name NoteUpdater</summary>
			public static readonly string NoteUpdater = "NoteUpdater";
			/// <summary>Member name NoteCreator</summary>
			public static readonly string NoteCreator = "NoteCreator";
			/// <summary>Member name UserNotes</summary>
			public static readonly string UserNotes = "UserNotes";
			/// <summary>Member name UserRoles</summary>
			public static readonly string UserRoles = "UserRoles";
			/// <summary>Member name UserTravelFees</summary>
			public static readonly string UserTravelFees = "UserTravelFees";
			/// <summary>Member name UserUnavailabilities</summary>
			public static readonly string UserUnavailabilities = "UserUnavailabilities";






















		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static UserEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public UserEntity():base("UserEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public UserEntity(IEntityFields2 fields):base("UserEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this UserEntity</param>
		public UserEntity(IValidator validator):base("UserEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public UserEntity(System.Int32 userId):base("UserEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.UserId = userId;
		}

		/// <summary> CTor</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="validator">The custom validator object for this UserEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public UserEntity(System.Int32 userId, IValidator validator):base("UserEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.UserId = userId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected UserEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{




				_invoices = (EntityCollection<InvoiceEntity>)info.GetValue("_invoices", typeof(EntityCollection<InvoiceEntity>));
				_noteUpdater = (EntityCollection<NoteEntity>)info.GetValue("_noteUpdater", typeof(EntityCollection<NoteEntity>));
				_noteCreator = (EntityCollection<NoteEntity>)info.GetValue("_noteCreator", typeof(EntityCollection<NoteEntity>));
				_userNotes = (EntityCollection<UserNoteEntity>)info.GetValue("_userNotes", typeof(EntityCollection<UserNoteEntity>));
				_userRoles = (EntityCollection<UserRoleEntity>)info.GetValue("_userRoles", typeof(EntityCollection<UserRoleEntity>));
				_userTravelFees = (EntityCollection<UserTravelFeeEntity>)info.GetValue("_userTravelFees", typeof(EntityCollection<UserTravelFeeEntity>));
				_userUnavailabilities = (EntityCollection<UserUnavailabilityEntity>)info.GetValue("_userUnavailabilities", typeof(EntityCollection<UserUnavailabilityEntity>));





















				_company = (CompanyEntity)info.GetValue("_company", typeof(CompanyEntity));
				if(_company!=null)
				{
					_company.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((UserFieldIndex)fieldIndex)
			{
				case UserFieldIndex.CompanyId:
					DesetupSyncCompany(true, false);
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
				case "Company":
					this.Company = (CompanyEntity)entity;
					break;




				case "Invoices":
					this.Invoices.Add((InvoiceEntity)entity);
					break;
				case "NoteUpdater":
					this.NoteUpdater.Add((NoteEntity)entity);
					break;
				case "NoteCreator":
					this.NoteCreator.Add((NoteEntity)entity);
					break;
				case "UserNotes":
					this.UserNotes.Add((UserNoteEntity)entity);
					break;
				case "UserRoles":
					this.UserRoles.Add((UserRoleEntity)entity);
					break;
				case "UserTravelFees":
					this.UserTravelFees.Add((UserTravelFeeEntity)entity);
					break;
				case "UserUnavailabilities":
					this.UserUnavailabilities.Add((UserUnavailabilityEntity)entity);
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
			return UserEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Company":
					toReturn.Add(UserEntity.Relations.CompanyEntityUsingCompanyId);
					break;




				case "Invoices":
					toReturn.Add(UserEntity.Relations.InvoiceEntityUsingPayableToId);
					break;
				case "NoteUpdater":
					toReturn.Add(UserEntity.Relations.NoteEntityUsingUpdateUserId);
					break;
				case "NoteCreator":
					toReturn.Add(UserEntity.Relations.NoteEntityUsingCreateUserId);
					break;
				case "UserNotes":
					toReturn.Add(UserEntity.Relations.UserNoteEntityUsingUserId);
					break;
				case "UserRoles":
					toReturn.Add(UserEntity.Relations.UserRoleEntityUsingUserId);
					break;
				case "UserTravelFees":
					toReturn.Add(UserEntity.Relations.UserTravelFeeEntityUsingUserId);
					break;
				case "UserUnavailabilities":
					toReturn.Add(UserEntity.Relations.UserUnavailabilityEntityUsingUserId);
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
				case "Company":
					SetupSyncCompany(relatedEntity);
					break;




				case "Invoices":
					this.Invoices.Add((InvoiceEntity)relatedEntity);
					break;
				case "NoteUpdater":
					this.NoteUpdater.Add((NoteEntity)relatedEntity);
					break;
				case "NoteCreator":
					this.NoteCreator.Add((NoteEntity)relatedEntity);
					break;
				case "UserNotes":
					this.UserNotes.Add((UserNoteEntity)relatedEntity);
					break;
				case "UserRoles":
					this.UserRoles.Add((UserRoleEntity)relatedEntity);
					break;
				case "UserTravelFees":
					this.UserTravelFees.Add((UserTravelFeeEntity)relatedEntity);
					break;
				case "UserUnavailabilities":
					this.UserUnavailabilities.Add((UserUnavailabilityEntity)relatedEntity);
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
				case "Company":
					DesetupSyncCompany(false, true);
					break;




				case "Invoices":
					base.PerformRelatedEntityRemoval(this.Invoices, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "NoteUpdater":
					base.PerformRelatedEntityRemoval(this.NoteUpdater, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "NoteCreator":
					base.PerformRelatedEntityRemoval(this.NoteCreator, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "UserNotes":
					base.PerformRelatedEntityRemoval(this.UserNotes, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "UserRoles":
					base.PerformRelatedEntityRemoval(this.UserRoles, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "UserTravelFees":
					base.PerformRelatedEntityRemoval(this.UserTravelFees, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "UserUnavailabilities":
					base.PerformRelatedEntityRemoval(this.UserUnavailabilities, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_company!=null)
			{
				toReturn.Add(_company);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();




			toReturn.Add(this.Invoices);
			toReturn.Add(this.NoteUpdater);
			toReturn.Add(this.NoteCreator);
			toReturn.Add(this.UserNotes);
			toReturn.Add(this.UserRoles);
			toReturn.Add(this.UserTravelFees);
			toReturn.Add(this.UserUnavailabilities);

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




				info.AddValue("_invoices", ((_invoices!=null) && (_invoices.Count>0) && !this.MarkedForDeletion)?_invoices:null);
				info.AddValue("_noteUpdater", ((_noteUpdater!=null) && (_noteUpdater.Count>0) && !this.MarkedForDeletion)?_noteUpdater:null);
				info.AddValue("_noteCreator", ((_noteCreator!=null) && (_noteCreator.Count>0) && !this.MarkedForDeletion)?_noteCreator:null);
				info.AddValue("_userNotes", ((_userNotes!=null) && (_userNotes.Count>0) && !this.MarkedForDeletion)?_userNotes:null);
				info.AddValue("_userRoles", ((_userRoles!=null) && (_userRoles.Count>0) && !this.MarkedForDeletion)?_userRoles:null);
				info.AddValue("_userTravelFees", ((_userTravelFees!=null) && (_userTravelFees.Count>0) && !this.MarkedForDeletion)?_userTravelFees:null);
				info.AddValue("_userUnavailabilities", ((_userUnavailabilities!=null) && (_userUnavailabilities.Count>0) && !this.MarkedForDeletion)?_userUnavailabilities:null);





















				info.AddValue("_company", (!this.MarkedForDeletion?_company:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(UserFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(UserFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new UserRelations().GetAllRelations();
		}
		





		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Invoice' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInvoices()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InvoiceFields.PayableToId, null, ComparisonOperator.Equal, this.UserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Note' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNoteUpdater()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoteFields.UpdateUserId, null, ComparisonOperator.Equal, this.UserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Note' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNoteCreator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoteFields.CreateUserId, null, ComparisonOperator.Equal, this.UserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'UserNote' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUserNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserNoteFields.UserId, null, ComparisonOperator.Equal, this.UserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'UserRole' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUserRoles()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserRoleFields.UserId, null, ComparisonOperator.Equal, this.UserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'UserTravelFee' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUserTravelFees()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserTravelFeeFields.UserId, null, ComparisonOperator.Equal, this.UserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'UserUnavailability' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUserUnavailabilities()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserUnavailabilityFields.UserId, null, ComparisonOperator.Equal, this.UserId));
			return bucket;
		}






















		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Company' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCompany()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CompanyFields.CompanyId, null, ComparisonOperator.Equal, this.CompanyId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(PsychologicalServices.Data.EntityType.UserEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);




			collectionsQueue.Enqueue(this._invoices);
			collectionsQueue.Enqueue(this._noteUpdater);
			collectionsQueue.Enqueue(this._noteCreator);
			collectionsQueue.Enqueue(this._userNotes);
			collectionsQueue.Enqueue(this._userRoles);
			collectionsQueue.Enqueue(this._userTravelFees);
			collectionsQueue.Enqueue(this._userUnavailabilities);





















		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);




			this._invoices = (EntityCollection<InvoiceEntity>) collectionsQueue.Dequeue();
			this._noteUpdater = (EntityCollection<NoteEntity>) collectionsQueue.Dequeue();
			this._noteCreator = (EntityCollection<NoteEntity>) collectionsQueue.Dequeue();
			this._userNotes = (EntityCollection<UserNoteEntity>) collectionsQueue.Dequeue();
			this._userRoles = (EntityCollection<UserRoleEntity>) collectionsQueue.Dequeue();
			this._userTravelFees = (EntityCollection<UserTravelFeeEntity>) collectionsQueue.Dequeue();
			this._userUnavailabilities = (EntityCollection<UserUnavailabilityEntity>) collectionsQueue.Dequeue();





















		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{




			if (this._invoices != null)
			{
				return true;
			}
			if (this._noteUpdater != null)
			{
				return true;
			}
			if (this._noteCreator != null)
			{
				return true;
			}
			if (this._userNotes != null)
			{
				return true;
			}
			if (this._userRoles != null)
			{
				return true;
			}
			if (this._userTravelFees != null)
			{
				return true;
			}
			if (this._userUnavailabilities != null)
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




			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<InvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoteEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoteEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserNoteEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserRoleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserTravelFeeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserTravelFeeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserUnavailabilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserUnavailabilityEntityFactory))) : null);





















		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Company", _company);




			toReturn.Add("Invoices", _invoices);
			toReturn.Add("NoteUpdater", _noteUpdater);
			toReturn.Add("NoteCreator", _noteCreator);
			toReturn.Add("UserNotes", _userNotes);
			toReturn.Add("UserRoles", _userRoles);
			toReturn.Add("UserTravelFees", _userTravelFees);
			toReturn.Add("UserUnavailabilities", _userUnavailabilities);






















			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{




			if(_invoices!=null)
			{
				_invoices.ActiveContext = base.ActiveContext;
			}
			if(_noteUpdater!=null)
			{
				_noteUpdater.ActiveContext = base.ActiveContext;
			}
			if(_noteCreator!=null)
			{
				_noteCreator.ActiveContext = base.ActiveContext;
			}
			if(_userNotes!=null)
			{
				_userNotes.ActiveContext = base.ActiveContext;
			}
			if(_userRoles!=null)
			{
				_userRoles.ActiveContext = base.ActiveContext;
			}
			if(_userTravelFees!=null)
			{
				_userTravelFees.ActiveContext = base.ActiveContext;
			}
			if(_userUnavailabilities!=null)
			{
				_userUnavailabilities.ActiveContext = base.ActiveContext;
			}





















			if(_company!=null)
			{
				_company.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{





			_invoices = null;
			_noteUpdater = null;
			_noteCreator = null;
			_userNotes = null;
			_userRoles = null;
			_userTravelFees = null;
			_userUnavailabilities = null;





















			_company = null;

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

			_fieldsCustomProperties.Add("UserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CompanyId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _company</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCompany(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _company, new PropertyChangedEventHandler( OnCompanyPropertyChanged ), "Company", UserEntity.Relations.CompanyEntityUsingCompanyId, true, signalRelatedEntity, "Users", resetFKFields, new int[] { (int)UserFieldIndex.CompanyId } );		
			_company = null;
		}

		/// <summary> setups the sync logic for member _company</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCompany(IEntity2 relatedEntity)
		{
			if(_company!=relatedEntity)
			{
				DesetupSyncCompany(true, true);
				_company = (CompanyEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _company, new PropertyChangedEventHandler( OnCompanyPropertyChanged ), "Company", UserEntity.Relations.CompanyEntityUsingCompanyId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCompanyPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this UserEntity</param>
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
		public  static UserRelations Relations
		{
			get	{ return new UserRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Invoice' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInvoices
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<InvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceEntityFactory))),
					(IEntityRelation)GetRelationsForField("Invoices")[0], (int)PsychologicalServices.Data.EntityType.UserEntity, (int)PsychologicalServices.Data.EntityType.InvoiceEntity, 0, null, null, null, null, "Invoices", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Note' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNoteUpdater
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<NoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoteEntityFactory))),
					(IEntityRelation)GetRelationsForField("NoteUpdater")[0], (int)PsychologicalServices.Data.EntityType.UserEntity, (int)PsychologicalServices.Data.EntityType.NoteEntity, 0, null, null, null, null, "NoteUpdater", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Note' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNoteCreator
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<NoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoteEntityFactory))),
					(IEntityRelation)GetRelationsForField("NoteCreator")[0], (int)PsychologicalServices.Data.EntityType.UserEntity, (int)PsychologicalServices.Data.EntityType.NoteEntity, 0, null, null, null, null, "NoteCreator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'UserNote' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUserNotes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<UserNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserNoteEntityFactory))),
					(IEntityRelation)GetRelationsForField("UserNotes")[0], (int)PsychologicalServices.Data.EntityType.UserEntity, (int)PsychologicalServices.Data.EntityType.UserNoteEntity, 0, null, null, null, null, "UserNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'UserRole' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUserRoles
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<UserRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserRoleEntityFactory))),
					(IEntityRelation)GetRelationsForField("UserRoles")[0], (int)PsychologicalServices.Data.EntityType.UserEntity, (int)PsychologicalServices.Data.EntityType.UserRoleEntity, 0, null, null, null, null, "UserRoles", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'UserTravelFee' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUserTravelFees
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<UserTravelFeeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserTravelFeeEntityFactory))),
					(IEntityRelation)GetRelationsForField("UserTravelFees")[0], (int)PsychologicalServices.Data.EntityType.UserEntity, (int)PsychologicalServices.Data.EntityType.UserTravelFeeEntity, 0, null, null, null, null, "UserTravelFees", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'UserUnavailability' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUserUnavailabilities
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<UserUnavailabilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserUnavailabilityEntityFactory))),
					(IEntityRelation)GetRelationsForField("UserUnavailabilities")[0], (int)PsychologicalServices.Data.EntityType.UserEntity, (int)PsychologicalServices.Data.EntityType.UserUnavailabilityEntity, 0, null, null, null, null, "UserUnavailabilities", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}






















		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Company' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCompany
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory))),
					(IEntityRelation)GetRelationsForField("Company")[0], (int)PsychologicalServices.Data.EntityType.UserEntity, (int)PsychologicalServices.Data.EntityType.CompanyEntity, 0, null, null, null, null, "Company", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return UserEntity.CustomProperties;}
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
			get { return UserEntity.FieldsCustomProperties;}
		}

		/// <summary> The UserId property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Users"."UserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 UserId
		{
			get { return (System.Int32)GetValue((int)UserFieldIndex.UserId, true); }
			set	{ SetValue((int)UserFieldIndex.UserId, value); }
		}

		/// <summary> The FirstName property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Users"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)UserFieldIndex.FirstName, true); }
			set	{ SetValue((int)UserFieldIndex.FirstName, value); }
		}

		/// <summary> The LastName property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Users"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)UserFieldIndex.LastName, true); }
			set	{ SetValue((int)UserFieldIndex.LastName, value); }
		}

		/// <summary> The Email property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Users"."Email"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Email
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Email, true); }
			set	{ SetValue((int)UserFieldIndex.Email, value); }
		}

		/// <summary> The IsActive property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Users"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)UserFieldIndex.IsActive, true); }
			set	{ SetValue((int)UserFieldIndex.IsActive, value); }
		}

		/// <summary> The CompanyId property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Users"."CompanyId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CompanyId
		{
			get { return (System.Int32)GetValue((int)UserFieldIndex.CompanyId, true); }
			set	{ SetValue((int)UserFieldIndex.CompanyId, value); }
		}





		/// <summary> Gets the EntityCollection with the related entities of type 'InvoiceEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(InvoiceEntity))]
		public virtual EntityCollection<InvoiceEntity> Invoices
		{
			get
			{
				if(_invoices==null)
				{
					_invoices = new EntityCollection<InvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceEntityFactory)));
					_invoices.SetContainingEntityInfo(this, "PayableTo");
				}
				return _invoices;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NoteEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NoteEntity))]
		public virtual EntityCollection<NoteEntity> NoteUpdater
		{
			get
			{
				if(_noteUpdater==null)
				{
					_noteUpdater = new EntityCollection<NoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoteEntityFactory)));
					_noteUpdater.SetContainingEntityInfo(this, "UpdateUser");
				}
				return _noteUpdater;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NoteEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NoteEntity))]
		public virtual EntityCollection<NoteEntity> NoteCreator
		{
			get
			{
				if(_noteCreator==null)
				{
					_noteCreator = new EntityCollection<NoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoteEntityFactory)));
					_noteCreator.SetContainingEntityInfo(this, "CreateUser");
				}
				return _noteCreator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UserNoteEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(UserNoteEntity))]
		public virtual EntityCollection<UserNoteEntity> UserNotes
		{
			get
			{
				if(_userNotes==null)
				{
					_userNotes = new EntityCollection<UserNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserNoteEntityFactory)));
					_userNotes.SetContainingEntityInfo(this, "User");
				}
				return _userNotes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UserRoleEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(UserRoleEntity))]
		public virtual EntityCollection<UserRoleEntity> UserRoles
		{
			get
			{
				if(_userRoles==null)
				{
					_userRoles = new EntityCollection<UserRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserRoleEntityFactory)));
					_userRoles.SetContainingEntityInfo(this, "User");
				}
				return _userRoles;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UserTravelFeeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(UserTravelFeeEntity))]
		public virtual EntityCollection<UserTravelFeeEntity> UserTravelFees
		{
			get
			{
				if(_userTravelFees==null)
				{
					_userTravelFees = new EntityCollection<UserTravelFeeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserTravelFeeEntityFactory)));
					_userTravelFees.SetContainingEntityInfo(this, "User");
				}
				return _userTravelFees;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UserUnavailabilityEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(UserUnavailabilityEntity))]
		public virtual EntityCollection<UserUnavailabilityEntity> UserUnavailabilities
		{
			get
			{
				if(_userUnavailabilities==null)
				{
					_userUnavailabilities = new EntityCollection<UserUnavailabilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserUnavailabilityEntityFactory)));
					_userUnavailabilities.SetContainingEntityInfo(this, "User");
				}
				return _userUnavailabilities;
			}
		}






















		/// <summary> Gets / sets related entity of type 'CompanyEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CompanyEntity Company
		{
			get
			{
				return _company;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCompany(value);
				}
				else
				{
					if(value==null)
					{
						if(_company != null)
						{
							_company.UnsetRelatedEntity(this, "Users");
						}
					}
					else
					{
						if(_company!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Users");
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
			get { return (int)PsychologicalServices.Data.EntityType.UserEntity; }
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
