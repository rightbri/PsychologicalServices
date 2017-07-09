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
	/// <summary>Implements the static Relations variant for the entity: AddressAddressType. </summary>
	public partial class AddressAddressTypeRelations
	{
		/// <summary>CTor</summary>
		public AddressAddressTypeRelations()
		{
		}

		/// <summary>Gets all relations of the AddressAddressTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AddressEntityUsingAddressId);
			toReturn.Add(this.AddressTypeEntityUsingAddressTypeId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AddressAddressTypeEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// AddressAddressType.AddressId - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Address", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, AddressAddressTypeFields.AddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressAddressTypeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AddressAddressTypeEntity and AddressTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// AddressAddressType.AddressTypeId - AddressType.AddressTypeId
		/// </summary>
		public virtual IEntityRelation AddressTypeEntityUsingAddressTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AddressType", false);
				relation.AddEntityFieldPair(AddressTypeFields.AddressTypeId, AddressAddressTypeFields.AddressTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressAddressTypeEntity", true);
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
