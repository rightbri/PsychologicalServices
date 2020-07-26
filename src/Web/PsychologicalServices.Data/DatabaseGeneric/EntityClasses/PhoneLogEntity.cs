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
	/// <summary>Entity class which represents the entity 'PhoneLog'.<br/><br/></summary>
	[Serializable]
	public partial class PhoneLogEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private NoteEntity _note;
		private UserEntity _createUser;
		private UserEntity _updateUser;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Note</summary>
			public static readonly string Note = "Note";
			/// <summary>Member name CreateUser</summary>
			public static readonly string CreateUser = "CreateUser";
			/// <summary>Member name UpdateUser</summary>
			public static readonly string UpdateUser = "UpdateUser";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PhoneLogEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public PhoneLogEntity():base("PhoneLogEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PhoneLogEntity(IEntityFields2 fields):base("PhoneLogEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PhoneLogEntity</param>
		public PhoneLogEntity(IValidator validator):base("PhoneLogEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="phoneLogId">PK value for PhoneLog which data should be fetched into this PhoneLog object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PhoneLogEntity(System.Int32 phoneLogId):base("PhoneLogEntity")
		{
			InitClassEmpty(null, null);
			this.PhoneLogId = phoneLogId;
		}

		/// <summary> CTor</summary>
		/// <param name="phoneLogId">PK value for PhoneLog which data should be fetched into this PhoneLog object</param>
		/// <param name="validator">The custom validator object for this PhoneLogEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PhoneLogEntity(System.Int32 phoneLogId, IValidator validator):base("PhoneLogEntity")
		{
			InitClassEmpty(validator, null);
			this.PhoneLogId = phoneLogId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PhoneLogEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_note = (NoteEntity)info.GetValue("_note", typeof(NoteEntity));
				if(_note!=null)
				{
					_note.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_createUser = (UserEntity)info.GetValue("_createUser", typeof(UserEntity));
				if(_createUser!=null)
				{
					_createUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_updateUser = (UserEntity)info.GetValue("_updateUser", typeof(UserEntity));
				if(_updateUser!=null)
				{
					_updateUser.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((PhoneLogFieldIndex)fieldIndex)
			{
				case PhoneLogFieldIndex.NoteId:
					DesetupSyncNote(true, false);
					break;
				case PhoneLogFieldIndex.CreateUserId:
					DesetupSyncCreateUser(true, false);
					break;
				case PhoneLogFieldIndex.UpdateUserId:
					DesetupSyncUpdateUser(true, false);
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
				case "Note":
					this.Note = (NoteEntity)entity;
					break;
				case "CreateUser":
					this.CreateUser = (UserEntity)entity;
					break;
				case "UpdateUser":
					this.UpdateUser = (UserEntity)entity;
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
				case "Note":
					toReturn.Add(Relations.NoteEntityUsingNoteId);
					break;
				case "CreateUser":
					toReturn.Add(Relations.UserEntityUsingCreateUserId);
					break;
				case "UpdateUser":
					toReturn.Add(Relations.UserEntityUsingUpdateUserId);
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
				case "Note":
					SetupSyncNote(relatedEntity);
					break;
				case "CreateUser":
					SetupSyncCreateUser(relatedEntity);
					break;
				case "UpdateUser":
					SetupSyncUpdateUser(relatedEntity);
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
				case "Note":
					DesetupSyncNote(false, true);
					break;
				case "CreateUser":
					DesetupSyncCreateUser(false, true);
					break;
				case "UpdateUser":
					DesetupSyncUpdateUser(false, true);
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
			if(_note!=null)
			{
				toReturn.Add(_note);
			}
			if(_createUser!=null)
			{
				toReturn.Add(_createUser);
			}
			if(_updateUser!=null)
			{
				toReturn.Add(_updateUser);
			}
			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		protected override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
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
				info.AddValue("_note", (!this.MarkedForDeletion?_note:null));
				info.AddValue("_createUser", (!this.MarkedForDeletion?_createUser:null));
				info.AddValue("_updateUser", (!this.MarkedForDeletion?_updateUser:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new PhoneLogRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Note' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNote()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoteFields.NoteId, null, ComparisonOperator.Equal, this.NoteId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCreateUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.CreateUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUpdateUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.UpdateUserId));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(PhoneLogEntityFactory));
		}

		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			bool toReturn = false;
			return toReturn ? true : base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
		}

		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Note", _note);
			toReturn.Add("CreateUser", _createUser);
			toReturn.Add("UpdateUser", _updateUser);
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
			_fieldsCustomProperties.Add("PhoneLogId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CallTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CompanyName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CallerName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ClaimantFirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ClaimantLastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("NoteId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CreateDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CreateUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("UpdateDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("UpdateUserId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _note</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNote(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _note, new PropertyChangedEventHandler(OnNotePropertyChanged), "Note", "PhoneLogs", PsychologicalServices.Data.RelationClasses.StaticPhoneLogRelations.NoteEntityUsingNoteIdStatic, true, new int[] { (int)PhoneLogFieldIndex.NoteId });
		}

		/// <summary> setups the sync logic for member _note</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNote(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _note, new PropertyChangedEventHandler( OnNotePropertyChanged ), "Note", "PhoneLogs", PsychologicalServices.Data.RelationClasses.StaticPhoneLogRelations.NoteEntityUsingNoteIdStatic, true, new string[] {  }, new int[] { (int)PhoneLogFieldIndex.NoteId }); 
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNotePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _createUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCreateUser(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _createUser, new PropertyChangedEventHandler(OnCreateUserPropertyChanged), "CreateUser", "PhoneLogs", PsychologicalServices.Data.RelationClasses.StaticPhoneLogRelations.UserEntityUsingCreateUserIdStatic, true, new int[] { (int)PhoneLogFieldIndex.CreateUserId });
		}

		/// <summary> setups the sync logic for member _createUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCreateUser(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _createUser, new PropertyChangedEventHandler( OnCreateUserPropertyChanged ), "CreateUser", "PhoneLogs", PsychologicalServices.Data.RelationClasses.StaticPhoneLogRelations.UserEntityUsingCreateUserIdStatic, true, new string[] {  }, new int[] { (int)PhoneLogFieldIndex.CreateUserId }); 
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCreateUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _updateUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncUpdateUser(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _updateUser, new PropertyChangedEventHandler(OnUpdateUserPropertyChanged), "UpdateUser", "PhoneLogs1", PsychologicalServices.Data.RelationClasses.StaticPhoneLogRelations.UserEntityUsingUpdateUserIdStatic, true, new int[] { (int)PhoneLogFieldIndex.UpdateUserId });
		}

		/// <summary> setups the sync logic for member _updateUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncUpdateUser(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _updateUser, new PropertyChangedEventHandler( OnUpdateUserPropertyChanged ), "UpdateUser", "PhoneLogs1", PsychologicalServices.Data.RelationClasses.StaticPhoneLogRelations.UserEntityUsingUpdateUserIdStatic, true, new string[] {  }, new int[] { (int)PhoneLogFieldIndex.UpdateUserId }); 
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUpdateUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PhoneLogEntity</param>
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
		public  static PhoneLogRelations Relations
		{
			get	{ return new PhoneLogRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Note' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNote
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(NoteEntityFactory))),	(IEntityRelation)GetRelationsForField("Note")[0], (int)PsychologicalServices.Data.EntityType.PhoneLogEntity, (int)PsychologicalServices.Data.EntityType.NoteEntity, 0, null, null, null, null, "Note", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCreateUser
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),	(IEntityRelation)GetRelationsForField("CreateUser")[0], (int)PsychologicalServices.Data.EntityType.PhoneLogEntity, (int)PsychologicalServices.Data.EntityType.UserEntity, 0, null, null, null, null, "CreateUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUpdateUser
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),	(IEntityRelation)GetRelationsForField("UpdateUser")[0], (int)PsychologicalServices.Data.EntityType.PhoneLogEntity, (int)PsychologicalServices.Data.EntityType.UserEntity, 0, null, null, null, null, "UpdateUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The PhoneLogId property of the Entity PhoneLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "PhoneLogs"."PhoneLogId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 PhoneLogId
		{
			get { return (System.Int32)GetValue((int)PhoneLogFieldIndex.PhoneLogId, true); }
			set	{ SetValue((int)PhoneLogFieldIndex.PhoneLogId, value); }
		}

		/// <summary> The CallTime property of the Entity PhoneLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "PhoneLogs"."CallTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTimeOffset, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTimeOffset CallTime
		{
			get { return (System.DateTimeOffset)GetValue((int)PhoneLogFieldIndex.CallTime, true); }
			set	{ SetValue((int)PhoneLogFieldIndex.CallTime, value); }
		}

		/// <summary> The CompanyName property of the Entity PhoneLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "PhoneLogs"."CompanyName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CompanyName
		{
			get { return (System.String)GetValue((int)PhoneLogFieldIndex.CompanyName, true); }
			set	{ SetValue((int)PhoneLogFieldIndex.CompanyName, value); }
		}

		/// <summary> The CallerName property of the Entity PhoneLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "PhoneLogs"."CallerName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CallerName
		{
			get { return (System.String)GetValue((int)PhoneLogFieldIndex.CallerName, true); }
			set	{ SetValue((int)PhoneLogFieldIndex.CallerName, value); }
		}

		/// <summary> The ClaimantFirstName property of the Entity PhoneLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "PhoneLogs"."ClaimantFirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ClaimantFirstName
		{
			get { return (System.String)GetValue((int)PhoneLogFieldIndex.ClaimantFirstName, true); }
			set	{ SetValue((int)PhoneLogFieldIndex.ClaimantFirstName, value); }
		}

		/// <summary> The ClaimantLastName property of the Entity PhoneLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "PhoneLogs"."ClaimantLastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ClaimantLastName
		{
			get { return (System.String)GetValue((int)PhoneLogFieldIndex.ClaimantLastName, true); }
			set	{ SetValue((int)PhoneLogFieldIndex.ClaimantLastName, value); }
		}

		/// <summary> The NoteId property of the Entity PhoneLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "PhoneLogs"."NoteId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 NoteId
		{
			get { return (System.Int32)GetValue((int)PhoneLogFieldIndex.NoteId, true); }
			set	{ SetValue((int)PhoneLogFieldIndex.NoteId, value); }
		}

		/// <summary> The CreateDate property of the Entity PhoneLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "PhoneLogs"."CreateDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTimeOffset, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTimeOffset CreateDate
		{
			get { return (System.DateTimeOffset)GetValue((int)PhoneLogFieldIndex.CreateDate, true); }
			set	{ SetValue((int)PhoneLogFieldIndex.CreateDate, value); }
		}

		/// <summary> The CreateUserId property of the Entity PhoneLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "PhoneLogs"."CreateUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CreateUserId
		{
			get { return (System.Int32)GetValue((int)PhoneLogFieldIndex.CreateUserId, true); }
			set	{ SetValue((int)PhoneLogFieldIndex.CreateUserId, value); }
		}

		/// <summary> The UpdateDate property of the Entity PhoneLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "PhoneLogs"."UpdateDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTimeOffset, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTimeOffset UpdateDate
		{
			get { return (System.DateTimeOffset)GetValue((int)PhoneLogFieldIndex.UpdateDate, true); }
			set	{ SetValue((int)PhoneLogFieldIndex.UpdateDate, value); }
		}

		/// <summary> The UpdateUserId property of the Entity PhoneLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "PhoneLogs"."UpdateUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 UpdateUserId
		{
			get { return (System.Int32)GetValue((int)PhoneLogFieldIndex.UpdateUserId, true); }
			set	{ SetValue((int)PhoneLogFieldIndex.UpdateUserId, value); }
		}

		/// <summary> Gets / sets related entity of type 'NoteEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual NoteEntity Note
		{
			get	{ return _note; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncNote(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "PhoneLogs", "Note", _note, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual UserEntity CreateUser
		{
			get	{ return _createUser; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncCreateUser(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "PhoneLogs", "CreateUser", _createUser, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual UserEntity UpdateUser
		{
			get	{ return _updateUser; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncUpdateUser(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "PhoneLogs1", "UpdateUser", _updateUser, true); 
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
			get { return (int)PsychologicalServices.Data.EntityType.PhoneLogEntity; }
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
