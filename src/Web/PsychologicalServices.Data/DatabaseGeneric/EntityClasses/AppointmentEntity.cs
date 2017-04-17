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
	/// Entity class which represents the entity 'Appointment'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AppointmentEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AppointmentAttributeEntity> _appointmentAttributes;
		private EntityCollection<InvoiceEntity> _invoices;


		private AddressEntity _location;
		private AppointmentStatusEntity _appointmentStatus;
		private AssessmentEntity _assessment;
		private UserEntity _psychometrist;
		private UserEntity _psychologist;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Location</summary>
			public static readonly string Location = "Location";
			/// <summary>Member name AppointmentStatus</summary>
			public static readonly string AppointmentStatus = "AppointmentStatus";
			/// <summary>Member name Assessment</summary>
			public static readonly string Assessment = "Assessment";
			/// <summary>Member name Psychometrist</summary>
			public static readonly string Psychometrist = "Psychometrist";
			/// <summary>Member name Psychologist</summary>
			public static readonly string Psychologist = "Psychologist";
			/// <summary>Member name AppointmentAttributes</summary>
			public static readonly string AppointmentAttributes = "AppointmentAttributes";
			/// <summary>Member name Invoices</summary>
			public static readonly string Invoices = "Invoices";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AppointmentEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AppointmentEntity():base("AppointmentEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AppointmentEntity(IEntityFields2 fields):base("AppointmentEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AppointmentEntity</param>
		public AppointmentEntity(IValidator validator):base("AppointmentEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="appointmentId">PK value for Appointment which data should be fetched into this Appointment object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AppointmentEntity(System.Int32 appointmentId):base("AppointmentEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.AppointmentId = appointmentId;
		}

		/// <summary> CTor</summary>
		/// <param name="appointmentId">PK value for Appointment which data should be fetched into this Appointment object</param>
		/// <param name="validator">The custom validator object for this AppointmentEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AppointmentEntity(System.Int32 appointmentId, IValidator validator):base("AppointmentEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.AppointmentId = appointmentId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AppointmentEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_appointmentAttributes = (EntityCollection<AppointmentAttributeEntity>)info.GetValue("_appointmentAttributes", typeof(EntityCollection<AppointmentAttributeEntity>));
				_invoices = (EntityCollection<InvoiceEntity>)info.GetValue("_invoices", typeof(EntityCollection<InvoiceEntity>));


				_location = (AddressEntity)info.GetValue("_location", typeof(AddressEntity));
				if(_location!=null)
				{
					_location.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_appointmentStatus = (AppointmentStatusEntity)info.GetValue("_appointmentStatus", typeof(AppointmentStatusEntity));
				if(_appointmentStatus!=null)
				{
					_appointmentStatus.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_assessment = (AssessmentEntity)info.GetValue("_assessment", typeof(AssessmentEntity));
				if(_assessment!=null)
				{
					_assessment.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_psychometrist = (UserEntity)info.GetValue("_psychometrist", typeof(UserEntity));
				if(_psychometrist!=null)
				{
					_psychometrist.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_psychologist = (UserEntity)info.GetValue("_psychologist", typeof(UserEntity));
				if(_psychologist!=null)
				{
					_psychologist.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AppointmentFieldIndex)fieldIndex)
			{
				case AppointmentFieldIndex.LocationId:
					DesetupSyncLocation(true, false);
					break;
				case AppointmentFieldIndex.PsychometristId:
					DesetupSyncPsychometrist(true, false);
					break;
				case AppointmentFieldIndex.PsychologistId:
					DesetupSyncPsychologist(true, false);
					break;
				case AppointmentFieldIndex.AppointmentStatusId:
					DesetupSyncAppointmentStatus(true, false);
					break;
				case AppointmentFieldIndex.AssessmentId:
					DesetupSyncAssessment(true, false);
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
				case "Location":
					this.Location = (AddressEntity)entity;
					break;
				case "AppointmentStatus":
					this.AppointmentStatus = (AppointmentStatusEntity)entity;
					break;
				case "Assessment":
					this.Assessment = (AssessmentEntity)entity;
					break;
				case "Psychometrist":
					this.Psychometrist = (UserEntity)entity;
					break;
				case "Psychologist":
					this.Psychologist = (UserEntity)entity;
					break;
				case "AppointmentAttributes":
					this.AppointmentAttributes.Add((AppointmentAttributeEntity)entity);
					break;
				case "Invoices":
					this.Invoices.Add((InvoiceEntity)entity);
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
			return AppointmentEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Location":
					toReturn.Add(AppointmentEntity.Relations.AddressEntityUsingLocationId);
					break;
				case "AppointmentStatus":
					toReturn.Add(AppointmentEntity.Relations.AppointmentStatusEntityUsingAppointmentStatusId);
					break;
				case "Assessment":
					toReturn.Add(AppointmentEntity.Relations.AssessmentEntityUsingAssessmentId);
					break;
				case "Psychometrist":
					toReturn.Add(AppointmentEntity.Relations.UserEntityUsingPsychometristId);
					break;
				case "Psychologist":
					toReturn.Add(AppointmentEntity.Relations.UserEntityUsingPsychologistId);
					break;
				case "AppointmentAttributes":
					toReturn.Add(AppointmentEntity.Relations.AppointmentAttributeEntityUsingAppointmentId);
					break;
				case "Invoices":
					toReturn.Add(AppointmentEntity.Relations.InvoiceEntityUsingAppointmentId);
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
			int numberOfOneWayRelations = 0+1+1;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));



				case "Psychometrist":
					return true;
				case "Psychologist":
					return true;

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
				case "Location":
					SetupSyncLocation(relatedEntity);
					break;
				case "AppointmentStatus":
					SetupSyncAppointmentStatus(relatedEntity);
					break;
				case "Assessment":
					SetupSyncAssessment(relatedEntity);
					break;
				case "Psychometrist":
					SetupSyncPsychometrist(relatedEntity);
					break;
				case "Psychologist":
					SetupSyncPsychologist(relatedEntity);
					break;
				case "AppointmentAttributes":
					this.AppointmentAttributes.Add((AppointmentAttributeEntity)relatedEntity);
					break;
				case "Invoices":
					this.Invoices.Add((InvoiceEntity)relatedEntity);
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
				case "Location":
					DesetupSyncLocation(false, true);
					break;
				case "AppointmentStatus":
					DesetupSyncAppointmentStatus(false, true);
					break;
				case "Assessment":
					DesetupSyncAssessment(false, true);
					break;
				case "Psychometrist":
					DesetupSyncPsychometrist(false, true);
					break;
				case "Psychologist":
					DesetupSyncPsychologist(false, true);
					break;
				case "AppointmentAttributes":
					base.PerformRelatedEntityRemoval(this.AppointmentAttributes, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Invoices":
					base.PerformRelatedEntityRemoval(this.Invoices, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_location!=null)
			{
				toReturn.Add(_location);
			}
			if(_appointmentStatus!=null)
			{
				toReturn.Add(_appointmentStatus);
			}
			if(_assessment!=null)
			{
				toReturn.Add(_assessment);
			}
			if(_psychometrist!=null)
			{
				toReturn.Add(_psychometrist);
			}
			if(_psychologist!=null)
			{
				toReturn.Add(_psychologist);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AppointmentAttributes);
			toReturn.Add(this.Invoices);

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
				info.AddValue("_invoices", ((_invoices!=null) && (_invoices.Count>0) && !this.MarkedForDeletion)?_invoices:null);


				info.AddValue("_location", (!this.MarkedForDeletion?_location:null));
				info.AddValue("_appointmentStatus", (!this.MarkedForDeletion?_appointmentStatus:null));
				info.AddValue("_assessment", (!this.MarkedForDeletion?_assessment:null));
				info.AddValue("_psychometrist", (!this.MarkedForDeletion?_psychometrist:null));
				info.AddValue("_psychologist", (!this.MarkedForDeletion?_psychologist:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AppointmentFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AppointmentFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AppointmentRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AppointmentAttribute' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAppointmentAttributes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AppointmentAttributeFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Invoice' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInvoices()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InvoiceFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId));
			return bucket;
		}



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Address' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLocation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.LocationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AppointmentStatus' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAppointmentStatus()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AppointmentStatusFields.AppointmentStatusId, null, ComparisonOperator.Equal, this.AppointmentStatusId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Assessment' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentFields.AssessmentId, null, ComparisonOperator.Equal, this.AssessmentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'User' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPsychometrist()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.PsychometristId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'User' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPsychologist()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.PsychologistId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(PsychologicalServices.Data.EntityType.AppointmentEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AppointmentEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._appointmentAttributes);
			collectionsQueue.Enqueue(this._invoices);


		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._appointmentAttributes = (EntityCollection<AppointmentAttributeEntity>) collectionsQueue.Dequeue();
			this._invoices = (EntityCollection<InvoiceEntity>) collectionsQueue.Dequeue();


		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._appointmentAttributes != null)
			{
				return true;
			}
			if (this._invoices != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<InvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceEntityFactory))) : null);


		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Location", _location);
			toReturn.Add("AppointmentStatus", _appointmentStatus);
			toReturn.Add("Assessment", _assessment);
			toReturn.Add("Psychometrist", _psychometrist);
			toReturn.Add("Psychologist", _psychologist);
			toReturn.Add("AppointmentAttributes", _appointmentAttributes);
			toReturn.Add("Invoices", _invoices);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_appointmentAttributes!=null)
			{
				_appointmentAttributes.ActiveContext = base.ActiveContext;
			}
			if(_invoices!=null)
			{
				_invoices.ActiveContext = base.ActiveContext;
			}


			if(_location!=null)
			{
				_location.ActiveContext = base.ActiveContext;
			}
			if(_appointmentStatus!=null)
			{
				_appointmentStatus.ActiveContext = base.ActiveContext;
			}
			if(_assessment!=null)
			{
				_assessment.ActiveContext = base.ActiveContext;
			}
			if(_psychometrist!=null)
			{
				_psychometrist.ActiveContext = base.ActiveContext;
			}
			if(_psychologist!=null)
			{
				_psychologist.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_appointmentAttributes = null;
			_invoices = null;


			_location = null;
			_appointmentStatus = null;
			_assessment = null;
			_psychometrist = null;
			_psychologist = null;

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

			_fieldsCustomProperties.Add("AppointmentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LocationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PsychometristId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PsychologistId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentStatusId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AssessmentId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _location</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLocation(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _location, new PropertyChangedEventHandler( OnLocationPropertyChanged ), "Location", AppointmentEntity.Relations.AddressEntityUsingLocationId, true, signalRelatedEntity, "Appointments", resetFKFields, new int[] { (int)AppointmentFieldIndex.LocationId } );		
			_location = null;
		}

		/// <summary> setups the sync logic for member _location</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLocation(IEntity2 relatedEntity)
		{
			if(_location!=relatedEntity)
			{
				DesetupSyncLocation(true, true);
				_location = (AddressEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _location, new PropertyChangedEventHandler( OnLocationPropertyChanged ), "Location", AppointmentEntity.Relations.AddressEntityUsingLocationId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLocationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _appointmentStatus</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAppointmentStatus(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _appointmentStatus, new PropertyChangedEventHandler( OnAppointmentStatusPropertyChanged ), "AppointmentStatus", AppointmentEntity.Relations.AppointmentStatusEntityUsingAppointmentStatusId, true, signalRelatedEntity, "Appointments", resetFKFields, new int[] { (int)AppointmentFieldIndex.AppointmentStatusId } );		
			_appointmentStatus = null;
		}

		/// <summary> setups the sync logic for member _appointmentStatus</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAppointmentStatus(IEntity2 relatedEntity)
		{
			if(_appointmentStatus!=relatedEntity)
			{
				DesetupSyncAppointmentStatus(true, true);
				_appointmentStatus = (AppointmentStatusEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _appointmentStatus, new PropertyChangedEventHandler( OnAppointmentStatusPropertyChanged ), "AppointmentStatus", AppointmentEntity.Relations.AppointmentStatusEntityUsingAppointmentStatusId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAppointmentStatusPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _assessment</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAssessment(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _assessment, new PropertyChangedEventHandler( OnAssessmentPropertyChanged ), "Assessment", AppointmentEntity.Relations.AssessmentEntityUsingAssessmentId, true, signalRelatedEntity, "Appointments", resetFKFields, new int[] { (int)AppointmentFieldIndex.AssessmentId } );		
			_assessment = null;
		}

		/// <summary> setups the sync logic for member _assessment</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAssessment(IEntity2 relatedEntity)
		{
			if(_assessment!=relatedEntity)
			{
				DesetupSyncAssessment(true, true);
				_assessment = (AssessmentEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _assessment, new PropertyChangedEventHandler( OnAssessmentPropertyChanged ), "Assessment", AppointmentEntity.Relations.AssessmentEntityUsingAssessmentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAssessmentPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _psychometrist</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPsychometrist(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _psychometrist, new PropertyChangedEventHandler( OnPsychometristPropertyChanged ), "Psychometrist", AppointmentEntity.Relations.UserEntityUsingPsychometristId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)AppointmentFieldIndex.PsychometristId } );		
			_psychometrist = null;
		}

		/// <summary> setups the sync logic for member _psychometrist</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPsychometrist(IEntity2 relatedEntity)
		{
			if(_psychometrist!=relatedEntity)
			{
				DesetupSyncPsychometrist(true, true);
				_psychometrist = (UserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _psychometrist, new PropertyChangedEventHandler( OnPsychometristPropertyChanged ), "Psychometrist", AppointmentEntity.Relations.UserEntityUsingPsychometristId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPsychometristPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _psychologist</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPsychologist(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _psychologist, new PropertyChangedEventHandler( OnPsychologistPropertyChanged ), "Psychologist", AppointmentEntity.Relations.UserEntityUsingPsychologistId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)AppointmentFieldIndex.PsychologistId } );		
			_psychologist = null;
		}

		/// <summary> setups the sync logic for member _psychologist</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPsychologist(IEntity2 relatedEntity)
		{
			if(_psychologist!=relatedEntity)
			{
				DesetupSyncPsychologist(true, true);
				_psychologist = (UserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _psychologist, new PropertyChangedEventHandler( OnPsychologistPropertyChanged ), "Psychologist", AppointmentEntity.Relations.UserEntityUsingPsychologistId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPsychologistPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AppointmentEntity</param>
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
		public  static AppointmentRelations Relations
		{
			get	{ return new AppointmentRelations(); }
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
					(IEntityRelation)GetRelationsForField("AppointmentAttributes")[0], (int)PsychologicalServices.Data.EntityType.AppointmentEntity, (int)PsychologicalServices.Data.EntityType.AppointmentAttributeEntity, 0, null, null, null, null, "AppointmentAttributes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Invoice' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInvoices
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<InvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceEntityFactory))),
					(IEntityRelation)GetRelationsForField("Invoices")[0], (int)PsychologicalServices.Data.EntityType.AppointmentEntity, (int)PsychologicalServices.Data.EntityType.InvoiceEntity, 0, null, null, null, null, "Invoices", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLocation
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))),
					(IEntityRelation)GetRelationsForField("Location")[0], (int)PsychologicalServices.Data.EntityType.AppointmentEntity, (int)PsychologicalServices.Data.EntityType.AddressEntity, 0, null, null, null, null, "Location", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AppointmentStatus' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAppointmentStatus
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentStatusEntityFactory))),
					(IEntityRelation)GetRelationsForField("AppointmentStatus")[0], (int)PsychologicalServices.Data.EntityType.AppointmentEntity, (int)PsychologicalServices.Data.EntityType.AppointmentStatusEntity, 0, null, null, null, null, "AppointmentStatus", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Assessment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssessment
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("Assessment")[0], (int)PsychologicalServices.Data.EntityType.AppointmentEntity, (int)PsychologicalServices.Data.EntityType.AssessmentEntity, 0, null, null, null, null, "Assessment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPsychometrist
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),
					(IEntityRelation)GetRelationsForField("Psychometrist")[0], (int)PsychologicalServices.Data.EntityType.AppointmentEntity, (int)PsychologicalServices.Data.EntityType.UserEntity, 0, null, null, null, null, "Psychometrist", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPsychologist
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),
					(IEntityRelation)GetRelationsForField("Psychologist")[0], (int)PsychologicalServices.Data.EntityType.AppointmentEntity, (int)PsychologicalServices.Data.EntityType.UserEntity, 0, null, null, null, null, "Psychologist", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AppointmentEntity.CustomProperties;}
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
			get { return AppointmentEntity.FieldsCustomProperties;}
		}

		/// <summary> The AppointmentId property of the Entity Appointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Appointments"."AppointmentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 AppointmentId
		{
			get { return (System.Int32)GetValue((int)AppointmentFieldIndex.AppointmentId, true); }
			set	{ SetValue((int)AppointmentFieldIndex.AppointmentId, value); }
		}

		/// <summary> The LocationId property of the Entity Appointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Appointments"."LocationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 LocationId
		{
			get { return (System.Int32)GetValue((int)AppointmentFieldIndex.LocationId, true); }
			set	{ SetValue((int)AppointmentFieldIndex.LocationId, value); }
		}

		/// <summary> The AppointmentTime property of the Entity Appointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Appointments"."AppointmentTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime AppointmentTime
		{
			get { return (System.DateTime)GetValue((int)AppointmentFieldIndex.AppointmentTime, true); }
			set	{ SetValue((int)AppointmentFieldIndex.AppointmentTime, value); }
		}

		/// <summary> The PsychometristId property of the Entity Appointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Appointments"."PsychometristId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PsychometristId
		{
			get { return (System.Int32)GetValue((int)AppointmentFieldIndex.PsychometristId, true); }
			set	{ SetValue((int)AppointmentFieldIndex.PsychometristId, value); }
		}

		/// <summary> The PsychologistId property of the Entity Appointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Appointments"."PsychologistId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PsychologistId
		{
			get { return (System.Int32)GetValue((int)AppointmentFieldIndex.PsychologistId, true); }
			set	{ SetValue((int)AppointmentFieldIndex.PsychologistId, value); }
		}

		/// <summary> The AppointmentStatusId property of the Entity Appointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Appointments"."AppointmentStatusId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 AppointmentStatusId
		{
			get { return (System.Int32)GetValue((int)AppointmentFieldIndex.AppointmentStatusId, true); }
			set	{ SetValue((int)AppointmentFieldIndex.AppointmentStatusId, value); }
		}

		/// <summary> The AssessmentId property of the Entity Appointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Appointments"."AssessmentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 AssessmentId
		{
			get { return (System.Int32)GetValue((int)AppointmentFieldIndex.AssessmentId, true); }
			set	{ SetValue((int)AppointmentFieldIndex.AssessmentId, value); }
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
					_appointmentAttributes.SetContainingEntityInfo(this, "Appointment");
				}
				return _appointmentAttributes;
			}
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
					_invoices.SetContainingEntityInfo(this, "Appointment");
				}
				return _invoices;
			}
		}



		/// <summary> Gets / sets related entity of type 'AddressEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AddressEntity Location
		{
			get
			{
				return _location;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLocation(value);
				}
				else
				{
					if(value==null)
					{
						if(_location != null)
						{
							_location.UnsetRelatedEntity(this, "Appointments");
						}
					}
					else
					{
						if(_location!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Appointments");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'AppointmentStatusEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AppointmentStatusEntity AppointmentStatus
		{
			get
			{
				return _appointmentStatus;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAppointmentStatus(value);
				}
				else
				{
					if(value==null)
					{
						if(_appointmentStatus != null)
						{
							_appointmentStatus.UnsetRelatedEntity(this, "Appointments");
						}
					}
					else
					{
						if(_appointmentStatus!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Appointments");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'AssessmentEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AssessmentEntity Assessment
		{
			get
			{
				return _assessment;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAssessment(value);
				}
				else
				{
					if(value==null)
					{
						if(_assessment != null)
						{
							_assessment.UnsetRelatedEntity(this, "Appointments");
						}
					}
					else
					{
						if(_assessment!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Appointments");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual UserEntity Psychometrist
		{
			get
			{
				return _psychometrist;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPsychometrist(value);
				}
				else
				{
					if(value==null)
					{
						if(_psychometrist != null)
						{
							UnsetRelatedEntity(_psychometrist, "Psychometrist");
						}
					}
					else
					{
						if(_psychometrist!=value)
						{
							SetRelatedEntity((IEntity2)value, "Psychometrist");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual UserEntity Psychologist
		{
			get
			{
				return _psychologist;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPsychologist(value);
				}
				else
				{
					if(value==null)
					{
						if(_psychologist != null)
						{
							UnsetRelatedEntity(_psychologist, "Psychologist");
						}
					}
					else
					{
						if(_psychologist!=value)
						{
							SetRelatedEntity((IEntity2)value, "Psychologist");
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
			get { return (int)PsychologicalServices.Data.EntityType.AppointmentEntity; }
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
