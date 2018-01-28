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
	/// Entity class which represents the entity 'InvoiceLineGroup'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class InvoiceLineGroupEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<InvoiceLineEntity> _invoiceLines;

		private InvoiceEntity _invoice;
		private InvoiceLineGroupAppointmentEntity _invoiceLineGroupAppointment;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Invoice</summary>
			public static readonly string Invoice = "Invoice";
			/// <summary>Member name InvoiceLines</summary>
			public static readonly string InvoiceLines = "InvoiceLines";

			/// <summary>Member name InvoiceLineGroupAppointment</summary>
			public static readonly string InvoiceLineGroupAppointment = "InvoiceLineGroupAppointment";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static InvoiceLineGroupEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public InvoiceLineGroupEntity():base("InvoiceLineGroupEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public InvoiceLineGroupEntity(IEntityFields2 fields):base("InvoiceLineGroupEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this InvoiceLineGroupEntity</param>
		public InvoiceLineGroupEntity(IValidator validator):base("InvoiceLineGroupEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="invoiceLineGroupId">PK value for InvoiceLineGroup which data should be fetched into this InvoiceLineGroup object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public InvoiceLineGroupEntity(System.Int32 invoiceLineGroupId):base("InvoiceLineGroupEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.InvoiceLineGroupId = invoiceLineGroupId;
		}

		/// <summary> CTor</summary>
		/// <param name="invoiceLineGroupId">PK value for InvoiceLineGroup which data should be fetched into this InvoiceLineGroup object</param>
		/// <param name="validator">The custom validator object for this InvoiceLineGroupEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public InvoiceLineGroupEntity(System.Int32 invoiceLineGroupId, IValidator validator):base("InvoiceLineGroupEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.InvoiceLineGroupId = invoiceLineGroupId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected InvoiceLineGroupEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_invoiceLines = (EntityCollection<InvoiceLineEntity>)info.GetValue("_invoiceLines", typeof(EntityCollection<InvoiceLineEntity>));

				_invoice = (InvoiceEntity)info.GetValue("_invoice", typeof(InvoiceEntity));
				if(_invoice!=null)
				{
					_invoice.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_invoiceLineGroupAppointment = (InvoiceLineGroupAppointmentEntity)info.GetValue("_invoiceLineGroupAppointment", typeof(InvoiceLineGroupAppointmentEntity));
				if(_invoiceLineGroupAppointment!=null)
				{
					_invoiceLineGroupAppointment.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((InvoiceLineGroupFieldIndex)fieldIndex)
			{
				case InvoiceLineGroupFieldIndex.InvoiceId:
					DesetupSyncInvoice(true, false);
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
				case "Invoice":
					this.Invoice = (InvoiceEntity)entity;
					break;
				case "InvoiceLines":
					this.InvoiceLines.Add((InvoiceLineEntity)entity);
					break;

				case "InvoiceLineGroupAppointment":
					this.InvoiceLineGroupAppointment = (InvoiceLineGroupAppointmentEntity)entity;
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
			return InvoiceLineGroupEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Invoice":
					toReturn.Add(InvoiceLineGroupEntity.Relations.InvoiceEntityUsingInvoiceId);
					break;
				case "InvoiceLines":
					toReturn.Add(InvoiceLineGroupEntity.Relations.InvoiceLineEntityUsingInvoiceLineGroupId);
					break;

				case "InvoiceLineGroupAppointment":
					toReturn.Add(InvoiceLineGroupEntity.Relations.InvoiceLineGroupAppointmentEntityUsingInvoiceLineGroupId);
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
				case "Invoice":
					SetupSyncInvoice(relatedEntity);
					break;
				case "InvoiceLines":
					this.InvoiceLines.Add((InvoiceLineEntity)relatedEntity);
					break;
				case "InvoiceLineGroupAppointment":
					SetupSyncInvoiceLineGroupAppointment(relatedEntity);
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
				case "Invoice":
					DesetupSyncInvoice(false, true);
					break;
				case "InvoiceLines":
					base.PerformRelatedEntityRemoval(this.InvoiceLines, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "InvoiceLineGroupAppointment":
					DesetupSyncInvoiceLineGroupAppointment(false, true);
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
			if(_invoiceLineGroupAppointment!=null)
			{
				toReturn.Add(_invoiceLineGroupAppointment);
			}

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_invoice!=null)
			{
				toReturn.Add(_invoice);
			}


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.InvoiceLines);

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
				info.AddValue("_invoiceLines", ((_invoiceLines!=null) && (_invoiceLines.Count>0) && !this.MarkedForDeletion)?_invoiceLines:null);

				info.AddValue("_invoice", (!this.MarkedForDeletion?_invoice:null));
				info.AddValue("_invoiceLineGroupAppointment", (!this.MarkedForDeletion?_invoiceLineGroupAppointment:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(InvoiceLineGroupFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(InvoiceLineGroupFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new InvoiceLineGroupRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'InvoiceLine' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInvoiceLines()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InvoiceLineFields.InvoiceLineGroupId, null, ComparisonOperator.Equal, this.InvoiceLineGroupId));
			return bucket;
		}


		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Invoice' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInvoice()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InvoiceFields.InvoiceId, null, ComparisonOperator.Equal, this.InvoiceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'InvoiceLineGroupAppointment' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInvoiceLineGroupAppointment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InvoiceLineGroupAppointmentFields.InvoiceLineGroupId, null, ComparisonOperator.Equal, this.InvoiceLineGroupId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(PsychologicalServices.Data.EntityType.InvoiceLineGroupEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(InvoiceLineGroupEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._invoiceLines);

		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._invoiceLines = (EntityCollection<InvoiceLineEntity>) collectionsQueue.Dequeue();

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._invoiceLines != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<InvoiceLineEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceLineEntityFactory))) : null);

		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Invoice", _invoice);
			toReturn.Add("InvoiceLines", _invoiceLines);

			toReturn.Add("InvoiceLineGroupAppointment", _invoiceLineGroupAppointment);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_invoiceLines!=null)
			{
				_invoiceLines.ActiveContext = base.ActiveContext;
			}

			if(_invoice!=null)
			{
				_invoice.ActiveContext = base.ActiveContext;
			}
			if(_invoiceLineGroupAppointment!=null)
			{
				_invoiceLineGroupAppointment.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_invoiceLines = null;

			_invoice = null;
			_invoiceLineGroupAppointment = null;
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

			_fieldsCustomProperties.Add("InvoiceLineGroupId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InvoiceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _invoice</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncInvoice(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _invoice, new PropertyChangedEventHandler( OnInvoicePropertyChanged ), "Invoice", InvoiceLineGroupEntity.Relations.InvoiceEntityUsingInvoiceId, true, signalRelatedEntity, "InvoiceLineGroups", resetFKFields, new int[] { (int)InvoiceLineGroupFieldIndex.InvoiceId } );		
			_invoice = null;
		}

		/// <summary> setups the sync logic for member _invoice</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncInvoice(IEntity2 relatedEntity)
		{
			if(_invoice!=relatedEntity)
			{
				DesetupSyncInvoice(true, true);
				_invoice = (InvoiceEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _invoice, new PropertyChangedEventHandler( OnInvoicePropertyChanged ), "Invoice", InvoiceLineGroupEntity.Relations.InvoiceEntityUsingInvoiceId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnInvoicePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _invoiceLineGroupAppointment</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncInvoiceLineGroupAppointment(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _invoiceLineGroupAppointment, new PropertyChangedEventHandler( OnInvoiceLineGroupAppointmentPropertyChanged ), "InvoiceLineGroupAppointment", InvoiceLineGroupEntity.Relations.InvoiceLineGroupAppointmentEntityUsingInvoiceLineGroupId, false, signalRelatedEntity, "InvoiceLineGroup", false, new int[] { (int)InvoiceLineGroupFieldIndex.InvoiceLineGroupId } );
			_invoiceLineGroupAppointment = null;
		}
		
		/// <summary> setups the sync logic for member _invoiceLineGroupAppointment</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncInvoiceLineGroupAppointment(IEntity2 relatedEntity)
		{
			if(_invoiceLineGroupAppointment!=relatedEntity)
			{
				DesetupSyncInvoiceLineGroupAppointment(true, true);
				_invoiceLineGroupAppointment = (InvoiceLineGroupAppointmentEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _invoiceLineGroupAppointment, new PropertyChangedEventHandler( OnInvoiceLineGroupAppointmentPropertyChanged ), "InvoiceLineGroupAppointment", InvoiceLineGroupEntity.Relations.InvoiceLineGroupAppointmentEntityUsingInvoiceLineGroupId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnInvoiceLineGroupAppointmentPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this InvoiceLineGroupEntity</param>
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
		public  static InvoiceLineGroupRelations Relations
		{
			get	{ return new InvoiceLineGroupRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InvoiceLine' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInvoiceLines
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<InvoiceLineEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceLineEntityFactory))),
					(IEntityRelation)GetRelationsForField("InvoiceLines")[0], (int)PsychologicalServices.Data.EntityType.InvoiceLineGroupEntity, (int)PsychologicalServices.Data.EntityType.InvoiceLineEntity, 0, null, null, null, null, "InvoiceLines", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}


		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Invoice' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInvoice
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceEntityFactory))),
					(IEntityRelation)GetRelationsForField("Invoice")[0], (int)PsychologicalServices.Data.EntityType.InvoiceLineGroupEntity, (int)PsychologicalServices.Data.EntityType.InvoiceEntity, 0, null, null, null, null, "Invoice", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InvoiceLineGroupAppointment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInvoiceLineGroupAppointment
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceLineGroupAppointmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("InvoiceLineGroupAppointment")[0], (int)PsychologicalServices.Data.EntityType.InvoiceLineGroupEntity, (int)PsychologicalServices.Data.EntityType.InvoiceLineGroupAppointmentEntity, 0, null, null, null, null, "InvoiceLineGroupAppointment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return InvoiceLineGroupEntity.CustomProperties;}
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
			get { return InvoiceLineGroupEntity.FieldsCustomProperties;}
		}

		/// <summary> The InvoiceLineGroupId property of the Entity InvoiceLineGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "InvoiceLineGroups"."InvoiceLineGroupId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 InvoiceLineGroupId
		{
			get { return (System.Int32)GetValue((int)InvoiceLineGroupFieldIndex.InvoiceLineGroupId, true); }
			set	{ SetValue((int)InvoiceLineGroupFieldIndex.InvoiceLineGroupId, value); }
		}

		/// <summary> The InvoiceId property of the Entity InvoiceLineGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "InvoiceLineGroups"."InvoiceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 InvoiceId
		{
			get { return (System.Int32)GetValue((int)InvoiceLineGroupFieldIndex.InvoiceId, true); }
			set	{ SetValue((int)InvoiceLineGroupFieldIndex.InvoiceId, value); }
		}

		/// <summary> The Description property of the Entity InvoiceLineGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "InvoiceLineGroups"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)InvoiceLineGroupFieldIndex.Description, true); }
			set	{ SetValue((int)InvoiceLineGroupFieldIndex.Description, value); }
		}

		/// <summary> The Sort property of the Entity InvoiceLineGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "InvoiceLineGroups"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Sort
		{
			get { return (System.Int32)GetValue((int)InvoiceLineGroupFieldIndex.Sort, true); }
			set	{ SetValue((int)InvoiceLineGroupFieldIndex.Sort, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'InvoiceLineEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(InvoiceLineEntity))]
		public virtual EntityCollection<InvoiceLineEntity> InvoiceLines
		{
			get
			{
				if(_invoiceLines==null)
				{
					_invoiceLines = new EntityCollection<InvoiceLineEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceLineEntityFactory)));
					_invoiceLines.SetContainingEntityInfo(this, "InvoiceLineGroup");
				}
				return _invoiceLines;
			}
		}


		/// <summary> Gets / sets related entity of type 'InvoiceEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual InvoiceEntity Invoice
		{
			get
			{
				return _invoice;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncInvoice(value);
				}
				else
				{
					if(value==null)
					{
						if(_invoice != null)
						{
							_invoice.UnsetRelatedEntity(this, "InvoiceLineGroups");
						}
					}
					else
					{
						if(_invoice!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "InvoiceLineGroups");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'InvoiceLineGroupAppointmentEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual InvoiceLineGroupAppointmentEntity InvoiceLineGroupAppointment
		{
			get
			{
				return _invoiceLineGroupAppointment;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncInvoiceLineGroupAppointment(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "InvoiceLineGroup");
					}
				}
				else
				{
					if(value==null)
					{
						DesetupSyncInvoiceLineGroupAppointment(true, true);
					}
					else
					{
						if(_invoiceLineGroupAppointment!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "InvoiceLineGroup");
							SetupSyncInvoiceLineGroupAppointment(relatedEntity);
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
			get { return (int)PsychologicalServices.Data.EntityType.InvoiceLineGroupEntity; }
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
