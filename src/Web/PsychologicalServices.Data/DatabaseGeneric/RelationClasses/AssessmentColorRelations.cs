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
	/// <summary>Implements the static Relations variant for the entity: AssessmentColor. </summary>
	public partial class AssessmentColorRelations
	{
		/// <summary>CTor</summary>
		public AssessmentColorRelations()
		{
		}

		/// <summary>Gets all relations of the AssessmentColorEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AssessmentEntityUsingAssessmentId);
			toReturn.Add(this.ColorEntityUsingColorId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AssessmentColorEntity and AssessmentEntity over the m:1 relation they have, using the relation between the fields:
		/// AssessmentColor.AssessmentId - Assessment.AssessmentId
		/// </summary>
		public virtual IEntityRelation AssessmentEntityUsingAssessmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Assessment", false);
				relation.AddEntityFieldPair(AssessmentFields.AssessmentId, AssessmentColorFields.AssessmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentColorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AssessmentColorEntity and ColorEntity over the m:1 relation they have, using the relation between the fields:
		/// AssessmentColor.ColorId - Color.ColorId
		/// </summary>
		public virtual IEntityRelation ColorEntityUsingColorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Color", false);
				relation.AddEntityFieldPair(ColorFields.ColorId, AssessmentColorFields.ColorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ColorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AssessmentColorEntity", true);
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
