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
	/// Entity class which represents the entity 'Invoice'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class InvoiceEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<InvoiceAppointmentEntity> _invoiceAppointments;
		private EntityCollection<InvoiceDocumentEntity> _invoiceDocuments;
		private EntityCollection<InvoiceStatusChangeEntity> _invoiceStatusChanges;


		private InvoiceStatusEntity _invoiceStatus;
		private InvoiceTypeEntity _invoiceType;
		private UserEntity _payableTo;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name InvoiceStatus</summary>
			public static readonly string InvoiceStatus = "InvoiceStatus";
			/// <summary>Member name InvoiceType</summary>
			public static readonly string InvoiceType = "InvoiceType";
			/// <summary>Member name PayableTo</summary>
			public static readonly string PayableTo = "PayableTo";
			/// <summary>Member name InvoiceAppointments</summary>
			public static readonly string InvoiceAppointments = "InvoiceAppointments";
			/// <summary>Member name InvoiceDocuments</summary>
			public static readonly string InvoiceDocuments = "InvoiceDocuments";
			/// <summary>Member name InvoiceStatusChanges</summary>
			public static readonly string InvoiceStatusChanges = "InvoiceStatusChanges";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static InvoiceEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public InvoiceEntity():base("InvoiceEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public InvoiceEntity(IEntityFields2 fields):base("InvoiceEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this InvoiceEntity</param>
		public InvoiceEntity(IValidator validator):base("InvoiceEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="invoiceId">PK value for Invoice which data should be fetched into this Invoice object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public InvoiceEntity(System.Int32 invoiceId):base("InvoiceEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.InvoiceId = invoiceId;
		}

		/// <summary> CTor</summary>
		/// <param name="invoiceId">PK value for Invoice which data should be fetched into this Invoice object</param>
		/// <param name="validator">The custom validator object for this InvoiceEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public InvoiceEntity(System.Int32 invoiceId, IValidator validator):base("InvoiceEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.InvoiceId = invoiceId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected InvoiceEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_invoiceAppointments = (EntityCollection<InvoiceAppointmentEntity>)info.GetValue("_invoiceAppointments", typeof(EntityCollection<InvoiceAppointmentEntity>));
				_invoiceDocuments = (EntityCollection<InvoiceDocumentEntity>)info.GetValue("_invoiceDocuments", typeof(EntityCollection<InvoiceDocumentEntity>));
				_invoiceStatusChanges = (EntityCollection<InvoiceStatusChangeEntity>)info.GetValue("_invoiceStatusChanges", typeof(EntityCollection<InvoiceStatusChangeEntity>));


				_invoiceStatus = (InvoiceStatusEntity)info.GetValue("_invoiceStatus", typeof(InvoiceStatusEntity));
				if(_invoiceStatus!=null)
				{
					_invoiceStatus.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_invoiceType = (InvoiceTypeEntity)info.GetValue("_invoiceType", typeof(InvoiceTypeEntity));
				if(_invoiceType!=null)
				{
					_invoiceType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_payableTo = (UserEntity)info.GetValue("_payableTo", typeof(UserEntity));
				if(_payableTo!=null)
				{
					_payableTo.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((InvoiceFieldIndex)fieldIndex)
			{
				case InvoiceFieldIndex.InvoiceStatusId:
					DesetupSyncInvoiceStatus(true, false);
					break;
				case InvoiceFieldIndex.InvoiceTypeId:
					DesetupSyncInvoiceType(true, false);
					break;
				case InvoiceFieldIndex.PayableToId:
					DesetupSyncPayableTo(true, false);
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
				case "InvoiceStatus":
					this.InvoiceStatus = (InvoiceStatusEntity)entity;
					break;
				case "InvoiceType":
					this.InvoiceType = (InvoiceTypeEntity)entity;
					break;
				case "PayableTo":
					this.PayableTo = (UserEntity)entity;
					break;
				case "InvoiceAppointments":
					this.InvoiceAppointments.Add((InvoiceAppointmentEntity)entity);
					break;
				case "InvoiceDocuments":
					this.InvoiceDocuments.Add((InvoiceDocumentEntity)entity);
					break;
				case "InvoiceStatusChanges":
					this.InvoiceStatusChanges.Add((InvoiceStatusChangeEntity)entity);
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
			return InvoiceEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "InvoiceStatus":
					toReturn.Add(InvoiceEntity.Relations.InvoiceStatusEntityUsingInvoiceStatusId);
					break;
				case "InvoiceType":
					toReturn.Add(InvoiceEntity.Relations.InvoiceTypeEntityUsingInvoiceTypeId);
					break;
				case "PayableTo":
					toReturn.Add(InvoiceEntity.Relations.UserEntityUsingPayableToId);
					break;
				case "InvoiceAppointments":
					toReturn.Add(InvoiceEntity.Relations.InvoiceAppointmentEntityUsingInvoiceId);
					break;
				case "InvoiceDocuments":
					toReturn.Add(InvoiceEntity.Relations.InvoiceDocumentEntityUsingInvoiceId);
					break;
				case "InvoiceStatusChanges":
					toReturn.Add(InvoiceEntity.Relations.InvoiceStatusChangeEntityUsingInvoiceId);
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
				case "InvoiceStatus":
					SetupSyncInvoiceStatus(relatedEntity);
					break;
				case "InvoiceType":
					SetupSyncInvoiceType(relatedEntity);
					break;
				case "PayableTo":
					SetupSyncPayableTo(relatedEntity);
					break;
				case "InvoiceAppointments":
					this.InvoiceAppointments.Add((InvoiceAppointmentEntity)relatedEntity);
					break;
				case "InvoiceDocuments":
					this.InvoiceDocuments.Add((InvoiceDocumentEntity)relatedEntity);
					break;
				case "InvoiceStatusChanges":
					this.InvoiceStatusChanges.Add((InvoiceStatusChangeEntity)relatedEntity);
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
				case "InvoiceStatus":
					DesetupSyncInvoiceStatus(false, true);
					break;
				case "InvoiceType":
					DesetupSyncInvoiceType(false, true);
					break;
				case "PayableTo":
					DesetupSyncPayableTo(false, true);
					break;
				case "InvoiceAppointments":
					base.PerformRelatedEntityRemoval(this.InvoiceAppointments, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "InvoiceDocuments":
					base.PerformRelatedEntityRemoval(this.InvoiceDocuments, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "InvoiceStatusChanges":
					base.PerformRelatedEntityRemoval(this.InvoiceStatusChanges, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_invoiceStatus!=null)
			{
				toReturn.Add(_invoiceStatus);
			}
			if(_invoiceType!=null)
			{
				toReturn.Add(_invoiceType);
			}
			if(_payableTo!=null)
			{
				toReturn.Add(_payableTo);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.InvoiceAppointments);
			toReturn.Add(this.InvoiceDocuments);
			toReturn.Add(this.InvoiceStatusChanges);

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
				info.AddValue("_invoiceAppointments", ((_invoiceAppointments!=null) && (_invoiceAppointments.Count>0) && !this.MarkedForDeletion)?_invoiceAppointments:null);
				info.AddValue("_invoiceDocuments", ((_invoiceDocuments!=null) && (_invoiceDocuments.Count>0) && !this.MarkedForDeletion)?_invoiceDocuments:null);
				info.AddValue("_invoiceStatusChanges", ((_invoiceStatusChanges!=null) && (_invoiceStatusChanges.Count>0) && !this.MarkedForDeletion)?_invoiceStatusChanges:null);


				info.AddValue("_invoiceStatus", (!this.MarkedForDeletion?_invoiceStatus:null));
				info.AddValue("_invoiceType", (!this.MarkedForDeletion?_invoiceType:null));
				info.AddValue("_payableTo", (!this.MarkedForDeletion?_payableTo:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(InvoiceFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(InvoiceFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new InvoiceRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'InvoiceAppointment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInvoiceAppointments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InvoiceAppointmentFields.InvoiceId, null, ComparisonOperator.Equal, this.InvoiceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'InvoiceDocument' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInvoiceDocuments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InvoiceDocumentFields.InvoiceId, null, ComparisonOperator.Equal, this.InvoiceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'InvoiceStatusChange' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInvoiceStatusChanges()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InvoiceStatusChangeFields.InvoiceId, null, ComparisonOperator.Equal, this.InvoiceId));
			return bucket;
		}



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'InvoiceStatus' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInvoiceStatus()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InvoiceStatusFields.InvoiceStatusId, null, ComparisonOperator.Equal, this.InvoiceStatusId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'InvoiceType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInvoiceType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InvoiceTypeFields.InvoiceTypeId, null, ComparisonOperator.Equal, this.InvoiceTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'User' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPayableTo()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.PayableToId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(PsychologicalServices.Data.EntityType.InvoiceEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(InvoiceEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._invoiceAppointments);
			collectionsQueue.Enqueue(this._invoiceDocuments);
			collectionsQueue.Enqueue(this._invoiceStatusChanges);


		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._invoiceAppointments = (EntityCollection<InvoiceAppointmentEntity>) collectionsQueue.Dequeue();
			this._invoiceDocuments = (EntityCollection<InvoiceDocumentEntity>) collectionsQueue.Dequeue();
			this._invoiceStatusChanges = (EntityCollection<InvoiceStatusChangeEntity>) collectionsQueue.Dequeue();


		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._invoiceAppointments != null)
			{
				return true;
			}
			if (this._invoiceDocuments != null)
			{
				return true;
			}
			if (this._invoiceStatusChanges != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<InvoiceAppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceAppointmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<InvoiceDocumentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceDocumentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<InvoiceStatusChangeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceStatusChangeEntityFactory))) : null);


		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("InvoiceStatus", _invoiceStatus);
			toReturn.Add("InvoiceType", _invoiceType);
			toReturn.Add("PayableTo", _payableTo);
			toReturn.Add("InvoiceAppointments", _invoiceAppointments);
			toReturn.Add("InvoiceDocuments", _invoiceDocuments);
			toReturn.Add("InvoiceStatusChanges", _invoiceStatusChanges);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_invoiceAppointments!=null)
			{
				_invoiceAppointments.ActiveContext = base.ActiveContext;
			}
			if(_invoiceDocuments!=null)
			{
				_invoiceDocuments.ActiveContext = base.ActiveContext;
			}
			if(_invoiceStatusChanges!=null)
			{
				_invoiceStatusChanges.ActiveContext = base.ActiveContext;
			}


			if(_invoiceStatus!=null)
			{
				_invoiceStatus.ActiveContext = base.ActiveContext;
			}
			if(_invoiceType!=null)
			{
				_invoiceType.ActiveContext = base.ActiveContext;
			}
			if(_payableTo!=null)
			{
				_payableTo.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_invoiceAppointments = null;
			_invoiceDocuments = null;
			_invoiceStatusChanges = null;


			_invoiceStatus = null;
			_invoiceType = null;
			_payableTo = null;

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

			_fieldsCustomProperties.Add("InvoiceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Identifier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InvoiceDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InvoiceStatusId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdateDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TaxRate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Total", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InvoiceTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PayableToId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _invoiceStatus</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncInvoiceStatus(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _invoiceStatus, new PropertyChangedEventHandler( OnInvoiceStatusPropertyChanged ), "InvoiceStatus", InvoiceEntity.Relations.InvoiceStatusEntityUsingInvoiceStatusId, true, signalRelatedEntity, "Invoices", resetFKFields, new int[] { (int)InvoiceFieldIndex.InvoiceStatusId } );		
			_invoiceStatus = null;
		}

		/// <summary> setups the sync logic for member _invoiceStatus</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncInvoiceStatus(IEntity2 relatedEntity)
		{
			if(_invoiceStatus!=relatedEntity)
			{
				DesetupSyncInvoiceStatus(true, true);
				_invoiceStatus = (InvoiceStatusEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _invoiceStatus, new PropertyChangedEventHandler( OnInvoiceStatusPropertyChanged ), "InvoiceStatus", InvoiceEntity.Relations.InvoiceStatusEntityUsingInvoiceStatusId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnInvoiceStatusPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _invoiceType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncInvoiceType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _invoiceType, new PropertyChangedEventHandler( OnInvoiceTypePropertyChanged ), "InvoiceType", InvoiceEntity.Relations.InvoiceTypeEntityUsingInvoiceTypeId, true, signalRelatedEntity, "Invoices", resetFKFields, new int[] { (int)InvoiceFieldIndex.InvoiceTypeId } );		
			_invoiceType = null;
		}

		/// <summary> setups the sync logic for member _invoiceType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncInvoiceType(IEntity2 relatedEntity)
		{
			if(_invoiceType!=relatedEntity)
			{
				DesetupSyncInvoiceType(true, true);
				_invoiceType = (InvoiceTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _invoiceType, new PropertyChangedEventHandler( OnInvoiceTypePropertyChanged ), "InvoiceType", InvoiceEntity.Relations.InvoiceTypeEntityUsingInvoiceTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnInvoiceTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _payableTo</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPayableTo(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _payableTo, new PropertyChangedEventHandler( OnPayableToPropertyChanged ), "PayableTo", InvoiceEntity.Relations.UserEntityUsingPayableToId, true, signalRelatedEntity, "Invoices", resetFKFields, new int[] { (int)InvoiceFieldIndex.PayableToId } );		
			_payableTo = null;
		}

		/// <summary> setups the sync logic for member _payableTo</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPayableTo(IEntity2 relatedEntity)
		{
			if(_payableTo!=relatedEntity)
			{
				DesetupSyncPayableTo(true, true);
				_payableTo = (UserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _payableTo, new PropertyChangedEventHandler( OnPayableToPropertyChanged ), "PayableTo", InvoiceEntity.Relations.UserEntityUsingPayableToId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPayableToPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this InvoiceEntity</param>
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
		public  static InvoiceRelations Relations
		{
			get	{ return new InvoiceRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InvoiceAppointment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInvoiceAppointments
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<InvoiceAppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceAppointmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("InvoiceAppointments")[0], (int)PsychologicalServices.Data.EntityType.InvoiceEntity, (int)PsychologicalServices.Data.EntityType.InvoiceAppointmentEntity, 0, null, null, null, null, "InvoiceAppointments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InvoiceDocument' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInvoiceDocuments
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<InvoiceDocumentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceDocumentEntityFactory))),
					(IEntityRelation)GetRelationsForField("InvoiceDocuments")[0], (int)PsychologicalServices.Data.EntityType.InvoiceEntity, (int)PsychologicalServices.Data.EntityType.InvoiceDocumentEntity, 0, null, null, null, null, "InvoiceDocuments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InvoiceStatusChange' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInvoiceStatusChanges
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<InvoiceStatusChangeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceStatusChangeEntityFactory))),
					(IEntityRelation)GetRelationsForField("InvoiceStatusChanges")[0], (int)PsychologicalServices.Data.EntityType.InvoiceEntity, (int)PsychologicalServices.Data.EntityType.InvoiceStatusChangeEntity, 0, null, null, null, null, "InvoiceStatusChanges", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InvoiceStatus' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInvoiceStatus
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceStatusEntityFactory))),
					(IEntityRelation)GetRelationsForField("InvoiceStatus")[0], (int)PsychologicalServices.Data.EntityType.InvoiceEntity, (int)PsychologicalServices.Data.EntityType.InvoiceStatusEntity, 0, null, null, null, null, "InvoiceStatus", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InvoiceType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInvoiceType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("InvoiceType")[0], (int)PsychologicalServices.Data.EntityType.InvoiceEntity, (int)PsychologicalServices.Data.EntityType.InvoiceTypeEntity, 0, null, null, null, null, "InvoiceType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPayableTo
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),
					(IEntityRelation)GetRelationsForField("PayableTo")[0], (int)PsychologicalServices.Data.EntityType.InvoiceEntity, (int)PsychologicalServices.Data.EntityType.UserEntity, 0, null, null, null, null, "PayableTo", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return InvoiceEntity.CustomProperties;}
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
			get { return InvoiceEntity.FieldsCustomProperties;}
		}

		/// <summary> The InvoiceId property of the Entity Invoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Invoices"."InvoiceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 InvoiceId
		{
			get { return (System.Int32)GetValue((int)InvoiceFieldIndex.InvoiceId, true); }
			set	{ SetValue((int)InvoiceFieldIndex.InvoiceId, value); }
		}

		/// <summary> The Identifier property of the Entity Invoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Invoices"."Identifier"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Identifier
		{
			get { return (System.String)GetValue((int)InvoiceFieldIndex.Identifier, true); }
			set	{ SetValue((int)InvoiceFieldIndex.Identifier, value); }
		}

		/// <summary> The InvoiceDate property of the Entity Invoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Invoices"."InvoiceDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime InvoiceDate
		{
			get { return (System.DateTime)GetValue((int)InvoiceFieldIndex.InvoiceDate, true); }
			set	{ SetValue((int)InvoiceFieldIndex.InvoiceDate, value); }
		}

		/// <summary> The InvoiceStatusId property of the Entity Invoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Invoices"."InvoiceStatusId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 InvoiceStatusId
		{
			get { return (System.Int32)GetValue((int)InvoiceFieldIndex.InvoiceStatusId, true); }
			set	{ SetValue((int)InvoiceFieldIndex.InvoiceStatusId, value); }
		}

		/// <summary> The UpdateDate property of the Entity Invoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Invoices"."UpdateDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime UpdateDate
		{
			get { return (System.DateTime)GetValue((int)InvoiceFieldIndex.UpdateDate, true); }
			set	{ SetValue((int)InvoiceFieldIndex.UpdateDate, value); }
		}

		/// <summary> The TaxRate property of the Entity Invoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Invoices"."TaxRate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal TaxRate
		{
			get { return (System.Decimal)GetValue((int)InvoiceFieldIndex.TaxRate, true); }
			set	{ SetValue((int)InvoiceFieldIndex.TaxRate, value); }
		}

		/// <summary> The Total property of the Entity Invoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Invoices"."Total"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Total
		{
			get { return (System.Decimal)GetValue((int)InvoiceFieldIndex.Total, true); }
			set	{ SetValue((int)InvoiceFieldIndex.Total, value); }
		}

		/// <summary> The InvoiceTypeId property of the Entity Invoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Invoices"."InvoiceTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 InvoiceTypeId
		{
			get { return (System.Int32)GetValue((int)InvoiceFieldIndex.InvoiceTypeId, true); }
			set	{ SetValue((int)InvoiceFieldIndex.InvoiceTypeId, value); }
		}

		/// <summary> The PayableToId property of the Entity Invoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Invoices"."PayableToId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PayableToId
		{
			get { return (System.Int32)GetValue((int)InvoiceFieldIndex.PayableToId, true); }
			set	{ SetValue((int)InvoiceFieldIndex.PayableToId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'InvoiceAppointmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(InvoiceAppointmentEntity))]
		public virtual EntityCollection<InvoiceAppointmentEntity> InvoiceAppointments
		{
			get
			{
				if(_invoiceAppointments==null)
				{
					_invoiceAppointments = new EntityCollection<InvoiceAppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceAppointmentEntityFactory)));
					_invoiceAppointments.SetContainingEntityInfo(this, "Invoice");
				}
				return _invoiceAppointments;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'InvoiceDocumentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(InvoiceDocumentEntity))]
		public virtual EntityCollection<InvoiceDocumentEntity> InvoiceDocuments
		{
			get
			{
				if(_invoiceDocuments==null)
				{
					_invoiceDocuments = new EntityCollection<InvoiceDocumentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceDocumentEntityFactory)));
					_invoiceDocuments.SetContainingEntityInfo(this, "Invoice");
				}
				return _invoiceDocuments;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'InvoiceStatusChangeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(InvoiceStatusChangeEntity))]
		public virtual EntityCollection<InvoiceStatusChangeEntity> InvoiceStatusChanges
		{
			get
			{
				if(_invoiceStatusChanges==null)
				{
					_invoiceStatusChanges = new EntityCollection<InvoiceStatusChangeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceStatusChangeEntityFactory)));
					_invoiceStatusChanges.SetContainingEntityInfo(this, "Invoice");
				}
				return _invoiceStatusChanges;
			}
		}



		/// <summary> Gets / sets related entity of type 'InvoiceStatusEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual InvoiceStatusEntity InvoiceStatus
		{
			get
			{
				return _invoiceStatus;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncInvoiceStatus(value);
				}
				else
				{
					if(value==null)
					{
						if(_invoiceStatus != null)
						{
							_invoiceStatus.UnsetRelatedEntity(this, "Invoices");
						}
					}
					else
					{
						if(_invoiceStatus!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Invoices");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'InvoiceTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual InvoiceTypeEntity InvoiceType
		{
			get
			{
				return _invoiceType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncInvoiceType(value);
				}
				else
				{
					if(value==null)
					{
						if(_invoiceType != null)
						{
							_invoiceType.UnsetRelatedEntity(this, "Invoices");
						}
					}
					else
					{
						if(_invoiceType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Invoices");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual UserEntity PayableTo
		{
			get
			{
				return _payableTo;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPayableTo(value);
				}
				else
				{
					if(value==null)
					{
						if(_payableTo != null)
						{
							_payableTo.UnsetRelatedEntity(this, "Invoices");
						}
					}
					else
					{
						if(_payableTo!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Invoices");
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
			get { return (int)PsychologicalServices.Data.EntityType.InvoiceEntity; }
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
