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
	/// <summary>Implements the relations factory for the entity: Invoice. </summary>
	public partial class InvoiceRelations
	{
		/// <summary>CTor</summary>
		public InvoiceRelations()
		{
		}

		/// <summary>Gets all relations of the InvoiceEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.InvoiceDocumentEntityUsingInvoiceId);
			toReturn.Add(this.InvoiceLineGroupEntityUsingInvoiceId);
			toReturn.Add(this.InvoiceStatusChangeEntityUsingInvoiceId);
			toReturn.Add(this.InvoiceStatusEntityUsingInvoiceStatusId);
			toReturn.Add(this.InvoiceTypeEntityUsingInvoiceTypeId);
			toReturn.Add(this.UserEntityUsingPayableToId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between InvoiceEntity and InvoiceDocumentEntity over the 1:n relation they have, using the relation between the fields:
		/// Invoice.InvoiceId - InvoiceDocument.InvoiceId
		/// </summary>
		public virtual IEntityRelation InvoiceDocumentEntityUsingInvoiceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "InvoiceDocuments" , true);
				relation.AddEntityFieldPair(InvoiceFields.InvoiceId, InvoiceDocumentFields.InvoiceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceDocumentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between InvoiceEntity and InvoiceLineGroupEntity over the 1:n relation they have, using the relation between the fields:
		/// Invoice.InvoiceId - InvoiceLineGroup.InvoiceId
		/// </summary>
		public virtual IEntityRelation InvoiceLineGroupEntityUsingInvoiceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "InvoiceLineGroups" , true);
				relation.AddEntityFieldPair(InvoiceFields.InvoiceId, InvoiceLineGroupFields.InvoiceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceLineGroupEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between InvoiceEntity and InvoiceStatusChangeEntity over the 1:n relation they have, using the relation between the fields:
		/// Invoice.InvoiceId - InvoiceStatusChange.InvoiceId
		/// </summary>
		public virtual IEntityRelation InvoiceStatusChangeEntityUsingInvoiceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "InvoiceStatusChanges" , true);
				relation.AddEntityFieldPair(InvoiceFields.InvoiceId, InvoiceStatusChangeFields.InvoiceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceStatusChangeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between InvoiceEntity and InvoiceStatusEntity over the m:1 relation they have, using the relation between the fields:
		/// Invoice.InvoiceStatusId - InvoiceStatus.InvoiceStatusId
		/// </summary>
		public virtual IEntityRelation InvoiceStatusEntityUsingInvoiceStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "InvoiceStatus", false);
				relation.AddEntityFieldPair(InvoiceStatusFields.InvoiceStatusId, InvoiceFields.InvoiceStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceStatusEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between InvoiceEntity and InvoiceTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Invoice.InvoiceTypeId - InvoiceType.InvoiceTypeId
		/// </summary>
		public virtual IEntityRelation InvoiceTypeEntityUsingInvoiceTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "InvoiceType", false);
				relation.AddEntityFieldPair(InvoiceTypeFields.InvoiceTypeId, InvoiceFields.InvoiceTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between InvoiceEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// Invoice.PayableToId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingPayableToId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PayableTo", false);
				relation.AddEntityFieldPair(UserFields.UserId, InvoiceFields.PayableToId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceEntity", true);
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
	internal static class StaticInvoiceRelations
	{
		internal static readonly IEntityRelation InvoiceDocumentEntityUsingInvoiceIdStatic = new InvoiceRelations().InvoiceDocumentEntityUsingInvoiceId;
		internal static readonly IEntityRelation InvoiceLineGroupEntityUsingInvoiceIdStatic = new InvoiceRelations().InvoiceLineGroupEntityUsingInvoiceId;
		internal static readonly IEntityRelation InvoiceStatusChangeEntityUsingInvoiceIdStatic = new InvoiceRelations().InvoiceStatusChangeEntityUsingInvoiceId;
		internal static readonly IEntityRelation InvoiceStatusEntityUsingInvoiceStatusIdStatic = new InvoiceRelations().InvoiceStatusEntityUsingInvoiceStatusId;
		internal static readonly IEntityRelation InvoiceTypeEntityUsingInvoiceTypeIdStatic = new InvoiceRelations().InvoiceTypeEntityUsingInvoiceTypeId;
		internal static readonly IEntityRelation UserEntityUsingPayableToIdStatic = new InvoiceRelations().UserEntityUsingPayableToId;

		/// <summary>CTor</summary>
		static StaticInvoiceRelations()
		{
		}
	}
}
