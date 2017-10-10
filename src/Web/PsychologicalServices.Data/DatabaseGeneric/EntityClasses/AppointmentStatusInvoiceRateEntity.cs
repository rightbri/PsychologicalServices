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
	/// Entity class which represents the entity 'AppointmentStatusInvoiceRate'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AppointmentStatusInvoiceRateEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private AppointmentSequenceEntity _appointmentSequence;
		private AppointmentStatusEntity _appointmentStatus;
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
			/// <summary>Member name AppointmentSequence</summary>
			public static readonly string AppointmentSequence = "AppointmentSequence";
			/// <summary>Member name AppointmentStatus</summary>
			public static readonly string AppointmentStatus = "AppointmentStatus";
			/// <summary>Member name Company</summary>
			public static readonly string Company = "Company";
			/// <summary>Member name ReferralSource</summary>
			public static readonly string ReferralSource = "ReferralSource";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AppointmentStatusInvoiceRateEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AppointmentStatusInvoiceRateEntity():base("AppointmentStatusInvoiceRateEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AppointmentStatusInvoiceRateEntity(IEntityFields2 fields):base("AppointmentStatusInvoiceRateEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AppointmentStatusInvoiceRateEntity</param>
		public AppointmentStatusInvoiceRateEntity(IValidator validator):base("AppointmentStatusInvoiceRateEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="companyId">PK value for AppointmentStatusInvoiceRate which data should be fetched into this AppointmentStatusInvoiceRate object</param>
		/// <param name="referralSourceId">PK value for AppointmentStatusInvoiceRate which data should be fetched into this AppointmentStatusInvoiceRate object</param>
		/// <param name="appointmentStatusId">PK value for AppointmentStatusInvoiceRate which data should be fetched into this AppointmentStatusInvoiceRate object</param>
		/// <param name="appointmentSequenceId">PK value for AppointmentStatusInvoiceRate which data should be fetched into this AppointmentStatusInvoiceRate object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AppointmentStatusInvoiceRateEntity(System.Int32 companyId, System.Int32 referralSourceId, System.Int32 appointmentStatusId, System.Int32 appointmentSequenceId):base("AppointmentStatusInvoiceRateEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CompanyId = companyId;
			this.ReferralSourceId = referralSourceId;
			this.AppointmentStatusId = appointmentStatusId;
			this.AppointmentSequenceId = appointmentSequenceId;
		}

		/// <summary> CTor</summary>
		/// <param name="companyId">PK value for AppointmentStatusInvoiceRate which data should be fetched into this AppointmentStatusInvoiceRate object</param>
		/// <param name="referralSourceId">PK value for AppointmentStatusInvoiceRate which data should be fetched into this AppointmentStatusInvoiceRate object</param>
		/// <param name="appointmentStatusId">PK value for AppointmentStatusInvoiceRate which data should be fetched into this AppointmentStatusInvoiceRate object</param>
		/// <param name="appointmentSequenceId">PK value for AppointmentStatusInvoiceRate which data should be fetched into this AppointmentStatusInvoiceRate object</param>
		/// <param name="validator">The custom validator object for this AppointmentStatusInvoiceRateEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AppointmentStatusInvoiceRateEntity(System.Int32 companyId, System.Int32 referralSourceId, System.Int32 appointmentStatusId, System.Int32 appointmentSequenceId, IValidator validator):base("AppointmentStatusInvoiceRateEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CompanyId = companyId;
			this.ReferralSourceId = referralSourceId;
			this.AppointmentStatusId = appointmentStatusId;
			this.AppointmentSequenceId = appointmentSequenceId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AppointmentStatusInvoiceRateEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_appointmentSequence = (AppointmentSequenceEntity)info.GetValue("_appointmentSequence", typeof(AppointmentSequenceEntity));
				if(_appointmentSequence!=null)
				{
					_appointmentSequence.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_appointmentStatus = (AppointmentStatusEntity)info.GetValue("_appointmentStatus", typeof(AppointmentStatusEntity));
				if(_appointmentStatus!=null)
				{
					_appointmentStatus.AfterSave+=new EventHandler(OnEntityAfterSave);
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

				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((AppointmentStatusInvoiceRateFieldIndex)fieldIndex)
			{
				case AppointmentStatusInvoiceRateFieldIndex.CompanyId:
					DesetupSyncCompany(true, false);
					break;
				case AppointmentStatusInvoiceRateFieldIndex.ReferralSourceId:
					DesetupSyncReferralSource(true, false);
					break;
				case AppointmentStatusInvoiceRateFieldIndex.AppointmentStatusId:
					DesetupSyncAppointmentStatus(true, false);
					break;
				case AppointmentStatusInvoiceRateFieldIndex.AppointmentSequenceId:
					DesetupSyncAppointmentSequence(true, false);
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
				case "AppointmentSequence":
					this.AppointmentSequence = (AppointmentSequenceEntity)entity;
					break;
				case "AppointmentStatus":
					this.AppointmentStatus = (AppointmentStatusEntity)entity;
					break;
				case "Company":
					this.Company = (CompanyEntity)entity;
					break;
				case "ReferralSource":
					this.ReferralSource = (ReferralSourceEntity)entity;
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
			return AppointmentStatusInvoiceRateEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AppointmentSequence":
					toReturn.Add(AppointmentStatusInvoiceRateEntity.Relations.AppointmentSequenceEntityUsingAppointmentSequenceId);
					break;
				case "AppointmentStatus":
					toReturn.Add(AppointmentStatusInvoiceRateEntity.Relations.AppointmentStatusEntityUsingAppointmentStatusId);
					break;
				case "Company":
					toReturn.Add(AppointmentStatusInvoiceRateEntity.Relations.CompanyEntityUsingCompanyId);
					break;
				case "ReferralSource":
					toReturn.Add(AppointmentStatusInvoiceRateEntity.Relations.ReferralSourceEntityUsingReferralSourceId);
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
				case "AppointmentSequence":
					SetupSyncAppointmentSequence(relatedEntity);
					break;
				case "AppointmentStatus":
					SetupSyncAppointmentStatus(relatedEntity);
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
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void UnsetRelatedEntity(IEntity2 relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "AppointmentSequence":
					DesetupSyncAppointmentSequence(false, true);
					break;
				case "AppointmentStatus":
					DesetupSyncAppointmentStatus(false, true);
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
			if(_appointmentSequence!=null)
			{
				toReturn.Add(_appointmentSequence);
			}
			if(_appointmentStatus!=null)
			{
				toReturn.Add(_appointmentStatus);
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


				info.AddValue("_appointmentSequence", (!this.MarkedForDeletion?_appointmentSequence:null));
				info.AddValue("_appointmentStatus", (!this.MarkedForDeletion?_appointmentStatus:null));
				info.AddValue("_company", (!this.MarkedForDeletion?_company:null));
				info.AddValue("_referralSource", (!this.MarkedForDeletion?_referralSource:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AppointmentStatusInvoiceRateFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AppointmentStatusInvoiceRateFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AppointmentStatusInvoiceRateRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AppointmentSequence' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAppointmentSequence()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AppointmentSequenceFields.AppointmentSequenceId, null, ComparisonOperator.Equal, this.AppointmentSequenceId));
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
		/// the related entity of type 'Company' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCompany()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CompanyFields.CompanyId, null, ComparisonOperator.Equal, this.CompanyId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ReferralSource' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReferralSource()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(PsychologicalServices.Data.EntityType.AppointmentStatusInvoiceRateEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AppointmentStatusInvoiceRateEntityFactory));
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
			toReturn.Add("AppointmentSequence", _appointmentSequence);
			toReturn.Add("AppointmentStatus", _appointmentStatus);
			toReturn.Add("Company", _company);
			toReturn.Add("ReferralSource", _referralSource);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_appointmentSequence!=null)
			{
				_appointmentSequence.ActiveContext = base.ActiveContext;
			}
			if(_appointmentStatus!=null)
			{
				_appointmentStatus.ActiveContext = base.ActiveContext;
			}
			if(_company!=null)
			{
				_company.ActiveContext = base.ActiveContext;
			}
			if(_referralSource!=null)
			{
				_referralSource.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_appointmentSequence = null;
			_appointmentStatus = null;
			_company = null;
			_referralSource = null;

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

			_fieldsCustomProperties.Add("CompanyId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReferralSourceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentStatusId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentSequenceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InvoiceRate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ApplyCompletionFee", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ApplyLargeFileFee", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ApplyTravelFee", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ApplyIssueInDisputeFees", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ApplyExtraReportFees", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _appointmentSequence</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAppointmentSequence(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _appointmentSequence, new PropertyChangedEventHandler( OnAppointmentSequencePropertyChanged ), "AppointmentSequence", AppointmentStatusInvoiceRateEntity.Relations.AppointmentSequenceEntityUsingAppointmentSequenceId, true, signalRelatedEntity, "AppointmentStatusInvoiceRates", resetFKFields, new int[] { (int)AppointmentStatusInvoiceRateFieldIndex.AppointmentSequenceId } );		
			_appointmentSequence = null;
		}

		/// <summary> setups the sync logic for member _appointmentSequence</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAppointmentSequence(IEntity2 relatedEntity)
		{
			if(_appointmentSequence!=relatedEntity)
			{
				DesetupSyncAppointmentSequence(true, true);
				_appointmentSequence = (AppointmentSequenceEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _appointmentSequence, new PropertyChangedEventHandler( OnAppointmentSequencePropertyChanged ), "AppointmentSequence", AppointmentStatusInvoiceRateEntity.Relations.AppointmentSequenceEntityUsingAppointmentSequenceId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAppointmentSequencePropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _appointmentStatus, new PropertyChangedEventHandler( OnAppointmentStatusPropertyChanged ), "AppointmentStatus", AppointmentStatusInvoiceRateEntity.Relations.AppointmentStatusEntityUsingAppointmentStatusId, true, signalRelatedEntity, "AppointmentStatusInvoiceRates", resetFKFields, new int[] { (int)AppointmentStatusInvoiceRateFieldIndex.AppointmentStatusId } );		
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
				base.PerformSetupSyncRelatedEntity( _appointmentStatus, new PropertyChangedEventHandler( OnAppointmentStatusPropertyChanged ), "AppointmentStatus", AppointmentStatusInvoiceRateEntity.Relations.AppointmentStatusEntityUsingAppointmentStatusId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _company</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCompany(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _company, new PropertyChangedEventHandler( OnCompanyPropertyChanged ), "Company", AppointmentStatusInvoiceRateEntity.Relations.CompanyEntityUsingCompanyId, true, signalRelatedEntity, "AppointmentStatusInvoiceRates", resetFKFields, new int[] { (int)AppointmentStatusInvoiceRateFieldIndex.CompanyId } );		
			_company = null;
		}

		/// <summary> setups the sync logic for member _company</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCompany(IEntity2 relatedEntity)
		{
			if(_company!=relatedEntity)
			{
				DesetupSyncCompany(true, true);
				_company = (CompanyEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _company, new PropertyChangedEventHandler( OnCompanyPropertyChanged ), "Company", AppointmentStatusInvoiceRateEntity.Relations.CompanyEntityUsingCompanyId, true, new string[] {  } );
			}
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
			base.PerformDesetupSyncRelatedEntity( _referralSource, new PropertyChangedEventHandler( OnReferralSourcePropertyChanged ), "ReferralSource", AppointmentStatusInvoiceRateEntity.Relations.ReferralSourceEntityUsingReferralSourceId, true, signalRelatedEntity, "AppointmentStatusInvoiceRates", resetFKFields, new int[] { (int)AppointmentStatusInvoiceRateFieldIndex.ReferralSourceId } );		
			_referralSource = null;
		}

		/// <summary> setups the sync logic for member _referralSource</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncReferralSource(IEntity2 relatedEntity)
		{
			if(_referralSource!=relatedEntity)
			{
				DesetupSyncReferralSource(true, true);
				_referralSource = (ReferralSourceEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _referralSource, new PropertyChangedEventHandler( OnReferralSourcePropertyChanged ), "ReferralSource", AppointmentStatusInvoiceRateEntity.Relations.ReferralSourceEntityUsingReferralSourceId, true, new string[] {  } );
			}
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
		/// <param name="validator">The validator object for this AppointmentStatusInvoiceRateEntity</param>
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
		public  static AppointmentStatusInvoiceRateRelations Relations
		{
			get	{ return new AppointmentStatusInvoiceRateRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AppointmentSequence' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAppointmentSequence
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentSequenceEntityFactory))),
					(IEntityRelation)GetRelationsForField("AppointmentSequence")[0], (int)PsychologicalServices.Data.EntityType.AppointmentStatusInvoiceRateEntity, (int)PsychologicalServices.Data.EntityType.AppointmentSequenceEntity, 0, null, null, null, null, "AppointmentSequence", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("AppointmentStatus")[0], (int)PsychologicalServices.Data.EntityType.AppointmentStatusInvoiceRateEntity, (int)PsychologicalServices.Data.EntityType.AppointmentStatusEntity, 0, null, null, null, null, "AppointmentStatus", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Company' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCompany
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory))),
					(IEntityRelation)GetRelationsForField("Company")[0], (int)PsychologicalServices.Data.EntityType.AppointmentStatusInvoiceRateEntity, (int)PsychologicalServices.Data.EntityType.CompanyEntity, 0, null, null, null, null, "Company", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReferralSource' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReferralSource
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceEntityFactory))),
					(IEntityRelation)GetRelationsForField("ReferralSource")[0], (int)PsychologicalServices.Data.EntityType.AppointmentStatusInvoiceRateEntity, (int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, 0, null, null, null, null, "ReferralSource", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AppointmentStatusInvoiceRateEntity.CustomProperties;}
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
			get { return AppointmentStatusInvoiceRateEntity.FieldsCustomProperties;}
		}

		/// <summary> The CompanyId property of the Entity AppointmentStatusInvoiceRate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AppointmentStatusInvoiceRates"."CompanyId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 CompanyId
		{
			get { return (System.Int32)GetValue((int)AppointmentStatusInvoiceRateFieldIndex.CompanyId, true); }
			set	{ SetValue((int)AppointmentStatusInvoiceRateFieldIndex.CompanyId, value); }
		}

		/// <summary> The ReferralSourceId property of the Entity AppointmentStatusInvoiceRate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AppointmentStatusInvoiceRates"."ReferralSourceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ReferralSourceId
		{
			get { return (System.Int32)GetValue((int)AppointmentStatusInvoiceRateFieldIndex.ReferralSourceId, true); }
			set	{ SetValue((int)AppointmentStatusInvoiceRateFieldIndex.ReferralSourceId, value); }
		}

		/// <summary> The AppointmentStatusId property of the Entity AppointmentStatusInvoiceRate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AppointmentStatusInvoiceRates"."AppointmentStatusId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 AppointmentStatusId
		{
			get { return (System.Int32)GetValue((int)AppointmentStatusInvoiceRateFieldIndex.AppointmentStatusId, true); }
			set	{ SetValue((int)AppointmentStatusInvoiceRateFieldIndex.AppointmentStatusId, value); }
		}

		/// <summary> The AppointmentSequenceId property of the Entity AppointmentStatusInvoiceRate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AppointmentStatusInvoiceRates"."AppointmentSequenceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 AppointmentSequenceId
		{
			get { return (System.Int32)GetValue((int)AppointmentStatusInvoiceRateFieldIndex.AppointmentSequenceId, true); }
			set	{ SetValue((int)AppointmentStatusInvoiceRateFieldIndex.AppointmentSequenceId, value); }
		}

		/// <summary> The InvoiceRate property of the Entity AppointmentStatusInvoiceRate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AppointmentStatusInvoiceRates"."InvoiceRate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 3, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal InvoiceRate
		{
			get { return (System.Decimal)GetValue((int)AppointmentStatusInvoiceRateFieldIndex.InvoiceRate, true); }
			set	{ SetValue((int)AppointmentStatusInvoiceRateFieldIndex.InvoiceRate, value); }
		}

		/// <summary> The ApplyCompletionFee property of the Entity AppointmentStatusInvoiceRate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AppointmentStatusInvoiceRates"."ApplyCompletionFee"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ApplyCompletionFee
		{
			get { return (System.Boolean)GetValue((int)AppointmentStatusInvoiceRateFieldIndex.ApplyCompletionFee, true); }
			set	{ SetValue((int)AppointmentStatusInvoiceRateFieldIndex.ApplyCompletionFee, value); }
		}

		/// <summary> The ApplyLargeFileFee property of the Entity AppointmentStatusInvoiceRate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AppointmentStatusInvoiceRates"."ApplyLargeFileFee"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ApplyLargeFileFee
		{
			get { return (System.Boolean)GetValue((int)AppointmentStatusInvoiceRateFieldIndex.ApplyLargeFileFee, true); }
			set	{ SetValue((int)AppointmentStatusInvoiceRateFieldIndex.ApplyLargeFileFee, value); }
		}

		/// <summary> The ApplyTravelFee property of the Entity AppointmentStatusInvoiceRate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AppointmentStatusInvoiceRates"."ApplyTravelFee"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ApplyTravelFee
		{
			get { return (System.Boolean)GetValue((int)AppointmentStatusInvoiceRateFieldIndex.ApplyTravelFee, true); }
			set	{ SetValue((int)AppointmentStatusInvoiceRateFieldIndex.ApplyTravelFee, value); }
		}

		/// <summary> The ApplyIssueInDisputeFees property of the Entity AppointmentStatusInvoiceRate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AppointmentStatusInvoiceRates"."ApplyIssueInDisputeFees"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ApplyIssueInDisputeFees
		{
			get { return (System.Boolean)GetValue((int)AppointmentStatusInvoiceRateFieldIndex.ApplyIssueInDisputeFees, true); }
			set	{ SetValue((int)AppointmentStatusInvoiceRateFieldIndex.ApplyIssueInDisputeFees, value); }
		}

		/// <summary> The ApplyExtraReportFees property of the Entity AppointmentStatusInvoiceRate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AppointmentStatusInvoiceRates"."ApplyExtraReportFees"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ApplyExtraReportFees
		{
			get { return (System.Boolean)GetValue((int)AppointmentStatusInvoiceRateFieldIndex.ApplyExtraReportFees, true); }
			set	{ SetValue((int)AppointmentStatusInvoiceRateFieldIndex.ApplyExtraReportFees, value); }
		}



		/// <summary> Gets / sets related entity of type 'AppointmentSequenceEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AppointmentSequenceEntity AppointmentSequence
		{
			get
			{
				return _appointmentSequence;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAppointmentSequence(value);
				}
				else
				{
					if(value==null)
					{
						if(_appointmentSequence != null)
						{
							_appointmentSequence.UnsetRelatedEntity(this, "AppointmentStatusInvoiceRates");
						}
					}
					else
					{
						if(_appointmentSequence!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AppointmentStatusInvoiceRates");
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
							_appointmentStatus.UnsetRelatedEntity(this, "AppointmentStatusInvoiceRates");
						}
					}
					else
					{
						if(_appointmentStatus!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AppointmentStatusInvoiceRates");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CompanyEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CompanyEntity Company
		{
			get
			{
				return _company;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCompany(value);
				}
				else
				{
					if(value==null)
					{
						if(_company != null)
						{
							_company.UnsetRelatedEntity(this, "AppointmentStatusInvoiceRates");
						}
					}
					else
					{
						if(_company!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AppointmentStatusInvoiceRates");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ReferralSourceEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ReferralSourceEntity ReferralSource
		{
			get
			{
				return _referralSource;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncReferralSource(value);
				}
				else
				{
					if(value==null)
					{
						if(_referralSource != null)
						{
							_referralSource.UnsetRelatedEntity(this, "AppointmentStatusInvoiceRates");
						}
					}
					else
					{
						if(_referralSource!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AppointmentStatusInvoiceRates");
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
			get { return (int)PsychologicalServices.Data.EntityType.AppointmentStatusInvoiceRateEntity; }
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
