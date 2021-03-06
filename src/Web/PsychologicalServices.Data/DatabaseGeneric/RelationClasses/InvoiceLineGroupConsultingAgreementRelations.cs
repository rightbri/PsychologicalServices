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
	/// <summary>Implements the relations factory for the entity: InvoiceLineGroupConsultingAgreement. </summary>
	public partial class InvoiceLineGroupConsultingAgreementRelations
	{
		/// <summary>CTor</summary>
		public InvoiceLineGroupConsultingAgreementRelations()
		{
		}

		/// <summary>Gets all relations of the InvoiceLineGroupConsultingAgreementEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.InvoiceLineGroupEntityUsingInvoiceLineGroupId);
			toReturn.Add(this.ConsultingAgreementEntityUsingConsultingAgreementId);
			return toReturn;
		}

		#region Class Property Declarations


		/// <summary>Returns a new IEntityRelation object, between InvoiceLineGroupConsultingAgreementEntity and InvoiceLineGroupEntity over the 1:1 relation they have, using the relation between the fields:
		/// InvoiceLineGroupConsultingAgreement.InvoiceLineGroupId - InvoiceLineGroup.InvoiceLineGroupId
		/// </summary>
		public virtual IEntityRelation InvoiceLineGroupEntityUsingInvoiceLineGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "InvoiceLineGroup", false);



				relation.AddEntityFieldPair(InvoiceLineGroupFields.InvoiceLineGroupId, InvoiceLineGroupConsultingAgreementFields.InvoiceLineGroupId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceLineGroupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceLineGroupConsultingAgreementEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between InvoiceLineGroupConsultingAgreementEntity and ConsultingAgreementEntity over the m:1 relation they have, using the relation between the fields:
		/// InvoiceLineGroupConsultingAgreement.ConsultingAgreementId - ConsultingAgreement.ConsultingAgreementId
		/// </summary>
		public virtual IEntityRelation ConsultingAgreementEntityUsingConsultingAgreementId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ConsultingAgreement", false);
				relation.AddEntityFieldPair(ConsultingAgreementFields.ConsultingAgreementId, InvoiceLineGroupConsultingAgreementFields.ConsultingAgreementId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ConsultingAgreementEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceLineGroupConsultingAgreementEntity", true);
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
	internal static class StaticInvoiceLineGroupConsultingAgreementRelations
	{
		internal static readonly IEntityRelation InvoiceLineGroupEntityUsingInvoiceLineGroupIdStatic = new InvoiceLineGroupConsultingAgreementRelations().InvoiceLineGroupEntityUsingInvoiceLineGroupId;
		internal static readonly IEntityRelation ConsultingAgreementEntityUsingConsultingAgreementIdStatic = new InvoiceLineGroupConsultingAgreementRelations().ConsultingAgreementEntityUsingConsultingAgreementId;

		/// <summary>CTor</summary>
		static StaticInvoiceLineGroupConsultingAgreementRelations()
		{
		}
	}
}
