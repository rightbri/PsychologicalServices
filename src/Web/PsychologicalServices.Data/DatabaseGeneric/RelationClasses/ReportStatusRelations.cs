﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.3.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
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
	/// <summary>Implements the relations factory for the entity: ReportStatus. </summary>
	public partial class ReportStatusRelations
	{
		/// <summary>CTor</summary>
		public ReportStatusRelations()
		{
		}

		/// <summary>Gets all relations of the ReportStatusEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AssessmentEntityUsingReportStatusId);
			toReturn.Add(this.CompanyEntityUsingNewAssessmentReportStatusId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ReportStatusEntity and AssessmentEntity over the 1:n relation they have, using the relation between the fields:
		/// ReportStatus.ReportStatusId - Assessment.ReportStatusId
		/// </summary>
		public virtual IEntityRelation AssessmentEntityUsingReportStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Assessments" , true);
				relation.AddEntityFieldPair(ReportStatusFields.ReportStatusId, AssessmentFields.ReportStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportStatusEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ReportStatusEntity and CompanyEntity over the 1:n relation they have, using the relation between the fields:
		/// ReportStatus.ReportStatusId - Company.NewAssessmentReportStatusId
		/// </summary>
		public virtual IEntityRelation CompanyEntityUsingNewAssessmentReportStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(ReportStatusFields.ReportStatusId, CompanyFields.NewAssessmentReportStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportStatusEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", false);
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
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticReportStatusRelations
	{
		internal static readonly IEntityRelation AssessmentEntityUsingReportStatusIdStatic = new ReportStatusRelations().AssessmentEntityUsingReportStatusId;
		internal static readonly IEntityRelation CompanyEntityUsingNewAssessmentReportStatusIdStatic = new ReportStatusRelations().CompanyEntityUsingNewAssessmentReportStatusId;

		/// <summary>CTor</summary>
		static StaticReportStatusRelations()
		{
		}
	}
}
