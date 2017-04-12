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
	/// <summary>Implements the static Relations variant for the entity: ReportType. </summary>
	public partial class ReportTypeRelations
	{
		/// <summary>CTor</summary>
		public ReportTypeRelations()
		{
		}

		/// <summary>Gets all relations of the ReportTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AssessmentReportEntityUsingReportTypeId);
			toReturn.Add(this.AssessmentTypeReportTypeEntityUsingReportTypeId);
			toReturn.Add(this.ReportTypeInvoiceAmountEntityUsingReportTypeId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ReportTypeEntity and AssessmentReportEntity over the 1:n relation they have, using the relation between the fields:
		/// ReportType.ReportTypeId - AssessmentReport.ReportTypeId
		/// </summary>
		public virtual IEntityRelation AssessmentReportEntityUsingReportTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AssessmentReports" , true);
				relation.AddEntityFieldPair(ReportTypeFields.ReportTypeId, AssessmentReportFields.ReportTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentReportEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ReportTypeEntity and AssessmentTypeReportTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// ReportType.ReportTypeId - AssessmentTypeReportType.ReportTypeId
		/// </summary>
		public virtual IEntityRelation AssessmentTypeReportTypeEntityUsingReportTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AssessmentTypeReportTypes" , true);
				relation.AddEntityFieldPair(ReportTypeFields.ReportTypeId, AssessmentTypeReportTypeFields.ReportTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeReportTypeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ReportTypeEntity and ReportTypeInvoiceAmountEntity over the 1:n relation they have, using the relation between the fields:
		/// ReportType.ReportTypeId - ReportTypeInvoiceAmount.ReportTypeId
		/// </summary>
		public virtual IEntityRelation ReportTypeInvoiceAmountEntityUsingReportTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ReportTypeInvoiceAmounts" , true);
				relation.AddEntityFieldPair(ReportTypeFields.ReportTypeId, ReportTypeInvoiceAmountFields.ReportTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportTypeInvoiceAmountEntity", false);
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
