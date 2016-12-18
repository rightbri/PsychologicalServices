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
	/// <summary>Implements the static Relations variant for the entity: Task. </summary>
	public partial class TaskRelations
	{
		/// <summary>CTor</summary>
		public TaskRelations()
		{
		}

		/// <summary>Gets all relations of the TaskEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AppointmentTaskEntityUsingTaskId);

			toReturn.Add(this.TaskStatusEntityUsingTaskStatusId);
			toReturn.Add(this.TaskTemplateEntityUsingTaskTemplateId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TaskEntity and AppointmentTaskEntity over the 1:n relation they have, using the relation between the fields:
		/// Task.TaskId - AppointmentTask.TaskId
		/// </summary>
		public virtual IEntityRelation AppointmentTaskEntityUsingTaskId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "" , true);
				relation.AddEntityFieldPair(TaskFields.TaskId, AppointmentTaskFields.TaskId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TaskEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AppointmentTaskEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between TaskEntity and TaskStatusEntity over the m:1 relation they have, using the relation between the fields:
		/// Task.TaskStatusId - TaskStatus.TaskStatusId
		/// </summary>
		public virtual IEntityRelation TaskStatusEntityUsingTaskStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TaskStatus", false);
				relation.AddEntityFieldPair(TaskStatusFields.TaskStatusId, TaskFields.TaskStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TaskStatusEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TaskEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TaskEntity and TaskTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// Task.TaskTemplateId - TaskTemplate.TaskTemplateId
		/// </summary>
		public virtual IEntityRelation TaskTemplateEntityUsingTaskTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TaskTemplate", false);
				relation.AddEntityFieldPair(TaskTemplateFields.TaskTemplateId, TaskFields.TaskTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TaskTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TaskEntity", true);
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
