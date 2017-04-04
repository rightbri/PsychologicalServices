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
	/// <summary>Implements the static Relations variant for the entity: InvoiceStatusChange. </summary>
	public partial class InvoiceStatusChangeRelations
	{
		/// <summary>CTor</summary>
		public InvoiceStatusChangeRelations()
		{
		}

		/// <summary>Gets all relations of the InvoiceStatusChangeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.InvoiceEntityUsingInvoiceId);
			toReturn.Add(this.InvoiceStatusEntityUsingInvoiceStatusId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between InvoiceStatusChangeEntity and InvoiceEntity over the m:1 relation they have, using the relation between the fields:
		/// InvoiceStatusChange.InvoiceId - Invoice.InvoiceId
		/// </summary>
		public virtual IEntityRelation InvoiceEntityUsingInvoiceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Invoice", false);
				relation.AddEntityFieldPair(InvoiceFields.InvoiceId, InvoiceStatusChangeFields.InvoiceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceStatusChangeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between InvoiceStatusChangeEntity and InvoiceStatusEntity over the m:1 relation they have, using the relation between the fields:
		/// InvoiceStatusChange.InvoiceStatusId - InvoiceStatus.InvoiceStatusId
		/// </summary>
		public virtual IEntityRelation InvoiceStatusEntityUsingInvoiceStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "InvoiceStatus", false);
				relation.AddEntityFieldPair(InvoiceStatusFields.InvoiceStatusId, InvoiceStatusChangeFields.InvoiceStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceStatusEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceStatusChangeEntity", true);
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
