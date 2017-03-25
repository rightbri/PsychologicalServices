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
	/// <summary>Implements the static Relations variant for the entity: Cities. </summary>
	public partial class CitiesRelations
	{
		/// <summary>CTor</summary>
		public CitiesRelations()
		{
		}

		/// <summary>Gets all relations of the CitiesEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AddressEntityUsingCityId);
			toReturn.Add(this.UserTravelFeeEntityUsingCityId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CitiesEntity and AddressEntity over the 1:n relation they have, using the relation between the fields:
		/// Cities.CityId - Address.CityId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingCityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Addresses" , true);
				relation.AddEntityFieldPair(CitiesFields.CityId, AddressFields.CityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CitiesEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CitiesEntity and UserTravelFeeEntity over the 1:n relation they have, using the relation between the fields:
		/// Cities.CityId - UserTravelFee.CityId
		/// </summary>
		public virtual IEntityRelation UserTravelFeeEntityUsingCityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UserTravelFees" , true);
				relation.AddEntityFieldPair(CitiesFields.CityId, UserTravelFeeFields.CityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CitiesEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserTravelFeeEntity", false);
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
