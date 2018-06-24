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
	/// <summary>Implements the relations factory for the entity: RawTestData. </summary>
	public partial class RawTestDataRelations
	{
		/// <summary>CTor</summary>
		public RawTestDataRelations()
		{
		}

		/// <summary>Gets all relations of the RawTestDataEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.InvoiceLineGroupRawTestDataEntityUsingRawTestDataId);
			toReturn.Add(this.ClaimantEntityUsingClaimantId);
			toReturn.Add(this.CompanyEntityUsingCompanyId);
			toReturn.Add(this.NoteEntityUsingNoteId);
			toReturn.Add(this.RawTestDataStatusEntityUsingRawTestDataStatusId);
			toReturn.Add(this.ReferralSourceEntityUsingBillToReferralSourceId);
			toReturn.Add(this.UserEntityUsingPsychologistId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between RawTestDataEntity and InvoiceLineGroupRawTestDataEntity over the 1:n relation they have, using the relation between the fields:
		/// RawTestData.RawTestDataId - InvoiceLineGroupRawTestData.RawTestDataId
		/// </summary>
		public virtual IEntityRelation InvoiceLineGroupRawTestDataEntityUsingRawTestDataId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "InvoiceLineGroupRawTestDatas" , true);
				relation.AddEntityFieldPair(RawTestDataFields.RawTestDataId, InvoiceLineGroupRawTestDataFields.RawTestDataId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RawTestDataEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceLineGroupRawTestDataEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between RawTestDataEntity and ClaimantEntity over the m:1 relation they have, using the relation between the fields:
		/// RawTestData.ClaimantId - Claimant.ClaimantId
		/// </summary>
		public virtual IEntityRelation ClaimantEntityUsingClaimantId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Claimant", false);
				relation.AddEntityFieldPair(ClaimantFields.ClaimantId, RawTestDataFields.ClaimantId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClaimantEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RawTestDataEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RawTestDataEntity and CompanyEntity over the m:1 relation they have, using the relation between the fields:
		/// RawTestData.CompanyId - Company.CompanyId
		/// </summary>
		public virtual IEntityRelation CompanyEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Company", false);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, RawTestDataFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RawTestDataEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RawTestDataEntity and NoteEntity over the m:1 relation they have, using the relation between the fields:
		/// RawTestData.NoteId - Note.NoteId
		/// </summary>
		public virtual IEntityRelation NoteEntityUsingNoteId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Note", false);
				relation.AddEntityFieldPair(NoteFields.NoteId, RawTestDataFields.NoteId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoteEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RawTestDataEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RawTestDataEntity and RawTestDataStatusEntity over the m:1 relation they have, using the relation between the fields:
		/// RawTestData.RawTestDataStatusId - RawTestDataStatus.RawTestDataStatusId
		/// </summary>
		public virtual IEntityRelation RawTestDataStatusEntityUsingRawTestDataStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "RawTestDataStatus", false);
				relation.AddEntityFieldPair(RawTestDataStatusFields.RawTestDataStatusId, RawTestDataFields.RawTestDataStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RawTestDataStatusEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RawTestDataEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RawTestDataEntity and ReferralSourceEntity over the m:1 relation they have, using the relation between the fields:
		/// RawTestData.BillToReferralSourceId - ReferralSource.ReferralSourceId
		/// </summary>
		public virtual IEntityRelation ReferralSourceEntityUsingBillToReferralSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BillToReferralSource", false);
				relation.AddEntityFieldPair(ReferralSourceFields.ReferralSourceId, RawTestDataFields.BillToReferralSourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralSourceEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RawTestDataEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RawTestDataEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// RawTestData.PsychologistId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingPsychologistId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Psychologist", false);
				relation.AddEntityFieldPair(UserFields.UserId, RawTestDataFields.PsychologistId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RawTestDataEntity", true);
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
	internal static class StaticRawTestDataRelations
	{
		internal static readonly IEntityRelation InvoiceLineGroupRawTestDataEntityUsingRawTestDataIdStatic = new RawTestDataRelations().InvoiceLineGroupRawTestDataEntityUsingRawTestDataId;
		internal static readonly IEntityRelation ClaimantEntityUsingClaimantIdStatic = new RawTestDataRelations().ClaimantEntityUsingClaimantId;
		internal static readonly IEntityRelation CompanyEntityUsingCompanyIdStatic = new RawTestDataRelations().CompanyEntityUsingCompanyId;
		internal static readonly IEntityRelation NoteEntityUsingNoteIdStatic = new RawTestDataRelations().NoteEntityUsingNoteId;
		internal static readonly IEntityRelation RawTestDataStatusEntityUsingRawTestDataStatusIdStatic = new RawTestDataRelations().RawTestDataStatusEntityUsingRawTestDataStatusId;
		internal static readonly IEntityRelation ReferralSourceEntityUsingBillToReferralSourceIdStatic = new RawTestDataRelations().ReferralSourceEntityUsingBillToReferralSourceId;
		internal static readonly IEntityRelation UserEntityUsingPsychologistIdStatic = new RawTestDataRelations().UserEntityUsingPsychologistId;

		/// <summary>CTor</summary>
		static StaticRawTestDataRelations()
		{
		}
	}
}
