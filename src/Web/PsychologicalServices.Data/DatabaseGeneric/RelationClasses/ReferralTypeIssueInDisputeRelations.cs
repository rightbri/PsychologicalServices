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
	/// <summary>Implements the static Relations variant for the entity: ReferralTypeIssueInDispute. </summary>
	public partial class ReferralTypeIssueInDisputeRelations
	{
		/// <summary>CTor</summary>
		public ReferralTypeIssueInDisputeRelations()
		{
		}

		/// <summary>Gets all relations of the ReferralTypeIssueInDisputeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.IssueInDisputeEntityUsingIssueInDisputeId);
			toReturn.Add(this.ReferralTypeEntityUsingReferralTypeId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ReferralTypeIssueInDisputeEntity and IssueInDisputeEntity over the m:1 relation they have, using the relation between the fields:
		/// ReferralTypeIssueInDispute.IssueInDisputeId - IssueInDispute.IssueInDisputeId
		/// </summary>
		public virtual IEntityRelation IssueInDisputeEntityUsingIssueInDisputeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "IssueInDispute", false);
				relation.AddEntityFieldPair(IssueInDisputeFields.IssueInDisputeId, ReferralTypeIssueInDisputeFields.IssueInDisputeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IssueInDisputeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralTypeIssueInDisputeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ReferralTypeIssueInDisputeEntity and ReferralTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ReferralTypeIssueInDispute.ReferralTypeId - ReferralType.ReferralTypeId
		/// </summary>
		public virtual IEntityRelation ReferralTypeEntityUsingReferralTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ReferralType", false);
				relation.AddEntityFieldPair(ReferralTypeFields.ReferralTypeId, ReferralTypeIssueInDisputeFields.ReferralTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralTypeIssueInDisputeEntity", true);
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
