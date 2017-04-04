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
	/// <summary>Implements the static Relations variant for the entity: AssessmentReportIssueInDispute. </summary>
	public partial class AssessmentReportIssueInDisputeRelations
	{
		/// <summary>CTor</summary>
		public AssessmentReportIssueInDisputeRelations()
		{
		}

		/// <summary>Gets all relations of the AssessmentReportIssueInDisputeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AssessmentReportEntityUsingReportId);
			toReturn.Add(this.IssueInDisputeEntityUsingIssueInDisputeId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AssessmentReportIssueInDisputeEntity and AssessmentReportEntity over the m:1 relation they have, using the relation between the fields:
		/// AssessmentReportIssueInDispute.ReportId - AssessmentReport.ReportId
		/// </summary>
		public virtual IEntityRelation AssessmentReportEntityUsingReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AssessmentReport", false);
				relation.AddEntityFieldPair(AssessmentReportFields.ReportId, AssessmentReportIssueInDisputeFields.ReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentReportEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentReportIssueInDisputeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentReportIssueInDisputeEntity and IssueInDisputeEntity over the m:1 relation they have, using the relation between the fields:
		/// AssessmentReportIssueInDispute.IssueInDisputeId - IssueInDispute.IssueInDisputeId
		/// </summary>
		public virtual IEntityRelation IssueInDisputeEntityUsingIssueInDisputeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "IssueInDispute", false);
				relation.AddEntityFieldPair(IssueInDisputeFields.IssueInDisputeId, AssessmentReportIssueInDisputeFields.IssueInDisputeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IssueInDisputeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentReportIssueInDisputeEntity", true);
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
