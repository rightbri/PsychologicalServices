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
	/// Entity class which represents the entity 'AssessmentType'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AssessmentTypeEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations

		private EntityCollection<AssessmentTypeReportTypeEntity> _assessmentTypeReportTypes;




		private EntityCollection<ReportTypeEntity> _reportTypeCollectionViaAssessmentTypeReportTypes;




		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{


			/// <summary>Member name AssessmentTypeReportTypes</summary>
			public static readonly string AssessmentTypeReportTypes = "AssessmentTypeReportTypes";




			/// <summary>Member name ReportTypeCollectionViaAssessmentTypeReportTypes</summary>
			public static readonly string ReportTypeCollectionViaAssessmentTypeReportTypes = "ReportTypeCollectionViaAssessmentTypeReportTypes";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AssessmentTypeEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AssessmentTypeEntity():base("AssessmentTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AssessmentTypeEntity(IEntityFields2 fields):base("AssessmentTypeEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AssessmentTypeEntity</param>
		public AssessmentTypeEntity(IValidator validator):base("AssessmentTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="assessmentTypeId">PK value for AssessmentType which data should be fetched into this AssessmentType object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AssessmentTypeEntity(System.Int32 assessmentTypeId):base("AssessmentTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.AssessmentTypeId = assessmentTypeId;
		}

		/// <summary> CTor</summary>
		/// <param name="assessmentTypeId">PK value for AssessmentType which data should be fetched into this AssessmentType object</param>
		/// <param name="validator">The custom validator object for this AssessmentTypeEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AssessmentTypeEntity(System.Int32 assessmentTypeId, IValidator validator):base("AssessmentTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.AssessmentTypeId = assessmentTypeId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AssessmentTypeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{

				_assessmentTypeReportTypes = (EntityCollection<AssessmentTypeReportTypeEntity>)info.GetValue("_assessmentTypeReportTypes", typeof(EntityCollection<AssessmentTypeReportTypeEntity>));




				_reportTypeCollectionViaAssessmentTypeReportTypes = (EntityCollection<ReportTypeEntity>)info.GetValue("_reportTypeCollectionViaAssessmentTypeReportTypes", typeof(EntityCollection<ReportTypeEntity>));




				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((AssessmentTypeFieldIndex)fieldIndex)
			{
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


				case "AssessmentTypeReportTypes":
					this.AssessmentTypeReportTypes.Add((AssessmentTypeReportTypeEntity)entity);
					break;




				case "ReportTypeCollectionViaAssessmentTypeReportTypes":
					this.ReportTypeCollectionViaAssessmentTypeReportTypes.IsReadOnly = false;
					this.ReportTypeCollectionViaAssessmentTypeReportTypes.Add((ReportTypeEntity)entity);
					this.ReportTypeCollectionViaAssessmentTypeReportTypes.IsReadOnly = true;
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
			return AssessmentTypeEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{


				case "AssessmentTypeReportTypes":
					toReturn.Add(AssessmentTypeEntity.Relations.AssessmentTypeReportTypeEntityUsingAssessmentTypeId);
					break;




				case "ReportTypeCollectionViaAssessmentTypeReportTypes":
					toReturn.Add(AssessmentTypeEntity.Relations.AssessmentTypeReportTypeEntityUsingAssessmentTypeId, "AssessmentTypeEntity__", "AssessmentTypeReportType_", JoinHint.None);
					toReturn.Add(AssessmentTypeReportTypeEntity.Relations.ReportTypeEntityUsingReportTypeId, "AssessmentTypeReportType_", string.Empty, JoinHint.None);
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


				case "AssessmentTypeReportTypes":
					this.AssessmentTypeReportTypes.Add((AssessmentTypeReportTypeEntity)relatedEntity);
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


				case "AssessmentTypeReportTypes":
					base.PerformRelatedEntityRemoval(this.AssessmentTypeReportTypes, relatedEntity, signalRelatedEntityManyToOne);
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


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();

			toReturn.Add(this.AssessmentTypeReportTypes);

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

				info.AddValue("_assessmentTypeReportTypes", ((_assessmentTypeReportTypes!=null) && (_assessmentTypeReportTypes.Count>0) && !this.MarkedForDeletion)?_assessmentTypeReportTypes:null);




				info.AddValue("_reportTypeCollectionViaAssessmentTypeReportTypes", ((_reportTypeCollectionViaAssessmentTypeReportTypes!=null) && (_reportTypeCollectionViaAssessmentTypeReportTypes.Count>0) && !this.MarkedForDeletion)?_reportTypeCollectionViaAssessmentTypeReportTypes:null);




			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AssessmentTypeFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AssessmentTypeFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AssessmentTypeRelations().GetAllRelations();
		}
		


		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AssessmentTypeReportType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessmentTypeReportTypes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentTypeReportTypeFields.AssessmentTypeId, null, ComparisonOperator.Equal, this.AssessmentTypeId));
			return bucket;
		}





		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ReportType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReportTypeCollectionViaAssessmentTypeReportTypes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ReportTypeCollectionViaAssessmentTypeReportTypes"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentTypeFields.AssessmentTypeId, null, ComparisonOperator.Equal, this.AssessmentTypeId, "AssessmentTypeEntity__"));
			return bucket;
		}




	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(PsychologicalServices.Data.EntityType.AssessmentTypeEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AssessmentTypeEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);

			collectionsQueue.Enqueue(this._assessmentTypeReportTypes);




			collectionsQueue.Enqueue(this._reportTypeCollectionViaAssessmentTypeReportTypes);


		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);

			this._assessmentTypeReportTypes = (EntityCollection<AssessmentTypeReportTypeEntity>) collectionsQueue.Dequeue();




			this._reportTypeCollectionViaAssessmentTypeReportTypes = (EntityCollection<ReportTypeEntity>) collectionsQueue.Dequeue();


		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{

			if (this._assessmentTypeReportTypes != null)
			{
				return true;
			}




			if (this._reportTypeCollectionViaAssessmentTypeReportTypes != null)
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

			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AssessmentTypeReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentTypeReportTypeEntityFactory))) : null);




			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory))) : null);


		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();


			toReturn.Add("AssessmentTypeReportTypes", _assessmentTypeReportTypes);




			toReturn.Add("ReportTypeCollectionViaAssessmentTypeReportTypes", _reportTypeCollectionViaAssessmentTypeReportTypes);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{

			if(_assessmentTypeReportTypes!=null)
			{
				_assessmentTypeReportTypes.ActiveContext = base.ActiveContext;
			}




			if(_reportTypeCollectionViaAssessmentTypeReportTypes!=null)
			{
				_reportTypeCollectionViaAssessmentTypeReportTypes.ActiveContext = base.ActiveContext;
			}




		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{


			_assessmentTypeReportTypes = null;




			_reportTypeCollectionViaAssessmentTypeReportTypes = null;




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

			_fieldsCustomProperties.Add("AssessmentTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Duration", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AssessmentTypeEntity</param>
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
		public  static AssessmentTypeRelations Relations
		{
			get	{ return new AssessmentTypeRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AssessmentTypeReportType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssessmentTypeReportTypes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AssessmentTypeReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentTypeReportTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("AssessmentTypeReportTypes")[0], (int)PsychologicalServices.Data.EntityType.AssessmentTypeEntity, (int)PsychologicalServices.Data.EntityType.AssessmentTypeReportTypeEntity, 0, null, null, null, null, "AssessmentTypeReportTypes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}





		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReportType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReportTypeCollectionViaAssessmentTypeReportTypes
		{
			get
			{
				IEntityRelation intermediateRelation = AssessmentTypeEntity.Relations.AssessmentTypeReportTypeEntityUsingAssessmentTypeId;
				intermediateRelation.SetAliases(string.Empty, "AssessmentTypeReportType_");
				return new PrefetchPathElement2(new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory))), intermediateRelation,
					(int)PsychologicalServices.Data.EntityType.AssessmentTypeEntity, (int)PsychologicalServices.Data.EntityType.ReportTypeEntity, 0, null, null, GetRelationsForField("ReportTypeCollectionViaAssessmentTypeReportTypes"), null, "ReportTypeCollectionViaAssessmentTypeReportTypes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}





		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AssessmentTypeEntity.CustomProperties;}
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
			get { return AssessmentTypeEntity.FieldsCustomProperties;}
		}

		/// <summary> The AssessmentTypeId property of the Entity AssessmentType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AssessmentTypes"."AssessmentTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 AssessmentTypeId
		{
			get { return (System.Int32)GetValue((int)AssessmentTypeFieldIndex.AssessmentTypeId, true); }
			set	{ SetValue((int)AssessmentTypeFieldIndex.AssessmentTypeId, value); }
		}

		/// <summary> The Name property of the Entity AssessmentType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AssessmentTypes"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)AssessmentTypeFieldIndex.Name, true); }
			set	{ SetValue((int)AssessmentTypeFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity AssessmentType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AssessmentTypes"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)AssessmentTypeFieldIndex.Description, true); }
			set	{ SetValue((int)AssessmentTypeFieldIndex.Description, value); }
		}

		/// <summary> The Duration property of the Entity AssessmentType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AssessmentTypes"."Duration"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Duration
		{
			get { return (System.Int32)GetValue((int)AssessmentTypeFieldIndex.Duration, true); }
			set	{ SetValue((int)AssessmentTypeFieldIndex.Duration, value); }
		}

		/// <summary> The IsActive property of the Entity AssessmentType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AssessmentTypes"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)AssessmentTypeFieldIndex.IsActive, true); }
			set	{ SetValue((int)AssessmentTypeFieldIndex.IsActive, value); }
		}


		/// <summary> Gets the EntityCollection with the related entities of type 'AssessmentTypeReportTypeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AssessmentTypeReportTypeEntity))]
		public virtual EntityCollection<AssessmentTypeReportTypeEntity> AssessmentTypeReportTypes
		{
			get
			{
				if(_assessmentTypeReportTypes==null)
				{
					_assessmentTypeReportTypes = new EntityCollection<AssessmentTypeReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentTypeReportTypeEntityFactory)));
					_assessmentTypeReportTypes.SetContainingEntityInfo(this, "AssessmentType");
				}
				return _assessmentTypeReportTypes;
			}
		}





		/// <summary> Gets the EntityCollection with the related entities of type 'ReportTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ReportTypeEntity))]
		public virtual EntityCollection<ReportTypeEntity> ReportTypeCollectionViaAssessmentTypeReportTypes
		{
			get
			{
				if(_reportTypeCollectionViaAssessmentTypeReportTypes==null)
				{
					_reportTypeCollectionViaAssessmentTypeReportTypes = new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory)));
					_reportTypeCollectionViaAssessmentTypeReportTypes.IsReadOnly=true;
				}
				return _reportTypeCollectionViaAssessmentTypeReportTypes;
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
			get { return (int)PsychologicalServices.Data.EntityType.AssessmentTypeEntity; }
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
