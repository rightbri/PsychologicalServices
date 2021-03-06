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
	/// <summary>Implements the relations factory for the entity: Contact. </summary>
	public partial class ContactRelations
	{
		/// <summary>CTor</summary>
		public ContactRelations()
		{
		}

		/// <summary>Gets all relations of the ContactEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ArbitrationEntityUsingBillToContactId);
			toReturn.Add(this.ArbitrationEntityUsingDefenseLawyerId);
			toReturn.Add(this.ArbitrationEntityUsingPlaintiffLawyerId);
			toReturn.Add(this.AddressEntityUsingAddressId);
			toReturn.Add(this.ContactTypeEntityUsingContactTypeId);
			toReturn.Add(this.EmployerEntityUsingEmployerId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ContactEntity and ArbitrationEntity over the 1:n relation they have, using the relation between the fields:
		/// Contact.ContactId - Arbitration.BillToContactId
		/// </summary>
		public virtual IEntityRelation ArbitrationEntityUsingBillToContactId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Arbitrations__" , true);
				relation.AddEntityFieldPair(ContactFields.ContactId, ArbitrationFields.BillToContactId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ArbitrationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ContactEntity and ArbitrationEntity over the 1:n relation they have, using the relation between the fields:
		/// Contact.ContactId - Arbitration.DefenseLawyerId
		/// </summary>
		public virtual IEntityRelation ArbitrationEntityUsingDefenseLawyerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Arbitrations" , true);
				relation.AddEntityFieldPair(ContactFields.ContactId, ArbitrationFields.DefenseLawyerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ArbitrationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ContactEntity and ArbitrationEntity over the 1:n relation they have, using the relation between the fields:
		/// Contact.ContactId - Arbitration.PlaintiffLawyerId
		/// </summary>
		public virtual IEntityRelation ArbitrationEntityUsingPlaintiffLawyerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Arbitrations_" , true);
				relation.AddEntityFieldPair(ContactFields.ContactId, ArbitrationFields.PlaintiffLawyerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ArbitrationEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ContactEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// Contact.AddressId - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Address", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, ContactFields.AddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ContactEntity and ContactTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Contact.ContactTypeId - ContactType.ContactTypeId
		/// </summary>
		public virtual IEntityRelation ContactTypeEntityUsingContactTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ContactType", false);
				relation.AddEntityFieldPair(ContactTypeFields.ContactTypeId, ContactFields.ContactTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ContactEntity and EmployerEntity over the m:1 relation they have, using the relation between the fields:
		/// Contact.EmployerId - Employer.EmployerId
		/// </summary>
		public virtual IEntityRelation EmployerEntityUsingEmployerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Employer", false);
				relation.AddEntityFieldPair(EmployerFields.EmployerId, ContactFields.EmployerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmployerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactEntity", true);
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
	internal static class StaticContactRelations
	{
		internal static readonly IEntityRelation ArbitrationEntityUsingBillToContactIdStatic = new ContactRelations().ArbitrationEntityUsingBillToContactId;
		internal static readonly IEntityRelation ArbitrationEntityUsingDefenseLawyerIdStatic = new ContactRelations().ArbitrationEntityUsingDefenseLawyerId;
		internal static readonly IEntityRelation ArbitrationEntityUsingPlaintiffLawyerIdStatic = new ContactRelations().ArbitrationEntityUsingPlaintiffLawyerId;
		internal static readonly IEntityRelation AddressEntityUsingAddressIdStatic = new ContactRelations().AddressEntityUsingAddressId;
		internal static readonly IEntityRelation ContactTypeEntityUsingContactTypeIdStatic = new ContactRelations().ContactTypeEntityUsingContactTypeId;
		internal static readonly IEntityRelation EmployerEntityUsingEmployerIdStatic = new ContactRelations().EmployerEntityUsingEmployerId;

		/// <summary>CTor</summary>
		static StaticContactRelations()
		{
		}
	}
}
