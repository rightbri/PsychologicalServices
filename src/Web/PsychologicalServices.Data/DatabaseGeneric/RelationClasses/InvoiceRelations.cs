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
	/// <summary>Implements the static Relations variant for the entity: Invoice. </summary>
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
			toReturn.Add(this.InvoiceLineEntityUsingInvoiceId);
			toReturn.Add(this.InvoiceStatusChangeEntityUsingInvoiceId);
			toReturn.Add(this.InvoiceDocumentEntityUsingInvoiceId);
			toReturn.Add(this.AppointmentEntityUsingAppointmentId);
			toReturn.Add(this.InvoiceStatusEntityUsingInvoiceStatusId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between InvoiceEntity and InvoiceLineEntity over the 1:n relation they have, using the relation between the fields:
		/// Invoice.InvoiceId - InvoiceLine.InvoiceId
		/// </summary>
		public virtual IEntityRelation InvoiceLineEntityUsingInvoiceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "InvoiceLines" , true);
				relation.AddEntityFieldPair(InvoiceFields.InvoiceId, InvoiceLineFields.InvoiceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceLineEntity", false);
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

		/// <summary>Returns a new IEntityRelation object, between InvoiceEntity and InvoiceDocumentEntity over the 1:1 relation they have, using the relation between the fields:
		/// Invoice.InvoiceId - InvoiceDocument.InvoiceId
		/// </summary>
		public virtual IEntityRelation InvoiceDocumentEntityUsingInvoiceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "InvoiceDocument", true);

				relation.AddEntityFieldPair(InvoiceFields.InvoiceId, InvoiceDocumentFields.InvoiceId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceDocumentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between InvoiceEntity and AppointmentEntity over the m:1 relation they have, using the relation between the fields:
		/// Invoice.AppointmentId - Appointment.AppointmentId
		/// </summary>
		public virtual IEntityRelation AppointmentEntityUsingAppointmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Appointment", false);
				relation.AddEntityFieldPair(AppointmentFields.AppointmentId, InvoiceFields.AppointmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvoiceEntity", true);
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

		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}

		#endregion

		#region Included Code

		#endregion
	}
}
