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
	/// <summary>Entity class which represents the entity 'ReferralTypeIssueInDispute'.<br/><br/></summary>
	[Serializable]
	public partial class ReferralTypeIssueInDisputeEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private IssueInDisputeEntity _issueInDispute;
		private ReferralTypeEntity _referralType;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name IssueInDispute</summary>
			public static readonly string IssueInDispute = "IssueInDispute";
			/// <summary>Member name ReferralType</summary>
			public static readonly string ReferralType = "ReferralType";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ReferralTypeIssueInDisputeEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public ReferralTypeIssueInDisputeEntity():base("ReferralTypeIssueInDisputeEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ReferralTypeIssueInDisputeEntity(IEntityFields2 fields):base("ReferralTypeIssueInDisputeEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ReferralTypeIssueInDisputeEntity</param>
		public ReferralTypeIssueInDisputeEntity(IValidator validator):base("ReferralTypeIssueInDisputeEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="referralTypeId">PK value for ReferralTypeIssueInDispute which data should be fetched into this ReferralTypeIssueInDispute object</param>
		/// <param name="issueInDisputeId">PK value for ReferralTypeIssueInDispute which data should be fetched into this ReferralTypeIssueInDispute object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ReferralTypeIssueInDisputeEntity(System.Int32 referralTypeId, System.Int32 issueInDisputeId):base("ReferralTypeIssueInDisputeEntity")
		{
			InitClassEmpty(null, null);
			this.ReferralTypeId = referralTypeId;
			this.IssueInDisputeId = issueInDisputeId;
		}

		/// <summary> CTor</summary>
		/// <param name="referralTypeId">PK value for ReferralTypeIssueInDispute which data should be fetched into this ReferralTypeIssueInDispute object</param>
		/// <param name="issueInDisputeId">PK value for ReferralTypeIssueInDispute which data should be fetched into this ReferralTypeIssueInDispute object</param>
		/// <param name="validator">The custom validator object for this ReferralTypeIssueInDisputeEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ReferralTypeIssueInDisputeEntity(System.Int32 referralTypeId, System.Int32 issueInDisputeId, IValidator validator):base("ReferralTypeIssueInDisputeEntity")
		{
			InitClassEmpty(validator, null);
			this.ReferralTypeId = referralTypeId;
			this.IssueInDisputeId = issueInDisputeId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ReferralTypeIssueInDisputeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_issueInDispute = (IssueInDisputeEntity)info.GetValue("_issueInDispute", typeof(IssueInDisputeEntity));
				if(_issueInDispute!=null)
				{
					_issueInDispute.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_referralType = (ReferralTypeEntity)info.GetValue("_referralType", typeof(ReferralTypeEntity));
				if(_referralType!=null)
				{
					_referralType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ReferralTypeIssueInDisputeFieldIndex)fieldIndex)
			{
				case ReferralTypeIssueInDisputeFieldIndex.ReferralTypeId:
					DesetupSyncReferralType(true, false);
					break;
				case ReferralTypeIssueInDisputeFieldIndex.IssueInDisputeId:
					DesetupSyncIssueInDispute(true, false);
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
				case "IssueInDispute":
					this.IssueInDispute = (IssueInDisputeEntity)entity;
					break;
				case "ReferralType":
					this.ReferralType = (ReferralTypeEntity)entity;
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
				case "IssueInDispute":
					toReturn.Add(Relations.IssueInDisputeEntityUsingIssueInDisputeId);
					break;
				case "ReferralType":
					toReturn.Add(Relations.ReferralTypeEntityUsingReferralTypeId);
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
				case "IssueInDispute":
					SetupSyncIssueInDispute(relatedEntity);
					break;
				case "ReferralType":
					SetupSyncReferralType(relatedEntity);
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
				case "IssueInDispute":
					DesetupSyncIssueInDispute(false, true);
					break;
				case "ReferralType":
					DesetupSyncReferralType(false, true);
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
			if(_issueInDispute!=null)
			{
				toReturn.Add(_issueInDispute);
			}
			if(_referralType!=null)
			{
				toReturn.Add(_referralType);
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
				info.AddValue("_issueInDispute", (!this.MarkedForDeletion?_issueInDispute:null));
				info.AddValue("_referralType", (!this.MarkedForDeletion?_referralType:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new ReferralTypeIssueInDisputeRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'IssueInDispute' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIssueInDispute()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IssueInDisputeFields.IssueInDisputeId, null, ComparisonOperator.Equal, this.IssueInDisputeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'ReferralType' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReferralType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralTypeFields.ReferralTypeId, null, ComparisonOperator.Equal, this.ReferralTypeId));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(ReferralTypeIssueInDisputeEntityFactory));
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
			toReturn.Add("IssueInDispute", _issueInDispute);
			toReturn.Add("ReferralType", _referralType);
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
			_fieldsCustomProperties.Add("ReferralTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IssueInDisputeId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _issueInDispute</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncIssueInDispute(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _issueInDispute, new PropertyChangedEventHandler(OnIssueInDisputePropertyChanged), "IssueInDispute", "ReferralTypeIssuesInDispute", PsychologicalServices.Data.RelationClasses.StaticReferralTypeIssueInDisputeRelations.IssueInDisputeEntityUsingIssueInDisputeIdStatic, true, new int[] { (int)ReferralTypeIssueInDisputeFieldIndex.IssueInDisputeId });
		}

		/// <summary> setups the sync logic for member _issueInDispute</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncIssueInDispute(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _issueInDispute, new PropertyChangedEventHandler( OnIssueInDisputePropertyChanged ), "IssueInDispute", "ReferralTypeIssuesInDispute", PsychologicalServices.Data.RelationClasses.StaticReferralTypeIssueInDisputeRelations.IssueInDisputeEntityUsingIssueInDisputeIdStatic, true, new string[] {  }, new int[] { (int)ReferralTypeIssueInDisputeFieldIndex.IssueInDisputeId }); 
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnIssueInDisputePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _referralType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncReferralType(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _referralType, new PropertyChangedEventHandler(OnReferralTypePropertyChanged), "ReferralType", "ReferralTypeIssuesInDispute", PsychologicalServices.Data.RelationClasses.StaticReferralTypeIssueInDisputeRelations.ReferralTypeEntityUsingReferralTypeIdStatic, true, new int[] { (int)ReferralTypeIssueInDisputeFieldIndex.ReferralTypeId });
		}

		/// <summary> setups the sync logic for member _referralType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncReferralType(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _referralType, new PropertyChangedEventHandler( OnReferralTypePropertyChanged ), "ReferralType", "ReferralTypeIssuesInDispute", PsychologicalServices.Data.RelationClasses.StaticReferralTypeIssueInDisputeRelations.ReferralTypeEntityUsingReferralTypeIdStatic, true, new string[] {  }, new int[] { (int)ReferralTypeIssueInDisputeFieldIndex.ReferralTypeId }); 
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnReferralTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ReferralTypeIssueInDisputeEntity</param>
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
		public  static ReferralTypeIssueInDisputeRelations Relations
		{
			get	{ return new ReferralTypeIssueInDisputeRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IssueInDispute' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIssueInDispute
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(IssueInDisputeEntityFactory))),	(IEntityRelation)GetRelationsForField("IssueInDispute")[0], (int)PsychologicalServices.Data.EntityType.ReferralTypeIssueInDisputeEntity, (int)PsychologicalServices.Data.EntityType.IssueInDisputeEntity, 0, null, null, null, null, "IssueInDispute", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReferralType' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReferralType
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ReferralTypeEntityFactory))),	(IEntityRelation)GetRelationsForField("ReferralType")[0], (int)PsychologicalServices.Data.EntityType.ReferralTypeIssueInDisputeEntity, (int)PsychologicalServices.Data.EntityType.ReferralTypeEntity, 0, null, null, null, null, "ReferralType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The ReferralTypeId property of the Entity ReferralTypeIssueInDispute<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ReferralTypeIssuesInDispute"."ReferralTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ReferralTypeId
		{
			get { return (System.Int32)GetValue((int)ReferralTypeIssueInDisputeFieldIndex.ReferralTypeId, true); }
			set	{ SetValue((int)ReferralTypeIssueInDisputeFieldIndex.ReferralTypeId, value); }
		}

		/// <summary> The IssueInDisputeId property of the Entity ReferralTypeIssueInDispute<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ReferralTypeIssuesInDispute"."IssueInDisputeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 IssueInDisputeId
		{
			get { return (System.Int32)GetValue((int)ReferralTypeIssueInDisputeFieldIndex.IssueInDisputeId, true); }
			set	{ SetValue((int)ReferralTypeIssueInDisputeFieldIndex.IssueInDisputeId, value); }
		}

		/// <summary> Gets / sets related entity of type 'IssueInDisputeEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual IssueInDisputeEntity IssueInDispute
		{
			get	{ return _issueInDispute; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncIssueInDispute(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "ReferralTypeIssuesInDispute", "IssueInDispute", _issueInDispute, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ReferralTypeEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual ReferralTypeEntity ReferralType
		{
			get	{ return _referralType; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncReferralType(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "ReferralTypeIssuesInDispute", "ReferralType", _referralType, true); 
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
			get { return (int)PsychologicalServices.Data.EntityType.ReferralTypeIssueInDisputeEntity; }
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
