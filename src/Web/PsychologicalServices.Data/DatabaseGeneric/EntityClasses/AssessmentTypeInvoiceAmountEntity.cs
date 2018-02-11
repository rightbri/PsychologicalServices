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
	
	/// <summary>Entity class which represents the entity 'AssessmentTypeInvoiceAmount'.<br/><br/></summary>
	[Serializable]
	public partial class AssessmentTypeInvoiceAmountEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private AssessmentTypeEntity _assessmentType;
		private CompanyEntity _company;
		private ReferralSourceEntity _referralSource;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AssessmentType</summary>
			public static readonly string AssessmentType = "AssessmentType";
			/// <summary>Member name Company</summary>
			public static readonly string Company = "Company";
			/// <summary>Member name ReferralSource</summary>
			public static readonly string ReferralSource = "ReferralSource";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AssessmentTypeInvoiceAmountEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public AssessmentTypeInvoiceAmountEntity():base("AssessmentTypeInvoiceAmountEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AssessmentTypeInvoiceAmountEntity(IEntityFields2 fields):base("AssessmentTypeInvoiceAmountEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AssessmentTypeInvoiceAmountEntity</param>
		public AssessmentTypeInvoiceAmountEntity(IValidator validator):base("AssessmentTypeInvoiceAmountEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="companyId">PK value for AssessmentTypeInvoiceAmount which data should be fetched into this AssessmentTypeInvoiceAmount object</param>
		/// <param name="referralSourceId">PK value for AssessmentTypeInvoiceAmount which data should be fetched into this AssessmentTypeInvoiceAmount object</param>
		/// <param name="assessmentTypeId">PK value for AssessmentTypeInvoiceAmount which data should be fetched into this AssessmentTypeInvoiceAmount object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AssessmentTypeInvoiceAmountEntity(System.Int32 companyId, System.Int32 referralSourceId, System.Int32 assessmentTypeId):base("AssessmentTypeInvoiceAmountEntity")
		{
			InitClassEmpty(null, null);
			this.CompanyId = companyId;
			this.ReferralSourceId = referralSourceId;
			this.AssessmentTypeId = assessmentTypeId;
		}

		/// <summary> CTor</summary>
		/// <param name="companyId">PK value for AssessmentTypeInvoiceAmount which data should be fetched into this AssessmentTypeInvoiceAmount object</param>
		/// <param name="referralSourceId">PK value for AssessmentTypeInvoiceAmount which data should be fetched into this AssessmentTypeInvoiceAmount object</param>
		/// <param name="assessmentTypeId">PK value for AssessmentTypeInvoiceAmount which data should be fetched into this AssessmentTypeInvoiceAmount object</param>
		/// <param name="validator">The custom validator object for this AssessmentTypeInvoiceAmountEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AssessmentTypeInvoiceAmountEntity(System.Int32 companyId, System.Int32 referralSourceId, System.Int32 assessmentTypeId, IValidator validator):base("AssessmentTypeInvoiceAmountEntity")
		{
			InitClassEmpty(validator, null);
			this.CompanyId = companyId;
			this.ReferralSourceId = referralSourceId;
			this.AssessmentTypeId = assessmentTypeId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AssessmentTypeInvoiceAmountEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_assessmentType = (AssessmentTypeEntity)info.GetValue("_assessmentType", typeof(AssessmentTypeEntity));
				if(_assessmentType!=null)
				{
					_assessmentType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_company = (CompanyEntity)info.GetValue("_company", typeof(CompanyEntity));
				if(_company!=null)
				{
					_company.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_referralSource = (ReferralSourceEntity)info.GetValue("_referralSource", typeof(ReferralSourceEntity));
				if(_referralSource!=null)
				{
					_referralSource.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AssessmentTypeInvoiceAmountFieldIndex)fieldIndex)
			{
				case AssessmentTypeInvoiceAmountFieldIndex.CompanyId:
					DesetupSyncCompany(true, false);
					break;
				case AssessmentTypeInvoiceAmountFieldIndex.ReferralSourceId:
					DesetupSyncReferralSource(true, false);
					break;
				case AssessmentTypeInvoiceAmountFieldIndex.AssessmentTypeId:
					DesetupSyncAssessmentType(true, false);
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
				case "AssessmentType":
					this.AssessmentType = (AssessmentTypeEntity)entity;
					break;
				case "Company":
					this.Company = (CompanyEntity)entity;
					break;
				case "ReferralSource":
					this.ReferralSource = (ReferralSourceEntity)entity;
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
				case "AssessmentType":
					toReturn.Add(Relations.AssessmentTypeEntityUsingAssessmentTypeId);
					break;
				case "Company":
					toReturn.Add(Relations.CompanyEntityUsingCompanyId);
					break;
				case "ReferralSource":
					toReturn.Add(Relations.ReferralSourceEntityUsingReferralSourceId);
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
				case "AssessmentType":
					SetupSyncAssessmentType(relatedEntity);
					break;
				case "Company":
					SetupSyncCompany(relatedEntity);
					break;
				case "ReferralSource":
					SetupSyncReferralSource(relatedEntity);
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
				case "AssessmentType":
					DesetupSyncAssessmentType(false, true);
					break;
				case "Company":
					DesetupSyncCompany(false, true);
					break;
				case "ReferralSource":
					DesetupSyncReferralSource(false, true);
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
			if(_assessmentType!=null)
			{
				toReturn.Add(_assessmentType);
			}
			if(_company!=null)
			{
				toReturn.Add(_company);
			}
			if(_referralSource!=null)
			{
				toReturn.Add(_referralSource);
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
				info.AddValue("_assessmentType", (!this.MarkedForDeletion?_assessmentType:null));
				info.AddValue("_company", (!this.MarkedForDeletion?_company:null));
				info.AddValue("_referralSource", (!this.MarkedForDeletion?_referralSource:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new AssessmentTypeInvoiceAmountRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'AssessmentType' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessmentType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentTypeFields.AssessmentTypeId, null, ComparisonOperator.Equal, this.AssessmentTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Company' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCompany()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CompanyFields.CompanyId, null, ComparisonOperator.Equal, this.CompanyId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'ReferralSource' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReferralSource()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(AssessmentTypeInvoiceAmountEntityFactory));
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
			toReturn.Add("AssessmentType", _assessmentType);
			toReturn.Add("Company", _company);
			toReturn.Add("ReferralSource", _referralSource);
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
			_fieldsCustomProperties.Add("CompanyId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ReferralSourceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AssessmentTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("SingleReportInvoiceAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ComboReportInvoiceAmount", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _assessmentType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAssessmentType(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _assessmentType, new PropertyChangedEventHandler(OnAssessmentTypePropertyChanged), "AssessmentType", "AssessmentTypeInvoiceAmounts", PsychologicalServices.Data.RelationClasses.StaticAssessmentTypeInvoiceAmountRelations.AssessmentTypeEntityUsingAssessmentTypeIdStatic, true, new int[] { (int)AssessmentTypeInvoiceAmountFieldIndex.AssessmentTypeId });
		}

		/// <summary> setups the sync logic for member _assessmentType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAssessmentType(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _assessmentType, new PropertyChangedEventHandler( OnAssessmentTypePropertyChanged ), "AssessmentType", "AssessmentTypeInvoiceAmounts", PsychologicalServices.Data.RelationClasses.StaticAssessmentTypeInvoiceAmountRelations.AssessmentTypeEntityUsingAssessmentTypeIdStatic, true, new string[] {  }, new int[] { (int)AssessmentTypeInvoiceAmountFieldIndex.AssessmentTypeId }); 
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAssessmentTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _company</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCompany(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _company, new PropertyChangedEventHandler(OnCompanyPropertyChanged), "Company", "AssessmentTypeInvoiceAmounts", PsychologicalServices.Data.RelationClasses.StaticAssessmentTypeInvoiceAmountRelations.CompanyEntityUsingCompanyIdStatic, true, new int[] { (int)AssessmentTypeInvoiceAmountFieldIndex.CompanyId });
		}

		/// <summary> setups the sync logic for member _company</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCompany(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _company, new PropertyChangedEventHandler( OnCompanyPropertyChanged ), "Company", "AssessmentTypeInvoiceAmounts", PsychologicalServices.Data.RelationClasses.StaticAssessmentTypeInvoiceAmountRelations.CompanyEntityUsingCompanyIdStatic, true, new string[] {  }, new int[] { (int)AssessmentTypeInvoiceAmountFieldIndex.CompanyId }); 
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

		/// <summary> Removes the sync logic for member _referralSource</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncReferralSource(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _referralSource, new PropertyChangedEventHandler(OnReferralSourcePropertyChanged), "ReferralSource", "AssessmentTypeInvoiceAmounts", PsychologicalServices.Data.RelationClasses.StaticAssessmentTypeInvoiceAmountRelations.ReferralSourceEntityUsingReferralSourceIdStatic, true, new int[] { (int)AssessmentTypeInvoiceAmountFieldIndex.ReferralSourceId });
		}

		/// <summary> setups the sync logic for member _referralSource</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncReferralSource(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _referralSource, new PropertyChangedEventHandler( OnReferralSourcePropertyChanged ), "ReferralSource", "AssessmentTypeInvoiceAmounts", PsychologicalServices.Data.RelationClasses.StaticAssessmentTypeInvoiceAmountRelations.ReferralSourceEntityUsingReferralSourceIdStatic, true, new string[] {  }, new int[] { (int)AssessmentTypeInvoiceAmountFieldIndex.ReferralSourceId }); 
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnReferralSourcePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AssessmentTypeInvoiceAmountEntity</param>
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
		public  static AssessmentTypeInvoiceAmountRelations Relations
		{
			get	{ return new AssessmentTypeInvoiceAmountRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AssessmentType' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssessmentType
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentTypeEntityFactory))),	(IEntityRelation)GetRelationsForField("AssessmentType")[0], (int)PsychologicalServices.Data.EntityType.AssessmentTypeInvoiceAmountEntity, (int)PsychologicalServices.Data.EntityType.AssessmentTypeEntity, 0, null, null, null, null, "AssessmentType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Company' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCompany
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory))),	(IEntityRelation)GetRelationsForField("Company")[0], (int)PsychologicalServices.Data.EntityType.AssessmentTypeInvoiceAmountEntity, (int)PsychologicalServices.Data.EntityType.CompanyEntity, 0, null, null, null, null, "Company", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReferralSource' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReferralSource
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceEntityFactory))),	(IEntityRelation)GetRelationsForField("ReferralSource")[0], (int)PsychologicalServices.Data.EntityType.AssessmentTypeInvoiceAmountEntity, (int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, 0, null, null, null, null, "ReferralSource", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The CompanyId property of the Entity AssessmentTypeInvoiceAmount<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AssessmentTypeInvoiceAmounts"."CompanyId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 CompanyId
		{
			get { return (System.Int32)GetValue((int)AssessmentTypeInvoiceAmountFieldIndex.CompanyId, true); }
			set	{ SetValue((int)AssessmentTypeInvoiceAmountFieldIndex.CompanyId, value); }
		}

		/// <summary> The ReferralSourceId property of the Entity AssessmentTypeInvoiceAmount<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AssessmentTypeInvoiceAmounts"."ReferralSourceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ReferralSourceId
		{
			get { return (System.Int32)GetValue((int)AssessmentTypeInvoiceAmountFieldIndex.ReferralSourceId, true); }
			set	{ SetValue((int)AssessmentTypeInvoiceAmountFieldIndex.ReferralSourceId, value); }
		}

		/// <summary> The AssessmentTypeId property of the Entity AssessmentTypeInvoiceAmount<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AssessmentTypeInvoiceAmounts"."AssessmentTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 AssessmentTypeId
		{
			get { return (System.Int32)GetValue((int)AssessmentTypeInvoiceAmountFieldIndex.AssessmentTypeId, true); }
			set	{ SetValue((int)AssessmentTypeInvoiceAmountFieldIndex.AssessmentTypeId, value); }
		}

		/// <summary> The SingleReportInvoiceAmount property of the Entity AssessmentTypeInvoiceAmount<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AssessmentTypeInvoiceAmounts"."SingleReportInvoiceAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 SingleReportInvoiceAmount
		{
			get { return (System.Int32)GetValue((int)AssessmentTypeInvoiceAmountFieldIndex.SingleReportInvoiceAmount, true); }
			set	{ SetValue((int)AssessmentTypeInvoiceAmountFieldIndex.SingleReportInvoiceAmount, value); }
		}

		/// <summary> The ComboReportInvoiceAmount property of the Entity AssessmentTypeInvoiceAmount<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AssessmentTypeInvoiceAmounts"."ComboReportInvoiceAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ComboReportInvoiceAmount
		{
			get { return (System.Int32)GetValue((int)AssessmentTypeInvoiceAmountFieldIndex.ComboReportInvoiceAmount, true); }
			set	{ SetValue((int)AssessmentTypeInvoiceAmountFieldIndex.ComboReportInvoiceAmount, value); }
		}

		/// <summary> Gets / sets related entity of type 'AssessmentTypeEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual AssessmentTypeEntity AssessmentType
		{
			get	{ return _assessmentType; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncAssessmentType(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "AssessmentTypeInvoiceAmounts", "AssessmentType", _assessmentType, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CompanyEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual CompanyEntity Company
		{
			get	{ return _company; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncCompany(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "AssessmentTypeInvoiceAmounts", "Company", _company, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ReferralSourceEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual ReferralSourceEntity ReferralSource
		{
			get	{ return _referralSource; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncReferralSource(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "AssessmentTypeInvoiceAmounts", "ReferralSource", _referralSource, true); 
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
			get { return (int)PsychologicalServices.Data.EntityType.AssessmentTypeInvoiceAmountEntity; }
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
