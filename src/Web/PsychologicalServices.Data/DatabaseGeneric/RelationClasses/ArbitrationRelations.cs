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
	/// <summary>Implements the static Relations variant for the entity: Arbitration. </summary>
	public partial class ArbitrationRelations
	{
		/// <summary>CTor</summary>
		public ArbitrationRelations()
		{
		}

		/// <summary>Gets all relations of the ArbitrationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AssessmentEntityUsingAssessmentId);
			toReturn.Add(this.ContactEntityUsingDefenseLawyerId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ArbitrationEntity and AssessmentEntity over the m:1 relation they have, using the relation between the fields:
		/// Arbitration.AssessmentId - Assessment.AssessmentId
		/// </summary>
		public virtual IEntityRelation AssessmentEntityUsingAssessmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Assessment", false);
				relation.AddEntityFieldPair(AssessmentFields.AssessmentId, ArbitrationFields.AssessmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ArbitrationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ArbitrationEntity and ContactEntity over the m:1 relation they have, using the relation between the fields:
		/// Arbitration.DefenseLawyerId - Contact.ContactId
		/// </summary>
		public virtual IEntityRelation ContactEntityUsingDefenseLawyerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DefenseLawyer", false);
				relation.AddEntityFieldPair(ContactFields.ContactId, ArbitrationFields.DefenseLawyerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ArbitrationEntity", true);
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
