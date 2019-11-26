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
	/// <summary>Entity class which represents the entity 'ConsultingAgreement'.<br/><br/></summary>
	[Serializable]
	public partial class ConsultingAgreementEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<InvoiceLineGroupConsultingAgreementEntity> _invoiceLineGroupConsultingAgreements;
		private CompanyEntity _company;
		private ReferralSourceEntity _billToReferralSource;
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
			/// <summary>Member name Company</summary>
			public static readonly string Company = "Company";
			/// <summary>Member name BillToReferralSource</summary>
			public static readonly string BillToReferralSource = "BillToReferralSource";
			/// <summary>Member name Psychologist</summary>
			public static readonly string Psychologist = "Psychologist";
			/// <summary>Member name InvoiceLineGroupConsultingAgreements</summary>
			public static readonly string InvoiceLineGroupConsultingAgreements = "InvoiceLineGroupConsultingAgreements";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ConsultingAgreementEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public ConsultingAgreementEntity():base("ConsultingAgreementEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ConsultingAgreementEntity(IEntityFields2 fields):base("ConsultingAgreementEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ConsultingAgreementEntity</param>
		public ConsultingAgreementEntity(IValidator validator):base("ConsultingAgreementEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="consultingAgreementId">PK value for ConsultingAgreement which data should be fetched into this ConsultingAgreement object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ConsultingAgreementEntity(System.Int32 consultingAgreementId):base("ConsultingAgreementEntity")
		{
			InitClassEmpty(null, null);
			this.ConsultingAgreementId = consultingAgreementId;
		}

		/// <summary> CTor</summary>
		/// <param name="consultingAgreementId">PK value for ConsultingAgreement which data should be fetched into this ConsultingAgreement object</param>
		/// <param name="validator">The custom validator object for this ConsultingAgreementEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ConsultingAgreementEntity(System.Int32 consultingAgreementId, IValidator validator):base("ConsultingAgreementEntity")
		{
			InitClassEmpty(validator, null);
			this.ConsultingAgreementId = consultingAgreementId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ConsultingAgreementEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_invoiceLineGroupConsultingAgreements = (EntityCollection<InvoiceLineGroupConsultingAgreementEntity>)info.GetValue("_invoiceLineGroupConsultingAgreements", typeof(EntityCollection<InvoiceLineGroupConsultingAgreementEntity>));
				_company = (CompanyEntity)info.GetValue("_company", typeof(CompanyEntity));
				if(_company!=null)
				{
					_company.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_billToReferralSource = (ReferralSourceEntity)info.GetValue("_billToReferralSource", typeof(ReferralSourceEntity));
				if(_billToReferralSource!=null)
				{
					_billToReferralSource.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_psychologist = (UserEntity)info.GetValue("_psychologist", typeof(UserEntity));
				if(_psychologist!=null)
				{
					_psychologist.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ConsultingAgreementFieldIndex)fieldIndex)
			{
				case ConsultingAgreementFieldIndex.CompanyId:
					DesetupSyncCompany(true, false);
					break;
				case ConsultingAgreementFieldIndex.PsychologistId:
					DesetupSyncPsychologist(true, false);
					break;
				case ConsultingAgreementFieldIndex.BillToReferralSourceId:
					DesetupSyncBillToReferralSource(true, false);
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
				case "Company":
					this.Company = (CompanyEntity)entity;
					break;
				case "BillToReferralSource":
					this.BillToReferralSource = (ReferralSourceEntity)entity;
					break;
				case "Psychologist":
					this.Psychologist = (UserEntity)entity;
					break;
				case "InvoiceLineGroupConsultingAgreements":
					this.InvoiceLineGroupConsultingAgreements.Add((InvoiceLineGroupConsultingAgreementEntity)entity);
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
				case "Company":
					toReturn.Add(Relations.CompanyEntityUsingCompanyId);
					break;
				case "BillToReferralSource":
					toReturn.Add(Relations.ReferralSourceEntityUsingBillToReferralSourceId);
					break;
				case "Psychologist":
					toReturn.Add(Relations.UserEntityUsingPsychologistId);
					break;
				case "InvoiceLineGroupConsultingAgreements":
					toReturn.Add(Relations.InvoiceLineGroupConsultingAgreementEntityUsingConsultingAgreementId);
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
				case "Company":
					SetupSyncCompany(relatedEntity);
					break;
				case "BillToReferralSource":
					SetupSyncBillToReferralSource(relatedEntity);
					break;
				case "Psychologist":
					SetupSyncPsychologist(relatedEntity);
					break;
				case "InvoiceLineGroupConsultingAgreements":
					this.InvoiceLineGroupConsultingAgreements.Add((InvoiceLineGroupConsultingAgreementEntity)relatedEntity);
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
				case "Company":
					DesetupSyncCompany(false, true);
					break;
				case "BillToReferralSource":
					DesetupSyncBillToReferralSource(false, true);
					break;
				case "Psychologist":
					DesetupSyncPsychologist(false, true);
					break;
				case "InvoiceLineGroupConsultingAgreements":
					this.PerformRelatedEntityRemoval(this.InvoiceLineGroupConsultingAgreements, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_company!=null)
			{
				toReturn.Add(_company);
			}
			if(_billToReferralSource!=null)
			{
				toReturn.Add(_billToReferralSource);
			}
			if(_psychologist!=null)
			{
				toReturn.Add(_psychologist);
			}
			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		protected override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.InvoiceLineGroupConsultingAgreements);
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
				info.AddValue("_invoiceLineGroupConsultingAgreements", ((_invoiceLineGroupConsultingAgreements!=null) && (_invoiceLineGroupConsultingAgreements.Count>0) && !this.MarkedForDeletion)?_invoiceLineGroupConsultingAgreements:null);
				info.AddValue("_company", (!this.MarkedForDeletion?_company:null));
				info.AddValue("_billToReferralSource", (!this.MarkedForDeletion?_billToReferralSource:null));
				info.AddValue("_psychologist", (!this.MarkedForDeletion?_psychologist:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new ConsultingAgreementRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'InvoiceLineGroupConsultingAgreement' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInvoiceLineGroupConsultingAgreements()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InvoiceLineGroupConsultingAgreementFields.ConsultingAgreementId, null, ComparisonOperator.Equal, this.ConsultingAgreementId));
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
		public virtual IRelationPredicateBucket GetRelationInfoBillToReferralSource()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceFields.ReferralSourceId, null, ComparisonOperator.Equal, this.BillToReferralSourceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPsychologist()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.PsychologistId));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(ConsultingAgreementEntityFactory));
		}

		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._invoiceLineGroupConsultingAgreements);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._invoiceLineGroupConsultingAgreements = (EntityCollection<InvoiceLineGroupConsultingAgreementEntity>) collectionsQueue.Dequeue();

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			bool toReturn = false;
			toReturn |=(this._invoiceLineGroupConsultingAgreements != null);
			return toReturn ? true : base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<InvoiceLineGroupConsultingAgreementEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceLineGroupConsultingAgreementEntityFactory))) : null);
		}

		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Company", _company);
			toReturn.Add("BillToReferralSource", _billToReferralSource);
			toReturn.Add("Psychologist", _psychologist);
			toReturn.Add("InvoiceLineGroupConsultingAgreements", _invoiceLineGroupConsultingAgreements);
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
			_fieldsCustomProperties.Add("ConsultingAgreementId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CompanyId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PsychologistId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("BillToReferralSourceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _company</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCompany(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _company, new PropertyChangedEventHandler(OnCompanyPropertyChanged), "Company", "ConsultingAgreements", PsychologicalServices.Data.RelationClasses.StaticConsultingAgreementRelations.CompanyEntityUsingCompanyIdStatic, true, new int[] { (int)ConsultingAgreementFieldIndex.CompanyId });
		}

		/// <summary> setups the sync logic for member _company</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCompany(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _company, new PropertyChangedEventHandler( OnCompanyPropertyChanged ), "Company", "ConsultingAgreements", PsychologicalServices.Data.RelationClasses.StaticConsultingAgreementRelations.CompanyEntityUsingCompanyIdStatic, true, new string[] {  }, new int[] { (int)ConsultingAgreementFieldIndex.CompanyId }); 
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

		/// <summary> Removes the sync logic for member _billToReferralSource</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBillToReferralSource(bool signalRelatedEntity, bool resetFKFields)
		{
			DesetupSync(signalRelatedEntity, resetFKFields, ref _billToReferralSource, new PropertyChangedEventHandler(OnBillToReferralSourcePropertyChanged), "BillToReferralSource", "ConsultingAgreements", PsychologicalServices.Data.RelationClasses.StaticConsultingAgreementRelations.ReferralSourceEntityUsingBillToReferralSourceIdStatic, true, new int[] { (int)ConsultingAgreementFieldIndex.BillToReferralSourceId });
		}

		/// <summary> setups the sync logic for member _billToReferralSource</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBillToReferralSource(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _billToReferralSource, new PropertyChangedEventHandler( OnBillToReferralSourcePropertyChanged ), "BillToReferralSource", "ConsultingAgreements", PsychologicalServices.Data.RelationClasses.StaticConsultingAgreementRelations.ReferralSourceEntityUsingBillToReferralSourceIdStatic, true, new string[] {  }, new int[] { (int)ConsultingAgreementFieldIndex.BillToReferralSourceId }); 
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBillToReferralSourcePropertyChanged( object sender, PropertyChangedEventArgs e )
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
			DesetupSync(signalRelatedEntity, resetFKFields, ref _psychologist, new PropertyChangedEventHandler(OnPsychologistPropertyChanged), "Psychologist", "ConsultingAgreements", PsychologicalServices.Data.RelationClasses.StaticConsultingAgreementRelations.UserEntityUsingPsychologistIdStatic, true, new int[] { (int)ConsultingAgreementFieldIndex.PsychologistId });
		}

		/// <summary> setups the sync logic for member _psychologist</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPsychologist(IEntityCore relatedEntity)
		{
			SetupSync(relatedEntity, ref _psychologist, new PropertyChangedEventHandler( OnPsychologistPropertyChanged ), "Psychologist", "ConsultingAgreements", PsychologicalServices.Data.RelationClasses.StaticConsultingAgreementRelations.UserEntityUsingPsychologistIdStatic, true, new string[] {  }, new int[] { (int)ConsultingAgreementFieldIndex.PsychologistId }); 
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
		/// <param name="validator">The validator object for this ConsultingAgreementEntity</param>
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
		public  static ConsultingAgreementRelations Relations
		{
			get	{ return new ConsultingAgreementRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InvoiceLineGroupConsultingAgreement' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInvoiceLineGroupConsultingAgreements
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<InvoiceLineGroupConsultingAgreementEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InvoiceLineGroupConsultingAgreementEntityFactory))), (IEntityRelation)GetRelationsForField("InvoiceLineGroupConsultingAgreements")[0], (int)PsychologicalServices.Data.EntityType.ConsultingAgreementEntity, (int)PsychologicalServices.Data.EntityType.InvoiceLineGroupConsultingAgreementEntity, 0, null, null, null, null, "InvoiceLineGroupConsultingAgreements", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Company' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCompany
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory))),	(IEntityRelation)GetRelationsForField("Company")[0], (int)PsychologicalServices.Data.EntityType.ConsultingAgreementEntity, (int)PsychologicalServices.Data.EntityType.CompanyEntity, 0, null, null, null, null, "Company", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReferralSource' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBillToReferralSource
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceEntityFactory))),	(IEntityRelation)GetRelationsForField("BillToReferralSource")[0], (int)PsychologicalServices.Data.EntityType.ConsultingAgreementEntity, (int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, 0, null, null, null, null, "BillToReferralSource", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPsychologist
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),	(IEntityRelation)GetRelationsForField("Psychologist")[0], (int)PsychologicalServices.Data.EntityType.ConsultingAgreementEntity, (int)PsychologicalServices.Data.EntityType.UserEntity, 0, null, null, null, null, "Psychologist", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The ConsultingAgreementId property of the Entity ConsultingAgreement<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ConsultingAgreements"."ConsultingAgreementId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ConsultingAgreementId
		{
			get { return (System.Int32)GetValue((int)ConsultingAgreementFieldIndex.ConsultingAgreementId, true); }
			set	{ SetValue((int)ConsultingAgreementFieldIndex.ConsultingAgreementId, value); }
		}

		/// <summary> The CompanyId property of the Entity ConsultingAgreement<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ConsultingAgreements"."CompanyId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CompanyId
		{
			get { return (System.Int32)GetValue((int)ConsultingAgreementFieldIndex.CompanyId, true); }
			set	{ SetValue((int)ConsultingAgreementFieldIndex.CompanyId, value); }
		}

		/// <summary> The PsychologistId property of the Entity ConsultingAgreement<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ConsultingAgreements"."PsychologistId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PsychologistId
		{
			get { return (System.Int32)GetValue((int)ConsultingAgreementFieldIndex.PsychologistId, true); }
			set	{ SetValue((int)ConsultingAgreementFieldIndex.PsychologistId, value); }
		}

		/// <summary> The BillToReferralSourceId property of the Entity ConsultingAgreement<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ConsultingAgreements"."BillToReferralSourceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 BillToReferralSourceId
		{
			get { return (System.Int32)GetValue((int)ConsultingAgreementFieldIndex.BillToReferralSourceId, true); }
			set	{ SetValue((int)ConsultingAgreementFieldIndex.BillToReferralSourceId, value); }
		}

		/// <summary> The IsActive property of the Entity ConsultingAgreement<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ConsultingAgreements"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ConsultingAgreementFieldIndex.IsActive, true); }
			set	{ SetValue((int)ConsultingAgreementFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'InvoiceLineGroupConsultingAgreementEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(InvoiceLineGroupConsultingAgreementEntity))]
		public virtual EntityCollection<InvoiceLineGroupConsultingAgreementEntity> InvoiceLineGroupConsultingAgreements
		{
			get { return GetOrCreateEntityCollection<InvoiceLineGroupConsultingAgreementEntity, InvoiceLineGroupConsultingAgreementEntityFactory>("ConsultingAgreement", true, false, ref _invoiceLineGroupConsultingAgreements);	}
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
					SetSingleRelatedEntityNavigator(value, "ConsultingAgreements", "Company", _company, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ReferralSourceEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual ReferralSourceEntity BillToReferralSource
		{
			get	{ return _billToReferralSource; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncBillToReferralSource(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "ConsultingAgreements", "BillToReferralSource", _billToReferralSource, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual UserEntity Psychologist
		{
			get	{ return _psychologist; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncPsychologist(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "ConsultingAgreements", "Psychologist", _psychologist, true); 
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
			get { return (int)PsychologicalServices.Data.EntityType.ConsultingAgreementEntity; }
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
