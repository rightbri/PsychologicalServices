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
	/// <summary>Implements the static Relations variant for the entity: IssueInDispute. </summary>
	public partial class IssueInDisputeRelations
	{
		/// <summary>CTor</summary>
		public IssueInDisputeRelations()
		{
		}

		/// <summary>Gets all relations of the IssueInDisputeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AssessmentReportIssueInDisputeEntityUsingIssueInDisputeId);
			toReturn.Add(this.IssueInDisputeInvoiceAmountEntityUsingIssueInDisputeId);
			toReturn.Add(this.ReferralTypeIssueInDisputeEntityUsingIssueInDisputeId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between IssueInDisputeEntity and AssessmentReportIssueInDisputeEntity over the 1:n relation they have, using the relation between the fields:
		/// IssueInDispute.IssueInDisputeId - AssessmentReportIssueInDispute.IssueInDisputeId
		/// </summary>
		public virtual IEntityRelation AssessmentReportIssueInDisputeEntityUsingIssueInDisputeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AssessmentReportIssuesInDispute" , true);
				relation.AddEntityFieldPair(IssueInDisputeFields.IssueInDisputeId, AssessmentReportIssueInDisputeFields.IssueInDisputeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IssueInDisputeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentReportIssueInDisputeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between IssueInDisputeEntity and IssueInDisputeInvoiceAmountEntity over the 1:n relation they have, using the relation between the fields:
		/// IssueInDispute.IssueInDisputeId - IssueInDisputeInvoiceAmount.IssueInDisputeId
		/// </summary>
		public virtual IEntityRelation IssueInDisputeInvoiceAmountEntityUsingIssueInDisputeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ReportTypeInvoiceAmount" , true);
				relation.AddEntityFieldPair(IssueInDisputeFields.IssueInDisputeId, IssueInDisputeInvoiceAmountFields.IssueInDisputeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IssueInDisputeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IssueInDisputeInvoiceAmountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between IssueInDisputeEntity and ReferralTypeIssueInDisputeEntity over the 1:n relation they have, using the relation between the fields:
		/// IssueInDispute.IssueInDisputeId - ReferralTypeIssueInDispute.IssueInDisputeId
		/// </summary>
		public virtual IEntityRelation ReferralTypeIssueInDisputeEntityUsingIssueInDisputeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ReferralTypeIssuesInDispute" , true);
				relation.AddEntityFieldPair(IssueInDisputeFields.IssueInDisputeId, ReferralTypeIssueInDisputeFields.IssueInDisputeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IssueInDisputeEntity", true);
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
