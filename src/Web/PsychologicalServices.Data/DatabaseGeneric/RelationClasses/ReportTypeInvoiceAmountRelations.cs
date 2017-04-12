﻿///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: ReportTypeInvoiceAmount. </summary>
	public partial class ReportTypeInvoiceAmountRelations
	{
		/// <summary>CTor</summary>
		public ReportTypeInvoiceAmountRelations()
		{
		}

		/// <summary>Gets all relations of the ReportTypeInvoiceAmountEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.ReferralSourceEntityUsingReferralSourceId);
			toReturn.Add(this.ReportTypeEntityUsingReportTypeId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ReportTypeInvoiceAmountEntity and ReferralSourceEntity over the m:1 relation they have, using the relation between the fields:
		/// ReportTypeInvoiceAmount.ReferralSourceId - ReferralSource.ReferralSourceId
		/// </summary>
		public virtual IEntityRelation ReferralSourceEntityUsingReferralSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ReferralSource", false);
				relation.AddEntityFieldPair(ReferralSourceFields.ReferralSourceId, ReportTypeInvoiceAmountFields.ReferralSourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportTypeInvoiceAmountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ReportTypeInvoiceAmountEntity and ReportTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ReportTypeInvoiceAmount.ReportTypeId - ReportType.ReportTypeId
		/// </summary>
		public virtual IEntityRelation ReportTypeEntityUsingReportTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ReportType", false);
				relation.AddEntityFieldPair(ReportTypeFields.ReportTypeId, ReportTypeInvoiceAmountFields.ReportTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportTypeInvoiceAmountEntity", true);
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