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
	/// <summary>Implements the static Relations variant for the entity: AssessmentType. </summary>
	public partial class AssessmentTypeRelations
	{
		/// <summary>CTor</summary>
		public AssessmentTypeRelations()
		{
		}

		/// <summary>Gets all relations of the AssessmentTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AssessmentEntityUsingAssessmentTypeId);
			toReturn.Add(this.AssessmentTypeAttributeTypeEntityUsingAssessmentTypeId);
			toReturn.Add(this.AssessmentTypeReportTypeEntityUsingAssessmentTypeId);
			toReturn.Add(this.CompanyEntityUsingNewAssessmentAssessmentTypeId);
			toReturn.Add(this.PsychometristInvoiceAmountEntityUsingAssessmentTypeId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AssessmentTypeEntity and AssessmentEntity over the 1:n relation they have, using the relation between the fields:
		/// AssessmentType.AssessmentTypeId - Assessment.AssessmentTypeId
		/// </summary>
		public virtual IEntityRelation AssessmentEntityUsingAssessmentTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Assessments" , true);
				relation.AddEntityFieldPair(AssessmentTypeFields.AssessmentTypeId, AssessmentFields.AssessmentTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AssessmentTypeEntity and AssessmentTypeAttributeTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// AssessmentType.AssessmentTypeId - AssessmentTypeAttributeType.AssessmentTypeId
		/// </summary>
		public virtual IEntityRelation AssessmentTypeAttributeTypeEntityUsingAssessmentTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AssessmentTypeAttributeTypes" , true);
				relation.AddEntityFieldPair(AssessmentTypeFields.AssessmentTypeId, AssessmentTypeAttributeTypeFields.AssessmentTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeAttributeTypeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AssessmentTypeEntity and AssessmentTypeReportTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// AssessmentType.AssessmentTypeId - AssessmentTypeReportType.AssessmentTypeId
		/// </summary>
		public virtual IEntityRelation AssessmentTypeReportTypeEntityUsingAssessmentTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AssessmentTypeReportTypes" , true);
				relation.AddEntityFieldPair(AssessmentTypeFields.AssessmentTypeId, AssessmentTypeReportTypeFields.AssessmentTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeReportTypeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AssessmentTypeEntity and CompanyEntity over the 1:n relation they have, using the relation between the fields:
		/// AssessmentType.AssessmentTypeId - Company.NewAssessmentAssessmentTypeId
		/// </summary>
		public virtual IEntityRelation CompanyEntityUsingNewAssessmentAssessmentTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Company" , true);
				relation.AddEntityFieldPair(AssessmentTypeFields.AssessmentTypeId, CompanyFields.NewAssessmentAssessmentTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AssessmentTypeEntity and PsychometristInvoiceAmountEntity over the 1:n relation they have, using the relation between the fields:
		/// AssessmentType.AssessmentTypeId - PsychometristInvoiceAmount.AssessmentTypeId
		/// </summary>
		public virtual IEntityRelation PsychometristInvoiceAmountEntityUsingAssessmentTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PsychometristInvoiceAmounts" , true);
				relation.AddEntityFieldPair(AssessmentTypeFields.AssessmentTypeId, PsychometristInvoiceAmountFields.AssessmentTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PsychometristInvoiceAmountEntity", false);
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
