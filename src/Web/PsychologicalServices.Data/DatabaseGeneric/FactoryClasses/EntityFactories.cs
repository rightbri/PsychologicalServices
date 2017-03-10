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
	/// <summary>Factory to create new, empty AppointmentTaskEntity objects.</summary>
	[Serializable]
	public partial class AppointmentTaskEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AppointmentTaskEntityFactory() : base("AppointmentTaskEntity", PsychologicalServices.Data.EntityType.AppointmentTaskEntity) { }

		/// <summary>Creates a new, empty AppointmentTaskEntity object.</summary>
		/// <returns>A new, empty AppointmentTaskEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AppointmentTaskEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAppointmentTask
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AppointmentTaskEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AppointmentTaskEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAppointmentTaskUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AppointmentTaskEntity>(this);
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
	/// <summary>Factory to create new, empty AssessmentIssueInDisputeEntity objects.</summary>
	[Serializable]
	public partial class AssessmentIssueInDisputeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public AssessmentIssueInDisputeEntityFactory() : base("AssessmentIssueInDisputeEntity", PsychologicalServices.Data.EntityType.AssessmentIssueInDisputeEntity) { }

		/// <summary>Creates a new, empty AssessmentIssueInDisputeEntity object.</summary>
		/// <returns>A new, empty AssessmentIssueInDisputeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new AssessmentIssueInDisputeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentIssueInDispute
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new AssessmentIssueInDisputeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AssessmentIssueInDisputeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAssessmentIssueInDisputeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<AssessmentIssueInDisputeEntity>(this);
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
	/// <summary>Factory to create new, empty InvoiceAmountEntity objects.</summary>
	[Serializable]
	public partial class InvoiceAmountEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public InvoiceAmountEntityFactory() : base("InvoiceAmountEntity", PsychologicalServices.Data.EntityType.InvoiceAmountEntity) { }

		/// <summary>Creates a new, empty InvoiceAmountEntity object.</summary>
		/// <returns>A new, empty InvoiceAmountEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new InvoiceAmountEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceAmount
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new InvoiceAmountEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new InvoiceAmountEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvoiceAmountUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<InvoiceAmountEntity>(this);
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
	/// <summary>Factory to create new, empty TaskEntity objects.</summary>
	[Serializable]
	public partial class TaskEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TaskEntityFactory() : base("TaskEntity", PsychologicalServices.Data.EntityType.TaskEntity) { }

		/// <summary>Creates a new, empty TaskEntity object.</summary>
		/// <returns>A new, empty TaskEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TaskEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTask
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TaskEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TaskEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTaskUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<TaskEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TaskStatusEntity objects.</summary>
	[Serializable]
	public partial class TaskStatusEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TaskStatusEntityFactory() : base("TaskStatusEntity", PsychologicalServices.Data.EntityType.TaskStatusEntity) { }

		/// <summary>Creates a new, empty TaskStatusEntity object.</summary>
		/// <returns>A new, empty TaskStatusEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TaskStatusEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTaskStatus
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TaskStatusEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TaskStatusEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTaskStatusUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<TaskStatusEntity>(this);
		}
		

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TaskTemplateEntity objects.</summary>
	[Serializable]
	public partial class TaskTemplateEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TaskTemplateEntityFactory() : base("TaskTemplateEntity", PsychologicalServices.Data.EntityType.TaskTemplateEntity) { }

		/// <summary>Creates a new, empty TaskTemplateEntity object.</summary>
		/// <returns>A new, empty TaskTemplateEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TaskTemplateEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTaskTemplate
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TaskTemplateEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TaskTemplateEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTaskTemplateUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<TaskTemplateEntity>(this);
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
				case PsychologicalServices.Data.EntityType.AppointmentStatusEntity:
					factoryToUse = new AppointmentStatusEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AppointmentTaskEntity:
					factoryToUse = new AppointmentTaskEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentEntity:
					factoryToUse = new AssessmentEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentClaimEntity:
					factoryToUse = new AssessmentClaimEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentColorEntity:
					factoryToUse = new AssessmentColorEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentIssueInDisputeEntity:
					factoryToUse = new AssessmentIssueInDisputeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentMedRehabEntity:
					factoryToUse = new AssessmentMedRehabEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentNoteEntity:
					factoryToUse = new AssessmentNoteEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentTypeEntity:
					factoryToUse = new AssessmentTypeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.AssessmentTypeReportTypeEntity:
					factoryToUse = new AssessmentTypeReportTypeEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.CalendarNoteEntity:
					factoryToUse = new CalendarNoteEntityFactory();
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
				case PsychologicalServices.Data.EntityType.InvoiceAmountEntity:
					factoryToUse = new InvoiceAmountEntityFactory();
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
				case PsychologicalServices.Data.EntityType.RightEntity:
					factoryToUse = new RightEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.RoleEntity:
					factoryToUse = new RoleEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.RoleRightEntity:
					factoryToUse = new RoleRightEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.TaskEntity:
					factoryToUse = new TaskEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.TaskStatusEntity:
					factoryToUse = new TaskStatusEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.TaskTemplateEntity:
					factoryToUse = new TaskTemplateEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.UserEntity:
					factoryToUse = new UserEntityFactory();
					break;
				case PsychologicalServices.Data.EntityType.UserRoleEntity:
					factoryToUse = new UserRoleEntityFactory();
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
