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
	/// <summary>Implements the relations factory for the entity: ConsultingAgreement. </summary>
	public partial class ConsultingAgreementRelations
	{
		/// <summary>CTor</summary>
		public ConsultingAgreementRelations()
		{
		}

		/// <summary>Gets all relations of the ConsultingAgreementEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.InvoiceLineGroupConsultingAgreementEntityUsingConsultingAgreementId);
			toReturn.Add(this.CompanyEntityUsingCompanyId);
			toReturn.Add(this.ReferralSourceEntityUsingBillToReferralSourceId);
			toReturn.Add(this.UserEntityUsingPsychologistId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ConsultingAgreementEntity and InvoiceLineGroupConsultingAgreementEntity over the 1:n relation they have, using the relation between the fields:
		/// ConsultingAgreement.ConsultingAgreementId - InvoiceLineGroupConsultingAgreement.ConsultingAgreementId
		/// </summary>
		public virtual IEntityRelation InvoiceLineGroupConsultingAgreementEntityUsingConsultingAgreementId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "InvoiceLineGroupConsultingAgreements" , true);
				relation.AddEntityFieldPair(ConsultingAgreementFields.ConsultingAgreementId, InvoiceLineGroupConsultingAgreementFields.ConsultingAgreementId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ConsultingAgreementEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceLineGroupConsultingAgreementEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ConsultingAgreementEntity and CompanyEntity over the m:1 relation they have, using the relation between the fields:
		/// ConsultingAgreement.CompanyId - Company.CompanyId
		/// </summary>
		public virtual IEntityRelation CompanyEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Company", false);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, ConsultingAgreementFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ConsultingAgreementEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ConsultingAgreementEntity and ReferralSourceEntity over the m:1 relation they have, using the relation between the fields:
		/// ConsultingAgreement.BillToReferralSourceId - ReferralSource.ReferralSourceId
		/// </summary>
		public virtual IEntityRelation ReferralSourceEntityUsingBillToReferralSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BillToReferralSource", false);
				relation.AddEntityFieldPair(ReferralSourceFields.ReferralSourceId, ConsultingAgreementFields.BillToReferralSourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ConsultingAgreementEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ConsultingAgreementEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// ConsultingAgreement.PsychologistId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingPsychologistId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Psychologist", false);
				relation.AddEntityFieldPair(UserFields.UserId, ConsultingAgreementFields.PsychologistId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ConsultingAgreementEntity", true);
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
	internal static class StaticConsultingAgreementRelations
	{
		internal static readonly IEntityRelation InvoiceLineGroupConsultingAgreementEntityUsingConsultingAgreementIdStatic = new ConsultingAgreementRelations().InvoiceLineGroupConsultingAgreementEntityUsingConsultingAgreementId;
		internal static readonly IEntityRelation CompanyEntityUsingCompanyIdStatic = new ConsultingAgreementRelations().CompanyEntityUsingCompanyId;
		internal static readonly IEntityRelation ReferralSourceEntityUsingBillToReferralSourceIdStatic = new ConsultingAgreementRelations().ReferralSourceEntityUsingBillToReferralSourceId;
		internal static readonly IEntityRelation UserEntityUsingPsychologistIdStatic = new ConsultingAgreementRelations().UserEntityUsingPsychologistId;

		/// <summary>CTor</summary>
		static StaticConsultingAgreementRelations()
		{
		}
	}
}
