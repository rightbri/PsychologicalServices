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
	/// Entity class which represents the entity 'Note'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class NoteEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AssessmentEntity> _summaryAssessment;
		private EntityCollection<AssessmentNoteEntity> _assessmentNotes;
		private EntityCollection<CalendarNoteEntity> _calendarNote;
		private EntityCollection<UserNoteEntity> _userNotes;











		private UserEntity _updateUser;
		private UserEntity _createUser;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name UpdateUser</summary>
			public static readonly string UpdateUser = "UpdateUser";
			/// <summary>Member name CreateUser</summary>
			public static readonly string CreateUser = "CreateUser";
			/// <summary>Member name SummaryAssessment</summary>
			public static readonly string SummaryAssessment = "SummaryAssessment";
			/// <summary>Member name AssessmentNotes</summary>
			public static readonly string AssessmentNotes = "AssessmentNotes";
			/// <summary>Member name CalendarNote</summary>
			public static readonly string CalendarNote = "CalendarNote";
			/// <summary>Member name UserNotes</summary>
			public static readonly string UserNotes = "UserNotes";












		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static NoteEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public NoteEntity():base("NoteEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public NoteEntity(IEntityFields2 fields):base("NoteEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this NoteEntity</param>
		public NoteEntity(IValidator validator):base("NoteEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="noteId">PK value for Note which data should be fetched into this Note object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public NoteEntity(System.Int32 noteId):base("NoteEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.NoteId = noteId;
		}

		/// <summary> CTor</summary>
		/// <param name="noteId">PK value for Note which data should be fetched into this Note object</param>
		/// <param name="validator">The custom validator object for this NoteEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public NoteEntity(System.Int32 noteId, IValidator validator):base("NoteEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.NoteId = noteId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected NoteEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_summaryAssessment = (EntityCollection<AssessmentEntity>)info.GetValue("_summaryAssessment", typeof(EntityCollection<AssessmentEntity>));
				_assessmentNotes = (EntityCollection<AssessmentNoteEntity>)info.GetValue("_assessmentNotes", typeof(EntityCollection<AssessmentNoteEntity>));
				_calendarNote = (EntityCollection<CalendarNoteEntity>)info.GetValue("_calendarNote", typeof(EntityCollection<CalendarNoteEntity>));
				_userNotes = (EntityCollection<UserNoteEntity>)info.GetValue("_userNotes", typeof(EntityCollection<UserNoteEntity>));











				_updateUser = (UserEntity)info.GetValue("_updateUser", typeof(UserEntity));
				if(_updateUser!=null)
				{
					_updateUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_createUser = (UserEntity)info.GetValue("_createUser", typeof(UserEntity));
				if(_createUser!=null)
				{
					_createUser.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((NoteFieldIndex)fieldIndex)
			{
				case NoteFieldIndex.UpdateUserId:
					DesetupSyncUpdateUser(true, false);
					break;
				case NoteFieldIndex.CreateUserId:
					DesetupSyncCreateUser(true, false);
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
				case "UpdateUser":
					this.UpdateUser = (UserEntity)entity;
					break;
				case "CreateUser":
					this.CreateUser = (UserEntity)entity;
					break;
				case "SummaryAssessment":
					this.SummaryAssessment.Add((AssessmentEntity)entity);
					break;
				case "AssessmentNotes":
					this.AssessmentNotes.Add((AssessmentNoteEntity)entity);
					break;
				case "CalendarNote":
					this.CalendarNote.Add((CalendarNoteEntity)entity);
					break;
				case "UserNotes":
					this.UserNotes.Add((UserNoteEntity)entity);
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
			return NoteEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "UpdateUser":
					toReturn.Add(NoteEntity.Relations.UserEntityUsingUpdateUserId);
					break;
				case "CreateUser":
					toReturn.Add(NoteEntity.Relations.UserEntityUsingCreateUserId);
					break;
				case "SummaryAssessment":
					toReturn.Add(NoteEntity.Relations.AssessmentEntityUsingSummaryNoteId);
					break;
				case "AssessmentNotes":
					toReturn.Add(NoteEntity.Relations.AssessmentNoteEntityUsingNoteId);
					break;
				case "CalendarNote":
					toReturn.Add(NoteEntity.Relations.CalendarNoteEntityUsingNoteId);
					break;
				case "UserNotes":
					toReturn.Add(NoteEntity.Relations.UserNoteEntityUsingNoteId);
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
				case "UpdateUser":
					SetupSyncUpdateUser(relatedEntity);
					break;
				case "CreateUser":
					SetupSyncCreateUser(relatedEntity);
					break;
				case "SummaryAssessment":
					this.SummaryAssessment.Add((AssessmentEntity)relatedEntity);
					break;
				case "AssessmentNotes":
					this.AssessmentNotes.Add((AssessmentNoteEntity)relatedEntity);
					break;
				case "CalendarNote":
					this.CalendarNote.Add((CalendarNoteEntity)relatedEntity);
					break;
				case "UserNotes":
					this.UserNotes.Add((UserNoteEntity)relatedEntity);
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
				case "UpdateUser":
					DesetupSyncUpdateUser(false, true);
					break;
				case "CreateUser":
					DesetupSyncCreateUser(false, true);
					break;
				case "SummaryAssessment":
					base.PerformRelatedEntityRemoval(this.SummaryAssessment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AssessmentNotes":
					base.PerformRelatedEntityRemoval(this.AssessmentNotes, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CalendarNote":
					base.PerformRelatedEntityRemoval(this.CalendarNote, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "UserNotes":
					base.PerformRelatedEntityRemoval(this.UserNotes, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_updateUser!=null)
			{
				toReturn.Add(_updateUser);
			}
			if(_createUser!=null)
			{
				toReturn.Add(_createUser);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.SummaryAssessment);
			toReturn.Add(this.AssessmentNotes);
			toReturn.Add(this.CalendarNote);
			toReturn.Add(this.UserNotes);

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
				info.AddValue("_summaryAssessment", ((_summaryAssessment!=null) && (_summaryAssessment.Count>0) && !this.MarkedForDeletion)?_summaryAssessment:null);
				info.AddValue("_assessmentNotes", ((_assessmentNotes!=null) && (_assessmentNotes.Count>0) && !this.MarkedForDeletion)?_assessmentNotes:null);
				info.AddValue("_calendarNote", ((_calendarNote!=null) && (_calendarNote.Count>0) && !this.MarkedForDeletion)?_calendarNote:null);
				info.AddValue("_userNotes", ((_userNotes!=null) && (_userNotes.Count>0) && !this.MarkedForDeletion)?_userNotes:null);











				info.AddValue("_updateUser", (!this.MarkedForDeletion?_updateUser:null));
				info.AddValue("_createUser", (!this.MarkedForDeletion?_createUser:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(NoteFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(NoteFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new NoteRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Assessment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSummaryAssessment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentFields.SummaryNoteId, null, ComparisonOperator.Equal, this.NoteId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AssessmentNote' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessmentNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentNoteFields.NoteId, null, ComparisonOperator.Equal, this.NoteId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CalendarNote' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCalendarNote()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CalendarNoteFields.NoteId, null, ComparisonOperator.Equal, this.NoteId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'UserNote' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUserNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserNoteFields.NoteId, null, ComparisonOperator.Equal, this.NoteId));
			return bucket;
		}












		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'User' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUpdateUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.UpdateUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'User' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCreateUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.CreateUserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(PsychologicalServices.Data.EntityType.NoteEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(NoteEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._summaryAssessment);
			collectionsQueue.Enqueue(this._assessmentNotes);
			collectionsQueue.Enqueue(this._calendarNote);
			collectionsQueue.Enqueue(this._userNotes);











		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._summaryAssessment = (EntityCollection<AssessmentEntity>) collectionsQueue.Dequeue();
			this._assessmentNotes = (EntityCollection<AssessmentNoteEntity>) collectionsQueue.Dequeue();
			this._calendarNote = (EntityCollection<CalendarNoteEntity>) collectionsQueue.Dequeue();
			this._userNotes = (EntityCollection<UserNoteEntity>) collectionsQueue.Dequeue();











		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._summaryAssessment != null)
			{
				return true;
			}
			if (this._assessmentNotes != null)
			{
				return true;
			}
			if (this._calendarNote != null)
			{
				return true;
			}
			if (this._userNotes != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AssessmentNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentNoteEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CalendarNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CalendarNoteEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserNoteEntityFactory))) : null);











		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("UpdateUser", _updateUser);
			toReturn.Add("CreateUser", _createUser);
			toReturn.Add("SummaryAssessment", _summaryAssessment);
			toReturn.Add("AssessmentNotes", _assessmentNotes);
			toReturn.Add("CalendarNote", _calendarNote);
			toReturn.Add("UserNotes", _userNotes);












			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_summaryAssessment!=null)
			{
				_summaryAssessment.ActiveContext = base.ActiveContext;
			}
			if(_assessmentNotes!=null)
			{
				_assessmentNotes.ActiveContext = base.ActiveContext;
			}
			if(_calendarNote!=null)
			{
				_calendarNote.ActiveContext = base.ActiveContext;
			}
			if(_userNotes!=null)
			{
				_userNotes.ActiveContext = base.ActiveContext;
			}











			if(_updateUser!=null)
			{
				_updateUser.ActiveContext = base.ActiveContext;
			}
			if(_createUser!=null)
			{
				_createUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_summaryAssessment = null;
			_assessmentNotes = null;
			_calendarNote = null;
			_userNotes = null;











			_updateUser = null;
			_createUser = null;

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

			_fieldsCustomProperties.Add("NoteId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Note", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdateUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdateDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreateUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreateDate", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _updateUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncUpdateUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _updateUser, new PropertyChangedEventHandler( OnUpdateUserPropertyChanged ), "UpdateUser", NoteEntity.Relations.UserEntityUsingUpdateUserId, true, signalRelatedEntity, "NoteUpdater", resetFKFields, new int[] { (int)NoteFieldIndex.UpdateUserId } );		
			_updateUser = null;
		}

		/// <summary> setups the sync logic for member _updateUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncUpdateUser(IEntity2 relatedEntity)
		{
			if(_updateUser!=relatedEntity)
			{
				DesetupSyncUpdateUser(true, true);
				_updateUser = (UserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _updateUser, new PropertyChangedEventHandler( OnUpdateUserPropertyChanged ), "UpdateUser", NoteEntity.Relations.UserEntityUsingUpdateUserId, true, new string[] {  } );
			}
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

		/// <summary> Removes the sync logic for member _createUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCreateUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _createUser, new PropertyChangedEventHandler( OnCreateUserPropertyChanged ), "CreateUser", NoteEntity.Relations.UserEntityUsingCreateUserId, true, signalRelatedEntity, "NoteCreator", resetFKFields, new int[] { (int)NoteFieldIndex.CreateUserId } );		
			_createUser = null;
		}

		/// <summary> setups the sync logic for member _createUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCreateUser(IEntity2 relatedEntity)
		{
			if(_createUser!=relatedEntity)
			{
				DesetupSyncCreateUser(true, true);
				_createUser = (UserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _createUser, new PropertyChangedEventHandler( OnCreateUserPropertyChanged ), "CreateUser", NoteEntity.Relations.UserEntityUsingCreateUserId, true, new string[] {  } );
			}
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


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this NoteEntity</param>
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
		public  static NoteRelations Relations
		{
			get	{ return new NoteRelations(); }
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
		public static IPrefetchPathElement2 PrefetchPathSummaryAssessment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AssessmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("SummaryAssessment")[0], (int)PsychologicalServices.Data.EntityType.NoteEntity, (int)PsychologicalServices.Data.EntityType.AssessmentEntity, 0, null, null, null, null, "SummaryAssessment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AssessmentNote' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssessmentNotes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AssessmentNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentNoteEntityFactory))),
					(IEntityRelation)GetRelationsForField("AssessmentNotes")[0], (int)PsychologicalServices.Data.EntityType.NoteEntity, (int)PsychologicalServices.Data.EntityType.AssessmentNoteEntity, 0, null, null, null, null, "AssessmentNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CalendarNote' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCalendarNote
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CalendarNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CalendarNoteEntityFactory))),
					(IEntityRelation)GetRelationsForField("CalendarNote")[0], (int)PsychologicalServices.Data.EntityType.NoteEntity, (int)PsychologicalServices.Data.EntityType.CalendarNoteEntity, 0, null, null, null, null, "CalendarNote", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("UserNotes")[0], (int)PsychologicalServices.Data.EntityType.NoteEntity, (int)PsychologicalServices.Data.EntityType.UserNoteEntity, 0, null, null, null, null, "UserNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}












		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUpdateUser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),
					(IEntityRelation)GetRelationsForField("UpdateUser")[0], (int)PsychologicalServices.Data.EntityType.NoteEntity, (int)PsychologicalServices.Data.EntityType.UserEntity, 0, null, null, null, null, "UpdateUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCreateUser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),
					(IEntityRelation)GetRelationsForField("CreateUser")[0], (int)PsychologicalServices.Data.EntityType.NoteEntity, (int)PsychologicalServices.Data.EntityType.UserEntity, 0, null, null, null, null, "CreateUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return NoteEntity.CustomProperties;}
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
			get { return NoteEntity.FieldsCustomProperties;}
		}

		/// <summary> The NoteId property of the Entity Note<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Notes"."NoteId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 NoteId
		{
			get { return (System.Int32)GetValue((int)NoteFieldIndex.NoteId, true); }
			set	{ SetValue((int)NoteFieldIndex.NoteId, value); }
		}

		/// <summary> The Note property of the Entity Note<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Notes"."Note"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Note
		{
			get { return (System.String)GetValue((int)NoteFieldIndex.Note, true); }
			set	{ SetValue((int)NoteFieldIndex.Note, value); }
		}

		/// <summary> The UpdateUserId property of the Entity Note<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Notes"."UpdateUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 UpdateUserId
		{
			get { return (System.Int32)GetValue((int)NoteFieldIndex.UpdateUserId, true); }
			set	{ SetValue((int)NoteFieldIndex.UpdateUserId, value); }
		}

		/// <summary> The UpdateDate property of the Entity Note<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Notes"."UpdateDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime UpdateDate
		{
			get { return (System.DateTime)GetValue((int)NoteFieldIndex.UpdateDate, true); }
			set	{ SetValue((int)NoteFieldIndex.UpdateDate, value); }
		}

		/// <summary> The CreateUserId property of the Entity Note<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Notes"."CreateUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CreateUserId
		{
			get { return (System.Int32)GetValue((int)NoteFieldIndex.CreateUserId, true); }
			set	{ SetValue((int)NoteFieldIndex.CreateUserId, value); }
		}

		/// <summary> The CreateDate property of the Entity Note<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Notes"."CreateDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreateDate
		{
			get { return (System.DateTime)GetValue((int)NoteFieldIndex.CreateDate, true); }
			set	{ SetValue((int)NoteFieldIndex.CreateDate, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AssessmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AssessmentEntity))]
		public virtual EntityCollection<AssessmentEntity> SummaryAssessment
		{
			get
			{
				if(_summaryAssessment==null)
				{
					_summaryAssessment = new EntityCollection<AssessmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentEntityFactory)));
					_summaryAssessment.SetContainingEntityInfo(this, "Summary");
				}
				return _summaryAssessment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AssessmentNoteEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AssessmentNoteEntity))]
		public virtual EntityCollection<AssessmentNoteEntity> AssessmentNotes
		{
			get
			{
				if(_assessmentNotes==null)
				{
					_assessmentNotes = new EntityCollection<AssessmentNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentNoteEntityFactory)));
					_assessmentNotes.SetContainingEntityInfo(this, "Note");
				}
				return _assessmentNotes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CalendarNoteEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CalendarNoteEntity))]
		public virtual EntityCollection<CalendarNoteEntity> CalendarNote
		{
			get
			{
				if(_calendarNote==null)
				{
					_calendarNote = new EntityCollection<CalendarNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CalendarNoteEntityFactory)));
					_calendarNote.SetContainingEntityInfo(this, "Note");
				}
				return _calendarNote;
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
					_userNotes.SetContainingEntityInfo(this, "Note");
				}
				return _userNotes;
			}
		}












		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual UserEntity UpdateUser
		{
			get
			{
				return _updateUser;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncUpdateUser(value);
				}
				else
				{
					if(value==null)
					{
						if(_updateUser != null)
						{
							_updateUser.UnsetRelatedEntity(this, "NoteUpdater");
						}
					}
					else
					{
						if(_updateUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "NoteUpdater");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual UserEntity CreateUser
		{
			get
			{
				return _createUser;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCreateUser(value);
				}
				else
				{
					if(value==null)
					{
						if(_createUser != null)
						{
							_createUser.UnsetRelatedEntity(this, "NoteCreator");
						}
					}
					else
					{
						if(_createUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "NoteCreator");
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
			get { return (int)PsychologicalServices.Data.EntityType.NoteEntity; }
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
