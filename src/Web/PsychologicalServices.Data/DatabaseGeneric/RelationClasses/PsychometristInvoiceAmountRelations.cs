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
	/// <summary>Implements the static Relations variant for the entity: PsychometristInvoiceAmount. </summary>
	public partial class PsychometristInvoiceAmountRelations
	{
		/// <summary>CTor</summary>
		public PsychometristInvoiceAmountRelations()
		{
		}

		/// <summary>Gets all relations of the PsychometristInvoiceAmountEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AppointmentSequenceEntityUsingAppointmentSequenceId);
			toReturn.Add(this.AppointmentStatusEntityUsingAppointmentStatusId);
			toReturn.Add(this.AssessmentTypeEntityUsingAssessmentTypeId);
			toReturn.Add(this.CompanyEntityUsingCompanyId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PsychometristInvoiceAmountEntity and AppointmentSequenceEntity over the m:1 relation they have, using the relation between the fields:
		/// PsychometristInvoiceAmount.AppointmentSequenceId - AppointmentSequence.AppointmentSequenceId
		/// </summary>
		public virtual IEntityRelation AppointmentSequenceEntityUsingAppointmentSequenceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AppointmentSequence", false);
				relation.AddEntityFieldPair(AppointmentSequenceFields.AppointmentSequenceId, PsychometristInvoiceAmountFields.AppointmentSequenceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentSequenceEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PsychometristInvoiceAmountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PsychometristInvoiceAmountEntity and AppointmentStatusEntity over the m:1 relation they have, using the relation between the fields:
		/// PsychometristInvoiceAmount.AppointmentStatusId - AppointmentStatus.AppointmentStatusId
		/// </summary>
		public virtual IEntityRelation AppointmentStatusEntityUsingAppointmentStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AppointmentStatus", false);
				relation.AddEntityFieldPair(AppointmentStatusFields.AppointmentStatusId, PsychometristInvoiceAmountFields.AppointmentStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentStatusEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PsychometristInvoiceAmountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PsychometristInvoiceAmountEntity and AssessmentTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// PsychometristInvoiceAmount.AssessmentTypeId - AssessmentType.AssessmentTypeId
		/// </summary>
		public virtual IEntityRelation AssessmentTypeEntityUsingAssessmentTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AssessmentType", false);
				relation.AddEntityFieldPair(AssessmentTypeFields.AssessmentTypeId, PsychometristInvoiceAmountFields.AssessmentTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PsychometristInvoiceAmountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PsychometristInvoiceAmountEntity and CompanyEntity over the m:1 relation they have, using the relation between the fields:
		/// PsychometristInvoiceAmount.CompanyId - Company.CompanyId
		/// </summary>
		public virtual IEntityRelation CompanyEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Company", false);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, PsychometristInvoiceAmountFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PsychometristInvoiceAmountEntity", true);
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
