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
	/// <summary>Implements the static Relations variant for the entity: ReferralType. </summary>
	public partial class ReferralTypeRelations
	{
		/// <summary>CTor</summary>
		public ReferralTypeRelations()
		{
		}

		/// <summary>Gets all relations of the ReferralTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AssessmentEntityUsingReferralTypeId);
			toReturn.Add(this.ReferralTypeIssueInDisputeEntityUsingReferralTypeId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ReferralTypeEntity and AssessmentEntity over the 1:n relation they have, using the relation between the fields:
		/// ReferralType.ReferralTypeId - Assessment.ReferralTypeId
		/// </summary>
		public virtual IEntityRelation AssessmentEntityUsingReferralTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(ReferralTypeFields.ReferralTypeId, AssessmentFields.ReferralTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ReferralTypeEntity and ReferralTypeIssueInDisputeEntity over the 1:n relation they have, using the relation between the fields:
		/// ReferralType.ReferralTypeId - ReferralTypeIssueInDispute.ReferralTypeId
		/// </summary>
		public virtual IEntityRelation ReferralTypeIssueInDisputeEntityUsingReferralTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ReferralTypeIssuesInDispute" , true);
				relation.AddEntityFieldPair(ReferralTypeFields.ReferralTypeId, ReferralTypeIssueInDisputeFields.ReferralTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralTypeIssueInDisputeEntity", false);
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
