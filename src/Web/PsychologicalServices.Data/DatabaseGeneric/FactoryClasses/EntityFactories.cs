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
using System.Collections.Generic;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.HelperClasses;
using PsychologicalServices.Data.RelationClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PsychologicalServices.Data.FactoryClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>general base class for the generated factories</summary>
	[Serializable]
	public partial class EntityFactoryBase2 : EntityFactoryCore2
	{
		private string _entityName;
		private PsychologicalServices.Data.EntityType _typeOfEntity;
		
		/// <summary>CTor</summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="typeOfEntity">The type of entity.</param>
		public EntityFactoryBase2(string entityName, PsychologicalServices.Data.EntityType typeOfEntity)
		{
			_entityName = entityName;
			_typeOfEntity = typeOfEntity;
		}
		
		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields2 object for the entity to create.</summary>
		/// <returns>Empty IEntityFields2 object.</returns>
		public override IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(_typeOfEntity);
		}
		
		/// <summary>Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value</summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity instance</returns>
		public override IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue)
		{
			return GeneralEntityFactory.Create((PsychologicalServices.Data.EntityType)entityTypeValue);
		}

		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <param name="objectAlias">The object alias to use for the elements in the relations.</param>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public override IRelationCollection CreateHierarchyRelations(string objectAlias) 
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetHierarchyRelations(_entityName, objectAlias);
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public override IEntityFactory2 GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity) 
		{
			IEntityFactory2 toReturn = (IEntityFactory2)InheritanceInfoProviderSingleton.GetInstance().GetEntityFactory(_entityName, fieldValues, entityFieldStartIndexesPerEntity);
			if(toReturn == null)
			{
				toReturn = this;
			}
			return toReturn;
		}
		
		/// <summary>Gets a predicateexpression which filters on the entity with type belonging to this factory.</summary>
		/// <param name="negate">Flag to produce a NOT filter, (true), or a normal filter (false). </param>
		/// <param name="objectAlias">The object alias to use for the predicate(s).</param>
		/// <returns>ready to use predicateexpression, or an empty predicate expression if the belonging entity isn't a hierarchical type.</returns>
		public override IPredicateExpression GetEntityTypeFilter(bool negate, string objectAlias) 
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetEntityTypeFilter(this.ForEntityName, objectAlias, negate);
		}
				
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public override string ForEntityName 
		{ 
			get { return _entityName; }
		}
	}
	
	/// <summary>Factory to create new, empty AddressEntity objects.</summary>
	[Serializable]
	public partial class AddressEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AddressEntityFactory() : base("AddressEntity", PsychologicalServices.Data.EntityType.AddressEntity) { }

		/// <summary>Creates a new, empty AddressEntity object.</summary>
		/// <returns>A new, empty AddressEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AddressEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAddress
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AddressEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AddressEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAddressUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AddressEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AddressTypeEntity objects.</summary>
	[Serializable]
	public partial class AddressTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AddressTypeEntityFactory() : base("AddressTypeEntity", PsychologicalServices.Data.EntityType.AddressTypeEntity) { }

		/// <summary>Creates a new, empty AddressTypeEntity object.</summary>
		/// <returns>A new, empty AddressTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AddressTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAddressType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AddressTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AddressTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAddressTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AddressTypeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AppointmentEntity objects.</summary>
	[Serializable]
	public partial class AppointmentEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AppointmentEntityFactory() : base("AppointmentEntity", PsychologicalServices.Data.EntityType.AppointmentEntity) { }

		/// <summary>Creates a new, empty AppointmentEntity object.</summary>
		/// <returns>A new, empty AppointmentEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AppointmentEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAppointment
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AppointmentEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AppointmentEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAppointmentUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AppointmentEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AppointmentAttributeEntity objects.</summary>
	[Serializable]
	public partial class AppointmentAttributeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AppointmentAttributeEntityFactory() : base("AppointmentAttributeEntity", PsychologicalServices.Data.EntityType.AppointmentAttributeEntity) { }

		/// <summary>Creates a new, empty AppointmentAttributeEntity object.</summary>
		/// <returns>A new, empty AppointmentAttributeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AppointmentAttributeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAppointmentAttribute
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AppointmentAttributeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AppointmentAttributeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAppointmentAttributeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AppointmentAttributeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AppointmentSequenceEntity objects.</summary>
	[Serializable]
	public partial class AppointmentSequenceEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AppointmentSequenceEntityFactory() : base("AppointmentSequenceEntity", PsychologicalServices.Data.EntityType.AppointmentSequenceEntity) { }

		/// <summary>Creates a new, empty AppointmentSequenceEntity object.</summary>
		/// <returns>A new, empty AppointmentSequenceEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AppointmentSequenceEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAppointmentSequence
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AppointmentSequenceEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AppointmentSequenceEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAppointmentSequenceUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AppointmentSequenceEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AppointmentStatusEntity objects.</summary>
	[Serializable]
	public partial class AppointmentStatusEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AppointmentStatusEntityFactory() : base("AppointmentStatusEntity", PsychologicalServices.Data.EntityType.AppointmentStatusEntity) { }

		/// <summary>Creates a new, empty AppointmentStatusEntity object.</summary>
		/// <returns>A new, empty AppointmentStatusEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AppointmentStatusEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAppointmentStatus
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AppointmentStatusEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AppointmentStatusEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAppointmentStatusUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AppointmentStatusEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AssessmentEntity objects.</summary>
	[Serializable]
	public partial class AssessmentEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AssessmentEntityFactory() : base("AssessmentEntity", PsychologicalServices.Data.EntityType.AssessmentEntity) { }

		/// <summary>Creates a new, empty AssessmentEntity object.</summary>
		/// <returns>A new, empty AssessmentEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AssessmentEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessment
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AssessmentEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AssessmentEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AssessmentEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AssessmentAttributeEntity objects.</summary>
	[Serializable]
	public partial class AssessmentAttributeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AssessmentAttributeEntityFactory() : base("AssessmentAttributeEntity", PsychologicalServices.Data.EntityType.AssessmentAttributeEntity) { }

		/// <summary>Creates a new, empty AssessmentAttributeEntity object.</summary>
		/// <returns>A new, empty AssessmentAttributeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AssessmentAttributeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentAttribute
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AssessmentAttributeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AssessmentAttributeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentAttributeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AssessmentAttributeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AssessmentClaimEntity objects.</summary>
	[Serializable]
	public partial class AssessmentClaimEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AssessmentClaimEntityFactory() : base("AssessmentClaimEntity", PsychologicalServices.Data.EntityType.AssessmentClaimEntity) { }

		/// <summary>Creates a new, empty AssessmentClaimEntity object.</summary>
		/// <returns>A new, empty AssessmentClaimEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AssessmentClaimEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentClaim
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AssessmentClaimEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AssessmentClaimEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentClaimUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AssessmentClaimEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AssessmentColorEntity objects.</summary>
	[Serializable]
	public partial class AssessmentColorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AssessmentColorEntityFactory() : base("AssessmentColorEntity", PsychologicalServices.Data.EntityType.AssessmentColorEntity) { }

		/// <summary>Creates a new, empty AssessmentColorEntity object.</summary>
		/// <returns>A new, empty AssessmentColorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AssessmentColorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentColor
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AssessmentColorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AssessmentColorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentColorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AssessmentColorEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AssessmentMedRehabEntity objects.</summary>
	[Serializable]
	public partial class AssessmentMedRehabEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AssessmentMedRehabEntityFactory() : base("AssessmentMedRehabEntity", PsychologicalServices.Data.EntityType.AssessmentMedRehabEntity) { }

		/// <summary>Creates a new, empty AssessmentMedRehabEntity object.</summary>
		/// <returns>A new, empty AssessmentMedRehabEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AssessmentMedRehabEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentMedRehab
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AssessmentMedRehabEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AssessmentMedRehabEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentMedRehabUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AssessmentMedRehabEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AssessmentNoteEntity objects.</summary>
	[Serializable]
	public partial class AssessmentNoteEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AssessmentNoteEntityFactory() : base("AssessmentNoteEntity", PsychologicalServices.Data.EntityType.AssessmentNoteEntity) { }

		/// <summary>Creates a new, empty AssessmentNoteEntity object.</summary>
		/// <returns>A new, empty AssessmentNoteEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AssessmentNoteEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentNote
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AssessmentNoteEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AssessmentNoteEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentNoteUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AssessmentNoteEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AssessmentReportEntity objects.</summary>
	[Serializable]
	public partial class AssessmentReportEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AssessmentReportEntityFactory() : base("AssessmentReportEntity", PsychologicalServices.Data.EntityType.AssessmentReportEntity) { }

		/// <summary>Creates a new, empty AssessmentReportEntity object.</summary>
		/// <returns>A new, empty AssessmentReportEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AssessmentReportEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentReport
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AssessmentReportEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AssessmentReportEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentReportUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AssessmentReportEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AssessmentReportIssueInDisputeEntity objects.</summary>
	[Serializable]
	public partial class AssessmentReportIssueInDisputeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AssessmentReportIssueInDisputeEntityFactory() : base("AssessmentReportIssueInDisputeEntity", PsychologicalServices.Data.EntityType.AssessmentReportIssueInDisputeEntity) { }

		/// <summary>Creates a new, empty AssessmentReportIssueInDisputeEntity object.</summary>
		/// <returns>A new, empty AssessmentReportIssueInDisputeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AssessmentReportIssueInDisputeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentReportIssueInDispute
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AssessmentReportIssueInDisputeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AssessmentReportIssueInDisputeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentReportIssueInDisputeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AssessmentReportIssueInDisputeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AssessmentTypeEntity objects.</summary>
	[Serializable]
	public partial class AssessmentTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AssessmentTypeEntityFactory() : base("AssessmentTypeEntity", PsychologicalServices.Data.EntityType.AssessmentTypeEntity) { }

		/// <summary>Creates a new, empty AssessmentTypeEntity object.</summary>
		/// <returns>A new, empty AssessmentTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AssessmentTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AssessmentTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AssessmentTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AssessmentTypeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AssessmentTypeAttributeTypeEntity objects.</summary>
	[Serializable]
	public partial class AssessmentTypeAttributeTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AssessmentTypeAttributeTypeEntityFactory() : base("AssessmentTypeAttributeTypeEntity", PsychologicalServices.Data.EntityType.AssessmentTypeAttributeTypeEntity) { }

		/// <summary>Creates a new, empty AssessmentTypeAttributeTypeEntity object.</summary>
		/// <returns>A new, empty AssessmentTypeAttributeTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AssessmentTypeAttributeTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentTypeAttributeType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AssessmentTypeAttributeTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AssessmentTypeAttributeTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentTypeAttributeTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AssessmentTypeAttributeTypeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AssessmentTypeReportTypeEntity objects.</summary>
	[Serializable]
	public partial class AssessmentTypeReportTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AssessmentTypeReportTypeEntityFactory() : base("AssessmentTypeReportTypeEntity", PsychologicalServices.Data.EntityType.AssessmentTypeReportTypeEntity) { }

		/// <summary>Creates a new, empty AssessmentTypeReportTypeEntity object.</summary>
		/// <returns>A new, empty AssessmentTypeReportTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AssessmentTypeReportTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentTypeReportType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AssessmentTypeReportTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AssessmentTypeReportTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentTypeReportTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AssessmentTypeReportTypeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AttributeEntity objects.</summary>
	[Serializable]
	public partial class AttributeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AttributeEntityFactory() : base("AttributeEntity", PsychologicalServices.Data.EntityType.AttributeEntity) { }

		/// <summary>Creates a new, empty AttributeEntity object.</summary>
		/// <returns>A new, empty AttributeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AttributeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAttribute
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AttributeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AttributeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAttributeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AttributeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty AttributeTypeEntity objects.</summary>
	[Serializable]
	public partial class AttributeTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AttributeTypeEntityFactory() : base("AttributeTypeEntity", PsychologicalServices.Data.EntityType.AttributeTypeEntity) { }

		/// <summary>Creates a new, empty AttributeTypeEntity object.</summary>
		/// <returns>A new, empty AttributeTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AttributeTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAttributeType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AttributeTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AttributeTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAttributeTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AttributeTypeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CalendarNoteEntity objects.</summary>
	[Serializable]
	public partial class CalendarNoteEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CalendarNoteEntityFactory() : base("CalendarNoteEntity", PsychologicalServices.Data.EntityType.CalendarNoteEntity) { }

		/// <summary>Creates a new, empty CalendarNoteEntity object.</summary>
		/// <returns>A new, empty CalendarNoteEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CalendarNoteEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCalendarNote
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CalendarNoteEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CalendarNoteEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCalendarNoteUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<CalendarNoteEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CityEntity objects.</summary>
	[Serializable]
	public partial class CityEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CityEntityFactory() : base("CityEntity", PsychologicalServices.Data.EntityType.CityEntity) { }

		/// <summary>Creates a new, empty CityEntity object.</summary>
		/// <returns>A new, empty CityEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CityEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCity
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CityEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CityEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCityUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<CityEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ClaimEntity objects.</summary>
	[Serializable]
	public partial class ClaimEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ClaimEntityFactory() : base("ClaimEntity", PsychologicalServices.Data.EntityType.ClaimEntity) { }

		/// <summary>Creates a new, empty ClaimEntity object.</summary>
		/// <returns>A new, empty ClaimEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ClaimEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewClaim
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ClaimEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ClaimEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewClaimUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<ClaimEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ClaimantEntity objects.</summary>
	[Serializable]
	public partial class ClaimantEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ClaimantEntityFactory() : base("ClaimantEntity", PsychologicalServices.Data.EntityType.ClaimantEntity) { }

		/// <summary>Creates a new, empty ClaimantEntity object.</summary>
		/// <returns>A new, empty ClaimantEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ClaimantEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewClaimant
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ClaimantEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ClaimantEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewClaimantUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<ClaimantEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ColorEntity objects.</summary>
	[Serializable]
	public partial class ColorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ColorEntityFactory() : base("ColorEntity", PsychologicalServices.Data.EntityType.ColorEntity) { }

		/// <summary>Creates a new, empty ColorEntity object.</summary>
		/// <returns>A new, empty ColorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ColorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewColor
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ColorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ColorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewColorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<ColorEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CompanyEntity objects.</summary>
	[Serializable]
	public partial class CompanyEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CompanyEntityFactory() : base("CompanyEntity", PsychologicalServices.Data.EntityType.CompanyEntity) { }

		/// <summary>Creates a new, empty CompanyEntity object.</summary>
		/// <returns>A new, empty CompanyEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CompanyEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCompany
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CompanyEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CompanyEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCompanyUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<CompanyEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CompanyAttributeEntity objects.</summary>
	[Serializable]
	public partial class CompanyAttributeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CompanyAttributeEntityFactory() : base("CompanyAttributeEntity", PsychologicalServices.Data.EntityType.CompanyAttributeEntity) { }

		/// <summary>Creates a new, empty CompanyAttributeEntity object.</summary>
		/// <returns>A new, empty CompanyAttributeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CompanyAttributeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCompanyAttribute
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CompanyAttributeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CompanyAttributeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCompanyAttributeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<CompanyAttributeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty InvoiceEntity objects.</summary>
	[Serializable]
	public partial class InvoiceEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public InvoiceEntityFactory() : base("InvoiceEntity", PsychologicalServices.Data.EntityType.InvoiceEntity) { }

		/// <summary>Creates a new, empty InvoiceEntity object.</summary>
		/// <returns>A new, empty InvoiceEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new InvoiceEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoice
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new InvoiceEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new InvoiceEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<InvoiceEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty InvoiceAppointmentEntity objects.</summary>
	[Serializable]
	public partial class InvoiceAppointmentEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public InvoiceAppointmentEntityFactory() : base("InvoiceAppointmentEntity", PsychologicalServices.Data.EntityType.InvoiceAppointmentEntity) { }

		/// <summary>Creates a new, empty InvoiceAppointmentEntity object.</summary>
		/// <returns>A new, empty InvoiceAppointmentEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new InvoiceAppointmentEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceAppointment
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new InvoiceAppointmentEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new InvoiceAppointmentEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceAppointmentUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<InvoiceAppointmentEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty InvoiceDocumentEntity objects.</summary>
	[Serializable]
	public partial class InvoiceDocumentEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public InvoiceDocumentEntityFactory() : base("InvoiceDocumentEntity", PsychologicalServices.Data.EntityType.InvoiceDocumentEntity) { }

		/// <summary>Creates a new, empty InvoiceDocumentEntity object.</summary>
		/// <returns>A new, empty InvoiceDocumentEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new InvoiceDocumentEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceDocument
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new InvoiceDocumentEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new InvoiceDocumentEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceDocumentUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<InvoiceDocumentEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty InvoiceLineEntity objects.</summary>
	[Serializable]
	public partial class InvoiceLineEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public InvoiceLineEntityFactory() : base("InvoiceLineEntity", PsychologicalServices.Data.EntityType.InvoiceLineEntity) { }

		/// <summary>Creates a new, empty InvoiceLineEntity object.</summary>
		/// <returns>A new, empty InvoiceLineEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new InvoiceLineEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceLine
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new InvoiceLineEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new InvoiceLineEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceLineUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<InvoiceLineEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty InvoiceStatusEntity objects.</summary>
	[Serializable]
	public partial class InvoiceStatusEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public InvoiceStatusEntityFactory() : base("InvoiceStatusEntity", PsychologicalServices.Data.EntityType.InvoiceStatusEntity) { }

		/// <summary>Creates a new, empty InvoiceStatusEntity object.</summary>
		/// <returns>A new, empty InvoiceStatusEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new InvoiceStatusEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceStatus
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new InvoiceStatusEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new InvoiceStatusEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceStatusUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<InvoiceStatusEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty InvoiceStatusChangeEntity objects.</summary>
	[Serializable]
	public partial class InvoiceStatusChangeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public InvoiceStatusChangeEntityFactory() : base("InvoiceStatusChangeEntity", PsychologicalServices.Data.EntityType.InvoiceStatusChangeEntity) { }

		/// <summary>Creates a new, empty InvoiceStatusChangeEntity object.</summary>
		/// <returns>A new, empty InvoiceStatusChangeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new InvoiceStatusChangeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceStatusChange
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new InvoiceStatusChangeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new InvoiceStatusChangeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceStatusChangeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<InvoiceStatusChangeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty InvoiceStatusPathsEntity objects.</summary>
	[Serializable]
	public partial class InvoiceStatusPathsEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public InvoiceStatusPathsEntityFactory() : base("InvoiceStatusPathsEntity", PsychologicalServices.Data.EntityType.InvoiceStatusPathsEntity) { }

		/// <summary>Creates a new, empty InvoiceStatusPathsEntity object.</summary>
		/// <returns>A new, empty InvoiceStatusPathsEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new InvoiceStatusPathsEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceStatusPaths
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new InvoiceStatusPathsEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new InvoiceStatusPathsEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceStatusPathsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<InvoiceStatusPathsEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty InvoiceTypeEntity objects.</summary>
	[Serializable]
	public partial class InvoiceTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public InvoiceTypeEntityFactory() : base("InvoiceTypeEntity", PsychologicalServices.Data.EntityType.InvoiceTypeEntity) { }

		/// <summary>Creates a new, empty InvoiceTypeEntity object.</summary>
		/// <returns>A new, empty InvoiceTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new InvoiceTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new InvoiceTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new InvoiceTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<InvoiceTypeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty IssueInDisputeEntity objects.</summary>
	[Serializable]
	public partial class IssueInDisputeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public IssueInDisputeEntityFactory() : base("IssueInDisputeEntity", PsychologicalServices.Data.EntityType.IssueInDisputeEntity) { }

		/// <summary>Creates a new, empty IssueInDisputeEntity object.</summary>
		/// <returns>A new, empty IssueInDisputeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new IssueInDisputeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewIssueInDispute
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new IssueInDisputeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new IssueInDisputeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewIssueInDisputeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<IssueInDisputeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty NoteEntity objects.</summary>
	[Serializable]
	public partial class NoteEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public NoteEntityFactory() : base("NoteEntity", PsychologicalServices.Data.EntityType.NoteEntity) { }

		/// <summary>Creates a new, empty NoteEntity object.</summary>
		/// <returns>A new, empty NoteEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new NoteEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewNote
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new NoteEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new NoteEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewNoteUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<NoteEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ReferralSourceEntity objects.</summary>
	[Serializable]
	public partial class ReferralSourceEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ReferralSourceEntityFactory() : base("ReferralSourceEntity", PsychologicalServices.Data.EntityType.ReferralSourceEntity) { }

		/// <summary>Creates a new, empty ReferralSourceEntity object.</summary>
		/// <returns>A new, empty ReferralSourceEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ReferralSourceEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReferralSource
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ReferralSourceEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ReferralSourceEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReferralSourceUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<ReferralSourceEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ReferralSourceAppointmentStatusSettingEntity objects.</summary>
	[Serializable]
	public partial class ReferralSourceAppointmentStatusSettingEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ReferralSourceAppointmentStatusSettingEntityFactory() : base("ReferralSourceAppointmentStatusSettingEntity", PsychologicalServices.Data.EntityType.ReferralSourceAppointmentStatusSettingEntity) { }

		/// <summary>Creates a new, empty ReferralSourceAppointmentStatusSettingEntity object.</summary>
		/// <returns>A new, empty ReferralSourceAppointmentStatusSettingEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ReferralSourceAppointmentStatusSettingEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReferralSourceAppointmentStatusSetting
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ReferralSourceAppointmentStatusSettingEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ReferralSourceAppointmentStatusSettingEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReferralSourceAppointmentStatusSettingUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<ReferralSourceAppointmentStatusSettingEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ReferralSourceTypeEntity objects.</summary>
	[Serializable]
	public partial class ReferralSourceTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ReferralSourceTypeEntityFactory() : base("ReferralSourceTypeEntity", PsychologicalServices.Data.EntityType.ReferralSourceTypeEntity) { }

		/// <summary>Creates a new, empty ReferralSourceTypeEntity object.</summary>
		/// <returns>A new, empty ReferralSourceTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ReferralSourceTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReferralSourceType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ReferralSourceTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ReferralSourceTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReferralSourceTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<ReferralSourceTypeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ReferralTypeEntity objects.</summary>
	[Serializable]
	public partial class ReferralTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ReferralTypeEntityFactory() : base("ReferralTypeEntity", PsychologicalServices.Data.EntityType.ReferralTypeEntity) { }

		/// <summary>Creates a new, empty ReferralTypeEntity object.</summary>
		/// <returns>A new, empty ReferralTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ReferralTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReferralType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ReferralTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ReferralTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReferralTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<ReferralTypeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ReferralTypeIssueInDisputeEntity objects.</summary>
	[Serializable]
	public partial class ReferralTypeIssueInDisputeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ReferralTypeIssueInDisputeEntityFactory() : base("ReferralTypeIssueInDisputeEntity", PsychologicalServices.Data.EntityType.ReferralTypeIssueInDisputeEntity) { }

		/// <summary>Creates a new, empty ReferralTypeIssueInDisputeEntity object.</summary>
		/// <returns>A new, empty ReferralTypeIssueInDisputeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ReferralTypeIssueInDisputeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReferralTypeIssueInDispute
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ReferralTypeIssueInDisputeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ReferralTypeIssueInDisputeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReferralTypeIssueInDisputeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<ReferralTypeIssueInDisputeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ReportStatusEntity objects.</summary>
	[Serializable]
	public partial class ReportStatusEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ReportStatusEntityFactory() : base("ReportStatusEntity", PsychologicalServices.Data.EntityType.ReportStatusEntity) { }

		/// <summary>Creates a new, empty ReportStatusEntity object.</summary>
		/// <returns>A new, empty ReportStatusEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ReportStatusEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReportStatus
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ReportStatusEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ReportStatusEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReportStatusUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<ReportStatusEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ReportTypeEntity objects.</summary>
	[Serializable]
	public partial class ReportTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ReportTypeEntityFactory() : base("ReportTypeEntity", PsychologicalServices.Data.EntityType.ReportTypeEntity) { }

		/// <summary>Creates a new, empty ReportTypeEntity object.</summary>
		/// <returns>A new, empty ReportTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ReportTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReportType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ReportTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ReportTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReportTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<ReportTypeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ReportTypeInvoiceAmountEntity objects.</summary>
	[Serializable]
	public partial class ReportTypeInvoiceAmountEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ReportTypeInvoiceAmountEntityFactory() : base("ReportTypeInvoiceAmountEntity", PsychologicalServices.Data.EntityType.ReportTypeInvoiceAmountEntity) { }

		/// <summary>Creates a new, empty ReportTypeInvoiceAmountEntity object.</summary>
		/// <returns>A new, empty ReportTypeInvoiceAmountEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ReportTypeInvoiceAmountEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReportTypeInvoiceAmount
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ReportTypeInvoiceAmountEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ReportTypeInvoiceAmountEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReportTypeInvoiceAmountUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<ReportTypeInvoiceAmountEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty RightEntity objects.</summary>
	[Serializable]
	public partial class RightEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public RightEntityFactory() : base("RightEntity", PsychologicalServices.Data.EntityType.RightEntity) { }

		/// <summary>Creates a new, empty RightEntity object.</summary>
		/// <returns>A new, empty RightEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new RightEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRight
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new RightEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new RightEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRightUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<RightEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty RoleEntity objects.</summary>
	[Serializable]
	public partial class RoleEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public RoleEntityFactory() : base("RoleEntity", PsychologicalServices.Data.EntityType.RoleEntity) { }

		/// <summary>Creates a new, empty RoleEntity object.</summary>
		/// <returns>A new, empty RoleEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new RoleEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRole
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new RoleEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new RoleEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<RoleEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty RoleRightEntity objects.</summary>
	[Serializable]
	public partial class RoleRightEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public RoleRightEntityFactory() : base("RoleRightEntity", PsychologicalServices.Data.EntityType.RoleRightEntity) { }

		/// <summary>Creates a new, empty RoleRightEntity object.</summary>
		/// <returns>A new, empty RoleRightEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new RoleRightEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleRight
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new RoleRightEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new RoleRightEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleRightUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<RoleRightEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty UserEntity objects.</summary>
	[Serializable]
	public partial class UserEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public UserEntityFactory() : base("UserEntity", PsychologicalServices.Data.EntityType.UserEntity) { }

		/// <summary>Creates a new, empty UserEntity object.</summary>
		/// <returns>A new, empty UserEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new UserEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUser
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new UserEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new UserEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<UserEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty UserNoteEntity objects.</summary>
	[Serializable]
	public partial class UserNoteEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public UserNoteEntityFactory() : base("UserNoteEntity", PsychologicalServices.Data.EntityType.UserNoteEntity) { }

		/// <summary>Creates a new, empty UserNoteEntity object.</summary>
		/// <returns>A new, empty UserNoteEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new UserNoteEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserNote
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new UserNoteEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new UserNoteEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserNoteUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<UserNoteEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty UserRoleEntity objects.</summary>
	[Serializable]
	public partial class UserRoleEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public UserRoleEntityFactory() : base("UserRoleEntity", PsychologicalServices.Data.EntityType.UserRoleEntity) { }

		/// <summary>Creates a new, empty UserRoleEntity object.</summary>
		/// <returns>A new, empty UserRoleEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new UserRoleEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserRole
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new UserRoleEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new UserRoleEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserRoleUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<UserRoleEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty UserTravelFeeEntity objects.</summary>
	[Serializable]
	public partial class UserTravelFeeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public UserTravelFeeEntityFactory() : base("UserTravelFeeEntity", PsychologicalServices.Data.EntityType.UserTravelFeeEntity) { }

		/// <summary>Creates a new, empty UserTravelFeeEntity object.</summary>
		/// <returns>A new, empty UserTravelFeeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new UserTravelFeeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserTravelFee
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new UserTravelFeeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new UserTravelFeeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserTravelFeeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<UserTravelFeeEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty UserUnavailabilityEntity objects.</summary>
	[Serializable]
	public partial class UserUnavailabilityEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public UserUnavailabilityEntityFactory() : base("UserUnavailabilityEntity", PsychologicalServices.Data.EntityType.UserUnavailabilityEntity) { }

		/// <summary>Creates a new, empty UserUnavailabilityEntity object.</summary>
		/// <returns>A new, empty UserUnavailabilityEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new UserUnavailabilityEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserUnavailability
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new UserUnavailabilityEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new UserUnavailabilityEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserUnavailabilityUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<UserUnavailabilityEntity>(this);
		}
		

		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty Entity objects based on the entity type specified. Uses  entity specific factory objects</summary>
	[Serializable]
	public partial class GeneralEntityFactory
	{
		/// <summary>Creates a new, empty Entity object of the type specified</summary>
		/// <param name="entityTypeToCreate">The entity type to create.</param>
		/// <returns>A new, empty Entity object.</returns>
		public static IEntity2 Create(PsychologicalServices.Data.EntityType entityTypeToCreate)
		{
			IEntityFactory2 factoryToUse = null;
			switch(entityTypeToCreate)
			{
				case PsychologicalServices.Data.EntityType.AddressEntity:
					factoryToUse = new AddressEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AddressTypeEntity:
					factoryToUse = new AddressTypeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AppointmentEntity:
					factoryToUse = new AppointmentEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AppointmentAttributeEntity:
					factoryToUse = new AppointmentAttributeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AppointmentSequenceEntity:
					factoryToUse = new AppointmentSequenceEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AppointmentStatusEntity:
					factoryToUse = new AppointmentStatusEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentEntity:
					factoryToUse = new AssessmentEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentAttributeEntity:
					factoryToUse = new AssessmentAttributeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentClaimEntity:
					factoryToUse = new AssessmentClaimEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentColorEntity:
					factoryToUse = new AssessmentColorEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentMedRehabEntity:
					factoryToUse = new AssessmentMedRehabEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentNoteEntity:
					factoryToUse = new AssessmentNoteEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentReportEntity:
					factoryToUse = new AssessmentReportEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentReportIssueInDisputeEntity:
					factoryToUse = new AssessmentReportIssueInDisputeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentTypeEntity:
					factoryToUse = new AssessmentTypeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentTypeAttributeTypeEntity:
					factoryToUse = new AssessmentTypeAttributeTypeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentTypeReportTypeEntity:
					factoryToUse = new AssessmentTypeReportTypeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AttributeEntity:
					factoryToUse = new AttributeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AttributeTypeEntity:
					factoryToUse = new AttributeTypeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.CalendarNoteEntity:
					factoryToUse = new CalendarNoteEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.CityEntity:
					factoryToUse = new CityEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.ClaimEntity:
					factoryToUse = new ClaimEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.ClaimantEntity:
					factoryToUse = new ClaimantEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.ColorEntity:
					factoryToUse = new ColorEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.CompanyEntity:
					factoryToUse = new CompanyEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.CompanyAttributeEntity:
					factoryToUse = new CompanyAttributeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.InvoiceEntity:
					factoryToUse = new InvoiceEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.InvoiceAppointmentEntity:
					factoryToUse = new InvoiceAppointmentEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.InvoiceDocumentEntity:
					factoryToUse = new InvoiceDocumentEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.InvoiceLineEntity:
					factoryToUse = new InvoiceLineEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.InvoiceStatusEntity:
					factoryToUse = new InvoiceStatusEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.InvoiceStatusChangeEntity:
					factoryToUse = new InvoiceStatusChangeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.InvoiceStatusPathsEntity:
					factoryToUse = new InvoiceStatusPathsEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.InvoiceTypeEntity:
					factoryToUse = new InvoiceTypeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.IssueInDisputeEntity:
					factoryToUse = new IssueInDisputeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.NoteEntity:
					factoryToUse = new NoteEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.ReferralSourceEntity:
					factoryToUse = new ReferralSourceEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.ReferralSourceAppointmentStatusSettingEntity:
					factoryToUse = new ReferralSourceAppointmentStatusSettingEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.ReferralSourceTypeEntity:
					factoryToUse = new ReferralSourceTypeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.ReferralTypeEntity:
					factoryToUse = new ReferralTypeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.ReferralTypeIssueInDisputeEntity:
					factoryToUse = new ReferralTypeIssueInDisputeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.ReportStatusEntity:
					factoryToUse = new ReportStatusEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.ReportTypeEntity:
					factoryToUse = new ReportTypeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.ReportTypeInvoiceAmountEntity:
					factoryToUse = new ReportTypeInvoiceAmountEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.RightEntity:
					factoryToUse = new RightEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.RoleEntity:
					factoryToUse = new RoleEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.RoleRightEntity:
					factoryToUse = new RoleRightEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.UserEntity:
					factoryToUse = new UserEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.UserNoteEntity:
					factoryToUse = new UserNoteEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.UserRoleEntity:
					factoryToUse = new UserRoleEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.UserTravelFeeEntity:
					factoryToUse = new UserTravelFeeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.UserUnavailabilityEntity:
					factoryToUse = new UserUnavailabilityEntityFactory();
					break;
			}
			IEntity2 toReturn = null;
			if(factoryToUse != null)
			{
				toReturn = factoryToUse.Create();
			}
			return toReturn;
		}		
	}
		
	/// <summary>Class which is used to obtain the entity factory based on the .NET type of the entity. </summary>
	[Serializable]
	public static class EntityFactoryFactory
	{
#if CF
		/// <summary>Gets the factory of the entity with the PsychologicalServices.Data.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(PsychologicalServices.Data.EntityType typeOfEntity)
		{
			return GeneralEntityFactory.Create(typeOfEntity).GetEntityFactory();
		}
#else
		private static Dictionary<Type, IEntityFactory2> _factoryPerType = new Dictionary<Type, IEntityFactory2>();

		/// <summary>Initializes the <see cref="EntityFactoryFactory"/> class.</summary>
		static EntityFactoryFactory()
		{
			Array entityTypeValues = Enum.GetValues(typeof(PsychologicalServices.Data.EntityType));
			foreach(int entityTypeValue in entityTypeValues)
			{
				IEntity2 dummy = GeneralEntityFactory.Create((PsychologicalServices.Data.EntityType)entityTypeValue);
				_factoryPerType.Add(dummy.GetType(), dummy.GetEntityFactory());
			}
		}

		/// <summary>Gets the factory of the entity with the .NET type specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(Type typeOfEntity)
		{
			IEntityFactory2 toReturn = null;
			_factoryPerType.TryGetValue(typeOfEntity, out toReturn);
			return toReturn;
		}

		/// <summary>Gets the factory of the entity with the PsychologicalServices.Data.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(PsychologicalServices.Data.EntityType typeOfEntity)
		{
			return GetFactory(GeneralEntityFactory.Create(typeOfEntity).GetType());
		}
#endif		
	}
		
	/// <summary>Element creator for creating project elements from somewhere else, like inside Linq providers.</summary>
	public class ElementCreator : ElementCreatorBase, IElementCreator2
	{
		/// <summary>Gets the factory of the Entity type with the PsychologicalServices.Data.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(int entityTypeValue)
		{
			return (IEntityFactory2)this.GetFactoryImpl(entityTypeValue);
		}
		
		/// <summary>Gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(Type typeOfEntity)
		{
			return (IEntityFactory2)this.GetFactoryImpl(typeOfEntity);
		}

		/// <summary>Creates a new resultset fields object with the number of field slots reserved as specified</summary>
		/// <param name="numberOfFields">The number of fields.</param>
		/// <returns>ready to use resultsetfields object</returns>
		public IEntityFields2 CreateResultsetFields(int numberOfFields)
		{
			return new ResultsetFields(numberOfFields);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand)
		{
			return new DynamicRelation(leftOperand);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperand">The right operand.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, onClause);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperandEntityName">Name of the entity, which is used as the right operand.</param>
		/// <param name="aliasRightOperand">The alias of the right operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (PsychologicalServices.Data.EntityType)Enum.Parse(typeof(PsychologicalServices.Data.EntityType), rightOperandEntityName, false), aliasRightOperand, onClause);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperandEntityName">Name of the entity which is used as the left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperandEntityName">Name of the entity, which is used as the right operand.</param>
		/// <param name="aliasLeftOperand">The alias of the left operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="aliasRightOperand">The alias of the right operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(string leftOperandEntityName, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation((PsychologicalServices.Data.EntityType)Enum.Parse(typeof(PsychologicalServices.Data.EntityType), leftOperandEntityName, false), joinType, (PsychologicalServices.Data.EntityType)Enum.Parse(typeof(PsychologicalServices.Data.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
		
		/// <summary>Obtains the inheritance info provider instance from the singleton </summary>
		/// <returns>The singleton instance of the inheritance info provider</returns>
		public override IInheritanceInfoProvider ObtainInheritanceInfoProviderInstance()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}
		
		/// <summary>Implementation of the routine which gets the factory of the Entity type with the PsychologicalServices.Data.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		protected override IEntityFactoryCore GetFactoryImpl(int entityTypeValue)
		{
			return EntityFactoryFactory.GetFactory((PsychologicalServices.Data.EntityType)entityTypeValue);
		}
#if !CF		
		/// <summary>Implementation of the routine which gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		protected override IEntityFactoryCore GetFactoryImpl(Type typeOfEntity)
		{
			return EntityFactoryFactory.GetFactory(typeOfEntity);
		}
#endif
	}
}
