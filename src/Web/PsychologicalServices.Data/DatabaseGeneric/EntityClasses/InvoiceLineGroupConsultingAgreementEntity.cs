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
	/// <summary>Entity class which represents the entity 'InvoiceLineGroupConsultingAgreement'.<br/><br/></summary>
	[Serializable]
	public partial class InvoiceLineGroupConsultingAgreementEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private ConsultingAgreementEntity _consultingAgreement;
		private InvoiceLineGroupEntity _invoiceLineGroup;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name ConsultingAgreement</summary>
			public static readonly string ConsultingAgreement = "ConsultingAgreement";
			/// <summary>Member name InvoiceLineGroup</summary>
			public static readonly string InvoiceLineGroup = "InvoiceLineGroup";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static InvoiceLineGroupConsultingAgreementEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public InvoiceLineGroupConsultingAgreementEntity():base("InvoiceLineGroupConsultingAgreementEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public InvoiceLineGroupConsultingAgreementEntity(IEntityFields2 fields):base("InvoiceLineGroupConsultingAgreementEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this InvoiceLineGroupConsultingAgreementEntity</param>
		public InvoiceLineGroupConsultingAgreementEntity(IValidator validator):base("InvoiceLineGroupConsultingAgreementEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="invoiceLineGroupId">PK value for InvoiceLineGroupConsultingAgreement which data should be fetched into this InvoiceLineGroupConsultingAgreement object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public InvoiceLineGroupConsultingAgreementEntity(System.Int32 invoiceLineGroupId):base("InvoiceLineGroupConsultingAgreementEntity")
		{
			InitClassEmpty(null, null);
			this.InvoiceLineGroupId = invoiceLineGroupId;
		}

		/// <summary> CTor</summary>
		/// <param name="invoiceLineGroupId">PK value for InvoiceLineGroupConsultingAgreement which data should be fetched into this InvoiceLineGroupConsultingAgreement object</param>
		/// <param name="validator">The custom validator object for this InvoiceLineGroupConsultingAgreementEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public InvoiceLineGroupConsultingAgreementEntity(System.Int32 invoiceLineGroupId, IValidator validator):base("InvoiceLineGroupConsultingAgreementEntity")
		{
			InitClassEmpty(validator, null);
			this.InvoiceLineGroupId = invoiceLineGroupId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected InvoiceLineGroupConsultingAgreementEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_consultingAgreement = (ConsultingAgreementEntity)info.GetValue("_consultingAgreement", typeof(ConsultingAgreementEntity));
				if(_consultingAgreement!=null)
				{
					_consultingAgreement.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_invoiceLineGroup = (InvoiceLineGroupEntity)info.GetValue("_invoiceLineGroup", typeof(InvoiceLineGroupEntity));
				if(_invoiceLineGroup!=null)
				{
					_invoiceLineGroup.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((InvoiceLineGroupConsultingAgreementFieldIndex)fieldIndex)
			{
				case InvoiceLineGroupConsultingAgreementFieldIndex.InvoiceLineGroupId:
					DesetupSyncInvoiceLineGroup(true, false);
					break;
				case InvoiceLineGroupConsultingAgreementFieldIndex.ConsultingAgreementId:
					DesetupSyncConsultingAgreement(true, false);
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
				case "ConsultingAgreement":
					this.ConsultingAgreement = (ConsultingAgreementEntity)entity;
					break;
				case "InvoiceLineGroup":
					this.InvoiceLineGroup = (InvoiceLineGroupEntity)entity;
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
				case "ConsultingAgreement":
					toReturn.Add(Relations.ConsultingAgreementEntityUsingConsultingAgreementId);
					break;
				case "InvoiceLineGroup":
					toReturn.Add(Relations.InvoiceLineGroupEntityUsingInvoiceLineGroupId);
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
				case "ConsultingAgreement":
					SetupSyncConsultingAgreement(relatedEntity);
					break;
				case "InvoiceLineGroup":
					SetupSyncInvoiceLineGroup(relatedEntity);
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
				case "ConsultingAgreement":
					DesetupSyncConsultingAgreement(false, true);
					break;
				case "InvoiceLineGroup":
					DesetupSyncInvoiceLineGroup(false, true);
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
			if(_consultingAgreement!=null)
			{
				toReturn.Add(_consultingAgreement);
			}
			if(_invoiceLineGroup!=null)
			{
				toReturn.Add(_invoiceLineGroup);
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
				info.AddValue("_consultingAgreement", (!this.MarkedForDeletion?_consultingAgreement:null));
				info.AddValue("_invoiceLineGroup", (!this.MarkedForDeletion?_invoiceLineGroup:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new InvoiceLineGroupConsultingAgreementRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'ConsultingAgreement' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoConsultingAgreement()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ConsultingAgreementFields.ConsultingAgreementId, null, ComparisonOperator.Equal, this.ConsultingAgreementId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'InvoiceLineGroup' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInvoiceLineGroup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InvoiceLineGroupFields.InvoiceLineGroupId, null, ComparisonOperator.Equal, this.InvoiceLineGroupId));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(InvoiceLineGroupConsultingAgreementEntityFactory));
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
			toReturn.Add("ConsultingAgreement", _consultingAgreement);
			toReturn.Add("InvoiceLineGroup", _invoiceLineGroup);
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
			_fieldsCustomProperties.Add("InvoiceLineGroupId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ConsultingAgreementId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _consultingAgreement</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncConsultingAgreement(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _consultingAgreement, new PropertyChangedEventHandler(OnConsultingAgreementPropertyChanged), "ConsultingAgreement", "InvoiceLineGroupConsultingAgreements", PsychologicalServices.Data.RelationClasses.StaticInvoiceLineGroupConsultingAgreementRelations.ConsultingAgreementEntityUsingConsultingAgreementIdStatic, true, new int[] { (int)InvoiceLineGroupConsultingAgreementFieldIndex.ConsultingAgreementId });
		}

		/// <summary> setups the sync logic for member _consultingAgreement</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncConsultingAgreement(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _consultingAgreement, new PropertyChangedEventHandler( OnConsultingAgreementPropertyChanged ), "ConsultingAgreement", "InvoiceLineGroupConsultingAgreements", PsychologicalServices.Data.RelationClasses.StaticInvoiceLineGroupConsultingAgreementRelations.ConsultingAgreementEntityUsingConsultingAgreementIdStatic, true, new string[] {  }, new int[] { (int)InvoiceLineGroupConsultingAgreementFieldIndex.ConsultingAgreementId }); 
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnConsultingAgreementPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _invoiceLineGroup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncInvoiceLineGroup(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, false, ref _invoiceLineGroup, new PropertyChangedEventHandler(OnInvoiceLineGroupPropertyChanged), "InvoiceLineGroup", "InvoiceLineGroupConsultingAgreement", PsychologicalServices.Data.RelationClasses.StaticInvoiceLineGroupConsultingAgreementRelations.InvoiceLineGroupEntityUsingInvoiceLineGroupIdStatic, true, new int[] { (int)InvoiceLineGroupConsultingAgreementFieldIndex.InvoiceLineGroupId });
		}
		
		/// <summary> setups the sync logic for member _invoiceLineGroup</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncInvoiceLineGroup(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _invoiceLineGroup, new PropertyChangedEventHandler( OnInvoiceLineGroupPropertyChanged ), "InvoiceLineGroup", "InvoiceLineGroupConsultingAgreement", PsychologicalServices.Data.RelationClasses.StaticInvoiceLineGroupConsultingAgreementRelations.InvoiceLineGroupEntityUsingInvoiceLineGroupIdStatic, true, new string[] {  }, new int[] { (int)InvoiceLineGroupConsultingAgreementFieldIndex.InvoiceLineGroupId }); 
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnInvoiceLineGroupPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this InvoiceLineGroupConsultingAgreementEntity</param>
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
		public  static InvoiceLineGroupConsultingAgreementRelations Relations
		{
			get	{ return new InvoiceLineGroupConsultingAgreementRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ConsultingAgreement' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathConsultingAgreement
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ConsultingAgreementEntityFactory))),	(IEntityRelation)GetRelationsForField("ConsultingAgreement")[0], (int)PsychologicalServices.Data.EntityType.InvoiceLineGroupConsultingAgreementEntity, (int)PsychologicalServices.Data.EntityType.ConsultingAgreementEntity, 0, null, null, null, null, "ConsultingAgreement", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InvoiceLineGroup' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInvoiceLineGroup
		{
			get { return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceLineGroupEntityFactory))), (IEntityRelation)GetRelationsForField("InvoiceLineGroup")[0], (int)PsychologicalServices.Data.EntityType.InvoiceLineGroupConsultingAgreementEntity, (int)PsychologicalServices.Data.EntityType.InvoiceLineGroupEntity, 0, null, null, null, null, "InvoiceLineGroup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);	}
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

		/// <summary> The InvoiceLineGroupId property of the Entity InvoiceLineGroupConsultingAgreement<br/><br/></summary>
		/// <remarks>Mapped on  table field: "InvoiceLineGroupConsultingAgreements"."InvoiceLineGroupId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 InvoiceLineGroupId
		{
			get { return (System.Int32)GetValue((int)InvoiceLineGroupConsultingAgreementFieldIndex.InvoiceLineGroupId, true); }
			set	{ SetValue((int)InvoiceLineGroupConsultingAgreementFieldIndex.InvoiceLineGroupId, value); }
		}

		/// <summary> The ConsultingAgreementId property of the Entity InvoiceLineGroupConsultingAgreement<br/><br/></summary>
		/// <remarks>Mapped on  table field: "InvoiceLineGroupConsultingAgreements"."ConsultingAgreementId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ConsultingAgreementId
		{
			get { return (System.Int32)GetValue((int)InvoiceLineGroupConsultingAgreementFieldIndex.ConsultingAgreementId, true); }
			set	{ SetValue((int)InvoiceLineGroupConsultingAgreementFieldIndex.ConsultingAgreementId, value); }
		}

		/// <summary> Gets / sets related entity of type 'ConsultingAgreementEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual ConsultingAgreementEntity ConsultingAgreement
		{
			get	{ return _consultingAgreement; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncConsultingAgreement(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "InvoiceLineGroupConsultingAgreements", "ConsultingAgreement", _consultingAgreement, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'InvoiceLineGroupEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned.<br/><br/>
		/// </summary>
		[Browsable(true)]
		public virtual InvoiceLineGroupEntity InvoiceLineGroup
		{
			get { return _invoiceLineGroup; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncInvoiceLineGroup(value);
					CallSetRelatedEntityDuringDeserialization(value, "InvoiceLineGroupConsultingAgreement");
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_invoiceLineGroup !=null);
						DesetupSyncInvoiceLineGroup(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("InvoiceLineGroup");
						}
					}
					else
					{
						if(_invoiceLineGroup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "InvoiceLineGroupConsultingAgreement");
							SetupSyncInvoiceLineGroup(value);
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
		protected override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)PsychologicalServices.Data.EntityType.InvoiceLineGroupConsultingAgreementEntity; }
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
