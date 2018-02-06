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
	/// <summary>Implements the static Relations variant for the entity: InvoiceLineGroups. </summary>
	public partial class InvoiceLineGroupsRelations
	{
		/// <summary>CTor</summary>
		public InvoiceLineGroupsRelations()
		{
		}

		/// <summary>Gets all relations of the InvoiceLineGroupsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.InvoiceLineEntityUsingInvoiceLineGroupId);

			toReturn.Add(this.InvoiceEntityUsingInvoiceId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between InvoiceLineGroupsEntity and InvoiceLineEntity over the 1:n relation they have, using the relation between the fields:
		/// InvoiceLineGroups.InvoiceLineGroupId - InvoiceLine.InvoiceLineGroupId
		/// </summary>
		public virtual IEntityRelation InvoiceLineEntityUsingInvoiceLineGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "InvoiceLines" , true);
				relation.AddEntityFieldPair(InvoiceLineGroupsFields.InvoiceLineGroupId, InvoiceLineFields.InvoiceLineGroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceLineGroupsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceLineEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between InvoiceLineGroupsEntity and InvoiceEntity over the m:1 relation they have, using the relation between the fields:
		/// InvoiceLineGroups.InvoiceId - Invoice.InvoiceId
		/// </summary>
		public virtual IEntityRelation InvoiceEntityUsingInvoiceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Invoice", false);
				relation.AddEntityFieldPair(InvoiceFields.InvoiceId, InvoiceLineGroupsFields.InvoiceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceLineGroupsEntity", true);
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
