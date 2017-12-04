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
	/// Entity class which represents the entity 'InvoiceDocumentSendLog'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class InvoiceDocumentSendLogEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private InvoiceDocumentEntity _invoiceDocument;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name InvoiceDocument</summary>
			public static readonly string InvoiceDocument = "InvoiceDocument";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static InvoiceDocumentSendLogEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public InvoiceDocumentSendLogEntity():base("InvoiceDocumentSendLogEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public InvoiceDocumentSendLogEntity(IEntityFields2 fields):base("InvoiceDocumentSendLogEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this InvoiceDocumentSendLogEntity</param>
		public InvoiceDocumentSendLogEntity(IValidator validator):base("InvoiceDocumentSendLogEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="invoiceDocumentSendLogId">PK value for InvoiceDocumentSendLog which data should be fetched into this InvoiceDocumentSendLog object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public InvoiceDocumentSendLogEntity(System.Int32 invoiceDocumentSendLogId):base("InvoiceDocumentSendLogEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.InvoiceDocumentSendLogId = invoiceDocumentSendLogId;
		}

		/// <summary> CTor</summary>
		/// <param name="invoiceDocumentSendLogId">PK value for InvoiceDocumentSendLog which data should be fetched into this InvoiceDocumentSendLog object</param>
		/// <param name="validator">The custom validator object for this InvoiceDocumentSendLogEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public InvoiceDocumentSendLogEntity(System.Int32 invoiceDocumentSendLogId, IValidator validator):base("InvoiceDocumentSendLogEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.InvoiceDocumentSendLogId = invoiceDocumentSendLogId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected InvoiceDocumentSendLogEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_invoiceDocument = (InvoiceDocumentEntity)info.GetValue("_invoiceDocument", typeof(InvoiceDocumentEntity));
				if(_invoiceDocument!=null)
				{
					_invoiceDocument.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((InvoiceDocumentSendLogFieldIndex)fieldIndex)
			{
				case InvoiceDocumentSendLogFieldIndex.InvoiceDocumentId:
					DesetupSyncInvoiceDocument(true, false);
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
				case "InvoiceDocument":
					this.InvoiceDocument = (InvoiceDocumentEntity)entity;
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
			return InvoiceDocumentSendLogEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "InvoiceDocument":
					toReturn.Add(InvoiceDocumentSendLogEntity.Relations.InvoiceDocumentEntityUsingInvoiceDocumentId);
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
				case "InvoiceDocument":
					SetupSyncInvoiceDocument(relatedEntity);
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
				case "InvoiceDocument":
					DesetupSyncInvoiceDocument(false, true);
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
			if(_invoiceDocument!=null)
			{
				toReturn.Add(_invoiceDocument);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();


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


				info.AddValue("_invoiceDocument", (!this.MarkedForDeletion?_invoiceDocument:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(InvoiceDocumentSendLogFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(InvoiceDocumentSendLogFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new InvoiceDocumentSendLogRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'InvoiceDocument' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInvoiceDocument()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InvoiceDocumentFields.InvoiceDocumentId, null, ComparisonOperator.Equal, this.InvoiceDocumentId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(PsychologicalServices.Data.EntityType.InvoiceDocumentSendLogEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(InvoiceDocumentSendLogEntityFactory));
		}
#if !CF
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


			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);


		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("InvoiceDocument", _invoiceDocument);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_invoiceDocument!=null)
			{
				_invoiceDocument.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_invoiceDocument = null;

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

			_fieldsCustomProperties.Add("InvoiceDocumentSendLogId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InvoiceDocumentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Recipients", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SentDate", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _invoiceDocument</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncInvoiceDocument(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _invoiceDocument, new PropertyChangedEventHandler( OnInvoiceDocumentPropertyChanged ), "InvoiceDocument", InvoiceDocumentSendLogEntity.Relations.InvoiceDocumentEntityUsingInvoiceDocumentId, true, signalRelatedEntity, "InvoiceDocumentSendLogs", resetFKFields, new int[] { (int)InvoiceDocumentSendLogFieldIndex.InvoiceDocumentId } );		
			_invoiceDocument = null;
		}

		/// <summary> setups the sync logic for member _invoiceDocument</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncInvoiceDocument(IEntity2 relatedEntity)
		{
			if(_invoiceDocument!=relatedEntity)
			{
				DesetupSyncInvoiceDocument(true, true);
				_invoiceDocument = (InvoiceDocumentEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _invoiceDocument, new PropertyChangedEventHandler( OnInvoiceDocumentPropertyChanged ), "InvoiceDocument", InvoiceDocumentSendLogEntity.Relations.InvoiceDocumentEntityUsingInvoiceDocumentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnInvoiceDocumentPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this InvoiceDocumentSendLogEntity</param>
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
		public  static InvoiceDocumentSendLogRelations Relations
		{
			get	{ return new InvoiceDocumentSendLogRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InvoiceDocument' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInvoiceDocument
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceDocumentEntityFactory))),
					(IEntityRelation)GetRelationsForField("InvoiceDocument")[0], (int)PsychologicalServices.Data.EntityType.InvoiceDocumentSendLogEntity, (int)PsychologicalServices.Data.EntityType.InvoiceDocumentEntity, 0, null, null, null, null, "InvoiceDocument", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return InvoiceDocumentSendLogEntity.CustomProperties;}
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
			get { return InvoiceDocumentSendLogEntity.FieldsCustomProperties;}
		}

		/// <summary> The InvoiceDocumentSendLogId property of the Entity InvoiceDocumentSendLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "InvoiceDocumentSendLogs"."InvoiceDocumentSendLogId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 InvoiceDocumentSendLogId
		{
			get { return (System.Int32)GetValue((int)InvoiceDocumentSendLogFieldIndex.InvoiceDocumentSendLogId, true); }
			set	{ SetValue((int)InvoiceDocumentSendLogFieldIndex.InvoiceDocumentSendLogId, value); }
		}

		/// <summary> The InvoiceDocumentId property of the Entity InvoiceDocumentSendLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "InvoiceDocumentSendLogs"."InvoiceDocumentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 InvoiceDocumentId
		{
			get { return (System.Int32)GetValue((int)InvoiceDocumentSendLogFieldIndex.InvoiceDocumentId, true); }
			set	{ SetValue((int)InvoiceDocumentSendLogFieldIndex.InvoiceDocumentId, value); }
		}

		/// <summary> The Recipients property of the Entity InvoiceDocumentSendLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "InvoiceDocumentSendLogs"."Recipients"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 4000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Recipients
		{
			get { return (System.String)GetValue((int)InvoiceDocumentSendLogFieldIndex.Recipients, true); }
			set	{ SetValue((int)InvoiceDocumentSendLogFieldIndex.Recipients, value); }
		}

		/// <summary> The SentDate property of the Entity InvoiceDocumentSendLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "InvoiceDocumentSendLogs"."SentDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTimeOffset, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTimeOffset SentDate
		{
			get { return (System.DateTimeOffset)GetValue((int)InvoiceDocumentSendLogFieldIndex.SentDate, true); }
			set	{ SetValue((int)InvoiceDocumentSendLogFieldIndex.SentDate, value); }
		}



		/// <summary> Gets / sets related entity of type 'InvoiceDocumentEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual InvoiceDocumentEntity InvoiceDocument
		{
			get
			{
				return _invoiceDocument;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncInvoiceDocument(value);
				}
				else
				{
					if(value==null)
					{
						if(_invoiceDocument != null)
						{
							_invoiceDocument.UnsetRelatedEntity(this, "InvoiceDocumentSendLogs");
						}
					}
					else
					{
						if(_invoiceDocument!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "InvoiceDocumentSendLogs");
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
			get { return (int)PsychologicalServices.Data.EntityType.InvoiceDocumentSendLogEntity; }
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
