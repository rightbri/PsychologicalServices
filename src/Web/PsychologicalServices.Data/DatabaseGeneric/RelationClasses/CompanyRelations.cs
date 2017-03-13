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
	/// <summary>Implements the static Relations variant for the entity: Company. </summary>
	public partial class CompanyRelations
	{
		/// <summary>CTor</summary>
		public CompanyRelations()
		{
		}

		/// <summary>Gets all relations of the CompanyEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AssessmentEntityUsingCompanyId);
			toReturn.Add(this.CompanyAttributeEntityUsingCompanyId);
			toReturn.Add(this.UserEntityUsingCompanyId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and AssessmentEntity over the 1:n relation they have, using the relation between the fields:
		/// Company.CompanyId - Assessment.CompanyId
		/// </summary>
		public virtual IEntityRelation AssessmentEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Assessments" , true);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, AssessmentFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and CompanyAttributeEntity over the 1:n relation they have, using the relation between the fields:
		/// Company.CompanyId - CompanyAttribute.CompanyId
		/// </summary>
		public virtual IEntityRelation CompanyAttributeEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CompanyAttributes" , true);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, CompanyAttributeFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyAttributeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CompanyEntity and UserEntity over the 1:n relation they have, using the relation between the fields:
		/// Company.CompanyId - User.CompanyId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Users" , true);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, UserFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
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
