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
	/// <summary>Implements the relations factory for the entity: CalendarNote. </summary>
	public partial class CalendarNoteRelations
	{
		/// <summary>CTor</summary>
		public CalendarNoteRelations()
		{
		}

		/// <summary>Gets all relations of the CalendarNoteEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CompanyEntityUsingCompanyId);
			toReturn.Add(this.NoteEntityUsingNoteId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between CalendarNoteEntity and CompanyEntity over the m:1 relation they have, using the relation between the fields:
		/// CalendarNote.CompanyId - Company.CompanyId
		/// </summary>
		public virtual IEntityRelation CompanyEntityUsingCompanyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Company", false);
				relation.AddEntityFieldPair(CompanyFields.CompanyId, CalendarNoteFields.CompanyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CompanyEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CalendarNoteEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CalendarNoteEntity and NoteEntity over the m:1 relation they have, using the relation between the fields:
		/// CalendarNote.NoteId - Note.NoteId
		/// </summary>
		public virtual IEntityRelation NoteEntityUsingNoteId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Note", false);
				relation.AddEntityFieldPair(NoteFields.NoteId, CalendarNoteFields.NoteId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoteEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CalendarNoteEntity", true);
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
	internal static class StaticCalendarNoteRelations
	{
		internal static readonly IEntityRelation CompanyEntityUsingCompanyIdStatic = new CalendarNoteRelations().CompanyEntityUsingCompanyId;
		internal static readonly IEntityRelation NoteEntityUsingNoteIdStatic = new CalendarNoteRelations().NoteEntityUsingNoteId;

		/// <summary>CTor</summary>
		static StaticCalendarNoteRelations()
		{
		}
	}
}
