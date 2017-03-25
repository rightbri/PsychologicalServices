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
using System.Collections;
using System.Collections.Generic;
using PsychologicalServices.Data;
using PsychologicalServices.Data.FactoryClasses;
using PsychologicalServices.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PsychologicalServices.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: Address. </summary>
	public partial class AddressRelations
	{
		/// <summary>CTor</summary>
		public AddressRelations()
		{
		}

		/// <summary>Gets all relations of the AddressEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AppointmentEntityUsingLocationId);

			toReturn.Add(this.AddressTypeEntityUsingAddressTypeId);
			toReturn.Add(this.CityEntityUsingCityId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AddressEntity and AppointmentEntity over the 1:n relation they have, using the relation between the fields:
		/// Address.AddressId - Appointment.LocationId
		/// </summary>
		public virtual IEntityRelation AppointmentEntityUsingLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Appointments" , true);
				relation.AddEntityFieldPair(AddressFields.AddressId, AppointmentFields.LocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AddressEntity and AddressTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Address.AddressTypeId - AddressType.AddressTypeId
		/// </summary>
		public virtual IEntityRelation AddressTypeEntityUsingAddressTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AddressType", false);
				relation.AddEntityFieldPair(AddressTypeFields.AddressTypeId, AddressFields.AddressTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AddressEntity and CityEntity over the m:1 relation they have, using the relation between the fields:
		/// Address.CityId - City.CityId
		/// </summary>
		public virtual IEntityRelation CityEntityUsingCityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "City", false);
				relation.AddEntityFieldPair(CityFields.CityId, AddressFields.CityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CityEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", true);
				return relation;
			}
		}

		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}

		#endregion

		#region Included Code

		#endregion
	}
}
