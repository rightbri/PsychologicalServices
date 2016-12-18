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
	/// <summary>Implements the static Relations variant for the entity: AssessmentIssueInDispute. </summary>
	public partial class AssessmentIssueInDisputeRelations
	{
		/// <summary>CTor</summary>
		public AssessmentIssueInDisputeRelations()
		{
		}

		/// <summary>Gets all relations of the AssessmentIssueInDisputeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AssessmentEntityUsingAssessmentId);
			toReturn.Add(this.IssueInDisputeEntityUsingIssueIsDisputeId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AssessmentIssueInDisputeEntity and AssessmentEntity over the m:1 relation they have, using the relation between the fields:
		/// AssessmentIssueInDispute.AssessmentId - Assessment.AssessmentId
		/// </summary>
		public virtual IEntityRelation AssessmentEntityUsingAssessmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Assessment", false);
				relation.AddEntityFieldPair(AssessmentFields.AssessmentId, AssessmentIssueInDisputeFields.AssessmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentIssueInDisputeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentIssueInDisputeEntity and IssueInDisputeEntity over the m:1 relation they have, using the relation between the fields:
		/// AssessmentIssueInDispute.IssueIsDisputeId - IssueInDispute.IssueInDisputeId
		/// </summary>
		public virtual IEntityRelation IssueInDisputeEntityUsingIssueIsDisputeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "IssueInDispute", false);
				relation.AddEntityFieldPair(IssueInDisputeFields.IssueInDisputeId, AssessmentIssueInDisputeFields.IssueIsDisputeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IssueInDisputeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentIssueInDisputeEntity", true);
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
