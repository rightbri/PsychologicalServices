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
	/// <summary>Implements the static Relations variant for the entity: InvoiceStatus. </summary>
	public partial class InvoiceStatusRelations
	{
		/// <summary>CTor</summary>
		public InvoiceStatusRelations()
		{
		}

		/// <summary>Gets all relations of the InvoiceStatusEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.InvoiceEntityUsingInvoiceStatusId);
			toReturn.Add(this.InvoiceStatusChangeEntityUsingInvoiceStatusId);
			toReturn.Add(this.InvoiceStatusPathsEntityUsingNextInvoiceStatusId);
			toReturn.Add(this.InvoiceStatusPathsEntityUsingInvoiceStatusId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between InvoiceStatusEntity and InvoiceEntity over the 1:n relation they have, using the relation between the fields:
		/// InvoiceStatus.InvoiceStatusId - Invoice.InvoiceStatusId
		/// </summary>
		public virtual IEntityRelation InvoiceEntityUsingInvoiceStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Invoices" , true);
				relation.AddEntityFieldPair(InvoiceStatusFields.InvoiceStatusId, InvoiceFields.InvoiceStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceStatusEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between InvoiceStatusEntity and InvoiceStatusChangeEntity over the 1:n relation they have, using the relation between the fields:
		/// InvoiceStatus.InvoiceStatusId - InvoiceStatusChange.InvoiceStatusId
		/// </summary>
		public virtual IEntityRelation InvoiceStatusChangeEntityUsingInvoiceStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "InvoiceStatusChanges" , true);
				relation.AddEntityFieldPair(InvoiceStatusFields.InvoiceStatusId, InvoiceStatusChangeFields.InvoiceStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceStatusEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceStatusChangeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between InvoiceStatusEntity and InvoiceStatusPathsEntity over the 1:n relation they have, using the relation between the fields:
		/// InvoiceStatus.InvoiceStatusId - InvoiceStatusPaths.NextInvoiceStatusId
		/// </summary>
		public virtual IEntityRelation InvoiceStatusPathsEntityUsingNextInvoiceStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "NextInvoiceStatusPaths" , true);
				relation.AddEntityFieldPair(InvoiceStatusFields.InvoiceStatusId, InvoiceStatusPathsFields.NextInvoiceStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceStatusEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceStatusPathsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between InvoiceStatusEntity and InvoiceStatusPathsEntity over the 1:n relation they have, using the relation between the fields:
		/// InvoiceStatus.InvoiceStatusId - InvoiceStatusPaths.InvoiceStatusId
		/// </summary>
		public virtual IEntityRelation InvoiceStatusPathsEntityUsingInvoiceStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "InvoiceStatusPaths" , true);
				relation.AddEntityFieldPair(InvoiceStatusFields.InvoiceStatusId, InvoiceStatusPathsFields.InvoiceStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceStatusEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceStatusPathsEntity", false);
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
